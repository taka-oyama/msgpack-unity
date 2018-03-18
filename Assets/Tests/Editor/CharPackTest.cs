using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class CharPackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsChar()
		{
			char value = (char)0;
			byte[] data = MsgPack.Pack<char>(value);
			char result = MsgPack.Unpack<char>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PositiveFixIntMaxAsChar()
		{
			char value = (char)sbyte.MaxValue;
			byte[] data = MsgPack.Pack<char>(value);
			char result = MsgPack.Unpack<char>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MinAsChar()
		{
			char value = (char)(sbyte.MaxValue + 1);
			byte[] data = MsgPack.Pack<char>(value);
			char result = MsgPack.Unpack<char>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt8MaxAsChar()
		{
			char value = (char)(byte.MaxValue);
			byte[] data = MsgPack.Pack<char>(value);
			char result = MsgPack.Unpack<char>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MinAsChar()
		{
			char value = (char)(byte.MaxValue + 1);
			byte[] data = MsgPack.Pack<char>(value);
			char result = MsgPack.Unpack<char>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UInt16MaxAsChar()
		{
			char value = (char)(ushort.MaxValue);
			byte[] data = MsgPack.Pack<char>(value);
			char result = MsgPack.Unpack<char>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}
	}
}
