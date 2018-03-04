using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace UniMsgPack
{
	public class FormatReader
	{
		readonly Stream stream;
		byte[] staticBuffer = new byte[8];
		byte[] dynamicBuffer = new byte[64];

		public FormatReader(Stream stream)
		{
			this.stream = stream;
		}

		public Format ReadFormat()
		{
			return new Format((byte)stream.ReadByte());
		}

		public byte ReadPositiveFixInt(Format format)
		{
			return format & 0x7f;
		}

		public byte ReadUInt8()
		{
			return (byte)stream.ReadByte();
		}

		public ushort ReadUInt16()
		{
			if(stream.Read(staticBuffer, 0, 2) == 2) {
				return (ushort)((staticBuffer[0] << 8) | staticBuffer[1]);
			}
			throw new FormatException();
		}

		public uint ReadUInt32()
		{
			if(stream.Read(staticBuffer, 0, 4) == 4) {
				return ((uint)staticBuffer[0] << 24) | ((uint)staticBuffer[1] << 16) | ((uint)staticBuffer[2] << 8) | (uint)staticBuffer[3];
			}
			throw new FormatException();
		}

		public ulong ReadUInt64()
		{
			if(stream.Read(staticBuffer, 0, 8) == 8) {
				return ((ulong)staticBuffer[0] << 56) | ((ulong)staticBuffer[1] << 48) | ((ulong)staticBuffer[2] << 40) | ((ulong)staticBuffer[3] << 32) | ((ulong)staticBuffer[4] << 24) | ((ulong)staticBuffer[5] << 16) | ((ulong)staticBuffer[6] << 8) | (ulong)staticBuffer[7];
			}
			throw new FormatException();
		}

		public sbyte ReadNegativeFixInt(Format format)
		{
			return (sbyte)((format & 0x1f) - 0x20);
		}

		public sbyte ReadInt8()
		{
			return (sbyte)stream.ReadByte();
		}

		public short ReadInt16()
		{
			if(stream.Read(staticBuffer, 0, 2) == 2) {
				return (short)((staticBuffer[0] << 8) | staticBuffer[1]);
			}
			throw new FormatException();
		}

		public int ReadInt32()
		{
			if(stream.Read(staticBuffer, 0, 4) == 4) {
				return (staticBuffer[0] << 24) | (staticBuffer[1] << 16) | (staticBuffer[2] << 8) | staticBuffer[3];
			}
			throw new FormatException();
		}

		public long ReadInt64()
		{
			if(stream.Read(staticBuffer, 0, 8) == 8) {
				return ((long)staticBuffer[0] << 56) | ((long)staticBuffer[1] << 48) | ((long)staticBuffer[2] << 40) | ((long)staticBuffer[3] << 32) | ((long)staticBuffer[4] << 24) | ((long)staticBuffer[5] << 16) | ((long)staticBuffer[6] << 8) | (long)staticBuffer[7];
			}
			throw new FormatException();
		}

		public float ReadFloat32()
		{
			if(stream.Read(staticBuffer, 0, 4) == 4) {
				if(BitConverter.IsLittleEndian) {
					Array.Reverse(staticBuffer);
				}
				return BitConverter.ToSingle(staticBuffer, 0);
			}
			throw new FormatException();
		}

		public double ReadFloat64()
		{
			if(stream.Read(staticBuffer, 0, 8) == 8) {
				if(BitConverter.IsLittleEndian) {
					Array.Reverse(staticBuffer);
				}
				return BitConverter.ToDouble(staticBuffer, 0);
			}
			throw new FormatException();
		}

		public string ReadFixStr(Format format)
		{
			return ReadStringOfSize(format & 0x1f);
		}

		public string ReadStr8()
		{
			return ReadStringOfSize(ReadUInt8());
		}

		public string ReadStr16()
		{
			return ReadStringOfSize(ReadUInt16());
		}

		public string ReadStr32()
		{
			return ReadStringOfSize(Convert.ToInt32(ReadUInt32()));
		}

		public byte[] ReadBin8()
		{
			return ReadBytesOfSize(ReadUInt8());
		}

		public byte[] ReadBin16()
		{
			return ReadBytesOfSize(ReadUInt16());
		}

		public byte[] ReadBin32()
		{
			return ReadBytesOfSize(Convert.ToInt32(ReadUInt32()));
		}

		public int ReadArraySize(Format format)
		{
			if(format.IsNil) return 0;
			if(format.IsFixArray) return format & 0xf;
			if(format.IsArray16) return ReadUInt16();
			if(format.IsArray32) return Convert.ToInt32(ReadUInt32());
			throw new FormatException();
		}

		public int ReadMapSize(Format format)
		{
			if(format.IsFixMap) return format & 0xf;
			if(format.IsMap16) return ReadUInt16();
			if(format.IsMap32) return Convert.ToInt32(ReadUInt32());
			throw new FormatException();
		}

		public void Skip()
		{
			Format format = ReadFormat();
			if(format.IsNil) { return; }
			if(format.IsFalse) { return; }
			if(format.IsTrue) { return; }
			if(format.IsPositiveFixInt) { return; }
			if(format.IsNegativeFixInt) { return; }
			if(format.IsUInt8 || format.IsInt8) { FastForward(1); return; }
			if(format.IsUInt16 || format.IsInt16) { FastForward(2); return; }
			if(format.IsUInt32 || format.IsInt32) { FastForward(4); return; }
			if(format.IsUInt64 || format.IsInt64) { FastForward(8); return; }
			if(format.IsFloat32) { FastForward(4); return; }
			if(format.IsFloat64) { FastForward(8); return; }
			if(format.IsFixStr) { FastForward(format & 0x1f); return; }
			if(format.IsStr8) { FastForward(ReadUInt8()); return; }
			if(format.IsStr16) { FastForward(ReadUInt16()); return; }
			if(format.IsStr32) { FastForward(ReadUInt32()); return; }
			if(format.IsBin8) { FastForward(ReadUInt8()); return; }
			if(format.IsBin16) { FastForward(ReadUInt16()); return; }
			if(format.IsBin32) { FastForward(ReadUInt32()); return; }
			if(format.IsArrayGroup) {
				for(int size = ReadArraySize(format); size > 0; size--) {
					Skip();
				}
				return;
			}
			if(format.IsMapGroup) {
				for(int size = ReadMapSize(format); size > 0; size--) {
					Skip();
					Skip();
				}
				return;
			}
			if(format.IsFixExt1) { FastForward(2); return; }
			if(format.IsFixExt2) { FastForward(3); return; }
			if(format.IsFixExt4) { FastForward(5); return; }
			if(format.IsFixExt8) { FastForward(9); return; }
			if(format.IsFixExt16) { FastForward(17); return; }
			if(format.IsExt8) { FastForward(ReadUInt8() + 1); return; }
			if(format.IsExt16) { FastForward(ReadUInt16() + 1); return; }
			if(format.IsExt32) { FastForward(ReadUInt32() + 1); return; }
		}

		void FastForward(long offset)
		{
			if(stream.CanSeek) {
				stream.Seek(offset, SeekOrigin.Current);
			}
			else {
				while(offset > 0) {
					int size = offset > int.MaxValue ? int.MaxValue : (int)offset;
					stream.Read(dynamicBuffer, 0, size);
					offset -= int.MaxValue;
				}
			}
		}

		string ReadStringOfSize(int size)
		{
			if(dynamicBuffer.Length < size) {
				Array.Resize(ref dynamicBuffer, size);
			}
			stream.Read(dynamicBuffer, 0, size);
			return Encoding.UTF8.GetString(dynamicBuffer, 0, size);
		}

		internal byte[] ReadBytesOfSize(int size)
		{
			byte[] buffer = new byte[size];
			stream.Read(buffer, 0, size);
			return buffer;
		}
	}
}
