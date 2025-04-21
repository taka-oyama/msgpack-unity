using System;
using NUnit.Framework;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class DateTimeHandlerTest : TestBase
	{
		#region Pack

		[Test]
		public void PackAsExt8()
		{
			DateTime value = DateTime.Parse("2018-01-01 12:00:00+09:00").ToLocalTime();
			byte[] data = Pack(value);
			Assert.AreEqual(Format.Ext8, data[0]);
			Assert.AreEqual(12, data[1]);
			Assert.AreEqual(-1, (sbyte)data[2]);
			Assert.AreEqual(15, data.Length);
		}

		#endregion


		#region Unpack

		[Test]
		public void UnpackAsExt8()
		{
			byte[] data = ReadFile("Timestamps/Timestamp96");
			DateTime result = Unpack<DateTime>(data);
			Assert.AreEqual("2018-01-01T12:00:00.0000000+09:00", result.ToString("o"));
		}

		[Test]
		public void UnpackFromString()
		{
			byte[] data = ReadFile("Timestamps/String");
			DateTime result = Unpack<DateTime>(data);
			Assert.AreEqual("2018-01-01T12:00:00.0000000+09:00", result.ToString("o"));
		}

		[Test]
		public void UnpackFromInt()
		{
			byte[] data = ReadFile("Timestamps/Int");
			DateTime result = Unpack<DateTime>(data);
			Assert.AreEqual("2018-01-01T12:00:00.0000000+09:00", result.ToString("o"));
		}

		#endregion


		#region Options

		[Test]
		public void FromString()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.PackingFormat = DateTimePackingFormat.String;
			DateTime value = DateTime.Parse("2018-01-01T12:00:00.1234567+09:00");
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data);
			Assert.AreEqual(Format.Str8, data[0]);
			Assert.AreEqual(33, data[1]);
			Assert.AreEqual(35, data.Length);
			Assert.AreEqual(value.ToString("o"), result.ToString("o"));
		}

		[Test]
		public void FromString_OutOfBoundsHandling_Clamp_Lower()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.OutOfBoundsHandling = DateTimeOutOfBoundsHandling.Clamp;
			string value = "0000-01-01T00:00:00+0900";
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data, context);
			Assert.AreEqual(184, data[0]);
			Assert.AreEqual("0001-01-01T09:18:00.0000000+09:18", result.ToString("o"));
		}

		[Test]
		public void FromString_OutOfBoundsHandling_Clamp_Upper()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.OutOfBoundsHandling = DateTimeOutOfBoundsHandling.Clamp;
			string value = "10000-12-31T23:59:59.99999999-0900";
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data, context);
			Assert.AreEqual(Format.Str8, data[0]);
			Assert.AreEqual("9999-12-31T23:59:59.9999999+09:00", result.ToString("o"));
		}

		[Test]
		public void FromString_OutOfBoundsHandling_Clamp_Invalid_String()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.OutOfBoundsHandling = DateTimeOutOfBoundsHandling.Clamp;
			string value = "February 31, 2018 12:00:00 AM";
			byte[] data = Pack(value, context);
			var e = Assert.Throws<System.FormatException>(() => Unpack<DateTime>(data, context));
			Assert.AreEqual("String was not recognized as a valid DateTime.", e.Message);
		}

		[Test]
		public void FromString_OutOfBoundsHandling_Throw()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.OutOfBoundsHandling = DateTimeOutOfBoundsHandling.Throw;
			string value = "0000-01-01T00:00:00+0900";
			byte[] data = Pack(value, context);
			var e = Assert.Throws<System.FormatException>(() => Unpack<DateTime>(data, context));
			Assert.AreEqual("The DateTime represented by the string is not supported in calendar 0000-01-01T00:00:00+0900.", e.Message);
		}

		[Test]
		public void FromEpoch()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.PackingFormat = DateTimePackingFormat.Epoch;
			// only 3 digit precision due to loss of precision
			var value = DateTime.Parse("2018-01-01T12:00:00.123+09:00");
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data);
			Assert.AreEqual(Format.Float64, data[0]);
			Assert.AreEqual(9, data.Length);
			Assert.AreEqual(value.ToString("o"), result.ToString("o"));
		}

		[Test]
		public void ConvertToUniversalFromExt()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.ZoneConversion = DateTimeZoneConversion.Universal;
			var value = DateTime.Parse("2018-01-01T12:00:00+09:00");
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data, context);
			Assert.AreEqual("2018-01-01T03:00:00.0000000Z", result.ToString("o"));
		}

		[Test]
		public void ConvertToUniversalFromString()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.PackingFormat = DateTimePackingFormat.String;
			context.DateTimeOptions.ZoneConversion = DateTimeZoneConversion.Universal;
			var value = DateTime.Parse("2018-01-01T12:00:00+09:00");
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data, context);
			Assert.AreEqual("2018-01-01T03:00:00.0000000Z", result.ToString("o"));
		}

		[Test]
		public void ConvertToUniversalFromEpoch()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.PackingFormat = DateTimePackingFormat.Epoch;
			context.DateTimeOptions.ZoneConversion = DateTimeZoneConversion.Universal;
			var value = DateTime.Parse("2018-01-01T12:00:00+09:00");
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data, context);
			Assert.AreEqual("2018-01-01T03:00:00.0000000Z", result.ToString("o"));
		}

		[Test]
		public void ConvertToLocalFromExt()
		{
			var context = new SerializationContext();
			var value = DateTime.Parse("2018-01-01T03:00:00Z");
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data, context);
			Assert.AreEqual("2018-01-01T12:00:00.0000000+09:00", result.ToString("o"));
		}

		[Test]
		public void ConvertToLocalFromString()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.PackingFormat = DateTimePackingFormat.String;
			var value = DateTime.Parse("2018-01-01T03:00:00Z");
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data, context);
			Assert.AreEqual("2018-01-01T12:00:00.0000000+09:00", result.ToString("o"));
		}

		[Test]
		public void ConvertToLocalFromEpoch()
		{
			var context = new SerializationContext();
			context.DateTimeOptions.PackingFormat = DateTimePackingFormat.Epoch;
			var value = DateTime.Parse("2018-01-01T03:00:00Z");
			byte[] data = Pack(value, context);
			DateTime result = Unpack<DateTime>(data, context);
			Assert.AreEqual("2018-01-01T12:00:00.0000000+09:00", result.ToString("o"));
		}

		#endregion


		#region Validation

		[Test]
		public void CheckTicks()
		{
			var value = DateTime.Parse("2018-01-01 12:00:00.7654321+09:00").ToLocalTime();
			byte[] data = Pack(value);
			var result = Unpack<DateTime>(data);
			Assert.AreEqual(value, result);
		}

		#endregion
	}
}
