using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;

namespace UniMsgPack
{
    public class MsgPackReader
    {
        Stream stream;
        byte[] staticBuffer = new byte[8];
        byte[] dynamicBuffer = new byte[64];

        public MsgPackReader(Stream stream)
        {
            this.stream = stream;
        }

        public object Read(Type type)
        {
            return Read(type, GetNextTypeFormat());
        }

        object Read(Type type, Format format)
        {
            if (type.IsPrimitive)
            {
                if (type == typeof(int)) return ReadInt32(format);
                if (type == typeof(bool)) return ReadBoolean(format);
                if (type == typeof(float)) return ReadFloat(format);
                if (type == typeof(double)) return ReadDouble(format);
                if (type == typeof(long)) return ReadInt64(format);
                if (type == typeof(uint)) return ReadUInt32(format);
                if (type == typeof(ulong)) return ReadUInt64(format);
                if (type == typeof(sbyte)) return ReadInt32(format);
                if (type == typeof(byte)) return ReadInt32(format);
                if (type == typeof(short)) return ReadInt32(format);
                if (type == typeof(ushort)) return ReadUInt32(format);
                if (type == typeof(char)) return ReadUInt32(format);
                throw new NotSupportedException(type + " is not a supported primitive type");
            }

            if (type == typeof(string)) return ReadString(format);
            if (type == typeof(byte[])) return ReadBinary(format);

            if (type.IsEnum) return ReadEnum(type, format);

            if (IsNullable(type)) return ReadNullable(type, format);

            if (type.IsArray) return ReadArray(type, format);
            if (type is IList) return ReadList(type, format);

            ReadMap(type, format);

            throw new FormatException();
        }

        bool ReadBoolean(Format format)
        {
            if (format == Format.False) return false;
            if (format == Format.True) return true;
            throw new FormatException();
        }

        int ReadInt32(Format format)
        {
            if (format >= Format.PositiveFixIntMin && format <= Format.PositiveFixIntMax) return (int)ExtractPositiveFixInt(format);
            if (format == Format.UInt8) return (int)ExtractUInt8();
            if (format == Format.UInt16) return (int)ExtractUInt16();
            if (format == Format.UInt32) return (int)ExtractUInt32();
            if (format >= Format.NegativeFixIntMin && format <= Format.NegativeFixIntMax) return ExtractNegativeFixInt(format);
            if (format == Format.Int8) return ExtractInt8();
            if (format == Format.Int16) return ExtractInt16();
            if (format == Format.Int32) return ExtractInt32();
            throw new FormatException();
        }

        uint ReadUInt32(Format format)
        {
            if (format >= Format.PositiveFixIntMin && format <= Format.PositiveFixIntMax) return ExtractPositiveFixInt(format);
            if (format == Format.UInt8) return ExtractUInt8();
            if (format == Format.UInt16) return ExtractUInt16();
            if (format == Format.UInt32) return ExtractUInt32();
            throw new FormatException();
        }

        long ReadInt64(Format format)
        {
            if (format >= Format.PositiveFixIntMin && format <= Format.PositiveFixIntMax) return (long)ExtractPositiveFixInt(format);
            if (format == Format.UInt8) return (long)ExtractUInt8();
            if (format == Format.UInt16) return (long)ExtractUInt16();
            if (format == Format.UInt32) return (long)ExtractUInt32();
            if (format == Format.UInt64) return (long)ExtractUInt64();
            if (format >= Format.NegativeFixIntMin && format <= Format.NegativeFixIntMax) return ExtractNegativeFixInt(format);
            if (format == Format.Int8) return ExtractInt8();
            if (format == Format.Int16) return ExtractInt16();
            if (format == Format.Int32) return ExtractInt32();
            if (format == Format.Int64) return ExtractInt64();
            throw new FormatException();
        }

        ulong ReadUInt64(Format format)
        {
            if (format >= Format.PositiveFixIntMin && format <= Format.PositiveFixIntMax) return ExtractPositiveFixInt(format);
            if (format == Format.UInt8) return ExtractUInt8();
            if (format == Format.UInt16) return ExtractUInt16();
            if (format == Format.UInt32) return ExtractUInt32();
            if (format == Format.UInt64) return ExtractUInt64();
            throw new FormatException();
        }

        float ReadFloat(Format format)
        {
            if (format == Format.Float32) return ExtractFloat();
            throw new FormatException();
        }

        double ReadDouble(Format format)
        {
            if (format == Format.Float32) return ExtractFloat();
            if (format == Format.Float64) return ExtractDouble();
            throw new FormatException();
        }

