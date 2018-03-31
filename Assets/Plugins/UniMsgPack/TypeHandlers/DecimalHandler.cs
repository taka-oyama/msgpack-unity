using UnityEngine;

namespace UniMsgPack
{
	public class DecimalHandler : ITypeHandler
	{
		ITypeHandler intArrayHandler;

		public object Read(Format format, FormatReader reader)
		{
			intArrayHandler = intArrayHandler ?? TypeHandlers.Resolve(typeof(int[]));
			int[] bits = (int[])intArrayHandler.Read(format, reader);
			return new decimal(bits);
		}

		public void Write(object obj, FormatWriter writer)
		{
			intArrayHandler = intArrayHandler ?? TypeHandlers.Resolve(typeof(int[]));
			int[] bits = decimal.GetBits((decimal)obj);
			intArrayHandler.Write(bits, writer);
		}
	}
}
