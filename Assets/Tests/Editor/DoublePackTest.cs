using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class DoublePackTest : TestBase
	{
		[Test]
		public void Float64Zero()
		{
			double value = 0.0;
			byte[] data = MsgPack.Pack<double>(value);
			double result = MsgPack.Unpack<double>(data);
			Assert.AreEqual(Format.Float64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Float64Min()
		{
			double value = double.MinValue;
			byte[] data = MsgPack.Pack<double>(value);
			double result = MsgPack.Unpack<double>(data);
			Assert.AreEqual(Format.Float64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Float64Max()
		{
			double value = double.MaxValue;
			byte[] data = MsgPack.Pack<double>(value);
			double result = MsgPack.Unpack<double>(data);
			Assert.AreEqual(Format.Float64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
