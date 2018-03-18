using UnityEngine;
using NUnit.Framework;

namespace UniMsgPack.Tests
{
	public class ArrayUnpackTest : TestBase
	{
		struct Map
		{
			public int a;
			public int b;
		}

		[Test]
		public void Nil()
		{
			int?[] nil = MsgPack.Unpack<int?[]>(ReadFile("Arrays/Nil"));
			Assert.AreEqual(0, nil.Length);
		}

		[Test]
		public void Nils()
		{
			int?[] nils = MsgPack.Unpack<int?[]>(ReadFile("Arrays/Nils"));
			Assert.AreEqual(2, nils.Length);
			for(int i = 0; i < nils.Length; i++) {
				Assert.AreEqual(nils[i], null);
			}
		}

		[Test]
		public void Arrays()
		{
			int[][] arrays = MsgPack.Unpack<int[][]>(ReadFile("Arrays/Arrays"));
			Assert.AreEqual(2, arrays.Length);
			Assert.AreEqual(2, arrays[0].Length);
			Assert.AreEqual(1, arrays[0][0]);
			Assert.AreEqual(2, arrays[0][1]);
			Assert.AreEqual(2, arrays[1].Length);
			Assert.AreEqual(3, arrays[1][0]);
			Assert.AreEqual(4, arrays[1][1]);
		}

		[Test]
		public void Maps()
		{
			Map[] maps = MsgPack.Unpack<Map[]>(ReadFile("Arrays/Maps"));
			Assert.AreEqual(2, maps.Length);
			Assert.AreEqual(1, maps[0].a);
			Assert.AreEqual(0, maps[0].b);
			Assert.AreEqual(0, maps[1].a);
			Assert.AreEqual(2, maps[1].b);
		}

		[Test]
		public void FixArrayMin()
		{
			int[] test = MsgPack.Unpack<int[]>(ReadFile("Arrays/FixArrayMin"));
			Assert.AreEqual(0, test.Length);
		}

		[Test]
		public void FixArrayMax()
		{
			int[] ints = MsgPack.Unpack<int[]>(ReadFile("Arrays/FixArrayMax"));
			Assert.AreEqual(ints.Length, 15);
			for(int i = 0; i < ints.Length; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void Array16Min()
		{
			int[] ints = MsgPack.Unpack<int[]>(ReadFile("Arrays/Array16Min"));
			Assert.AreEqual(ints.Length, 16);
			for(int i = 0; i < ints.Length; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void Array16Max()
		{
			int[] ints = MsgPack.Unpack<int[]>(ReadFile("Arrays/Array16Max"));
			Assert.AreEqual(ints.Length, 65535);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void Array32Min()
		{
			int[] ints = MsgPack.Unpack<int[]>(ReadFile("Arrays/Array32Min"));
			Assert.AreEqual(ints.Length, 65536);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}
	}
}
