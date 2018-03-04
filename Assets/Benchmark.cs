using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class Benchmark : MonoBehaviour
	{
		struct Map
		{
			public int a;
			public int b;
		}

		const int times = 5;
		const int counter = 100000;

		public void Start()
		{
			double average = 0.0;
			byte[] bytes = File.ReadAllBytes(Application.dataPath + "/Tests/Files/Arrays/Maps.mpack");
			MsgPackReader reader = new MsgPackReader(new MemoryStream(bytes));
			for(int n = 0; n < times; n++) {
				var s1 = Stopwatch.StartNew();
				for(int i = 0; i < counter; i++) {
					reader.stream.Position = 0;
					reader.Read<Map[]>();
				}
				s1.Stop();
				average += s1.Elapsed.TotalMilliseconds;
			}
			UnityEngine.Debug.Log((average / times).ToString("0.00 ms"));
		}
	}
}
