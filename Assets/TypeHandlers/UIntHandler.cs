using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class UIntHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsPositiveFixInt) return (uint)reader.ReadPositiveFixInt(format);
			if(format.IsUInt8) return (uint)reader.ReadUInt8();
			if(format.IsUInt16) return (uint)reader.ReadUInt16();
			if(format.IsUInt32) return reader.ReadUInt32();
			throw new FormatException();
		}
	}
}
