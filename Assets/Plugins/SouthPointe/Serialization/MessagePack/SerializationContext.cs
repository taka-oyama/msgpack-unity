using System.Reflection;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public class SerializationContext
	{
		static SerializationContext defaultContext;

		public static SerializationContext Default
		{
			get { return defaultContext = defaultContext ?? new SerializationContext(); }
		}

		public readonly DateTimeOptions dateTimeOptions;

		public readonly EnumOptions enumOptions;

		public readonly ArrayOptions arrayOptions;

		public readonly MapOptions mapOptions;

		public readonly JsonOptions jsonOptions;

		public readonly TypeHandlers typeHandlers;

		public SerializationContext()
		{
			dateTimeOptions = new DateTimeOptions();
			enumOptions = new EnumOptions();
			arrayOptions = new ArrayOptions();
			mapOptions = new MapOptions();
			jsonOptions = new JsonOptions();
			typeHandlers = new TypeHandlers(this);
		}
	}
}
