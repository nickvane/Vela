using System;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Abstract model of UID-based identifiers consisting of a root part and an optional extension; lexical form:
	/// root::extension
	/// </summary>
	[Serializable, OpenEhrName("UID_BASED_ID")]
	public abstract class UIdBasedId : ObjectId
	{
		protected UIdBasedId(string value)
			: base(value)
		{
		}

		///<summary>
		/// The value of the id in the form defined below.
		///</summary>
		[OpenEhrName("value")]
		public override string Value
		{
			get
			{
				var value = Root.ToString();
				if (HasExtension) value += "::" + Extension;
				return value;
			}
			set
			{
				var splitIndex = value.IndexOf("::");
				if (splitIndex > -1)
				{
					Root = new UuId(value.Substring(0, splitIndex));
					Extension = value.Substring(splitIndex + 2, value.Length - splitIndex - 2);
				}
				else
				{
					Root = new UuId(value);
				}
			}
		}

		/// <summary>
		/// The identifier of the conceptual namespace in which the object exists, within the identification scheme. Returns the part to the left of the first ‘::’ separator, if any, or else the whole string.
		/// </summary>
		[OpenEhrName("root")]
		public virtual UuId Root
		{
			get;
			set;
		}
		/// <summary>
		/// Optional local identifier of the object within the context of the root identifier. Returns the part to the right of the first ‘::’ separator if any, or else any empty String.
		/// </summary>
		[OpenEhrName("extension")]
		public virtual string Extension
		{
			get;
			set;
		}
		/// <summary>
		/// True if extension /= Void
		/// </summary>
		[OpenEhrName("has_extension")]
		public bool HasExtension
		{
			get
			{
				return !string.IsNullOrEmpty(Extension);
			}
		}
	}
}
