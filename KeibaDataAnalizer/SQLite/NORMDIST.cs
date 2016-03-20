using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Nikochan.Keiba.KeibaDataAnalyzer.SQLite
{
    [SQLiteFunction(Name = "NORMDIST", FuncType = FunctionType.Scalar, Arguments = 4)]
    public class NORMDIST : SQLiteFunction
    {
        private const double PARTS = 50000.0;

        public double NormalDist(double x, double mean, double standard_dev)
        {
            double fact = standard_dev * Math.Sqrt(2.0 * Math.PI);
            double expo = (x - mean) * (x - mean) / (2.0 * standard_dev * standard_dev);
            return Math.Exp(-expo) / fact;
        }

        public override object Invoke(object[] args)
        {
            if (DBNull.Value.Equals(args[0]) || DBNull.Value.Equals(args[1])
                || DBNull.Value.Equals(args[2]) || DBNull.Value.Equals(args[3]))
            {
                return DBNull.Value;
            }
            double x = Convert.ToDouble(args[0]);
            double mean = Convert.ToDouble(args[1]);
            double standard_dev = Convert.ToDouble(args[2]);
            bool cumulative = (Convert.ToInt32(args[3]) != 0);

            double lowBound = 0.0;
            if (cumulative) //do integration: trapezoidal rule used here
            {
                double width = (x - lowBound) / (PARTS - 1.0);
                double integral = 0.0;
                for (int i = 1; i < PARTS - 1; i++)
                {
                    integral += 0.5 * width * (NormalDist(lowBound + width * i, mean, standard_dev) +
                        (NormalDist(lowBound + width * (i + 1), mean, standard_dev)));
                }
                return integral;
            }
            else //return function value
            {
                return NormalDist(x, mean, standard_dev);
            }
        }
    }
}
