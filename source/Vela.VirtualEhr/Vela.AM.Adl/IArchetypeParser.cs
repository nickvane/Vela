using Vela.AM.Aom.Archetypes;

namespace Vela.AM.Adl
{
	/// <summary>
	/// 
	/// </summary>
	public interface IArchetypeParser
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="archetype"></param>
		/// <returns></returns>
		Archetype Parse(string archetype);
	}
}
