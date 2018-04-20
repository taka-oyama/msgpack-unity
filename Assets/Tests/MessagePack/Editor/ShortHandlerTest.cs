using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class ShortHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackPositiveFixIntMinAsShort()
		{
			short value = 0;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixIntMaxAsShort()
		{
			short value = sbyte.MaxValue;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MinAsShort()
		{
			short value = sbyte.MaxValue + 1;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MaxAsShort()
		{
			short value = byte.MaxValue;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MinAsShort()
		{
			short value = byte.MaxValue + 1;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNegativeFixIntMinAsShort()
		{
			short value = -32;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.NegativeFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNegativeFixIntMaxAsShort()
		{
			short value = -1;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.NegativeFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt8MinAsShort()
		{
			short value = sbyte.MinValue;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt8MaxAsShort()
		{
			short value = -33;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt16MinAsShort()
		{
			short value = short.MinValue;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt16MaxAsShort()
		{
			short value = sbyte.MinValue - 1;
			byte[] data = Pack<short>(value);
			short result = Unpack<short>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackPositiveFixIntMinAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8MaxAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16MinAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16MaxAsShort()
		{
			Assert.Throws<OverflowException>(() => Unpack<short>(ReadFile("Ints/UInt16Max")));
		}

		[Test]
		public void UnpackUInt32MinAsShort()
		{
			Assert.Throws<FormatException>(() => Unpack<short>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UnpackUInt32MaxAsShort()
		{
			Assert.Throws<FormatException>(() => Unpack<short>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UnpackUInt64MinAsShort()
		{
			Assert.Throws<FormatException>(() => Unpack<short>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UnpackUInt64MaxAsShort()
		{
			Assert.Throws<FormatException>(() => Unpack<short>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void UnpackNegativeFixIntMinAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void UnpackInt8MinAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void UnpackInt8MaxAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void UnpackInt16MinAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void UnpackInt16MaxAsShort()
		{
			short value = Unpack<short>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt32MinAsShort()
		{
			Assert.Throws<FormatException>(() => Unpack<short>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void UnpackInt32MaxAsShort()
		{
			Assert.Throws<FormatException>(() => Unpack<short>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void UnpackInt64MinAsShort()
		{
			Assert.Throws<FormatException>(() => Unpack<short>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void UnpackInt64MaxAsShort()
		{
			Assert.Throws<FormatException>(() => Unpack<short>(ReadFile("Ints/Int64Max")));
		}

		#endregion
	}
}
