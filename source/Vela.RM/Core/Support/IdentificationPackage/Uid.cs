using System;
using Vela.RM.Core.Support.Helper;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Abstract parent of classes representing unique identifiers which identify information entities in a durable way. UIDs only ever identify one IE in time or space and are never re-used.
	/// </summary>
	[Serializable, OpenEhrName("UID")]
	public abstract class Uid
	{
		protected Uid(){}

		protected Uid(string value)
		{
			Assertion.WhenNull(value);
			// ReSharper disable DoNotCallOverridableMethodsInConstructor
			Value = value;
			// ReSharper restore DoNotCallOverridableMethodsInConstructor
		}

		/// <summary>
		/// The value of the id.
		/// </summary>
		[OpenEhrName("value")]
		public abstract string Value
		{
			get;
			set;
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
