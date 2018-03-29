using UnityEngine;
using NUnit.Framework;

namespace UniMsgPack.Tests
{
	public class BoolHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackTrue()
		{
			byte[] data = MsgPack.Pack(true);
			Assert.AreEqual(Format.True, data[0]);
		}

		[Test]
		public void PackFalse()
		{
			byte[] data = MsgPack.Pack(false);
			Assert.AreEqual(Format.False, data[0]);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackTrue()
		{
			bool boolValue = MsgPack.Unpack<bool>(ReadFile("Bools/True"));
			Assert.IsTrue(boolValue);
		}

		[Test]
		public void UnpackFalse()
		{
			bool boolValue = MsgPack.Unpack<bool>(ReadFile("Bools/False"));
			Assert.IsFalse(boolValue);
		}

		#endregion
	}
}
