using System;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Class describing a reference to another object, which may exist locally or be maintained outside the current namespace,  e.g. in another service. Services are usually external, e.g. available in a LAN (including on the same host) or the internet via Corba, SOAP, or some other distributed protocol. However, in small systems they may be part of the same executable as the data containing the Id.
	/// </summary>
	[Serializable, OpenEhrName("OBJECT_REF")]
	public class ObjectRef
	{
		/// <summary>
		/// Globally unique id of an object, regardless of where it is stored.
		/// </summary>
		[OpenEhrName("id")]
		public ObjectId Id
		{
			get;
			set;
		}
		/// <summary>
		/// Namespace to which this identifier belongs in the local system context (and possibly in any other openEHR compliant environment) e.g. “terminology”, “demographic”. These names are not yet standardised. Legal values for the namespace are “local” | “unknown” | “[a-zA-Z][a-zA-Z0-9_-:/&+?]*”
		/// </summary>
		[OpenEhrName("namespace")]
		public virtual string Namespace
		{
			get;
			set;
		}
		/// <summary>
		/// Name of the class (concrete or abstract) of object to which this identifier type refers, e.g. “PARTY”, “PERSON”, “GUIDELINE” etc. These class names are from the relevant reference model. The type name “ANY” can be used to indicate that any type is accepted (e.g. if the type is unknown).
		/// </summary>
		[OpenEhrName("type")]
		public virtual string Type
		{
			get;
			set;
		}
	}
}
