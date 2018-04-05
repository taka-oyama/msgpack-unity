using System;
using System.Collections.Generic;
using System.IO;
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

		class MapForNameConverter
		{
			public int a = 1;
			public int aa = 2;
		}

		class AllCapsNameConverter : IMapNameConverter
		{
			public string OnPack(string name)
			{
				return name + name;
			}

			public string OnUnpack(string name)
			{
				return name + name;
			}
		}

		class PropertyMap
		{
			public int A { get; set; }
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

		[Test]
		public void PackPropertyMap()
		{
			var value = new PropertyMap { A = 1 };
			MemoryStream stream = new MemoryStream(MsgPack.Pack(value));
			Assert.AreEqual(Format.FixMapMin + 1, stream.ReadByte());
			Assert.AreEqual(Format.FixStrMin + 18, stream.ReadByte());
			byte[] buffer = new byte[18];
			stream.Read(buffer, 0, buffer.Length);
			Assert.AreEqual("<A>k__BackingField", Encoding.UTF8.GetString(buffer));
			Assert.AreEqual(Format.PositiveFixIntMin + 1, stream.ReadByte());
			Assert.AreEqual(21, stream.Length);
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

		[Test]
		public void UnpackPropertyMap()
		{
			var value = new PropertyMap { A = 1 };
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<PropertyMap>(data);
			Assert.AreEqual(result.A, value.A);
		}

		#endregion


		#region MapOptions

		[Test]
		public void IgnoreNulls()
		{
			var context = new SerializationContext();
			context.mapOptions.ignoreNullOnPack = true;
			var value = new[] { new StructMap() };
			byte[] data = MsgPack.Pack(value, context);
			var result = MsgPack.Unpack<StructMap[]>(data);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.FixMapMin + 1, data[1]);
			Assert.AreEqual(Format.FixStrMin + 1, data[2]);
			Assert.AreEqual("a", Encoding.UTF8.GetString(new byte[] { data[3] }));
			Assert.AreEqual(Format.PositiveFixIntMin, data[4]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void DoNotIgnoreNulls()
		{
			var context = new SerializationContext();
			context.mapOptions.ignoreNullOnPack = false;
			var value = new[] { new StructMap() };
			byte[] data = MsgPack.Pack(value, context);
			var result = MsgPack.Unpack<StructMap[]>(data);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.FixMapMin + 2, data[1]);
			Assert.AreEqual(Format.FixStrMin + 1, data[2]);
			Assert.AreEqual("a", Encoding.UTF8.GetString(new byte[] { data[3] }));
			Assert.AreEqual(Format.PositiveFixIntMin, data[4]);
			Assert.AreEqual(Format.FixStrMin + 1, data[5]);
			Assert.AreEqual("d", Encoding.UTF8.GetString(new byte[] { data[6] }));
			Assert.AreEqual(Format.Nil, data[7]);
			Assert.AreEqual(8, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void NameConvertionOnPack()
		{
			var context = new SerializationContext();
			context.mapOptions.nameConverter = new AllCapsNameConverter();
			var value = new MapForNameConverter() { a = 3, aa = 4 };
			byte[] data = MsgPack.Pack(value, context);
			var result = MsgPack.Unpack<MapForNameConverter>(data);
			Assert.AreEqual(Format.FixMapMin + 2, data[0]);
			Assert.AreEqual(Format.FixStrMin + 2, data[1]);
			Assert.AreEqual("aa", Encoding.UTF8.GetString(new byte[] { data[2], data[3] }));
			Assert.AreEqual(Format.PositiveFixIntMin + 3, data[4]);
			Assert.AreEqual(Format.FixStrMin + 4, data[5]);
			Assert.AreEqual("aaaa", Encoding.UTF8.GetString(new byte[] { data[6], data[7], data[8], data[9] }));
			Assert.AreEqual(Format.PositiveFixIntMin + 4, data[10]);
			Assert.AreEqual(11, data.Length);
			Assert.AreEqual(1, result.a);
			Assert.AreEqual(3, result.aa);
		}

		[Test]
		public void NameConvertionOnUnpack()
		{
			var context = new SerializationContext();
			context.mapOptions.nameConverter = new AllCapsNameConverter();
			var value = new MapForNameConverter() { a = 3, aa = 4 };
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<MapForNameConverter>(data, context);
			Assert.AreEqual(Format.FixMapMin + 2, data[0]);
			Assert.AreEqual(Format.FixStrMin + 1, data[1]);
			Assert.AreEqual("a", Encoding.UTF8.GetString(new byte[] { data[2] }));
			Assert.AreEqual(Format.PositiveFixIntMin + 3, data[3]);
			Assert.AreEqual(Format.FixStrMin + 2, data[4]);
			Assert.AreEqual("aa", Encoding.UTF8.GetString(new byte[] { data[5], data[6] }));
			Assert.AreEqual(Format.PositiveFixIntMin + 4, data[7]);
			Assert.AreEqual(8, data.Length);
			Assert.AreEqual(1, result.a);
			Assert.AreEqual(3, result.aa);
		}

		#endregion
	}
}
