using System;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataStructures.RepresentationPackage
{
	/// <summary>
	/// The leaf variant of <see cref="Item"/>, to which a <see cref="DataValue"/> instance is attached.
	/// </summary>
	[Serializable]
	[OpenEhrName("ITEM")]
	public class Element : Item
	{
		/// <summary>
		/// data value of this leaf
		/// </summary>
		[OpenEhrName("value")]
		public DataValue Value { get; set; }

		/// <summary>
		/// flavour of null value, e.g. indeterminate, not asked etc
		/// </summary>
		[OpenEhrName("null_flavour")]
		public CodedText NullFlavour { get; set; }

		/// <summary>
		/// True if value logically not known, e.g. if indeterminate, not asked etc.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_null")]
		public bool IsNull()
		{
			throw new NotImplementedException();
		}
	}
}
