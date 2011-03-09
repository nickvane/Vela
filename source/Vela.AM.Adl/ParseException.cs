//-----------------------------------------------------------------------
// <copyright file="ParseException.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;

namespace Vela.AM.Adl
{
	public class ParseException : Exception
	{
		public ParseException(string message) : base(message)
		{
			
		}
	}
}