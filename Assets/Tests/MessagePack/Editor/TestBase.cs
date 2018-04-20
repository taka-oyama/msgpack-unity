using System.IO;
using UnityEngine;

namespace MessagePack.Tests
{
	public abstract class TestBase
	{
		protected string basePath = Application.dataPath + "/Tests/MessagePack/Files";

		public byte[] Pack<T>(T obj, SerializationContext context = null)
		{
			return new MessagePackFormatter(context).Serialize(obj);
		}

		public T Unpack<T>(byte[] bytes, SerializationContext context = null)
		{
			return new MessagePackFormatter(context).Deserialize<T>(bytes);
		}

		public string AsJson(byte[] bytes, SerializationContext context = null)
		{
			return new MessagePackFormatter(context).AsJson(bytes);
		}

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
