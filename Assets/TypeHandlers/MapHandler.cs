using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace UniMsgPack
{
	public class MapHandler : ITypeHandler
	{
		public readonly Type type;
		public readonly Dictionary<string, Type> fieldTypes;
		readonly ITypeHandler nameHandler;

		public MapHandler(Type type)
		{
			this.type = type;
			this.nameHandler = TypeHandler.GetHandler(typeof(string));
			this.fieldTypes = MapResolver.GetFieldTypes(type);
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsNil) return null;
			object obj = FormatterServices.GetUninitializedObject(type);
			int size = reader.ReadMapSize(format);

			Dictionary<Type, ITypeHandler> types = new Dictionary<Type, ITypeHandler>();
			foreach(Type fieldType in fieldTypes.Values) {
				types.Add(fieldType, TypeHandler.GetHandler(fieldType));
			}

			while(size > 0) {
				string name = (string)nameHandler.Read(format, reader);
				FieldInfo field = MapResolver.GetField(type, name);
				if(field != null) {
					field.SetValue(obj, Read(field.FieldType));
				}
				else {
					reader.Skip();
				}
				size = size - 1;
			}
			return obj;
		}
	}
}
