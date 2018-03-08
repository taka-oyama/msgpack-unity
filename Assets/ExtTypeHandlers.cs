using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniMsgPack
{
	public static class ExtTypeHandlers
	{
		static readonly Dictionary<sbyte, ExtTypeHandler> handlers;

		static ExtTypeHandlers()
		{
			handlers = new Dictionary<sbyte, ExtTypeHandler>();
		}

		internal static ExtTypeHandler Get(sbyte extType)
		{
			return handlers[extType];
		}

		internal static void AddIfNotExist(ExtTypeHandler handler)
		{
			if(!handlers.ContainsKey(handler.ExtType)) {
				handlers.Add(handler.ExtType, handler);
			}
		}
	}
}
