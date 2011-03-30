//-----------------------------------------------------------------------
// <copyright file="IDocument.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

namespace Vela.Common
{
	public interface IDocument
	{
		string Id { get; set; }
		bool IsDeleted { get; set; }
	}
}