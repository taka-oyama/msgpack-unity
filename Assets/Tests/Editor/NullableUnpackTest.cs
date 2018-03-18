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
		public void NullableInt()
		{
			int? value = MsgPack.Unpack<int?>(ReadFile("Nullables/Int"));
			Assert.AreEqual(1, value);
		}

		[Test]
		public void NullableIntAsNull()
		{
			int? value = MsgPack.Unpack<int?>(ReadFile("Nullables/Nil"));
			Assert.AreEqual(null, value);
		}

		[Test]
		public void NullableEnum()
		{
			MyEnum? value = MsgPack.Unpack<MyEnum>(ReadFile("Nullables/EnumInt"));
			Assert.AreEqual(MyEnum.Foo, value);
		}

		[Test]
		public void NullableEnumAsNull()
		{
			MyEnum? value = MsgPack.Unpack<MyEnum?>(ReadFile("Nullables/Nil"));
			Assert.AreEqual(null, value);
		}
	}
}
