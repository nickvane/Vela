//-----------------------------------------------------------------------
// <copyright file="Locatable.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.Common.ArchetypedPackage
{
	///<summary>
	/// Root class of all information model classes that can be archetyped.
	///</summary>
	[Serializable]
	[OpenEhrName("LOCATABLE")]
	public abstract class Locatable : Pathable
	{
		private string _pathSeparator = "/";

		///<summary>
		/// Runtime name of this fragment, used to build runtime paths. This is the term provided via a clinical application or batch process to name this EHR construct: its retention in the EHR faithfully preserves the original label by which this entry was known to end users.
		///</summary>
		[OpenEhrName("name")]
		public Text Name { get; set; }

		///<summary>
		/// Design-time archetype id of this node taken from its generating archetype; used to build archetype paths. Always in the form of an “at” code, e.g. “at0005”. 
		/// This value enables a "standardised" name for this node to be generated, by referring to the generating archetype local ontology.
		/// At an archetype root point, the value of this attribute is always the stringified form of the archetype_id found in the archetype_details object.
		///</summary>
		[OpenEhrName("archetype_node_id")]
		public string ArchetypeNodeId { get; set; }

		///<summary>
		/// Optional globally unique object identifier for root points of archetyped structures.
		///</summary>
		[OpenEhrName("uid")]
		public UIdBasedId Uid { get; set; }

		/// <summary>
		/// Details of archetyping used on this node.
		/// </summary>
		[OpenEhrName("archetype_details")]
		public Archetyped ArchetypeDetails { get; set; }

		/// <summary>
		/// Audit trail from non-openEHR system of original commit of information forming the content of this node, or from a conversion gateway which has synthesised this node.
		/// </summary>
		[OpenEhrName("feeder_audit")]
		public FeederAudit FeederAudit { get; set; }

		/// <summary>
		/// Links to other archetyped structures (data whose root object inherits from ARCHETYPED, such as ENTRY, SECTION and so on). Links may be to structures in other compositions.
		/// </summary>
		[OpenEhrName("links")]
		public IList<Link> Links { get; set; }

		///<summary>
		/// Clinical concept of the archetype as a whole (= derived from the ‘archetype_node_id’ of the root node)
		///</summary>
		[OpenEhrName("concept")]
		public Text Concept
		{
			get { throw new NotImplementedException(); }
		}

		///<summary>
		/// True if this node is the root of an archetyped structure.
		///</summary>
		[OpenEhrName("is_archetype_root")]
		public bool IsArchetypeRoot
		{
			get { throw new NotImplementedException(); }
		}
		
		///<summary>
		/// The path to an item relative to the root of this archetyped structure.
		///</summary>
		///<param name="item"></param>
		///<returns></returns>
		[OpenEhrName("path_of_item")]
		public override string GetPathOfItem(Pathable item)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// The item at a path (relative to this item); only valid for unique paths, i.e. paths that resolve to a single item.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		[OpenEhrName("item_at_path")]
		public override object GetItemAtPath(string path)
		{
			if (string.IsNullOrEmpty(path)) return null;
			if (path == _pathSeparator) return this;
			throw new NotImplementedException();
		}

		///<summary>
		/// List of items corresponding to a non-unique path.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		[OpenEhrName("items_at_path")]
		public override IList<object> GetItemsAtPath(string path)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// True if the path exists in the data with respect to the current item.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		[OpenEhrName("path_exists")]
		public override bool DoesPathExists(string path)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// True if the path corresponds to a single item in the data.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		[OpenEhrName("path_unique")]
		public override bool IsPathUnique(string path)
		{
			throw new NotImplementedException();
		}
	}
}