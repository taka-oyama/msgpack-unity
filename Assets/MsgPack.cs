using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public static class MsgPack
	{
		public static byte[] Pack<T>(T obj)
		{
			MemoryStream stream = new MemoryStream();
			Pack(stream, obj);
			return stream.ToArray();
		}

		public static Stream Pack<T>(T obj, Stream stream)
		{
			new MsgPackWriter(stream).Write(obj);
			return stream;
		}

		public static T Unpack<T>(byte[] data)
		{
			return Unpack<T>(new MemoryStream(data));
		}

		public static T Unpack<T>(Stream stream)
		{
			return new MsgPackReader(stream).Read<T>();
		}
	}
}
