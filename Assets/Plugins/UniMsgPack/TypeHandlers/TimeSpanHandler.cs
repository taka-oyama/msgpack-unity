using System;
using UnityEngine;

namespace UniMsgPack
{
	public class TimeSpanHandler : ITypeHandler
	{
		ITypeHandler longHandler;

		public object Read(Format format, FormatReader reader)
		{
			longHandler = longHandler ?? TypeHandlers.Get(typeof(long));
			return new TimeSpan((long)longHandler.Read(format, reader));
		}

		public void Write(object obj, FormatWriter writer)
		{
			writer.Write(((TimeSpan)obj).Ticks);
		}
	}
}
