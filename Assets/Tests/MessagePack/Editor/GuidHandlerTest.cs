using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class GuidHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void Pack()
		{
			var value = Guid.NewGuid();
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<Guid>(data);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackAsString()
		{
			var value = Guid.NewGuid().ToString();
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<Guid>(data);
			Assert.AreEqual(value, result.ToString());
		}

		#endregion
	}
}
