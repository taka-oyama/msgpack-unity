using System.Globalization;

namespace SouthPointe.Serialization.MessagePack
{
	public class DateTimeOptions
	{
		/// <summary>
		/// The packing format for DateTime format. Available formats are...
		/// Extension: packs using extension format defined in spec.
		/// String: packs in ISO8601 formatted string.
		/// Epoch: packs as Unix Epoch Time using double.
		/// Defaults to `Extension` format.
		/// </summary>
		public DateTimePackingFormat PackingFormat = DateTimePackingFormat.Extension;

		/// <summary>
		/// The zone conversion for DateTime format.
		/// </summary>
		public DateTimeZoneConversion ZoneConversion = DateTimeZoneConversion.Local;

		/// <summary>
		/// The culture info for DateTime format.
		/// This is used when parsing DateTime from string.
		/// </summary>
		public CultureInfo Culture = CultureInfo.CurrentCulture;
		
		/// <summary>
		/// The out of bounds handling for DateTime format.
		/// This is used when parsing DateTime from string.
		/// </summary>
		public DateTimeOutOfBoundsHandling OutOfBoundsHandling = DateTimeOutOfBoundsHandling.Throw;
	}
}
