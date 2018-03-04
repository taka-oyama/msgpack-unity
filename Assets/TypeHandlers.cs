using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniMsgPack
{
	public static class TypeHandlers
	{
		static readonly Dictionary<Type, ITypeHandler> handlers;

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
			handlers.Add(typeof(DateTime), new DateTimeHandler());
		}

		public static ITypeHandler Get<T>()
		{
			return Get(typeof(T));
		}

		public static ITypeHandler Get(Type type)
		{
			return handlers[type];
		}

		public static bool IsDefined(Type type)
		{
			return handlers.ContainsKey(type);
		}

		public static void Define(Type type, ITypeHandler handler)
		{
			handlers.Add(type, handler);
		}

		public static void DefineIfUndefined(Type type)
		{
			if(IsDefined(type)) {
				return;
			}

			if(type.IsEnum) {
				DefineIfUndefined(type, new EnumHandler(type));
				return;
			}

			if(type.IsNullable()) {
				Type underlyingType = Nullable.GetUnderlyingType(type);
				DefineIfUndefined(type, new NullableHandler(underlyingType));
				return;
			}

			if(type.IsArray) {
				Type elementType = type.GetElementType();
				DefineIfUndefined(elementType);
				DefineIfUndefined(type, new ArrayHandler(elementType));
				return;
			}

			if(typeof(IList).IsAssignableFrom(type)) {
				Type innerType = type.GetGenericArguments()[0];
				DefineIfUndefined(innerType);
				DefineIfUndefined(type, new ListHandler(innerType));
				return;
			}

			if(typeof(IDictionary).IsAssignableFrom(type)) {
				Type[] innerTypes = type.GetGenericArguments();
				DefineIfUndefined(innerTypes[0]);
				DefineIfUndefined(innerTypes[1]);
				DefineIfUndefined(type, new DictionaryHandler(type, innerTypes[0], innerTypes[1]));
				return;
			}

			if(type.IsClass || type.IsValueType) {
				foreach(Type fieldType in MapHandler.GetFieldTypes(type)) {
					DefineIfUndefined(fieldType);
				}
				DefineIfUndefined(type, new MapHandler(type));
				return;
			}

			throw new FormatException("No Type definition found for " + type);
		}

		public static void DefineIfUndefined(Type type, ITypeHandler handler)
		{
			if(IsDefined(type)) {
				return;
			}
			Define(type, handler);
		}
	}
}
