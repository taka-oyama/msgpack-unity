using System;
using System.Collections;
using UnityEngine;

namespace UniMsgPack
{
	public class DictionaryHandler : ITypeHandler
	{
		readonly Type type;
		readonly ITypeHandler keyHandler;
		readonly ITypeHandler valueHandler;

		public DictionaryHandler(Type type, Type keyType, Type valueType)
		{
			this.type = type;
			this.keyHandler = TypeHandlers.Get(keyType);
			this.valueHandler = TypeHandlers.Get(valueType);
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsNil) {
				return null;
			}
			IDictionary dictionary = (IDictionary)Activator.CreateInstance(type);
			int size = reader.ReadMapSize(format);
			while(size > 0) {
				object key = keyHandler.Read(reader.ReadFormat(), reader);
				object value = valueHandler.Read(reader.ReadFormat(), reader);
				dictionary.Add(key, value);
				size = size - 1;
			}
			return dictionary;
		}
	}
}
