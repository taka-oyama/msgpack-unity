using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class ByteHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsPositiveFixInt) return reader.ReadPositiveFixInt(format);
			if(format.IsUInt8) return reader.ReadUInt8();
			throw new FormatException();
		}
	}
}
