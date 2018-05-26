using System;
using NUnit.Framework;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class StringHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackNil()
		{
			string value = null;
			byte[] data = Pack<string>(value);
			string result = Unpack<string>(data);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackFixStrMin()
		{
			string value = "";
			byte[] data = Pack<string>(value);
			string result = Unpack<string>(data);
			Assert.AreEqual(Format.FixStrMin, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackFixStrMax()
		{
			string value = new String('A', 31);
			byte[] data = Pack<string>(value);
			string result = Unpack<string>(data);
			Assert.AreEqual(Format.FixStrMax, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackStr8Min()
		{
			string value = new String('A', 32);
			byte[] data = Pack<string>(value);
			string result = Unpack<string>(data);
			Assert.AreEqual(Format.Str8, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackStr8Max()
		{
			string value = new String('A', byte.MaxValue);
			byte[] data = Pack<string>(value);
			string result = Unpack<string>(data);
			Assert.AreEqual(Format.Str8, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackStr16Min()
		{
			string value = new String('A', byte.MaxValue + 1);
			byte[] data = Pack<string>(value);
			string result = Unpack<string>(data);
			Assert.AreEqual(Format.Str16, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackStr16Max()
		{
			string value = new String('A', ushort.MaxValue);
			byte[] data = Pack<string>(value);
			string result = Unpack<string>(data);
			Assert.AreEqual(Format.Str16, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackStr32Min()
		{
			string value = new String('A', ushort.MaxValue + 1);
			byte[] data = Pack<string>(value);
			string result = Unpack<string>(data);
			Assert.AreEqual(Format.Str32, data[0]);
			Assert.AreEqual(value, result);
		}

		public void PackStr32Max()
		{
			// Omitted because the filesize is too big
		}

		[Test]
		public void PackStrWithMultiByteString()
		{
			string value = "あいうえお";
			byte[] data = Pack<string>(value);
			Assert.AreEqual(Format.FixStrMin + 15, data[0]);
			Assert.AreEqual(16, data.Length);
		}

		[Test]
		public void PackMultipleTimes()
		{
			var formatter = new MessagePackFormatter();
			string value1 = new String('A', 65);
			string value2 = new String('B', 5);
			byte[] data1 = formatter.Serialize(value1);
			byte[] data2 = formatter.Serialize(value2);
			string result1 = formatter.Deserialize<string>(data1);
			string result2 = formatter.Deserialize<string>(data2);
			Assert.AreEqual(value1, result1);
			Assert.AreEqual(value2, result2);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackNil()
		{
			string value = Unpack<string>(ReadFile("Strings/Nil"));
			Assert.AreEqual(null, value);
		}

		[Test]
		public void UnpackFixStrMin()
		{
			string value = Unpack<string>(ReadFile("Strings/FixStrMin"));
			Assert.AreEqual("", value);
		}

		[Test]
		public void UnpackFixStrMax()
		{
			string value = Unpack<string>(ReadFile("Strings/FixStrMax"));
			Assert.AreEqual(new String('A', 31), value);
		}

		[Test]
		public void UnpackStr8Min()
		{
			string value = Unpack<string>(ReadFile("Strings/Str8Min"));
			Assert.AreEqual(new String('A', 32), value);
		}

		[Test]
		public void UnpackStr8Max()
		{
			string value = Unpack<string>(ReadFile("Strings/Str8Max"));
			Assert.AreEqual(new String('A', byte.MaxValue), value);
		}

		[Test]
		public void UnpackStr16Min()
		{
			string value = Unpack<string>(ReadFile("Strings/Str16Min"));
			Assert.AreEqual(new String('A', byte.MaxValue + 1), value);
		}

		[Test]
		public void UnpackStr16Max()
		{
			string value = Unpack<string>(ReadFile("Strings/Str16Max"));
			Assert.AreEqual(new String('A', ushort.MaxValue), value);
		}

		[Test]
		public void UnpackStr32Min()
		{
			string value = Unpack<string>(ReadFile("Strings/Str32Min"));
			Assert.AreEqual(new String('A', ushort.MaxValue + 1), value);
		}

		public void UnpackStr32Max()
		{
			// Omitted because the filesize is too big
		}

		[Test]
		public void UnpackStrWithMultiByteString()
		{
			string value = "あいうえお";
			byte[] data = Pack<string>(value);
			string result = Unpack<string>(data);
			Assert.AreEqual(value, result);
		}

		#endregion
	}
}
