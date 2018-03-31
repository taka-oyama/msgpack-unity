using UnityEngine;
using System;

namespace UniMsgPack
{
	public class Vector3Handler : ITypeHandler
	{
		ITypeHandler floatHandler;

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsArrayFamily) {
				floatHandler = floatHandler ?? TypeHandlers.Get(typeof(float));
				Vector3 vector = new Vector3();
				vector.x = (float)floatHandler.Read(reader.ReadFormat(), reader);
				vector.y = (float)floatHandler.Read(reader.ReadFormat(), reader);
				vector.z = (float)floatHandler.Read(reader.ReadFormat(), reader);
				return vector;
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			Vector3 vector = (Vector3)obj;
			writer.WriteArrayHeader(3);
			writer.Write(vector.x);
			writer.Write(vector.y);
			writer.Write(vector.z);
		}
	}
}
