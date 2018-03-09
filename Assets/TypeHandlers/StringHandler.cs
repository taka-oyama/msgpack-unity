﻿using System;
using UnityEngine;

namespace UniMsgPack
{
	public class StringHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsNil) return null;
			if(format.IsFixStr) return reader.ReadFixStr(format);
			if(format.IsStr8) return reader.ReadStr8();
			if(format.IsStr16) return reader.ReadStr16();
			if(format.IsStr32) return reader.ReadStr32();
			throw new FormatException();
		}
	}
}