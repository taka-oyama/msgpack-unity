using System;
using UnityEngine;

namespace UniMsgPack
{
	public class DateTimeOffsetHandler : ITypeHandler
	{
		DateTimeHandler baseHandler;

		public object Read(Format format, FormatReader reader)
		{
			return new DateTimeOffset(ReadDateTime(format, reader));
		}

		DateTime ReadDateTime(Format format, FormatReader reader)
		{
			this.baseHandler = baseHandler ?? TypeHandlers.Get(typeof(DateTime)) as DateTimeHandler;
			return (DateTime)baseHandler.Read(format, reader);
		}
	}
}
