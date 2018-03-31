using UnityEngine;
using NUnit.Framework;
using System;

namespace UniMsgPack.Tests
{
	public class TimeSpanHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void Pack()
		{
			var value = new TimeSpan(0, 0, 0, 0, 100);
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<TimeSpan>(data);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void Unpack()
		{
			var value = new TimeSpan(100, 100, 100, 100, 100);
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<TimeSpan>(data);
			Assert.AreEqual(result, value);
		}

		#endregion
	}
}
