using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class LongPackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsLong()
		{
			long value = 0;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixIntMaxAsLong()
		{
			long value = sbyte.MaxValue;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MinAsLong()
		{
			long value = sbyte.MaxValue + 1;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MaxAsLong()
		{
			long value = byte.MaxValue;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MinAsLong()
		{
			long value = byte.MaxValue + 1;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MaxAsLong()
		{
			long value = ushort.MaxValue;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt32MinAsLong()
		{
			long value = ushort.MaxValue + 1;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt32MaxAsLong()
		{
			long value = uint.MaxValue;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt64MinAsLong()
		{
			long value = (long)uint.MaxValue + 1;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.UInt64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void NegativeFixIntMinAsLong()
		{
			long value = -32;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.NegativeFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void NegativeFixIntMaxAsLong()
		{
			long value = -1;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.NegativeFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int8MinAsLong()
		{
			long value = sbyte.MinValue;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int8MaxAsLong()
		{
			long value = -33;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int16MinAsLong()
		{
			long value = short.MinValue;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int16MaxAsLong()
		{
			long value = sbyte.MinValue - 1;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int32MinAsLong()
		{
			long value = int.MinValue;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.Int32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int32MaxAsLong()
		{
			long value = short.MinValue - 1;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.Int32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int64MinAsLong()
		{
			long value = long.MinValue;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.Int64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Int64MaxAsLong()
		{
			long value = (long)int.MinValue - 1;
			byte[] data = MsgPack.Pack<long>(value);
			long result = MsgPack.Unpack<long>(data);
			Assert.AreEqual(Format.Int64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
