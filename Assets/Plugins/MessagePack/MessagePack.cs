using System.IO;
using UnityEngine;

namespace MessagePack
{
	public static class MessagePack
	{
		public static byte[] Pack<T>(T obj, SerializationContext context = null)
		{
			return new MessagePackFormatter(context).Serialize(obj);
		}

		public static T Unpack<T>(byte[] data, SerializationContext context = null)
		{
			return new MessagePackFormatter(context).Deserialize<T>(data);
		}

		public static string AsJson(byte[] data, SerializationContext context = null)
		{
			return new MessagePackFormatter(context).AsJson(data);
		}
	}
}
