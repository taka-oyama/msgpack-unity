using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class UIntUnpackTest : TestBase
	{
		[Test]
		public void UnpackPositiveFixIntMin()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/PositiveFixIntMin.mpack");
			uint value = MsgPack.Unpack<uint>(bytes);
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMax()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/PositiveFixIntMax.mpack");
			uint value = MsgPack.Unpack<uint>(bytes);
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8Min()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/UInt8Min.mpack");
			uint value = MsgPack.Unpack<uint>(bytes);
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8Max()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/UInt8Max.mpack");
			uint value = MsgPack.Unpack<uint>(bytes);
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16Min()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/UInt16Min.mpack");
			uint value = MsgPack.Unpack<uint>(bytes);
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16Max()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/UInt16Max.mpack");
			uint value = MsgPack.Unpack<uint>(bytes);
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UnpackUInt32Min()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/UInt32Min.mpack");
			uint value = MsgPack.Unpack<uint>(bytes);
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt32Max()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/UInt32Max.mpack");
			uint value = MsgPack.Unpack<uint>(bytes);
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UnpackUInt64Min()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/UInt64Min.mpack");
			ulong value = MsgPack.Unpack<ulong>(bytes);
			Assert.AreEqual((ulong)uint.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt64Max()
		{
			byte[] bytes = ReadFile(basePath + "/Ints/UInt64Max.mpack");
			ulong value = MsgPack.Unpack<ulong>(bytes);
			Assert.AreEqual(ulong.MaxValue, value);
		}
	}
}
