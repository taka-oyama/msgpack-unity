namespace SouthPointe.Serialization.MessagePack
{
	public interface IExtTypeHandler : ITypeHandler
	{
		sbyte ExtType { get; }

		object ReadExt(uint length, FormatReader reader);
	}
}
