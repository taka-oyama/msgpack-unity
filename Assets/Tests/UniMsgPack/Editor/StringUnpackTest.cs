using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class StringUnpackTest : TestBase
	{
		[Test]
		public void Nil()
		{
			string value = MsgPack.Unpack<string>(ReadFile("Strings/Nil"));
			Assert.AreEqual(null, value);
		}

		[Test]
		public void FixStrMin()
		{
			string value = MsgPack.Unpack<string>(ReadFile("Strings/FixStrMin"));
			Assert.AreEqual("", value);
		}

		[Test]
		public void FixStrMax()
		{
			string value = MsgPack.Unpack<string>(ReadFile("Strings/FixStrMax"));
			Assert.AreEqual(new String('A', 31), value);
		}

		[Test]
		public void Str8Min()
		{
			string value = MsgPack.Unpack<string>(ReadFile("Strings/Str8Min"));
			Assert.AreEqual(new String('A', 32), value);
		}

		[Test]
		public void Str8Max()
		{
			string value = MsgPack.Unpack<string>(ReadFile("Strings/Str8Max"));
			Assert.AreEqual(new String('A', byte.MaxValue), value);
		}

		[Test]
		public void Str16Min()
		{
			string value = MsgPack.Unpack<string>(ReadFile("Strings/Str16Min"));
			Assert.AreEqual(new String('A', byte.MaxValue + 1), value);
		}

		[Test]
		public void Str16Max()
		{
			string value = MsgPack.Unpack<string>(ReadFile("Strings/Str16Max"));
			Assert.AreEqual(new String('A', ushort.MaxValue), value);
		}

		[Test]
		public void Str32Min()
		{
			string value = MsgPack.Unpack<string>(ReadFile("Strings/Str32Min"));
			Assert.AreEqual(new String('A', ushort.MaxValue + 1), value);
		}

		public void Str32Max()
		{
			// Omitted because the filesize is too big
		}
	}
}
