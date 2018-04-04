using System.Reflection;

namespace UniMsgPack
{
	public class MapOptions
	{
		public bool ignoreNullOnPack = true;

		public IMapNameConverter nameConverter = new DefaultMapNameConverter();

		public BindingFlags fieldFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField;
	}
}
