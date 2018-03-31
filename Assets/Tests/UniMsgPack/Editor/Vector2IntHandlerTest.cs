using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class Vector2IntHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void Pack()
		{
			var value = new Vector2Int(1, 2);
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<Vector2Int>(data);
			Assert.AreEqual(Format.FixArrayMin + 2, data[0]);
			Assert.AreEqual(Format.PositiveFixIntMin + 1, data[1]);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void Unpack()
		{
			var value = new Vector2Int(1, 2);
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<Vector2Int>(data);
			Assert.AreEqual(result, value);
		}

		[Test]
		public void UnpackAsFloats()
		{
			var value = new int[] { 1, 2 };
			byte[] data = MsgPack.Pack(value);
			var result = MsgPack.Unpack<Vector2Int>(data);
			Assert.AreEqual(result.x, value[0]);
			Assert.AreEqual(result.y, value[1]);
		}

		#endregion
	}
}
