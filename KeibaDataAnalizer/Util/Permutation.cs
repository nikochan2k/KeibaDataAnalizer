using System;
using System.Collections.Generic;
using System.Text;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Util
{
    public static class Permutation
    {
        // items は、int[], List<int>, List<char> などが受け取れる
        // m は、選び取る数
        // withRedandant = true 重複を許す
        // n 個から m個の順列を求める(重複あり/なし)
        public static IEnumerable<T[]> GetElements<T>(IEnumerable<T> items, int m)
        {
            if (m == 1)
            {
                foreach (var n in items)
                {
                    yield return new T[] { n };
                }
                yield break;
            }
            foreach (var atom in items)
            {
                var templist = new List<T>(items);
                templist.Remove(atom);
                var ary1 = new T[] { atom };
                var elements = GetElements(templist, m - 1);
                foreach (var ary2 in elements)
                {
                    var newelem = new T[ary1.Length + ary2.Length];
                    ary1.CopyTo(newelem, 0);
                    ary2.CopyTo(newelem, ary1.Length);
                    yield return newelem;
                }
            }
        }
    }
}
