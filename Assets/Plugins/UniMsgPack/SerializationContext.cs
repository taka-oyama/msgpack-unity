using UnityEngine;

namespace UniMsgPack
{
	public class SerializationContext
	{
		static SerializationContext defaultContext;

		public static SerializationContext Default
		{
			get { return defaultContext = defaultContext ?? new SerializationContext(); }
		}

		public readonly TypeHandlers typeHandlers;

		public SerializationContext()
		{
			this.typeHandlers = new TypeHandlers(this);
		}
	}
}
