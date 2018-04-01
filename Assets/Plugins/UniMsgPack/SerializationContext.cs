using System.Reflection;
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

		public DateTimePackingFormat dateTimePackingFormat;

		public BindingFlags mapFieldFlags;

		public IMapNameConverter mapNameConverter;

		public SerializationContext()
		{
			typeHandlers = new TypeHandlers(this);
			dateTimePackingFormat = DateTimePackingFormat.Ext;
			mapFieldFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField;
			mapNameConverter = new DefaultMapNameConverter();
		}
	}
}
