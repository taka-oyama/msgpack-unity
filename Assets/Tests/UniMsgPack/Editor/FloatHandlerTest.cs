using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class FloatHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackFloat32Zero()
		{
			float value = 0.0f;
			byte[] data = MsgPack.Pack<float>(value);
			float result = MsgPack.Unpack<float>(data);
			Assert.AreEqual(Format.Float32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackFloat32Min()
		{
			float value = float.MinValue;
			byte[] data = MsgPack.Pack<float>(value);
			float result = MsgPack.Unpack<float>(data);
			Assert.AreEqual(Format.Float32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackFloat32Max()
		{
			float value = float.MaxValue;
			byte[] data = MsgPack.Pack<float>(value);
			float result = MsgPack.Unpack<float>(data);
			Assert.AreEqual(Format.Float32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackFloat32Zero()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float32Zero"));
			Assert.AreEqual(0.0, value);
		}

		[Test]
		public void UnpackFloat32Min()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float32Min"));
			Assert.AreEqual(float.MinValue, value);
		}

		[Test]
		public void UnpackFloat32Max()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float32Max"));
			Assert.AreEqual(float.MaxValue, value);
		}

		[Test]
		public void UnpackFloat64ZeroAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Floats/Float64Zero"));
			Assert.AreEqual(0f, value);
		}

		[Test]
		public void UnpackFloat64MinAsFloat()
		{
			Assert.Throws<InvalidCastException>(() => {
				MsgPack.Unpack<float>(ReadFile("Floats/Float64Min"));
			});
		}

		[Test]
		public void UnpackFloat64MaxAsFloat()
		{
			Assert.Throws<InvalidCastException>(() => {
				MsgPack.Unpack<float>(ReadFile("Floats/Float64Max"));
			});
		}

		[Test]
		public void UnpackPositiveFixIntAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UnpackUInt32MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt32MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UnpackUInt64MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt64Min"));
			Assert.AreEqual((long)uint.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt64MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/UInt64Max"));
			Assert.AreEqual(ulong.MaxValue, value);
		}

		[Test]
		public void UnpackNegativeFixIntMinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/NegativeFixIntMax"));
			Assert.AreEqual(-1, value);
		}

		[Test]
		public void UnpackInt8MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
		}

		[Test]
		public void UnpackInt8MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int8Max"));
			Assert.AreEqual(-33, value);
		}

		[Test]
		public void UnpackInt16MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
		}

		[Test]
		public void UnpackInt16MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int16Max"));
			Assert.AreEqual(sbyte.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt32MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
		}

		[Test]
		public void UnpackInt32MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int32Max"));
			Assert.AreEqual(short.MinValue - 1, value);
		}

		[Test]
		public void UnpackInt64MinAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int64Min"));
			Assert.AreEqual(long.MinValue, value);
		}

		[Test]
		public void UnpackInt64MaxAsFloat()
		{
			float value = MsgPack.Unpack<float>(ReadFile("Ints/Int64Max"));
			Assert.AreEqual((long)int.MinValue - 1, value);
		}

		#endregion
	}
}
