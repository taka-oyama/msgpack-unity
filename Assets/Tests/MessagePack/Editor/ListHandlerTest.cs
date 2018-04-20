using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace MessagePack.Tests
{
	public class ListHandlerTest : TestBase
	{
		struct MapWithNullable
		{
			public int? a;
			public int b;
		}

		#region Pack

		[Test]
		public void PackNil()
		{
			List<int> nil = null;
			byte[] data = Pack(nil);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void PackNils()
		{
			var nils = new List<int?>() { null };
			byte[] data = Pack(nils);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.Nil, data[1]);
			Assert.AreEqual(2, data.Length);
		}

		[Test]
		public void PackArrays()
		{
			var arrays = new List<List<int>>() { new List<int>() { 0 } };
			byte[] data = Pack(arrays);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.FixArrayMin + 1, data[1]);
			Assert.AreEqual(0, data[2]);
			Assert.AreEqual(3, data.Length);
		}

		[Test]
		public void PackMaps()
		{
			var maps = new List<MapWithNullable>() { new MapWithNullable() };
			byte[] data = Pack(maps);
			Assert.AreEqual(Format.FixArrayMin + 1, data[0]);
			Assert.AreEqual(Format.FixMapMin + 1, data[1]);
			Assert.AreEqual(Format.FixStrMin + 1, data[2]);
			Assert.AreEqual("b", Encoding.UTF8.GetString(new byte[] { data[3] }));
			Assert.AreEqual(Format.PositiveFixIntMin, data[4]);
			Assert.AreEqual(5, data.Length);
		}

		[Test]
		public void PackFixArrayMin()
		{
			var ints = new List<int>();
			byte[] data = Pack(ints);
			Assert.AreEqual(Format.FixArrayMin, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void PackFixArrayMax()
		{
			var ints = new List<int>(15);
			for(int i = 0; i < ints.Capacity; i++) {
				ints.Add(i);
			}
			byte[] data = Pack(ints);
			var result = Unpack<List<int>>(data);
			Assert.AreEqual(Format.FixArrayMax, data[0]);
			Assert.AreEqual(16, data.Length);

			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(i, result[i]);
			}
		}

		[Test]
		public void PackArray16Min()
		{
			var ints = new List<int>(16);
			for(int i = 0; i < ints.Capacity; i++) {
				ints.Add(i);
			}
			byte[] data = Pack(ints);
			var result = Unpack<List<int>>(data);
			Assert.AreEqual(Format.Array16, data[0]);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(i, result[i]);
			}
		}

		[Test]
		public void PackArray16Max()
		{
			var ints = new List<int>(ushort.MaxValue);
			for(int i = 0; i < ints.Capacity; i++) {
				ints.Add(i);
			}
			byte[] data = Pack(ints);
			var result = Unpack<List<int>>(data);
			Assert.AreEqual(Format.Array16, data[0]);
			for(int i = 0; i < result.Count; i++) {
				Assert.AreEqual(i, result[i]);
			}
		}

		[Test]
		public void PackArray32Min()
		{
			var ints = new List<int>(ushort.MaxValue + 1);
			for(int i = 0; i < ints.Capacity; i++) {
				ints.Add(i);
			}
			byte[] data = Pack(ints);
			var result = Unpack<List<int>>(data);
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
			var nil = Unpack<List<int>>(ReadFile("Arrays/Nil"));
			Assert.AreEqual(0, nil.Count);
		}

		[Test]
		public void UnpackNils()
		{
			var nils = Unpack<List<int?>>(ReadFile("Arrays/Nils"));
			Assert.AreEqual(2, nils.Count);
			for(int i = 0; i < nils.Count; i++) {
				Assert.AreEqual(nils[i], null);
			}
		}

		[Test]
		public void UnpackArrays()
		{
			var arrays = Unpack<List<List<int?>>>(ReadFile("Arrays/Arrays"));
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
			var maps = Unpack<List<Map>>(ReadFile("Arrays/Maps"));
			Assert.AreEqual(2, maps.Count);
			Assert.AreEqual(1, maps[0].a);
			Assert.AreEqual(0, maps[0].b);
			Assert.AreEqual(0, maps[1].a);
			Assert.AreEqual(2, maps[1].b);
		}

		[Test]
		public void UnpackFixArrayMin()
		{
			var test = Unpack<List<Map>>(ReadFile("Arrays/FixArrayMin"));
			Assert.AreEqual(0, test.Count);
		}

		[Test]
		public void UnpackFixArrayMax()
		{
			var ints = Unpack<List<int>>(ReadFile("Arrays/FixArrayMax"));
			Assert.AreEqual(ints.Count, 15);
			for(int i = 0; i < ints.Count; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Min()
		{
			var ints = Unpack<List<int>>(ReadFile("Arrays/Array16Min"));
			Assert.AreEqual(ints.Count, 16);
			for(int i = 0; i < ints.Count; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray16Max()
		{
			var ints = Unpack<List<int>>(ReadFile("Arrays/Array16Max"));
			Assert.AreEqual(ints.Count, 65535);
			for(int i = 0; i < 10; i++) {
				Assert.AreEqual(i, ints[i]);
			}
		}

		[Test]
		public void UnpackArray32Min()
		{
			var ints = Unpack<List<int>>(ReadFile("Arrays/Array32Min"));
			Assert.AreEqual(ints.Count, 65536);
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
			List<int> value = null;
			byte[] data = Pack(value);
			var result = Unpack<List<int>>(data, context);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(new List<int>(0), result);
		}

		[Test]
		public void DoNotTreatNullAsEmpty()
		{
			var context = new SerializationContext();
			context.arrayOptions.nullAsEmptyOnUnpack = false;
			List<int> value = null;
			byte[] data = Pack(value);
			var result = Unpack<List<int>>(data, context);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(value, result);
		}

		#endregion
	}
}
