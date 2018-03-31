using System;
using UnityEngine;

namespace UniMsgPack
{
	public class GuidHandler : ITypeHandler
	{
		ITypeHandler binaryHandler;
		ITypeHandler stringHandler;

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsBin8) {
				binaryHandler = binaryHandler ?? TypeHandlers.Get(typeof(byte[]));
				return new Guid((byte[])binaryHandler.Read(format, reader));
			}
			if(format.IsStr8) {
				stringHandler = stringHandler ?? TypeHandlers.Get(typeof(string));
				return new Guid((string)stringHandler.Read(format, reader));				
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			binaryHandler = binaryHandler ?? TypeHandlers.Get(typeof(byte[]));
			binaryHandler.Write(((Guid)obj).ToByteArray(), writer);
		}
	}
}
