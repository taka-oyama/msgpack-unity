using System;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class DateTimePackTest : TestBase
	{
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

		[Test]
		public void CheckTicks()
		{
			DateTime value = DateTime.Parse("2018-01-01 12:00:00.7654321+09:00").ToLocalTime();
			byte[] data = MsgPack.Pack(value);
			DateTime result = MsgPack.Unpack<DateTime>(data);
			Assert.AreEqual(value, result);
		}
	}
}
