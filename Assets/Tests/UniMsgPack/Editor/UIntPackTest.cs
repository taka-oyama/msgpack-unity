using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class UIntPackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsUInt()
		{
			uint value = 0;
			byte[] data = MsgPack.Pack<uint>(value);
			uint result = MsgPack.Unpack<uint>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixIntMaxAsUInt()
		{
			uint value = (uint)sbyte.MaxValue;
			byte[] data = MsgPack.Pack<uint>(value);
			uint result = MsgPack.Unpack<uint>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MinAsUInt()
		{
			uint value = sbyte.MaxValue + 1;
			byte[] data = MsgPack.Pack<uint>(value);
			uint result = MsgPack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MaxAsUInt()
		{
			uint value = byte.MaxValue;
			byte[] data = MsgPack.Pack<uint>(value);
			uint result = MsgPack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MinAsUInt()
		{
			uint value = byte.MaxValue + 1;
			byte[] data = MsgPack.Pack<uint>(value);
			uint result = MsgPack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MaxAsUInt()
		{
			uint value = ushort.MaxValue;
			byte[] data = MsgPack.Pack<uint>(value);
			uint result = MsgPack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt32MinAsUInt()
		{
			uint value = ushort.MaxValue + 1;
			byte[] data = MsgPack.Pack<uint>(value);
			uint result = MsgPack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt32MaxAsUInt()
		{
			uint value = uint.MaxValue;
			byte[] data = MsgPack.Pack<uint>(value);
			uint result = MsgPack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
