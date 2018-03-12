using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class MsgPackReader
	{
		public Stream stream;
		readonly FormatReader formatReader;

		public MsgPackReader(Stream stream)
		{
			this.stream = stream;
			this.formatReader = new FormatReader(stream);
		}

		public T Read<T>()
		{
			Type type = typeof(T);
			Format format = formatReader.ReadFormat();
			return (T)TypeHandlers.Resolve(type).Read(format, formatReader);
		}
	}
}