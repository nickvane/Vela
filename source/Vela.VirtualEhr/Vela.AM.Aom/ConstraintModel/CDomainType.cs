//-----------------------------------------------------------------------
// <copyright file="CDomainType.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using Vela.RM.Core.Support;

namespace Vela.AM.Aom.ConstraintModel
{
	/// <summary>
	/// Abstract parent type of domain-specific constrainer types, to be defined in external packages.
	/// </summary>
	[OpenEhrName("C_DOMAIN_TYPE")]
	public abstract class CDomainType<T> : CDefinedObject<T>
	{
		/// <summary>
		/// Standard (i.e. C_OBJECT) form of constraint.
		/// </summary>
		[OpenEhrName("standard_equivalent")]
		public CComplexObject StandardEquivalent { get; set; }
	}
}