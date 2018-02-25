using UnityEngine;
using NUnit.Framework;

namespace UniMsgPack.Tests
{
	public class ArrayTest : TestBase
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
			int?[] nil = MsgPack.Unpack<int?[]>(bytes);
			Assert.AreEqual(0, nil.Length);
		}

		[Test]
		public void UnpackNils()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Nils.mpack");
			int?[] nils = MsgPack.Unpack<int?[]>(bytes);
			Assert.AreEqual(2, nils.Length);
			for(int i = 0; i < nils.Length; i++) {
				Assert.AreEqual(nils[i], null);
			}
		}

		[Test]
		public void UnpackArrays()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Arrays.mpack");
			int[][] arrays = MsgPack.Unpack<int[][]>(bytes);
			Assert.AreEqual(2, arrays.Length);
			Assert.AreEqual(2, arrays[0].Length);
			Assert.AreEqual(1, arrays[0][0]);
			Assert.AreEqual(2, arrays[0][1]);
			Assert.AreEqual(2, arrays[1].Length);
			Assert.AreEqual(3, arrays[1][0]);
			Assert.AreEqual(4, arrays[1][1]);
		}

		[Test]
		public void UnpackMaps()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Maps.mpack");
			Map[] maps = MsgPack.Unpack<Map[]>(bytes);
			Assert.AreEqual(2, maps.Length);
			Assert.AreEqual(1, maps[0].a);
			Assert.AreEqual(0, maps[0].b);
			Assert.AreEqual(0, maps[1].a);
			Assert.AreEqual(2, maps[1].b);
		}

		[Test]
		public void UnpackFixArrayMin()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/FixArrayMin.mpack");
			int[] test = MsgPack.Unpack<int[]>(bytes);
			Assert.AreEqual(0, test.Length);
		}

		[Test]
		public void UnpackFixArrayMax()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/FixArrayMax.mpack");
			int[] ints = MsgPack.Unpack<int[]>(bytes);
			Assert.AreEqual(ints.Length, 15);
			for(int i = 0; i < ints.Length; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Min()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Array16Min.mpack");
			int[] ints = MsgPack.Unpack<int[]>(bytes);
			Assert.AreEqual(ints.Length, 16);
			for(int i = 0; i < ints.Length; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Max()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Array16Max.mpack");
			int[] ints = MsgPack.Unpack<int[]>(bytes);
			Assert.AreEqual(ints.Length, 65535);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray32Min()
		{
			byte[] bytes = ReadFile(basePath + "/Arrays/Array32Min.mpack");
			int[] ints = MsgPack.Unpack<int[]>(bytes);
			Assert.AreEqual(ints.Length, 65536);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}
	}
}
