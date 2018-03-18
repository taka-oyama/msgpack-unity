using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class MsgPackWriter
	{
		public Stream stream;
		readonly FormatWriter writer;

		public MsgPackWriter(Stream stream)
		{
			this.stream = stream;
			this.writer = new FormatWriter(stream);
		}

		public void Write<T>(T obj)
		{
			// Type is handled this way because GetType() throws an error if obj is null.
			// see https://stackoverflow.com/a/13874286/232195 more more details.
			Type type = (obj != null) ? obj.GetType() : typeof(T);

			Write(type, obj);
		}
		
		public void Write(Type type, object obj)
		{
			TypeHandlers.Resolve(type).Write(obj, writer);
		}
	}
}