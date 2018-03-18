using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class MapPackTest : TestBase
	{
		struct StructMap
		{
			public int a;
			public int b;
			public int c;
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
			private int a = 0;
			public int A { get { return a; } }
		}

		class MixedMap
		{
			public ClassMap inner = null;
		}

		[Test]
		public void Struct()
		{
			StructMap map = MsgPack.Unpack<StructMap>(ReadFile("Maps/Struct"));
			Assert.AreEqual(map.a, 1);
			Assert.AreEqual(map.b, 2);
			Assert.AreEqual(map.c, 0);
			Assert.AreEqual(map.d, null);
		}

		[Test]
		public void Class()
		{
			ClassMap map = MsgPack.Unpack<ClassMap>(ReadFile("Maps/Struct"));
			Assert.AreEqual(map.a, 1);
			Assert.AreEqual(map.b, 2);
			Assert.AreEqual(map.c, 0);
			Assert.AreEqual(map.d, null);
		}

		[Test]
		public void ClassWithPrivateFields()
		{
			PrivateClassMap map = MsgPack.Unpack<PrivateClassMap>(ReadFile("Maps/Struct"));
			Assert.AreEqual(map.A, 1);
		}

		[Test]
		public void MapSkippable()
		{
			MixedMap map = MsgPack.Unpack<MixedMap>(ReadFile("Maps/MapSkippable"));
			Assert.AreEqual(map.inner.a, 1);
			Assert.AreEqual(map.inner.b, 2);
		}

		[Test]
		public void FixMapMin()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/FixMapMin"));
			Assert.AreEqual(0, dict.Count);
		}

		[Test]
		public void FixMapMax()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/FixMapMax"));
			Assert.AreEqual(15, dict.Count);
			for(int i = 0; i < 15; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void Map16Min()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/Map16Min"));
			Assert.AreEqual(16, dict.Count);
			for(int i = 0; i < 16; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void Map16Max()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/Map16Max"));
			Assert.AreEqual(ushort.MaxValue, dict.Count);
			for(int i = 0; i < ushort.MaxValue; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void Map32Min()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/Map32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, dict.Count);
			for(int i = 0; i < ushort.MaxValue + 1; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}
	}
}
