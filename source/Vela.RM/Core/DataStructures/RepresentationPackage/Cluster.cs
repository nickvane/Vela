﻿using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataStructures.RepresentationPackage
{
	/// <summary>
	/// The grouping variant of <see cref="Item"/>, which may contain further instances of <see cref="Item"/>, in an ordered list.
	/// </summary>
	[Serializable]
	[OpenEhrName("CLUSTER")]
	public class Cluster : Item
	{
		/// <summary>
		/// Ordered list of items - <see cref="Cluster"/> or <see cref="Cluster"/> objects - under this <see cref="Element"/>.
		/// </summary>
		[OpenEhrName("items")]
		public IList<Item> Items { get; set; }
	}
}
