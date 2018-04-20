using System.Security.Cryptography;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class ByteArrayHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackNil()
		{
			byte[] value = null;
			byte[] data = Pack<byte[]>(value);
			byte[] result = Unpack<byte[]>(data);
			Assert.AreEqual(Format.Nil, data[0]);
			Assert.AreEqual(0, result.Length);
		}

		[Test]
		public void PackBin8Min()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[1];
			rand.GetBytes(value);
			byte[] data = Pack<byte[]>(value);
			byte[] result = Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin8, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackBin8Max()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[byte.MaxValue];
			rand.GetBytes(value);
			byte[] data = Pack<byte[]>(value);
			byte[] result = Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin8, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackBin16Min()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[byte.MaxValue + 1];
			rand.GetBytes(value);
			byte[] data = Pack<byte[]>(value);
			byte[] result = Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin16, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackBin16Max()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[ushort.MaxValue];
			rand.GetBytes(value);
			byte[] data = Pack<byte[]>(value);
			byte[] result = Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin16, data[0]);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackBin32Min()
		{
			RandomNumberGenerator rand = RandomNumberGenerator.Create();
			byte[] value = new byte[ushort.MaxValue + 1];
			rand.GetBytes(value);
			byte[] data = Pack<byte[]>(value);
			byte[] result = Unpack<byte[]>(data);
			Assert.AreEqual(Format.Bin32, data[0]);
			Assert.AreEqual(value, result);
		}

		public void PackBin32Max()
		{
			// bytes too big
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackNil()
		{
			byte[] result = Unpack<byte[]>(ReadFile("Nullables/Nil"));
			Assert.AreEqual(0, result.Length);
		}

		[Test]
		public void UnpackBin8Min()
		{
			byte[] result = Unpack<byte[]>(ReadFile("Binaries/Bin8Min"));
			Assert.AreEqual(1, result.Length);
		}

		[Test]
		public void UnpackBin8Max()
		{
			byte[] result = Unpack<byte[]>(ReadFile("Binaries/Bin8Max"));
			Assert.AreEqual(byte.MaxValue, result.Length);
		}

		[Test]
		public void UnpackBin16Min()
		{
			byte[] result = Unpack<byte[]>(ReadFile("Binaries/Bin16Min"));
			Assert.AreEqual(byte.MaxValue + 1, result.Length);
		}

		[Test]
		public void UnpackBin16Max()
		{
			byte[] result = Unpack<byte[]>(ReadFile("Binaries/Bin16Max"));
			Assert.AreEqual(ushort.MaxValue, result.Length);
		}

		[Test]
		public void UnpackBin32Min()
		{
			byte[] result = Unpack<byte[]>(ReadFile("Binaries/Bin32Min"));
			Assert.AreEqual(ushort.MaxValue + 1, result.Length);
		}

		public void UnpackBin32Max()
		{
			// bytes too big
		}

		#endregion
	}
}
