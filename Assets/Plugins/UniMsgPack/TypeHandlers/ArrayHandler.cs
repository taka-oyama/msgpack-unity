using System;
using UnityEngine;

namespace UniMsgPack
{
	public class ArrayHandler : ITypeHandler
	{
		readonly Type elementType;
		readonly ITypeHandler elementTypeHandler;

		public ArrayHandler(Type elementType, ITypeHandler elementTypehandler)
		{
			this.elementType = elementType;
			this.elementTypeHandler = elementTypehandler;
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsArrayFamily) {
				int size = reader.ReadArrayLength(format);
				Array array = Array.CreateInstance(elementType, size);
				for(int i = 0; i < size; i++) {
					object value = elementTypeHandler.Read(reader.ReadFormat(), reader);
					array.SetValue(value, i);
				}
				return array;
			}
			if(format.IsNil) {
				return Array.CreateInstance(elementType, 0);
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			Array values = (Array)obj;
			writer.WriteArrayHeader(values.Length);
			foreach(object value in values) {
				elementTypeHandler.Write(value, writer);
			}
		}
	}
}
