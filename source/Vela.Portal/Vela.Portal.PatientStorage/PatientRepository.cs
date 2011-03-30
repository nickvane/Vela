using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Vela.Portal.PatientStorage.Contracts;

namespace Vela.Portal.PatientStorage
{
	public class PatientRepository
	{
		public IEnumerable<Patient> GetPatients()
		{
			var text = new List<string>();
			using(var textStreamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Vela.Portal.PatientStorage.PatientData.txt")))
			{
				while (textStreamReader.Peek() != -1)
				{
					text.Add(textStreamReader.ReadLine());
				}
			}
			CultureInfo provider = CultureInfo.InvariantCulture;
			var result = new List<Patient>();
			foreach (var line in text)
			{
				var split = line.Split(',');
				var patient = new Patient
				              	{
				              		FirstName = split[0],
				              		LastName = split[1],
				              		BirthDate = DateTime.ParseExact(split[2], "yyyy-MM-dd", provider),
				              		PatientNumber = split[3],
				              		Gender = split[4] == "M" ? Gender.Male : Gender.Female
				              	};
				result.Add(patient);
			}
			return result;
		}
	}
}