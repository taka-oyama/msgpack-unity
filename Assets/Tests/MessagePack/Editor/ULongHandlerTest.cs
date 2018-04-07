using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class ULongHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackPositiveFixIntMinAsULong()
		{
			ulong value = 0;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.PositiveFixIntMin, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackPositiveFixIntMaxAsULong()
		{
			ulong value = (uint)sbyte.MaxValue;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.PositiveFixIntMax, data[0]);
			Assert.AreEqual(1, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MinAsULong()
		{
			ulong value = sbyte.MaxValue + 1;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt8MaxAsULong()
		{
			ulong value = byte.MaxValue;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt8, data[0]);
			Assert.AreEqual(2, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MinAsULong()
		{
			ulong value = byte.MaxValue + 1;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt16MaxAsULong()
		{
			ulong value = ushort.MaxValue;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt16, data[0]);
			Assert.AreEqual(3, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt32MinAsULong()
		{
			ulong value = ushort.MaxValue + 1;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt32MaxAsULong()
		{
			ulong value = uint.MaxValue;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt32, data[0]);
			Assert.AreEqual(5, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt64MinAsULong()
		{
			ulong value = (ulong)uint.MaxValue + 1;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackUInt64MaxAsULong()
		{
			ulong value = ulong.MaxValue;
			byte[] data = MessagePack.Pack<ulong>(value);
			ulong result = MessagePack.Unpack<ulong>(data);
			Assert.AreEqual(Format.UInt64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value, result);
		}

		#endregion

		#region Unpack

		[Test]
		public void UnpackPositiveFixIntMinAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void UnpackPositiveFixIntMaxAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt8MinAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt8MaxAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16MinAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16MaxAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UnpackUInt32MinAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt32MaxAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UnpackUInt64MinAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/UInt64Min"));
			Assert.AreEqual((long)uint.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt64MaxAsULong()
		{
			ulong value = MessagePack.Unpack<ulong>(ReadFile("Ints/UInt64Max"));
			Assert.AreEqual(ulong.MaxValue, value);
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
