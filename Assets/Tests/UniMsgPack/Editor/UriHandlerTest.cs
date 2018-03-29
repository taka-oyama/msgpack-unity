using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class UriHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackUriString()
		{
			Uri value = new Uri("https://github.com/msgpack/msgpack/blob/master/spec.md#type-system");
			byte[] data = MsgPack.Pack<Uri>(value);
			Uri result = MsgPack.Unpack<Uri>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNil()
		{
			Uri value = null;
			byte[] data = MsgPack.Pack<Uri>(value);
			Uri result = MsgPack.Unpack<Uri>(data);
			Assert.AreEqual(null, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackUriString()
		{
			Uri value = MsgPack.Unpack<Uri>(ReadFile("Strings/Uri"));
			Uri expected = new Uri("https://github.com/msgpack/msgpack/blob/master/spec.md#type-system");
			Assert.AreEqual(expected, value);
		}

		[Test]
		public void UnpackNil()
		{
			Uri value = MsgPack.Unpack<Uri>(ReadFile("Strings/Nil"));
			Assert.AreEqual(null, value);
		}

		[Test]
		public void UnpackEmptyString()
		{
			Assert.Throws<UriFormatException>(() => MsgPack.Unpack<Uri>(ReadFile("Strings/FixStrMin")));
		}

		#endregion
	}
}
