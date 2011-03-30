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
	public class TView
	{
		private IList<TViewConstraint> _constraints;

		public IList<TViewConstraint> Constraints { get { return _constraints ?? (_constraints = new List<TViewConstraint>()); }}
	}
}