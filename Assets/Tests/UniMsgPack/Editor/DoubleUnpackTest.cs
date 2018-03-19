using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class DoubleUnpackTest : TestBase
	{
		[Test]
		public void Float64Zero()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Floats/Float64Zero"));
			Assert.AreEqual(0.0, value);
		}

		[Test]
		public void Float64Min()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Floats/Float64Min"));
			Assert.AreEqual(double.MinValue, value);
		}

		[Test]
		public void Float64Max()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Floats/Float64Max"));
			Assert.AreEqual(double.MaxValue, value);
		}

		[Test]
		public void Float32ZeroAsDouble()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float32Zero"));
			Assert.AreEqual(0f, value);
		}

		[Test]
		public void Float32MinAsDouble()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float32Min"));
			Assert.AreEqual(float.MinValue, value);
		}

		[Test]
		public void Float32MaxAsDouble()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float32Max"));
			Assert.AreEqual(float.MaxValue, value);
		}

		[Test]
		public void PositiveFixIntAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UInt8MinAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UInt8MaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UInt16MinAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UInt16MaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UInt32MinAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UInt32MaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UInt64MinAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/UInt64Min"));
			Assert.AreEqual((long)uint.MaxValue + 1, value);
		}

		[Test]
		public void UInt64MaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/UInt64Max"));
			Assert.AreEqual(ulong.MaxValue, value);
		}

		[Test]
		public void NegativeFixIntMinAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void NegativeFixIntMaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void Int8MinAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void Int8MaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void Int16MinAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void Int16MaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void Int32MinAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void Int32MaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/Int32Max"));
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void Int64MinAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/Int64Min"));
			Assert.AreEqual(long.MinValue, value);
		}

		[Test]
		public void Int64MaxAsDouble()
		{
			double value = MsgPack.Unpack<double>(ReadFile("Ints/Int64Max"));
			Assert.AreEqual((long)int.MinValue - 1, value);
		}
	}
}
