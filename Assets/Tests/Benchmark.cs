using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public class Benchmark : MonoBehaviour
	{
		public Color color = new Color(0.5f, 0.5f, 0.5f);
		public Color32 color32 = new Color(0.5f, 0.5f, 0.5f);

		class Map
		{
			public int a;
			public Vector2[] v2s;
		}

		const int times = 50;
		const int counter = 10000;

		public void Start()
		{
			var vector2s = new Vector2[] {
				Vector2.one,
				Vector2.zero,
			};
			var maps = new Map[] {
				new Map() { v2s = vector2s },
				new Map() { v2s = vector2s },
			};
			var formatter = new MessagePackFormatter();
			SerializationContext.Default.jsonOptions.prettyPrint = true;
			var data = formatter.Serialize(maps);
			var json = formatter.AsJson(data);

			Debug.Log(json);
		}
	}
}
