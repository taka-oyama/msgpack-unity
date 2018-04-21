using UnityEngine;
using NUnit.Framework;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class BoolHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackTrue()
		{
			byte[] data = Pack(true);
			Assert.AreEqual(Format.True, data[0]);
		}

		[Test]
		public void PackFalse()
		{
			byte[] data = Pack(false);
			Assert.AreEqual(Format.False, data[0]);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackTrue()
		{
			bool boolValue = Unpack<bool>(ReadFile("Bools/True"));
			Assert.IsTrue(boolValue);
		}

		[Test]
		public void UnpackFalse()
		{
			bool boolValue = Unpack<bool>(ReadFile("Bools/False"));
			Assert.IsFalse(boolValue);
		}

		#endregion
	}
}
