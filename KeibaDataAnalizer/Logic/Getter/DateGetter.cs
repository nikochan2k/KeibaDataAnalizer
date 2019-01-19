using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Getter
{
    public class DateGetter : DefaultGetter
    {
        public DateGetter(ImportHistory importHistory)
            : base(importHistory)
        {
        }
        
        public override DateTime? GetDateTime(byte[] data, int index, int count)
        {
            String s = GetString(data, index, count);
            DateTime? result = null;
            if (s != null)
            {
                try
                {
                    result = DateTime.ParseExact(s, "yyyyMMdd", DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);
                }
                catch (FormatException ex)
                {
                    ImportHistory.AddImportLog(index, count, "yyyyMMdd形式の日付を解釈できません: " + s,
                            CommonUtil.FlattenException(ex));
                }
            }
            return result;
        }
    }
}
