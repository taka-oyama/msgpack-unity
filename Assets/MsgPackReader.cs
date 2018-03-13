using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class MsgPackReader
	{
		public Stream stream;
		readonly FormatReader reader;

		public MsgPackReader(Stream stream)
		{
			this.stream = stream;
			this.reader = new FormatReader(stream);
		}

		public object Read(Type type)
		{
			return TypeHandlers.Resolve(type).Read(reader.ReadFormat(), reader);
		}
	}
}