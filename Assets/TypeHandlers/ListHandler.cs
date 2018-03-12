using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniMsgPack
{
	public class ListHandler : ITypeHandler
	{
		readonly Type elementType;
		readonly ITypeHandler handler;

		public ListHandler(Type elementType)
		{
			this.elementType = elementType;
			this.handler = TypeHandlers.Get(elementType);
		}

		public object Read(Format format, FormatReader reader)
		{
			Type listType = typeof(List<>).MakeGenericType(new[] { elementType });
			IList list = (IList)Activator.CreateInstance(listType);
			int size = reader.ReadArrayLength(format);
			for(int i = 0; i < size; i++) {
				list.Add(handler.Read(reader.ReadFormat(), reader));
			}
			return list;
		}

		public void Write(object obj, FormatWriter writer)
		{
			IList values = (IList)obj;
			writer.WriteArrayLength(values.Count);
			foreach(object value in values) {
				handler.Write(value, writer);
			}
		}
	}
}
