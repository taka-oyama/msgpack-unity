using System;
using UnityEngine;

namespace UniMsgPack
{
	public class ByteHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsPositiveFixInt) return reader.ReadPositiveFixInt(format);
			if(format.IsUInt8) return reader.ReadUInt8();
			if(format.IsNil) return default(byte);
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			byte value = Convert.ToByte(obj);
			if(value <= sbyte.MaxValue) {
				writer.WritePositiveFixInt(value);
			}
			else if(value <= byte.MaxValue) {
				writer.WriteFormat(Format.UInt8);
				writer.WriteUInt8(value);
			} else {
				throw new FormatException();
			}
		}
	}
}
