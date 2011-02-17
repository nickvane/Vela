using System;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	///<summary>
	/// Concrete type corresponding to hierarchical identifiers of the form defined by <see cref="UIdBasedId"/>.
	///</summary>
	[Serializable, OpenEhrName("HIER_OBJECT_ID")]
	public class HierObjectId : UIdBasedId
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">should be of format guid::string</param>
		public HierObjectId(string value)
			: base(value)
		{
		}
	}
}
