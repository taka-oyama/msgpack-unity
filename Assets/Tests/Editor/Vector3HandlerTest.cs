﻿using System;
using NUnit.Framework;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class Vector3HandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void Pack()
		{
			var value = new Vector3(1f, 2f, 3f);
			byte[] data = Pack(value);
			var result = Unpack<Vector3>(data);
			Assert.AreEqual(Format.FixArrayMin + 3, data[0]);
			Assert.AreEqual(Format.Float32, data[1]);
			Assert.AreEqual(value, result);
		}

		#endregion


		#region Unpack

		[Test]
		public void Unpack()
		{
			var value = new Vector3(1f, 2f, 3f);
			byte[] data = Pack(value);
			var result = Unpack<Vector3>(data);
			Assert.AreEqual(result, value);
		}

		[Test]
		public void UnpackAsFloats()
		{
			var value = new float[] { 1f, 2f, 3f };
			byte[] data = Pack(value);
			var result = Unpack<Vector3>(data);
			Assert.AreEqual(result.x, value[0]);
			Assert.AreEqual(result.y, value[1]);
		}

		#endregion
	}
}