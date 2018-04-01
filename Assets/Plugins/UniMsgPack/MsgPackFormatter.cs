using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class MsgPackFormatter
	{
		public T Deserialize<T>(byte[] bytes, SerializationContext context = null)
		{
			return (T)Deserialize(typeof(T), bytes, context);
		}

		public T Deserialize<T>(Stream stream, SerializationContext context = null)
		{
			return (T)Deserialize(typeof(T), stream, context);
		}

		public object Deserialize(Type type, byte[] bytes, SerializationContext context = null)
		{
			return Deserialize(type, new MemoryStream(bytes), context);
		}

		public object Deserialize(Type type, Stream stream, SerializationContext context = null)
		{
			FormatReader reader = new FormatReader(stream);
			context = context ?? SerializationContext.Default;
			return context.typeHandlers.Get(type).Read(reader.ReadFormat(), reader);
		}

		public void Serialize<T>(Stream stream, T obj, SerializationContext context = null)
		{
			// Type is handled this way because GetType() throws an error if obj is null.
			// see https://stackoverflow.com/a/13874286/232195 more more details.
			Type type = (obj != null) ? obj.GetType() : typeof(T);

			Serialize(stream, type, obj, context);
		}

		public void Serialize(Stream stream, Type type, object obj, SerializationContext context = null)
		{
			context = context ?? SerializationContext.Default;
			context.typeHandlers.Get(type).Write(obj, new FormatWriter(stream));
		}
	}
}
