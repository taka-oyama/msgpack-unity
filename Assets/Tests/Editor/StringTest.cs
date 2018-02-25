using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class StringTest : TestBase
	{
		[Test]
		public void UnpackNil()
		{
			byte[] bytes = ReadFile(basePath + "/Strings/Nil.mpack");
			string value = MsgPack.Unpack<string>(bytes);
			Assert.AreEqual(null, value);
		}

		[Test]
		public void UnpackFixStrMin()
		{
			byte[] bytes = ReadFile(basePath + "/Strings/FixStrMin.mpack");
			string value = MsgPack.Unpack<string>(bytes);
			Assert.AreEqual("", value);
		}

		[Test]
		public void UnpackFixStrMax()
		{
			byte[] bytes = ReadFile(basePath + "/Strings/FixStrMax.mpack");
			string value = MsgPack.Unpack<string>(bytes);
			Assert.AreEqual(new String('A', 31), value);
		}

		[Test]
		public void UnpackStr8Min()
		{
			byte[] bytes = ReadFile(basePath + "/Strings/Str8Min.mpack");
			string value = MsgPack.Unpack<string>(bytes);
			Assert.AreEqual(new String('A', 32), value);
		}

		[Test]
		public void UnpackStr8Max()
		{
			byte[] bytes = ReadFile(basePath + "/Strings/Str8Max.mpack");
			string value = MsgPack.Unpack<string>(bytes);
			Assert.AreEqual(new String('A', byte.MaxValue), value);
		}

		[Test]
		public void UnpackStr16Min()
		{
			byte[] bytes = ReadFile(basePath + "/Strings/Str16Min.mpack");
			string value = MsgPack.Unpack<string>(bytes);
			Assert.AreEqual(new String('A', byte.MaxValue + 1), value);
		}

		[Test]
		public void UnpackStr16Max()
		{
			byte[] bytes = ReadFile(basePath + "/Strings/Str16Max.mpack");
			string value = MsgPack.Unpack<string>(bytes);
			Assert.AreEqual(new String('A', ushort.MaxValue), value);
		}

		[Test]
		public void UnpackStr32Min()
		{
			byte[] bytes = ReadFile(basePath + "/Strings/Str32Min.mpack");
			string value = MsgPack.Unpack<string>(bytes);
			Assert.AreEqual(new String('A', ushort.MaxValue + 1), value);
		}

		public void UnpackStr32Max()
		{
			// Omitted because the filesize is too big
		}
	}
}
