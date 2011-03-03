using Vela.Common.Dal.RavenDB;
using Vela.RM.Core.Common.ChangeControlPackage;
using Vela.RM.Core.DataTypes.DateTimePackage;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Domain.Entities
{
	public interface IGenericVersion<T> : IDocument
	{
		/// <summary>
		/// Unique identifier of this version container. This id will be the same in all instances of the same container in a distributed environment, meaning that it can be understood as the uid of the “virtual version tree”.
		/// </summary>
		HierObjectId Uid
		{
			get;
			set;
		}

		/// <summary>
		/// Reference to object to which this version container belongs, e.g. the id of the containing EHR or other relevant owning entity.
		/// </summary>
		ObjectRef OwnerId
		{
			get;
			set;
		}

		/// <summary>
		/// Time of initial creation of this version container.
		/// </summary>
		DateTime TimeCreated
		{
			get;
			set;
		}

		Version<T> Version { get; set; }
	}
}