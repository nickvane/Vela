//-----------------------------------------------------------------------
// <copyright file="Evaluation.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// Entry type for evaluation statements.
	/// Used for all kinds of statements which evaluate other information, such as interpretations of obvservations, diagnoses, differential  diagnoses, hypotheses, risk assessments, goals and plans.
	/// Should not be used for actionable statements such as medication orders - these are represented using the <see cref="Instruction"/> type.
	/// </summary>
	[Serializable]
	[OpenEhrName("EVALUATION")]
	public class Evaluation : CareEntry
	{
		/// <summary>
		/// The data of this evaluation, in the form of a spatial data structure.
		/// </summary>
		[OpenEhrName("data")]
		public ItemStructure Data { get; set; }
	}
}