using System.Linq;
using Raven.Client;
using Vela.Common.Helper;

namespace Vela.Common.Dal.RavenDB
{
	public class RavenRepository<T> : IRavenRepository<T> where T : class, IDocument
	{
		private readonly IQueryable<T> _collection;

		public RavenRepository(IDocumentSession session, IQueryable<T> collection)
		{
			Assertion.WhenNull(session);
			DocumentSession = session;
			_collection = collection;
		}

		/// <summary>
		/// 
		/// </summary>
		public IDocumentSession DocumentSession { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IQueryable<T> Collection
		{
			get { return _collection ?? DocumentSession.Query<T>(); }
		}

		/// <summary>
		/// Gets the entity with the specified id.
		/// </summary>        
		/// <returns>Found object from the database, or an empty(default) one if not found.</returns>
		public T this[string id]
		{
			get { return string.IsNullOrEmpty(id) ? null : DocumentSession.Load<T>(id); }
		}

		/// <summary>
		/// Adds an item to the collection.
		/// </summary>
		/// <param name="item">The object to add to the collection.</param>
		public void Store(T item)
		{
			DocumentSession.Store(item);
		}

		/// <summary>
		/// Determines whether the collection contains a specific value.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is found in the collection; otherwise, false.
		/// </returns>
		/// <param name="item">The object to locate in the collection.</param>
		public bool Contains(T item)
		{
			if (item == null) return false;
			return this[item.Id] != null;
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the collection.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the collection; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original Collection.
		/// </returns>
		/// <param name="item">The object to remove from the collection.</param>
		public bool Delete(T item)
		{
			DocumentSession.Delete(item);
			return true;
		}

		/// <summary>
		/// Gets the number of elements contained in the collection.
		/// </summary>
		/// <returns>
		/// The number of elements contained in the collection.
		/// </returns>
		public int Count
		{
			get
			{
				return Collection.Count();
			}
		}
	}
}