using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public static class MsgPack
	{
		public static byte[] Pack<T>(T obj)
		{
			MemoryStream stream = new MemoryStream();
			Pack(obj, stream);
			return stream.ToArray();
		}

		public static void Pack<T>(T obj, Stream stream)
		{
			new MsgPackFormatter().Serialize(stream, obj);
		}

		public static T Unpack<T>(byte[] data)
		{
			return Unpack<T>(new MemoryStream(data));
		}

		public static T Unpack<T>(Stream stream)
		{
			return new MsgPackFormatter().Deserialize<T>(stream);
		}
	}
}
