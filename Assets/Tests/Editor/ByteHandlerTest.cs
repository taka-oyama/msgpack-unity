using NUnit.Framework;
using System;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class ByteHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackPositiveFixIntMinAsByte()
		{
			byte value = 0;
			byte[] data = Pack<byte>(value);
			byte result = Unpack<byte>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixIntMaxAsByte()
		{
			byte value = (byte)sbyte.MaxValue;
			byte[] data = Pack<byte>(value);
			byte result = Unpack<byte>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MinAsByte()
		{
			byte value = (byte)sbyte.MaxValue + 1;
			byte[] data = Pack<byte>(value);
			byte result = Unpack<byte>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MaxAsByte()
		{
			byte value = byte.MaxValue;
			byte[] data = Pack<byte>(value);
			byte result = Unpack<byte>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackPositiveFixIntMinAsByte()
		{
			byte value = Unpack<byte>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsByte()
		{
			byte value = Unpack<byte>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsByte()
		{
			byte value = Unpack<byte>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8MaxAsByte()
		{
			byte value = Unpack<byte>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16MinAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/UInt16Min")));
		}

		[Test]
		public void UnpackUInt16MaxAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/UInt16Max")));
		}

		[Test]
		public void UnpackUInt32MinAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UnpackUInt32MaxAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UnpackUInt64MinAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UnpackUInt64MaxAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void UnpackNegativeFixIntMinAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/NegativeFixIntMin")));
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/NegativeFixIntMax")));
		}

		[Test]
		public void UnpackInt8MinAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/Int8Min")));
		}

		[Test]
		public void UnpackInt8MaxAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/Int8Max")));
		}

		[Test]
		public void UnpackInt16MinAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void UnpackInt16MaxAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void UnpackInt32MinAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void UnpackInt32MaxAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void UnpackInt64MinAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void UnpackInt64MaxAsByte()
		{
			Assert.Throws<FormatException>(() => Unpack<byte>(ReadFile("Ints/Int64Max")));
		}

		#endregion
	}
}
