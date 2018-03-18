using System.Security.Cryptography;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ByteArrayPackTest : TestBase
	{
		[Test]
		public void Nil()
		{
			byte[] value = null;
			byte[] data = MsgPack.Pack<byte[]>(value);
			byte[] result = MsgPack.Unpack<byte[]>(data);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(0, result.Length);
		}

		[Test]
		public void Bin8Min()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[1];
			rand.GetBytes(value);
			byte[] data = MsgPack.Pack<byte[]>(value);
			byte[] result = MsgPack.Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin8, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Bin8Max()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[byte.MaxValue];
			rand.GetBytes(value);
			byte[] data = MsgPack.Pack<byte[]>(value);
			byte[] result = MsgPack.Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin8, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Bin16Min()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[byte.MaxValue + 1];
			rand.GetBytes(value);
			byte[] data = MsgPack.Pack<byte[]>(value);
			byte[] result = MsgPack.Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin16, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Bin16Max()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[ushort.MaxValue];
			rand.GetBytes(value);
			byte[] data = MsgPack.Pack<byte[]>(value);
			byte[] result = MsgPack.Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin16, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Bin32Min()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[ushort.MaxValue + 1];
			rand.GetBytes(value);
			byte[] data = MsgPack.Pack<byte[]>(value);
			byte[] result = MsgPack.Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin32, data[0]);
			Assert.AreEqual(value, result);
		}

		public void Bin32Max()
		{
			// bytes too big
		}
	}
}
