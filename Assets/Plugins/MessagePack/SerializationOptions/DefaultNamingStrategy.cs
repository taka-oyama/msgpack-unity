using System.Reflection;
using UnityEngine;

namespace MessagePack
{
	public class DefaultNamingStrategy : IMapNamingStrategy
	{
		public string OnPack(string name)
		{
			return name;
		}

		public string OnUnpack(string name)
		{
			return name;
		}
	}
}
