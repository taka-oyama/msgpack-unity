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

		public void Write(object obj, FormatWriter writer)
		{
			ushort value = Convert.ToUInt16(obj);
			Format format = writer.GetFormatForInt(value);
			writer.WriteFormat(format);
			if(format.IsPositiveFixInt) writer.WritePositiveFixInt((byte)value);
			if(format.IsUInt8) writer.WriteUInt8((byte)value);
			if(format.IsUInt16) writer.WriteUInt16(value);
			throw new FormatException();
		}
	}
}
