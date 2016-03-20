using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Getter
{
    public class TimeGetter : DefaultGetter
    {
        private static readonly Regex MSSF = new Regex("^(\\d)(\\d{2})(\\d)$");

        public TimeGetter(ImportHistory importHistory)
            : base(importHistory)
        {
        }

        public override Double? GetDouble(byte[] data, int index, int count)
        {
            String s = GetString(data, index, count);
            if (s == null)
            {
                return null;
            }
            Match match = MSSF.Match(s);
            if (!match.Success)
            {
                return null;
            }            
            int m = int.Parse(match.Groups[1].Value);
            int ss = int.Parse(match.Groups[2].Value);
            int f = int.Parse(match.Groups[3].Value);
            double value = m * 60 + ss + (double)f / 10.0;
            return value;
        }
    }
}
