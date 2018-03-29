using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class ColorUnpackTest : TestBase
	{
		[Test]
		public void AsBinary()
		{
			Color value = new Color(0f, 0.51f, 0.51f, 1f);
			byte[] data = MsgPack.Pack(value);
			Color result = MsgPack.Unpack<Color>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void AsArray()
		{
			Color value = new Color(0.51f, 0.51f, 0.51f, 1f);
			byte[] data = MsgPack.Pack(value);
			Color result = MsgPack.Unpack<Color>(data);
			Assert.AreEqual(new Color(0f, 0.51f, 0.51f, 1f), result);
		}

		[Test]
		public void AsString()
		{
			string value = "#008282ff";
			byte[] data = MsgPack.Pack(value);
			Color result = MsgPack.Unpack<Color>(data);
			Assert.AreEqual(new Color(0f, 0.51f, 0.51f, 1f).ToString(), result.ToString());
		}

		[Test]
		public void AsMap()
		{
			Dictionary<string, float> value = new Dictionary<string, float>();
			value.Add("r", 0f);
			value.Add("g", 0.51f);
			value.Add("b", 0.51f);
			value.Add("a", 1f);
			byte[] data = MsgPack.Pack(value);
			Color result = MsgPack.Unpack<Color>(data);
			Assert.AreEqual(new Color(0f, 0.51f, 0.51f, 1f), result);
		}
	}
}
