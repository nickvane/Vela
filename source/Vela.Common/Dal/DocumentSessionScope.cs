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
		private bool _disposed;
		private readonly IDocumentSession _instance;
		private readonly DocumentSessionScope _parent;
		[ThreadStatic]
		private static DocumentSessionScope _head;

		///<summary>
		///</summary>
		///<exception cref="ArgumentNullException"></exception>
		public DocumentSessionScope(IDocumentSession session)
		{
			_instance = session;

			Thread.BeginThreadAffinity();
			_parent = _head;
			_head = this;
		}

		///<summary>
		///</summary>
		public static IDocumentSession Current
		{
			get { return _head != null ? _head._instance : null; }
		}


		~DocumentSessionScope()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);  // Finalization is now unnecessary

		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_instance.SaveChanges();
				}

				// Dispose unmanaged resources

				//WARNING: no dispose needed, but if needed, apparantly it is called in the incorrect order!!!
				_head = _parent;
				Thread.EndThreadAffinity();
			}

			_disposed = true;
		}
	}
}