using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public static class TypeHandler
	{
		static readonly Dictionary<Type, ITypeHandler> handlers;

		static TypeHandler()
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

		public static bool IsDefined(Type type)
		{
			return handlers.ContainsKey(type);
		}

		public static void Define(Type type)
		{
			if(type.IsArray) {
				ArrayHandler handler = new ArrayHandler(type);
				Define(type, handler);
				if(!IsDefined(handler.elementType)) {
					Define(handler.elementType);
				}
			}
			if(type.IsClass || type.IsValueType) {
				MapHandler handler = new MapHandler(type);
				Define(type, handler);
				foreach(Type fieldType in handler.fieldTypes.Values) {
					if(!IsDefined(fieldType)) {
						Define(fieldType);
					}
				}
			}
		}

		public static void Define(Type type, ITypeHandler handler)
		{
			handlers.Add(type, handler);
		}

		public static ITypeHandler GetHandler(Type type)
		{
			if(IsDefined(type)) {
				return handlers[type];
			}
			return null;
		}

		public static object Read(Type type, Format format, FormatReader reader)
		{
			return handlers[type].Read(format, reader);
		}
	}
}
