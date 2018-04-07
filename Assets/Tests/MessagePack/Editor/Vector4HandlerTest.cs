using System;
using NUnit.Framework;
using UnityEngine;

namespace MessagePack.Tests
{
	public class Vector4HandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void Pack()
		{
			var value = new Vector4(1f, 2f, 3f, 4f);
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<Vector4>(data);
			Assert.AreEqual(Format.FixArrayMin + 4, data[0]);
			Assert.AreEqual(Format.Float32, data[1]);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void Unpack()
		{
			var value = new Vector4(1f, 2f, 3f, 4f);
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<Vector4>(data);
			Assert.AreEqual(result, value);
		}

		[Test]
		public void UnpackAsFloats()
		{
			var value = new float[] { 1f, 2f, 3f, 4f };
			byte[] data = MessagePack.Pack(value);
			var result = MessagePack.Unpack<Vector4>(data);
			Assert.AreEqual(result.x, value[0]);
			Assert.AreEqual(result.y, value[1]);
			Assert.AreEqual(result.z, value[2]);
			Assert.AreEqual(result.w, value[3]);
		}

		#endregion
	}
}
