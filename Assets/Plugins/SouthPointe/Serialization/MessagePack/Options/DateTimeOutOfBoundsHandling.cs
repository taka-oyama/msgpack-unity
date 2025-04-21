namespace SouthPointe.Serialization.MessagePack
{
	public enum DateTimeOutOfBoundsHandling
	{
		/// <summary>
		/// Throws an exception when the parsed date is out of bounds.
		/// </summary>
		Throw,

		/// <summary>
		/// Clamps the parsed date to the nearest valid date.
		/// </summary>
		Clamp,
	}
}
