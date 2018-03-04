using System;
using UnityEngine;

namespace UniMsgPack
{
	public class UShortHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsPositiveFixInt) return (ushort)reader.ReadPositiveFixInt(format);
			if(format.IsUInt8) return (ushort)reader.ReadUInt8();
			if(format.IsUInt16) return reader.ReadUInt16();
			throw new FormatException();
		}
	}
}
