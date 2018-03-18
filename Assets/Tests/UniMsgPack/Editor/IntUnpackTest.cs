using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class IntUnpackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMaxAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UInt8MinAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UInt8MaxAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UInt16MinAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UInt16MaxAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UInt32MinAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UInt32MaxAsInt()
		{
			Assert.Throws<OverflowException>(() => MsgPack.Unpack<int>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UInt64MinAsInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<int>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UInt64MaxAsInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<int>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void NegativeFixIntMinAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void NegativeFixIntMaxAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void Int8MinAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void Int8MaxAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void Int16MinAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void Int16MaxAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void Int32MinAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void Int32MaxAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int32Max"));
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void Int64MinAsInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<int>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void Int64MaxAsInt()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<int>(ReadFile("Ints/Int64Max")));
		}
	}
}
