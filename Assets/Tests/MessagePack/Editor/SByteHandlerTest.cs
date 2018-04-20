using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class SByteHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackPositiveFixIntMinAsSByte()
		{
			sbyte value = 0;
			byte[] data = Pack<sbyte>(value);
			sbyte result = Unpack<sbyte>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixIntMaxAsSByte()
		{
			sbyte value = sbyte.MaxValue;
			byte[] data = Pack<sbyte>(value);
			sbyte result = Unpack<sbyte>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNegativeFixIntMinAsSByte()
		{
			sbyte value = -32;
			byte[] data = Pack<sbyte>(value);
			sbyte result = Unpack<sbyte>(data);
			Assert.AreEqual(Format.NegativeFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNegativeFixIntMaxAsSByte()
		{
			sbyte value = -1;
			byte[] data = Pack<sbyte>(value);
			sbyte result = Unpack<sbyte>(data);
			Assert.AreEqual(Format.NegativeFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackPositiveFixIntMinAsSByte()
		{
			sbyte value = Unpack<sbyte>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsSByte()
		{
			sbyte value = Unpack<sbyte>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsSByte()
		{
			Assert.Throws<OverflowException>(() => Unpack<sbyte>(ReadFile("Ints/UInt8Min")));
		}

		[Test]
		public void UnpackUInt8MaxAsSByte()
		{
			Assert.Throws<OverflowException>(() => Unpack<sbyte>(ReadFile("Ints/UInt8Max")));
		}

		[Test]
		public void UnpackUInt16MinAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/UInt16Min")));
		}

		[Test]
		public void UnpackUInt16MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/UInt16Max")));
		}

		[Test]
		public void UnpackUInt32MinAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UnpackUInt32MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UnpackUInt64MinAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UnpackUInt64MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void UnpackNegativeFixIntMinAsSByte()
		{
			sbyte value = Unpack<sbyte>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsSByte()
		{
			sbyte value = Unpack<sbyte>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void UnpackInt8MinAsSByte()
		{
			sbyte value = Unpack<sbyte>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void UnpackInt8MaxAsSByte()
		{
			sbyte value = Unpack<sbyte>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void UnpackInt16MinAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void UnpackInt16MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void UnpackInt32MinAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void UnpackInt32MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void UnpackInt64MinAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void UnpackInt64MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => Unpack<sbyte>(ReadFile("Ints/Int64Max")));
		}

		#endregion
	}
}
