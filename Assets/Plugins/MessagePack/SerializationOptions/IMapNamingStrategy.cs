using UnityEngine;

namespace MessagePack
{
	public interface IMapNamingStrategy
	{
		string OnPack(string name);
		string OnUnpack(string name);
	}
}
