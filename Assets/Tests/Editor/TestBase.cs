using System.IO;
using UnityEngine;

public abstract class TestBase
{
	protected string basePath = Application.dataPath + "/Tests/Files";

	public static byte[] ReadFile(string path)
	{
		return File.ReadAllBytes(path);
	}
}
