using System;
using System.Collections;
using System.Collections.Generic;
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
			int size = reader.ReadMapLength(format);
			while(size > 0) {
				object key = keyHandler.Read(reader.ReadFormat(), reader);
				object value = valueHandler.Read(reader.ReadFormat(), reader);
				dictionary.Add(key, value);
				size = size - 1;
			}
			return dictionary;
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			IDictionary dictionary = (IDictionary)obj;
			int size = dictionary.Count;
			foreach(DictionaryEntry kv in dictionary) {
				keyHandler.Write(kv.Key, writer);
				valueHandler.Write(kv.Value, writer);
			}
		}
	}
}
