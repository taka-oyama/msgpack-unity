using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class UriPackTest : TestBase
	{
		[Test]
		public void UriString()
		{
			Uri value = new Uri("https://github.com/msgpack/msgpack/blob/master/spec.md#type-system");
			byte[] data = MsgPack.Pack<Uri>(value);
			Uri result = MsgPack.Unpack<Uri>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void Nil()
		{
			Uri value = null;
			byte[] data = MsgPack.Pack<Uri>(value);
			Uri result = MsgPack.Unpack<Uri>(data);
			Assert.AreEqual(null, result);
		}
	}
}
