using System.Collections.Generic;

namespace Vela.SM.ArchetypeService
{
	public class ReferenceModelInfo
	{
		private IDictionary<string, string> _properties;
		public string ClassName { get; set; }
		public IDictionary<string, string> Properties { get { return _properties ?? (_properties = new Dictionary<string, string>()); } }
	}
}
