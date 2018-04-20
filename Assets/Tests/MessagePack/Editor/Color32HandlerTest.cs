using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class Color32HandlerTest : TestBase
	{
		#region Pack
		[Test]
		public void Pack()
		{
			Color32 value = new Color32(0, 50, 100, 255);
			byte[] data = Pack(value);
			Color32 result = Unpack<Color32>(data);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackAsBinary()
		{
			Color32 value = new Color32(100, 100, 100, 255);
			byte[] data = Pack(value);
			Color32 result = Unpack<Color32>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void UnpackAsArray()
		{
			int[] value = { 100, 100, 100, 255 };
			byte[] data = Pack(value);
			Color32 result = Unpack<Color32>(data);
			Assert.AreEqual(new Color32(100, 100, 100, 255), result);
		}

		[Test]
		public void UnpackAsString()
		{
			string value = "#646464ff";
			byte[] data = Pack(value);
			Color32 result = Unpack<Color32>(data);
			Assert.AreEqual(new Color32(100, 100, 100, 255), result);
		}

		[Test]
		public void UnpackAsMap()
		{
			Dictionary<string, byte> value = new Dictionary<string, byte>();
			value.Add("r", 100);
			value.Add("g", 100);
			value.Add("b", 100);
			value.Add("a", 255);
			byte[] data = Pack(value);
			Color32 result = Unpack<Color32>(data);
			Assert.AreEqual(new Color32(100, 100, 100, 255), result);
		}

		#endregion
	}
}
