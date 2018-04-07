using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class DecimalHandlerTest : TestBase
	{
		[Test]
		public void Pack()
		{
			var value = decimal.MinValue;
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<decimal>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Unpack()
		{
			var value = decimal.MaxValue;
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<decimal>(data);
			Assert.AreEqual(result, value);
		}

		[Test]
		public void Decimal()
		{
			var value = new decimal(12345.67890);
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<decimal>(data);
			Assert.AreEqual(result, value);
		}
	}
}
