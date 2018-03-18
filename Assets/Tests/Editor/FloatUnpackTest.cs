using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class FloatUnpackTest : TestBase
	{
		[Test]
		public void Float32Zero()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float32Zero"));
			Assert.AreEqual(0.0, value);
		}

		[Test]
		public void Float32Min()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float32Min"));
			Assert.AreEqual(float.MinValue, value);
		}

		[Test]
		public void Float32Max()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float32Max"));
			Assert.AreEqual(float.MaxValue, value);
		}

		[Test]
		public void Float64ZeroAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float64Zero"));
			Assert.AreEqual(0f, value);
		}

		[Test]
		public void Float64MinAsFloat()
		{
			Assert.Throws<InvalidCastException>(() => {
				MsgPack.Unpack<float>(ReadFile("Floats/Float64Min"));
			});
		}

		[Test]
		public void Float64MaxAsFloat()
		{
			Assert.Throws<InvalidCastException>(() => {
				MsgPack.Unpack<float>(ReadFile("Floats/Float64Max"));
			});
		}
	}
}
