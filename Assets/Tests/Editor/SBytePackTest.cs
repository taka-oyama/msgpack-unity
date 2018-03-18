using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class SBytePackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsSByte()
		{
			sbyte value = 0;
			byte[] data = MsgPack.Pack<sbyte>(value);
			sbyte result = MsgPack.Unpack<sbyte>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixIntMaxAsSByte()
		{
			sbyte value = sbyte.MaxValue;
			byte[] data = MsgPack.Pack<sbyte>(value);
			sbyte result = MsgPack.Unpack<sbyte>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void NegativeFixIntMinAsSByte()
		{
			sbyte value = -32;
			byte[] data = MsgPack.Pack<sbyte>(value);
			sbyte result = MsgPack.Unpack<sbyte>(data);
			Assert.AreEqual(Format.NegativeFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void NegativeFixIntMaxAsSByte()
		{
			sbyte value = -1;
			byte[] data = MsgPack.Pack<sbyte>(value);
			sbyte result = MsgPack.Unpack<sbyte>(data);
			Assert.AreEqual(Format.NegativeFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
