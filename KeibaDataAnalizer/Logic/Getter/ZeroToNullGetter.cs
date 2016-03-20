using System;
using System.Collections.Generic;
using System.Text;


namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Getter
{
    public class ZeroToNullGetter : DefaultGetter
    {
        public ZeroToNullGetter(ImportHistory importHistory)
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
            return Decimal.Parse(s) == Decimal.Zero ? null : s;
        }
    }
}
