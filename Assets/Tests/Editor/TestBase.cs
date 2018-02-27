using System.IO;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public abstract class TestBase
	{
		protected string basePath = Application.dataPath + "/Tests/Files";

		public byte[] ReadFile(string path)
		{
			return File.ReadAllBytes(basePath + "/" + path + ".mpack");
		}
	}
}
