using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;

namespace UniMsgPack.Tests
{
	public class ListUnpackTest : TestBase
	{
		struct Map
		{
			public int a;
			public int b;
		}

		[Test]
		public void UnpackNil()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Nil.mpack");
			List<int> nil = MsgPack.Unpack<List<int>>(bytes);
			Assert.AreEqual(0, nil.Count);
		}

		[Test]
		public void UnpackNils()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Nils.mpack");
			List<int?> nils = MsgPack.Unpack<List<int?>>(bytes);
			Assert.AreEqual(2, nils.Count);
			for(int i = 0; i < nils.Count; i++) {
				Assert.AreEqual(nils[i], null);
			}
		}

		[Test]
		public void UnpackArrays()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Arrays.mpack");
			List<List<int?>> arrays = MsgPack.Unpack<List<List<int?>>>(bytes);
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
			byte[] bytes = ReadFile(basePath + "/Arrays/Maps.mpack");
			List<Map> maps = MsgPack.Unpack<List<Map>>(bytes);
			Assert.AreEqual(2, maps.Count);
			Assert.AreEqual(1, maps[0].a);
			Assert.AreEqual(0, maps[0].b);
			Assert.AreEqual(0, maps[1].a);
			Assert.AreEqual(2, maps[1].b);
		}

		[Test]
		public void UnpackFixArrayMin()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/FixArrayMin.mpack");
			List<Map> test = MsgPack.Unpack<List<Map>>(bytes);
			Assert.AreEqual(0, test.Count);
		}

		[Test]
		public void UnpackFixArrayMax()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/FixArrayMax.mpack");
			List<int> ints = MsgPack.Unpack<List<int>>(bytes);
			Assert.AreEqual(ints.Count, 15);
			for(int i = 0; i < ints.Count; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Min()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Array16Min.mpack");
			List<int> ints = MsgPack.Unpack<List<int>>(bytes);
			Assert.AreEqual(ints.Count, 16);
			for(int i = 0; i < ints.Count; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Max()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Array16Max.mpack");
			List<int> ints = MsgPack.Unpack<List<int>>(bytes);
			Assert.AreEqual(ints.Count, 65535);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray32Min()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Array32Min.mpack");
			List<int> ints = MsgPack.Unpack<List<int>>(bytes);
			Assert.AreEqual(ints.Count, 65536);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}
	}
}
