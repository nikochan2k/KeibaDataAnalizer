using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public class KD2SeisekiImporter : KDSeisekiImporter
    {
        private String kolSei1Path;

        private String kolSei2Path;

        public KD2SeisekiImporter(ImportHistory importHistory, String kolSei1Path, String kolSei2Path)
            : base(importHistory)
        {
            this.kolSei1Path = kolSei1Path;
            this.kolSei2Path = kolSei2Path;
        }

        #region KDImporter メンバ

        protected override int BytesOfRace
        {
            get { return 2756; }
        }

        protected override int BytesOfShussouba
        {
            get { return 474; }
        }

        protected override int RaceDataSakuseiNengappiIndex
        {
            get { return 2326; }
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
            race.BetteiBareiHandi = DEFAULT_GETTER.GetInt32(buffer, 74, 2);
            race.BetteiBareiHandiShousai = DEFAULT_GETTER.GetString(buffer, 76, 18);
            race.JoukenFuka1 = DEFAULT_GETTER.GetInt32(buffer, 94, 2);
            race.JoukenFuka2 = DEFAULT_GETTER.GetInt32(buffer, 96, 2);
            race.JoukenKei = GetJoukenKei(buffer, 98);
            race.JoukenNenreiSeigen = GetJoukenNenreiSeigen(buffer, 98, 99);
            race.Jouken1 = DEFAULT_GETTER.GetInt32(buffer, 100, 5);
            if (race.ChuuouChihouGaikoku != 0)
            {
                race.Kumi1 = DEFAULT_GETTER.GetInt32(buffer, 105, 2);
                race.IjouIkaMiman = DEFAULT_GETTER.GetInt32(buffer, 107, 1);
                race.Jouken2 = DEFAULT_GETTER.GetInt32(buffer, 108, 5);
                race.Kumi2 = DEFAULT_GETTER.GetInt32(buffer, 108, 5);
            }
            race.DirtShiba = DEFAULT_GETTER.GetInt32(buffer, 115, 1).Value;
            race.MigiHidari = DEFAULT_GETTER.GetInt32(buffer, 116, 1).Value;
            race.UchiSoto = DEFAULT_GETTER.GetInt32(buffer, 117, 1);
            race.Course = DEFAULT_GETTER.GetInt32(buffer, 118, 1);
            race.Kyori = DEFAULT_GETTER.GetInt32(buffer, 119, 4).Value;
            DateTime? nengappi;
            nengappi = DATE_GETTER.GetDateTime(buffer, 124, 8);
            if (nengappi != null)
            {
                race.CourseRecordFlag = DEFAULT_GETTER.GetInt32(buffer, 123, 1);
                race.CourseRecordNengappi = nengappi;
                race.CourseRecordTime = TIME_GETTER.GetDouble(buffer, 132, 4);
                race.CourseRecordBamei = DEFAULT_GETTER.GetString(buffer, 136, 30);
                race.CourseRecordKinryou = ONE_TENTH_GETTER.GetDouble(buffer, 166, 3);
                race.CourseRecordTanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 169, 8);
            }
            nengappi = DATE_GETTER.GetDateTime(buffer, 177, 8);
            if (nengappi != null)
            {
                race.KyoriRecordNengappi = nengappi;
                race.KyoriRecordTime = TIME_GETTER.GetDouble(buffer, 185, 4);
                race.KyoriRecordBamei = DEFAULT_GETTER.GetString(buffer, 189, 30);
                race.KyoriRecordKinryou = ONE_TENTH_GETTER.GetDouble(buffer, 219, 3);
                race.KyoriRecordTanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 222, 8);
                race.KyoriRecordBasho = DEFAULT_GETTER.GetInt32(buffer, 230, 2);
            }
            nengappi = DATE_GETTER.GetDateTime(buffer, 232, 8);
            if (nengappi != null)
            {
                race.RaceRecordNengappi = nengappi;
                race.RaceRecordTime = TIME_GETTER.GetDouble(buffer, 240, 4);
                race.RaceRecordBamei = DEFAULT_GETTER.GetString(buffer, 244, 30);
                race.RaceRecordKinryou = ONE_TENTH_GETTER.GetDouble(buffer, 274, 3);
                race.RaceRecordTanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 277, 8);
                race.RaceRecordBasho = DEFAULT_GETTER.GetInt32(buffer, 285, 2);
            }
            race.Shoukin1Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 287, 9);
            race.Shoukin2Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 296, 9);
            race.Shoukin3Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 305, 9);
            race.Shoukin4Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 314, 9);
            race.Shoukin5Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 323, 9);
            race.Shoukin5ChakuDouchaku1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 332, 9);
            race.Shoukin5ChakuDouchaku2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 341, 9);
            race.FukaShou = ZERO_TO_NULL_GETTER.GetInt32(buffer, 350, 9);
            race.MaeuriFlag = DEFAULT_GETTER.GetInt32(buffer, 359, 1);
            race.YoteiHassouJikan = DEFAULT_GETTER.GetString(buffer, 360, 5);
            race.Tousuu = DEFAULT_GETTER.GetInt32(buffer, 365, 2).Value;
            race.TorikeshiTousuu = DEFAULT_GETTER.GetInt32(buffer, 367, 2).Value;
            race.SuiteiTimeRyou = TIME_GETTER.GetDouble(buffer, 369, 4);
            race.SuiteiTimeOmoFuryou = TIME_GETTER.GetDouble(buffer, 373, 4);
            race.Pace = DEFAULT_GETTER.GetInt32(buffer, 377, 1);
            race.Tenki = DEFAULT_GETTER.GetInt32(buffer, 378, 1);
            race.Baba = DEFAULT_GETTER.GetInt32(buffer, 379, 1);
            race.Seed = DEFAULT_GETTER.GetInt32(buffer, 380, 1);
            if (race.HeichiShougai == 1)
            {
                race.ShougaiHeikin1F = ZERO_TO_NULL_GETTER.GetDouble(buffer, 771, 4);
            }
            race.SeisekiSakuseiNengappi = dataSakuseiNengappi;

            return race;
        }

        protected override RaceHaitou BuildRaceHaitou(Race race, byte[] buffer)
        {
            var raceHaitou = new RaceHaitou();

            raceHaitou.Id = race.Id;
            raceHaitou.TanUmaban1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 381, 2);
            raceHaitou.TanshouHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 383, 6);
            raceHaitou.TanUmaban2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 389, 2);
            raceHaitou.TanshouHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 391, 6);
            raceHaitou.TanUmaban3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 397, 2);
            raceHaitou.TanshouHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 399, 6);
            raceHaitou.FukuUmaban1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 405, 2);
            raceHaitou.FukushouHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 407, 6);
            raceHaitou.FukuUmaban2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 413, 2);
            raceHaitou.FukushouHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 415, 6);
            raceHaitou.FukuUmaban3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 421, 2);
            raceHaitou.FukushouHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 423, 6);
            raceHaitou.FukuUmaban4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 429, 2);
            raceHaitou.FukushouHaitoukin4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 431, 6);
            raceHaitou.FukuUmaban5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 437, 2);
            raceHaitou.FukushouHaitoukin5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 439, 6);
            raceHaitou.Wakuren11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 445, 1);
            raceHaitou.Wakuren12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 446, 1);
            raceHaitou.WakurenHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 447, 6);
            raceHaitou.WakurenNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 453, 2);
            raceHaitou.Wakuren21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 455, 1);
            raceHaitou.Wakuren22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 456, 1);
            raceHaitou.WakurenHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 457, 6);
            raceHaitou.WakurenNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 463, 2);
            raceHaitou.Wakuren31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 465, 1);
            raceHaitou.Wakuren32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 466, 1);
            raceHaitou.WakurenHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 467, 6);
            raceHaitou.WakurenNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 473, 2);
            raceHaitou.Umaren11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 475, 2);
            raceHaitou.Umaren12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 477, 2);
            raceHaitou.UmarenHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 479, 7);
            raceHaitou.UmarenNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 486, 3);
            raceHaitou.Umaren21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 489, 2);
            raceHaitou.Umaren22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 491, 2);
            raceHaitou.UmarenHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 493, 7);
            raceHaitou.UmarenNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 500, 3);
            raceHaitou.Umaren31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 503, 2);
            raceHaitou.Umaren32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 505, 2);
            raceHaitou.UmarenHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 507, 7);
            raceHaitou.UmarenNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 514, 3);
            raceHaitou.WideUmaren11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 517, 2);
            raceHaitou.WideUmaren12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 519, 2);
            raceHaitou.WideUmarenHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 521, 7);
            raceHaitou.WideUmarenNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 528, 3);
            raceHaitou.WideUmaren21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 531, 2);
            raceHaitou.WideUmaren22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 533, 2);
            raceHaitou.WideUmarenHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 535, 7);
            raceHaitou.WideUmarenNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 542, 3);
            raceHaitou.WideUmaren31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 545, 2);
            raceHaitou.WideUmaren32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 547, 2);
            raceHaitou.WideUmarenHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 549, 7);
            raceHaitou.WideUmarenNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 556, 3);
            raceHaitou.WideUmaren41 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 559, 2);
            raceHaitou.WideUmaren42 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 561, 2);
            raceHaitou.WideUmarenHaitoukin4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 563, 7);
            raceHaitou.WideUmarenNinki4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 570, 3);
            raceHaitou.WideUmaren51 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 573, 2);
            raceHaitou.WideUmaren52 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 575, 2);
            raceHaitou.WideUmarenHaitoukin5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 577, 7);
            raceHaitou.WideUmarenNinki5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 584, 3);
            raceHaitou.WideUmaren61 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 587, 2);
            raceHaitou.WideUmaren62 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 589, 2);
            raceHaitou.WideUmarenHaitoukin6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 591, 7);
            raceHaitou.WideUmarenNinki6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 598, 3);
            raceHaitou.WideUmaren71 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 601, 2);
            raceHaitou.WideUmaren72 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 603, 2);
            raceHaitou.WideUmarenHaitoukin7 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 605, 7);
            raceHaitou.WideUmarenNinki7 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 612, 3);
            raceHaitou.Umatan11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 615, 2);
            raceHaitou.Umatan12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 617, 2);
            raceHaitou.UmatanHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 619, 7);
            raceHaitou.UmatanNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 626, 3);
            raceHaitou.Umatan21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 629, 2);
            raceHaitou.Umatan22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 631, 2);
            raceHaitou.UmatanHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 633, 7);
            raceHaitou.UmatanNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 640, 3);
            raceHaitou.Umatan31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 643, 2);
            raceHaitou.Umatan32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 645, 2);
            raceHaitou.UmatanHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 647, 7);
            raceHaitou.UmatanNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 654, 3);
            raceHaitou.Umatan41 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 657, 2);
            raceHaitou.Umatan42 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 659, 2);
            raceHaitou.UmatanHaitoukin4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 661, 7);
            raceHaitou.UmatanNinki4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 668, 3);
            raceHaitou.Umatan51 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 671, 2);
            raceHaitou.Umatan52 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 673, 2);
            raceHaitou.UmatanHaitoukin5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 675, 7);
            raceHaitou.UmatanNinki5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 682, 3);
            raceHaitou.Umatan61 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 685, 2);
            raceHaitou.Umatan62 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 687, 2);
            raceHaitou.UmatanHaitoukin6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 689, 7);
            raceHaitou.UmatanNinki6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 696, 3);
            raceHaitou.Sanrenpuku11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 699, 2);
            raceHaitou.Sanrenpuku12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 701, 2);
            raceHaitou.Sanrenpuku13 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 703, 2);
            raceHaitou.SanrenpukuHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 705, 7);
            raceHaitou.SanrenpukuNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 712, 3);
            raceHaitou.Sanrenpuku21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 715, 2);
            raceHaitou.Sanrenpuku22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 717, 2);
            raceHaitou.Sanrenpuku23 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 719, 2);
            raceHaitou.SanrenpukuHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 721, 7);
            raceHaitou.SanrenpukuNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 728, 3);
            raceHaitou.Sanrenpuku31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 731, 2);
            raceHaitou.Sanrenpuku32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 733, 2);
            raceHaitou.Sanrenpuku33 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 735, 2);
            raceHaitou.SanrenpukuHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 737, 7);
            raceHaitou.SanrenpukuNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 744, 3);
            raceHaitou.Sanrentan11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2334, 2);
            raceHaitou.Sanrentan12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2336, 2);
            raceHaitou.Sanrentan13 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2338, 2);
            raceHaitou.SanrentanHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2340, 9);
            raceHaitou.SanrentanNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2349, 4);
            raceHaitou.Sanrentan21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2353, 2);
            raceHaitou.Sanrentan22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2355, 2);
            raceHaitou.Sanrentan23 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2357, 2);
            raceHaitou.SanrentanHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2359, 9);
            raceHaitou.SanrentanNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2368, 4);
            raceHaitou.Sanrentan31 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2372, 2);
            raceHaitou.Sanrentan32 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2374, 2);
            raceHaitou.Sanrentan33 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2376, 2);
            raceHaitou.SanrentanHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2378, 9);
            raceHaitou.SanrentanNinki3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2387, 4);
            raceHaitou.Sanrentan41 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2391, 2);
            raceHaitou.Sanrentan42 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2393, 2);
            raceHaitou.Sanrentan43 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2395, 2);
            raceHaitou.SanrentanHaitoukin4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2397, 9);
            raceHaitou.SanrentanNinki4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2406, 4);
            raceHaitou.Sanrentan51 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2410, 2);
            raceHaitou.Sanrentan52 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2412, 2);
            raceHaitou.Sanrentan53 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2414, 2);
            raceHaitou.SanrentanHaitoukin5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2416, 9);
            raceHaitou.SanrentanNinki5 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2425, 4);
            raceHaitou.Sanrentan61 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2429, 2);
            raceHaitou.Sanrentan62 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2431, 2);
            raceHaitou.Sanrentan63 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2433, 2);
            raceHaitou.SanrentanHaitoukin6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2435, 9);
            raceHaitou.SanrentanNinki6 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 2444, 4);

            return raceHaitou;
        }

        protected override int LapTimeIndex
        {
            get { return 775; }
        }

        protected override int LapTimeIndexOfShougai
        {
            get { return 755; }
        }

        protected override int KeikaIndex
        {
            get { return 829; }
        }

        protected override int HassouJoukyouIndex
        {
            get { return 1846; }
        }

        protected override int TsuukaJuniIndex
        {
            get { return 298; }
        }

        #endregion

    }
}
