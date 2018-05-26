using System;
using NUnit.Framework;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class DoubleHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackFloat64Zero()
		{
			double value = 0.0;
			byte[] data = Pack<double>(value);
			double result = Unpack<double>(data);
			Assert.AreEqual(Format.Float64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackFloat64Min()
		{
			double value = double.MinValue;
			byte[] data = Pack<double>(value);
			double result = Unpack<double>(data);
			Assert.AreEqual(Format.Float64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackFloat64Max()
		{
			double value = double.MaxValue;
			byte[] data = Pack<double>(value);
			double result = Unpack<double>(data);
			Assert.AreEqual(Format.Float64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackFloat64Zero()
		{
			double value = Unpack<double>(ReadFile("Floats/Float64Zero"));
			Assert.AreEqual(0.0, value);
		}

		[Test]
		public void UnpackFloat64Min()
		{
			double value = Unpack<double>(ReadFile("Floats/Float64Min"));
			Assert.AreEqual(double.MinValue, value);
		}

		[Test]
		public void UnpackFloat64Max()
		{
			double value = Unpack<double>(ReadFile("Floats/Float64Max"));
			Assert.AreEqual(double.MaxValue, value);
		}

		[Test]
		public void UnpackFloat32ZeroAsDouble()
		{
			float value = Unpack<float>(ReadFile("Floats/Float32Zero"));
			Assert.AreEqual(0f, value);
		}

		[Test]
		public void UnpackFloat32MinAsDouble()
		{
			float value = Unpack<float>(ReadFile("Floats/Float32Min"));
			Assert.AreEqual(float.MinValue, value);
		}

		[Test]
		public void UnpackFloat32MaxAsDouble()
		{
			float value = Unpack<float>(ReadFile("Floats/Float32Max"));
			Assert.AreEqual(float.MaxValue, value);
		}

		[Test]
		public void UnpackPositiveFixIntAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8MaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16MinAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16MaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UnpackUInt32MinAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt32MaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UnpackUInt64MinAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/UInt64Min"));
			Assert.AreEqual((long)uint.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt64MaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/UInt64Max"));
			Assert.AreEqual(ulong.MaxValue, value);
		}

		[Test]
		public void UnpackNegativeFixIntMinAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void UnpackInt8MinAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void UnpackInt8MaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void UnpackInt16MinAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void UnpackInt16MaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt32MinAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void UnpackInt32MaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/Int32Max"));
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt64MinAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/Int64Min"));
			Assert.AreEqual(long.MinValue, value);
		}

		[Test]
		public void UnpackInt64MaxAsDouble()
		{
			double value = Unpack<double>(ReadFile("Ints/Int64Max"));
			Assert.AreEqual((long)int.MinValue - 1, value);
		}

		#endregion
	}
}
