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

		[Test]
		public void PositiveFixIntAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UInt8MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UInt8MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UInt16MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UInt16MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UInt32MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UInt32MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UInt64MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt64Min"));
			Assert.AreEqual((long)uint.MaxValue + 1, value);
		}

		[Test]
		public void UInt64MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt64Max"));
			Assert.AreEqual(ulong.MaxValue, value);
		}

		[Test]
		public void NegativeFixIntMinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void NegativeFixIntMaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void Int8MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void Int8MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void Int16MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void Int16MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void Int32MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void Int32MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int32Max"));
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void Int64MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int64Min"));
			Assert.AreEqual(long.MinValue, value);
		}

		[Test]
		public void Int64MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int64Max"));
			Assert.AreEqual((long)int.MinValue - 1, value);
		}
	}
}
