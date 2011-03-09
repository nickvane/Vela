//-----------------------------------------------------------------------
// <copyright file="IDocument.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

namespace Vela.Common.Dal.RavenDB
{
	public interface IDocument
	{
		string Id { get; set; }
	}
}