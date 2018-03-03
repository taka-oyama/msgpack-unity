using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniMsgPack
{
	public struct Format
	{
		readonly byte value;

		public Format(byte value)
		{
			this.value = value;
		}

		public bool IsPositiveFixInt { get { return Between(0x00, 0x7f); } }
		public bool IsFixMap { get { return Between(0x80, 0x8f); } }
		public bool IsFixArray { get { return Between(0x90, 0x9f); } }
		public bool IsFixStr { get { return Between(0xa0, 0xbf); } }
		public bool IsNil { get { return value == 0xc0; } }
		public bool IsFalse { get { return value == 0xc2; } }
		public bool IsTrue { get { return value == 0xc3; } }
		public bool IsBin8 { get { return value == 0xc4; } }
		public bool IsBin16 { get { return value == 0xc5; } }
		public bool IsBin32 { get { return value == 0xc6; } }
		public bool IsExt8 { get { return value == 0xc7; } }
		public bool IsExt16 { get { return value == 0xc8; } }
		public bool IsExt32 { get { return value == 0xc9; } }
		public bool IsFloat32 { get { return value == 0xca; } }
		public bool IsFloat64 { get { return value == 0xcb; } }
		public bool IsUInt8 { get { return value == 0xcc; } }
		public bool IsUInt16 { get { return value == 0xcd; } }
		public bool IsUInt32 { get { return value == 0xce; } }
		public bool IsUInt64 { get { return value == 0xcf; } }
		public bool IsInt8 { get { return value == 0xd0; } }
		public bool IsInt16 { get { return value == 0xd1; } }
		public bool IsInt32 { get { return value == 0xd2; } }
		public bool IsInt64 { get { return value == 0xd3; } }
		public bool IsFixExt1 { get { return value == 0xd4; } }
		public bool IsFixExt2 { get { return value == 0xd5; } }
		public bool IsFixExt4 { get { return value == 0xd6; } }
		public bool IsFixExt8 { get { return value == 0xd7; } }
		public bool IsFixExt16 { get { return value == 0xd8; } }
		public bool IsStr8 { get { return value == 0xd9; } }
		public bool IsStr16 { get { return value == 0xda; } }
		public bool IsStr32 { get { return value == 0xdb; } }
		public bool IsArray16 { get { return value == 0xdc; } }
		public bool IsArray32 { get { return value == 0xdd; } }
		public bool IsMap16 { get { return value == 0xde; } }
		public bool IsMap32 { get { return value == 0xdf; } }
		public bool IsNegativeFixInt { get { return Between(0xe0, 0xff); } }

		public bool IsIntGroup { get { return IsPositiveFixInt || IsNegativeFixInt || IsInt8 || IsUInt8 || IsInt16 || IsUInt16 || IsInt32 || IsUInt32; } }
		public bool IsStringGroup { get { return IsFixStr || IsStr8 || IsStr16 || IsStr32; } }
		public bool IsBinaryGroup { get { return IsBin8 || IsBin16 || IsBin32; } }
		public bool IsArrayGroup { get { return IsFixArray || IsArray16 || IsArray32; } }
		public bool IsMapGroup { get { return IsFixMap || IsMap16 || IsMap32; } }

		bool Between(byte min, byte max)
		{
			return value >= min && value <= max;
		}

		public override int GetHashCode()
		{
			return this.value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if(obj is Format) {
				return this.value == ((Format)obj).value;
			}
			if(obj is byte) {
				return this.value == (byte)obj;
			}
			return false;
		}

		public static byte operator &(Format f1, byte value)
		{
			return (byte)(f1.value & value);
		}

		public static bool operator ==(Format f1, Format f2)
		{
			return f1.value == f2.value;
		}

		public static bool operator !=(Format f1, Format f2)
		{
			return f1.value != f2.value;
		}
	}

}