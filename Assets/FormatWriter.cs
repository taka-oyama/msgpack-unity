using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace UniMsgPack
{
	public class FormatWriter
	{
		readonly Stream stream;
		readonly byte[] staticBuffer = new byte[9];

		public FormatWriter(Stream stream)
		{
			this.stream = stream;
		}

		public void WriteFormat(byte format)
		{
			stream.WriteByte(format);
		}

		public void WriteNil()
		{
			stream.WriteByte(Format.Nil);
		}

		public void WriteTrue()
		{
			stream.WriteByte(Format.True);
		}

		public void WriteFalse()
		{
			stream.WriteByte(Format.False);
		}

		public void WritePositiveFixInt(byte i)
		{
			if(i >= 0 || i <= sbyte.MaxValue) {
				stream.WriteByte(i);
			}
			throw new OverflowException(i + " is out of range for PositiveFixInt");
		}

		public void WriteUInt8(byte i)
		{
			stream.WriteByte(i);
		}

		public void WriteUInt16(ushort i)
		{
			staticBuffer[0] = (byte)(i >> 8);
			staticBuffer[1] = (byte)i;
			stream.Write(staticBuffer, 0, 2);
		}

		public void WriteUInt32(uint i)
		{
			staticBuffer[0] = (byte)(i >> 24);
			staticBuffer[1] = (byte)(i >> 16);
			staticBuffer[2] = (byte)(i >> 8);
			staticBuffer[3] = (byte)i;
			stream.Write(staticBuffer, 0, 4);
		}

		public void WriteUInt64(ulong i)
		{
			staticBuffer[0] = (byte)(i >> 56);
			staticBuffer[1] = (byte)(i >> 48);
			staticBuffer[2] = (byte)(i >> 40);
			staticBuffer[3] = (byte)(i >> 32);
			staticBuffer[4] = (byte)(i >> 24);
			staticBuffer[5] = (byte)(i >> 16);
			staticBuffer[6] = (byte)(i >> 8);
			staticBuffer[7] = (byte)i;
			stream.Write(staticBuffer, 0, 8);
		}

		public void WriteNegativeFixInt(sbyte i)
		{
			if(i >= -32 && i <= -1) {
				stream.WriteByte((byte)(Format.NegativeFixIntMin | (byte)i));
			}
			throw new OverflowException(i + " is out of range for NegativeFixInt");
		}

		public void WriteInt8(sbyte i)
		{
			stream.WriteByte((byte)i);
		}

		public void WriteInt16(ushort i)
		{
			staticBuffer[0] = (byte)(i >> 8);
			staticBuffer[1] = (byte)i;
			stream.Write(staticBuffer, 0, 2);
		}

		public void WriteInt32(uint i)
		{
			staticBuffer[0] = (byte)(i >> 24);
			staticBuffer[1] = (byte)(i >> 16);
			staticBuffer[2] = (byte)(i >> 8);
			staticBuffer[3] = (byte)i;
			stream.Write(staticBuffer, 0, 4);
		}

		public void WriteInt64(long i)
		{
			staticBuffer[0] = (byte)(i >> 56);
			staticBuffer[1] = (byte)(i >> 48);
			staticBuffer[2] = (byte)(i >> 40);
			staticBuffer[3] = (byte)(i >> 32);
			staticBuffer[4] = (byte)(i >> 24);
			staticBuffer[5] = (byte)(i >> 16);
			staticBuffer[6] = (byte)(i >> 8);
			staticBuffer[7] = (byte)i;
			stream.Write(staticBuffer, 0, 8);
		}

		public void WriteFloat32(float f)
		{
			byte[] bytes = BitConverter.GetBytes(f);
			if(BitConverter.IsLittleEndian) {
				Array.Reverse(bytes);
			}
			stream.Write(bytes, 0, 4);
		}

		public void WriteFloat64(double f)
		{
			byte[] bytes = BitConverter.GetBytes(f);
			if(BitConverter.IsLittleEndian) {
				Array.Reverse(bytes);
			}
			stream.Write(bytes, 0, 8);
		}

		public void WriteFixStr(string s)
		{
			if(s.Length <= 31) {
				WriteString((byte)(Format.FixStrMin | (byte)s.Length), s);
			}
			throw new OverflowException(s.Length + " is out of range for FixStr");
		}

		public void WriteStr8(string s)
		{
			WriteString(Format.Str8, s);
		}

		public void WriteStr16(string s)
		{
			WriteString(Format.Str16, s);
		}

		public void WriteStr32(string s)
		{
			WriteString(Format.Str32, s);
		}

		public void WriteBin8(byte[] bytes)
		{
			WriteBinary(Format.Bin8, bytes);
		}

		public void WriteBin16(byte[] bytes)
		{
			WriteBinary(Format.Bin16, bytes);
		}

		public void WriteBin32(byte[] bytes)
		{
			WriteBinary(Format.Bin32, bytes);
		}

		public void WriteExtType(uint length, sbyte extType)
		{
			if(length == 1) stream.WriteByte(Format.FixExt1);
			if(length == 2) stream.WriteByte(Format.FixExt2);
			if(length == 4) stream.WriteByte(Format.FixExt4);
			if(length == 8) stream.WriteByte(Format.FixExt8);
			if(length == 16) stream.WriteByte(Format.FixExt16);
			if(length <= byte.MaxValue) {
				stream.WriteByte(Format.Ext8);
				stream.WriteByte((byte)length);
			}
			if(length <= byte.MaxValue) {
				stream.WriteByte(Format.Ext16);
				stream.WriteByte((byte)length);
			}
			stream.WriteByte((byte)extType);
		}

		void WriteString(byte lengthFormat, string s)
		{
			byte[] lengthAsBytes = BitConverter.GetBytes(s.Length);
			byte[] stringAsBytes = Encoding.UTF8.GetBytes(s);
			stream.WriteByte(lengthFormat);
			stream.Write(lengthAsBytes, 0, lengthAsBytes.Length);
			stream.Write(stringAsBytes, 0, stringAsBytes.Length);
		}

		void WriteBinary(byte lengthFormat, byte[] bytes)
		{
			stream.WriteByte(lengthFormat);
			stream.Write(bytes, 0, bytes.Length);
		}
	}
}
