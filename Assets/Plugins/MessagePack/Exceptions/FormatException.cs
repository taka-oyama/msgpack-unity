using System;
using System.IO;
using UnityEngine;

namespace MessagePack
{
	public class FormatException : System.FormatException
	{
		public FormatException() { }

		public FormatException(string message) : base(message) { }

		public FormatException(ITypeHandler handler, Format format, FormatReader reader) : base(string.Format("{0}: Undefined Format {1} at position {2}", handler.GetType(), format, reader.stream.Position))
		{
			this.Source = RepresetStreamAsJson(reader.stream);
		}

		public FormatException(Stream stream, Exception inner) : base(string.Format("{0} at Position: {1}", inner.Message, stream.Position), inner)
		{
			this.Source = RepresetStreamAsJson(stream);
		}

		string RepresetStreamAsJson(Stream stream)
		{
			string json = null;
			if(stream.CanSeek) {
				long prevPosition = stream.Position;
				stream.Position = 0;
				json = JsonConverter.Encode(stream);
				stream.Position = prevPosition;
			}
			return json;
		}
	}
}
