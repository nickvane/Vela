using Vela.RM.Core.Support.MeasurementPackage;

namespace Vela.AM.Adl
{
	/// <summary>
	/// Factory for the different archetype parsers. Support for adl en xml parser.
	/// </summary>
	public class ParserFactory : IParserFactory
	{
		/// <summary>
		/// Get the appropriate parser by evaluating the text of the archetype
		/// </summary>
		/// <param name="archetype">Text format of the archetype. This can be adl or xml.</param>
		/// <param name="measurementService"></param>
		/// <returns>An implementation of the archetype parser.</returns>
		public IArchetypeParser GetArchetypeParser(string archetype, IMeasurementService measurementService)
		{
			//TODO: throw notimplementedexception for adl parser.
			return new ArchetypeXmlParser();
		}

		/// <summary>
		/// Get the appropriate parser by evaluating the text of the operational template
		/// </summary>
		/// <param name="template">Text format of the operational template. This can be adl or xml.</param>
		/// <param name="measurementService"></param>
		/// <returns>An implementation of the operational template parser.</returns>
		public IOperationalTemplateParser GetOperationalTemplateParser(string template, IMeasurementService measurementService)
		{
			return new OperationalTemplateXmlParser();
		}
	}
}
