using NUnit.Framework;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class FormatterTest : TestBase
	{
		[Test]
		public void UnpackWithNull()
		{
			object value = Unpack<object>(null);
			Assert.AreEqual(null, value);
		}

		[Test]
		public void AsJsonWithNull()
		{
			object value = AsJson(null);
			Assert.AreEqual(null, value);
		}
	}
}
