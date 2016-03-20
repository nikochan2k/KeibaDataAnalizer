using System;
using System.Collections.Generic;
using System.Text;

using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public class KD3ShutsubahyouImporter : KDShutsubahyouImporter
    {
        private String kolDen1Path;

        private String kolDen2Path;

        public KD3ShutsubahyouImporter(ImportHistory importHistory, String kolDen1Path, String kolDen2Path)
            : base(importHistory)
        {
            this.kolDen1Path = kolDen1Path;
            this.kolDen2Path = kolDen2Path;
        }

        protected override string KolDen1Path
        {
            get { return kolDen1Path; }
        }

        protected override string KolDen2Path
        {
            get { return kolDen2Path; }
        }

        protected override int BytesOfRace
        {
            get { return 848; }
        }

        protected override int BytesOfShussouba
        {
            get { return 1000; }
        }

        protected override int RaceDataSakuseiNengappiIndex
        {
            get { return 418; }
        }

        protected override int ShussoubaDataSakuseiNengappiIndex
        {
            get { return 727; }
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
            race.ChuuouChihouGaikoku = DEFAULT_GETTER.GetInt32(buffer, 22, 1).Value;
            race.IppanTokubetsu = DEFAULT_GETTER.GetInt32(buffer, 23, 1).Value;
            race.HeichiShougai = DEFAULT_GETTER.GetInt32(buffer, 24, 1).Value;
            race.JuushouKaisuu = ZERO_TO_NULL_GETTER.GetInt32(buffer, 25, 3);
            race.TokubetsuMei = DEFAULT_GETTER.GetString(buffer, 28, 30);
            race.TanshukuTokubetsuMei = DEFAULT_GETTER.GetString(buffer, 58, 14);
            race.Grade = DEFAULT_GETTER.GetInt32(buffer, 72, 1);
            race.JpnFlag = DEFAULT_GETTER.GetInt32(buffer, 73, 1);
            race.BetteiBareiHandi = DEFAULT_GETTER.GetInt32(buffer, 74, 2);
            race.BetteiBareiHandiShousai = DEFAULT_GETTER.GetString(buffer, 76, 18);
            race.JoukenFuka1 = DEFAULT_GETTER.GetInt32(buffer, 94, 2);
            race.JoukenFuka2 = DEFAULT_GETTER.GetInt32(buffer, 96, 2);
            race.JoukenKei = GetJoukenKei(buffer, 98);
            race.JoukenNenreiSeigen = GetJoukenNenreiSeigen(buffer, 98, 99);
            race.Jouken1 = DEFAULT_GETTER.GetInt32(buffer, 100, 5);
            race.DirtShiba = DEFAULT_GETTER.GetInt32(buffer, 105, 1).Value;
            race.MigiHidari = DEFAULT_GETTER.GetInt32(buffer, 106, 1).Value;
            race.UchiSoto = DEFAULT_GETTER.GetInt32(buffer, 107, 1);
            race.Course = DEFAULT_GETTER.GetInt32(buffer, 108, 1);
            race.Kyori = DEFAULT_GETTER.GetInt32(buffer, 109, 4).Value;
            DateTime? nengappi;
            nengappi = DATE_GETTER.GetDateTime(buffer, 114, 8);
            if (nengappi != null)
            {
                race.CourseRecordFlag = DEFAULT_GETTER.GetInt32(buffer, 113, 1);
                race.CourseRecordNengappi = nengappi;
                race.CourseRecordTime = TIME_GETTER.GetDouble(buffer, 122, 4);
                race.CourseRecordBamei = DEFAULT_GETTER.GetString(buffer, 126, 30);
                race.CourseRecordKinryou = ONE_TENTH_GETTER.GetDouble(buffer, 156, 3);
                race.CourseRecordTanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 159, 8);
            }
            nengappi = DATE_GETTER.GetDateTime(buffer, 167, 8);
            if (nengappi != null)
            {
                race.KyoriRecordNengappi = nengappi;
                race.KyoriRecordTime = TIME_GETTER.GetDouble(buffer, 175, 4);
                race.KyoriRecordBamei = DEFAULT_GETTER.GetString(buffer, 179, 30);
                race.KyoriRecordKinryou = ONE_TENTH_GETTER.GetDouble(buffer, 209, 3);
                race.KyoriRecordTanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 212, 8);
                race.KyoriRecordBasho = DEFAULT_GETTER.GetInt32(buffer, 220, 2);
            }
            nengappi = DATE_GETTER.GetDateTime(buffer, 222, 8);
            if (nengappi != null)
            {
                race.RaceRecordNengappi = nengappi;
                race.RaceRecordTime = TIME_GETTER.GetDouble(buffer, 230, 4);
                race.RaceRecordBamei = DEFAULT_GETTER.GetString(buffer, 234, 30);
                race.RaceRecordKinryou = ONE_TENTH_GETTER.GetDouble(buffer, 264, 3);
                race.RaceRecordTanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 267, 8);
                race.RaceRecordBasho = DEFAULT_GETTER.GetInt32(buffer, 275, 2);
            }
            race.Shoukin1Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 277, 9);
            race.Shoukin2Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 286, 9);
            race.Shoukin3Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 295, 9);
            race.Shoukin4Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 304, 9);
            race.Shoukin5Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 313, 9);
            race.FukaShou = ZERO_TO_NULL_GETTER.GetInt32(buffer, 322, 9);
            race.MaeuriFlag = DEFAULT_GETTER.GetInt32(buffer, 331, 1);
            race.YoteiHassouJikan = DEFAULT_GETTER.GetString(buffer, 332, 5);
            race.Tousuu = DEFAULT_GETTER.GetInt32(buffer, 337, 2).Value;
            race.TorikeshiTousuu = DEFAULT_GETTER.GetInt32(buffer, 339, 2).Value;
            race.SuiteiTimeRyou = TIME_GETTER.GetDouble(buffer, 341, 4);
            race.SuiteiTimeOmoFuryou = TIME_GETTER.GetDouble(buffer, 345, 4);
            race.YosouPace = DEFAULT_GETTER.GetInt32(buffer, 349, 1);
            race.ShutsubahyouSakuseiNengappi = dataSakuseiNengappi;

            return race;
        }

        protected override Shussouba BuildShussouba(byte[] buffer, Race race, long shussoubaId, DateTime dataSakuseiNengappi)
        {
            Shussouba shussouba = new Shussouba();

            shussouba.Id = shussoubaId;
            shussouba.RaceId = shussoubaId / 100;
            int kaisaiNen = GetKaisaiNen(shussouba.RaceId);
            shussouba.Umaban = (int)(shussoubaId % 100);
            shussouba.Wakuban = DEFAULT_GETTER.GetInt32(buffer, 22, 1).Value;
            shussouba.KyousoubaId = DEFAULT_GETTER.GetString(buffer, 25, 7);
            shussouba.KanaBamei = DEFAULT_GETTER.GetString(buffer, 32, 30);
            shussouba.UmaKigou = ZERO_TO_NULL_GETTER.GetInt32(buffer, 62, 2);
            shussouba.Seibetsu = DEFAULT_GETTER.GetInt32(buffer, 64, 1).Value;
            shussouba.Nenrei = GetNenrei(buffer, 65, kaisaiNen);
            shussouba.BanushiMei = DEFAULT_GETTER.GetString(buffer, 67, 40);
            shussouba.TanshukuBanushiMei = DEFAULT_GETTER.GetString(buffer, 107, 20);
            shussouba.Blinker = DEFAULT_GETTER.GetInt32(buffer, 147, 1);
            shussouba.Kinryou = ONE_TENTH_GETTER.GetDouble(buffer, 148, 3);
            shussouba.KishuId = DEFAULT_GETTER.GetInt32(buffer, 151, 5).Value;
            shussouba.KishuMei = DEFAULT_GETTER.GetString(buffer, 156, 32);
            shussouba.TanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 188, 8);
            shussouba.KishuTouzaiBetsu = DEFAULT_GETTER.GetInt32(buffer, 196, 1);
            shussouba.KishuShozokuBasho = DEFAULT_GETTER.GetInt32(buffer, 197, 2);
            shussouba.KishuShozokuKyuushaId = DEFAULT_GETTER.GetInt32(buffer, 199, 5);
            shussouba.MinaraiKubun = DEFAULT_GETTER.GetInt32(buffer, 204, 1);
            shussouba.Norikawari = DEFAULT_GETTER.GetInt32(buffer, 205, 1);
            shussouba.KyuushaId = DEFAULT_GETTER.GetInt32(buffer, 206, 5);
            shussouba.KyuushaMei = DEFAULT_GETTER.GetString(buffer, 211, 32);
            shussouba.TanshukuKyuushaMei = DEFAULT_GETTER.GetString(buffer, 243, 8);
            shussouba.KyuushaShozokuBasho = DEFAULT_GETTER.GetInt32(buffer, 251, 2);
            shussouba.KyuushaRitsuHokuNanBetsu = DEFAULT_GETTER.GetInt32(buffer, 253, 1);
            shussouba.YosouShirushi = DEFAULT_GETTER.GetInt32(buffer, 254, 1);
            shussouba.YosouShirushiHonshi = DEFAULT_GETTER.GetInt32(buffer, 255, 1);
            shussouba.ShutsubahyouSakuseiNengappi = dataSakuseiNengappi;
            shussouba.Seinen = GetSeinen(buffer, 735, 65, kaisaiNen);

            return shussouba;
        }

        protected override int? ChoukyouAwaseFlagIndex
        {
            get
            {
                return 607;
            }
        }

        protected override int? ChoukyouAwaseIndex
        {
            get
            {
                return 608;
            }
        }

        private static readonly IDictionary<int, int> CHOUKYOU_INDEX_MAP = new Dictionary<int, int>() {
			{ 2, 373 },
			{ 3, 490 }
		};

        protected override IDictionary<int, int> ChoukyouIndexMap
        {
            get
            {
                return CHOUKYOU_INDEX_MAP;
            }
        }

        protected override Choukyou BuildChoukyou(Shussouba shussouba, byte[] buffer)
        {
            var choukyou = new Choukyou();

            choukyou.Id = shussouba.Id;
            choukyou.KyousoubaId = shussouba.KyousoubaId;
            choukyou.Tanpyou = DEFAULT_GETTER.GetString(buffer, 694, 24);
            choukyou.HonsuuCourse = DEFAULT_GETTER.GetInt32(buffer, 718, 3);
            choukyou.HonsuuHanro = DEFAULT_GETTER.GetInt32(buffer, 721, 3);
            choukyou.HonsuuPool = DEFAULT_GETTER.GetInt32(buffer, 724, 3);
            choukyou.Rating = ONE_TENTH_GETTER.GetDouble(buffer, 739, 3);
            choukyou.KyuuyouRiyuu = DEFAULT_GETTER.GetString(buffer, 783, 60);

            return choukyou;
        }

    }
}
