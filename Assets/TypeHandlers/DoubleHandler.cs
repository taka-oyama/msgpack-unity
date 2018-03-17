using System;
using UnityEngine;

namespace UniMsgPack
{
	public class DoubleHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsFloat32) return (double)reader.ReadFloat32();
			if(format.IsFloat64) return reader.ReadFloat64();
			if(format.IsNil) return default(double);
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			writer.WriteFormat(Format.Float32);
			writer.WriteFloat64((double)obj);
		}
	}
}
