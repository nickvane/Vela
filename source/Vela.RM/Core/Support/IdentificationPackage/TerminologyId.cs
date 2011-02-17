using System;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Identifier for terminologies such accessed via a terminology query service. In this class, the value attribute identifies the Terminology in the  terminology service, e.g. “SNOMED-CT”. A terminology is assumed to be in a particular language, which must be explicitly specified.
	/// The value if the id attribute is the precise terminology id identifier, including actual release (i.e. actual “version”), local modifications etc; e.g. “ICPC2”.
	/// Lexical form: name [ ‘(’ version ‘)’ ]
	/// </summary>
	[Serializable, OpenEhrName("TERMINOLOGY_ID")]
	public class TerminologyId : ObjectId
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <remarks>
		/// The syntax of the value attribute is as follows:
		///		name [ ‘(’ version ‘)’ ]
		///	Examples of terminology identifiers include:
		///		• “snomed-ct”
		///		• “ICD9(1999)”
		/// </remarks>
		public TerminologyId(string value)
			: base(value)
		{
		}

		[OpenEhrName("value")]
		public override string Value
		{
			get
			{
				var value = Name;
				if (!string.IsNullOrEmpty(VersionId)) value += "(" + VersionId + ")";
				return value;
			}
			set
			{
				var splitIndex = value.IndexOf('(');
				if (splitIndex > -1)
				{
					var split = value.Split('(');
					Name = split[0];
					VersionId = split[1].TrimEnd(')');
				}
				else
				{
					Name = value;
					VersionId = string.Empty;
				}
			}
		}

		///<summary>
		/// Return the terminology id (which includes the “version” in some cases). Distinct names correspond to distinct (i.e. non-compatible) terminologies. Thus the names “ICD10AM” and “ICD10” refer to distinct terminologies.
		///</summary>
		[OpenEhrName("name")]
		public string Name
		{
			get;
			set;
		}
		///<summary>
		/// Version of this terminology, if versioning supported, else the empty string.
		///</summary>
		[OpenEhrName("version_id")]
		public string VersionId
		{
			get;
			set;
		}
	}
}
