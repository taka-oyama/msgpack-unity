using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class ByteArrayHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsNil) return new byte[0];
			if(format.IsBin8) return reader.ReadBin8();
			if(format.IsBin16) return reader.ReadBin16();
			if(format.IsBin32) return reader.ReadBin32();
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			byte[] value = (byte[])obj;
			Format format = writer.GetFormatForBinary(value);
			if(format.IsBin8) writer.WriteBin8(value);
			else if(format.IsBin16) writer.WriteBin16(value);
			else if(format.IsBin32) writer.WriteBin32(value);
			else throw new FormatException();
		}
	}
}
