using System;
using Vela.RM.Core.Properties;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	///<summary>
	/// Identifier for parties in a demographic or identity service. There are typically a number of subtypes of the PARTY class, including PERSON, ORGANISATION, etc. Abstract supertypes are allowed if the referenced object is of a type not known by the current implementation of this class (in other words, if the demographic model is changed by the addition of a new  PARTY or  ACTOR subtypes, valid PARTY_REFs can still be constructed to them).
	///</summary>
	[Serializable, OpenEhrName("PARTY_REF")]
	public class PartyRef : ObjectRef
	{
		/// <summary>
		/// Name of the class (concrete or abstract) of object to which this identifier type refers, e.g. “PARTY”, “PERSON”, “GUIDELINE” etc. These class names are from the relevant reference model. The type name “ANY” can be used to indicate that any type is accepted (e.g. if the type is unknown).
		/// Type must be “PERSON”, “ORGANISATION”, “GROUP”, “AGENT”, “ROLE”, “PARTY” or “ACTOR”.
		/// </summary>
		[OpenEhrName("type")]
		public override string Type
		{
			get
			{
				return base.Type;
			}
			set
			{
				RefType type;
				if (!Enum.TryParse(value, true, out type))
				{
					throw new ArgumentException(string.Format(Resources.InvalidType, value, this.GetType().Name), "value");
				}
				switch (type)
				{
					case RefType.PERSON:
					case RefType.ORGANISATION:
					case RefType.GROUP:
					case RefType.AGENT:
					case RefType.ROLE:
					case RefType.PARTY:
					case RefType.ACTOR:
						base.Type = value;
						break;
					default:
						throw new ArgumentException(string.Format(Resources.InvalidType, value, this.GetType().Name), "value");
				}
			}
		}
	}
}
