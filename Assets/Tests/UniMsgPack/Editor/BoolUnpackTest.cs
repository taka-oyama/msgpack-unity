using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class BoolUnpackTest : TestBase
	{
		[Test]
		public void True()
		{
			bool boolValue = MsgPack.Unpack<bool>(ReadFile("Bools/True"));
			Assert.IsTrue(boolValue);
		}

		[Test]
		public void False()
		{
			bool boolValue = MsgPack.Unpack<bool>(ReadFile("Bools/False"));
			Assert.IsFalse(boolValue);
		}
	}
}
