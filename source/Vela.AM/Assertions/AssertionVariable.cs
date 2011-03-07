using Vela.RM.Core.Support;

namespace Vela.AM.Assertions
{
	/// <summary>
	/// Definition of a named variable used in an assertion expression. Note: the definition of named variables may change; still under development in ADL2.
	/// </summary>
	[OpenEhrName("ASSERTION_VARIABLE")]
	public class AssertionVariable
	{
		/// <summary>
		/// Name of variable.
		/// </summary>
		[OpenEhrName("name")]
		public string Name { get; set; }

		/// <summary>
		/// Formal definition of the variable. (see ADL2 specification; still under development).
		/// </summary>
		[OpenEhrName("definition")]
		public string Definition { get; set; }
	}
}