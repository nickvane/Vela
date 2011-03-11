using Vela.RM.Core.Support;

namespace Vela.AM.Ap.DataTypes.Basic
{
	/// <summary>
	/// Constrainer type for  DV_STATE instances. The attribute  c_value defines a state/event table which constrains the allowed values of the attribute value in a DV_STATE instance, as well as the order of transitions between values.
	/// </summary>
	[OpenEhrName("C_DV_STATE")]
	public class CState
	{
		/// <summary>
		/// 
		/// </summary>
		[OpenEhrName("value")]
		public StateMachine Value { get; set; }
	}
}
