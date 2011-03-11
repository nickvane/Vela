using Vela.RM.Core.Support;

namespace Vela.AM.Ap.DataTypes.Basic
{
	/// <summary>
	/// Abstract definition of one state in a state machine
	/// </summary>
	[OpenEhrName("STATE")]
	public class State
	{
		/// <summary>
		/// name of this state
		/// </summary>
		[OpenEhrName("name")]
		public string Name { get; set; }
	}
}
