using UnityEngine;

namespace MessagePack
{
	public class FormatException : System.FormatException
	{
		public FormatException() { }

		public FormatException(string message) : base(message) { }

		public FormatException(ITypeHandler handler, Format format, FormatReader reader)
			: base(handler.GetType() + ": Undefined Format " + format + " in " + " at position " + reader.Position) { }
	}
}
