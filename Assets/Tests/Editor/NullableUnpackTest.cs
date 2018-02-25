using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class NullableUnpackTest : TestBase
	{
		enum MyEnum
		{
			Foo = 1,
		}

		[Test]
		public void UnpackNullableInt()
		{
			byte[] bytes = ReadFile(basePath + "/Nullables/Int.mpack");
			int? value = MsgPack.Unpack<int?>(bytes);
			Assert.AreEqual(1, value);
		}

		[Test]
		public void UnpackNullableIntAsNull()
		{
			byte[] bytes = ReadFile(basePath + "/Nullables/Nil.mpack");
			int? value = MsgPack.Unpack<int?>(bytes);
			Assert.AreEqual(null, value);
		}

		[Test]
		public void UnpackNullableEnum()
		{
			byte[] bytes = ReadFile(basePath + "/Nullables/EnumInt.mpack");
			MyEnum value = MsgPack.Unpack<MyEnum>(bytes);
			Assert.AreEqual(MyEnum.Foo, value);
		}

		[Test]
		public void UnpackNullableEnumAsNull()
		{
			byte[] bytes = ReadFile(basePath + "/Nullables/Nil.mpack");
			MyEnum? value = MsgPack.Unpack<MyEnum?>(bytes);
			Assert.AreEqual(null, value);
		}
	}
}
