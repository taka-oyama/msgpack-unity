using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public class DynamicMapHandler : ITypeHandler
	{
		readonly SerializationContext context;
		readonly Lazy<MapDefinition> definition;
		readonly ITypeHandler nameHandler;
		readonly IMapNamingStrategy nameConverter;
		readonly static object[] callbackParameters = new object[0];

		public DynamicMapHandler(SerializationContext context, Lazy<MapDefinition> definition)
		{
			this.context = context;
			this.definition = definition;
			this.nameHandler = context.TypeHandlers.Get<string>();
			this.nameConverter = context.MapOptions.NamingStrategy;
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsMapFamily) {
				object obj = Activator.CreateInstance(definition.Value.Type);
				InvokeCallback<OnDeserializingAttribute>(obj);
				int size = reader.ReadMapLength(format);
				while(size > 0) {
					string name = (string)nameHandler.Read(reader.ReadFormat(), reader);
					name = nameConverter.OnUnpack(name, definition.Value);

					if(definition.Value.FieldHandlers.ContainsKey(name)) {
						object value = definition.Value.FieldHandlers[name].Read(reader.ReadFormat(), reader);
						definition.Value.FieldInfos[name].SetValue(obj, value);
					}
					else if(context.MapOptions.IgnoreUnknownFieldOnUnpack) {
						reader.Skip();
					}
					else {
						throw new MissingFieldException(name + " does not exist for type: " + definition.Value.Type);
					}
					size = size - 1;
				}
				InvokeCallback<OnDeserializedAttribute>(obj);
				return obj;
			}
			if(format.IsEmptyArray && context.MapOptions.AllowEmptyArrayOnUnpack) {
				return Activator.CreateInstance(definition.Value.Type);
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
			foreach(KeyValuePair<string, FieldInfo> kv in definition.Value.FieldInfos) {
				object value = kv.Value.GetValue(obj);
				if(context.MapOptions.IgnoreNullOnPack && value == null) {
					continue;
				}
				string name = nameConverter.OnPack(kv.Key, definition.Value);
				nameHandler.Write(name, writer);
				definition.Value.FieldHandlers[kv.Key].Write(value, writer);
			}
			InvokeCallback<OnSerializedAttribute>(obj);
		}

		int DetermineSize(object obj)
		{
			if(!context.MapOptions.IgnoreNullOnPack) {
				return definition.Value.FieldInfos.Count;
			}
			int count = 0;
			foreach(FieldInfo info in definition.Value.FieldInfos.Values) {
				if(info.GetValue(obj) != null) {
					count += 1;
				}
			}
			return count;
		}

		void InvokeCallback<T>(object obj) where T : Attribute
		{
			Type attributeType = typeof(T);
			if(definition.Value.Callbacks.ContainsKey(attributeType)) {
				foreach(MethodInfo methodInfo in definition.Value.Callbacks[attributeType]) {
					methodInfo.Invoke(obj, callbackParameters);
				}
			}
		}
	}
}
