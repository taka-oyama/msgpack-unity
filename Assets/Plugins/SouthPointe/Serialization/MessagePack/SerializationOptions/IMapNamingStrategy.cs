using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public interface IMapNamingStrategy
	{
		string OnPack(string name);
		string OnUnpack(string name);
	}
}
