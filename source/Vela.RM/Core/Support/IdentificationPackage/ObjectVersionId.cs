using System;
using Vela.RM.Properties;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Globally unique identifier for one version of a versioned object; lexical form:
	/// object_id ‘::’ creating_system_id ‘::’ version_tree_id
	/// </summary>
	[Serializable, OpenEhrName("OBJECT_VERSION_ID")]
	public class ObjectVersionId : UIdBasedId
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">should be of format object_id ‘::’ creating_system_id ‘::’ version_tree_id</param>
		public ObjectVersionId(string value)
			: base(value)
		{
		}

		/// <summary>
		/// Globally unique identifier for one version of a versioned object; lexical form: object_id ‘::’ creating_system_id ‘::’ version_tree_id
		/// </summary>
		[OpenEhrName("value")]
		public override string Value
		{
			get
			{
				return ObjectId.Value + "::" + CreatingSystemId.Value + "::" + VersionTreeId.Value;
			}
			set
			{
				var separator = new string[] { "::" };
				var split = value.Split(separator, StringSplitOptions.None);
				if (split.Length != 3) throw new ArgumentException(string.Format(Resources.InvalidObjectVersionId, value), "value");
				ObjectId = new UuId(split[0]);
				CreatingSystemId = new UuId(split[1]);
				VersionTreeId = new VersionTreeId(split[2]);
			}
		}

		/// <summary>
		/// Unique identifier for logical object of which this identifier identifies one version; normally the object_id will be the unique identifier of the version container containing the version referred to by this OBJECT_VERSION_ID instance.
		/// </summary>
		[OpenEhrName("object_id")]
		public UuId ObjectId
		{
			get;
			set;
		}

		/// <summary>
		/// Identifier of the system that created the Version corresponding to this Object version id.
		/// </summary>
		[OpenEhrName("creating_system_id")]
		public UuId CreatingSystemId
		{
			get;
			set;
		}

		/// <summary>
		/// Tree identifier of this version with respect to other versions in the same version tree, as either 1 or 3 part dot-separated numbers, e.g. “1”, “2.1.4”.
		/// </summary>
		[OpenEhrName("version_tree_id")]
		public VersionTreeId VersionTreeId
		{
			get;
			set;
		}

		/// <summary>
		/// True if this version identifier represents a branch.
		/// </summary>
		public bool IsBranch
		{
			get
			{
				return VersionTreeId != null && VersionTreeId.IsBranch;
			}
		}
	}
}
