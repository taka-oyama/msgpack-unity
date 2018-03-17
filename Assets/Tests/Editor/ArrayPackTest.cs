using UnityEngine;
using NUnit.Framework;
using System.Text;

namespace UniMsgPack.Tests
{
	public class ArrayPackTest : TestBase
	{
		struct Map
		{
			public int? a;
			public int b;
		}

		[Test]
		public void Nil()
		{
			int[] value = null;
			byte[] data = MsgPack.Pack(value);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(Format.Nil, data[0]);
		}

		[Test]
		public void Nils()
		{
			string[] value = { null, null };
			byte[] data = MsgPack.Pack(value);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(Format.FixArrayMin + 2, data[0]);
			Assert.AreEqual(Format.Nil, data[1]);
			Assert.AreEqual(Format.Nil, data[2]);
		}

		[Test]
		public void Objects()
		{
			object[] value = { 1, false };
			byte[] data = MsgPack.Pack(value);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(Format.FixArrayMin + 2, data[0]);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[1]);
			Assert.AreEqual(Format.False, data[2]);
		}

		[Test]
		public void Maps()
		{
			object[] value = { new Map() };
			byte[] data = MsgPack.Pack(value);
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
		public void FixedArrayMax()
		{
			int[] value = new int[15];
			for(int i = 0; i < value.Length; i++) {
				value[i] = i;
			}
			byte[] data = MsgPack.Pack(value);
			Assert.AreEqual(Format.FixArrayMax, data[0]);
			Assert.AreEqual(16, data.Length);
		}

		[Test]
		public void Array16Min()
		{
			int[] value = new int[16];
			for(int i = 0; i < value.Length; i++) {
				value[i] = i;
			}
			byte[] data = MsgPack.Pack(value);
			int[] result = MsgPack.Unpack<int[]>(data);
			Assert.AreEqual(Format.Array16, data[0]);
			Assert.AreEqual(value.Length, result.Length);
			for(int i = 0; i < result.Length; i++) {
				Assert.AreEqual(i, value[i]);
			}
		}

		[Test]
		public void Array16Max()
		{
			int[] value = new int[ushort.MaxValue];
			for(int i = 0; i < value.Length; i++) {
				value[i] = i;
			}
			byte[] data = MsgPack.Pack(value);
			int[] result = MsgPack.Unpack<int[]>(data);
			Assert.AreEqual(Format.Array16, data[0]);
			Assert.AreEqual(value.Length, result.Length);
			for(int i = 0; i < result.Length; i++) {
				Assert.AreEqual(i, value[i]);
			}
		}

		[Test]
		public void Array32Min()
		{
			int[] value = new int[ushort.MaxValue + 1];
			for(int i = 0; i < value.Length; i++) {
				value[i] = i;
			}
			byte[] data = MsgPack.Pack(value);
			int[] result = MsgPack.Unpack<int[]>(data);
			Assert.AreEqual(Format.Array32, data[0]);
			Assert.AreEqual(value.Length, result.Length);
			for(int i = 0; i < result.Length; i++) {
				Assert.AreEqual(i, value[i]);
			}
		}
	}
}
