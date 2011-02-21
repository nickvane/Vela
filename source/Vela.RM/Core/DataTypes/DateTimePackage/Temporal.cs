using System;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.DateTimePackage
{
	/// <summary>
	/// Specialised temporal variant of <see cref="AbsoluteQuantity{T,TA}"/> whose  diff type is <see cref="Duration"/>.
	/// </summary>
	[Serializable]
	[OpenEhrName("DV_TEMPORAL")]
	public abstract class Temporal<T, TA> : AbsoluteQuantity<T, TA>
		where T : Ordered<T>
		where TA : Amount<TA>
	{
	}
}
