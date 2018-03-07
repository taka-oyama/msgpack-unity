using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniMsgPack
{
	public class ObjectHandler : ITypeHandler
	{
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
			if(format.IsFixArray) return HandleArray(format, reader);
			if(format.IsArray16) return HandleArray(format, reader);
			if(format.IsArray32) return HandleArray(format, reader);
			if(format.IsFixMap) return HandleMap(format, reader);
			if(format.IsMap16) return HandleMap(format, reader);
			if(format.IsMap32) return HandleMap(format, reader);
			if(format.IsFixExt1) return HandleExt(format, reader);
			if(format.IsFixExt2) return HandleExt(format, reader);
			if(format.IsFixExt4) return HandleExt(format, reader);
			if(format.IsFixExt8) return HandleExt(format, reader);
			if(format.IsExt8) return HandleExt(format, reader);
			if(format.IsExt16) return HandleExt(format, reader);
			if(format.IsExt32) return HandleExt(format, reader);
			throw new FormatException();
		}

		object HandleArray(Format format, FormatReader reader)
		{
			return TypeHandlers.Resolve<List<object>>().Read(format, reader);
		}

		object HandleMap(Format format, FormatReader reader)
		{
			return TypeHandlers.Resolve<Dictionary<object, object>>().Read(format, reader);
		}

		object HandleExt(Format format, FormatReader reader)
		{
			uint size = reader.ReadExtSize(format);
			sbyte extType = reader.ReadExtType(format);
			return TypeHandlers.GetExt(extType).Read(size, reader);
		}
	}
}
