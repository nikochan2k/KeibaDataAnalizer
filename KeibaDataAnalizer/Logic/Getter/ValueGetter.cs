using System;
using System.Collections.Generic;
using System.Text;


namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Getter
{
    interface ValueGetter
    {
        String GetString(byte[] data, int index, int count);

        SByte? GetSByte(byte[] data, int index, int count);

        Int16? GetInt16(byte[] data, int index, int count);

        Int32? GetInt32(byte[] data, int index, int count);

        Int64? GetInt64(byte[] data, int index, int count);

        Single? GetSingle(byte[] data, int index, int count);

        Double? GetDouble(byte[] data, int index, int count);

        Decimal? GetDecimal(byte[] data, int index, int count);

        DateTime? GetDateTime(byte[] data, int index, int count);

    }
}
