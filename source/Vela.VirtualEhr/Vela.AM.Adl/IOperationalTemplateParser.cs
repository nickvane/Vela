using Vela.AM.Templates;

namespace Vela.AM.Adl
{
	/// <summary>
	/// 
	/// </summary>
	public interface IOperationalTemplateParser
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="operationalTemplate"></param>
		/// <returns></returns>
		OperationalTemplate Parse(string operationalTemplate);
	}
}
