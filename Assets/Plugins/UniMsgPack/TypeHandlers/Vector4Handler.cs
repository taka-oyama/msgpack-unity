using UnityEngine;
using System;

namespace UniMsgPack
{
	public class Vector4Handler : ITypeHandler
	{
		readonly SerializationContext context;
		ITypeHandler floatHandler;

		public Vector4Handler(SerializationContext context)
		{
			this.context = context;
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsArrayFamily) {
				floatHandler = floatHandler ?? context.typeHandlers.Get<float>();
				Vector4 vector = new Vector4();
				vector.x = (float)floatHandler.Read(reader.ReadFormat(), reader);
				vector.y = (float)floatHandler.Read(reader.ReadFormat(), reader);
				vector.z = (float)floatHandler.Read(reader.ReadFormat(), reader);
				vector.w = (float)floatHandler.Read(reader.ReadFormat(), reader);
				return vector;
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			Vector4 vector = (Vector4)obj;
			writer.WriteArrayHeader(4);
			writer.Write(vector.x);
			writer.Write(vector.y);
			writer.Write(vector.z);
			writer.Write(vector.w);
		}
	}
}
