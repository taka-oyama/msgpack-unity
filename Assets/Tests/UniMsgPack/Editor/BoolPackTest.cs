using UnityEngine;
using NUnit.Framework;

namespace UniMsgPack.Tests
{
	public class BoolPackTest : TestBase
	{
		[Test]
		public void True()
		{
			byte[] data = MsgPack.Pack(true);
			Assert.AreEqual(Format.True, data[0]);
		}

		[Test]
		public void False()
		{
			byte[] data = MsgPack.Pack(false);
			Assert.AreEqual(Format.False, data[0]);
		}
	}
}
