using UnityEngine;
using System;

namespace UniMsgPack
{
	public class Vector2Handler : ITypeHandler
	{
		ITypeHandler floatHandler;

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsArrayFamily) {
				floatHandler = floatHandler ?? TypeHandlers.Get(typeof(byte));
				Vector2 vector = new Vector2();
				vector.x = (float)floatHandler.Read(reader.ReadFormat(), reader);
				vector.y = (float)floatHandler.Read(reader.ReadFormat(), reader);
				return vector;
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			Vector2 vector = (Vector2)obj;
			writer.WriteArrayHeader(2);
			writer.Write(vector.x);
			writer.Write(vector.y);
		}
	}
}
