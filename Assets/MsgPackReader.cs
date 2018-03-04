using System;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace UniMsgPack
{
	public class MsgPackReader
	{
		public Stream stream;
		readonly FormatReader formatReader;

		public MsgPackReader(Stream stream)
		{
			this.stream = stream;
			this.formatReader = new FormatReader(stream);
		}

		public T Read<T>()
		{
			return Read<T>(formatReader.ReadFormat());
		}

		T Read<T>(Format format)
		{
			return (T)Read(typeof(T), format);
		}

		object Read(Type type)
		{
			return Read(type, formatReader.ReadFormat());
		}

		object Read(Type type, Format format)
		{
			if(TypeHandler.IsDefined(type)) {
				return TypeHandler.Read(type, format, formatReader);
			}

			if(format.IsMapGroup) {
				return ReadClassOrStruct(type, format);
			}

			if(type.IsArray) {
				return ReadArray(type, format);
			}

			if(type.IsEnum) {
				return ReadEnum(type, format);
			}

			if(type.IsNullable()) {
				return ReadNullable(type, format);
			}

			if(typeof(IList).IsAssignableFrom(type)) {
				return ReadList(type, format);
			}

			if(typeof(IDictionary).IsAssignableFrom(type)) {
				return ReadDictionary(type, format);
			}

			throw new FormatException();
		}

		object ReadNullable(Type type, Format format)
		{
			if(format.IsNil) return null;
			return Read(Nullable.GetUnderlyingType(type), format);
		}

		object ReadEnum(Type type, Format format)
		{
			if(format.IsIntGroup) return Enum.ToObject(type, Read<int>(format));
			if(format.IsStringGroup) return Enum.Parse(type, Read<string>(format), true);
			throw new FormatException();
		}

		Array ReadArray(Type type, Format format)
		{
			Type elementType = type.GetElementType();
			int size = formatReader.ReadArraySize(format);
			Array array = Array.CreateInstance(elementType, size);
			for(int i = 0; i < size; i++) {
				array.SetValue(Read(elementType), i);
			}
			return array;
		}

		IList ReadList(Type type, Format format)
		{
			Type elementType = type.GetGenericArguments()[0];
			Type listType = typeof(List<>).MakeGenericType(new[] { elementType });
			IList list = (IList)Activator.CreateInstance(listType);
			int size = formatReader.ReadArraySize(format);
			for(int i = 0; i < size; i++) {
				list.Add(Read(elementType));
			}
			return list;
		}

		IDictionary ReadDictionary(Type type, Format format)
		{
			if(format.IsNil) {
				return null;
			}
			IDictionary dictionary = (IDictionary)Activator.CreateInstance(type);
			Type[] types = type.GetGenericArguments();
			int size = formatReader.ReadMapSize(format);
			while(size > 0) {
				dictionary.Add(Read(types[0]), Read(types[1]));
				size = size - 1;
			}
			return dictionary;
		}

		object ReadClassOrStruct(Type type, Format format)
		{
			if(format.IsNil) {
				return null;
			}
			object obj = FormatterServices.GetUninitializedObject(type);
			int size = formatReader.ReadMapSize(format);
			while(size > 0) {
				string name = Read<string>();
				FieldInfo field = MapResolver.GetField(type, name);
				if(field != null) {
					field.SetValue(obj, Read(field.FieldType));
				}
				else {
					formatReader.Skip();
				}
				size = size - 1;
			}
			return obj;
		}
	}
}