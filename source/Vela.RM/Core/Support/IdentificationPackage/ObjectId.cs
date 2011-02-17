using System;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	///<summary>
	/// Ancestor class of identifiers of informational objects. Ids may be completely meaningless, in which case their only job  is to refer to something, or may carry some information to do with the identified object.
	/// Object ids are used inside an object to identify that object. To identify another object in another service, use an OBJECT_REF, or else use a UID for local objects identified by UID. If none of the subtypes is suitable, direct instances of this class may be used.
	///</summary>
	[Serializable, OpenEhrName("OBJECT_ID")]
	public abstract class ObjectId : Uid
	{
		private string _value;

		protected ObjectId(string value)
			: base(value)
		{
		}

		///<summary>
		/// The value of the id in the form defined below.
		///</summary>
		[OpenEhrName("value")]
		public override string Value
		{
			get;
			set;
		}
	}
}
