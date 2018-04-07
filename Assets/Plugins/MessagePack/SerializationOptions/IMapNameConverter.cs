using UnityEngine;

namespace MessagePack
{
	public interface IMapNameConverter
	{
		string OnPack(string name);
		string OnUnpack(string name);
	}
}
