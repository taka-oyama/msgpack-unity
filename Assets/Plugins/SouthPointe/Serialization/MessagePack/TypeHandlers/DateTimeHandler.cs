using System;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack
{
	public class DateTimeHandler : IExtTypeHandler
	{
		readonly static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		readonly SerializationContext context;
		ITypeHandler stringHandler;
		ITypeHandler doubleHandler;

		public sbyte ExtType { get { return -1; } }

		public DateTimeHandler(SerializationContext context)
		{
			this.context = context;
		}

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsExtFamily) {
				uint length = reader.ReadExtLength(format);
				if(ExtType == reader.ReadExtType(reader.ReadFormat())) {
					return ReadExt(length, reader);
				}
			}
			if(format.IsStringFamily) {
				stringHandler ??= context.TypeHandlers.Get<string>();
				string dateTimeStr = (string)stringHandler.Read(format, reader);
				return ParseStringWithZone(dateTimeStr);
			}
			if(format.IsFloatFamily || format.IsIntFamily) {
				doubleHandler ??= context.TypeHandlers.Get<double>();
				double seconds = (double)doubleHandler.Read(format, reader);
				return ConvertToZone(epoch.AddSeconds(seconds));
			}
			throw new FormatException(this, format, reader);
		}

		public object ReadExt(uint length, FormatReader reader)
		{
			// Timestamp 32
			if(length == 4) {
				DateTime value = epoch.AddSeconds(reader.ReadUInt32());
				return ConvertToZone(value);
			}
			// Timestamp 64
			if(length == 8) {
				byte[] buffer = reader.ReadBytesOfLength(8);
				uint nanoseconds = ((uint)buffer[0] << 22) | ((uint)buffer[1] << 14) | ((uint)buffer[2] << 6) | (uint)buffer[3] >> 2;
				ulong seconds = ((ulong)(buffer[3] & 0x3) << 32) | ((ulong)buffer[4] << 24) | ((ulong)buffer[5] << 16) | ((ulong)buffer[6] << 8) | (ulong)buffer[7];
				DateTime value = epoch.AddTicks(nanoseconds / 100).AddSeconds(seconds);
				return ConvertToZone(value);
			}
			// Timestamp 96
			if(length == 12) {
				DateTime value = epoch.AddTicks(reader.ReadUInt32() / 100).AddSeconds(reader.ReadInt64());
				return ConvertToZone(value);
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			DateTime value = (DateTime)obj;
			switch(context.DateTimeOptions.PackingFormat) {
				case DateTimePackingFormat.Extension:
					TimeSpan diff = value.ToUniversalTime() - epoch;
					writer.WriteExtHeader(12, ExtType);
					writer.WriteUInt32((uint)(value.Ticks % 10000000) * 100);
					writer.WriteUInt64((ulong)diff.TotalSeconds);
					break;
				case DateTimePackingFormat.String:
					writer.Write(value.ToString("o"));
					break;
				case DateTimePackingFormat.Epoch:
					writer.Write((value.ToUniversalTime() - epoch).TotalSeconds);
					break;
				default:
					throw new FormatException();
			}
		}

		private DateTime ParseStringWithZone(string str)
		{
			DateTimeOptions options = context.DateTimeOptions;

			DateTimeStyles styles = options.ZoneConversion switch
			{
				DateTimeZoneConversion.Universal => DateTimeStyles.AdjustToUniversal,
				DateTimeZoneConversion.Local => DateTimeStyles.None,
				_ => throw new NotImplementedException(),
			};

			try {
				return ConvertToZone(DateTime.Parse(str, options.Culture, styles));
			} 
			catch (System.FormatException e) {
				if(options.OutOfBoundsHandling == DateTimeOutOfBoundsHandling.Clamp) {
					return FindYearInException(e) switch
					{
						<= 1 => ConvertToZone(DateTime.MinValue),
						>= 9999 => ConvertToZone(DateTime.MaxValue),
						_ => throw e,
					};
				}
				throw;
			}			

		}

		private int? FindYearInException(System.FormatException e)
		{
			Regex regex = new (@"(?<year>\d+)-\d{2}-\d{2}", RegexOptions.Compiled | RegexOptions.CultureInvariant);
			var captures = regex.Match(e.Message).Groups["year"].Captures;
			if(captures.Count != 0) {
				string yearAsString = regex.Match(e.Message).Groups["year"].Captures[0].Value;
				return int.Parse(yearAsString);
			}
			return null;
		}

		private DateTime ConvertToZone(DateTime dt)
		{
			return context.DateTimeOptions.ZoneConversion switch
            {
                DateTimeZoneConversion.Universal => dt.Kind == DateTimeKind.Utc ? dt : dt.ToUniversalTime(),
                DateTimeZoneConversion.Local => dt.Kind == DateTimeKind.Local ? dt : dt.ToLocalTime(),
                _ => throw new NotImplementedException(),
            };
		}
	}
}
