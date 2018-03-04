using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
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
			if(TypeDefinition.Undefined(type)) {
				TypeDefinition.Define(type);
			}
			return TypeDefinition.Get(type).Read(format, formatReader);
		}
	}
}