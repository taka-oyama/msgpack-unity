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
			if(format.IsNil) return default(short);
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			short value = Convert.ToInt16(obj);
			Format format = writer.GetFormatForInt(value);
			writer.WriteFormat(format);
			if(format.IsPositiveFixInt) writer.WritePositiveFixInt((byte)value);
			else if(format.IsUInt8) writer.WriteUInt8((byte)value);
			else if(format.IsUInt16) writer.WriteUInt16((ushort)value);
			else if(format.IsNegativeFixInt) writer.WriteNegativeFixInt((sbyte)value);
			else if(format.IsInt8) writer.WriteInt8((sbyte)value);
			else if(format.IsInt16) writer.WriteInt16(value);
			else throw new FormatException();
		}
	}
}
