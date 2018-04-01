using System;
using UnityEngine;

namespace UniMsgPack
{
	public class NullableHandler : ITypeHandler
	{
		readonly ITypeHandler underlyingTypeHandler;

		public NullableHandler(ITypeHandler underlyingTypeHandler)
		{
			this.underlyingTypeHandler = underlyingTypeHandler;
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsNil) return null;
			return underlyingTypeHandler.Read(format, reader);
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			underlyingTypeHandler.Write(obj, writer);
		}
	}
}
