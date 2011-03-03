using System.Collections.Generic;
using Vela.Common.Dal.RavenDB;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Domain.Ehr.EhrPackage
{
	/// <summary>
	/// The EHR object is the root object and access point of an EHR for a subject of care.
	/// </summary>
	[OpenEhrName("EHR")]
	public class EhrRoot : IDocument
	{
		private IList<ObjectRef> _contributions;
		private IList<ObjectRef> _compositions;

		/// <summary>
		/// The id of this EHR.
		/// </summary>
		[OpenEhrName("ehr_id")]
		public HierObjectId EhrId { get; set; }

		/// <summary>
		/// The id of the EHR system on which this EHR was created.
		/// </summary>
		[OpenEhrName("system_id")]
		public HierObjectId SystemId { get; set; }

		/// <summary>
		/// Time of creation of the EHR
		/// </summary>
		[OpenEhrName("time_created")]
		public DateTime TimeCreated { get; set; }

		/// <summary>
		/// Reference to EHR_ACCESS object for this EHR.
		/// </summary>
		[OpenEhrName("ehr_access")]
		public ObjectRef EhrAccess { get; set; }

		/// <summary>
		/// Reference to EHR_STATUS object for this EHR.
		/// </summary>
		[OpenEhrName("ehr_status")]
		public ObjectRef EhrStatus { get; set; }

		/// <summary>
		/// Optional directory structure for this EHR.
		/// </summary>
		[OpenEhrName("directory")]
		public ObjectRef Directory { get; set; }

		/// <summary>
		/// Master list of all composition references in this EHR
		/// </summary>
		[OpenEhrName("compositions")]
		public IList<ObjectRef> Compositions
		{
			get
			{
				return _compositions ?? (_compositions = new List<ObjectRef>());
			}
		}

		/// <summary>
		/// List of contributions causing changes to this EHR. Each contribution contains a list of versions, which may include references to any number of VERSION instances, i.e. items of type VERSIONED_COMPOSITION and VERSIONED_FOLDER.
		/// </summary>
		[OpenEhrName("contributions")]
		public IList<ObjectRef> Contributions
		{
			get
			{
				return _contributions ?? (_contributions = new List<ObjectRef>());
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Id
		{
			get { return EhrId != null ? EhrId.Value : string.Empty; }
			set { if (EhrId == null) EhrId = new HierObjectId(value); }
		}
	}
}