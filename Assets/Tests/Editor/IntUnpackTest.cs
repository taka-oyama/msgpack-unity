using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class IntUnpackTest : TestBase
	{
		[Test]
		public void UnpackNegativeFixIntMin()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/NegativeFixIntMin.mpack");
			int value = MsgPack.Unpack<int>(bytes);
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void UnpackNegativeFixIntMax()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/NegativeFixIntMax.mpack");
			int value = MsgPack.Unpack<int>(bytes);
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void UnpackInt8Min()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/Int8Min.mpack");
			int value = MsgPack.Unpack<int>(bytes);
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void UnpackInt8Max()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/Int8Max.mpack");
			int value = MsgPack.Unpack<int>(bytes);
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void UnpackInt16Min()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/Int16Min.mpack");
			int value = MsgPack.Unpack<int>(bytes);
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void UnpackInt16Max()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/Int16Max.mpack");
			int value = MsgPack.Unpack<int>(bytes);
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt32Min()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/Int32Min.mpack");
			int value = MsgPack.Unpack<int>(bytes);
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void UnpackInt32Max()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/Int32Max.mpack");
			int value = MsgPack.Unpack<int>(bytes);
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt64Min()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/Int64Min.mpack");
			long value = MsgPack.Unpack<long>(bytes);
			Assert.AreEqual(long.MinValue, value);
		}

		[Test]
		public void UnpackInt64Max()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/Int64Max.mpack");
			long value = MsgPack.Unpack<long>(bytes);
			Assert.AreEqual((long)int.MinValue - 1, value);
		}
	}
}
