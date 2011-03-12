//-----------------------------------------------------------------------
// <copyright file="Paragraph.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.TextPackage
{
	/// <summary>
	/// A logical composite text value consisting of a series of DV_TEXTs, i.e. plain text (optionally coded) potentially with simple formatting, to form a larger tract of prose, which may be interpreted for display purposes as a paragraph.
	/// USE: DV_PARAGRAPH is the standard way for constructing longer text items in summaries, reports and so on.
	/// </summary>
	[Serializable, OpenEhrName("DV_PARAGRAPH")]
	public class Paragraph : DataValue
	{
		private IList<Text> _items;

		/// <summary>
		/// Items making up the paragraph, each of which is a text item (which may have its own formatting, and/or have hyperlinks).
		/// </summary>
		[OpenEhrName("items")]
		public IList<Text> Items
		{
			get
			{
				return _items ?? (_items = new List<Text>());
			}
		}
	}
}