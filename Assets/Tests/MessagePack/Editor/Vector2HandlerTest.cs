using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class Vector2HandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void Pack()
		{
			var value = new Vector2(1f, 2f);
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<Vector2>(data);
			Assert.AreEqual(Format.FixArrayMin + 2, data[0]);
			Assert.AreEqual(Format.Float32, data[1]);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void Unpack()
		{
			var value = new Vector2(1f, 2f);
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<Vector2>(data);
			Assert.AreEqual(result, value);
		}

		[Test]
		public void UnpackAsFloats()
		{
			var value = new float[] { 1f, 2f };
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<Vector2>(data);
			Assert.AreEqual(result.x, value[0]);
			Assert.AreEqual(result.y, value[1]);
		}

		#endregion
	}
}
