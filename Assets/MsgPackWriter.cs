using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class MsgPackWriter
	{
		public Stream stream;
		readonly FormatWriter writer;

		public MsgPackWriter(Stream stream)
		{
			this.stream = stream;
			this.writer = new FormatWriter(stream);
		}

		public void Write(object obj)
		{
			TypeHandlers.Resolve(obj.GetType()).Write(obj, writer);
		}
	}
}