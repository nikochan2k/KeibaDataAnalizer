using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.ComponentModel;

using Nikochan.Keiba.KeibaDataAnalyzer.Logic;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Getter
{
    public class DefaultGetter : ValueGetter
    {
        protected static readonly NullReferenceException NULL_REFERENCE_EXCEPTION = new NullReferenceException();

        private static readonly String[] FROM_STRINGS = { "ｶﾞ", "ｷﾞ", "ｸﾞ", "ｹﾞ", "ｺﾞ", "ｻﾞ", "ｼﾞ", "ｽﾞ", "ｾﾞ", "ｿﾞ", "ﾀﾞ", "ﾁﾞ", "ﾂﾞ", "ﾃﾞ", "ﾄﾞ", "ﾊﾞ", "ﾋﾞ", "ﾌﾞ", "ﾍﾞ", "ﾎﾞ", "ﾊﾟ", "ﾋﾟ", "ﾌﾟ", "ﾍﾟ", "ﾎﾟ", "ｳﾞ" };

        private static readonly String[] TO_STRINGS = { "ガ", "ギ", "グ", "ゲ", "ゴ", "ザ", "ジ", "ズ", "ゼ", "ゾ", "ダ", "ヂ", "ヅ", "デ", "ド", "バ", "ビ", "ブ", "ベ", "ボ", "パ", "ピ", "プ", "ペ", "ポ", "ヴ" };

        private const String FROM_CHARS = "　！”＃＄％＆’（）＊＋，－．／０１２３４５６７８９：；＜＝＞？＠ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ［￥］＾＿｀ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ｛｜｝￣“‘＼｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ";

        private const String TO_CHARS = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~\"'\\。「」、・ヲァィゥェォャュョッーアイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワン゛゜";

        private static readonly Encoding SJIS = Encoding.GetEncoding(932);

        private static readonly Regex SP = new Regex("^\\s+$");

        protected ImportHistory ImportHistory{get; set;}

        public DefaultGetter(ImportHistory importHistory)
        {
            this.ImportHistory = importHistory;
        }

        public virtual String GetString(byte[] data, int index, int count)
        {
            
            String s = SJIS.GetString(data, index, count);
            for (var i = 0; i < FROM_STRINGS.Length; i++)
            {
                s = s.Replace(FROM_STRINGS[i], TO_STRINGS[i]);
            }
            for (var i = 0; i < FROM_CHARS.Length; i++)
            {
                s = s.Replace(FROM_CHARS[i], TO_CHARS[i]);
            }
            if (SP.IsMatch(s))
            {
                return null;
            }
            return s.Trim();
        }

        protected virtual TOutput GetValue<TOutput>(byte[] data, int index, int count)
        {
            String s = GetString(data, index, count);
            Type conversionType = typeof(TOutput);
            if (!conversionType.IsGenericType)
            {
                if (s == null)
                {
                    throw NULL_REFERENCE_EXCEPTION;
                }
                return (TOutput)Convert.ChangeType(s, conversionType);
            }
            if (s == null)
            {
                return default(TOutput);
            }
            conversionType = Nullable.GetUnderlyingType(conversionType);
            try
            {
                return (TOutput)Convert.ChangeType(s, conversionType);
            }
            catch (Exception ex)
            {
                ImportHistory.AddImportLog(index, count, s + " を型 " + conversionType.Name + "に変換できません。",
                            CommonUtil.FlattenException(ex));
                return default(TOutput);
            }
        }

        public virtual SByte? GetSByte(byte[] data, int index, int count)
        {
            return GetValue<SByte?>(data, index, count);
        }

        public virtual Int16? GetInt16(byte[] data, int index, int count)
        {
            return GetValue<Int16?>(data, index, count);
        }

        public virtual Int32? GetInt32(byte[] data, int index, int count)
        {
            return GetValue<Int32?>(data, index, count);
        }

        public virtual Int64? GetInt64(byte[] data, int index, int count)
        {
            return GetValue<Int64?>(data, index, count);
        }

        public virtual Single? GetSingle(byte[] data, int index, int count)
        {
            return GetValue<Single?>(data, index, count);
        }

        public virtual Double? GetDouble(byte[] data, int index, int count)
        {
            return GetValue<Double?>(data, index, count);
        }

        public virtual Decimal? GetDecimal(byte[] data, int index, int count)
        {
            return GetValue<Decimal?>(data, index, count);
        }

        public virtual DateTime? GetDateTime(byte[] data, int index, int count)
        {
            return GetValue<DateTime?>(data, index, count);
        }

    }
}
