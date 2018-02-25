﻿using NUnit.Framework;
using UniMsgPack;
using UnityEngine;

public class BoolTest : TestBase
{
	[Test]
	public void UnpackTrue()
	{
		byte[] bytes = ReadFile(basePath + "/Bools/True.mpack");
		bool boolValue = MsgPack.Unpack<bool>(bytes);
		Assert.IsTrue(boolValue);
	}

	[Test]
	public void UnpackFalse()
	{
		byte[] bytes = ReadFile(basePath + "/Bools/False.mpack");
		bool boolValue = MsgPack.Unpack<bool>(bytes);
		Assert.IsFalse(boolValue);
	}
}