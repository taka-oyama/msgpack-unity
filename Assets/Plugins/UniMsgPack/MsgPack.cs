using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public static class MsgPack
	{
		public static byte[] Pack<T>(T obj, SerializationContext context = null)
		{
			MemoryStream stream = new MemoryStream();
			Pack(obj, stream, context);
			return stream.ToArray();
		}

		public static void Pack<T>(T obj, Stream stream, SerializationContext context = null)
		{
			new MsgPackFormatter().Serialize(stream, obj, context);
		}

		public static T Unpack<T>(byte[] data, SerializationContext context = null)
		{
			return Unpack<T>(new MemoryStream(data), context);
		}

		public static T Unpack<T>(Stream stream, SerializationContext context = null)
		{
			return new MsgPackFormatter().Deserialize<T>(stream, context);
		}
	}
}
