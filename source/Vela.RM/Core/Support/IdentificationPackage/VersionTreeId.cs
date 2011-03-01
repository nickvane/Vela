using System;
using Vela.Common.Helper;
using Vela.RM.Properties;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Version tree identifier for one version. Lexical form:
	/// trunk_version [ ‘.’ branch_number ‘.’ branch_version ]
	/// </summary>
	[Serializable, OpenEhrName("VERSION_TREE_ID")]
	public class VersionTreeId
	{
		private int _trunkVersion;
		private int? _branchNumber;
		private int? _branchVersion;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">value should be of format int.int.int</param>
		public VersionTreeId(string value)
		{
			Value = value;
		}

		///<summary>
		/// String form of this identifier.
		/// Format: trunk.branch.branchversion
		///</summary>
		[OpenEhrName("value")]
		public string Value
		{
			get
			{
				var value = _trunkVersion.ToString();
				if (_branchNumber.HasValue) value += "." + _branchNumber;
				if (_branchVersion.HasValue) value += "." + _branchVersion;
				return value;
			}
			set
			{
				var split = value.Split('.');
				if (split.Length > 0)
				{
					Assertion.WhenFalse("value", int.TryParse(split[0], out _trunkVersion));
					if (_trunkVersion < 1) throw new ArgumentException(Resources.InvalidTrunkVersion, value);
				}
				if (split.Length > 1)
				{
					int branchNumber;
					Assertion.WhenFalse("value", int.TryParse(split[1], out branchNumber));
					if (branchNumber < 1) throw new ArgumentException(Resources.InvalidBranchNumber, value);
					_branchNumber = branchNumber;
				}
				if (split.Length > 2)
				{
					int branchVersion;
					Assertion.WhenFalse("value", int.TryParse(split[2], out branchVersion));
					if (branchVersion < 1) throw new ArgumentException(Resources.InvalidBranchVersion, value);
					_branchVersion = branchVersion;
				}
			}
		}

		///<summary>
		/// Trunk version number; numbering starts at 1.
		///</summary>
		[OpenEhrName("trunk_version")]
		public int TrunkVersion
		{
			get
			{
				return _trunkVersion;
			}
		}

		///<summary>
		/// Number of branch from the trunk point; numbering starts at 1.
		///</summary>
		[OpenEhrName("branch_number")]
		public int? BranchNumber
		{
			get
			{
				return _branchNumber;
			}
		}

		///<summary>
		/// Version of the branch; numbering starts at 1.
		///</summary>
		[OpenEhrName("branch_version")]
		public int? BranchVersion
		{
			get
			{
				return _branchVersion;
			}
		}

		///<summary>
		/// True if this version identifier represents a branch, i.e. has branch_number and branch_version parts.
		///</summary>
		[OpenEhrName("is_branch")]
		public bool IsBranch
		{
			get
			{
				return _branchNumber.HasValue & _branchVersion.HasValue;
			}
		}

		///<summary>
		/// True if this version identifier corresponds to the first version, i.e. trunk_version = “1”
		///</summary>
		[OpenEhrName("is_first")]
		public bool IsFirst
		{
			get
			{
				return _trunkVersion == 1;
			}
		}
	}
}
