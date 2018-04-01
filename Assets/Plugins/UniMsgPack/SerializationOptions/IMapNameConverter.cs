using UnityEngine;

namespace UniMsgPack
{
	public interface IMapNameConverter
	{
		string OnPack(string name);
		string OnUnpack(string name);
	}
}
