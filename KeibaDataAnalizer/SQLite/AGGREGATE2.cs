using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SQLite;

namespace Nikochan.Keiba.KeibaDataAnalyzer.SQLite
{
    public class AGGREGATE2 : SQLiteFunction
    {
        protected class Context
        {
            private IList<double> xList = new List<double>();

            private IList<double> yList = new List<double>();

            private int n = 0;

            private double sigma_x = 0.0;

            private double sigma_x2 = 0.0;

            private double sigma_y = 0.0;

            private double sigma_y2 = 0.0;

            private double sigma_xy = 0.0;

            public void Add(double x, double y)
            {
                n++;

                xList.Add(x);
                sigma_x += x;
                sigma_x2 += x * x;

                yList.Add(y);
                sigma_y += y;
                sigma_y2 += y * y;

                sigma_xy += x * y;
            }

            public int N
            {
                get
                {
                    return n;
                }
            }

            public double SigmaX
            {
                get
                {
                    return sigma_x;
                }
            }

            public double SigmaX2
            {
                get
                {
                    return sigma_x2;
                }
            }

            public double SigmaY
            {
                get
                {
                    return sigma_y;
                }
            }

            public double SigmaY2
            {
                get
                {
                    return sigma_y2;
                }
            }

            public double SigmaXY
            {
                get
                {
                    return sigma_xy;
                }
            }

            private double? sxx;

            public double Sxx
            {
                get
                {
                    if (sxx == null)
                    {
                        sxx = sigma_x2 - (sigma_x * sigma_x) / n;
                    }
                    return sxx.Value;
                }
            }

            private double? syy;

            public double Syy
            {
                get
                {
                    if (syy == null)
                    {
                        syy = sigma_y2 - (sigma_y * sigma_y) / n;
                    }
                    return syy.Value;
                }
            }

            private double? sxy;

            public double Sxy
            {
                get
                {
                    if (sxy == null)
                    {
                        sxy = sigma_xy - (sigma_x * sigma_y) / n;
                    }
                    return sxy.Value;
                }
            }

            public double? xBar;

            public double XBar
            {
                get
                {
                    if (xBar == null)
                    {
                        xBar = sigma_x / n;
                    }
                    return xBar.Value;
                }
            }

            public double? yBar;

            public double YBar
            {
                get
                {
                    if (yBar == null)
                    {
                        yBar = sigma_y / n;
                    }
                    return yBar.Value;
                }
            }

            private double? a;

            public double A
            {
                get
                {
                    if (a == null)
                    {
                        a = Sxy / Sxx;
                    }
                    return a.Value;
                }
            }

            private double? b;

            public double B
            {
                get
                {
                    if (b == null)
                    {
                        b = YBar - (Sxy / Sxx) * XBar;
                    }
                    return b.Value;
                }
            }

            public double? se;

            public double SE
            {
                get
                {
                    if (se == null)
                    {
                        se = Syy - A * Sxy;
                    }
                    return se.Value;
                }
            }

            private double? ve;

            public double VE
            {
                get
                {
                    if (ve == null)
                    {
                        ve = SE / (n - 2);
                    }
                    return ve.Value;
                }
            }

            private double? r;

            public double R
            {
                get
                {
                    if (r == null)
                    {
                        r = Sxy / Math.Sqrt(Sxx * Syy);
                    }
                    return r.Value;
                }
            }

            private double? r2;

            public double R2
            {
                get
                {
                    if (r2 == null)
                    {
                        r2 = 1 - SE / Syy;
                    }
                    return r2.Value;
                }
            }

        }

        public override void Step(object[] args, int stepNumber, ref object contextData)
        {
            if (DBNull.Value.Equals(args[0]) || DBNull.Value.Equals(args[1]))
            {
                return;
            }
            double x, y;
            try
            {
                x = Convert.ToDouble(args[0]);
                y = Convert.ToDouble(args[1]);
            }
            catch (Exception)
            {
                return;
            }
            var context = (contextData as Context) ?? (Context)(contextData = new Context());
            context.Add(x, y);
        }


    }
}
