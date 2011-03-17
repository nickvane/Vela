using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Vela.RM.Core.Common.ArchetypedPackage;
using Vela.RM.Core.Support;

namespace Vela.SM.ArchetypeService
{
	public static class ReferenceModel
	{
		private const string Lock = "lock";
		private static IDictionary<string, ReferenceModelInfo> _classes;

		public static IDictionary<string, ReferenceModelInfo> Classes
		{
			get
			{
				if (_classes == null)
				{
					lock (Lock)
					{
						if (_classes == null)
						{
							_classes = new Dictionary<string, ReferenceModelInfo>();
							var assembly = typeof(Locatable).Assembly;
							var result = from t in assembly.GetTypes().AsQueryable()
							             where !string.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith("Vela.RM.Core")
							             where !t.IsAbstract
							             where t.IsPublic
							             where t.IsClass
										 where t.GetCustomAttributes(typeof(OpenEhrNameAttribute), false).Count() == 1
										 select new { Type = t, OpenEhrName = ((OpenEhrNameAttribute)t.GetCustomAttributes(typeof(OpenEhrNameAttribute), false).First()).Name };
							var types = result.ToList();
							foreach (var variable in types)
							{
								var referenceModelInfo = new ReferenceModelInfo
								                         	{ClassName = variable.Type.FullName};
								var properties = (from p in variable.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance).AsQueryable()
								                 where p.GetCustomAttributes(typeof (OpenEhrNameAttribute), false).Count() == 1
								                 select
								                 	new
								                 		{
								                 			PropertyName = p.Name,
								                 			OpenEhrName = ((OpenEhrNameAttribute) p.GetCustomAttributes(typeof (OpenEhrNameAttribute), false).First()).Name
								                 		}).ToList();
								foreach (var property in properties)
								{
									if (!referenceModelInfo.Properties.ContainsKey(property.OpenEhrName))
										referenceModelInfo.Properties.Add(property.OpenEhrName, property.PropertyName);
								}
								_classes.Add(variable.OpenEhrName, referenceModelInfo);
							}
						}
					}
				}
				return _classes;
			}
		}
	}
}