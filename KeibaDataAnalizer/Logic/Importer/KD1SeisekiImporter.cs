using System;
using System.IO;
using System.Collections.Generic;

using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

using NLog;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public class KD1SeisekiImporter : KDSeisekiImporter
    {
		private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
		
        private String kolSeiPath;

        public KD1SeisekiImporter(ImportHistory importHistory, String kolSeiPath) : base(importHistory)
        {
            this.kolSeiPath = kolSeiPath;
        }

        #region KDImporter メンバ

        protected override int BytesOfRace
        {
            get { return 3178; }
        }

        protected override int BytesOfShussouba
        {
            get { return 132; }
        }

        protected override int RaceDataSakuseiNengappiIndex
        {
            get { throw new NotImplementedException(); }
        }

        protected override string KolSei1Path
        {
            get { throw new NotImplementedException(); }
        }

        protected override string KolSei2Path
        {
            get { throw new NotImplementedException(); }
        }

        protected override int LapTimeIndex
        {
            get { return 298; }
        }

        protected override int LapTimeIndexOfShougai
        {
            get { return 33; }
        }

        public override void Import()
        {
            long length = new FileInfo(kolSeiPath).Length;

            using (var fs = new BufferedStream(new FileStream(kolSeiPath, FileMode.Open, FileAccess.Read)))
            {
                importHistory.UncompressedFileName = Path.GetFileName(kolSeiPath);

                var buffer = new byte[BytesOfRace];
                var ticks = File.GetLastWriteTime(kolSeiPath).Ticks;
                var dataSakuseiNengappi = new DateTime(ticks);

                while (fs.Read(buffer, 0, BytesOfRace) == BytesOfRace)
                {
                    try
                    {
			            using(var transaction = new Transaction()){
			            	var db = transaction.DB;
			            	var con = transaction.Connection;
	                        var raceId = GetRaceId(buffer);
	                        var oldRace = db.TryFind<Race>(con, raceId);
	                        if (oldRace != null)
	                        {
	                            if (oldRace.SeisekiSakuseiNengappi != null && dataSakuseiNengappi <= oldRace.SeisekiSakuseiNengappi)
	                            {
	                                continue;
	                            }
	                            DatabaseUtil.SetForeignKey(db, con, true);
	                            db.Delete<Race>(con, oldRace);
	                            DatabaseUtil.SetForeignKey(db, con, false);
	                        }
	
	                        Race race = BuildRace(buffer, raceId, dataSakuseiNengappi);
	                        race.SeisekiSakuseiNengappi = dataSakuseiNengappi;
	                        db.Insert<Race>(con, race);
	
	                        var raceHaitou = BuildRaceHaitou(race, buffer);
	                        db.Insert<RaceHaitou>(con, raceHaitou);
	
	                        IList<RaceLapTime> raceLapTimeList;
	                        if (race.HeichiShougai == 0)
	                        {
	                            raceLapTimeList = BuildRaceLapTimeList(race, buffer, LapTimeIndex);
	                        }
	                        else
	                        {
	                            raceLapTimeList = BuildRaceLapTimeList(race, buffer, LapTimeIndexOfShougai);
	                        }
	                        foreach (var raceLapTime in raceLapTimeList)
	                        {
	                        	db.Insert<RaceLapTime>(con, raceLapTime);
	                        }
	
	                        for (int i = 0, max = race.Tousuu; i < max; i++)
	                        {
	                            byte[] shussoubaBuffer = new byte[BytesOfShussouba];
	                            Array.Copy(buffer, 792 + i * BytesOfShussouba, shussoubaBuffer, 0, BytesOfShussouba);
	                            var shussoubaId = GetShussoubaId(shussoubaBuffer, raceId);
	                            var oldShussouba = db.TryFind<Shussouba>(con, shussoubaId);
	                            if (oldShussouba != null)
	                            {
		                        	if(oldShussouba.SeisekiSakuseiNengappi != null){
		                        		if(dataSakuseiNengappi <= oldShussouba.SeisekiSakuseiNengappi){
		                        			// 既に最新の成績が入っている場合
			                                continue;
		                        		} else {
		                        			if(oldShussouba.ShutsubahyouSakuseiNengappi == null){
				                            	DatabaseUtil.SetForeignKey(db, con, true);
				                            	db.Delete<Shussouba>(con, oldShussouba);
				                            	DatabaseUtil.SetForeignKey(db, con, false);
				                            	oldShussouba = null;
		                        			}
		                        		}
		                        	}
	                            }
	
	                            var shussouba = BuildShussouba(shussoubaBuffer, race, shussoubaId, dataSakuseiNengappi);
		                        if (oldShussouba != null)
		                        {
		                            shussouba.ShutsubahyouSakuseiNengappi = oldShussouba.ShutsubahyouSakuseiNengappi;
		                            db.Update<Shussouba>(con, shussouba);
		                        }
		                        else{
			                        db.Insert<Shussouba>(con, shussouba);
		                        }
		                        
	                            var shussoubaTsuukaJuniList = BuildShussoubaTsuukaJuni(shussouba, buffer);
	                            foreach (var shussoubaTsuukaJuni in shussoubaTsuukaJuniList)
	                            {
	                            	db.Insert<ShussoubaTsuukaJuni>(con, shussoubaTsuukaJuni);
	                            }
	                            
					        	foreach (var userSQL in ModelUtil.GetUserSQLList("PostSeisekiShussoubaImport")) {
					        		try{
						        		db.Execute(con, userSQL.SQL, shussouba);
					        		} catch(Exception ex){
					        			LOGGER.Error(CommonUtil.FlattenException(ex));
					        		}
					        	}
		                        
	                        }
	
	                        var raceKeikaList = BuildRaceKeikaList(race, buffer);
	                        foreach (var raceKeika in raceKeikaList)
	                        {
	                        	db.Insert<RaceKeika>(con, raceKeika);
	                            var shussoubaKeikaList = BuildShussoubaKeikaList(raceKeika);
	                            foreach (var shussoubaKeika in shussoubaKeikaList)
	                            {
	                            	db.Insert<ShussoubaKeika>(con, shussoubaKeika);
	                            }
	                        }
	                        
				        	foreach (var userSQL in ModelUtil.GetUserSQLList("PostSeisekiRaceImport")) {
				        		try{
					        		db.Execute(con, userSQL.SQL, race);
				        		} catch(Exception ex){
				        			LOGGER.Error(CommonUtil.FlattenException(ex));
				        		}
				        	}
	                        
			            	transaction.Commit();
		            	}
                    }
                    catch (Exception ex)
                    {
                        importHistory.AddImportLog(null, null, "予期せぬエラーが発生しました。",
                            CommonUtil.FlattenException(ex));
                    }
                    finally
                    {
                        importHistory.Index += BytesOfRace;
                    }
                }
            }
        }

        protected override int GetUmaban(byte[] buffer)
        {
            int? umaban = DEFAULT_GETTER.GetInt32(buffer, 51, 2);
            return umaban.Value;
        }

        protected override Race BuildRace(byte[] buffer, long raceId, DateTime dataSakuseiNengappi)
        {
            var race = new Race();

            race.Id = raceId;
            race.KaisaiBasho = DEFAULT_GETTER.GetInt32(buffer, 0, 2).Value;
            race.KaisaiNen = DEFAULT_GETTER.GetInt32(buffer, 2, 4).Value;
            race.KaisaiKaiji = DEFAULT_GETTER.GetInt32(buffer, 6, 2).Value;
            race.KaisaiNichiji = DEFAULT_GETTER.GetInt32(buffer, 8, 2).Value;
            race.RaceBangou = DEFAULT_GETTER.GetInt32(buffer, 10, 2).Value;
            race.Nengappi = DATE_GETTER.GetDateTime(buffer, 12, 8).Value;
            race.KouryuuFlag = DEFAULT_GETTER.GetInt32(buffer, 23, 1);
            race.ChuuouChihouGaikoku = DEFAULT_GETTER.GetInt32(buffer, 20, 1).Value;
            race.IppanTokubetsu = DEFAULT_GETTER.GetInt32(buffer, 21, 1).Value;
            race.HeichiShougai = DEFAULT_GETTER.GetInt32(buffer, 22, 1).Value;
            race.JuushouKaisuu = ZERO_TO_NULL_GETTER.GetInt32(buffer, 53, 3);
            race.TokubetsuMei = DEFAULT_GETTER.GetString(buffer, 56, 30);
            race.Grade = DEFAULT_GETTER.GetInt32(buffer, 86, 1);
            race.BetteiBareiHandiShousai = DEFAULT_GETTER.GetString(buffer, 124, 18);
            race.JoukenFuka1 = DEFAULT_GETTER.GetInt32(buffer, 120, 2);
            race.JoukenFuka2 = DEFAULT_GETTER.GetInt32(buffer, 122, 2);
            race.JoukenKei = GetJoukenKei(buffer, 103);
            race.JoukenNenreiSeigen = GetJoukenNenreiSeigen(buffer, 103, 104);
            race.Jouken1 = DEFAULT_GETTER.GetInt32(buffer, 105, 5);
            if (race.ChuuouChihouGaikoku != 0)
            {
                race.Kumi1 = DEFAULT_GETTER.GetInt32(buffer, 110, 2);
                race.IjouIkaMiman = DEFAULT_GETTER.GetInt32(buffer, 112, 1);
                race.Jouken2 = DEFAULT_GETTER.GetInt32(buffer, 113, 5);
                race.Kumi2 = DEFAULT_GETTER.GetInt32(buffer, 118, 2);
            }
            race.DirtShiba = DEFAULT_GETTER.GetInt32(buffer, 87, 1).Value;
            race.MigiHidari = DEFAULT_GETTER.GetInt32(buffer, 88, 1).Value;
            race.UchiSoto = DEFAULT_GETTER.GetInt32(buffer, 89, 1).Value;
            race.Course = DEFAULT_GETTER.GetInt32(buffer, 90, 1);
            race.Kyori = DEFAULT_GETTER.GetInt32(buffer, 91, 4).Value;
            race.CourseRecordFlag = DEFAULT_GETTER.GetInt32(buffer, 28, 1);
            race.CourseRecordTime = TIME_GETTER.GetDouble(buffer, 29, 4);
            race.Shoukin1Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 142, 9);
            race.Shoukin2Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 151, 9);
            race.Shoukin3Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 160, 9);
            race.Shoukin4Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 169, 9);
            race.Shoukin5Chaku = ZERO_TO_NULL_GETTER.GetInt32(buffer, 178, 9);
            race.Shoukin5ChakuDouchaku1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 187, 9);
            race.FukaShou = ZERO_TO_NULL_GETTER.GetInt32(buffer, 196, 8);
            race.Tousuu = DEFAULT_GETTER.GetInt32(buffer, 95, 2).Value;
            race.TorikeshiTousuu = DEFAULT_GETTER.GetInt32(buffer, 97, 2).Value;
            race.SuiteiTimeRyou = TIME_GETTER.GetDouble(buffer, 24, 4);
            race.Pace = DEFAULT_GETTER.GetInt32(buffer, 101, 1);
            race.Tenki = DEFAULT_GETTER.GetInt32(buffer, 99, 1);
            race.Baba = DEFAULT_GETTER.GetInt32(buffer, 100, 1);
            race.Seed = DEFAULT_GETTER.GetInt32(buffer, 102, 1);
            if (race.HeichiShougai == 1) // 障害
            {
                race.ShougaiHeikin1F = ZERO_TO_NULL_GETTER.GetDouble(buffer, 49, 4);
            }
            race.SeisekiSakuseiNengappi = dataSakuseiNengappi;

            return race;
        }

        protected override RaceHaitou BuildRaceHaitou(Race race, byte[] buffer)
        {
            var raceHaitou = new RaceHaitou();

            raceHaitou.Id = race.Id;
            raceHaitou.TanUmaban1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 250, 2);
            raceHaitou.TanshouHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 252, 6);
            raceHaitou.TanUmaban2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 258, 2);
            raceHaitou.TanshouHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 260, 6);
            raceHaitou.FukuUmaban1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 266, 2);
            raceHaitou.FukushouHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 268, 6);
            raceHaitou.FukuUmaban2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 274, 2);
            raceHaitou.FukushouHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 276, 6);
            raceHaitou.FukuUmaban3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 282, 2);
            raceHaitou.FukushouHaitoukin3 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 284, 6);
            raceHaitou.FukuUmaban4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 290, 2);
            raceHaitou.FukushouHaitoukin4 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 292, 6);
            raceHaitou.Wakuren11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 204, 1);
            raceHaitou.Wakuren12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 205, 1);
            raceHaitou.WakurenHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 206, 6);
            raceHaitou.WakurenNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 212, 2);
            raceHaitou.Wakuren21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 214, 1);
            raceHaitou.Wakuren22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 215, 1);
            raceHaitou.WakurenHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 216, 6);
            raceHaitou.WakurenNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 222, 2);
            raceHaitou.Umaren11 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 224, 2);
            raceHaitou.Umaren12 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 226, 2);
            raceHaitou.UmarenHaitoukin1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 228, 6);
            raceHaitou.UmarenNinki1 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 234, 3);
            raceHaitou.Umaren21 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 237, 2);
            raceHaitou.Umaren22 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 239, 2);
            raceHaitou.UmarenHaitoukin2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 241, 6);
            raceHaitou.UmarenNinki2 = ZERO_TO_NULL_GETTER.GetInt32(buffer, 247, 3);

            return raceHaitou;
        }

        protected override int KeikaIndex
        {
            get { return 352; }
        }

        protected override int HassouJoukyouIndex
        {
            get { throw new NotImplementedException(); }
        }

        protected override IList<RaceKeika> BuildRaceKeikaList(Race Race, byte[] buffer)
        {
            IList<RaceKeika> RaceKeikaList = new List<RaceKeika>();

            for (int bangou = 1, offset = KeikaIndex; bangou <= 4; bangou++, offset += 110)
            {
                var keika = DEFAULT_GETTER.GetString(buffer, offset, 110);
                if (keika == null)
                {
                    continue;
                }

                var RaceKeika = new RaceKeika();

                RaceKeika.Id = Race.Id * 10 + bangou;
                RaceKeika.RaceId = Race.Id;
                RaceKeika.Keika = keika;

                RaceKeikaList.Add(RaceKeika);
            }

            return RaceKeikaList;
        }

        protected override Shussouba BuildShussouba(byte[] buffer, Race race, long shussoubaId, DateTime dataSakuseiNengappi)
        {
            var shussouba = new Shussouba();

            shussouba.Id = shussoubaId;
            shussouba.RaceId = shussoubaId / 100;
            int kaisaiNen = GetKaisaiNen(shussouba.RaceId);
            shussouba.Umaban = (int)(shussoubaId % 100);
            shussouba.Wakuban = DEFAULT_GETTER.GetInt32(buffer, 50, 1).Value;
            shussouba.Gate = DEFAULT_GETTER.GetInt32(buffer, 53, 2).Value;
            shussouba.KyousoubaId = DEFAULT_GETTER.GetString(buffer, 0, 7);
            shussouba.KanaBamei = DEFAULT_GETTER.GetString(buffer, 7, 30);
            shussouba.Seibetsu = DEFAULT_GETTER.GetInt32(buffer, 41, 1).Value;
            shussouba.Nenrei = GetNenrei(buffer, 42, kaisaiNen);
            shussouba.Blinker = DEFAULT_GETTER.GetInt32(buffer, 84, 1);
            shussouba.Kinryou = ONE_TENTH_GETTER.GetDouble(buffer, 55, 3);
            shussouba.Bataijuu = ZERO_TO_NULL_GETTER.GetInt32(buffer, 72, 3);
            shussouba.Zougen = DEFAULT_GETTER.GetInt32(buffer, 75, 3);
            shussouba.RecordShisuu = ZERO_TO_NULL_GETTER.GetInt32(buffer, 111, 3);
            shussouba.KishuId = DEFAULT_GETTER.GetInt32(buffer, 59, 5).Value;
            shussouba.TanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 115, 8);
            shussouba.MinaraiKubun = DEFAULT_GETTER.GetInt32(buffer, 58, 1);
            shussouba.Norikawari = DEFAULT_GETTER.GetInt32(buffer, 64, 1);
            shussouba.KyuushaId = DEFAULT_GETTER.GetInt32(buffer, 78, 5);
            shussouba.TanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 123, 8);
            shussouba.YosouShirushi = DEFAULT_GETTER.GetInt32(buffer, 83, 1);
            shussouba.Ninki = ZERO_TO_NULL_GETTER.GetInt32(buffer, 65, 2);
            shussouba.Odds = ONE_TENTH_GETTER.GetDouble(buffer, 67, 5);
            shussouba.KakuteiChakujun = ZERO_TO_NULL_GETTER.GetInt32(buffer, 44, 2);
            shussouba.ChakujunFuka = DEFAULT_GETTER.GetInt32(buffer, 46, 2);
            shussouba.NyuusenChakujun = ZERO_TO_NULL_GETTER.GetInt32(buffer, 48, 2);
            shussouba.TorikeshiShubetsu = DEFAULT_GETTER.GetInt32(buffer, 131, 1);
            shussouba.RecordNinshiki = DEFAULT_GETTER.GetInt32(buffer, 85, 1);
            shussouba.Time = TIME_GETTER.GetDouble(buffer, 86, 4);
            shussouba.Chakusa1 = DEFAULT_GETTER.GetInt32(buffer, 90, 2);
            shussouba.Chakusa2 = DEFAULT_GETTER.GetInt32(buffer, 92, 1);
            shussouba.TimeSa = GetTimeSa(buffer, 93);
            if(race.Kyori >= 1200){
	            shussouba.Zenhan3F = ONE_TENTH_GETTER.GetDouble(buffer, 96, 3);
            }
            shussouba.Kouhan3F = ONE_TENTH_GETTER.GetDouble(buffer, 99, 3);
            shussouba.YonCornerIchiDori = DEFAULT_GETTER.GetInt32(buffer, 110, 1);
            shussouba.Seinen = kaisaiNen - shussouba.Nenrei;

            return shussouba;
        }

        protected override int TsuukaJuniIndex
        {
            get { return 102; }
        }

        #endregion


    }
}
