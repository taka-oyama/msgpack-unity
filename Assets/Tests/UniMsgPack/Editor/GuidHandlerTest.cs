using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class GuidHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void Pack()
		{
			var value = Guid.NewGuid();
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<Guid>(data);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackAsString()
		{
			var value = Guid.NewGuid().ToString();
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<Guid>(data);
			Assert.AreEqual(value, result.ToString());
		}

		#endregion
	}
}
