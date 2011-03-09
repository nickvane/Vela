//-----------------------------------------------------------------------
// <copyright file="OpenEhrNameAttribute.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;

namespace Vela.RM.Core.Support
{
	/// <summary>
	/// Description of OpenEhrNameAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public sealed class OpenEhrNameAttribute : Attribute
	{
		public OpenEhrNameAttribute(string name)
		{
			Name = name;
		}

		public string Name
		{
			get;
			set;
		}
	}

}