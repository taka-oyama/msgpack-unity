using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class FloatUnpackTest : TestBase
	{
		[Test]
		public void Float64Zero()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Floats/Float64Zero"));
			Assert.AreEqual(0.0, value);
		}

		[Test]
		public void Float64ZeroAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float64Zero"));
			Assert.AreEqual(0f, value);
		}

		[Test]
		public void Float64Min()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Floats/Float64Min"));
			Assert.AreEqual(double.MinValue, value);
		}

		[Test]
		public void Float64MinAsFloat()
		{
			Assert.Throws<InvalidCastException>(() => {
				MsgPack.Unpack<float>(ReadFile("Floats/Float64Min"));
			});
		}

		[Test]
		public void Float64Max()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Floats/Float64Max"));
			Assert.AreEqual(double.MaxValue, value);
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
