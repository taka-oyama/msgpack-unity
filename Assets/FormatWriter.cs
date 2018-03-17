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

		public void WriteFormat(byte formatValue)
		{
			stream.WriteByte(formatValue);
		}

		public void WriteNil()
		{
			stream.WriteByte(Format.Nil);
		}

		public void Write(bool value)
		{
			stream.WriteByte(value ? Format.True : Format.False);
		}

		public void Write(byte value)
		{
			if(value <= sbyte.MaxValue) {
				WritePositiveFixInt(value);
			}
			else {
				WriteFormat(Format.UInt8);
				WriteUInt8((byte)value);
			}
		}

		public void Write(ushort value)
		{
			if(value <= byte.MaxValue) {
				Write((byte)value);
			}
			else {
				WriteFormat(Format.UInt16);
				WriteUInt16(value);				
			}
		}

		public void Write(uint value)
		{
			if(value <= ushort.MaxValue) {
				Write((ushort)value);
			}
			else {
				WriteFormat(Format.UInt32);
				WriteUInt32(value);
			}
		}

		public void Write(ulong value)
		{
			if(value <= uint.MaxValue) {
				Write((ulong)value);
			}
			else {
				WriteFormat(Format.UInt64);
				WriteUInt64(value);
			}
		}

		public void Write(sbyte value)
		{
			if(value >= 0) {
				Write((byte)value);
			}
			else if(value >= -32) {
				WriteNegativeFixInt(value);
			}
			else {
				WriteFormat(Format.Int8);
				WriteInt8(value);
			}
		}

		public void Write(short value)
		{
			if(value >= 0) {
				Write((ushort)value);
			}
			else if(value > short.MinValue) {
				Write((sbyte)value);
			}
			else {
				WriteFormat(Format.Int16);
				WriteInt16(value);
			}
		}

		public void Write(int value)
		{
			if(value >= 0) {
				Write((uint)value);
			}
			else if(value > int.MinValue) {
				Write((short)value);
			}
			else {
				WriteFormat(Format.Int32);
				WriteInt32(value);
			}
		}

		public void Write(long value)
		{
			if(value >= 0) {
				Write((uint)value);
			}
			else if(value > long.MinValue) {
				Write((int)value);
			}
			else {
				WriteFormat(Format.Int64);
				WriteInt64(value);
			}
		}

		public void Write(float f)
		{
			byte[] bytes = BitConverter.GetBytes(f);
			if(BitConverter.IsLittleEndian) {
				Array.Reverse(bytes);
			}
			WriteFormat(Format.Float32);
			stream.Write(bytes, 0, 4);
		}

		public void Write(double f)
		{
			byte[] bytes = BitConverter.GetBytes(f);
			if(BitConverter.IsLittleEndian) {
				Array.Reverse(bytes);
			}
			WriteFormat(Format.Float64);
			stream.Write(bytes, 0, 8);
		}

		public void Write(string str)
		{
			if(str == null) {
				WriteNil();
				return;
			}
			
			if(str.Length <= 31) {
				WriteFormat((byte)(Format.FixStrMin | (byte)str.Length));
			}
			else if(str.Length <= byte.MaxValue) {
				WriteFormat(Format.Str8);
				WriteUInt8((byte)str.Length);
			}
			else if(str.Length <= ushort.MaxValue) {
				WriteFormat(Format.Str16);
				WriteUInt16((ushort)str.Length);
			}
			else {
				WriteFormat(Format.Str32);
				WriteUInt32((uint)str.Length);
			}

			byte[] stringAsBytes = Encoding.UTF8.GetBytes(str);
			stream.Write(stringAsBytes, 0, stringAsBytes.Length);
		}

		public void Write(byte[] bytes)
		{
			if(bytes == null) {
				WriteNil();
				return;
			}

			if(bytes.Length <= byte.MaxValue) {
				WriteFormat(Format.Bin8);
				WriteUInt8((byte)bytes.Length);
			}
			else if(bytes.Length <= ushort.MaxValue) {
				WriteFormat(Format.Bin16);
				WriteUInt16((ushort)bytes.Length);
			}
			else {
				WriteFormat(Format.Bin32);
				WriteUInt32((uint)bytes.Length);				
			}
			stream.Write(bytes, 0, bytes.Length);
		}

		public void WriteArrayHeader(int length)
		{
			if(length <= 15) {
				WriteFormat((byte)(length | Format.FixArrayMin));
			}
			else if(length <= ushort.MaxValue) {
				WriteFormat(Format.Array16);
				WriteUInt16((ushort)length);
			}
			else {
				WriteFormat(Format.Array32);
				WriteUInt32((uint)length);
			}
		}

		public void WriteMapHeader(int length)
		{
			if(length <= 15) {
				WriteFormat((byte)(length | Format.FixMapMin));
			}
			else if(length <= ushort.MaxValue) {
				WriteFormat(Format.Map16);
				WriteUInt16((ushort)length);
			}
			else {
				WriteFormat(Format.Map32);
				WriteUInt32((uint)length);
			}
		}

		public void WriteExtHeader(byte format, uint length, sbyte extType)
		{
			if(length == 1) {
				WriteFormat(Format.FixExt1);
			}
			else if(length == 2) {
				WriteFormat(Format.FixExt2);
			}
			else if(length == 4) {
				WriteFormat(Format.FixExt4);
			}
			else if(length == 8) {
				WriteFormat(Format.FixExt8);
			}
			else if(length == 16) {
				WriteFormat(Format.FixExt16);
			}
			else if(length <= byte.MaxValue) {
				WriteFormat(Format.Ext8);
				WriteUInt8((byte)length);
			}
			else if(length <= ushort.MaxValue) {
				WriteFormat(Format.Ext16);
				WriteUInt16((ushort)length);
			}
			else if(length <= uint.MaxValue) {
				WriteFormat(Format.Ext32);
				WriteUInt32(length);				
			}
			else {
				throw new FormatException();
			}
			stream.WriteByte((byte)extType);
		}

		public void WritePositiveFixInt(byte i)
		{
			if(i >= 0 || i <= sbyte.MaxValue) {
				stream.WriteByte((byte)(i | Format.PositiveFixIntMin));
			}
			else {
				throw new OverflowException(i + " is out of range for PositiveFixInt");
			}
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
				stream.WriteByte((byte)((byte)i | Format.NegativeFixIntMin));
			}
			else {
				throw new OverflowException(i + " is out of range for NegativeFixInt");
			}
		}

		public void WriteInt8(sbyte i)
		{
			stream.WriteByte((byte)i);
		}

		public void WriteInt16(short i)
		{
			staticBuffer[0] = (byte)(i >> 8);
			staticBuffer[1] = (byte)i;
			stream.Write(staticBuffer, 0, 2);
		}

		public void WriteInt32(int i)
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
	}
}
