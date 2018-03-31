using UnityEngine;
using System;

namespace UniMsgPack
{
	public class Vector3IntHandler : ITypeHandler
	{
		ITypeHandler intHandler;

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsArrayFamily) {
				intHandler = intHandler ?? TypeHandlers.Get(typeof(int));
				Vector3Int vector = new Vector3Int();
				vector.x = (int)intHandler.Read(reader.ReadFormat(), reader);
				vector.y = (int)intHandler.Read(reader.ReadFormat(), reader);
				vector.z = (int)intHandler.Read(reader.ReadFormat(), reader);
				return vector;
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			Vector3Int vector = (Vector3Int)obj;
			writer.WriteArrayHeader(2);
			writer.Write(vector.x);
			writer.Write(vector.y);
			writer.Write(vector.z);
		}
	}
}
