using System.Reflection;

namespace SouthPointe.Serialization.MessagePack
{
	public class MapOptions
	{
		public bool ignoreNullOnPack = true;

		public bool ignoreMissingFieldOnUnpack = true;

		public IMapNamingStrategy namingStrategy = new DefaultNamingStrategy();

		public BindingFlags fieldFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField;
	}
}
