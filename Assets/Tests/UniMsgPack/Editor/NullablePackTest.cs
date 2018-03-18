using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class NullablePackTest : TestBase
	{
		enum MyEnum
		{
			Foo = 1,
		}

		[Test]
		public void NullableInt()
		{
			int? value = 1;
			byte[] data = MsgPack.Pack<int?>(value);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void NullableIntAsNull()
		{
			int? value = null;
			byte[] data = MsgPack.Pack<int?>(value);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void NullableEnum()
		{
			MyEnum? value = MyEnum.Foo;
			byte[] data = MsgPack.Pack<MyEnum?>(value);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[0]);
			Assert.AreEqual(1, data.Length);
		}

		[Test]
		public void NullableEnumAsNull()
		{
			MyEnum? value = null;
			byte[] data = MsgPack.Pack<MyEnum?>(value);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(1, data.Length);
		}
	}
}
