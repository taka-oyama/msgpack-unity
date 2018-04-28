using System.Reflection;

namespace SouthPointe.Serialization.MessagePack
{
	public class MapOptions
	{
		public bool IgnoreNullOnPack = true;

		public bool IgnoreUnknownFieldOnUnpack = true;

		/// <summary>
		/// This is for compatibility with msgpack-php
		/// since php cannot distinguish between ordered array and hashed array.
		/// </summary>
		public bool AllowEmptyArrayOnUnpack = true;

		public IMapNamingStrategy NamingStrategy = new DefaultNamingStrategy();

		public BindingFlags FieldFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField;
	}
}
