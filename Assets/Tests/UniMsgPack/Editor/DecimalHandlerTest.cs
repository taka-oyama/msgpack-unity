using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class DecimalHandlerTest : TestBase
	{
		[Test]
		public void Pack()
		{
			var value = decimal.MinValue;
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<decimal>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Unpack()
		{
			var value = decimal.MaxValue;
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<decimal>(data);
			Assert.AreEqual(result, value);
		}

		[Test]
		public void Decimal()
		{
			var value = new decimal(12345.67890);
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<decimal>(data);
			Assert.AreEqual(result, value);
		}
	}
}
