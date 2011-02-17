using System;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	///<summary>
	/// Reference to a LOCATABLE instance inside the top-level content structure inside a VERSION{T}; the path attribute is applied to the object that VERSION.data points to.
	///</summary>
	[Serializable, OpenEhrName("LOCATABLE_REF")]
	public class LocatableRef : ObjectRef
	{
		///<summary>
		/// The identifier of the Version.
		///</summary>
		[OpenEhrName("id")]
		public new ObjectVersionId Id
		{
			get;
			set;
		}

		/// <summary>
		/// The path to an instance in question, as an absolute path with respect to the object found at VERSION.data. An empty path means that the object referred to by id being specified.
		/// </summary>
		[OpenEhrName("path")]
		public string Path
		{
			get;
			set;
		}

		///<summary>
		/// A URI form of the reference, created by concatenating the following:
		/// “ehr://” + id.value + “/” + path
		///</summary>
		///<returns></returns>
		[OpenEhrName("as_uri")]
		public string ToUri()
		{
			return "ehr://" + Id.Value + "/" + Path;
		}
	}
}
