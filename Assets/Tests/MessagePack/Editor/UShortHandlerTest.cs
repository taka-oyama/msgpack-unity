using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class UShortHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackPositiveFixIntMinAsUShort()
		{
			ushort value = 0;
			byte[] data = Pack<ushort>(value);
			ushort result = Unpack<ushort>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixIntMaxAsUShort()
		{
			ushort value = (ushort)sbyte.MaxValue;
			byte[] data = Pack<ushort>(value);
			ushort result = Unpack<ushort>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MinAsUShort()
		{
			ushort value = sbyte.MaxValue + 1;
			byte[] data = Pack<ushort>(value);
			ushort result = Unpack<ushort>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MaxAsUShort()
		{
			ushort value = byte.MaxValue;
			byte[] data = Pack<ushort>(value);
			ushort result = Unpack<ushort>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MinAsUShort()
		{
			ushort value = byte.MaxValue + 1;
			byte[] data = Pack<ushort>(value);
			ushort result = Unpack<ushort>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MaxAsUShort()
		{
			ushort value = ushort.MaxValue;
			byte[] data = Pack<ushort>(value);
			ushort result = Unpack<ushort>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackPositiveFixIntMinAsUShort()
		{
			ushort value = Unpack<ushort>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsUShort()
		{
			ushort value = Unpack<ushort>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsUShort()
		{
			ushort value = Unpack<ushort>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8MaxAsUShort()
		{
			ushort value = Unpack<ushort>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16MinAsUShort()
		{
			ushort value = Unpack<ushort>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16MaxAsUShort()
		{
			ushort value = Unpack<ushort>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UnpackUInt32MinAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UnpackUInt32MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UnpackUInt64MinAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UnpackUInt64MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void UnpackNegativeFixIntMinAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/NegativeFixIntMin")));
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/NegativeFixIntMax")));
		}

		[Test]
		public void UnpackInt8MinAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/Int8Min")));
		}

		[Test]
		public void UnpackInt8MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/Int8Max")));
		}

		[Test]
		public void UnpackInt16MinAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void UnpackInt16MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void UnpackInt32MinAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void UnpackInt32MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void UnpackInt64MinAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void UnpackInt64MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => Unpack<ushort>(ReadFile("Ints/Int64Max")));
		}

		#endregion
	}
}
