using UnityEngine;
using System.Collections;
using System;

namespace UniMsgPack
{
	public class CharHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsPositiveFixInt) return Convert.ToChar(reader.ReadPositiveFixInt(format));
			if(format.IsUInt8) return Convert.ToChar(reader.ReadUInt8());
			if(format.IsUInt16) return Convert.ToChar(reader.ReadUInt16());
			if(format.IsNil) return default(char);
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			writer.Write(Convert.ToUInt16(obj));
		}
	}
}
