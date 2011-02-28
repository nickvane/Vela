using System;
using NUnit.Framework;
using Uri = Vela.RM.Core.DataTypes.UriPackage.Uri;

namespace Vela.RM.UnitTests.Core.DataTypes.UriPackage
{
	[TestFixture]
	public class WhenUsingUri
	{
		const string Value = "test";

		[Test]
		public void ValueShouldBeSet()
		{
			var uri = new Uri(Value);
			Assert.AreEqual(Value, uri.Value);
		}

		[Test, ExpectedException(typeof(NotImplementedException))]
		public void SchemeIsNotImplementedYet()
		{
			var uri = new Uri(Value);
			var scheme = uri.Scheme;
		}

		[Test, ExpectedException(typeof(NotImplementedException))]
		public void PathIsNotImplementedYet()
		{
			var uri = new Uri(Value);
			var path = uri.Path;
		}

		[Test, ExpectedException(typeof(NotImplementedException))]
		public void FragmentIdIsNotImplementedYet()
		{
			var uri = new Uri(Value);
			var fragmentid = uri.FragmentId;
		}

		[Test, ExpectedException(typeof(NotImplementedException))]
		public void QueryIsNotImplementedYet()
		{
			var uri = new Uri(Value);
			var query = uri.Query;
		}
	}
}
