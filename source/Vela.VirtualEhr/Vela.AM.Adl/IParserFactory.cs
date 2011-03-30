using Vela.RM.Core.Support.MeasurementPackage;

namespace Vela.AM.Adl
{
	/// <summary>
	/// Factory for the different archetype parsers. Support for adl en xml parser.
	/// </summary>
	public interface IParserFactory
	{
		/// <summary>
		/// Get the appropriate parser by evaluating the text of the archetype
		/// </summary>
		/// <param name="archetype">Text format of the archetype. This can be adl or xml.</param>
		/// <param name="measurementService"></param>
		/// <returns>An implementation of the archetype parser.</returns>
		IArchetypeParser GetArchetypeParser(string archetype, IMeasurementService measurementService);

		/// <summary>
		/// Get the appropriate parser by evaluating the text of the operational template
		/// </summary>
		/// <param name="template">Text format of the operational template. This can be adl or xml.</param>
		/// <param name="measurementService"></param>
		/// <returns>An implementation of the operational template parser.</returns>
		IOperationalTemplateParser GetOperationalTemplateParser(string template, IMeasurementService measurementService);
	}
}
