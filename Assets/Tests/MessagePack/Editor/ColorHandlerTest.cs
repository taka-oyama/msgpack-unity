using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class ColorHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void Pack()
		{
			Color value = new Color(0.25f, 0.5f, 1, 1);
			byte[] data = MessagePack.Pack(value);
			Color result = MessagePack.Unpack<Color>(data);
			Assert.AreEqual(value, result);
		}
		#endregion


		#region Unpack

		[Test]
		public void UnpackAsBinary()
		{
			Color value = new Color(0f, 0.51f, 0.51f, 1f);
			byte[] data = MessagePack.Pack(value);
			Color result = MessagePack.Unpack<Color>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UnpackAsArray()
		{
			Color value = new Color(0f, 0.51f, 0.51f, 1f);
			byte[] data = MessagePack.Pack(value);
			Color result = MessagePack.Unpack<Color>(data);
			Assert.AreEqual(new Color(0f, 0.51f, 0.51f, 1f), result);
		}

		[Test]
		public void UnpackAsString()
		{
			string value = "#008282ff";
			byte[] data = MessagePack.Pack(value);
			Color result = MessagePack.Unpack<Color>(data);
			Assert.AreEqual(new Color(0f, 0.51f, 0.51f, 1f).ToString(), result.ToString());
		}

		[Test]
		public void UnpackAsMap()
		{
			Dictionary<string, float> value = new Dictionary<string, float>();
			value.Add("r", 0f);
			value.Add("g", 0.51f);
			value.Add("b", 0.51f);
			value.Add("a", 1f);
			byte[] data = MessagePack.Pack(value);
			Color result = MessagePack.Unpack<Color>(data);
			Assert.AreEqual(new Color(0f, 0.51f, 0.51f, 1f), result);
		}

		#endregion
	}
}
