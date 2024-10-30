﻿using System;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public class ULongHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsPositiveFixInt) return (ulong)reader.ReadPositiveFixInt(format);
			if(format.IsUInt8) return (ulong)reader.ReadUInt8();
			if(format.IsUInt16) return (ulong)reader.ReadUInt16();
			if(format.IsUInt32) return (ulong)reader.ReadUInt32();
			if(format.IsUInt64) return reader.ReadUInt64();
			if(format.IsNil) return default(ulong);
			if(format.IsFixStr) return Convert.ToUInt64(reader.ReadFixStr(format));
			throw new FormatException(this, format, reader);
		}

		public void Write(object obj, FormatWriter writer)
		{
			writer.Write(Convert.ToUInt64(obj));
		}
	}
}
