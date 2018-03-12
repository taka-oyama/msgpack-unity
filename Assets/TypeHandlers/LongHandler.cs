using System;
using UnityEngine;

namespace UniMsgPack
{
	public class LongHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsPositiveFixInt) return (long)reader.ReadPositiveFixInt(format);
			if(format.IsUInt8) return (long)reader.ReadUInt8();
			if(format.IsUInt16) return (long)reader.ReadUInt16();
			if(format.IsUInt32) return (long)reader.ReadUInt32();
			if(format.IsUInt64) return Convert.ToInt64(reader.ReadUInt64());
			if(format.IsNegativeFixInt) return (long)reader.ReadNegativeFixInt(format);
			if(format.IsInt8) return (long)reader.ReadInt8();
			if(format.IsInt16) return (long)reader.ReadInt16();
			if(format.IsInt32) return (long)reader.ReadInt32();
			if(format.IsInt64) return reader.ReadInt64();
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			long value = Convert.ToInt64(obj);
			Format format = writer.GetFormatForInt(value);
			writer.WriteFormat(format);
			if(format.IsPositiveFixInt) writer.WritePositiveFixInt((byte)value);
			if(format.IsUInt8) writer.WriteUInt8((byte)value);
			if(format.IsUInt16) writer.WriteUInt16((ushort)value);
			if(format.IsUInt32) writer.WriteUInt32((uint)value);
			if(format.IsUInt64) writer.WriteUInt64((ulong)value);
			if(format.IsNegativeFixInt) writer.WriteNegativeFixInt((sbyte)value);
			if(format.IsInt8) writer.WriteInt8((sbyte)value);
			if(format.IsInt16) writer.WriteInt16((short)value);
			if(format.IsInt32) writer.WriteInt32((int)value);
			if(format.IsInt64) writer.WriteInt64(value);
			throw new FormatException();
		}
	}
}
