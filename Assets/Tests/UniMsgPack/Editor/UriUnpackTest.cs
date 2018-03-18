using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class UriUnpackTest : TestBase
	{
		[Test]
		public void UriString()
		{
			Uri value = MsgPack.Unpack<Uri>(ReadFile("Strings/Uri"));
			Uri expected = new Uri("https://github.com/msgpack/msgpack/blob/master/spec.md#type-system");
			Assert.AreEqual(expected, value);
		}

		[Test]
		public void Nil()
		{
			Uri value = MsgPack.Unpack<Uri>(ReadFile("Strings/Nil"));
			Assert.AreEqual(null, value);
		}

		[Test]
		public void EmptyString()
		{
			Assert.Throws<UriFormatException>(() => MsgPack.Unpack<Uri>(ReadFile("Strings/FixStrMin")));
		}
	}
}
