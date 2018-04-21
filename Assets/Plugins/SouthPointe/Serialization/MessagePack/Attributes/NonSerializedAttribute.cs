using System;

namespace SouthPointe.Serialization.MessagePack
{
	[AttributeUsage(AttributeTargets.Field, Inherited = false)]
	public sealed class NonSerializedAttribute : Attribute
	{
		
	}
}
