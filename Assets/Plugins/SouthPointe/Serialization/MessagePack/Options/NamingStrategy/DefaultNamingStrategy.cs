using System.Reflection;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public class DefaultNamingStrategy : IMapNamingStrategy
	{
		public string OnPack(string name, MapDefinition definition)
		{
			return name;
		}

		public string OnUnpack(string name, MapDefinition definition)
		{
			return name;
		}
	}
}
