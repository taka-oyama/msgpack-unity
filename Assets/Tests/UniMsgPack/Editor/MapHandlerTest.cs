using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class MapHandlerTest : TestBase
	{
		#region Declarations

		struct StructMap
		{
			public int a;
			public int? d;
		}

		struct StructMapExt
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

		#endregion


		#region Pack

		[Test]
		public void PackStruct()
		{
			StructMap map = new StructMap() { a = 0, d = null };
			byte[] data = MsgPack.Pack<StructMap>(map);
			StructMap result = MsgPack.Unpack<StructMap>(data);
			Assert.AreEqual(map.a, result.a);
			Assert.AreEqual(map.d, result.d);
		}

		[Test]
		public void PackClass()
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
		public void PackClassWithPrivateFields()
		{
			PrivateClassMap map = new PrivateClassMap();
			byte[] data = MsgPack.Pack<PrivateClassMap>(map);
			PrivateClassMap result = MsgPack.Unpack<PrivateClassMap>(data);
			Assert.AreEqual(map.A, result.A);
		}

		[Test]
		public void PackMixedMapping()
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
		public void PackFixMapMin()
		{
			Dictionary<int, int> dict = new Dictionary<int, int>();
			byte[] data = MsgPack.Pack<Dictionary<int, int>>(dict);
			Dictionary<int, int> result = MsgPack.Unpack<Dictionary<int, int>>(data);
			Assert.AreEqual(Format.FixMapMin, data[0]);
			Assert.AreEqual(0, result.Count);
		}

		[Test]
		public void PackFixMapMax()
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
		public void PackMap16Min()
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
		public void PackMap16Max()
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
		public void PackMap32Min()
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
		#endregion


		#region Unpack

		[Test]
		public void UnpackStruct()
		{
			StructMapExt map = MsgPack.Unpack<StructMapExt>(ReadFile("Maps/Struct"));
			Assert.AreEqual(map.a, 1);
			Assert.AreEqual(map.b, 2);
			Assert.AreEqual(map.c, 0);
			Assert.AreEqual(map.d, null);
		}

		[Test]
		public void UnpackClass()
		{
			ClassMap map = MsgPack.Unpack<ClassMap>(ReadFile("Maps/Struct"));
			Assert.AreEqual(map.a, 1);
			Assert.AreEqual(map.b, 2);
			Assert.AreEqual(map.c, 0);
			Assert.AreEqual(map.d, null);
		}

		[Test]
		public void UnpackClassWithPrivateFields()
		{
			PrivateClassMap map = MsgPack.Unpack<PrivateClassMap>(ReadFile("Maps/Struct"));
			Assert.AreEqual(map.A, 1);
		}

		[Test]
		public void UnpackMapSkippable()
		{
			MixedMap map = MsgPack.Unpack<MixedMap>(ReadFile("Maps/MapSkippable"));
			Assert.AreEqual(map.inner.a, 1);
			Assert.AreEqual(map.inner.b, 2);
		}

		[Test]
		public void UnpackFixMapMin()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/FixMapMin"));
			Assert.AreEqual(0, dict.Count);
		}

		[Test]
		public void UnpackFixMapMax()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/FixMapMax"));
			Assert.AreEqual(15, dict.Count);
			for(int i = 0; i < 15; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void UnpackMap16Min()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/Map16Min"));
			Assert.AreEqual(16, dict.Count);
			for(int i = 0; i < 16; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void UnpackMap16Max()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/Map16Max"));
			Assert.AreEqual(ushort.MaxValue, dict.Count);
			for(int i = 0; i < ushort.MaxValue; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		[Test]
		public void UnpackMap32Min()
		{
			Dictionary<int, int> dict = MsgPack.Unpack<Dictionary<int, int>>(ReadFile("Maps/Map32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, dict.Count);
			for(int i = 0; i < ushort.MaxValue + 1; i++) {
				Assert.AreEqual(1, dict[i]);
			}
		}

		#endregion
	}
}
