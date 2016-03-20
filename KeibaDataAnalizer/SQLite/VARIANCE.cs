using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Nikochan.Keiba.KeibaDataAnalyzer.SQLite
{
    [SQLiteFunction(Name = "VARIANCE", FuncType = FunctionType.Aggregate, Arguments = 1)]
    public class VARIANCE : AGGREGATE
    {
        public override object Final(object contextData)
        {
            if (contextData == null)
            {
                return DBNull.Value;
            }
            var context = (Context)contextData;
            var count = context.List.Count;
            if (count == 0)
            {
                return DBNull.Value;
            }
            var sum = 0.0;
            foreach (var value in context.List)
            {
                sum += value;
            }
            double average = sum / count;
            double variance = 0.0;
            foreach (var value in context.List)
            {
                variance += Math.Pow(value - average, 2);
            }
            return variance / count;
        }
    }
}
