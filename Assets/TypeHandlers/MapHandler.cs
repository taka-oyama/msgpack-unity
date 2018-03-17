using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace UniMsgPack
{
	public class MapHandler : ITypeHandler
	{
		const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField;
		static readonly Dictionary<Type, Dictionary<string, FieldInfo>> cache;

		readonly Type type;
		readonly ITypeHandler nameHandler;
		readonly Dictionary<Type, ITypeHandler> fieldHandlers;

		static MapHandler()
		{
			cache = new Dictionary<Type, Dictionary<string, FieldInfo>>();
		}

		public MapHandler(Type type)
		{
			this.type = type;
			this.nameHandler = TypeHandlers.Get(typeof(string));
			this.fieldHandlers = new Dictionary<Type, ITypeHandler>();
			foreach(Type fieldType in GetFieldTypes(type)) {
				if(!fieldHandlers.ContainsKey(fieldType)) {
					fieldHandlers.Add(fieldType, TypeHandlers.Get(fieldType));
				}
			}
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsMapGroup) {
				object obj = FormatterServices.GetUninitializedObject(type);
				int size = reader.ReadMapLength(format);
				while(size > 0) {
					string name = (string)nameHandler.Read(reader.ReadFormat(), reader);
					FieldInfo field = GetFieldInfo(name);
					if(field != null) {
						object value = fieldHandlers[field.FieldType].Read(reader.ReadFormat(), reader);
						field.SetValue(obj, value);
					}
					else {
						reader.Skip();
					}
					size = size - 1;
				}
				return obj;
			}
			if(format.IsNil) {
				return null;
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			writer.WriteMapLength(cache[type].Count);
			foreach(KeyValuePair<string, FieldInfo> kv in cache[type]) {
				object value = kv.Value.GetValue(obj);
				nameHandler.Write(kv.Key, writer);
				fieldHandlers[kv.Value.FieldType].Write(value, writer);
			}
		}

		FieldInfo GetFieldInfo(string field)
		{
			if(!cache.ContainsKey(type)) {
				cache[type] = ResolveType(type);
			}
			if(cache[type].ContainsKey(field)) {
				return cache[type][field];
			}
			return null;
		}

		public static List<Type> GetFieldTypes(Type type)
		{
			if(!cache.ContainsKey(type)) {
				cache[type] = ResolveType(type);
			}
			List<Type> types = new List<Type>(cache[type].Count);
			foreach(FieldInfo fieldInfo in cache[type].Values) {
				types.Add(fieldInfo.FieldType);
			}
			return types;
		}

		static Dictionary<string, FieldInfo> ResolveType(Type type)
		{
			FieldInfo[] fields = type.GetFields(flags);
			Dictionary<string, FieldInfo> infos = new Dictionary<string, FieldInfo>(fields.Length);
			foreach(FieldInfo info in fields) {
				infos[info.Name] = info;
			}
			return infos;
		}

		public static void ClearCache()
		{
			cache.Clear();
		}
	}
}
