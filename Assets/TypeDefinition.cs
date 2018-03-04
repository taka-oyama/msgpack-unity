using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public static class TypeDefinition
	{
		static readonly Dictionary<Type, ITypeHandler> handlers;

		static TypeDefinition()
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

		public static bool Defined(Type type)
		{
			return handlers.ContainsKey(type);
		}

		public static bool Undefined(Type type)
		{
			return !handlers.ContainsKey(type);
		}

		public static void Define(Type type)
		{
			if(Defined(type)) {
				return;
			}

			if(type.IsEnum) {
				Define(type, new EnumHandler(type));
				return;
			}

			if(type.IsNullable()) {
				Type underlyingType = Nullable.GetUnderlyingType(type);
				Define(type, new NullableHandler(underlyingType));
				return;
			}

			if(type.IsArray) {
				Type elementType = type.GetElementType();
				Define(elementType);
				Define(type, new ArrayHandler(elementType));
				return;
			}

			if(typeof(IList).IsAssignableFrom(type)) {
				Type innerType = type.GetGenericArguments()[0];
				Define(innerType);
				Define(type, new ListHandler(innerType));
				return;
			}

			if(typeof(IDictionary).IsAssignableFrom(type)) {
				Type[] innerTypes = type.GetGenericArguments();
				Define(innerTypes[0]);
				Define(innerTypes[1]);
				Define(type, new DictionaryHandler(type, innerTypes[0], innerTypes[1]));
				return;
			}

			if(type.IsClass || type.IsValueType) {
				foreach(Type fieldType in MapHandler.GetFieldTypes(type)) {
					Define(fieldType);
				}
				Define(type, new MapHandler(type));
				return;
			}

			throw new FormatException("No Type definition found for " + type);
		}

		public static void Define(Type type, ITypeHandler handler)
		{
			if(Defined(type)) {
				return;
			}
			handlers.Add(type, handler);
		}

		public static ITypeHandler Get<T>()
		{
			return Get(typeof(T));
		}

		public static ITypeHandler Get(Type type)
		{
			return handlers[type];
		}
	}
}
