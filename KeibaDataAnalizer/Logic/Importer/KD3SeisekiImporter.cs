using System;
using System.Collections.Generic;
using System.IO;

using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public class KD3SeisekiImporter : KDSeisekiImporter
    {
        private String kolSei1Path;

        private String kolSei2Path;

        private String kolSei3Path;

        public KD3SeisekiImporter(ImportHistory importHistory, String kolSei1Path, String kolSei2Path, String kolSei3Path)
            : base(importHistory)
        {
            this.kolSei1Path = kolSei1Path;
            this.kolSei2Path = kolSei2Path;
            this.kolSei3Path = kolSei3Path;
        }

        #region KDImporter メンバ

        protected override int BytesOfRace
        {
            get { return 3200; }
        }

        protected override int BytesOfShussouba
        {
            get { return 600; }
        }

        protected override int RaceDataSakuseiNengappiIndex
        {
            get { return 2910; }
        }

        protected override string KolSei1Path
        {
            get { return kolSei1Path; }
        }

        protected override string KolSei2Path
        {
            get { return kolSei2Path; }
        }

        protected override Race BuildRace(byte[] buffer, long raceId, DateTime dataSakuseiNengappi)
        {
            Race race = new Race();

            race.Id = raceId;
            race.KaisaiBasho = DEFAULT_GETTER.GetInt32(buffer, 0, 2).Value;
            race.KaisaiNen = DEFAULT_GETTER.GetInt32(buffer, 2, 4).Value;
            race.KaisaiKaiji = DEFAULT_GETTER.GetInt32(buffer, 6, 2).Value;
            race.KaisaiNichiji = DEFAULT_GETTER.GetInt32(buffer, 8, 2).Value;
            race.RaceBangou = DEFAULT_GETTER.GetInt32(buffer, 10, 2).Value;
            race.Nengappi = DATE_GETTER.GetDateTime(buffer, 12, 8).Value;
            race.Kyuujitsu = DEFAULT_GETTER.GetInt32(buffer, 20, 1).Value;
            race.Youbi = DEFAULT_GETTER.GetInt32(buffer, 21, 1).Value;
            race.KouryuuFlag = DEFAULT_GETTER.GetInt32(buffer, 22, 1);
            race.ChuuouChihouGaikoku = DEFAULT_GETTER.GetInt32(buffer, 23, 1).Value;
            race.IppanTokubetsu = DEFAULT_GETTER.GetInt32(buffer, 24, 1).Value;
            race.HeichiShougai = DEFAULT_GETTER.GetInt32(buffer, 25, 1).Value;
            race.JuushouKaisuu = ZERO_TO_NULL_GETTER.GetInt32(buffer, 26, 3);
            race.TokubetsuMei = DEFAULT_GETTER.GetString(buffer, 29, 30);
            race.TanshukuTokubetsuMei = DEFAULT_GETTER.GetString(buffer, 59, 14);
            race.Grade = DEFAULT_GETTER.GetInt32(buffer, 73, 1);
            race.JpnFlag = ZERO_TO_NULL_GETTER.GetInt32(buffer, 74, 1);
            race.BetteiBareiHandi = DEFAULT_GETTER.GetInt32(buffer, 75, 2);
            race.BetteiBareiHandiShousai = DEFAULT_GETTER.GetString(buffer, 77, 18);
            race.JoukenFuka1 = DEFAULT_GETTER.GetInt32(buffer, 95, 2);
            race.JoukenFuka2 = DEFAULT_GETTER.GetInt32(buffer, 97, 2);
            race.JoukenKei = GetJoukenKei(buffer, 99);
            race.JoukenNenreiSeigen = GetJoukenNenreiSeigen(buffer, 99, 100);
            race.Jouken1 = DEFAULT_GETTER.GetInt32(buffer, 101, 5);
            if (race.ChuuouChihouGaikoku != 0)
            {
                race.Kumi1 = DEFAULT_GETTER.GetInt32(buffer, 106, 2);
                race.IjouIkaMiman = DEFAULT_GETTER.GetInt32(buffer, 108, 1);
                race.Jouken2 = DEFAULT_GETTER.GetInt32(buffer, 109, 5);
                race.Kumi2 = DEFAULT_GETTER.GetInt32(buffer, 114, 2);
            }
            race.DirtShiba = DEFAULT_GETTER.GetInt32(buffer, 116, 1).Value;
            race.MigiHidari = DEFAULT_GETTER.GetInt32(buffer, 117, 1).Value;
            race.UchiSoto = DEFAULT_GETTER.GetInt32(buffer, 118, 1);
            race.Course = DEFAULT_GETTER.GetInt32(buffer, 119, 1);
            race.Kyori = DEFAULT_GETTER.GetInt32(buffer, 120, 4).Value;
            DateTime? nengappi;
            nengappi = DATE_GETTER.GetDateTime(buffer, 125, 8);
            if (nengappi != null)
            {
                race.CourseRecordFlag = DEFAULT_GETTER.GetInt32(buffer, 124, 1);
                race.CourseRecordNengappi = nengappi;
                race.CourseRecordTime = TIME_GETTER.GetDouble(buffer, 133, 4);
                race.CourseRecordBamei = DEFAULT_GETTER.GetString(buffer, 137, 30);
                race.CourseRecordKinryou = ONE_TENTH_GETTER.GetDouble(buffer, 167, 3);
                race.CourseRecordTanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 170, 8);
            }
            nengappi = DATE_GETTER.GetDateTime(buffer, 178, 8);
            if (nengappi != null)
            {
                race.KyoriRecordNengappi = nengappi;
                race.KyoriRecordTime = TIME_GETTER.GetDouble(buffer, 186, 4);
                race.KyoriRecordBamei = DEFAULT_GETTER.GetString(buffer, 190, 30);
                race.KyoriRecordKinryou = ONE_TENTH_GETTER.GetDouble(buffer, 220, 3);
                race.KyoriRecordTanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 223, 8);
                race.KyoriRecordBasho = DEFAULT_GETTER.GetInt32(buffer, 231, 2);
            }
            nengappi = DATE_GETTER.GetDateTime(buffer, 233, 8);
            if (nengappi != null)
            {
                race.RaceRecordNengappi = nengappi;
                race.RaceRecordTime = TIME_GETTER.GetDouble(buffer, 241, 4);
                race.RaceRecordBamei = DEFAULT_GETTER.GetString(buffer, 245, 30);
                race.RaceRecordKinryou = ONE_TENTH_GETTER.GetDouble(buffer, 275, 3);
                race.RaceRecordTanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 278, 8);
                race.RaceRecordBasho = DEFAULT_GETTER.GetInt32(buffer, 286, 2);
            }
            race.Shoukin1Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 288, 9);
            race.Shoukin2Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 297, 9);
            race.Shoukin3Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 306, 9);
            race.Shoukin4Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 315, 9);
            race.Shoukin5Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 324, 9);
            race.Shoukin5ChakuDouchaku1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 333, 9);
            race.Shoukin5ChakuDouchaku2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 342, 9);
            race.FukaShou = ZERO_TO_NULL_GETTER.GetInt32(buffer, 351, 9);
            race.MaeuriFlag = DEFAULT_GETTER.GetInt32(buffer, 360, 1);
            race.YoteiHassouJikan = DEFAULT_GETTER.GetString(buffer, 361, 5);
            race.Tousuu = DEFAULT_GETTER.GetInt32(buffer, 366, 2).Value;
            race.TorikeshiTousuu = DEFAULT_GETTER.GetInt32(buffer, 368, 2).Value;
            race.SuiteiTimeRyou = TIME_GETTER.GetDouble(buffer, 370, 4);
            race.SuiteiTimeOmoFuryou = TIME_GETTER.GetDouble(buffer, 374, 4);
            race.Pace = DEFAULT_GETTER.GetInt32(buffer, 378, 1);
            race.Tenki = DEFAULT_GETTER.GetInt32(buffer, 379, 1);
            race.Baba = DEFAULT_GETTER.GetInt32(buffer, 380, 1);
            race.Seed = DEFAULT_GETTER.GetInt32(buffer, 381, 1);
            if (race.HeichiShougai == 1)
            {
                race.ShougaiHeikin1F = ZERO_TO_NULL_GETTER.GetDouble(buffer, 398, 4);
            }
            race.SeisekiSakuseiNengappi = dataSakuseiNengappi;

            return race;
        }

        protected override RaceHaitou BuildRaceHaitou(Race race, byte[] buffer)
        {
            var raceHaitou = new RaceHaitou();

            raceHaitou.Id = race.Id;
            raceHaitou.TanUmaban1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2100, 2);
            raceHaitou.TanshouHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2102, 6);
            raceHaitou.TanUmaban2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2108, 2);
            raceHaitou.TanshouHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2110, 6);
            raceHaitou.TanUmaban3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2116, 2);
            raceHaitou.TanshouHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2118, 6);
            raceHaitou.FukuUmaban1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2124, 2);
            raceHaitou.FukushouHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2126, 6);
            raceHaitou.FukuUmaban2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2132, 2);
            raceHaitou.FukushouHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2134, 6);
            raceHaitou.FukuUmaban3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2140, 2);
            raceHaitou.FukushouHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2142, 6);
            raceHaitou.FukuUmaban4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2148, 2);
            raceHaitou.FukushouHaitoukin4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2150, 6);
            raceHaitou.FukuUmaban5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2156, 2);
            raceHaitou.FukushouHaitoukin5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2158, 6);
            raceHaitou.Wakuren11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2164, 1);
            raceHaitou.Wakuren12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2165, 1);
            raceHaitou.WakurenHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2166, 6);
            raceHaitou.WakurenNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2172, 2);
            raceHaitou.Wakuren21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2174, 1);
            raceHaitou.Wakuren22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2175, 1);
            raceHaitou.WakurenHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2176, 6);
            raceHaitou.WakurenNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2182, 2);
            raceHaitou.Wakuren31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2184, 1);
            raceHaitou.Wakuren32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2185, 1);
            raceHaitou.WakurenHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2186, 6);
            raceHaitou.WakurenNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2192, 2);
            raceHaitou.Umaren11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2194, 2);
            raceHaitou.Umaren12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2196, 2);
            raceHaitou.UmarenHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2198, 7);
            raceHaitou.UmarenNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2205, 3);
            raceHaitou.Umaren21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2208, 2);
            raceHaitou.Umaren22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2210, 2);
            raceHaitou.UmarenHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2212, 7);
            raceHaitou.UmarenNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2219, 3);
            raceHaitou.Umaren31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2222, 2);
            raceHaitou.Umaren32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2224, 2);
            raceHaitou.UmarenHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2226, 7);
            raceHaitou.UmarenNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2233, 3);
            raceHaitou.WideUmaren11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2236, 2);
            raceHaitou.WideUmaren12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2238, 2);
            raceHaitou.WideUmarenHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2240, 7);
            raceHaitou.WideUmarenNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2247, 3);
            raceHaitou.WideUmaren21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2250, 2);
            raceHaitou.WideUmaren22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2252, 2);
            raceHaitou.WideUmarenHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2254, 7);
            raceHaitou.WideUmarenNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2261, 3);
            raceHaitou.WideUmaren31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2264, 2);
            raceHaitou.WideUmaren32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2266, 2);
            raceHaitou.WideUmarenHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2268, 7);
            raceHaitou.WideUmarenNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2275, 3);
            raceHaitou.WideUmaren41 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2278, 2);
            raceHaitou.WideUmaren42 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2280, 2);
            raceHaitou.WideUmarenHaitoukin4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2282, 7);
            raceHaitou.WideUmarenNinki4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2289, 3);
            raceHaitou.WideUmaren51 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2292, 2);
            raceHaitou.WideUmaren52 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2294, 2);
            raceHaitou.WideUmarenHaitoukin5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2296, 7);
            raceHaitou.WideUmarenNinki5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2303, 3);
            raceHaitou.WideUmaren61 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2306, 2);
            raceHaitou.WideUmaren62 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2308, 2);
            raceHaitou.WideUmarenHaitoukin6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2310, 7);
            raceHaitou.WideUmarenNinki6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2317, 3);
            raceHaitou.WideUmaren71 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2320, 2);
            raceHaitou.WideUmaren72 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2322, 2);
            raceHaitou.WideUmarenHaitoukin7 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2324, 7);
            raceHaitou.WideUmarenNinki7 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2331, 3);
            raceHaitou.Umatan11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2334, 2);
            raceHaitou.Umatan12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2336, 2);
            raceHaitou.UmatanHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2338, 7);
            raceHaitou.UmatanNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2345, 3);
            raceHaitou.Umatan21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2348, 2);
            raceHaitou.Umatan22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2350, 2);
            raceHaitou.UmatanHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2352, 7);
            raceHaitou.UmatanNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2359, 3);
            raceHaitou.Umatan31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2362, 2);
            raceHaitou.Umatan32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2364, 2);
            raceHaitou.UmatanHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2366, 7);
            raceHaitou.UmatanNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2373, 3);
            raceHaitou.Umatan41 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2376, 2);
            raceHaitou.Umatan42 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2378, 2);
            raceHaitou.UmatanHaitoukin4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2380, 7);
            raceHaitou.UmatanNinki4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2387, 3);
            raceHaitou.Umatan51 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2390, 2);
            raceHaitou.Umatan52 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2392, 2);
            raceHaitou.UmatanHaitoukin5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2394, 7);
            raceHaitou.UmatanNinki5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2401, 3);
            raceHaitou.Umatan61 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2404, 2);
            raceHaitou.Umatan62 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2406, 2);
            raceHaitou.UmatanHaitoukin6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2408, 7);
            raceHaitou.UmatanNinki6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2415, 3);
            raceHaitou.Sanrenpuku11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2418, 2);
            raceHaitou.Sanrenpuku12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2420, 2);
            raceHaitou.Sanrenpuku13 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2422, 2);
            raceHaitou.SanrenpukuHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2424, 7);
            raceHaitou.SanrenpukuNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2431, 3);
            raceHaitou.Sanrenpuku21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2434, 2);
            raceHaitou.Sanrenpuku22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2436, 2);
            raceHaitou.Sanrenpuku23 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2438, 2);
            raceHaitou.SanrenpukuHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2440, 7);
            raceHaitou.SanrenpukuNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2447, 3);
            raceHaitou.Sanrenpuku31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2450, 2);
            raceHaitou.Sanrenpuku32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2452, 2);
            raceHaitou.Sanrenpuku33 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2454, 2);
            raceHaitou.SanrenpukuHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2456, 7);
            raceHaitou.SanrenpukuNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2463, 3);
            raceHaitou.Sanrentan11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2466, 2);
            raceHaitou.Sanrentan12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2468, 2);
            raceHaitou.Sanrentan13 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2470, 2);
            raceHaitou.SanrentanHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2472, 9);
            raceHaitou.SanrentanNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2481, 4);
            raceHaitou.Sanrentan21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2485, 2);
            raceHaitou.Sanrentan22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2487, 2);
            raceHaitou.Sanrentan23 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2489, 2);
            raceHaitou.SanrentanHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2491, 9);
            raceHaitou.SanrentanNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2500, 4);
            raceHaitou.Sanrentan31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2504, 2);
            raceHaitou.Sanrentan32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2506, 2);
            raceHaitou.Sanrentan33 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2508, 2);
            raceHaitou.SanrentanHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2510, 9);
            raceHaitou.SanrentanNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2519, 4);
            raceHaitou.Sanrentan41 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2523, 2);
            raceHaitou.Sanrentan42 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2525, 2);
            raceHaitou.Sanrentan43 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2527, 2);
            raceHaitou.SanrentanHaitoukin4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2529, 9);
            raceHaitou.SanrentanNinki4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2538, 4);
            raceHaitou.Sanrentan51 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2542, 2);
            raceHaitou.Sanrentan52 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2544, 2);
            raceHaitou.Sanrentan53 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2546, 2);
            raceHaitou.SanrentanHaitoukin5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2548, 9);
            raceHaitou.SanrentanNinki5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2557, 4);
            raceHaitou.Sanrentan61 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2561, 2);
            raceHaitou.Sanrentan62 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2563, 2);
            raceHaitou.Sanrentan63 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2565, 2);
            raceHaitou.SanrentanHaitoukin6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2567, 9);
            raceHaitou.SanrentanNinki6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2576, 4);

            return raceHaitou;
        }

        protected override int KeikaIndex
        {
            get { return 456; }
        }

        protected override int LapTimeIndex
        {
            get { return 402; }
        }

        protected override int LapTimeIndexOfShougai
        {
            get { return 382; }
        }

        protected override int HassouJoukyouIndex
        {
            get { return 1473; }
        }

        protected override int TsuukaJuniIndex
        {
            get { return 298; }
        }

        #endregion

    }
}
