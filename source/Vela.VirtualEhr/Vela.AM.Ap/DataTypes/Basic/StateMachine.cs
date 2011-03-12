using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.Ap.DataTypes.Basic
{
	/// <summary>
	/// Definition of a state machine in terms of states, transition events and outputs, and next states.
	/// </summary>
	[OpenEhrName("STATE_MACHINE")]
	public class StateMachine
	{
		private IList<State> _states;

		/// <summary>
		/// 
		/// </summary>
		[OpenEhrName("states")]
		public IList<State> Type
		{
			get
			{
				return _states ?? (_states = new List<State>());
			}
		}
	}
}
