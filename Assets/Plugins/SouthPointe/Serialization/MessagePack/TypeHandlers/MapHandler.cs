using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public class MapHandler : ITypeHandler
	{
		readonly SerializationContext context;
		readonly Type type;
		readonly ITypeHandler nameHandler;
		readonly IMapNamingStrategy nameConverter;
		readonly Dictionary<string, FieldInfo> fieldInfos;
		readonly Dictionary<string, ITypeHandler> fieldHandlers;
		readonly Dictionary<Type, MethodInfo[]> callbacks;
		readonly static object[] callbackParameters = new object[0];

		public MapHandler(SerializationContext context, MapDefinition definition)
		{
			this.context = context;
			this.type = definition.type;
			this.nameHandler = context.typeHandlers.Get<string>();
			this.nameConverter = context.mapOptions.namingStrategy;
			this.fieldInfos = definition.fieldInfos;
			this.fieldHandlers = definition.fieldHandlers;
			this.callbacks = definition.callbacks;
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsMapFamily) {
				object obj = Activator.CreateInstance(type);
				InvokeCallback<OnDeserializingAttribute>(obj);
				int size = reader.ReadMapLength(format);
				while(size > 0) {
					string name = nameConverter.OnUnpack((string)nameHandler.Read(reader.ReadFormat(), reader));

					if(fieldHandlers.ContainsKey(name)) {
						object value = fieldHandlers[name].Read(reader.ReadFormat(), reader);
						fieldInfos[name].SetValue(obj, value);
					}
					else if(context.mapOptions.ignoreUnknownFieldOnUnpack) {
						reader.Skip();
					}
					else {
						throw new MissingFieldException(name + " does not exist for type: " + type);
					}
					size = size - 1;
				}
				InvokeCallback<OnDeserializedAttribute>(obj);
				return obj;
			}
			if(format.IsEmptyArray && context.mapOptions.allowEmptyArrayOnUnpack) {
				return Activator.CreateInstance(type);
			}
			if(format.IsNil) {
				return null;
			}
			throw new FormatException(this, format, reader);
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			InvokeCallback<OnSerializingAttribute>(obj);
			writer.WriteMapHeader(DetermineSize(obj));
			foreach(KeyValuePair<string, FieldInfo> kv in fieldInfos) {
				object value = kv.Value.GetValue(obj);
				if(context.mapOptions.ignoreNullOnPack && value == null) {
					continue;
				}
				nameHandler.Write(nameConverter.OnPack(kv.Key), writer);
				fieldHandlers[kv.Key].Write(value, writer);
			}
			InvokeCallback<OnSerializedAttribute>(obj);
		}

		int DetermineSize(object obj)
		{
			if(!context.mapOptions.ignoreNullOnPack) {
				return fieldInfos.Count;
			}
			int count = 0;
			foreach(FieldInfo info in fieldInfos.Values) {
				if(info.GetValue(obj) != null) {
					count += 1;
				}
			}
			return count;
		}

		void InvokeCallback<T>(object obj) where T : Attribute
		{
			Type attributeType = typeof(T);
			if(callbacks.ContainsKey(attributeType)) {
				foreach(MethodInfo methodInfo in callbacks[attributeType]) {
					methodInfo.Invoke(obj, callbackParameters);
				}
			}
		}
	}
}
