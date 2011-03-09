//-----------------------------------------------------------------------
// <copyright file="State.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.BasicPackage
{
	/// <summary>
	/// For representing state values which obey a defined state machine, such as a variable representing the states of an instruction or care process.
	/// USE: State is expressed as a string but its values are driven by archetypedefined state machines. This provides a powerful way of capturing stateful complex processes in simple data.
	/// </summary>
	[Serializable, OpenEhrName("DV_STATE")]
	public class State : DataValue
	{
		/// <summary>
		/// The state name. State names are determined by a state/event table defined in archetypes, and coded using openEHR Terminology or local archetype terms, as specified by the archetype.
		/// </summary>
		[OpenEhrName("value")]
		public CodedText Value
		{
			get;
			set;
		}

		/// <summary>
		/// Indicates whether this state is a terminal state, such as “aborted”, “completed” etc from which no further transitions are possible.
		/// </summary>
		[OpenEhrName("is_terminal")]
		public bool IsTerminal
		{
			get;
			set;
		}
	}
}