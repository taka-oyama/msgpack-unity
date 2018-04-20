using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class IntHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackPositiveFixIntMinAsInt()
		{
			int value = 0;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixIntMaxAsInt()
		{
			int value = sbyte.MaxValue;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MinAsInt()
		{
			int value = sbyte.MaxValue + 1;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MaxAsInt()
		{
			int value = byte.MaxValue;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MinAsInt()
		{
			int value = byte.MaxValue + 1;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MaxAsInt()
		{
			int value = ushort.MaxValue;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt32MinAsInt()
		{
			int value = ushort.MaxValue + 1;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNegativeFixIntMinAsInt()
		{
			int value = -32;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.NegativeFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNegativeFixIntMaxAsInt()
		{
			int value = -1;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.NegativeFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt8MinAsInt()
		{
			int value = sbyte.MinValue;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt8MaxAsInt()
		{
			int value = -33;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt16MinAsInt()
		{
			int value = short.MinValue;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt16MaxAsInt()
		{
			int value = sbyte.MinValue - 1;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt32MinAsInt()
		{
			int value = int.MinValue;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.Int32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackInt32MaxAsInt()
		{
			int value = short.MinValue - 1;
			byte[] data = Pack<int>(value);
			int result = Unpack<int>(data);
			Assert.AreEqual(Format.Int32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackPositiveFixIntMinAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8MaxAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16MinAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16MaxAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UnpackUInt32MinAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt32MaxAsInt()
		{
			Assert.Throws<OverflowException>(() => Unpack<int>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UnpackUInt64MinAsInt()
		{
			Assert.Throws<FormatException>(() => Unpack<int>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UnpackUInt64MaxAsInt()
		{
			Assert.Throws<FormatException>(() => Unpack<int>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void UnpackNegativeFixIntMinAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void UnpackInt8MinAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void UnpackInt8MaxAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void UnpackInt16MinAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void UnpackInt16MaxAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt32MinAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void UnpackInt32MaxAsInt()
		{
			int value = Unpack<int>(ReadFile("Ints/Int32Max"));
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt64MinAsInt()
		{
			Assert.Throws<FormatException>(() => Unpack<int>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void UnpackInt64MaxAsInt()
		{
			Assert.Throws<FormatException>(() => Unpack<int>(ReadFile("Ints/Int64Max")));
		}

		#endregion
	}
}
