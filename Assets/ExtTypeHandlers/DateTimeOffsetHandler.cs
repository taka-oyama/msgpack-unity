using System;
using UnityEngine;

namespace UniMsgPack
{
	public class DateTimeOffsetHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			ITypeHandler handler = TypeHandlers.Get(typeof(DateTimeOffset));
			return new DateTimeOffset((DateTime)handler.Read(format, reader));
		}
	}
}
