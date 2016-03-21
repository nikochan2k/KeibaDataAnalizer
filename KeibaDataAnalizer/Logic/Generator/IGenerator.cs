using System.ComponentModel;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Generator
{
	/// <summary>
	/// Description of IGenerator.
	/// </summary>
	public interface IGenerator
	{
		string Name { get; }

		void Generate(Component component);
	}
}
