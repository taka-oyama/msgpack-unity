using System;
using UnityEngine;

namespace UniMsgPack
{
	public class TimeSpanHandler : ITypeHandler
	{
		readonly SerializationContext context;
		ITypeHandler longHandler;

		public TimeSpanHandler(SerializationContext context)
		{
			this.context = context;
		}

		public object Read(Format format, FormatReader reader)
		{
			longHandler = longHandler ?? context.typeHandlers.Get<long>();
			return new TimeSpan((long)longHandler.Read(format, reader));
		}

		public void Write(object obj, FormatWriter writer)
		{
			writer.Write(((TimeSpan)obj).Ticks);
		}
	}
}
