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
			this.intHandler = TypeDefinition.Get<int>();
			this.stringHandler = TypeDefinition.Get<string>();
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsIntGroup) {
				return Enum.ToObject(type, intHandler.Read(format, reader));
			}
			if(format.IsStringGroup) {
				return Enum.Parse(type, (string)stringHandler.Read(format, reader), true);
			}
			throw new FormatException();
		}
	}
}
