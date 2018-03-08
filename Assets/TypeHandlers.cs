using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniMsgPack
{
	public static class TypeHandlers
	{
		static readonly Dictionary<Type, ITypeHandler> handlers;
		static readonly Dictionary<sbyte, ExtTypeHandler> extHandlers;

		static TypeHandlers()
		{
			handlers = new Dictionary<Type, ITypeHandler>();

			handlers.Add(typeof(bool), new BoolHandler());
			handlers.Add(typeof(sbyte), new SByteHandler());
			handlers.Add(typeof(byte), new ByteHandler());
			handlers.Add(typeof(short), new ShortHandler());
			handlers.Add(typeof(ushort), new UShortHandler());
			handlers.Add(typeof(int), new IntHandler());
			handlers.Add(typeof(uint), new UIntHandler());
			handlers.Add(typeof(long), new LongHandler());
			handlers.Add(typeof(ulong), new ULongHandler());
			handlers.Add(typeof(float), new FloatHandler());
			handlers.Add(typeof(double), new DoubleHandler());
			handlers.Add(typeof(string), new StringHandler());
			handlers.Add(typeof(byte[]), new ByteArrayHandler());
			handlers.Add(typeof(object), new ObjectHandler());
			handlers.Add(typeof(DateTime), new DateTimeHandler());
		}

		public static ITypeHandler Get(Type type)
		{
			lock(handlers) {
				return handlers[type];
			}
		}

		internal static ITypeHandler Resolve(Type type)
		{
			lock(handlers) {
				AddIfNotExist(type);
				return Get(type);
			}
		}

		static void AddIfNotExist(Type type)
		{
			if(handlers.ContainsKey(type)) {
				return;
			}

			if(type.IsEnum) {
				AddIfNotExist(type, new EnumHandler(type));
				return;
			}

			if(type.IsNullable()) {
				Type underlyingType = Nullable.GetUnderlyingType(type);
				AddIfNotExist(type, new NullableHandler(underlyingType));
				return;
			}

			if(type.IsArray) {
				Type elementType = type.GetElementType();
				AddIfNotExist(elementType);
				AddIfNotExist(type, new ArrayHandler(elementType));
				return;
			}

			if(typeof(IList).IsAssignableFrom(type)) {
				Type innerType = type.GetGenericArguments()[0];
				AddIfNotExist(innerType);
				AddIfNotExist(type, new ListHandler(innerType));
				return;
			}

			if(typeof(IDictionary).IsAssignableFrom(type)) {
				Type[] innerTypes = type.GetGenericArguments();
				AddIfNotExist(innerTypes[0]);
				AddIfNotExist(innerTypes[1]);
				AddIfNotExist(type, new DictionaryHandler(type, innerTypes[0], innerTypes[1]));
				return;
			}

			if(type.IsClass || type.IsValueType) {
				foreach(Type fieldType in MapHandler.GetFieldTypes(type)) {
					AddIfNotExist(fieldType);
				}
				AddIfNotExist(type, new MapHandler(type));
				return;
			}

			throw new FormatException("No Type definition found for " + type);
		}

		static void AddIfNotExist(Type type, ITypeHandler handler)
		{
			if(!handlers.ContainsKey(type)) {
				handlers.Add(type, handler);

				if(handler is ExtTypeHandler) {
					ExtTypeHandlers.AddIfNotExist((ExtTypeHandler)handler);
				}
			}
		}
	}
}
