using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.Ap.DataTypes.Basic
{
	/// <summary>
	/// Definition of a non-terminal state in a state machine, i.e. one that has transitions
	/// </summary>
	[OpenEhrName("NON_TERMINAL_STATE")]
	public class NonTerminalState : State
	{
		private IList<Transition> _transitions;

		/// <summary>
		/// 
		/// </summary>
		[OpenEhrName("transitions")]
		public IList<Transition> Transitions
		{
			get { return _transitions ?? (_transitions = new List<Transition>()); }
		}
	}
}
