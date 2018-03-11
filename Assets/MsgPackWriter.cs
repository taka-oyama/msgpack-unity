using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class MsgPackWriter
	{
		public Stream stream;
		readonly FormatWriter formatWriter;

		public MsgPackWriter(Stream stream)
		{
			this.stream = stream;
			this.formatWriter = new FormatWriter(stream);
		}

		public void Write<T>(T obj)
		{
			Write(typeof(T), obj);
		}

		public void Write(Type type, object obj)
		{
			TypeHandlers.Resolve(type).Write(obj, formatWriter);
		}
	}
}