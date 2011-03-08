using System;
using System.Collections.Generic;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.AM.ConstraintModel
{
	public class CCodePhrase : CDomainType
	{
		private IList<string> _codeList	;

		public string CodeString
		{
			get;
			set;
		}

		public TerminologyId TerminologyId
		{
			get;
			set;
		}

		public IList<string> CodeList
		{
			get { return _codeList ?? (_codeList = new List<string>()); }
		}

		/// <summary>
		/// True if constraints represented by other are narrower than this node. Note: not easily evaluatable for CONSTRAINT_REF nodes.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public override bool IsSubsetOf(ArchetypeConstraint other)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if this node (and all its sub-nodes) is a valid archetype node for its type. This function should be implemented by each subtype to perform semantic validation of itself, and then call the is_valid function in any subparts, and generate the result appropriately
		/// </summary>
		/// <returns></returns>
		public override bool IsValid()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		/// <returns></returns>
		public override object DefaultValue()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if any value (i.e. instance) of the reference model type would be allowed. Redefined in descedants.
		/// </summary>
		public override bool AnyAllowed { get; set; }

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override bool IsValidValue(object value)
		{
			throw new NotImplementedException();
		}
	}
}
