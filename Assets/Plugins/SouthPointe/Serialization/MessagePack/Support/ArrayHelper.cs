using System;
using UnityEngine;

public static class ArrayHelper
{
	public static void ResizeAccordingly(ref byte[] buffer, int length)
	{
		if(buffer.Length < length) {
			int newSize = buffer.Length;
			while(newSize < length) {
				newSize *= 2;
			}
			Array.Resize(ref buffer, newSize);
		}
	}
}
