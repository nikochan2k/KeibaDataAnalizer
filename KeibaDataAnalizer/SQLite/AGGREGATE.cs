using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SQLite;

namespace Nikochan.Keiba.KeibaDataAnalyzer.SQLite
{
    public class AGGREGATE : SQLiteFunction
    {
        protected class Context
        {
            private IList<double> list = new List<double>();

            public IList<double> List
            {
                get
                {
                    return list;
                }
            }
        }

        public override void Step(object[] args, int stepNumber, ref object contextData)
        {
            if (DBNull.Value.Equals(args[0]))
            {
                return;
            }
            double value;
            try
            {
                value = Convert.ToDouble(args[0]);
            }
            catch (Exception)
            {
                return;
            }
            var context = (contextData as Context) ?? (Context)(contextData = new Context());
            context.List.Add(value);
        }


    }
}
