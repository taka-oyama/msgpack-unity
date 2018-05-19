using System;
using NUnit.Framework;
using UnityEngine;


namespace SouthPointe.Serialization.MessagePack.Tests
{
	public class NamingStrategyTest : TestBase
	{
		[Serializable] class PascalMap { public string FirstNameFirst; }

		#region Default

		[Test]
		public void ToAndFromDefault()
		{
			var defaultContext = new SerializationContext();
			defaultContext.MapOptions.NamingStrategy = new DefaultNamingStrategy();

			var value = new PascalMap { FirstNameFirst = "abc" };
			var data = Pack(value, defaultContext);
			var result = Unpack<PascalMap>(data, defaultContext);

			Assert.AreEqual(value.FirstNameFirst, result.FirstNameFirst);
		}

		#endregion


		#region CamelCase

		[Serializable] class CamelMap { public string firstNameFirst; }

		[Test]
		public void ToCamelCaseMatched()
		{
			var camelCaseContext = new SerializationContext();
			camelCaseContext.MapOptions.NamingStrategy = new CamelCaseNamingStrategy();

			var value = new PascalMap { FirstNameFirst = "abc" };
			var data = Pack(value, camelCaseContext);
			var result = Unpack<CamelMap>(data);

			Assert.AreEqual(value.FirstNameFirst, result.firstNameFirst);
		}

		[Test]
		public void ToCamelCaseUnmatched()
		{
			var value = new CamelMap { firstNameFirst = "abc" };
			var data = Pack(value);
			var result = Unpack<PascalMap>(data);

			Assert.AreEqual(null, result.FirstNameFirst);
		}

		[Test]
		public void FromCamelCaseMatched()
		{
			var camelCaseContext = new SerializationContext();
			camelCaseContext.MapOptions.NamingStrategy = new CamelCaseNamingStrategy();

			var value = new CamelMap { firstNameFirst = "abc" };
			var data = Pack(value);
			var result = Unpack<PascalMap>(data, camelCaseContext);

			Assert.AreEqual(value.firstNameFirst, result.FirstNameFirst);
		}

		[Test]
		public void FromCamelCaseUnmatched()
		{
			var value = new CamelMap { firstNameFirst = "abc" };
			var data = Pack(value);
			var result = Unpack<PascalMap>(data);

			Assert.AreEqual(null, result.FirstNameFirst);
		}

		#endregion


		#region SnakeCase

		[Serializable] class SnakeMap { public string first_name_first; }

		[Test]
		public void ToSnakeCaseMatched()
		{
			var snakeCaseContext = new SerializationContext();
			snakeCaseContext.MapOptions.NamingStrategy = new SnakeCaseNamingStrategy();

			var value = new PascalMap { FirstNameFirst = "abc" };
			var data = Pack(value, snakeCaseContext);
			var result = Unpack<SnakeMap>(data);

			Assert.AreEqual(value.FirstNameFirst, result.first_name_first);
		}

		[Test]
		public void ToSnakeCaseUnmatched()
		{
			var value = new SnakeMap { first_name_first = "abc" };
			var data = Pack(value);
			var result = Unpack<PascalMap>(data);

			Assert.AreEqual(null, result.FirstNameFirst);
		}

		[Test]
		public void FromSnakeCaseMatched()
		{
			var snakeCaseContext = new SerializationContext();
			snakeCaseContext.MapOptions.NamingStrategy = new SnakeCaseNamingStrategy();

			var value = new SnakeMap { first_name_first = "abc" };
			var data = Pack(value);
			var result = Unpack<PascalMap>(data, snakeCaseContext);

			Assert.AreEqual(value.first_name_first, result.FirstNameFirst);
		}

		[Test]
		public void FromSnakeCaseUnmatched()
		{
			var value = new SnakeMap { first_name_first = "abc" };
			var data = Pack(value);
			var result = Unpack<PascalMap>(data);

			Assert.AreEqual(null, result.FirstNameFirst);
		}

		#endregion
	}
}
