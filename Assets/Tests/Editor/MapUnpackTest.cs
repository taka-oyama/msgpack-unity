using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class MapUnpackTest : TestBase
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
		public void UnpackStruct()
		{
			byte[] bytes = ReadFile(basePath + "/Maps/Struct.mpack");
			StructMap map = MsgPack.Unpack<StructMap>(bytes);
			Assert.AreEqual(map.a, 1);
			Assert.AreEqual(map.b, 2);
			Assert.AreEqual(map.c, 0);
			Assert.AreEqual(map.d, null);
		}

		[Test]
		public void UnpackClass()
		{
			byte[] bytes = ReadFile(basePath + "/Maps/Struct.mpack");
			ClassMap map = MsgPack.Unpack<ClassMap>(bytes);
			Assert.AreEqual(map.a, 1);
			Assert.AreEqual(map.b, 2);
			Assert.AreEqual(map.c, 0);
			Assert.AreEqual(map.d, null);
		}

		[Test]
		public void UnpackClassWithPrivateFields()
		{
			byte[] bytes = ReadFile(basePath + "/Maps/Struct.mpack");
			PrivateClassMap map = MsgPack.Unpack<PrivateClassMap>(bytes);
			Assert.AreEqual(map.A, 1);
		}

		[Test]
		public void UnpackMapSkippable()
		{
			byte[] bytes = ReadFile(basePath + "/Maps/MapSkippable.mpack");
			MixedMap map = MsgPack.Unpack<MixedMap>(bytes);
			Assert.AreEqual(map.inner.a, 1);
			Assert.AreEqual(map.inner.b, 2);
		}

		[Test]
		public void UnpackFixMapMin()
		{
			byte[] bytes = ReadFile(basePath + "/Maps/FixMapMin.mpack");
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(bytes);
			Assert.AreEqual(0, dict.Count);
		}

		[Test]
		public void UnpackFixMapMax()
		{
			byte[] bytes = ReadFile(basePath + "/Maps/FixMapMax.mpack");
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(bytes);
			Assert.AreEqual(15, dict.Count);
			for(int i = 0; i < 15; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void UnpackMap16Min()
		{
			byte[] bytes = ReadFile(basePath + "/Maps/Map16Min.mpack");
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(bytes);
			Assert.AreEqual(16, dict.Count);
			for(int i = 0; i < 16; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void UnpackMap16Max()
		{
			byte[] bytes = ReadFile(basePath + "/Maps/Map16Max.mpack");
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(bytes);
			Assert.AreEqual(ushort.MaxValue, dict.Count);
			for(int i = 0; i < ushort.MaxValue; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void UnpackMap32Min()
		{
			byte[] bytes = ReadFile(basePath + "/Maps/Map32Min.mpack");
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(bytes);
			Assert.AreEqual(ushort.MaxValue + 1, dict.Count);
			for(int i = 0; i < ushort.MaxValue + 1; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}
	}
}
