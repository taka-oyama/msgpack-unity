using System;
using NUnit.Framework;
using UniMsgPack;
using UnityEngine;

public class FloatTest : TestBase
{
	[Test]
	public void UnpackFloat64Zero()
	{
		byte[] bytes = ReadFile(basePath + "/Floats/Float64Zero.mpack");
		double value = MsgPack.Unpack<double>(bytes);
		Assert.AreEqual(0.0, value);
	}

	[Test]
	public void UnpackFloat64ZeroAsFloat()
	{
		byte[] bytes = ReadFile(basePath + "/Floats/Float64Zero.mpack");
		float value = MsgPack.Unpack<float>(bytes);
		Assert.AreEqual(0f, value);
	}

	[Test]
	public void UnpackFloat64Min()
	{
		byte[] bytes = ReadFile(basePath + "/Floats/Float64Min.mpack");
		double value = MsgPack.Unpack<double>(bytes);
		Assert.AreEqual(double.MinValue, value);
	}

	[Test]
	public void UnpackFloat64MinAsFloat()
	{
		Assert.Throws<InvalidCastException>(() => {
			byte[] bytes = ReadFile(basePath + "/Floats/Float64Min.mpack");
			MsgPack.Unpack<float>(bytes);
		});
	}

	[Test]
	public void UnpackFloat64Max()
	{
		byte[] bytes = ReadFile(basePath + "/Floats/Float64Max.mpack");
		double value = MsgPack.Unpack<double>(bytes);
		Assert.AreEqual(double.MaxValue, value);
	}

	[Test]
	public void UnpackFloat64MaxAsFloat()
	{
		Assert.Throws<InvalidCastException>(() => {
			byte[] bytes = ReadFile(basePath + "/Floats/Float64Max.mpack");
			MsgPack.Unpack<float>(bytes);
		});
	}
}
