using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using Vela.Common.Dal.LinqSpecs;
using Vela.Common.Helper;

namespace Vela.Common.Dal.RavenDb
{
	public class RavenRepository<T> : IRepository<T> where T : class, IDocument
	{
		private IQueryable<T> _collection;

		public RavenRepository(IDocumentSession session, IQueryable<T> collection)
		{
			Assertion.WhenNull(session);
			DocumentSession = session;
			_collection = collection;
		}

		/// <summary>
		/// 
		/// </summary>
		protected IDocumentSession DocumentSession { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IQueryable<T> Collection
		{
			get { return _collection ?? DocumentSession.Query<T>(); }
			set { _collection = value; }
		}

		/// <summary>
		/// Gets the entity with the specified id.
		/// </summary>        
		/// <returns>Found object from the database, or an empty(default) one if not found.</returns>
		public T this[string id]
		{
			get { return string.IsNullOrEmpty(id) ? null : DocumentSession.Load<T>(id); }
		}

		#region IRepository<T> Members

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public IEnumerator<T> GetEnumerator()
		{
			return Collection.Take(1000).GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
		public void Add(T item)
		{
			DocumentSession.Store(item);
		}

		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		public void Clear()
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
		/// </returns>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
		public bool Contains(T item)
		{
			if (item == null) return false;
			return this[item.Id] != null;
		}

		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.-or-The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.-or-Type <paramref name="T"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.</exception>
		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </returns>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
		public bool Remove(T item)
		{
			DocumentSession.Delete(item);
			return true;
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <returns>
		/// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </returns>
		public int Count
		{
			get
			{
				return Collection.Count();
			}
			private set { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
		/// </returns>
		public bool IsReadOnly
		{
			get { return false; }
		}

		#endregion

		///<summary>
		/// Find all by specification
		///</summary>
		///<param name="specification">A specification</param>
		///<returns></returns>
		public IEnumerable<T> FindAll(Specification<T> specification)
		{
			return GetQuery(specification);
		}

		///<summary>
		/// Find one by specification
		///</summary>
		///<param name="specification">A specification</param>
		///<returns></returns>
		public T FindOne(Specification<T> specification)
		{
			return GetQuery(specification).SingleOrDefault();
		}

		protected IQueryable<T> GetQuery(Specification<T> specification)
		{
			return Collection.Where(specification.IsSatisfiedBy());
		}
	}
}