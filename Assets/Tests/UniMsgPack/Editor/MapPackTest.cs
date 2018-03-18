using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class MapPackTest : TestBase
	{
		struct StructMap
		{
			public int a;
			public int? d;
		}

		class ClassMap
		{
			public int a = 0;
			public int b = 0;
			public int c = 0;
			public int? d = null;
		}

		class PrivateClassMap
		{
			private int a = 1;
			public int A { get { return a; } }
		}

		class MixedMap
		{
			public ClassMap inner = null;
		}

		[Test]
		public void Struct()
		{
			StructMap map = new StructMap() { a = 0, d = null };
			byte[] data = MsgPack.Pack<StructMap>(map);
			StructMap result = MsgPack.Unpack<StructMap>(data);
			Assert.AreEqual(map.a, result.a);
			Assert.AreEqual(map.d, result.d);
		}

		[Test]
		public void Class()
		{
			ClassMap map = new ClassMap() { a = 1, b = 2 };
			byte[] data = MsgPack.Pack<ClassMap>(map);
			ClassMap result = MsgPack.Unpack<ClassMap>(data);
			Assert.AreEqual(map.a, result.a);
			Assert.AreEqual(map.b, result.b);
			Assert.AreEqual(map.c, result.c);
			Assert.AreEqual(map.d, result.d);
		}

		[Test]
		public void ClassWithPrivateFields()
		{
			PrivateClassMap map = new PrivateClassMap();
			byte[] data = MsgPack.Pack<PrivateClassMap>(map);
			PrivateClassMap result = MsgPack.Unpack<PrivateClassMap>(data);
			Assert.AreEqual(map.A, result.A);
		}

		[Test]
		public void MixedMapping()
		{
			MixedMap map = new MixedMap() {
				inner = new ClassMap() { a = 1, b = 2 }
			};
			byte[] data = MsgPack.Pack<MixedMap>(map);
			MixedMap result = MsgPack.Unpack<MixedMap>(data);
			Assert.AreEqual(map.inner.a, result.inner.a);
			Assert.AreEqual(map.inner.b, result.inner.b);
		}

		[Test]
		public void FixMapMin()
		{
			Dictionary<int, int> dict = new Dictionary<int, int>();
			byte[] data = MsgPack.Pack<Dictionary<int, int>>(dict);
			Dictionary<int, int> result = MsgPack.Unpack<Dictionary<int, int>>(data);
			Assert.AreEqual(Format.FixMapMin, data[0]);
			Assert.AreEqual(0, result.Count);
		}

		[Test]
		public void FixMapMax()
		{
			int size = 15;
			Dictionary<int, int> dict = new Dictionary<int, int>();
			for(int i = 0; i < size; i++) {
				dict.Add(i, 1);
			}
			byte[] data = MsgPack.Pack<Dictionary<int, int>>(dict);
			Dictionary<int, int> result = MsgPack.Unpack<Dictionary<int, int>>(data);
			Assert.AreEqual(Format.FixMapMax, data[0]);
			Assert.AreEqual(size, result.Count);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void Map16Min()
		{
			int size = 16;
			Dictionary<int, int> dict = new Dictionary<int, int>();
			for(int i = 0; i < size; i++) {
				dict.Add(i, 1);
			}
			byte[] data = MsgPack.Pack<Dictionary<int, int>>(dict);
			Dictionary<int, int> result = MsgPack.Unpack<Dictionary<int, int>>(data);
			Assert.AreEqual(Format.Map16, data[0]);
			Assert.AreEqual(size, result.Count);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void Map16Max()
		{
			int size = ushort.MaxValue;
			Dictionary<int, int> dict = new Dictionary<int, int>();
			for(int i = 0; i < size; i++) {
				dict.Add(i, 1);
			}
			byte[] data = MsgPack.Pack<Dictionary<int, int>>(dict);
			Dictionary<int, int> result = MsgPack.Unpack<Dictionary<int, int>>(data);
			Assert.AreEqual(Format.Map16, data[0]);
			Assert.AreEqual(size, result.Count);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void Map32Min()
		{
			int size = ushort.MaxValue + 1;
			Dictionary<int, int> dict = new Dictionary<int, int>();
			for(int i = 0; i < size; i++) {
				dict.Add(i, 1);
			}
			byte[] data = MsgPack.Pack<Dictionary<int, int>>(dict);
			Dictionary<int, int> result = MsgPack.Unpack<Dictionary<int, int>>(data);
			Assert.AreEqual(Format.Map32, data[0]);
			Assert.AreEqual(size, result.Count);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}
	}
}
