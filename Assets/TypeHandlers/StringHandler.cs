using System;
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

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			string value = (string)obj;
			Format format = writer.GetFormatForString(value);
			if(format.IsFixStr) writer.WriteFixStr(value);
			else if(format.IsStr8) writer.WriteStr8(value);
			else if(format.IsStr16) writer.WriteStr16(value);
			else if(format.IsStr32) writer.WriteStr32(value);
			throw new FormatException();
		}
	}
}
