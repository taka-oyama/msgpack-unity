using System;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

namespace MessagePack
{
	public class Benchmark : MonoBehaviour
	{
		public Color color = new Color(0.5f, 0.5f, 0.5f);
		public Color32 color32 = new Color(0.5f, 0.5f, 0.5f);

		struct Map
		{
			public int a;
			public int b;
		}

		const int times = 50;
		const int counter = 10000;

		public void Start()
		{
			var time = DateTime.Now;
			double average = 0.0;

			Map[] maps = new Map[counter];
			for(int i = 0; i < counter; i++)
			{
				maps[i] = new Map() { a = UnityEngine.Random.Range(0, 100), b = UnityEngine.Random.Range(0, 100) };
			}

			var bytes = MessagePack.Pack(maps);
			Stream stream = new MemoryStream(bytes);
			MessagePackFormatter formatter = new MessagePackFormatter();
			for(int n = 0; n < times; n++) {
				var s1 = System.Diagnostics.Stopwatch.StartNew();
				stream.Position = 0;
				formatter.Deserialize(typeof(Map[]), stream);
				s1.Stop();
				average += s1.Elapsed.TotalMilliseconds;
			}
			Debug.Log((average / times).ToString("0.00 ms"));
		}
	}
}
