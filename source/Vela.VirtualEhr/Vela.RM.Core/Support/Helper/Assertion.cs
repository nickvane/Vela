using System;
using System.Diagnostics;

namespace Vela.RM.Core.Support.Helper
{
	/// <summary>
	/// Provides access to assertion functions.
	/// </summary>
	//[DebuggerStepThrough]
	public static class Assertion
	{
		/// <summary>
		/// Asserts when a condition is false.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="condition">The condition result.</param>
		/// <exception cref="System.ArgumentException">If <code>condition</code> is false.</exception>
		public static void WhenFalse(string paramName, bool condition)
		{
			if (!condition)
				throw new ArgumentException(paramName);
		}

		/// <summary>
		/// Asserts when a condition is true.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="condition">The condition result.</param>
		/// <exception cref="System.ArgumentException">If <code>condition</code> is true.</exception>
		public static void WhenTrue(string paramName, bool condition)
		{
			if (condition)
				throw new ArgumentException(paramName);
		}

		/// <summary>
		/// Asserts that <code>value</code> is not null.
		/// </summary>
		/// <param name="paramName">The name of the parameter to assert.</param>
		/// <param name="value">The value to test.</param>
		/// <exception cref="System.ArgumentNullException">If <code>value</code> is null.</exception>
		public static void WhenNull(string paramName, object value)
		{
			if (value == null)
				throw new ArgumentNullException(paramName);
		}

		/// <summary>
		/// Asserts that <code>value</code> is not null.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <exception cref="System.ArgumentNullException">If <code>value</code> is null.</exception>
		public static void WhenNull(object value)
		{
			if (value == null)
				throw new ArgumentNullException();
		}

		/// <summary>
		/// Asserts that <code>value</code> is not empty.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="value">The value to test.</param>
		public static void WhenEmpty(string paramName, string value)
		{
			WhenEmpty(paramName, value, false);
		}

		/// <summary>
		/// Asserts that <code>value</code> is not empty.
		/// </summary>
		/// <param name="value">The value to test.</param>
		public static void WhenEmpty(string value)
		{
			WhenEmpty(null, value, false);
		}

		/// <summary>
		/// Asserts that <code>value</code> is not empty.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="trim">Whether to trim the string before checking it.</param>
		public static void WhenEmpty(string value, bool trim)
		{
			WhenEmpty(null, value, trim);
		}

		/// <summary>
		/// Asserts that <code>value</code> is not empty.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="value">The value to test.</param>
		/// <param name="trim">Whether to trim the string before checking it.</param>
		public static void WhenEmpty(string paramName, string value, bool trim)
		{
			if (string.IsNullOrEmpty(value) || (trim && string.IsNullOrWhiteSpace(value))) 
				throw new ArgumentException(paramName);
		}
	}
}