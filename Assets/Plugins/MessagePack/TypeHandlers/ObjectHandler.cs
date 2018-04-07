using System.Collections.Generic;
using UnityEngine;

namespace MessagePack
{
	public class ObjectHandler : ITypeHandler
	{
		readonly SerializationContext context;

		public ObjectHandler(SerializationContext context)
		{
			this.context = context;
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsNil) return null;
			if(format.IsFalse) return false;
			if(format.IsTrue) return true;
			if(format.IsPositiveFixInt) return reader.ReadPositiveFixInt(format);
			if(format.IsUInt8) return reader.ReadUInt8();
			if(format.IsUInt16) return reader.ReadUInt16();
			if(format.IsUInt32) return reader.ReadUInt32();
			if(format.IsUInt64) return reader.ReadUInt64();
			if(format.IsNegativeFixInt) return reader.ReadNegativeFixInt(format);
			if(format.IsInt8) return reader.ReadInt8();
			if(format.IsInt16) return reader.ReadInt16();
			if(format.IsInt32) return reader.ReadInt32();
			if(format.IsInt64) return reader.ReadInt64();
			if(format.IsFloat32) return reader.ReadFloat32();
			if(format.IsFloat64) return reader.ReadFloat64();
			if(format.IsFixStr) return reader.ReadFixStr(format);
			if(format.IsStr8) return reader.ReadStr8();
			if(format.IsStr16) return reader.ReadStr16();
			if(format.IsStr32) return reader.ReadStr32();
			if(format.IsBin8) return reader.ReadBin8();
			if(format.IsBin16) return reader.ReadBin16();
			if(format.IsBin32) return reader.ReadBin32();
			if(format.IsFixArray) return ReadArray(format, reader);
			if(format.IsArray16) return ReadArray(format, reader);
			if(format.IsArray32) return ReadArray(format, reader);
			if(format.IsFixMap) return ReadMap(format, reader);
			if(format.IsMap16) return ReadMap(format, reader);
			if(format.IsMap32) return ReadMap(format, reader);
			if(format.IsFixExt1) return ReadExt(format, reader);
			if(format.IsFixExt2) return ReadExt(format, reader);
			if(format.IsFixExt4) return ReadExt(format, reader);
			if(format.IsFixExt8) return ReadExt(format, reader);
			if(format.IsExt8) return ReadExt(format, reader);
			if(format.IsExt16) return ReadExt(format, reader);
			if(format.IsExt32) return ReadExt(format, reader);
			throw new FormatException(this, format, reader);
		}

		public void Write(object obj, FormatWriter writer)
		{
			if(obj == null) {
				writer.WriteNil();
				return;
			}
			context.typeHandlers.Get(obj.GetType()).Write(obj, writer);
		}

		object ReadArray(Format format, FormatReader reader)
		{
			return context.typeHandlers.Get<List<object>>().Read(format, reader);
		}

		object ReadMap(Format format, FormatReader reader)
		{
			return context.typeHandlers.Get<Dictionary<object, object>>().Read(format, reader);
		}

		object ReadExt(Format format, FormatReader reader)
		{
			uint length = reader.ReadExtLength(format);
			sbyte extType = reader.ReadExtType(format);
			return context.typeHandlers.GetExt(extType).ReadExt(length, reader);
		}
	}
}
