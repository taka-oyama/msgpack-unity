using System;

namespace SouthPointe.Serialization.MessagePack
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	public sealed class OnSerializedAttribute : Attribute
	{

	}
}
