using System;
using NUnit.Framework;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class LongHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackPositiveFixIntMinAsLong()
		{
			long value = 0;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixIntMaxAsLong()
		{
			long value = sbyte.MaxValue;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MinAsLong()
		{
			long value = sbyte.MaxValue + 1;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MaxAsLong()
		{
			long value = byte.MaxValue;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MinAsLong()
		{
			long value = byte.MaxValue + 1;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MaxAsLong()
		{
			long value = ushort.MaxValue;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt32MinAsLong()
		{
			long value = ushort.MaxValue + 1;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt32MaxAsLong()
		{
			long value = uint.MaxValue;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt64MinAsLong()
		{
			long value = (long)uint.MaxValue + 1;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.UInt64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNegativeFixIntMinAsLong()
		{
			long value = -32;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.NegativeFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNegativeFixIntMaxAsLong()
		{
			long value = -1;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.NegativeFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt8MinAsLong()
		{
			long value = sbyte.MinValue;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt8MaxAsLong()
		{
			long value = -33;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt16MinAsLong()
		{
			long value = short.MinValue;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt16MaxAsLong()
		{
			long value = sbyte.MinValue - 1;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt32MinAsLong()
		{
			long value = int.MinValue;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.Int32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt32MaxAsLong()
		{
			long value = short.MinValue - 1;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.Int32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt64MinAsLong()
		{
			long value = long.MinValue;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.Int64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt64MaxAsLong()
		{
			long value = (long)int.MinValue - 1;
			byte[] data = Pack<long>(value);
			long result = Unpack<long>(data);
			Assert.AreEqual(Format.Int64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackPositiveFixIntMinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8MaxAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16MinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16MaxAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UnpackUInt32MinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt32MaxAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UnpackUInt64MinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/UInt64Min"));
			Assert.AreEqual((long)uint.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt64MaxAsLong()
		{
			Assert.Throws<OverflowException>(() => Unpack<long>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void UnpackNegativeFixIntMinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void UnpackInt8MinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void UnpackInt8MaxAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void UnpackInt16MinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void UnpackInt16MaxAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt32MinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void UnpackInt32MaxAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/Int32Max"));
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt64MinAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/Int64Min"));
			Assert.AreEqual(long.MinValue, value);
		}

		[Test]
		public void UnpackInt64MaxAsLong()
		{
			long value = Unpack<long>(ReadFile("Ints/Int64Max"));
			Assert.AreEqual((long)int.MinValue - 1, value);
		}

		#endregion
	}
}
