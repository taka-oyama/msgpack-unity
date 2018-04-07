using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class UIntHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackPositiveFixIntMinAsUInt()
		{
			uint value = 0;
			byte[] data = MessagePack.Pack<uint>(value);
			uint result = MessagePack.Unpack<uint>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixIntMaxAsUInt()
		{
			uint value = (uint)sbyte.MaxValue;
			byte[] data = MessagePack.Pack<uint>(value);
			uint result = MessagePack.Unpack<uint>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MinAsUInt()
		{
			uint value = sbyte.MaxValue + 1;
			byte[] data = MessagePack.Pack<uint>(value);
			uint result = MessagePack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MaxAsUInt()
		{
			uint value = byte.MaxValue;
			byte[] data = MessagePack.Pack<uint>(value);
			uint result = MessagePack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MinAsUInt()
		{
			uint value = byte.MaxValue + 1;
			byte[] data = MessagePack.Pack<uint>(value);
			uint result = MessagePack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MaxAsUInt()
		{
			uint value = ushort.MaxValue;
			byte[] data = MessagePack.Pack<uint>(value);
			uint result = MessagePack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt32MinAsUInt()
		{
			uint value = ushort.MaxValue + 1;
			byte[] data = MessagePack.Pack<uint>(value);
			uint result = MessagePack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt32MaxAsUInt()
		{
			uint value = uint.MaxValue;
			byte[] data = MessagePack.Pack<uint>(value);
			uint result = MessagePack.Unpack<uint>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackPositiveFixIntMinAsUInt()
		{
			uint value = MessagePack.Unpack<uint>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsUInt()
		{
			uint value = MessagePack.Unpack<uint>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsUInt()
		{
			uint value = MessagePack.Unpack<uint>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8MaxAsUInt()
		{
			uint value = MessagePack.Unpack<uint>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16MinAsUInt()
		{
			uint value = MessagePack.Unpack<uint>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16MaxAsUInt()
		{
			uint value = MessagePack.Unpack<uint>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UnpackUInt32MinAsUInt()
		{
			uint value = MessagePack.Unpack<uint>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt32MaxAsUInt()
		{
			uint value = MessagePack.Unpack<uint>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UnpackUInt64MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/UInt64Min")));
		}

		[Test]
		public void UnpackUInt64MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/UInt64Max")));
		}

		[Test]
		public void UnpackNegativeFixIntMinAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/NegativeFixIntMin")));
		}

		[Test]
		public void UnpackNegativeFixIntMaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/NegativeFixIntMax")));
		}

		[Test]
		public void UnpackInt8MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/Int8Min")));
		}

		[Test]
		public void UnpackInt8MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/Int8Max")));
		}

		[Test]
		public void UnpackInt16MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/Int16Min")));
		}

		[Test]
		public void UnpackInt16MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/Int16Max")));
		}

		[Test]
		public void UnpackInt32MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/Int32Min")));
		}

		[Test]
		public void UnpackInt32MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/Int32Max")));
		}

		[Test]
		public void UnpackInt64MinAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/Int64Min")));
		}

		[Test]
		public void UnpackInt64MaxAsUInt()
		{
			Assert.Throws<FormatException>(() => MessagePack.Unpack<uint>(ReadFile("Ints/Int64Max")));
		}

		#endregion
	}
}
