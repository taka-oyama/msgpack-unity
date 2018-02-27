using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class UIntUnpackTest : TestBase
	{
		#region PositiveFixInt Min

		[Test]
		public void PositiveFixIntMinAsByte()
		{
			byte value = MsgPack.Unpack<byte>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMinAsSByte()
		{
			sbyte value = MsgPack.Unpack<sbyte>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMinAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMinAsUShort()
		{
			ushort value = MsgPack.Unpack<ushort>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMinAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMinAsUInt()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMinAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		[Test]
		public void PositiveFixIntMinAsULong()
		{
			ulong value = MsgPack.Unpack<ulong>(ReadFile("Ints/PositiveFixIntMin"));
			Assert.AreEqual(0, value);
		}

		#endregion


		#region PositiveFixInt Max

		[Test]
		public void PositiveFixIntMaxAsByte()
		{
			byte value = MsgPack.Unpack<byte>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void PositiveFixIntMaxAsSByte()
		{
			sbyte value = MsgPack.Unpack<sbyte>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void PositiveFixIntMaxAsShort()
		{
			short value = MsgPack.Unpack<short>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void PositiveFixIntMaxAsUShort()
		{
			ushort value = MsgPack.Unpack<ushort>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void PositiveFixIntMaxAsInt()
		{
			int value = MsgPack.Unpack<int>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void PositiveFixIntMaxAsLong()
		{
			long value = MsgPack.Unpack<long>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		[Test]
		public void PositiveFixIntMaxAsULong()
		{
			ulong value = MsgPack.Unpack<ulong>(ReadFile("Ints/PositiveFixIntMax"));
			Assert.AreEqual(sbyte.MaxValue, value);
		}

		#endregion


		#region UInt8 Min

		[Test]
		public void UInt8MinAsSByte()
		{
			Assert.Throws<OverflowException>(() => {
				MsgPack.Unpack<sbyte>(ReadFile("Ints/UInt8Min"));
			});
		}

		[Test]
		public void UInt8MinAsByte()
		{
			byte value = MsgPack.Unpack<byte>(ReadFile("Ints/UInt8Min"));
			Assert.AreEqual(sbyte.MaxValue + 1, value);
		}

		#endregion



		[Test]
		public void UnpackUInt8Max()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt8Max"));
			Assert.AreEqual(byte.MaxValue, value);
		}

		[Test]
		public void UnpackUInt16Min()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt16Min"));
			Assert.AreEqual(byte.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt16Max()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt16Max"));
			Assert.AreEqual(ushort.MaxValue, value);
		}

		[Test]
		public void UnpackUInt32Min()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt32Max()
		{
			uint value = MsgPack.Unpack<uint>(ReadFile("Ints/UInt32Max"));
			Assert.AreEqual(uint.MaxValue, value);
		}

		[Test]
		public void UnpackUInt64Min()
		{
			ulong value = MsgPack.Unpack<ulong>(ReadFile("Ints/UInt64Min"));
			Assert.AreEqual((ulong)uint.MaxValue + 1, value);
		}

		[Test]
		public void UnpackUInt64Max()
		{
			ulong value = MsgPack.Unpack<ulong>(ReadFile("Ints/UInt64Max"));
			Assert.AreEqual(ulong.MaxValue, value);
		}
	}
}
