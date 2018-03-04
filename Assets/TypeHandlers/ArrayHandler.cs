using System;
using UnityEngine;

namespace UniMsgPack
{
	public class ArrayHandler : ITypeHandler
	{
		public readonly Type elementType;

		public ArrayHandler(Type type)
		{
			this.elementType = type.GetElementType();
		}

		public object Read(Format format, FormatReader reader)
		{
			ITypeHandler handler = TypeHandler.GetHandler(elementType);
			int size = reader.ReadArraySize(format);
			Array array = Array.CreateInstance(elementType, size);
			for(int i = 0; i < size; i++) {
				array.SetValue(handler.Read(reader.ReadFormat(), reader), i);
			}
			return array;
		}
	}
}
