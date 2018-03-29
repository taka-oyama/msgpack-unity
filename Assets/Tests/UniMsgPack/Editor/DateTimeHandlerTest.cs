using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class DateTimeHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackAsExt8()
		{
			DateTime value = DateTime.Parse("2018-01-01 12:00:00+09:00").ToLocalTime();
			byte[] data = MsgPack.Pack(value);
			Assert.AreEqual(Format.Ext8, data[0]);
			Assert.AreEqual(12, data[1]);
			Assert.AreEqual(-1, (sbyte)data[2]);
			Assert.AreEqual(15, data.Length);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackAsExt8()
		{
			byte[] data = ReadFile("Timestamps/Timestamp96");
			DateTime result = MsgPack.Unpack<DateTime>(data);
			Assert.AreEqual("2018-01-01T12:00:00.0000000+09:00", result.ToString("o"));
		}

		[Test]
		public void UnpackFromString()
		{
			byte[] data = ReadFile("Timestamps/String");
			DateTime result = MsgPack.Unpack<DateTime>(data);
			Assert.AreEqual("2018-01-01T12:00:00.0000000+09:00", result.ToString("o"));
		}

		[Test]
		public void UnpackFromInt()
		{
			byte[] data = ReadFile("Timestamps/Int");
			DateTime result = MsgPack.Unpack<DateTime>(data);
			Assert.AreEqual("2018-01-01T12:00:00.0000000+09:00", result.ToString("o"));
		}

		#endregion


		#region Validation

		[Test]
		public void CheckTicks()
		{
			DateTime value = DateTime.Parse("2018-01-01 12:00:00.7654321+09:00").ToLocalTime();
			byte[] data = MsgPack.Pack(value);
			DateTime result = MsgPack.Unpack<DateTime>(data);
			Assert.AreEqual(value, result);
		}

		#endregion
	}
}
