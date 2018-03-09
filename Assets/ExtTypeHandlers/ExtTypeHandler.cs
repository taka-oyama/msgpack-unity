using System;

namespace UniMsgPack
{
	public abstract class ExtTypeHandler : ITypeHandler
	{
		public abstract sbyte ExtType { get; }

		public abstract object Read(uint length, FormatReader reader);

		public object Read(Format format, FormatReader reader)
		{
			uint size = reader.ReadExtSize(format);
			if(ExtType == reader.ReadExtType(format)) {
				return Read(size, reader);
			}
			throw new FormatException();
		}
	}
}
