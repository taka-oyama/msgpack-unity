using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class CharHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackPositiveFixIntMinAsChar()
		{
			char value = (char)0;
			byte[] data = Pack<char>(value);
			char result = Unpack<char>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixIntMaxAsChar()
		{
			char value = (char)sbyte.MaxValue;
			byte[] data = Pack<char>(value);
			char result = Unpack<char>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MinAsChar()
		{
			char value = (char)(sbyte.MaxValue + 1);
			byte[] data = Pack<char>(value);
			char result = Unpack<char>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MaxAsChar()
		{
			char value = (char)(byte.MaxValue);
			byte[] data = Pack<char>(value);
			char result = Unpack<char>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MinAsChar()
		{
			char value = (char)(byte.MaxValue + 1);
			byte[] data = Pack<char>(value);
			char result = Unpack<char>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MaxAsChar()
		{
			char value = (char)(ushort.MaxValue);
			byte[] data = Pack<char>(value);
			char result = Unpack<char>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackPositiveFixIntMinAsChar()
		{
			Assert.AreEqual(0, Unpack<char>(ReadFile("Ints/PositiveFixIntMin")));
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsChar()
		{
			Assert.AreEqual(sbyte.MaxValue, Unpack<char>(ReadFile("Ints/PositiveFixIntMax")));
		}

		[Test]
		public void UnpackUInt8MinAsChar()
		{
			Assert.AreEqual(sbyte.MaxValue + 1, Unpack<char>(ReadFile("Ints/UInt8Min")));
		}

		[Test]
		public void UnpackUInt8MaxAsChar()
		{
			Assert.AreEqual(byte.MaxValue, Unpack<char>(ReadFile("Ints/UInt8Max")));
		}

		[Test]
		public void UnpackUInt16MinAsChar()
		{
			Assert.AreEqual(byte.MaxValue + 1, Unpack<char>(ReadFile("Ints/UInt16Min")));
		}

		[Test]
		public void UnpackUInt16MaxAsChar()
		{
			Assert.AreEqual(ushort.MaxValue, Unpack<char>(ReadFile("Ints/UInt16Max")));
		}

		[Test]
		public void UnpackUInt32MinAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/UInt32Min")));
		}

		[Test]
		public void UnpackUInt32MaxAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/UInt32Max")));
		}

		[Test]
		public void UnpackUInt64MinAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UnpackUInt64MaxAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void UnpackNegativeFixIntMinAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/NegativeFixIntMin")));
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/NegativeFixIntMax")));
		}

		[Test]
		public void UnpackInt8MinAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/Int8Min")));
		}

		[Test]
		public void UnpackInt8MaxAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/Int8Max")));
		}

		[Test]
		public void UnpackInt16MinAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void UnpackInt16MaxAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void UnpackInt32MinAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void UnpackInt32MaxAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void UnpackInt64MinAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void UnpackInt64MaxAsChar()
		{
			Assert.Throws<FormatException>(() => Unpack<char>(ReadFile("Ints/Int64Max")));
		}

		#endregion
	}
}
