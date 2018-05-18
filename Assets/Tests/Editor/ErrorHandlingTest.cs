using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Text;
using System;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class ErrorHandlingTest : TestBase
	{
		class DummyMap
		{
			public int abc = 1;
		}

		[Test]
		public void DeserializeWithPartialData()
		{
			try {
				List<byte> bytes = new List<byte>();
				bytes.Add(Format.FixMapMin + 2);
				bytes.Add(Format.FixStrMin + 3);
				bytes.AddRange(Encoding.ASCII.GetBytes("abc"));
				bytes.Add(Format.PositiveFixIntMin + 10);

				Unpack<DummyMap>(bytes.ToArray());
			}
			catch(Exception exception) {
				Assert.AreEqual("{\"abc\":10,", exception.Source);
				Assert.AreEqual("There is nothing more to read", exception.Message);
			}
		}

		[Test]
		public void DeserializeUnknownFormat()
		{
			try {
				List<byte> bytes = new List<byte>();
				bytes.Add(Format.FixMapMin + 2);
				bytes.Add(Format.FixStrMin + 3);
				bytes.AddRange(Encoding.ASCII.GetBytes("abc"));
				bytes.Add(Format.PositiveFixIntMin + 10);
				bytes.Add(Format.NeverUsed);

				Unpack<DummyMap>(bytes.ToArray());
			}
			catch(Exception exception) {
				Assert.AreEqual("{\"abc\":10,", exception.Source);
				Assert.AreEqual("Undefined Format 0xC1 at Position: 7", exception.Message);
			}
		}
	}
}
