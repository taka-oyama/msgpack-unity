using UnityEngine;
using System;

namespace UniMsgPack
{
	public class Vector4Handler : ITypeHandler
	{
		ITypeHandler floatHandler;

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsArrayFamily) {
				floatHandler = floatHandler ?? TypeHandlers.Get(typeof(byte));
				Vector4 vector = new Vector4();
				vector.w = (float)floatHandler.Read(reader.ReadFormat(), reader);
				vector.x = (float)floatHandler.Read(reader.ReadFormat(), reader);
				vector.y = (float)floatHandler.Read(reader.ReadFormat(), reader);
				vector.z = (float)floatHandler.Read(reader.ReadFormat(), reader);
				return vector;
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			Vector4 vector = (Vector4)obj;
			writer.WriteArrayHeader(4);
			writer.Write(vector.w);
			writer.Write(vector.x);
			writer.Write(vector.y);
			writer.Write(vector.z);
		}
	}
}
