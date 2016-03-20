﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SQLite;

namespace Nikochan.Keiba.KeibaDataAnalyzer.SQLite
{
    [SQLiteFunction(Name = "CORREL", FuncType = FunctionType.Aggregate, Arguments = 2)]
    public class CORREL : AGGREGATE2
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
            return context.R;
        }
    }
}
