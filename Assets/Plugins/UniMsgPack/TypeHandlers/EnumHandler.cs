using System;
using UnityEngine;

namespace UniMsgPack
{
	public class EnumHandler : ITypeHandler
	{
		readonly SerializationContext context;
		readonly Type type;
		ITypeHandler intHandler;
		ITypeHandler stringHandler;

		public EnumHandler(SerializationContext context, Type type)
		{
			this.context = context;
			this.type = type;
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsIntFamily) {
				intHandler = intHandler ?? context.typeHandlers.Get<int>();
				return Enum.ToObject(type, intHandler.Read(format, reader));
			}
			if(format.IsStringFamily) {
				stringHandler = stringHandler ?? context.typeHandlers.Get<string>();
				return Enum.Parse(type, (string)stringHandler.Read(format, reader), true);
			}
			if(format.IsNil) {
				return Enum.ToObject(type, 0);
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			switch(context.enumOptions.packingFormat) {
				case EnumPackingFormat.Integer:
              		intHandler = intHandler ?? context.typeHandlers.Get<int>();
					intHandler.Write(obj, writer);
					break;
				case EnumPackingFormat.String:
					stringHandler = stringHandler ?? context.typeHandlers.Get<string>();
					stringHandler.Write(obj.ToString(), writer);
					break;
			}
		}
	}
}
