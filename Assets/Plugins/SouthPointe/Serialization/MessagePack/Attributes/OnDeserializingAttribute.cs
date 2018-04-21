using System;
using System.Runtime.InteropServices;

namespace SouthPointe.Serialization.MessagePack
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	public sealed class OnDeserializingAttribute : Attribute
	{

	}
}