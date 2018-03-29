using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace UniMsgPack.Tests
{
	public class ListHandlerTest : TestBase
	{
		#region Pack

		struct MapWithNullable
		{
			public int? a;
			public int b;
		}

		[Test]
		public void PackNil()
		{
			List<int> nil = null;
			byte[] data = MsgPack.Pack<List<int>>(nil);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void PackNils()
		{
			List<int?> nils = new List<int?>() { null };
			byte[] data = MsgPack.Pack<List<int?>>(nils);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.Nil, data[1]);
			Assert.AreEqual(2, data.Length);
		}

		[Test]
		public void PackArrays()
		{
			List<List<int>> arrays = new List<List<int>>() { new List<int>() { 0 } };
			byte[] data = MsgPack.Pack<List<List<int>>>(arrays);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.FixArrayMin + 1, data[1]);
			Assert.AreEqual(0, data[2]);
			Assert.AreEqual(3, data.Length);
		}

		[Test]
		public void PackMaps()
		{
			List<MapWithNullable> maps = new List<MapWithNullable>() { new MapWithNullable() };
			byte[] data = MsgPack.Pack<List<MapWithNullable>>(maps);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.FixMapMin + 2, data[1]);
			Assert.AreEqual(Format.FixStrMin + 1, data[2]);
			Assert.AreEqual("a", Encoding.UTF8.GetString(new byte[] { data[3] }));
			Assert.AreEqual(Format.Nil, data[4]);
			Assert.AreEqual(Format.FixStrMin + 1, data[5]);
			Assert.AreEqual("b", Encoding.UTF8.GetString(new byte[] { data[6] }));
			Assert.AreEqual(Format.PositiveFixIntMin, data[7]);
			Assert.AreEqual(8, data.Length);
		}

		[Test]
		public void PackFixArrayMin()
		{
			List<int> ints = new List<int>();
			byte[] data = MsgPack.Pack<List<int>>(ints);
			Assert.AreEqual(Format.FixArrayMin, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void PackFixArrayMax()
		{
			List<int> ints = new List<int>(15);
			for(int i = 0; i < ints.Capacity; i++) {
				ints.Add(i);
			}
			byte[] data = MsgPack.Pack<List<int>>(ints);
			List<int> result = MsgPack.Unpack<List<int>>(data);
			Assert.AreEqual(Format.FixArrayMax, data[0]);
			Assert.AreEqual(16, data.Length);

			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(i, result[i]);
			}
		}

		[Test]
		public void PackArray16Min()
		{
			List<int> ints = new List<int>(16);
			for(int i = 0; i < ints.Capacity; i++) {
				ints.Add(i);
			}
			byte[] data = MsgPack.Pack<List<int>>(ints);
			List<int> result = MsgPack.Unpack<List<int>>(data);
			Assert.AreEqual(Format.Array16, data[0]);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(i, result[i]);
			}
		}

		[Test]
		public void PackArray16Max()
		{
			List<int> ints = new List<int>(ushort.MaxValue);
			for(int i = 0; i < ints.Capacity; i++) {
				ints.Add(i);
			}
			byte[] data = MsgPack.Pack<List<int>>(ints);
			List<int> result = MsgPack.Unpack<List<int>>(data);
			Assert.AreEqual(Format.Array16, data[0]);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(i, result[i]);
			}
		}

		[Test]
		public void PackArray32Min()
		{
			List<int> ints = new List<int>(ushort.MaxValue + 1);
			for(int i = 0; i < ints.Capacity; i++) {
				ints.Add(i);
			}
			byte[] data = MsgPack.Pack<List<int>>(ints);
			List<int> result = MsgPack.Unpack<List<int>>(data);
			Assert.AreEqual(Format.Array32, data[0]);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(i, result[i]);
			}
		}

		#endregion


		#region Unpack

		struct Map
		{
			public int a;
			public int b;
		}

		[Test]
		public void UnpackNil()
		{
			List<int> nil = MsgPack.Unpack<List<int>>(ReadFile("Arrays/Nil"));
			Assert.AreEqual(0, nil.Count);
		}

		[Test]
		public void UnpackNils()
		{
			List<int?> nils = MsgPack.Unpack<List<int?>>(ReadFile("Arrays/Nils"));
			Assert.AreEqual(2, nils.Count);
			for(int i = 0; i < nils.Count; i++) {
				Assert.AreEqual(nils[i], null);
			}
		}

		[Test]
		public void UnpackArrays()
		{
			List<List<int?>> arrays = MsgPack.Unpack<List<List<int?>>>(ReadFile("Arrays/Arrays"));
			Assert.AreEqual(2, arrays.Count);
			Assert.AreEqual(2, arrays[0].Count);
			Assert.AreEqual(1, arrays[0][0]);
			Assert.AreEqual(2, arrays[0][1]);
			Assert.AreEqual(2, arrays[1].Count);
			Assert.AreEqual(3, arrays[1][0]);
			Assert.AreEqual(4, arrays[1][1]);
		}

		[Test]
		public void UnpackMaps()
		{
			List<Map> maps = MsgPack.Unpack<List<Map>>(ReadFile("Arrays/Maps"));
			Assert.AreEqual(2, maps.Count);
			Assert.AreEqual(1, maps[0].a);
			Assert.AreEqual(0, maps[0].b);
			Assert.AreEqual(0, maps[1].a);
			Assert.AreEqual(2, maps[1].b);
		}

		[Test]
		public void UnpackFixArrayMin()
		{
			List<Map> test = MsgPack.Unpack<List<Map>>(ReadFile("Arrays/FixArrayMin"));
			Assert.AreEqual(0, test.Count);
		}

		[Test]
		public void UnpackFixArrayMax()
		{
			List<int> ints = MsgPack.Unpack<List<int>>(ReadFile("Arrays/FixArrayMax"));
			Assert.AreEqual(ints.Count, 15);
			for(int i = 0; i < ints.Count; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Min()
		{
			List<int> ints = MsgPack.Unpack<List<int>>(ReadFile("Arrays/Array16Min"));
			Assert.AreEqual(ints.Count, 16);
			for(int i = 0; i < ints.Count; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Max()
		{
			List<int> ints = MsgPack.Unpack<List<int>>(ReadFile("Arrays/Array16Max"));
			Assert.AreEqual(ints.Count, 65535);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray32Min()
		{
			List<int> ints = MsgPack.Unpack<List<int>>(ReadFile("Arrays/Array32Min"));
			Assert.AreEqual(ints.Count, 65536);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		#endregion
	}
}
