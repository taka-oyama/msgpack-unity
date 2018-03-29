using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ObjectHandlerTest : TestBase
	{
		struct StructMap
		{
			public int a;
			public int b;
		}

		#region Pack

		[Test]
		public void PackNil()
		{
			object value = null;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackFalse()
		{
			object value = false;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.False, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackTrue()
		{
			object value = true;
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.True, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixInt()
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
		public void PackUInt8Max()
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
		public void PackUInt16Max()
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
		public void PackUInt32Max()
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
		public void PackUInt64Max()
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
		public void PackNegativeFixIntMin()
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
		public void PackInt8Min()
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
		public void PackInt16Min()
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
		public void PackInt32Min()
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
		public void PackInt64MinAsLong()
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
		public void PackFloat32Zero()
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
		public void PackFloat64Zero()
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
		public void PackFixStrMin()
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
		public void PackStr8Min()
		{
			object value = new String('A', 32);
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Str8, data[0]);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(string), value.GetType());
		}

		[Test]
		public void PackStr16Min()
		{
			object value = new String('A', byte.MaxValue + 1);
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Str16, data[0]);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(string), value.GetType());
		}

		[Test]
		public void PackStr32Min()
		{
			object value = new String('A', ushort.MaxValue + 1);
			byte[] data = MsgPack.Pack<object>(value);
			object result = MsgPack.Unpack<object>(data);
			Assert.AreEqual(Format.Str32, data[0]);
			Assert.AreEqual(value, result);
			Assert.AreEqual(typeof(string), value.GetType());
		}

		[Test]
		public void PackNils()
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
		public void PackNilsAsObject()
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
		public void PackStruct()
		{
			object value = new StructMap() { a = 1, b = 2 };
			byte[] data = MsgPack.Pack<object>(value);
			Dictionary<object, object> result = (Dictionary<object, object>)MsgPack.Unpack<object>(data);
			Assert.AreEqual(2, result.Count);
			Assert.AreEqual(result["a"], 1);
			Assert.AreEqual(result["b"], 2);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackNil()
		{
			Assert.AreEqual(null, MsgPack.Unpack<object>(ReadFile("Arrays/Nil")));
		}

		[Test]
		public void UnpackFalse()
		{
			Assert.AreEqual(false, MsgPack.Unpack<object>(ReadFile("Bools/False")));
		}

		[Test]
		public void UnpackTrue()
		{
			Assert.AreEqual(true, MsgPack.Unpack<object>(ReadFile("Bools/True")));
		}

		[Test]
		public void UnpackPositiveFixInt()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
			Assert.AreEqual(typeof(byte), value.GetType());
		}

		[Test]
		public void UnpackUInt8Max()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
			Assert.AreEqual(typeof(byte), value.GetType());
		}

		[Test]
		public void UnpackUInt16Max()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
			Assert.AreEqual(typeof(ushort), value.GetType());

		}

		[Test]
		public void UnpackUInt32Max()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
			Assert.AreEqual(typeof(uint), value.GetType());
		}

		[Test]
		public void UnpackUInt64Max()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/UInt64Max"));
			Assert.AreEqual(ulong.MaxValue, value);
			Assert.AreEqual(typeof(ulong), value.GetType());
		}

		[Test]
		public void UnpackNegativeFixIntMin()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
			Assert.AreEqual(typeof(sbyte), value.GetType());
		}

		[Test]
		public void UnpackInt8Min()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
			Assert.AreEqual(typeof(sbyte), value.GetType());
		}

		[Test]
		public void UnpackInt16Min()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
			Assert.AreEqual(typeof(short), value.GetType());
		}

		[Test]
		public void UnpackInt32Min()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
			Assert.AreEqual(typeof(int), value.GetType());
		}

		[Test]
		public void UnpackInt64MinAsLong()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/Int64Min"));
			Assert.AreEqual(long.MinValue, value);
			Assert.AreEqual(typeof(long), value.GetType());
		}

		[Test]
		public void UnpackFloat64Zero()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Floats/Float64Zero"));
			Assert.AreEqual(0.0, value);
			Assert.AreEqual(typeof(double), value.GetType());
		}

		[Test]
		public void UnpackFixStrMin()
		{
			Assert.AreEqual("", MsgPack.Unpack<object>(ReadFile("Strings/FixStrMin")));
		}

		[Test]
		public void UnpackStr8Min()
		{
			Assert.AreEqual(new String('A', 32), MsgPack.Unpack<object>(ReadFile("Strings/Str8Min")));
		}

		[Test]
		public void UnpackStr16Min()
		{
			Assert.AreEqual(new String('A', byte.MaxValue + 1), MsgPack.Unpack<object>(ReadFile("Strings/Str16Min")));
		}

		[Test]
		public void UnpackStr32Min()
		{
			Assert.AreEqual(new String('A', ushort.MaxValue + 1), MsgPack.Unpack<object>(ReadFile("Strings/Str32Min")));
		}

		[Test]
		public void UnpackNils()
		{
			object[] nils = MsgPack.Unpack<object[]>(ReadFile("Arrays/Nils"));
			Assert.AreEqual(2, nils.Length);
			for(int i = 0; i < nils.Length; i++) {
				Assert.AreEqual(nils[i], null);
			}
		}

		[Test]
		public void UnpackNilsAsObject()
		{
			object nils = MsgPack.Unpack<object>(ReadFile("Arrays/Nils"));
			List<object> nilsList = (List<object>)nils;
			Assert.AreEqual(2, nilsList.Count);
			for(int i = 0; i < nilsList.Count; i++) {
				Assert.AreEqual(nilsList[i], null);
			}
		}

		[Test]
		public void UnpackStruct()
		{
			object map = MsgPack.Unpack<object>(ReadFile("Maps/Struct"));
			Dictionary<object, object> objMap = (Dictionary<object, object>)map;
			Assert.AreEqual(objMap.Count, 2);
			Assert.AreEqual(objMap["a"], 1);
			Assert.AreEqual(objMap["b"], 2);
		}

		#endregion
	}
}
