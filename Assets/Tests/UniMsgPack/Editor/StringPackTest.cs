using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class StringPackTest : TestBase
	{
		[Test]
		public void Nil()
		{
			string value = null;
			byte[] data = MsgPack.Pack<string>(value);
			string result = MsgPack.Unpack<string>(data);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void FixStrMin()
		{
			string value = "";
			byte[] data = MsgPack.Pack<string>(value);
			string result = MsgPack.Unpack<string>(data);
			Assert.AreEqual(Format.FixStrMin, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void FixStrMax()
		{
			string value = new String('A', 31);
			byte[] data = MsgPack.Pack<string>(value);
			string result = MsgPack.Unpack<string>(data);
			Assert.AreEqual(Format.FixStrMax, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Str8Min()
		{
			string value = new String('A', 32);
			byte[] data = MsgPack.Pack<string>(value);
			string result = MsgPack.Unpack<string>(data);
			Assert.AreEqual(Format.Str8, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Str8Max()
		{
			string value = new String('A', byte.MaxValue);
			byte[] data = MsgPack.Pack<string>(value);
			string result = MsgPack.Unpack<string>(data);
			Assert.AreEqual(Format.Str8, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Str16Min()
		{
			string value = new String('A', byte.MaxValue + 1);
			byte[] data = MsgPack.Pack<string>(value);
			string result = MsgPack.Unpack<string>(data);
			Assert.AreEqual(Format.Str16, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Str16Max()
		{
			string value = new String('A', ushort.MaxValue);
			byte[] data = MsgPack.Pack<string>(value);
			string result = MsgPack.Unpack<string>(data);
			Assert.AreEqual(Format.Str16, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Str32Min()
		{
			string value = new String('A', ushort.MaxValue + 1);
			byte[] data = MsgPack.Pack<string>(value);
			string result = MsgPack.Unpack<string>(data);
			Assert.AreEqual(Format.Str32, data[0]);
			Assert.AreEqual(value, result);
		}

		public void Str32Max()
		{
			// Omitted because the filesize is too big
		}
	}
}
