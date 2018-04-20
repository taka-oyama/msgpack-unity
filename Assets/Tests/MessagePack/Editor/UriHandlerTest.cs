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
			byte[] data = Pack<Uri>(value);
			Uri result = Unpack<Uri>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void PackNil()
		{
			Uri value = null;
			byte[] data = Pack<Uri>(value);
			Uri result = Unpack<Uri>(data);
			Assert.AreEqual(null, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackUriString()
		{
			Uri value = Unpack<Uri>(ReadFile("Strings/Uri"));
			Uri expected = new Uri("https://github.com/msgpack/msgpack/blob/master/spec.md#type-system");
			Assert.AreEqual(expected, value);
		}

		[Test]
		public void UnpackNil()
		{
			Uri value = Unpack<Uri>(ReadFile("Strings/Nil"));
			Assert.AreEqual(null, value);
		}

		[Test]
		public void UnpackEmptyString()
		{
			Assert.Throws<UriFormatException>(() => Unpack<Uri>(ReadFile("Strings/FixStrMin")));
		}

		#endregion
	}
}
