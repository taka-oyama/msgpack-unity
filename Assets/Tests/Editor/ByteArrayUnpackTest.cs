using System.Security.Cryptography;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ByteArrayUnpackTest : TestBase
	{
		[Test]
		public void Nil()
		{
			byte[] result = MsgPack.Unpack<byte[]>(ReadFile("Nullables/Nil"));
			Assert.AreEqual(0, result.Length);
		}

		[Test]
		public void Bin8Min()
		{
			byte[] result = MsgPack.Unpack<byte[]>(ReadFile("Binaries/Bin8Min"));
			Assert.AreEqual(1, result.Length);
		}

		[Test]
		public void Bin8Max()
		{
			byte[] result = MsgPack.Unpack<byte[]>(ReadFile("Binaries/Bin8Max"));
			Assert.AreEqual(byte.MaxValue, result.Length);
		}

		[Test]
		public void Bin16Min()
		{
			byte[] result = MsgPack.Unpack<byte[]>(ReadFile("Binaries/Bin16Min"));
			Assert.AreEqual(byte.MaxValue + 1, result.Length);
		}

		[Test]
		public void Bin16Max()
		{
			byte[] result = MsgPack.Unpack<byte[]>(ReadFile("Binaries/Bin16Max"));
			Assert.AreEqual(ushort.MaxValue, result.Length);
		}

		[Test]
		public void Bin32Min()
		{
			byte[] result = MsgPack.Unpack<byte[]>(ReadFile("Binaries/Bin32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, result.Length);
		}

		public void Bin32Max()
		{
			// bytes too big
		}
	}
}
