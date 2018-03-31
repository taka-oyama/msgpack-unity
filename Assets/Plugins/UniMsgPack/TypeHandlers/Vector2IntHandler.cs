using UnityEngine;
using System;

namespace UniMsgPack
{
	public class Vector2IntHandler : ITypeHandler
	{
		ITypeHandler intHandler;

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsArrayFamily) {
				intHandler = intHandler ?? TypeHandlers.Get(typeof(int));
				Vector2Int vector = new Vector2Int();
				vector.x = (int)intHandler.Read(reader.ReadFormat(), reader);
				vector.y = (int)intHandler.Read(reader.ReadFormat(), reader);
				return vector;
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			Vector2Int vector = (Vector2Int)obj;
			writer.WriteArrayHeader(2);
			writer.Write(vector.x);
			writer.Write(vector.y);
		}
	}
}
