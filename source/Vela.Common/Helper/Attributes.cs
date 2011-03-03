using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Vela.Common.Helper
{
	/// <summary>
	/// Provides helper methods for attributes.
	/// </summary>
	public static class Attributes
	{
		/// <summary>
		/// Fetches the attributes for a type.
		/// </summary>
		/// <typeparam name="T">The attribute type to fetch.</typeparam>
		/// <param name="item">The item to fetch the attributes from.</param>
		/// <param name="inherit">When true, look up the hierarchy chain for the inherited custom attribute.</param>
		/// <returns>The attributes of type <code>T</code> defined on <code>type</code>.</returns>
		public static IList<T> GetAttributes<T>(this ICustomAttributeProvider item, bool inherit) where T : Attribute
		{
			if (item == null) throw new ArgumentNullException("item");
			return (from a in item.GetCustomAttributes(inherit)
					where a is T
					select a as T).ToList();
		}
	}
}