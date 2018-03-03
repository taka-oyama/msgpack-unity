﻿using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace UniMsgPack
{
	public class MsgPackReader
	{
		readonly Stream stream;
		byte[] staticBuffer = new byte[8];
		byte[] dynamicBuffer = new byte[64];
		static DateTime epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public MsgPackReader(Stream stream)
		{
			this.stream = stream;
		}

		public T Read<T>()
		{
			return (T)Read(typeof(T));
		}

		public object Read(Type type)
		{
			return Read(type, ExtractNextFormat());
		}

		object Read(Type type, Format format)
		{
			if(type.IsPrimitive) {
				if(type == typeof(int)) return ReadInt(format);
				if(type == typeof(bool)) return ReadBool(format);
				if(type == typeof(float)) return ReadFloat(format);
				if(type == typeof(double)) return ReadDouble(format);
				if(type == typeof(uint)) return ReadUInt(format);
				if(type == typeof(sbyte)) return ReadSbyte(format);
				if(type == typeof(byte)) return ReadByte(format);
				if(type == typeof(short)) return ReadShort(format);
				if(type == typeof(ushort)) return ReadUShort(format);
				if(type == typeof(long)) return ReadLong(format);
				if(type == typeof(ulong)) return ReadULong(format);
				throw new NotSupportedException(type + " is not a supported primitive type");
			}
			if(type == typeof(string)) return ReadString(format);
			if(type == typeof(byte[])) return ReadBinary(format);
			if(type == typeof(DateTime)) return ReadDateTime(format);
			if(type.IsEnum) return ReadEnum(type, format);
			if(IsNullable(type)) return ReadNullable(type, format);
			if(type.IsArray) return ReadArray(type, format);
			if(typeof(IList).IsAssignableFrom(type)) return ReadList(type, format);
			if(typeof(IDictionary).IsAssignableFrom(type)) return ReadDictionary(type, format);
			return ReadClassOrStruct(type, format);
		}

		bool ReadBool(Format format)
		{
			if(format == Format.False) return false;
			if(format == Format.True) return true;
			throw new FormatException();
		}

		byte ReadByte(Format format)
		{
			if(format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax)) return ExtractPositiveFixInt(format);
			if(format == Format.UInt8) return ExtractUInt8();
			throw new FormatException();
		}

		ushort ReadUShort(Format format)
		{
			if(format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax)) return ExtractPositiveFixInt(format);
			if(format == Format.UInt8) return ExtractUInt8();
			if(format == Format.UInt16) return ExtractUInt16();
			throw new FormatException();
		}

		uint ReadUInt(Format format)
		{
			if(format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax)) return ExtractPositiveFixInt(format);
			if(format == Format.UInt8) return ExtractUInt8();
			if(format == Format.UInt16) return ExtractUInt16();
			if(format == Format.UInt32) return ExtractUInt32();
			throw new FormatException();
		}

		ulong ReadULong(Format format)
		{
			if(format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax)) return ExtractPositiveFixInt(format);
			if(format == Format.UInt8) return ExtractUInt8();
			if(format == Format.UInt16) return ExtractUInt16();
			if(format == Format.UInt32) return ExtractUInt32();
			if(format == Format.UInt64) return ExtractUInt64();
			throw new FormatException();
		}

		sbyte ReadSbyte(Format format)
		{
			if(format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax)) return (sbyte)ExtractPositiveFixInt(format);
			if(format == Format.UInt8) return Convert.ToSByte(ExtractUInt8());
			if(format.Between(Format.NegativeFixIntMin, Format.NegativeFixIntMax)) return ExtractNegativeFixInt(format);
			if(format == Format.Int8) return ExtractInt8();
			throw new FormatException();
		}

		short ReadShort(Format format)
		{
			if(format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax)) return ExtractPositiveFixInt(format);
			if(format == Format.UInt8) return ExtractUInt8();
			if(format == Format.UInt16) return Convert.ToInt16(ExtractUInt16());
			if(format.Between(Format.NegativeFixIntMin, Format.NegativeFixIntMax)) return ExtractNegativeFixInt(format);
			if(format == Format.Int8) return ExtractInt8();
			if(format == Format.Int16) return ExtractInt16();
			throw new FormatException();
		}

		int ReadInt(Format format)
		{
			if(format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax)) return ExtractPositiveFixInt(format);
			if(format == Format.UInt8) return ExtractUInt8();
			if(format == Format.UInt16) return ExtractUInt16();
			if(format == Format.UInt32) return Convert.ToInt32(ExtractUInt32());
			if(format.Between(Format.NegativeFixIntMin, Format.NegativeFixIntMax)) return ExtractNegativeFixInt(format);
			if(format == Format.Int8) return ExtractInt8();
			if(format == Format.Int16) return ExtractInt16();
			if(format == Format.Int32) return ExtractInt32();
			throw new FormatException();
		}

		long ReadLong(Format format)
		{
			if(format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax)) return ExtractPositiveFixInt(format);
			if(format == Format.UInt8) return ExtractUInt8();
			if(format == Format.UInt16) return ExtractUInt16();
			if(format == Format.UInt32) return ExtractUInt32();
			if(format == Format.UInt64) return Convert.ToInt64(ExtractUInt64());
			if(format.Between(Format.NegativeFixIntMin, Format.NegativeFixIntMax)) return ExtractNegativeFixInt(format);
			if(format == Format.Int8) return ExtractInt8();
			if(format == Format.Int16) return ExtractInt16();
			if(format == Format.Int32) return ExtractInt32();
			if(format == Format.Int64) return ExtractInt64();
			throw new FormatException();
		}

		float ReadFloat(Format format)
		{
			if(format == Format.Float32) return ExtractFloat32();
			if(format == Format.Float64) {
				double value = ExtractFloat64();
				if(value > float.MaxValue) {
					throw new InvalidCastException(string.Format("{0} is too big for a float", value));
				}
				if(value < float.MinValue) {
					throw new InvalidCastException(string.Format("{0} is too small for a float", value));
				}
				return (float)value;
			}
			throw new FormatException();
		}

		double ReadDouble(Format format)
		{
			if(format == Format.Float32) return ExtractFloat32();
			if(format == Format.Float64) return ExtractFloat64();
			throw new FormatException();
		}

		string ReadString(Format format)
		{
			if(format == Format.Nil) {
				return null;
			}
			int size = ExtractStringSize(format);
			if(dynamicBuffer.Length < size) {
				Array.Resize(ref dynamicBuffer, size);
			}
			stream.Read(dynamicBuffer, 0, size);
			return Encoding.UTF8.GetString(dynamicBuffer, 0, size);
		}

		byte[] ReadBinary(Format format)
		{
			if(format == Format.Nil) {
				return null;
			}
			int size = ExtractBinSize(format);
			byte[] destination = new byte[size];
			stream.Read(destination, 0, size);
			return destination;
		}

		object ReadNullable(Type type, Format format)
		{
			if(format == Format.Nil) {
				return null;
			}
			return Read(Nullable.GetUnderlyingType(type), format);
		}

		object ReadEnum(Type type, Format format)
		{
			if(format.IsInt()) {
				int value = ReadInt(format);
				if(Enum.IsDefined(type, value)) {
					return Enum.ToObject(type, value);
				}
				throw new FormatException();
			}
			if(format.IsString()) {
				return Enum.Parse(type, ReadString(format), true);
			}
			throw new FormatException();
		}

		object ReadArray(Type type, Format format)
		{
			Type elementType = type.GetElementType();
			if(format == Format.Nil) {
				return Array.CreateInstance(elementType, 0);
			}
			int size = ExtractArraySize(format);
			if(size >= 0) {
				Array array = Array.CreateInstance(elementType, size);
				for(int i = 0; i < size; i++) {
					array.SetValue(Read(elementType), i);
				}
				return array;
			}
			throw new FormatException(string.Format("Invalid Format {0} for {1}", format, type));
		}

		object ReadList(Type type, Format format)
		{
			Type elementType = type.GetGenericArguments()[0];
			Type listType = typeof(List<>).MakeGenericType(new[] { elementType });
			IList list = (IList)Activator.CreateInstance(listType);
			if(format == Format.Nil) {
				return list;
			}
			int size = ExtractArraySize(format);
			if(size >= 0) {
				for(int i = 0; i < size; i++) {
					list.Add(Read(elementType));
				}
				return list;
			}
			throw new FormatException(string.Format("Invalid Format {0} for {1}", format, type));
		}

		object ReadDictionary(Type type, Format format)
		{
			if(format == Format.Nil) {
				return null;
			}
			int size = ExtractMapSize(format);
			if(size == -1) {
				throw new FormatException(string.Format("Invalid Map size {0} for {1}", size, type));
			}
			IDictionary dictionary = (IDictionary)Activator.CreateInstance(type);
			Type[] types = type.GetGenericArguments();
			while(size > 0) {
				dictionary.Add(Read(types[0]), Read(types[1]));
				size = size - 1;
			}
			return dictionary;
		}

		object ReadClassOrStruct(Type type, Format format)
		{
			if(format == Format.Nil) {
				return null;
			}
			int size = ExtractMapSize(format);
			if(size == -1) {
				throw new FormatException(string.Format("Invalid Map size {0} for {1}", size, type));
			}
			object obj = FormatterServices.GetUninitializedObject(type);
			while(size > 0) {
				string name = ReadString(ExtractNextFormat());
				FieldInfo field = MapResolver.GetField(type, name);
				if(field != null) {
					field.SetValue(obj, Read(field.FieldType));
				}
				else {
					Skip();
				}
				size = size - 1;
			}
			return obj;
		}

		DateTime ReadDateTime(Format format)
		{
			if(format == Format.FixExt4) {
				if(stream.ReadByte() == -1) {
					return ExtractTimestamp32();
				}
			}
			if(format == Format.FixExt8) {
				if(stream.ReadByte() == -1) {
					return ExtractTimestamp64();
				}
			}
			if(format == Format.Ext8) {
				if(stream.ReadByte() == 12) {
					if(stream.ReadByte() == -1) {
						return ExtractTimestamp96();
					}
				}
			}
			throw new FormatException();
		}

		void Skip()
		{
			Format format = ExtractNextFormat();
			if(format == Format.Nil) { return; }
			if(format == Format.False) { return; }
			if(format == Format.True) { return; }
			if(format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax)) { return; }
			if(format.Between(Format.NegativeFixIntMin, Format.NegativeFixIntMax)) { return; }
			if(format == Format.UInt8 || format == Format.Int8) { FastForward(1); return; }
			if(format == Format.UInt16 || format == Format.Int16) { FastForward(2); return; }
			if(format == Format.UInt32 || format == Format.Int32) { FastForward(4); return; }
			if(format == Format.UInt64 || format == Format.Int64) { FastForward(8); return; }
			if(format == Format.Float32) { FastForward(4); return; }
			if(format == Format.Float64) { FastForward(8); return; }
			if(format.Between(Format.FixStrMin, Format.FixStrMax) || format == Format.Str8 || format == Format.Str16 || format == Format.Str32) {
				FastForward(ExtractStringSize(format));
				return;
			}
			if(format == Format.Bin8 || format == Format.Bin16 || format == Format.Bin32) {
				FastForward(ExtractBinSize(format));
				return;
			}
			if(format.Between(Format.FixArrayMin, Format.FixArrayMax) || format == Format.Array16 || format == Format.Array32) {
				for(int size = ExtractArraySize(format); size > 0; size--) {
					Skip();
				}
				return;
			}
			if(format.Between(Format.FixMapMin, Format.FixMapMax) || format == Format.Map16 || format == Format.Map32) {
				for(int size = ExtractMapSize(format); size > 0; size--) {
					Skip();
					Skip();
				}
				return;
			}
			if(format == Format.FixExt1) { FastForward(2); return; }
			if(format == Format.FixExt2) { FastForward(3); return; }
			if(format == Format.FixExt4) { FastForward(5); return; }
			if(format == Format.FixExt8) { FastForward(9); return; }
			if(format == Format.FixExt16) { FastForward(17); return; }
			if(format == Format.Ext8 || format == Format.Ext16 || format == Format.Ext32) {
				FastForward(ExtractUInt32() + 1);
				return;
			}
		}

		void FastForward(long offset)
		{
			if(stream.CanSeek) {
				stream.Seek(offset, SeekOrigin.Current);
			}
			else {
				while(offset > 0) {
					int size = offset > int.MaxValue ? int.MaxValue : (int)offset;
					stream.Read(dynamicBuffer, 0, size);
					offset -= int.MaxValue;
				}
			}
		}

		Format ExtractNextFormat()
		{
			return (Format)stream.ReadByte();
		}

		byte ExtractPositiveFixInt(Format format)
		{
			return (byte)((int)format & 0x7f);
		}

		byte ExtractUInt8()
		{
			return (byte)stream.ReadByte();
		}

		ushort ExtractUInt16()
		{
			if(stream.Read(staticBuffer, 0, 2) == 2) {
				return (ushort)((staticBuffer[0] << 8) | staticBuffer[1]);
			}
			throw new FormatException();
		}

		uint ExtractUInt32()
		{
			if(stream.Read(staticBuffer, 0, 4) == 4) {
				return ((uint)staticBuffer[0] << 24) | ((uint)staticBuffer[1] << 16) | ((uint)staticBuffer[2] << 8) | (uint)staticBuffer[3];
			}
			throw new FormatException();
		}

		ulong ExtractUInt64()
		{
			if(stream.Read(staticBuffer, 0, 8) == 8) {
				return ((ulong)staticBuffer[0] << 56) | ((ulong)staticBuffer[1] << 48) | ((ulong)staticBuffer[2] << 40) | ((ulong)staticBuffer[3] << 32) | ((ulong)staticBuffer[4] << 24) | ((ulong)staticBuffer[5] << 16) | ((ulong)staticBuffer[6] << 8) | (ulong)staticBuffer[7];
			}
			throw new FormatException();
		}

		sbyte ExtractNegativeFixInt(Format format)
		{
			return (sbyte)(((int)format & 0x1f) - 0x20);
		}

		sbyte ExtractInt8()
		{
			return (sbyte)stream.ReadByte();
		}

		short ExtractInt16()
		{
			if(stream.Read(staticBuffer, 0, 2) == 2) {
				return (short)((staticBuffer[0] << 8) | staticBuffer[1]);
			}
			throw new FormatException();
		}

		int ExtractInt32()
		{
			if(stream.Read(staticBuffer, 0, 4) == 4) {
				return (staticBuffer[0] << 24) | (staticBuffer[1] << 16) | (staticBuffer[2] << 8) | staticBuffer[3];
			}
			throw new FormatException();
		}

		long ExtractInt64()
		{
			if(stream.Read(staticBuffer, 0, 8) == 8) {
				return ((long)staticBuffer[0] << 56) | ((long)staticBuffer[1] << 48) | ((long)staticBuffer[2] << 40) | ((long)staticBuffer[3] << 32) | ((long)staticBuffer[4] << 24) | ((long)staticBuffer[5] << 16) | ((long)staticBuffer[6] << 8) | (long)staticBuffer[7];
			}
			throw new FormatException();
		}

		float ExtractFloat32()
		{
			if(stream.Read(staticBuffer, 0, 4) == 4) {
				if(BitConverter.IsLittleEndian) {
					Array.Reverse(staticBuffer);
				}
				return BitConverter.ToSingle(staticBuffer, 0);
			}
			throw new FormatException();
		}

		double ExtractFloat64()
		{
			if(stream.Read(staticBuffer, 0, 8) == 8) {
				if(BitConverter.IsLittleEndian) {
					Array.Reverse(staticBuffer);
				}
				return BitConverter.ToDouble(staticBuffer, 0);
			}
			throw new FormatException();
		}

		DateTime ExtractTimestamp32()
		{
			return epochTime.AddSeconds(ExtractUInt32());
		}

		DateTime ExtractTimestamp64()
		{
			stream.Read(staticBuffer, 0, 8);
			uint nanoseconds = ((uint)staticBuffer[0] << 22) | ((uint)staticBuffer[1] << 14) | ((uint)staticBuffer[2] << 6) | (uint)staticBuffer[3] >> 2;
			ulong seconds = ((ulong)(staticBuffer[3] & 0x3) << 32) | ((ulong)staticBuffer[4] << 24) | ((ulong)staticBuffer[5] << 16) | ((ulong)staticBuffer[6] << 8) | (ulong)staticBuffer[7];
			return epochTime.AddTicks(nanoseconds / 100).AddSeconds(seconds);
		}

		DateTime ExtractTimestamp96()
		{
			return epochTime.AddTicks(ExtractUInt32() / 100).AddSeconds(ExtractInt64());
		}

		int ExtractStringSize(Format format)
		{
			if(format.Between(Format.FixStrMin, Format.FixStrMax)) return ((int)format & 0x1f);
			if(format == Format.Str8) return ExtractUInt8();
			if(format == Format.Str16) return ExtractUInt16();
			if(format == Format.Str32) return Convert.ToInt32(ExtractUInt32());
			throw new FormatException();
		}

		int ExtractBinSize(Format format)
		{
			if(format.Between(Format.FixStrMin, Format.FixStrMax)) return ((int)format & 0x1f);
			if(format == Format.Bin8) return ExtractUInt8();
			if(format == Format.Bin16) return ExtractUInt16();
			if(format == Format.Bin32) return Convert.ToInt32(ExtractUInt32());
			throw new FormatException();
		}

		int ExtractArraySize(Format format)
		{
			if(format.Between(Format.FixArrayMin, Format.FixArrayMax)) return ((int)format & 0xf);
			if(format == Format.Array16) return ExtractUInt16();
			if(format == Format.Array32) return Convert.ToInt32(ExtractUInt32());
			return -1;
		}

		int ExtractMapSize(Format format)
		{
			if(format.Between(Format.FixMapMin, Format.FixMapMax)) return ((int)format & 0xf);
			if(format == Format.Map16) return ExtractUInt16();
			if(format == Format.Map32) return Convert.ToInt32(ExtractUInt32());
			return -1;
		}

		bool IsNullable(Type type)
		{
			if(type.IsValueType) {
				Type underlyingType = Nullable.GetUnderlyingType(type);
				if(underlyingType != null) {
					return true;
				}
			}
			return false;
		}
	}
}