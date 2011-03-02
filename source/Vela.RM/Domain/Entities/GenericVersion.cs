using Vela.RM.Core.DataTypes.DateTimePackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.Domain.Entities
{
	/// <summary>
	/// Container object that holds 1 specific version and the information about the VersionContainer the version belongs to.
	/// </summary>
	public class GenericVersion<T> : IGenericVersion<T>
	{
		/// <summary>
		/// Unique identifier of this version container. This id will be the same in all instances of the same container in a distributed environment, meaning that it can be understood as the uid of the “virtual version tree”.
		/// </summary>
		[OpenEhrName("uid")]
		public HierObjectId Uid { get; set; }

		/// <summary>
		/// Reference to object to which this version container belongs, e.g. the id of the containing EHR or other relevant owning entity.
		/// </summary>
		[OpenEhrName("owner_id")]
		public ObjectRef OwnerId { get; set; }

		/// <summary>
		/// Time of initial creation of this versioned object.
		/// </summary>
		[OpenEhrName("time_created")]
		public DateTime TimeCreated { get; set; }

		#region IGenericVersion<T> Members

		/// <summary>
		/// The specific version. This is either OriginalVersion or ImportedVersion
		/// </summary>
		public Version<T> Version { get; set; }

		/// <summary>
		/// Unique identifier of this version.
		/// </summary>
		public string Id
		{
			get { return (Version != null && Version.Uid != null) ? Version.Uid.Value : string.Empty; }
			set { if (Version != null && Version.Uid != null) Version.Uid.Value = value; }
		}

		#endregion
	}
}