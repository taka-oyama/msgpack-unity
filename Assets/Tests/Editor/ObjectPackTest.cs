using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ObjectPackTest : TestBase
	{
		struct StructMap
		{
			public int a;
			public int b;
		}

		[Test]
		public void Nil()
		{
			object value = null;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void False()
		{
			object value = false;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.False, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void True()
		{
			object value = true;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.True, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixInt()
		{
			object value = sbyte.MaxValue;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(byte), result.GetType());
		}

		[Test]
		public void UInt8Max()
		{
			object value = byte.MaxValue;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(byte), result.GetType());
		}

		[Test]
		public void UInt16Max()
		{
			object value = ushort.MaxValue;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(ushort), result.GetType());
		}

		[Test]
		public void UInt32Max()
		{
			object value = uint.MaxValue;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(uint), result.GetType());
		}

		[Test]
		public void UInt64Max()
		{
			object value = ulong.MaxValue;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.UInt64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(ulong), result.GetType());
		}

		[Test]
		public void NegativeFixIntMin()
		{
			object value = -32;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.NegativeFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(sbyte), result.GetType());
		}

		[Test]
		public void Int8Min()
		{
			object value = sbyte.MinValue;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Int8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(sbyte), result.GetType());
		}

		[Test]
		public void Int16Min()
		{
			object value = short.MinValue;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Int16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(short), result.GetType());
		}

		[Test]
		public void Int32Min()
		{
			object value = int.MinValue;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Int32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(int), result.GetType());
		}

		[Test]
		public void Int64MinAsLong()
		{
			object value = long.MinValue;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Int64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(long), value.GetType());
		}

		[Test]
		public void Float32Zero()
		{
			object value = 0.0f;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Float32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(float), value.GetType());
		}

		[Test]
		public void Float64Zero()
		{
			object value = 0.0;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Float64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(double), value.GetType());
		}

		[Test]
		public void FixStrMin()
		{
			object value = "";
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.FixStrMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(string), value.GetType());
		}

		[Test]
		public void Str8Min()
		{
			object value = new String('A', 32);
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Str8, data[0]);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(string), value.GetType());
		}

		[Test]
		public void Str16Min()
		{
			object value = new String('A', byte.MaxValue + 1);
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Str16, data[0]);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(string), value.GetType());
		}

		[Test]
		public void Str32Min()
		{
			object value = new String('A', ushort.MaxValue + 1);
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Str32, data[0]);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(string), value.GetType());
		}

		[Test]
		public void Nils()
		{
			object value = new object[] { null, null };
			byte[] data = MsgPack.Pack<object>(value);
			List<object> result = (List<object>)MsgPack.Unpack<object>(data);
			Assert.AreEqual(2, result.Count);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(result[i], null);
			}
		}

		[Test]
		public void NilsAsObject()
		{
			object value = new List<object> { null, null };
			byte[] data = MsgPack.Pack<object>(value);
			List<object> result = (List<object>)MsgPack.Unpack<object>(data);
			Assert.AreEqual(2, result.Count);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(result[i], null);
			}
		}

		[Test]
		public void Struct()
		{
			object value = new StructMap() { a = 1, b = 2 };
			byte[] data = MsgPack.Pack<object>(value);
			Dictionary<object, object> result = (Dictionary<object, object>)MsgPack.Unpack<object>(data);
			Assert.AreEqual(2, result.Count);
			Assert.AreEqual(result["a"], 1);
			Assert.AreEqual(result["b"], 2);
		}
	}
}
