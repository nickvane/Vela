//-----------------------------------------------------------------------
// <copyright file="TimeSpecification.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.DataTypes.EncapsulatedPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.TimeSpecificationPackage
{
	///<summary>
	/// This is an abstract class of which all timing specifications are specialisations. Specifies points in time, possibly linked to the calendar, or a real world repeating event, such as “breakfast”.
	///</summary>
	[Serializable]
	[OpenEhrName("DV_TIME_SPECIFICATION")]
	public abstract class TimeSpecification : DataValue
	{
		///<summary>
		/// the specification, in the HL7v3 syntax for PIVL or EIVL types. See below.
		///</summary>
		[OpenEhrName("value")]
		public Parsable Value
		{
			get;
			set;
		}

		/// <summary>
		/// Indicates what prototypical point in the calendar the specification is aligned to, e.g. “5th of the month”. Empty if not aligned. Extracted from the ‘value’ attribute.
		/// </summary>
		[OpenEhrName("calendar_alignment")]
		public abstract string GetCalendarAlignment();

		/// <summary>
		/// Indicates what real-world event the specification is aligned to if any. Extracted from the ‘value’ attribute.
		/// </summary>
		[OpenEhrName("event_alignment")]
		public abstract string GetEventAlignment();

		/// <summary>
		/// Indicates if the specification is aligned with institution schedules, e.g. a hospital nursing changeover or meal serving times. Extracted from the ‘value’ attribute.
		/// </summary>
		[OpenEhrName("institution_specified")]
		public abstract bool IsInstitutionSpecified();
	}
}