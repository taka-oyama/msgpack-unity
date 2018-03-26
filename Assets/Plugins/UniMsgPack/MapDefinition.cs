using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace UniMsgPack
{
	public class MapDefinition
	{
		const BindingFlags fieldFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField;
		const BindingFlags methodFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod;

		readonly static Dictionary<Type, MapDefinition> cache;
		readonly static Type[] callbackTypes;

		public readonly Dictionary<string, FieldInfo> fieldInfos;
		public readonly Dictionary<string, ITypeHandler> fieldHandlers;
		public readonly Dictionary<Type, MethodInfo[]> callbacks;


		static MapDefinition()
		{
			cache = new Dictionary<Type, MapDefinition>();
			callbackTypes = new Type[] {
				typeof(OnDeserializingAttribute), typeof(OnDeserializedAttribute),
				typeof(OnSerializingAttribute), typeof(OnSerializedAttribute),
			};
		}

		public static MapDefinition Get(Type type)
		{
			if(!cache.ContainsKey(type)) {
				cache[type] = new MapDefinition(type);
			}
			return cache[type];
		}

		MapDefinition(Type type)
		{
			this.fieldInfos = new Dictionary<string, FieldInfo>();
			foreach(FieldInfo info in type.GetFields(fieldFlags)) {
				if(!AttributesExist(info, typeof(NonSerializedAttribute))) {
					fieldInfos[info.Name] = info;
				}
			}

			this.fieldHandlers = new Dictionary<string, ITypeHandler>();
			foreach(FieldInfo info in fieldInfos.Values) {
				fieldHandlers.Add(info.Name, TypeHandlers.Resolve(info.FieldType));
			}

			this.callbacks = new Dictionary<Type, MethodInfo[]>();
			MethodInfo[] methodInfos = type.GetMethods(methodFlags);
			foreach(Type callbackType in callbackTypes) {
				List<MethodInfo> methodsWithCallbacks = new List<MethodInfo>();
				foreach(MethodInfo methodInfo in methodInfos) {
					if(AttributesExist(methodInfo, callbackType)) {
						methodsWithCallbacks.Add(methodInfo);
					}
				}
				if(methodsWithCallbacks.Count > 0) {
					callbacks[callbackType] = methodsWithCallbacks.ToArray();
				}
			}
		}

		bool AttributesExist(MemberInfo info, Type attributeType)
		{
			return info.GetCustomAttributes(attributeType, true).Length > 0;
		}
	}
}
