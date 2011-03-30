using Vela.AM.Aom.ConstraintModel;
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
	public class TComplexObject : CComplexObject
	{
		public new object DefaultValue { get; set; }
	}
}