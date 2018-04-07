using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class UriHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackUriString()
		{
			Uri value = new Uri("https://github.com/msgpack/msgpack/blob/master/spec.md#type-system");
			byte[] data = MessagePack.Pack<Uri>(value);
			Uri result = MessagePack.Unpack<Uri>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNil()
		{
			Uri value = null;
			byte[] data = MessagePack.Pack<Uri>(value);
			Uri result = MessagePack.Unpack<Uri>(data);
			Assert.AreEqual(null, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackUriString()
		{
			Uri value = MessagePack.Unpack<Uri>(ReadFile("Strings/Uri"));
			Uri expected = new Uri("https://github.com/msgpack/msgpack/blob/master/spec.md#type-system");
			Assert.AreEqual(expected, value);
		}

		[Test]
		public void UnpackNil()
		{
			Uri value = MessagePack.Unpack<Uri>(ReadFile("Strings/Nil"));
			Assert.AreEqual(null, value);
		}

		[Test]
		public void UnpackEmptyString()
		{
			Assert.Throws<UriFormatException>(() => MessagePack.Unpack<Uri>(ReadFile("Strings/FixStrMin")));
		}

		#endregion
	}
}
