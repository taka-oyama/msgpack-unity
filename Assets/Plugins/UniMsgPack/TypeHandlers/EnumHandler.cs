using System;
using UnityEngine;

namespace UniMsgPack
{
	public class EnumHandler : ITypeHandler
	{
		public readonly Type type;
		readonly ITypeHandler intHandler;
		readonly ITypeHandler stringHandler;

		public EnumHandler(Type type)
		{
			this.type = type;
			this.intHandler = TypeHandlers.Get(typeof(int));
			this.stringHandler = TypeHandlers.Get(typeof(string));
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsIntFamily) return Enum.ToObject(type, intHandler.Read(format, reader));
			if(format.IsStringFamily) return Enum.Parse(type, (string)stringHandler.Read(format, reader), true);
			if(format.IsNil) return Enum.ToObject(type, 0);
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			intHandler.Write(obj, writer);
		}
	}
}
