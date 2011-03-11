using Vela.RM.Core.Support;

namespace Vela.AM.Ap.DataTypes.Basic
{
	/// <summary>
	/// Definition of a state machine transition.
	/// </summary>
	[OpenEhrName("TRANSITION")]
	public class Transition
	{
		/// <summary>
		/// Event which fires this transition
		/// </summary>
		[OpenEhrName("event")]
		public string Event
		{
			get;
			set;
		}

		/// <summary>
		/// Guard condition which must be true for this transition to fire
		/// </summary>
		[OpenEhrName("guard")]
		public string Guard
		{
			get;
			set;
		}

		/// <summary>
		/// Side-effect action to execute during the firing of this transition
		/// </summary>
		[OpenEhrName("action")]
		public string Action
		{
			get;
			set;
		}

		/// <summary>
		/// Target state of transition
		/// </summary>
		[OpenEhrName("next_state")]
		public State NextState
		{
			get;
			set;
		}
	}
}
