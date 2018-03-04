using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class ULongHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsPositiveFixInt) return (ulong)reader.ReadPositiveFixInt(format);
			if(format.IsUInt8) return (ulong)reader.ReadUInt8();
			if(format.IsUInt16) return (ulong)reader.ReadUInt16();
			if(format.IsUInt32) return (ulong)reader.ReadUInt32();
			if(format.IsUInt64) return reader.ReadUInt64();
			throw new FormatException();
		}
	}
}
