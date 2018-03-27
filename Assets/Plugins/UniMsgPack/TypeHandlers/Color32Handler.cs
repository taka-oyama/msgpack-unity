using UnityEngine;
using System;
using System.Collections.Generic;

namespace UniMsgPack
{
	public class Color32Handler : ITypeHandler
	{
		ITypeHandler byteHandler;
		ITypeHandler stringHandler;
		ITypeHandler mapHandler;

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsBinaryFamily) {
				byte[] bytes = reader.ReadBin8();
				return new Color32(bytes[0], bytes[1], bytes[2], bytes[3]);
			}
			if(format.IsArrayFamily) {
				byteHandler = byteHandler ?? TypeHandlers.Get(typeof(byte));
				int length = reader.ReadArrayLength(format);
				byte[] bytes = new byte[length];
				for(int i = 0; i < length; i++) {
					bytes[i] = (byte)byteHandler.Read(reader.ReadFormat(), reader);
				}
				return new Color32(bytes[0], bytes[1], bytes[2], bytes[3]);
			}
			if(format.IsStringFamily) {
				stringHandler = stringHandler ?? TypeHandlers.Get(typeof(string));
				string htmlStr = (string)stringHandler.Read(format, reader);
				Color color;
				ColorUtility.TryParseHtmlString(htmlStr, out color);
				return (Color32)color;
			}
			if(format.IsMapFamily) {
				mapHandler = mapHandler ?? TypeHandlers.Get(typeof(Dictionary<string, byte>));
				Dictionary<string, byte> map = (Dictionary<string, byte>)mapHandler.Read(format, reader);
				return new Color32(map["r"], map["g"], map["b"], map["a"]);
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			Color32 color = (Color32)obj;
			writer.WriteBinHeader(4);
			writer.WriteRawByte(color.r);
			writer.WriteRawByte(color.g);
			writer.WriteRawByte(color.b);
			writer.WriteRawByte(color.a);
		}
	}
}
