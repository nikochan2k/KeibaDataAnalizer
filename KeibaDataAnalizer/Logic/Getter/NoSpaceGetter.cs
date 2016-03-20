using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Getter
{
	/// <summary>
	/// Description of NoSpaceSetter.
	/// </summary>
	public class NoSpaceGetter : DefaultGetter
	{
		private static Regex NO_SPACE_REGEX = new Regex(@"\s");
		
        public NoSpaceGetter(ImportHistory importHistory)
            : base(importHistory)
        {
        }
        
        public override string GetString(byte[] data, int index, int count)
        {
            String s = base.GetString(data, index, count);
            if (s == null)
            {
                return null;
            }
            return NO_SPACE_REGEX.Replace(s, string.Empty);
        }
	}
}
