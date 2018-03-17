using UnityEngine;
using NUnit.Framework;
using System;

namespace UniMsgPack.Tests
{
	public class BytePackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsByte()
		{
			byte value = MsgPack.Unpack<byte>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMaxAsByte()
		{
			byte value = MsgPack.Unpack<byte>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UInt8MinAsByte()
		{
			byte value = MsgPack.Unpack<byte>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UInt8MaxAsByte()
		{
			byte value = MsgPack.Unpack<byte>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UInt16MinAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/UInt16Min")));
		}

		[Test]
		public void UInt16MaxAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/UInt16Max")));
		}

		[Test]
		public void UInt32MinAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UInt32MaxAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UInt64MinAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UInt64MaxAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void NegativeFixIntMinAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/NegativeFixIntMin")));
		}

		[Test]
		public void NegativeFixIntMaxAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/NegativeFixIntMax")));
		}

		[Test]
		public void Int8MinAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/Int8Min")));
		}

		[Test]
		public void Int8MaxAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/Int8Max")));
		}

		[Test]
		public void Int16MinAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void Int16MaxAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void Int32MinAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void Int32MaxAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void Int64MinAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void Int64MaxAsByte()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<byte>(ReadFile("Ints/Int64Max")));
		}
	}
}
