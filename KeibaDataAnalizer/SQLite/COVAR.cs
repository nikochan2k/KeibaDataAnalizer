using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SQLite;

namespace Nikochan.Keiba.KeibaDataAnalyzer.SQLite
{
    [SQLiteFunction(Name = "COVAR", FuncType = FunctionType.Aggregate, Arguments = 2)]
    public class COVAR : AGGREGATE2
    {
        public override object Final(object contextData)
        {
            if (contextData == null)
            {
                return DBNull.Value;
            }
            var context = (Context)contextData;
            if (context.N == 0)
            {
                return DBNull.Value;
            }
            var cover = context.Sxy / context.N;
            return cover;
        }
    }
}
