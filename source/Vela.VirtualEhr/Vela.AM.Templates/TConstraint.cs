using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.Templates
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// This class is not part of the 1.0.2 specifications. It is still a work in progress, see http://www.openehr.org/wiki/display/spec/openEHR+Templates+and+Specialised+Archetypes
	/// </remarks>
	[OpenEhrName("")]
	public class TConstraint
	{
		private IList<TAttribute> _attributes;

		/// <summary>
		/// 
		/// </summary>
		[OpenEhrName("attributes")]
		public IList<TAttribute> Attributes { get { return _attributes ?? (_attributes = new List<TAttribute>()); }}
	}
}