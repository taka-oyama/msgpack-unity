using System;
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

		public void Write(object obj, FormatWriter writer)
		{
			uint value = Convert.ToUInt32(obj);
			Format format = writer.GetFormatForInt(value);
			writer.WriteFormat(format);
			if(format.IsPositiveFixInt) writer.WritePositiveFixInt((byte)value);
			if(format.IsUInt8) writer.WriteUInt8((byte)value);
			if(format.IsUInt16) writer.WriteUInt16((ushort)value);
			if(format.IsUInt32) writer.WriteUInt32(value);
			throw new FormatException();
		}
	}
}
