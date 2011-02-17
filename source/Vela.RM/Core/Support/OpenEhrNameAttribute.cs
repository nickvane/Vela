using System;

namespace Vela.RM.Core.Support
{
	/// <summary>
	/// Description of OpenEhrNameAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class OpenEhrNameAttribute : Attribute
	{
		public OpenEhrNameAttribute(string name)
		{
			Name = name;
		}

		public string Name
		{
			get;
			set;
		}
	}

}
