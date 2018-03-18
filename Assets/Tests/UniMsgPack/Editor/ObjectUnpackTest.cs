using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ObjectUnpackTest : TestBase
	{
		struct StructMap
		{
			public int a;
			public int b;
		}

		[Test]
		public void Nil()
		{
			Assert.AreEqual(null, MsgPack.Unpack<object>(ReadFile("Arrays/Nil")));
		}

		[Test]
		public void False()
		{
			Assert.AreEqual(false, MsgPack.Unpack<object>(ReadFile("Bools/False")));
		}

		[Test]
		public void True()
		{
			Assert.AreEqual(true, MsgPack.Unpack<object>(ReadFile("Bools/True")));
		}

		[Test]
		public void PositiveFixInt()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
			Assert.AreEqual(typeof(byte), value.GetType());
		}

		[Test]
		public void UInt8Max()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
			Assert.AreEqual(typeof(byte), value.GetType());
		}

		[Test]
		public void UInt16Max()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
			Assert.AreEqual(typeof(ushort), value.GetType());

		}

		[Test]
		public void UInt32Max()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
			Assert.AreEqual(typeof(uint), value.GetType());
		}

		[Test]
		public void UInt64Max()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/UInt64Max"));
			Assert.AreEqual(ulong.MaxValue, value);
			Assert.AreEqual(typeof(ulong), value.GetType());
		}

		[Test]
		public void NegativeFixIntMin()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/NegativeFixIntMin"));
			Assert.AreEqual(-32, value);
			Assert.AreEqual(typeof(sbyte), value.GetType());
		}

		[Test]
		public void Int8Min()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/Int8Min"));
			Assert.AreEqual(sbyte.MinValue, value);
			Assert.AreEqual(typeof(sbyte), value.GetType());
		}

		[Test]
		public void Int16Min()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/Int16Min"));
			Assert.AreEqual(short.MinValue, value);
			Assert.AreEqual(typeof(short), value.GetType());
		}

		[Test]
		public void Int32Min()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/Int32Min"));
			Assert.AreEqual(int.MinValue, value);
			Assert.AreEqual(typeof(int), value.GetType());
		}

		[Test]
		public void Int64MinAsLong()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Ints/Int64Min"));
			Assert.AreEqual(long.MinValue, value);
			Assert.AreEqual(typeof(long), value.GetType());
		}

		[Test]
		public void Float64Zero()
		{
			object value = MsgPack.Unpack<object>(ReadFile("Floats/Float64Zero"));
			Assert.AreEqual(0.0, value);
			Assert.AreEqual(typeof(double), value.GetType());
		}

		[Test]
		public void FixStrMin()
		{
			Assert.AreEqual("", MsgPack.Unpack<object>(ReadFile("Strings/FixStrMin")));
		}

		[Test]
		public void Str8Min()
		{
			Assert.AreEqual(new String('A', 32), MsgPack.Unpack<object>(ReadFile("Strings/Str8Min")));
		}

		[Test]
		public void Str16Min()
		{
			Assert.AreEqual(new String('A', byte.MaxValue + 1), MsgPack.Unpack<object>(ReadFile("Strings/Str16Min")));
		}

		[Test]
		public void Str32Min()
		{
			Assert.AreEqual(new String('A', ushort.MaxValue + 1), MsgPack.Unpack<object>(ReadFile("Strings/Str32Min")));
		}

		[Test]
		public void Nils()
		{
			object[] nils = MsgPack.Unpack<object[]>(ReadFile("Arrays/Nils"));
			Assert.AreEqual(2, nils.Length);
			for(int i = 0; i < nils.Length; i++) {
				Assert.AreEqual(nils[i], null);
			}
		}

		[Test]
		public void NilsAsObject()
		{
			object nils = MsgPack.Unpack<object>(ReadFile("Arrays/Nils"));
			List<object> nilsList = (List<object>)nils;
			Assert.AreEqual(2, nilsList.Count);
			for(int i = 0; i < nilsList.Count; i++) {
				Assert.AreEqual(nilsList[i], null);
			}
		}

		[Test]
		public void Struct()
		{
			object map = MsgPack.Unpack<object>(ReadFile("Maps/Struct"));
			Dictionary<object, object> objMap = (Dictionary<object, object>)map;
			Assert.AreEqual(objMap.Count, 2);
			Assert.AreEqual(objMap["a"], 1);
			Assert.AreEqual(objMap["b"], 2);
		}
	}
}
