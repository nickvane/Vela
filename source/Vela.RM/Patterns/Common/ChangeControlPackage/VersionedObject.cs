using System;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Patterns.Common.ChangeControlPackage
{
	///<summary>
	/// Version control abstraction, defining semantics for versioning one complex object.
	///</summary>
	///<typeparam name="T"></typeparam>
	[Serializable]
	[OpenEhrName("VERSIONED_OBJECT<T>")]
	public class VersionedObject<T>
	{
		/// <summary>
		/// Unique identifier of this version container. This id will be the same in all instances of the same container in a distributed environment, meaning that it can be understood as the uid of the “virtual version tree”.
		/// </summary>
		[OpenEhrName("uid")]
		public HierObjectId Uid
		{
			get;
			set;
		}

		/// <summary>
		/// Reference to object to which this version container belongs, e.g. the id of the containing EHR or other relevant owning entity.
		/// </summary>
		[OpenEhrName("owner_id")]
		public ObjectRef OwnerId
		{
			get;
			set;
		}

		/// <summary>
		/// Time of initial creation of this versioned object.
		/// </summary>
		[OpenEhrName("time_created")]
		public DateTime TimeCreated
		{
			get;
			set;
		}
	}
}
