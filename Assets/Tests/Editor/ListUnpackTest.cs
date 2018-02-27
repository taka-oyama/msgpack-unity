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
		public void Nil()
		{
			List<int> nil = MsgPack.Unpack<List<int>>(ReadFile("Arrays/Nil"));
			Assert.AreEqual(0, nil.Count);
		}

		[Test]
		public void Nils()
		{
			List<int?> nils = MsgPack.Unpack<List<int?>>(ReadFile("Arrays/Nils"));
			Assert.AreEqual(2, nils.Count);
			for(int i = 0; i < nils.Count; i++) {
				Assert.AreEqual(nils[i], null);
			}
		}

		[Test]
		public void Arrays()
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
		public void Maps()
		{
			List<Map> maps = MsgPack.Unpack<List<Map>>(ReadFile("Arrays/Maps"));
			Assert.AreEqual(2, maps.Count);
			Assert.AreEqual(1, maps[0].a);
			Assert.AreEqual(0, maps[0].b);
			Assert.AreEqual(0, maps[1].a);
			Assert.AreEqual(2, maps[1].b);
		}

		[Test]
		public void FixArrayMin()
		{
			List<Map> test = MsgPack.Unpack<List<Map>>(ReadFile("Arrays/FixArrayMin"));
			Assert.AreEqual(0, test.Count);
		}

		[Test]
		public void FixArrayMax()
		{
			List<int> ints = MsgPack.Unpack<List<int>>(ReadFile("Arrays/FixArrayMax"));
			Assert.AreEqual(ints.Count, 15);
			for(int i = 0; i < ints.Count; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void Array16Min()
		{
			List<int> ints = MsgPack.Unpack<List<int>>(ReadFile("Arrays/Array16Min"));
			Assert.AreEqual(ints.Count, 16);
			for(int i = 0; i < ints.Count; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void Array16Max()
		{
			List<int> ints = MsgPack.Unpack<List<int>>(ReadFile("Arrays/Array16Max"));
			Assert.AreEqual(ints.Count, 65535);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void Array32Min()
		{
			List<int> ints = MsgPack.Unpack<List<int>>(ReadFile("Arrays/Array32Min"));
			Assert.AreEqual(ints.Count, 65536);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}
	}
}
