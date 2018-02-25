using NUnit.Framework;
using UniMsgPack;
using UnityEngine;

public class IntTest : TestBase
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
