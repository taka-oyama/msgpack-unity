using System;
using UnityEngine;

namespace UniMsgPack
{
	public class ShortHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsPositiveFixInt) return (short)reader.ReadPositiveFixInt(format);
			if(format.IsUInt8) return (short)reader.ReadUInt8();
			if(format.IsUInt16) return Convert.ToInt16(reader.ReadUInt16());
			if(format.IsNegativeFixInt) return(short) reader.ReadNegativeFixInt(format);
			if(format.IsInt8) return (short)reader.ReadInt8();
			if(format.IsInt16) return reader.ReadInt16();
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			short value = Convert.ToInt16(obj);
			Format format = writer.GetFormatForInt(value);
			writer.WriteFormat(format);
			if(format.IsPositiveFixInt) writer.WritePositiveFixInt((byte)value);
			if(format.IsUInt8) writer.WriteUInt8((byte)value);
			if(format.IsUInt16) writer.WriteUInt16((ushort)value);
			if(format.IsNegativeFixInt) writer.WriteNegativeFixInt((sbyte)value);
			if(format.IsInt8) writer.WriteInt8((sbyte)value);
			if(format.IsInt16) writer.WriteInt16(value);
			throw new FormatException();
		}
	}
}
