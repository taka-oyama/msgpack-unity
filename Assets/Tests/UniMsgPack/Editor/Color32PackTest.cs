using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class Color32PackTest : TestBase
	{
		[Test]
		public void Pack()
		{
			Color32 value = new Color32(0, 50, 100, 255);
			byte[] data = MsgPack.Pack(value);
			Color32 result = MsgPack.Unpack<Color32>(data);
			Assert.AreEqual(value, result);
		}
	}
}
