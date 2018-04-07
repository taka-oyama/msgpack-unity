using UnityEngine;
using NUnit.Framework;
using System.Text;

namespace MessagePack.Tests
{
	public class ArrayHandlerTest : TestBase
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
			int[] value = null;
			byte[] data = MessagePack.Pack(value);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(Format.Nil, data[0]);
		}

		[Test]
		public void PackNils()
		{
			string[] value = { null, null };
			byte[] data = MessagePack.Pack(value);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(Format.FixArrayMin + 2, data[0]);
			Assert.AreEqual(Format.Nil, data[1]);
			Assert.AreEqual(Format.Nil, data[2]);
		}

		[Test]
		public void PackObjects()
		{
			object[] value = { 1, false };
			byte[] data = MessagePack.Pack(value);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(Format.FixArrayMin + 2, data[0]);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[1]);
			Assert.AreEqual(Format.False, data[2]);
		}

		[Test]
		public void PackMaps()
		{
			object[] value = { new MapWithNullable() };
			byte[] data = MessagePack.Pack(value);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.FixMapMin + 1, data[1]);
			Assert.AreEqual(Format.FixStrMin + 1, data[2]);
			Assert.AreEqual("b", Encoding.UTF8.GetString(new byte[] { data[3] }));
			Assert.AreEqual(Format.PositiveFixIntMin, data[4]);
			Assert.AreEqual(5, data.Length);
		}

		[Test]
		public void PackFixedArrayMax()
		{
			int[] value = new int[15];
			for(int i = 0; i < value.Length; i++) {
				value[i] = i;
			}
			byte[] data = MessagePack.Pack(value);
			Assert.AreEqual(Format.FixArrayMax, data[0]);
			Assert.AreEqual(16, data.Length);
		}

		[Test]
		public void PackArray16Min()
		{
			int[] value = new int[16];
			for(int i = 0; i < value.Length; i++) {
				value[i] = i;
			}
			byte[] data = MessagePack.Pack(value);
			int[] result = MessagePack.Unpack<int[]>(data);
			Assert.AreEqual(Format.Array16, data[0]);
			Assert.AreEqual(value.Length, result.Length);
			for(int i = 0; i < result.Length; i++) {
				Assert.AreEqual(i, value[i]);
			}
		}

		[Test]
		public void PackArray16Max()
		{
			int[] value = new int[ushort.MaxValue];
			for(int i = 0; i < value.Length; i++) {
				value[i] = i;
			}
			byte[] data = MessagePack.Pack(value);
			int[] result = MessagePack.Unpack<int[]>(data);
			Assert.AreEqual(Format.Array16, data[0]);
			Assert.AreEqual(value.Length, result.Length);
			for(int i = 0; i < result.Length; i++) {
				Assert.AreEqual(i, value[i]);
			}
		}

		[Test]
		public void PackArray32Min()
		{
			int[] value = new int[ushort.MaxValue + 1];
			for(int i = 0; i < value.Length; i++) {
				value[i] = i;
			}
			byte[] data = MessagePack.Pack(value);
			int[] result = MessagePack.Unpack<int[]>(data);
			Assert.AreEqual(Format.Array32, data[0]);
			Assert.AreEqual(value.Length, result.Length);
			for(int i = 0; i < result.Length; i++) {
				Assert.AreEqual(i, value[i]);
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
			int?[] nil = MessagePack.Unpack<int?[]>(ReadFile("Arrays/Nil"));
			Assert.AreEqual(0, nil.Length);
		}

		[Test]
		public void UnpackNils()
		{
			int?[] nils = MessagePack.Unpack<int?[]>(ReadFile("Arrays/Nils"));
			Assert.AreEqual(2, nils.Length);
			for(int i = 0; i < nils.Length; i++) {
				Assert.AreEqual(nils[i], null);
			}
		}

		[Test]
		public void UnpackArrays()
		{
			int[][] arrays = MessagePack.Unpack<int[][]>(ReadFile("Arrays/Arrays"));
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
			Map[] maps = MessagePack.Unpack<Map[]>(ReadFile("Arrays/Maps"));
			Assert.AreEqual(2, maps.Length);
			Assert.AreEqual(1, maps[0].a);
			Assert.AreEqual(0, maps[0].b);
			Assert.AreEqual(0, maps[1].a);
			Assert.AreEqual(2, maps[1].b);
		}

		[Test]
		public void UnpackFixArrayMin()
		{
			int[] test = MessagePack.Unpack<int[]>(ReadFile("Arrays/FixArrayMin"));
			Assert.AreEqual(0, test.Length);
		}

		[Test]
		public void UnpackFixArrayMax()
		{
			int[] ints = MessagePack.Unpack<int[]>(ReadFile("Arrays/FixArrayMax"));
			Assert.AreEqual(ints.Length, 15);
			for(int i = 0; i < ints.Length; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Min()
		{
			int[] ints = MessagePack.Unpack<int[]>(ReadFile("Arrays/Array16Min"));
			Assert.AreEqual(ints.Length, 16);
			for(int i = 0; i < ints.Length; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Max()
		{
			int[] ints = MessagePack.Unpack<int[]>(ReadFile("Arrays/Array16Max"));
			Assert.AreEqual(ints.Length, 65535);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray32Min()
		{
			int[] ints = MessagePack.Unpack<int[]>(ReadFile("Arrays/Array32Min"));
			Assert.AreEqual(ints.Length, 65536);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		#endregion


		#region Options

		[Test]
		public void TreatNullAsEmpty()
		{
			var context = new SerializationContext();
			context.arrayOptions.nullAsEmptyOnUnpack = true;
			int[] value = null;
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<int[]>(data, context);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(new int[0], result);
		}

		[Test]
		public void DoNotTreatNullAsEmpty()
		{
			var context = new SerializationContext();
			context.arrayOptions.nullAsEmptyOnUnpack = false;
			int[] value = null;
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<int[]>(data, context);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(value, result);
		}

		#endregion
	}
}
