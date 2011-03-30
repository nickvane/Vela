//-----------------------------------------------------------------------
// <copyright file="IMeasurementService.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

namespace Vela.RM.Core.Support.MeasurementPackage
{
	/// <summary>
	/// Defines an object providing proxy access to a measurement information service.
	/// </summary>
	[OpenEhrName("MEASUREMENT_SERVICE")]
	public interface IMeasurementService
	{
		/// <summary>
		/// True if the units string ‘units’ is a valid string according to the HL7 UCUM specification.
		/// </summary>
		/// <param name="units"></param>
		/// <returns></returns>
		[OpenEhrName("is_valid_units_string")]
		bool IsValidUnitsString(string units);

		/// <summary>
		/// True if two units strings correspond to the same measured property.
		/// </summary>
		/// <param name="unit1"></param>
		/// <param name="unit2"></param>
		/// <returns></returns>
		[OpenEhrName("units_equivalent")]
		bool AreEquivalentUnits(string unit1, string unit2);
	}
}