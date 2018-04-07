using System;
using System.Runtime.Serialization;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class SerializationAttributeTest : TestBase
	{
		class MapTemp { public int? a; }
		class MapActual { [NonSerialized] public int? a; }
		class MapWithSerializing { public int a; [OnSerializing] void T1() { a = 1; } }
		class MapWithDeserializing { public int a; [OnDeserializing] void T1() { a = 3; } }
		class MapWithSerialized { public int a; [OnSerialized] void T1() { a = 2; } }
		class MapWithDeserialized { public int a; [OnDeserialized] void T1() { a = 4; } }
		class MapWithSerializings { public int a, b; [OnSerializing] void T1() { a = 1; } [OnSerializing] void T2() { b = 2; } }

		[Test]
		public void PackNonSerialize()
		{
			MapActual map = new MapActual() { a = 1 };
			byte[] bytes = MessagePack.Pack(map);
			Assert.AreEqual(1, bytes.Length);
			Assert.AreEqual(Format.FixMapMin, bytes[0]);
		}

		[Test]
		public void UnpackNonSerialize()
		{
			MapTemp map = new MapTemp() { a = 1 };
			byte[] bytes = MessagePack.Pack(map);
			MapActual actual = MessagePack.Unpack<MapActual>(bytes);
			Assert.AreEqual(null, actual.a);
		}

		[Test]
		public void PackMapWithSerializing()
		{
			MapWithSerializing mapBefore = new MapWithSerializing();
			byte[] bytes = MessagePack.Pack(mapBefore);
			MapWithSerializing mapAfter = MessagePack.Unpack<MapWithSerializing>(bytes);
			Assert.AreEqual(1, mapAfter.a); // overwritten by callback
		}

		[Test]
		public void UnpackMapWithDeserializing()
		{
			MapWithDeserializing mapBefore = new MapWithDeserializing();
			byte[] bytes = MessagePack.Pack(mapBefore);
			MapWithDeserializing mapAfter = MessagePack.Unpack<MapWithDeserializing>(bytes);
			Assert.AreEqual(0, mapAfter.a); // overwritten by packed value
		}

		[Test]
		public void PackMapWithSerialized()
		{
			MapWithSerialized mapBefore = new MapWithSerialized();
			byte[] bytes = MessagePack.Pack(mapBefore);
			MapWithSerialized mapAfter = MessagePack.Unpack<MapWithSerialized>(bytes);
			Assert.AreEqual(0, mapAfter.a); // overwritten after packing so not reflected on unpacking
		}

		[Test]
		public void UnpackMapWithDeserialized()
		{
			MapWithDeserialized mapBefore = new MapWithDeserialized();
			byte[] bytes = MessagePack.Pack(mapBefore);
			MapWithDeserialized mapAfter = MessagePack.Unpack<MapWithDeserialized>(bytes);
			Assert.AreEqual(4, mapAfter.a); // overwritten by callback
		}

		[Test]
		public void MultipleSerializings()
		{
			MapWithSerializings mapBefore = new MapWithSerializings();
			byte[] bytes = MessagePack.Pack(mapBefore);
			MapWithSerializings mapAfter = MessagePack.Unpack<MapWithSerializings>(bytes);
			Assert.AreEqual(1, mapAfter.a); // overwritten by callback
			Assert.AreEqual(2, mapAfter.b); // overwritten by callback
		}
	}
}
