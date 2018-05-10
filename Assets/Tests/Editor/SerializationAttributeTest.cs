using System;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class SerializationAttributeTest : TestBase
	{
		class MapNonSerializable { public int a; }
		[Serializable] class MapTemp { public int? a; }
		[Serializable] class MapActual {[NonSerialized] public int? a; }
		[Serializable] class MapWithSerializing { public int a;[OnSerializing] void T1() { a = 1; } }
		[Serializable] class MapWithDeserializing { public int a;[OnDeserializing] void T1() { a = 3; } }
		[Serializable] class MapWithSerialized { public int a;[OnSerialized] void T1() { a = 2; } }
		[Serializable] class MapWithDeserialized { public int a;[OnDeserialized] void T1() { a = 4; } }
		[Serializable] class MapWithSerializings { public int a, b;[OnSerializing] void T1() { a = 1; }[OnSerializing] void T2() { b = 2; } }

		[Serializable] class MapWithEnum
		{
			public enum MyEnum { A, B }
			public MyEnum a = MyEnum.B;
		}

		[Test]
		public void PackNonSerializableDisabled()
		{
			var context = new SerializationContext();
			context.MapOptions.RequireSerializableAttribute = false;
			var data = ReadFile("Maps/MapSkippable");
			Assert.Throws<CustomAttributeFormatException>(() => Unpack<MapNonSerializable>(data, context));
		}

		[Test]
		public void UnpackNonSerializableDisabled()
		{
			var context = new SerializationContext();
			context.MapOptions.RequireSerializableAttribute = false;
			var map = new MapNonSerializable() { a = 1 };
			Assert.Throws<CustomAttributeFormatException>(() => Pack(map, context));
		}

		[Test]
		public void PackNonSerializableEnabled()
		{
			var context = new SerializationContext();
			context.MapOptions.RequireSerializableAttribute = true;
			var data = ReadFile("Maps/MapSkippable");
			Assert.DoesNotThrow(() => Unpack<MapNonSerializable>(data, context));
		}

		[Test]
		public void UnpackNonSerializableEnabled()
		{
			var context = new SerializationContext();
			context.MapOptions.RequireSerializableAttribute = true;
			var map = new MapNonSerializable() { a = 1 };
			Assert.DoesNotThrow(() => Pack(map, context));
		}

		[Test]
		public void PackNonSerialize()
		{
			MapActual map = new MapActual() { a = 1 };
			byte[] bytes = Pack(map);
			Assert.AreEqual(1, bytes.Length);
			Assert.AreEqual(Format.FixMapMin, bytes[0]);
		}

		[Test]
		public void UnpackNonSerialize()
		{
			MapTemp map = new MapTemp() { a = 1 };
			byte[] bytes = Pack(map);
			MapActual actual = Unpack<MapActual>(bytes);
			Assert.AreEqual(null, actual.a);
		}

		[Test]
		public void PackMapWithSerializing()
		{
			MapWithSerializing mapBefore = new MapWithSerializing();
			byte[] bytes = Pack(mapBefore);
			MapWithSerializing mapAfter = Unpack<MapWithSerializing>(bytes);
			Assert.AreEqual(1, mapAfter.a); // overwritten by callback
		}

		[Test]
		public void UnpackMapWithDeserializing()
		{
			MapWithDeserializing mapBefore = new MapWithDeserializing();
			byte[] bytes = Pack(mapBefore);
			MapWithDeserializing mapAfter = Unpack<MapWithDeserializing>(bytes);
			Assert.AreEqual(0, mapAfter.a); // overwritten by packed value
		}

		[Test]
		public void PackMapWithSerialized()
		{
			MapWithSerialized mapBefore = new MapWithSerialized();
			byte[] bytes = Pack(mapBefore);
			MapWithSerialized mapAfter = Unpack<MapWithSerialized>(bytes);
			Assert.AreEqual(0, mapAfter.a); // overwritten after packing so not reflected on unpacking
		}

		[Test]
		public void UnpackMapWithDeserialized()
		{
			MapWithDeserialized mapBefore = new MapWithDeserialized();
			byte[] bytes = Pack(mapBefore);
			MapWithDeserialized mapAfter = Unpack<MapWithDeserialized>(bytes);
			Assert.AreEqual(4, mapAfter.a); // overwritten by callback
		}

		[Test]
		public void MultipleSerializings()
		{
			MapWithSerializings mapBefore = new MapWithSerializings();
			byte[] bytes = Pack(mapBefore);
			MapWithSerializings mapAfter = Unpack<MapWithSerializings>(bytes);
			Assert.AreEqual(1, mapAfter.a); // overwritten by callback
			Assert.AreEqual(2, mapAfter.b); // overwritten by callback
		}

		[Test]
		public void PackMapWithEnum()
		{
			byte[] bytes = Pack(new MapWithEnum());
			Assert.AreEqual(4, bytes.Length);
			Assert.AreEqual(Format.FixMapMin + 1, bytes[0]);
		}

		[Test]
		public void UnpackMapWithEnum()
		{
			byte[] bytes = Pack(new MapWithEnum());
			var data = Unpack<MapWithEnum>(bytes);
			Assert.AreEqual(data.a, MapWithEnum.MyEnum.B);
		}

	}
}
