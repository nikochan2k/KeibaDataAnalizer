using Soma.Core;
using System;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Generator
{
	/// <summary>
	/// Description of ShussoubaDto.
	/// </summary>
	public class ShussoubaDto
	{
        [Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "KyousoubaId", IsEnclosed = false)]
        public String KyousoubaId { get; set; }
        [Column(Name = "Kouhan3FJuni", IsEnclosed = false)]
        public Int32? Kouhan3FJuni { get; set; }
	}
}
