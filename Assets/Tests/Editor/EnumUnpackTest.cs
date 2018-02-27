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
		public void EnumFromInt()
		{
			MyEnum value = MsgPack.Unpack<MyEnum>(ReadFile("Enums/EnumInt"));
			Assert.AreEqual(MyEnum.Foo, value);
		}

		[Test]
		public void EnumFromString()
		{
			MyEnum value = MsgPack.Unpack<MyEnum>(ReadFile("Enums/EnumString"));
			Assert.AreEqual(MyEnum.Foo, value);
		}
	}
}
