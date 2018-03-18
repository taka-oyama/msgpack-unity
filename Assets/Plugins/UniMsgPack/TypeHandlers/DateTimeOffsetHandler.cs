using System;
using UnityEngine;

namespace UniMsgPack
{
	public class DateTimeOffsetHandler : ITypeHandler
	{
		ITypeHandler baseHandler;

		public object Read(Format format, FormatReader reader)
		{
			DateTime time = (DateTime)LoadDateTimeHandler().Read(format, reader);
			return new DateTimeOffset(time);
		}

		public void Write(object obj, FormatWriter writer)
		{
			LoadDateTimeHandler().Write(obj, writer);
		}

		ITypeHandler LoadDateTimeHandler()
		{
			return baseHandler = baseHandler ?? TypeHandlers.Get(typeof(DateTime));
		}
	}
}
