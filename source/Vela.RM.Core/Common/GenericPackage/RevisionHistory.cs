//-----------------------------------------------------------------------
// <copyright file="RevisionHistory.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.Common.GenericPackage
{
	///<summary>
	/// Defines the notion of a revision history of audit items, each associated with theversion for which that audit was committed. The list is in most-recent-first order.
	///</summary>
	[OpenEhrName("REVISION_HISTORY")]
	public class RevisionHistory
	{
		///<summary>
		/// The items in this history in most-recent-last order.
		///</summary>
		[OpenEhrName("items")]
		public IList<RevisionHistoryItem> Items { get; set; }

		/// <summary>
		/// The version id of the most recent item, as a String.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("most_recent_version")]
		public string GetMostRecentVersion()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// The commit date/time of the most recent item,  as a String.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("most_recent_version_time_committed")]
		public string GetCommittedTimeOfMostRecentVersion()
		{
			throw new NotImplementedException();
		}
	}
}