using System;
using UnityEngine;

namespace UniMsgPack
{
	public class ArrayHandler : ITypeHandler
	{
		readonly Type elementType;
		readonly ITypeHandler handler;

		public ArrayHandler(Type elementType)
		{
			this.elementType = elementType;
			this.handler = TypeHandlers.Get(elementType);
		}

		public object Read(Format format, FormatReader reader)
		{
			int size = reader.ReadArrayLength(format);
			Array array = Array.CreateInstance(elementType, size);

			for(int i = 0; i < size; i++) {
				object value = handler.Read(reader.ReadFormat(), reader);
				array.SetValue(value, i);
			}
			return array;
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}

			Array values = (Array)obj;
			writer.WriteArrayLength(values.Length);
			foreach(object value in values) {
				handler.Write(value, writer);
			}
		}
	}
}
