using System;
using System.Collections.Generic;
using System.Text;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Getter
{
    public class OneTenthGetter : ZeroToNullGetter
    {
        public OneTenthGetter(ImportHistory importHistory)
            : base(importHistory)
        {
        }

        public override Double? GetDouble(byte[] data, int index, int count)
        {
            Double? value = base.GetDouble(data, index, count);
            return value != null ? value / 10.0 : null;
        }
    }
}