        string ReadString(Format format)
        {
            if (format == Format.Nil)
            {
                return null;
            }
            int size = 0;
            if (format >= Format.FixStrMin && format <= Format.FixStrMax)
            {
                size = (int)format & 0x1f;
            }
            else if (format == Format.Str8)
            {
                size = (int)ExtractUInt8();
            }
            else if (format == Format.Str16)
            {
                size = (int)ExtractUInt16();
            }
            else if (format == Format.Str32)
            {
                size = (int)ExtractUInt32();
            }
            else
            {
                throw new FormatException();
            }
            if (dynamicBuffer.Length < size)
            {
                Array.Resize<byte>(ref dynamicBuffer, size);
            }
            stream.Read(dynamicBuffer, 0, size);
            return Encoding.UTF8.GetString(dynamicBuffer, 0, size);
        }

        byte[] ReadBinary(Format format)
        {
            if (format == Format.Nil)
            {
                return null;
            }
            int size = 0;
            if (format == Format.Bin8)
            {
                size = (int)ExtractUInt8();
            }
            else if (format == Format.Bin16)
            {
                size = (int)ExtractUInt16();
            }
            else if (format == Format.Bin32)
            {
                size = (int)ExtractUInt32();
            }
            else
            {
                throw new FormatException();
            }
            byte[] destination = new byte[size];
            stream.Read(destination, 0, size);
            return destination;
        }

        object ReadNullable(Type type, Format format)
        {
            return Read(Nullable.GetUnderlyingType(type), format);
        }

        object ReadEnum(Type type, Format format)
        {
            if (IsIntTypeFormat(format))
            {
                int value = ReadInt32(GetNextTypeFormat());
                if (Enum.IsDefined(type, value))
                {
                    return Enum.ToObject(type, value);
                }
                throw new FormatException();
            }
            if (IsStringTypeFormat(format))
            {
                return Enum.Parse(type, ReadString(GetNextTypeFormat()), true);
            }
            throw new FormatException();
        }

        object ReadArray(Type type, Format format)
        {
            Type elementType = type.GetElementType();
            if (format == Format.Nil)
            {
                return Array.CreateInstance(elementType, 0);
            }
            int size = -1;
            if (format >= Format.FixArrayMin && format <= Format.FixArrayMax) size = ((int)format & 0xf);
            if (format == Format.Array16) size = (int)ExtractUInt16();
            if (format == Format.Array32) size = (int)ExtractUInt32();
            if (size >= 0)
            {
                Array array = Array.CreateInstance(elementType, size);
                for (int i = 0; i < size; i++)
                {
                    array.SetValue(Read(elementType), i);
                }
                return array;
            }
            throw new FormatException(string.Format("Invalid Format {0} for {1}", format, type));
        }

        object ReadList(Type type, Format format)
        {
            Type elementType = type.GetElementType();
            Type listType = typeof(List<>).MakeGenericType(new[] { elementType });
            IList list = (IList)Activator.CreateInstance(listType);
            if (format == Format.Nil)
            {
                return list;
            }
            int size = 0;
            if (format >= Format.FixArrayMin && format <= Format.FixArrayMax) size = ((int)format & 0xf);
            if (format == Format.Array16) size = (int)ExtractUInt16();
            if (format == Format.Array32) size = (int)ExtractUInt32();
            if (size >= 0)
            {
                for (int i = 0; i < size; i++)
                {
                    list.Add(Read(elementType));
                }
                return list;
            }
            throw new FormatException(string.Format("Invalid Format {0} for {1}", format, type));
        }

        object ReadMap(Type type, Format format)
        {
            if (format == Format.Nil)
            {
                return null;
            }
            object obj = FormatterServices.GetUninitializedObject(type);
            int size = 0;
            if (format >= Format.FixMapMin && format <= Format.FixMapMax) size = ((int)format & 0xf);
            if (format == Format.Map16) size = (int)ExtractUInt16();
            if (format == Format.Map32) size = (int)ExtractUInt32();
            while (size != 0)
            {
                string name = ReadString(GetNextTypeFormat());
                FieldInfo field = type.GetField(name);
                field.SetValue(obj, Read(field.FieldType));
                size = size - 1;
            }
            return obj;
        }

        byte[] ReadExt(Type type, Format format)
        {
            if (format == Format.FixExt1)
            {
                sbyte extType = (sbyte)stream.ReadByte();
                return new byte[1] { Convert.ToByte(stream.ReadByte()) };
            }
            if (format == Format.FixExt2)
            {
                sbyte extType = (sbyte)stream.ReadByte();
                byte[] destination = new byte[2];
                stream.Read(destination, 0, 2);
                return destination;
            }
            if (format == Format.FixExt4)
            {
                sbyte extType = (sbyte)stream.ReadByte();
                byte[] destination = new byte[4];
                stream.Read(destination, 0, 4);
                return destination;
            }
            if (format == Format.FixExt8)
            {
                sbyte extType = (sbyte)stream.ReadByte();
                byte[] destination = new byte[8];
                stream.Read(destination, 0, 8);
                return destination;
            }
            if (format == Format.FixExt16)
            {
                sbyte extType = (sbyte)stream.ReadByte();
                byte[] destination = new byte[16];
                stream.Read(destination, 0, 16);
                return destination;
            }
            if (format == Format.Ext8)
            {
                int size = stream.ReadByte();
                sbyte extType = (sbyte)stream.ReadByte();
                byte[] destination = new byte[size];
                stream.Read(destination, 0, size);
                return destination;
            }
            if (format == Format.Ext16)
            {
                int size = (int)ExtractUInt16();
                sbyte extType = (sbyte)stream.ReadByte();
                byte[] destination = new byte[size];
                stream.Read(destination, 0, size);
                return destination;
            }
            if (format == Format.Ext32)
            {
                int size = (int)ExtractUInt32();
                sbyte extType = (sbyte)stream.ReadByte();
                byte[] destination = new byte[size];
                stream.Read(destination, 0, size);
                return destination;
            }
            throw new FormatException();
        }

