﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public class MapDefinition
	{
		const BindingFlags MethodFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod;

		static readonly Type[] callbackTypes = {
			typeof(OnDeserializingAttribute), typeof(OnDeserializedAttribute),
			typeof(OnSerializingAttribute), typeof(OnSerializedAttribute),
		};

		public readonly Type Type;
		public readonly Dictionary<string, FieldInfo> FieldInfos;
		public readonly Dictionary<string, ITypeHandler> FieldHandlers;
		public readonly Dictionary<Type, MethodInfo[]> Callbacks;

		internal MapDefinition(SerializationContext context, Type type)
		{
			this.Type = type;

			if(!IsSerializable(context, type))
			{
				throw new CustomAttributeFormatException(type + " does not have System.SerializableAttribute defined");
			}

			this.FieldInfos = new Dictionary<string, FieldInfo>();
			foreach(FieldInfo info in type.GetFields(context.MapOptions.FieldFlags)) {
				if(IsSerializable(context, info.FieldType) && !AttributesExist(info, typeof(NonSerializedAttribute))) {
					FieldInfos[info.Name] = info;
				}
			}

			this.FieldHandlers = new Dictionary<string, ITypeHandler>();
			foreach(FieldInfo info in FieldInfos.Values) {
				FieldHandlers.Add(info.Name, context.TypeHandlers.Get(info.FieldType));
			}

			this.Callbacks = new Dictionary<Type, MethodInfo[]>();
			MethodInfo[] methodInfos = type.GetMethods(MethodFlags);
			foreach(Type callbackType in callbackTypes) {
				List<MethodInfo> methodsWithCallbacks = new List<MethodInfo>();
				foreach(MethodInfo methodInfo in methodInfos) {
					if(AttributesExist(methodInfo, callbackType)) {
						methodsWithCallbacks.Add(methodInfo);
					}
				}
				if(methodsWithCallbacks.Count > 0) {
					Callbacks[callbackType] = methodsWithCallbacks.ToArray();
				}
			}
		}

		bool IsSerializable(SerializationContext context, Type type)
		{
			if(context.MapOptions.RequireSerializableAttribute) {
				return true;
			}
			return type.IsSerializable;
		}

		bool AttributesExist(MemberInfo info, Type attributeType)
		{
			return info.GetCustomAttributes(attributeType, true).Length > 0;
		}
	}
}
