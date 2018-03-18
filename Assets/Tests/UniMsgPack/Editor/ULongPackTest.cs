using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ULongPackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsULong()
		{
			ulong value = 0;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixIntMaxAsULong()
		{
			ulong value = (uint)sbyte.MaxValue;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MinAsULong()
		{
			ulong value = sbyte.MaxValue + 1;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MaxAsULong()
		{
			ulong value = byte.MaxValue;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MinAsULong()
		{
			ulong value = byte.MaxValue + 1;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MaxAsULong()
		{
			ulong value = ushort.MaxValue;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt32MinAsULong()
		{
			ulong value = ushort.MaxValue + 1;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt32MaxAsULong()
		{
			ulong value = uint.MaxValue;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt64MinAsULong()
		{
			ulong value = (ulong)uint.MaxValue + 1;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt64MaxAsULong()
		{
			ulong value = ulong.MaxValue;
			byte[] data = MsgPack.Pack<ulong>(value);
			ulong result = MsgPack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
