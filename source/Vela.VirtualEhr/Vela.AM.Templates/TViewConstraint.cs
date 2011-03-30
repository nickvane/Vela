using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.Templates
{
	/// <summary>
	/// 
	/// </summary>
	[OpenEhrName("")]
	public class TViewConstraint
	{
		private IDictionary<string, string> _items;

		public string Path { get; set; }
		public IDictionary<string, string> Items { get { return _items ?? (_items = new Dictionary<string, string>()); }}
	}
}