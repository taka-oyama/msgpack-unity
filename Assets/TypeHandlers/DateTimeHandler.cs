using System;
using System.IO;
using UnityEngine;

namespace UniMsgPack
{
	public class DateTimeHandler : ITypeHandler
	{
		readonly static DateTime epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsFixExt4) {
				// Timestamp 32
				if(IsTimestampExtType(reader)) {
					return epochTime.AddSeconds(reader.ReadUInt32());
				}
			}
			if(format.IsFixExt8) {
				// Timestamp 64
				if(IsTimestampExtType(reader)) {
					byte[] buffer = reader.ReadBytesOfSize(8);
					uint nanoseconds = ((uint)buffer[0] << 22) | ((uint)buffer[1] << 14) | ((uint)buffer[2] << 6) | (uint)buffer[3] >> 2;
					ulong seconds = ((ulong)(buffer[3] & 0x3) << 32) | ((ulong)buffer[4] << 24) | ((ulong)buffer[5] << 16) | ((ulong)buffer[6] << 8) | (ulong)buffer[7];
					return epochTime.AddTicks(nanoseconds / 100).AddSeconds(seconds);
				}
			}
			if(format.IsExt8) {
				// Timestamp 96
				if(reader.ReadUInt8() == 12) {
					if(IsTimestampExtType(reader)) {
						return epochTime.AddTicks(reader.ReadUInt32() / 100).AddSeconds(reader.ReadInt64());
					}
				}
			}
			throw new FormatException();
		}

		bool IsTimestampExtType(FormatReader reader)
		{
			return reader.ReadInt8() == -1;
		}
	}
}
