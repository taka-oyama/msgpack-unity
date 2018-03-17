using System;
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
			if(format.IsNil) return default(ulong);
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			ulong value = Convert.ToUInt64(obj);
			Format format = writer.GetFormatForInt(value);
			writer.WriteFormat(format);
			if(format.IsPositiveFixInt) writer.WritePositiveFixInt((byte)value);
			else if(format.IsUInt8) writer.WriteUInt8((byte)value);
			else if(format.IsUInt16) writer.WriteUInt16((ushort)value);
			else if(format.IsUInt32) writer.WriteUInt32((uint)value);
			else if(format.IsUInt64) writer.WriteUInt64(value);
			else throw new FormatException();
		}
	}
}
