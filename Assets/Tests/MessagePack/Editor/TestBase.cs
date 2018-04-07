using System.IO;
using UnityEngine;

namespace MessagePack.Tests
{
	public abstract class TestBase
	{
		protected string basePath = Application.dataPath + "/Tests/MessagePack/Files";

		public byte[] ReadFile(string path)
		{
			return File.ReadAllBytes(basePath + "/" + path + ".mpack");
		}

		public void WriteFile(string path, byte[] bytes)
		{
			File.WriteAllBytes(basePath + "/" + path + ".mpack", bytes);
		}
	}
}
