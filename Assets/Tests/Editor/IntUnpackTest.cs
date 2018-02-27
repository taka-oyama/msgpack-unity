using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class IntUnpackTest : TestBase
	{
		[Test]
		public void NegativeFixIntMin()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void NegativeFixIntMax()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void Int8Min()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void Int8Max()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void Int16Min()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void Int16Max()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void Int32Min()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void Int32Max()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/Int32Max"));
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void Int64Min()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int64Min"));
			Assert.AreEqual(long.MinValue, value);
		}

		[Test]
		public void Int64Max()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/Int64Max"));
			Assert.AreEqual((long)int.MinValue - 1, value);
		}
	}
}
