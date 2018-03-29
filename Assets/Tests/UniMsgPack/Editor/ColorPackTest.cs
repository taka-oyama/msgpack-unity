using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ColorPackTest : TestBase
	{
		[Test]
		public void Pack()
		{
			Color value = new Color(0.25f, 0.5f, 1, 1);
			byte[] data = MsgPack.Pack(value);
			Color result = MsgPack.Unpack<Color>(data);
			Assert.AreEqual(value, result);
		}
	}
}
