using System.Reflection;

namespace UniMsgPack
{
	public class MapOptions
	{
		public bool ignoreNullOnPack;

		public IMapNameConverter nameConverter;

		public BindingFlags fieldFlags;

		public MapOptions()
		{
			ignoreNullOnPack = true;
			nameConverter = new DefaultMapNameConverter();
			fieldFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField;
		}
	}
}