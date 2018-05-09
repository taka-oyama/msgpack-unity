using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class JsonConverterTest : TestBase
	{
		[Serializable]
		class Map
		{
			public int? a = 1;
			public float b = 1f;
			public int[] c = { 1, 2 };
			public string d = null;
			public bool e = true;
			public bool f = false;
		}

		[Test]
		public void MapAsJson()
		{
			var map = new Map();
			var data = Pack(map);
			var json = AsJson(data);

			Assert.AreEqual("{\"a\":1,\"b\":1,\"c\":[1,2],\"e\":true,\"f\":false}", json);
		}

		[Test]
		public void MapAsJsonWithNull()
		{
			var context = new SerializationContext();
			context.MapOptions.IgnoreNullOnPack = false;
			var map = new Map();
			var data = Pack(map, context);
			var json = AsJson(data);

			Assert.AreEqual("{\"a\":1,\"b\":1,\"c\":[1,2],\"d\":null,\"e\":true,\"f\":false}", json);
		}

		[Test]
		public void ArrayAsJson()
		{
			var array = new int[] { 1, 2, 3 };
			var data = Pack(array);
			var json = AsJson(data);

			Assert.AreEqual("[1,2,3]", json);
		}

		[Test]
		public void PrettyPrint()
		{
			var context = new SerializationContext();
			context.JsonOptions.PrettyPrint = true;
			context.JsonOptions.IndentationString = " ";
			var array = new int[] { 1, 2, 3 };
			var data = Pack(array);
			var json = AsJson(data, context);

			Assert.AreEqual("[\n 1,\n 2,\n 3\n]", json);
		}

		[Test]
		public void FormatError()
		{
			var array = new int[] { 1, 2, 3 };
			var data = Pack(array);
			var bytes = new List<byte>(data);
			bytes.Insert(2, Format.NeverUsed);

			Assert.Throws(typeof(FormatException), () => {
				try {
					AsJson(bytes.ToArray());
				}
				catch(Exception e) {
					Assert.AreEqual(e.Source, "[1,");
					throw;
				}
			});
		}
	}
}
