using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class IntPackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsInt()
		{
			int value = 0;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixIntMaxAsInt()
		{
			int value = sbyte.MaxValue;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MinAsInt()
		{
			int value = sbyte.MaxValue + 1;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MaxAsInt()
		{
			int value = byte.MaxValue;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MinAsInt()
		{
			int value = byte.MaxValue + 1;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MaxAsInt()
		{
			int value = ushort.MaxValue;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt32MinAsInt()
		{
			int value = ushort.MaxValue + 1;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void NegativeFixIntMinAsInt()
		{
			int value = -32;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.NegativeFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void NegativeFixIntMaxAsInt()
		{			
			int value = -1;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.NegativeFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int8MinAsInt()
		{
			int value = sbyte.MinValue;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int8MaxAsInt()
		{
			int value = -33;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int16MinAsInt()
		{
			int value = short.MinValue;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int16MaxAsInt()
		{
			int value = sbyte.MinValue - 1;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int32MinAsInt()
		{
			int value = int.MinValue;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.Int32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int32MaxAsInt()
		{
			int value = short.MinValue - 1;
			byte[] data = MsgPack.Pack<int>(value);
			int result = MsgPack.Unpack<int>(data);
			Assert.AreEqual(Format.Int32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
