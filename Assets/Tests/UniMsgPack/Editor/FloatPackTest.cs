using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class FloatPackTest : TestBase
	{
		[Test]
		public void Float32Zero()
		{
			float value = 0.0f;
			byte[] data = MsgPack.Pack<float>(value);
			float result = MsgPack.Unpack<float>(data);
			Assert.AreEqual(Format.Float32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Float32Min()
		{
			float value = float.MinValue;
			byte[] data = MsgPack.Pack<float>(value);
			float result = MsgPack.Unpack<float>(data);
			Assert.AreEqual(Format.Float32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Float32Max()
		{
			float value = float.MaxValue;
			byte[] data = MsgPack.Pack<float>(value);
			float result = MsgPack.Unpack<float>(data);
			Assert.AreEqual(Format.Float32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
