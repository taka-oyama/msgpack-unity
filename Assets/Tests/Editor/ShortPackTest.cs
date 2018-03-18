using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ShortPackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsShort()
		{
			short value = 0;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixIntMaxAsShort()
		{
			short value = sbyte.MaxValue;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MinAsShort()
		{
			short value = sbyte.MaxValue + 1;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MaxAsShort()
		{
			short value = byte.MaxValue;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MinAsShort()
		{
			short value = byte.MaxValue + 1;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void NegativeFixIntMinAsShort()
		{
			short value = -32;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.NegativeFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void NegativeFixIntMaxAsShort()
		{
			short value = -1;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.NegativeFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int8MinAsShort()
		{
			short value = sbyte.MinValue;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int8MaxAsShort()
		{
			short value = -33;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int16MinAsShort()
		{
			short value = short.MinValue;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int16MaxAsShort()
		{
			short value = sbyte.MinValue - 1;
			byte[] data = MsgPack.Pack<short>(value);
			short result = MsgPack.Unpack<short>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
