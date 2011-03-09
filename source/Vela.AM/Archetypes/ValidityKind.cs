//-----------------------------------------------------------------------
// <copyright file="ValidityKind.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using Vela.RM.Core.Support;

namespace Vela.AM.Archetypes
{
	/// <summary>
	/// An enumeration of three values which may commonly occur in constraint models.
	/// Use as the type of any attribute within this model, which expresses constraint on some attribute in a class in a reference model. For example to indicate validityof Date/Time fields.
	/// </summary>
	[OpenEhrName("VALIDITY_KIND")]
	public class ValidityKind
	{
		/// <summary>
		/// Constant to indicate mandatory presence of something
		/// </summary>
		[OpenEhrName("mandatory")]
		public const int Mandatory = 1001;

		/// <summary>
		/// Constant to indicate optional presence of something
		/// </summary>
		[OpenEhrName("optional")]
		public const int Optional = 1002;

		/// <summary>
		/// Constant to indicate disallowed presence of something
		/// </summary>
		[OpenEhrName("disallowed")]
		public const int Disallowed = 1003;
	}
}