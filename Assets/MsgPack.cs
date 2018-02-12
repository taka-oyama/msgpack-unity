using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public static class MsgPack
	{
		public static void Pack(Stream stream)
		{

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
