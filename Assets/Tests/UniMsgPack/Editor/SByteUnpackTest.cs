using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class SByteUnpackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsSByte()
		{
			sbyte value = MsgPack.Unpack<sbyte>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMaxAsSByte()
		{
			sbyte value = MsgPack.Unpack<sbyte>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UInt8MinAsSByte()
		{
			Assert.Throws<OverflowException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/UInt8Min")));
		}

		[Test]
		public void UInt8MaxAsSByte()
		{
			Assert.Throws<OverflowException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/UInt8Max")));
		}

		[Test]
		public void UInt16MinAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/UInt16Min")));
		}

		[Test]
		public void UInt16MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/UInt16Max")));
		}

		[Test]
		public void UInt32MinAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UInt32MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UInt64MinAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UInt64MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void NegativeFixIntMinAsSByte()
		{
			sbyte value = MsgPack.Unpack<sbyte>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void NegativeFixIntMaxAsSByte()
		{
			sbyte value = MsgPack.Unpack<sbyte>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void Int8MinAsSByte()
		{
			sbyte value = MsgPack.Unpack<sbyte>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void Int8MaxAsSByte()
		{
			sbyte value = MsgPack.Unpack<sbyte>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void Int16MinAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void Int16MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void Int32MinAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void Int32MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void Int64MinAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void Int64MaxAsSByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<sbyte>(ReadFile("Ints/Int64Max")));
		}
	}
}
