using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class NullableHandlerTest : TestBase
	{
		enum MyEnum
		{
			Foo = 1,
		}

		#region Pack

		[Test]
		public void PackNullableInt()
		{
			int? value = 1;
			byte[] data = Pack<int?>(value);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void PackNullableIntAsNull()
		{
			int? value = null;
			byte[] data = Pack<int?>(value);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void PackNullableEnum()
		{
			MyEnum? value = MyEnum.Foo;
			byte[] data = Pack<MyEnum?>(value);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void PackNullableEnumAsNull()
		{
			MyEnum? value = null;
			byte[] data = Pack<MyEnum?>(value);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackNullableInt()
		{
			int? value = Unpack<int?>(ReadFile("Nullables/Int"));
			Assert.AreEqual(1, value);
		}

		[Test]
		public void UnpackNullableIntAsNull()
		{
			int? value = Unpack<int?>(ReadFile("Nullables/Nil"));
			Assert.AreEqual(null, value);
		}

		[Test]
		public void UnpackNullableEnum()
		{
			MyEnum? value = Unpack<MyEnum>(ReadFile("Nullables/EnumInt"));
			Assert.AreEqual(MyEnum.Foo, value);
		}

		[Test]
		public void UnpackNullableEnumAsNull()
		{
			MyEnum? value = Unpack<MyEnum?>(ReadFile("Nullables/Nil"));
			Assert.AreEqual(null, value);
		}

		#endregion
	}
}
