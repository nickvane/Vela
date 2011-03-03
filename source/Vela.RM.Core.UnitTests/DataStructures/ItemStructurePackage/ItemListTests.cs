using System.Collections.Generic;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.DataStructures.RepresentationPackage;
using Text = Vela.RM.Core.DataTypes.TextPackage.Text;

namespace Vela.RM.Core.UnitTests.DataStructures.ItemStructurePackage
{
	[TestFixture]
	public class WhenUsingItemList
	{
		[Test]
		public void DefaulPropertiesAndFunctionsShouldWork()
		{
			var name1 = "name1";
			var name2 = "name2";
			var name3 = "name3";
			var list = new ItemList();
			Assert.IsNotNull(list.Items);
			Assert.AreEqual(0, list.GetNames().Count);
			list.Items = new List<Element>() { new Element() { Name = new Text(name1) }, 
				new Element() { Name = new Text(name2) }, 
				new Element() { Name = new Text(name3) }};
			Assert.AreEqual(3, list.GetNames().Count);
			Assert.IsNotNull(list.GetNamedItem(name1));
			Assert.IsNotNull(list.GetNamedItem(name2));
			Assert.IsNotNull(list.GetNamedItem(name3));
			Assert.IsNull(list.GetNamedItem(""));
		}
	}
}
