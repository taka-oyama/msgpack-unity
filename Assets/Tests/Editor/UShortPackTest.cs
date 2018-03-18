using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class UShortPackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsUShort()
		{
			ushort value = 0;
			byte[] data = MsgPack.Pack<ushort>(value);
			ushort result = MsgPack.Unpack<ushort>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixIntMaxAsUShort()
		{
			ushort value = (ushort)sbyte.MaxValue;
			byte[] data = MsgPack.Pack<ushort>(value);
			ushort result = MsgPack.Unpack<ushort>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MinAsUShort()
		{
			ushort value = sbyte.MaxValue + 1;
			byte[] data = MsgPack.Pack<ushort>(value);
			ushort result = MsgPack.Unpack<ushort>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MaxAsUShort()
		{
			ushort value = byte.MaxValue;
			byte[] data = MsgPack.Pack<ushort>(value);
			ushort result = MsgPack.Unpack<ushort>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MinAsUShort()
		{
			ushort value = byte.MaxValue + 1;
			byte[] data = MsgPack.Pack<ushort>(value);
			ushort result = MsgPack.Unpack<ushort>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MaxAsUShort()
		{
			ushort value = ushort.MaxValue;
			byte[] data = MsgPack.Pack<ushort>(value);
			ushort result = MsgPack.Unpack<ushort>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
