using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class EnumHandlerTest : TestBase
	{
		#region Pack

		enum MyEnum
		{
			Foo = 1,
		}

		[Test]
		public void PackEnum()
		{
			MyEnum value = MyEnum.Foo;
			byte[] data = MessagePack.Pack<MyEnum>(value);
			MyEnum result = MessagePack.Unpack<MyEnum>(data);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(MyEnum.Foo, result);
		}

		[Test]
		public void PackEnumFromInt()
		{
			int value = 1;
			byte[] data = MessagePack.Pack<int>(value);
			MyEnum result = MessagePack.Unpack<MyEnum>(data);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(MyEnum.Foo, result);
		}

		[Test]
		public void PackEnumFromString()
		{
			string value = "Foo";
			byte[] data = MessagePack.Pack<string>(value);
			MyEnum result = MessagePack.Unpack<MyEnum>(data);
			Assert.AreEqual(Format.FixStrMin + 3, data[0]);
			Assert.AreEqual(4, data.Length);
			Assert.AreEqual(MyEnum.Foo, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void EnumFromInt()
		{
			MyEnum value = MessagePack.Unpack<MyEnum>(ReadFile("Enums/EnumInt"));
			Assert.AreEqual(MyEnum.Foo, value);
		}

		[Test]
		public void EnumFromString()
		{
			MyEnum value = MessagePack.Unpack<MyEnum>(ReadFile("Enums/EnumString"));
			Assert.AreEqual(MyEnum.Foo, value);
		}

		#endregion
	}
}
