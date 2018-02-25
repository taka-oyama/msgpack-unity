using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class EnumUnpackTest : TestBase
	{
		enum MyEnum
		{
			Foo = 1,
		}

		[Test]
		public void UnpackEnumFromInt()
		{
			byte[] bytes = ReadFile(basePath + "/Enums/EnumInt.mpack");
			MyEnum value = MsgPack.Unpack<MyEnum>(bytes);
			Assert.AreEqual(MyEnum.Foo, value);
		}

		[Test]
		public void UnpackEnumFromString()
		{
			byte[] bytes = ReadFile(basePath + "/Enums/EnumString.mpack");
			MyEnum value = MsgPack.Unpack<MyEnum>(bytes);
			Assert.AreEqual(MyEnum.Foo, value);
		}
	}
}
