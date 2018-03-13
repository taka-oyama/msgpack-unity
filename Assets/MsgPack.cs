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
			return (T)(new MsgPackReader(stream)).Read(typeof(T));
		}
	}
}
