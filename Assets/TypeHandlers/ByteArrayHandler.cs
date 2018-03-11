using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class ByteArrayHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsNil) return null;
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
			if(value.Length <= byte.MaxValue) {
				writer.WriteFormat(Format.Bin8);
				writer.WriteBin8(value);
			}
			else if(value.Length <= ushort.MaxValue) {
				writer.WriteFormat(Format.Bin16);
				writer.WriteBin16(value);
			}
			else if(value.LongLength <= uint.MaxValue) {
				writer.WriteFormat(Format.Bin32);
				writer.WriteBin32(value);
			}
			throw new FormatException();
		}
	}
}
