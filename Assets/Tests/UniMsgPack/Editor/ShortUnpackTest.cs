using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ShortUnpackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMaxAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UInt8MinAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UInt8MaxAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UInt16MinAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UInt16MaxAsShort()
		{
			Assert.Throws<OverflowException>(() => MsgPack.Unpack<short>(ReadFile("Ints/UInt16Max")));
		}

		[Test]
		public void UInt32MinAsShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<short>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UInt32MaxAsShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<short>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UInt64MinAsShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<short>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UInt64MaxAsShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<short>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void NegativeFixIntMinAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void NegativeFixIntMaxAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void Int8MinAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void Int8MaxAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void Int16MinAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void Int16MaxAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void Int32MinAsShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<short>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void Int32MaxAsShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<short>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void Int64MinAsShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<short>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void Int64MaxAsShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<short>(ReadFile("Ints/Int64Max")));
		}
	}
}
