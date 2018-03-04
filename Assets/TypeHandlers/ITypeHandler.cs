using System.IO;

namespace UniMsgPack
{
	public interface ITypeHandler
	{
		object Read(Format format, FormatReader reader);
	}
}
