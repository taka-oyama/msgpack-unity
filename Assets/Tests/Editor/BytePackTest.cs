using NUnit.Framework;
using System;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class BytePackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsByte()
		{
			byte value = 0;
			byte[] data = MsgPack.Pack<byte>(value);
			byte result = MsgPack.Unpack<byte>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixIntMaxAsByte()
		{
			byte value = (byte)sbyte.MaxValue;
			byte[] data = MsgPack.Pack<byte>(value);
			byte result = MsgPack.Unpack<byte>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MinAsByte()
		{
			byte value = (byte)sbyte.MaxValue + 1;
			byte[] data = MsgPack.Pack<byte>(value);
			byte result = MsgPack.Unpack<byte>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MaxAsByte()
		{
			byte value = byte.MaxValue;
			byte[] data = MsgPack.Pack<byte>(value);
			byte result = MsgPack.Unpack<byte>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(value, result);
		}
	}
}
