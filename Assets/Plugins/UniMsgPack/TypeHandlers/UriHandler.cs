using System;
using UnityEngine;

namespace UniMsgPack
{
	public class UriHandler : ITypeHandler
	{
		ITypeHandler stringHandler;

		ITypeHandler GetStringHandler()
		{
			return stringHandler = stringHandler ?? TypeHandlers.Get(typeof(string));
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsNil) return null;
			return new Uri((string)GetStringHandler().Read(format, reader));
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			string value = ((Uri)obj).ToString();
			GetStringHandler().Write(value, writer);
		}
	}
}
