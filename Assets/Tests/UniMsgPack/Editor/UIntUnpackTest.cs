using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class UIntUnpackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsUInt()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMaxAsUInt()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UInt8MinAsUInt()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UInt8MaxAsUInt()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UInt16MinAsUInt()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UInt16MaxAsUInt()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UInt32MinAsUInt()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UInt32MaxAsUInt()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UInt64MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UInt64MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void NegativeFixIntMinAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/NegativeFixIntMin")));
		}

		[Test]
		public void NegativeFixIntMaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/NegativeFixIntMax")));
		}

		[Test]
		public void Int8MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/Int8Min")));
		}

		[Test]
		public void Int8MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/Int8Max")));
		}

		[Test]
		public void Int16MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void Int16MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void Int32MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void Int32MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void Int64MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void Int64MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<uint>(ReadFile("Ints/Int64Max")));
		}
	}
}
