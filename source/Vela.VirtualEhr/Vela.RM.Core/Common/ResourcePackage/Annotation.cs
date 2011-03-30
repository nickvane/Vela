using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.Common.ResourcePackage
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// This class is not part of the 1.0.2 specifications. It is still a work in progress, see http://www.openehr.org/wiki/display/spec/openEHR+Templates+and+Specialised+Archetypes
	/// </remarks>
	[OpenEhrName("ANNOTATION")]
	public class Annotation
	{
		private IDictionary<string, string> _items;

		/// <summary>
		/// 
		/// </summary>
		[OpenEhrName("path")]
		public string Path { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[OpenEhrName("items")]
		public IDictionary<string, string> Items
		{
			get
			{
				return _items ?? (_items = new Dictionary<string, string>());
			}
		}
	}
}
