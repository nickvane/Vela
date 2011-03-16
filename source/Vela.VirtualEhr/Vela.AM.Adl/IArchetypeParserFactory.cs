namespace Vela.AM.Adl
{
	/// <summary>
	/// Factory for the different archetype parsers. Support for adl en xml parser.
	/// </summary>
	public interface IArchetypeParserFactory
	{
		/// <summary>
		/// Get the appropriate parser by evaluating the text of the archetype
		/// </summary>
		/// <param name="archetype">Text format of the archetype. This can be adl or xml.</param>
		/// <returns>An implementation of the archetype parser.</returns>
		IArchetypeParser GetParser(string archetype);
	}
}
