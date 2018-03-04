using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class DoubleHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsFloat32) return (double)reader.ReadFloat32();
			if(format.IsFloat64) return reader.ReadFloat64();
			throw new FormatException();
		}
	}
}
