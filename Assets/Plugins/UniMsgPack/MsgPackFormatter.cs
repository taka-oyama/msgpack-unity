using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class MsgPackFormatter
	{
		public T Deserialize<T>(byte[] bytes)
		{
			return (T)Deserialize(typeof(T), bytes);
		}

		public T Deserialize<T>(Stream stream)
		{
			return (T)Deserialize(typeof(T), stream);
		}

		public object Deserialize(Type type, byte[] bytes)
		{
			return Deserialize(type, new MemoryStream(bytes));
		}

		public object Deserialize(Type type, Stream stream)
		{
			FormatReader reader = new FormatReader(stream);
			return TypeHandlers.Resolve(type).Read(reader.ReadFormat(), reader);
		}

		public void Serialize<T>(Stream stream, T obj)
		{
			// Type is handled this way because GetType() throws an error if obj is null.
			// see https://stackoverflow.com/a/13874286/232195 more more details.
			Type type = (obj != null) ? obj.GetType() : typeof(T);

			Serialize(stream, type, obj);
		}

		public void Serialize(Stream stream, Type type, object obj)
		{
			TypeHandlers.Resolve(type).Write(obj, new FormatWriter(stream));
		}
	}
}
