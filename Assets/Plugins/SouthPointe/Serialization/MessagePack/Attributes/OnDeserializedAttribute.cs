using System;

namespace SouthPointe.Serialization.MessagePack
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	public sealed class OnDeserializedAttribute : Attribute
	{

	}
}
