using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class LongUnpackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UInt8MinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UInt8MaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UInt16MinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UInt16MaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UInt32MinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UInt32MaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UInt64MinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/UInt64Min"));
			Assert.AreEqual((long)uint.MaxValue + 1, value);
		}

		[Test]
		public void UInt64MaxAsLong()
		{
			Assert.Throws<OverflowException>(() => MsgPack.Unpack<long>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void NegativeFixIntMinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void NegativeFixIntMaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void Int8MinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void Int8MaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void Int16MinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void Int16MaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void Int32MinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void Int32MaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int32Max"));
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void Int64MinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int64Min"));
			Assert.AreEqual(long.MinValue, value);
		}

		[Test]
		public void Int64MaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int64Max"));
			Assert.AreEqual((long)int.MinValue - 1, value);
		}
	}
}
