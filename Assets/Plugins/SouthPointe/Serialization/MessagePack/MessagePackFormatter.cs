using System;
using System.IO;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public class MessagePackFormatter
	{
		public SerializationContext Context { get; set; }

		public MessagePackFormatter(SerializationContext context = null)
		{
			this.Context = context ?? SerializationContext.Default;
		}

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
			if(bytes.Length == 0) {
				return null;
			}
			return Deserialize(type, new MemoryStream(bytes));
		}

		public object Deserialize(Type type, Stream stream)
		{
			FormatReader reader = new FormatReader(stream);
			return Context.TypeHandlers.Get(type).Read(reader.ReadFormat(), reader);
		}

		public byte[] Serialize<T>(T obj)
		{
			return Serialize(typeof(T), obj);
		}

		public byte[] Serialize(Type type, object obj)
		{
			MemoryStream stream = new MemoryStream();
			Serialize(stream, type, obj);
			return stream.ToArray();
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
			Context.TypeHandlers.Get(type).Write(obj, new FormatWriter(stream));
		}

		public string AsJson(byte[] data)
		{
			return AsJson(new MemoryStream(data));
		}

		public string AsJson(Stream stream)
		{
			return JsonConverter.Encode(stream, Context);
		}
	}
}
