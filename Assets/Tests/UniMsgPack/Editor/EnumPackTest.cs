using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
    public class EnumPackTest : TestBase
    {
		enum MyEnum
		{
			Foo = 1,
		}

		[Test]
		public void Enum()
		{
			MyEnum value = MyEnum.Foo;
			byte[] data = MsgPack.Pack<MyEnum>(value);
			MyEnum result = MsgPack.Unpack<MyEnum>(data);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(MyEnum.Foo, result);
		}

		[Test]
		public void EnumFromInt()
		{
			int value = 1;
			byte[] data = MsgPack.Pack<int>(value);
			MyEnum result = MsgPack.Unpack<MyEnum>(data);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(MyEnum.Foo, result);
		}

		[Test]
		public void EnumFromString()
		{
			string value = "Foo";
			byte[] data = MsgPack.Pack<string>(value);
			MyEnum result = MsgPack.Unpack<MyEnum>(data);
			Assert.AreEqual(Format.FixStrMin + 3, data[0]);
			Assert.AreEqual(4, data.Length);
			Assert.AreEqual(MyEnum.Foo, result);
		}
    }
}