        uint ExtractPositiveFixInt(Format format)
        {
            return (uint)format & 0x7f;
        }

        int ExtractNegativeFixInt(Format format)
        {
            return ((int)format & 0x1f) - 0x20;
        }

        int ExtractInt8()
        {
            return stream.ReadByte();
        }

        uint ExtractUInt8()
        {
            return (uint)stream.ReadByte();
        }

        int ExtractInt16()
        {
            if (stream.Read(staticBuffer, 0, 2) == 2)
            {
                return (staticBuffer[0] << 8) | staticBuffer[1];
            }
            throw new FormatException();
        }

        uint ExtractUInt16()
        {
            if (stream.Read(staticBuffer, 0, 2) == 2)
            {
                return ((uint)staticBuffer[0] << 8) | (uint)staticBuffer[1];
            }
            throw new FormatException();
        }

        int ExtractInt32()
        {
            if (stream.Read(staticBuffer, 0, 4) == 4)
            {
                return (staticBuffer[0] << 24) | (staticBuffer[1] << 16) | (staticBuffer[2] << 8) | staticBuffer[3];
            }
            throw new FormatException();
        }

        uint ExtractUInt32()
        {
            if (stream.Read(staticBuffer, 0, 4) == 4)
            {
                return ((uint)staticBuffer[0] << 24) | ((uint)staticBuffer[1] << 16) | ((uint)staticBuffer[2] << 8) | (uint)staticBuffer[3];
            }
            throw new FormatException();
        }

        long ExtractInt64()
        {
            if (stream.Read(staticBuffer, 0, 8) == 8)
            {
                return ((long)staticBuffer[0] << 56) | ((long)staticBuffer[1] << 48) | ((long)staticBuffer[2] << 40) | ((long)staticBuffer[3] << 32) | ((long)staticBuffer[4] << 24) | ((long)staticBuffer[5] << 16) | ((long)staticBuffer[6] << 8) | (long)staticBuffer[7];
            }
            throw new FormatException();
        }

        ulong ExtractUInt64()
        {
            if (stream.Read(staticBuffer, 0, 8) == 8)
            {
                return ((ulong)staticBuffer[0] << 56) | ((ulong)staticBuffer[1] << 48) | ((ulong)staticBuffer[2] << 40) | ((ulong)staticBuffer[3] << 32) | ((ulong)staticBuffer[4] << 24) | ((ulong)staticBuffer[5] << 16) | ((ulong)staticBuffer[6] << 8) | (ulong)staticBuffer[7];
            }
            throw new FormatException();
        }

        float ExtractFloat()
        {
            if (stream.Read(staticBuffer, 0, 4) == 4)
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(staticBuffer);
                }
                return BitConverter.ToSingle(staticBuffer, 0);
            }
            throw new FormatException();
        }

        double ExtractDouble()
        {
            if (stream.Read(staticBuffer, 0, 8) == 8)
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(staticBuffer);
                }
                return BitConverter.ToDouble(staticBuffer, 0);
            }
            throw new FormatException();
        }

        Format GetNextTypeFormat()
        {
            return (Format)stream.ReadByte();
        }

        bool IsIntTypeFormat(Format format)
        {
            return
                (format >= Format.PositiveFixIntMin && format <= Format.PositiveFixIntMax) ||
                (format >= Format.NegativeFixIntMin && format <= Format.NegativeFixIntMax) ||
                format == Format.Int8 ||
                format == Format.UInt8 ||
                format == Format.Int16 ||
                format == Format.UInt16 ||
                format == Format.Int32 ||
                format == Format.UInt32;
        }

        bool IsStringTypeFormat(Format format)
        {
            return (format >= Format.FixStrMin && format <= Format.FixStrMax) ||
                format == Format.Str8 ||
                format == Format.Str16 ||
                format == Format.Str32;
        }

        bool IsNullable(Type type)
        {
            if (type.IsValueType)
            {
                Type underlyingType = Nullable.GetUnderlyingType(type);
                if (underlyingType != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}