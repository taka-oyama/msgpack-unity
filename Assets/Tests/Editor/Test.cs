using UnityEngine;
using UniMsgPack;
using NUnit.Framework;
using System.IO;

public class Test
{
	static string basePath;

	static Test()
	{
		basePath = Application.dataPath + "/Tests/Files";
	}

	public static byte[] ReadFile(string path)
	{
		return File.ReadAllBytes(path);
	}

	[Test]
	public void UnpackFixArrayMin()
	{
		byte[] bytes = ReadFile(basePath + "/Arrays/FixArrayMin.mpack");
		int[] test = MsgPack.Unpack<int[]>(bytes);

		Assert.AreEqual(test.Length, 0);
	}

	[Test]
	public void UnpackFixArrayMax()
	{
		byte[] bytes = ReadFile(basePath + "/Arrays/FixArrayMax.mpack");
		int[] test = MsgPack.Unpack<int[]>(bytes);

		Assert.AreEqual(test.Length, 15);
	}
}
