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
		int[] ints = MsgPack.Unpack<int[]>(bytes);

		Assert.AreEqual(ints.Length, 15);
		foreach(int i in ints) {
			Assert.AreEqual(i, ints[i]);
		}
	}

	[Test]
	public void UnpackArray16Min()
	{
		byte[] bytes = ReadFile(basePath + "/Arrays/Array16Min.mpack");
		int[] ints = MsgPack.Unpack<int[]>(bytes);

		Assert.AreEqual(ints.Length, 16);
		foreach(int i in ints) {
			Assert.AreEqual(i, ints[i]);
		}
	}
}
