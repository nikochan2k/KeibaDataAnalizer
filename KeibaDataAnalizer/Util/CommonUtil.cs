using System;
using System.Collections.Generic;
using System.Text;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Util
{
    public class CommonUtil
    {
        public static string FlattenException(Exception ex)
        {
            var sb = new StringBuilder();

            while (ex != null)
            {
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);

                ex = ex.InnerException;
            }

            return sb.ToString();
        }
    }
}
