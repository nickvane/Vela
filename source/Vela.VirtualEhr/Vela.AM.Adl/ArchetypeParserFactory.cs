namespace Vela.AM.Adl
{
	/// <summary>
	/// Factory for the different archetype parsers. Support for adl en xml parser.
	/// </summary>
	public class ArchetypeParserFactory : IArchetypeParserFactory
	{
		/// <summary>
		/// Get the appropriate parser by evaluating the text of the archetype
		/// </summary>
		/// <param name="archetype">Text format of the archetype. This can be adl or xml.</param>
		/// <returns>An implementation of the archetype parser.</returns>
		public IArchetypeParser GetParser(string archetype)
		{
			//TODO: throw notimplementedexception for adl parser.
			return new XmlParser();
		}
	}
}
