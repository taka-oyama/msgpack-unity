using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class CharUnpackTest : TestBase
	{
		[Test]
		public void PositiveFixIntMinAsChar()
		{
			Assert.AreEqual(0, MsgPack.Unpack<char>(ReadFile("Ints/PositiveFixIntMin")));
		}

		[Test]
		public void PositiveFixIntMaxAsChar()
		{
			Assert.AreEqual(sbyte.MaxValue, MsgPack.Unpack<char>(ReadFile("Ints/PositiveFixIntMax")));
		}

		[Test]
		public void UInt8MinAsChar()
		{
			Assert.AreEqual(sbyte.MaxValue + 1, MsgPack.Unpack<char>(ReadFile("Ints/UInt8Min")));
		}

		[Test]
		public void UInt8MaxAsChar()
		{
			Assert.AreEqual(byte.MaxValue, MsgPack.Unpack<char>(ReadFile("Ints/UInt8Max")));
		}

		[Test]
		public void UInt16MinAsChar()
		{
			Assert.AreEqual(byte.MaxValue + 1, MsgPack.Unpack<char>(ReadFile("Ints/UInt16Min")));
		}

		[Test]
		public void UInt16MaxAsChar()
		{
			Assert.AreEqual(ushort.MaxValue, MsgPack.Unpack<char>(ReadFile("Ints/UInt16Max")));
		}

		[Test]
		public void UInt32MinAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UInt32MaxAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UInt64MinAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UInt64MaxAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void NegativeFixIntMinAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/NegativeFixIntMin")));
		}

		[Test]
		public void NegativeFixIntMaxAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/NegativeFixIntMax")));
		}

		[Test]
		public void Int8MinAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/Int8Min")));
		}

		[Test]
		public void Int8MaxAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/Int8Max")));
		}

		[Test]
		public void Int16MinAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void Int16MaxAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void Int32MinAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void Int32MaxAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void Int64MinAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void Int64MaxAsChar()
		{
			Assert.Throws<FormatException>(() => MsgPack.Unpack<char>(ReadFile("Ints/Int64Max")));
		}
	}
}
