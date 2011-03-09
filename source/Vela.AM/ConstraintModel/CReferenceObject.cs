//-----------------------------------------------------------------------
// <copyright file="CReferenceObject.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Abstract parent type of C_OBJECT subtypes that are defined by reference.
	/// </summary>
	[OpenEhrName("C_REFERENCE_OBJECT")]
	public abstract class CReferenceObject : CObject
	{
	}
}