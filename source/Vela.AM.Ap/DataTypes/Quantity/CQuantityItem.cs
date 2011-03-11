using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.Support;

namespace Vela.AM.Ap.DataTypes.Quantity
{
	/// <summary>
	/// Constrain instances of DV_QUANTITY.
	/// </summary>
	[OpenEhrName("C_QUANTITY_ITEM")]
	public class CQuantityItem
	{
		/// <summary>
		/// Constraint on units of the DV_QUANTITY.
		/// </summary>
		[OpenEhrName("units")]
		public string Units
		{
			get;
			set;
		}

		/// <summary>
		/// Constraint on the magnitude of the DV_QUANTITY.
		/// </summary>
		[OpenEhrName("magnitude")]
		public Interval<double> Magnitude { get; set; }

		/// <summary>
		/// Constraint on the precision of the DV_QUANTITY. A value of -1 means that precision is unconstrained.
		/// </summary>
		[OpenEhrName("precision")]
		public Interval<int> Precision
		{
			get;
			set;
		}
	}
}