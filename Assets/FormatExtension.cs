namespace UniMsgPack
{
	public static class FormatExtension
	{
		public static bool Between(this Format target, Format min, Format max)
		{
			return target >= min && target <= max;
		}

		public static bool IsInt(this Format format)
		{
			return
				format.Between(Format.PositiveFixIntMin, Format.PositiveFixIntMax) ||
				format.Between(Format.NegativeFixIntMin, Format.NegativeFixIntMax) ||
				format == Format.Int8 ||
				format == Format.UInt8 ||
				format == Format.Int16 ||
				format == Format.UInt16 ||
				format == Format.Int32 ||
				format == Format.UInt32;
		}

		public static bool IsString(this Format format)
		{
			return
				format.Between(Format.FixStrMin, Format.FixStrMax) ||
				format == Format.Str8 ||
				format == Format.Str16 ||
				format == Format.Str32;
		}
	}
}
