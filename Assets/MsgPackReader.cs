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
			return Read<T>(formatReader.ReadFormat());
		}

		T Read<T>(Format format)
		{
			return (T)Read(typeof(T), format);
		}

		object Read(Type type)
		{
			return Read(type, formatReader.ReadFormat());
		}

		object Read(Type type, Format format)
		{
			return TypeHandlers.Resolve(type).Read(format, formatReader);
		}
	}
}