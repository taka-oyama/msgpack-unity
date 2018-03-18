using System;
using UnityEngine;

namespace UniMsgPack
{
	public class NullableHandler : ITypeHandler
	{
		public readonly Type underlyingType;

		public NullableHandler(Type underlyingType)
		{
			this.underlyingType = underlyingType;
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsNil) return null;
			return TypeHandlers.Get(underlyingType).Read(format, reader);
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			TypeHandlers.Get(underlyingType).Write(obj, writer);
		}
	}
}
