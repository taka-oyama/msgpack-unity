using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace UniMsgPack.Tests
{
	public class ListPackTest : TestBase
	{
		struct Map
		{
			public int? a;
			public int b;
		}

		[Test]
		public void Nil()
		{
			List<int> nil = null;
			byte[] data = MsgPack.Pack<List<int>>(nil);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void Nils()
		{
			List<int?> nils = new List<int?>() { null };
			byte[] data = MsgPack.Pack<List<int?>>(nils);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.Nil, data[1]);
			Assert.AreEqual(2, data.Length);
		}

		[Test]
		public void Arrays()
		{
			List<List<int>> arrays = new List<List<int>>() { new List<int>() { 0 } };
			byte[] data = MsgPack.Pack<List<List<int>>>(arrays);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.FixArrayMin + 1, data[1]);
			Assert.AreEqual(0, data[2]);
			Assert.AreEqual(3, data.Length);
		}

		[Test]
		public void Maps()
		{
			List<Map> maps = new List<Map>() { new Map() };
			byte[] data = MsgPack.Pack<List<Map>>(maps);
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
		public void FixArrayMin()
		{
			List<int> ints = new List<int>();
			byte[] data = MsgPack.Pack<List<int>>(ints);
			Assert.AreEqual(Format.FixArrayMin, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void FixArrayMax()
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
		public void Array16Min()
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
		public void Array16Max()
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
		public void Array32Min()
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
	}
}
