using System;
using UnityEngine;

namespace UniMsgPack
{
	public class DateTimeHandler : ExtTypeHandler
	{
		readonly static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public override sbyte ExtType
		{
			get { return -1; }
		}

		public override object Read(uint length, FormatReader reader)
		{
			// Timestamp 32
			if(length == 4) {
				return epoch.AddSeconds(reader.ReadUInt32());
			}

			// Timestamp 64
			if(length == 8) {
				byte[] buffer = reader.ReadBytesOfSize(8);
				uint nanoseconds = ((uint)buffer[0] << 22) | ((uint)buffer[1] << 14) | ((uint)buffer[2] << 6) | (uint)buffer[3] >> 2;
				ulong seconds = ((ulong)(buffer[3] & 0x3) << 32) | ((ulong)buffer[4] << 24) | ((ulong)buffer[5] << 16) | ((ulong)buffer[6] << 8) | (ulong)buffer[7];
				return epoch.AddTicks(nanoseconds / 100).AddSeconds(seconds);
			}

			// Timestamp 96
			if(length == 12) {
				return epoch.AddTicks(reader.ReadUInt32() / 100).AddSeconds(reader.ReadInt64());
			}

			throw new FormatException();
		}
	}
}
