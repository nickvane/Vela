//-----------------------------------------------------------------------
// <copyright file="DocumentSessionScope.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Threading;
using Raven.Client;

namespace Vela.Common.Dal
{
	/// <summary>
	/// A helper to use the IDocumentSession within a using statement
	/// </summary>
	/// <remarks>Reference: http://msdn.microsoft.com/en-us/magazine/cc300805.aspx</remarks>
	public class DocumentSessionScope : IDisposable
	{
		[ThreadStatic] private static DocumentSessionScope _head;
		private readonly IDocumentSession _instance;
		private bool _disposed;

		///<summary>
		///</summary>
		///<exception cref="ArgumentNullException"></exception>
		public DocumentSessionScope(IDocumentSession session)
		{
			_instance = session;

			Thread.BeginThreadAffinity();
			_head = this;
		}

		///<summary>
		///</summary>
		public static IDocumentSession Current
		{
			get
			{
				if (_head != null)
				{
					return _head._instance;
				}
				return null;
			}
		}

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this); // Finalization is now unnecessary
		}

		#endregion

		~DocumentSessionScope()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_instance.SaveChanges();
					_instance.Dispose();
				}

				// Dispose unmanaged resources

				//WARNING: no dispose needed, but if needed, apparantly it is called in the incorrect order!!!
				Thread.EndThreadAffinity();
			}

			_disposed = true;
		}
	}
}