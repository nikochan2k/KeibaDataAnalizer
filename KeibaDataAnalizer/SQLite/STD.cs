using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Nikochan.Keiba.KeibaDataAnalyzer.SQLite
{
    [SQLiteFunction(Name = "STD", FuncType = FunctionType.Aggregate, Arguments = 1)]
    public class STD : VARIANCE
    {
        public override object Final(object contextData)
        {
            if (contextData == null)
            {
                return null;
            }
           
            object value = base.Final(contextData);
            if (value == null || DBNull.Value.Equals(value))
            {
                return DBNull.Value;
            }
            return Math.Sqrt((double)value);
        }
    }
}
