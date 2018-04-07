using System.Reflection;
using UnityEngine;

namespace MessagePack
{
	public class DefaultMapNameConverter : IMapNameConverter
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
