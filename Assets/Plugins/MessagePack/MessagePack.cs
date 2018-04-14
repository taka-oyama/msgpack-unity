using System.IO;
using UnityEngine;

namespace MessagePack
{
	public static class MessagePack
	{
		public static byte[] Pack<T>(T obj, SerializationContext context = null)
		{
			MemoryStream stream = new MemoryStream();
			Pack(obj, stream, context);
			return stream.ToArray();
		}

		public static void Pack<T>(T obj, Stream stream, SerializationContext context = null)
		{
			new MessagePackFormatter().Serialize(stream, obj, context);
		}

		public static T Unpack<T>(byte[] data, SerializationContext context = null)
		{
			return Unpack<T>(new MemoryStream(data), context);
		}

		public static T Unpack<T>(Stream stream, SerializationContext context = null)
		{
			return new MessagePackFormatter().Deserialize<T>(stream, context);
		}

		public static string AsJson(byte[] data, SerializationContext context = null)
		{
			return AsJson(new MemoryStream(data), context);
		}

		public static string AsJson(Stream stream, SerializationContext context = null)
		{
			return JsonConverter.Encode(stream, context);
		}
	}
}
