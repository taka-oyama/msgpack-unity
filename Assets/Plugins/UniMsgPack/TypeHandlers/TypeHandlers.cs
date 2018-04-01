using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniMsgPack
{
	public class TypeHandlers
	{
		readonly SerializationContext context;
		readonly Dictionary<Type, ITypeHandler> handlers;
		readonly Dictionary<sbyte, IExtTypeHandler> extHandlers;
		readonly Dictionary<Type, MapDefinition> mapDefinitions;

		public TypeHandlers(SerializationContext context)
		{
			this.context = context;

			this.handlers = new Dictionary<Type, ITypeHandler> {
				{ typeof(bool), new BoolHandler() },
				{ typeof(sbyte), new SByteHandler() },
				{ typeof(byte), new ByteHandler() },
				{ typeof(short), new ShortHandler() },
				{ typeof(ushort), new UShortHandler() },
				{ typeof(int), new IntHandler() },
				{ typeof(uint), new UIntHandler() },
				{ typeof(long), new LongHandler() },
				{ typeof(ulong), new ULongHandler() },
				{ typeof(float), new FloatHandler() },
				{ typeof(double), new DoubleHandler() },
				{ typeof(string), new StringHandler() },
				{ typeof(byte[]), new ByteArrayHandler() },
				{ typeof(char), new CharHandler() },
				{ typeof(decimal), new DecimalHandler(context) },
				{ typeof(object), new ObjectHandler(context) },
				{ typeof(DateTime), new DateTimeHandler(context) },
				{ typeof(Color), new ColorHandler(context) },
				{ typeof(Color32), new Color32Handler(context) },
				{ typeof(Guid), new GuidHandler(context) },
				{ typeof(Quaternion), new QuaternionHandler(context) },
				{ typeof(TimeSpan), new TimeSpanHandler(context) },
				{ typeof(Uri), new UriHandler(context) },
				{ typeof(Vector2), new Vector2Handler(context) },
				{ typeof(Vector2Int), new Vector2IntHandler(context) },
				{ typeof(Vector3), new Vector3Handler(context) },
				{ typeof(Vector3Int), new Vector3IntHandler(context) },
				{ typeof(Vector4), new Vector4Handler(context) },
			};

			this.extHandlers = new Dictionary<sbyte, IExtTypeHandler>() {
				{ -1, new DateTimeHandler(context) },
			};

			this.mapDefinitions = new Dictionary<Type, MapDefinition>();
		}

		public ITypeHandler Get<T>()
		{
			return Get(typeof(T));
		}

		public ITypeHandler Get(Type type)
		{
			lock(handlers) {
				AddIfNotExist(type);
				return handlers[type];
			}
		}

		public IExtTypeHandler GetExt(sbyte extType)
		{
			lock(handlers) {
				return extHandlers[extType];
			}
		}

		public void SetHandler(Type type, ITypeHandler handler)
		{
			lock(handlers) {
				handlers[type] = handler;
			}

			if(handler is IExtTypeHandler) {
				IExtTypeHandler extHandler = (IExtTypeHandler)handler;
				lock(extHandlers) {
					extHandlers[extHandler.ExtType] = extHandler;
				}
			}
		}

		void AddIfNotExist(Type type)
		{
			if(handlers.ContainsKey(type)) {
				return;
			}

			if(type.IsEnum) {
				AddIfNotExist(type, new EnumHandler(context, type));
				return;
			}

			if(type.IsNullable()) {
				Type underlyingType = Nullable.GetUnderlyingType(type);
				AddIfNotExist(type, new NullableHandler(Get(underlyingType)));
				return;
			}

			if(type.IsArray) {
				Type elementType = type.GetElementType();
				AddIfNotExist(type, new ArrayHandler(elementType, Get(elementType)));
				return;
			}

			if(typeof(IList).IsAssignableFrom(type)) {
				Type innerType = type.GetGenericArguments()[0];
				AddIfNotExist(type, new ListHandler(innerType, Get(innerType)));
				return;
			}

			if(typeof(IDictionary).IsAssignableFrom(type)) {
				Type[] innerTypes = type.GetGenericArguments();
				AddIfNotExist(type, new DictionaryHandler(type, Get(innerTypes[0]), Get(innerTypes[1])));
				return;
			}

			if(type.IsClass || type.IsValueType) {
				if(!mapDefinitions.ContainsKey(type)) {
					mapDefinitions[type] = new MapDefinition(type, context.typeHandlers);
				}
				AddIfNotExist(type, new MapHandler(context, mapDefinitions[type]));
				return;
			}

			throw new FormatException("No Type definition found for " + type);
		}

		void AddIfNotExist(Type type, ITypeHandler handler)
		{
			if(!handlers.ContainsKey(type)) {
				handlers.Add(type, handler);
			}
		}
	}
}
