using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class UShortUnpackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsUShort()
		{
			ushort value = MsgPack.Unpack<ushort>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMaxAsUShort()
		{
			ushort value = MsgPack.Unpack<ushort>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UInt8MinAsUShort()
		{
			ushort value = MsgPack.Unpack<ushort>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UInt8MaxAsUShort()
		{
			ushort value = MsgPack.Unpack<ushort>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UInt16MinAsUShort()
		{
			ushort value = MsgPack.Unpack<ushort>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UInt16MaxAsUShort()
		{
			ushort value = MsgPack.Unpack<ushort>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UInt32MinAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UInt32MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UInt64MinAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UInt64MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void NegativeFixIntMinAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/NegativeFixIntMin")));
		}

		[Test]
		public void NegativeFixIntMaxAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/NegativeFixIntMax")));
		}

		[Test]
		public void Int8MinAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/Int8Min")));
		}

		[Test]
		public void Int8MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/Int8Max")));
		}

		[Test]
		public void Int16MinAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void Int16MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void Int32MinAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void Int32MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void Int64MinAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void Int64MaxAsUShort()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<ushort>(ReadFile("Ints/Int64Max")));
		}
	}
}
