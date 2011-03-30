//-----------------------------------------------------------------------
// <copyright file="IBaseRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Linq;

namespace Vela.Common
{
	public interface IBaseRepository<T> where T : IDocument
	{
		/// <summary>
		/// 
		/// </summary>
		IQueryable<T> Collection { get; }

		/// <summary>
		/// Gets the entity with the specified id.
		/// </summary>        
		/// <returns>Found object from the database, or an empty(default) one if not found.</returns>
		T this[string id] { get; }

		/// <summary>
		/// Determines whether the collection contains a specific value.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is found in the collection; otherwise, false.
		/// </returns>
		/// <param name="item">The object to locate in the collection.</param>
		bool Contains(T item);

		/// <summary>
		/// Adds an item to the collection.
		/// </summary>
		/// <param name="item">The object to add to the collection.</param>
		void Save(T item);

		/// <summary>
		/// Removes the first occurrence of a specific object from the collection.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the collection; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original Collection.
		/// </returns>
		/// <param name="item">The object to remove from the collection.</param>
		bool Delete(T item);

		/// <summary>
		/// Gets the number of elements contained in the collection.
		/// </summary>
		/// <returns>
		/// The number of elements contained in the collection.
		/// </returns>
		int Count { get; }
	}
}