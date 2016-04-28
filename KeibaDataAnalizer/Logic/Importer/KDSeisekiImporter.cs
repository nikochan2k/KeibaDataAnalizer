using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using System.IO;
using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Enum;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

using NLog;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public abstract class KDSeisekiImporter : KDRaceShussoubaImporter
    {
		private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
		
        protected KDSeisekiImporter(ImportHistory importHistory) : base(importHistory)
        {
        }

        protected override int ShussoubaDataSakuseiNengappiIndex
        {
            get
            {
                return 424;
            }
        }

        protected abstract String KolSei1Path { get; }

        protected abstract String KolSei2Path { get; }


        protected override int? ChoukyouAwaseFlagIndex
        {
            get
            {
                return null;
            }
        }

        protected override int? ChoukyouAwaseIndex
        {
            get
            {
                return null;
            }
        }

        private static readonly IDictionary<int, int> CHOUKYOU_INDEX_MAP = new Dictionary<int, int>()
                        {
                            {0, 307}
                        };

        protected override IDictionary<int, int> ChoukyouIndexMap
        {
            get
            {
                return CHOUKYOU_INDEX_MAP;
            }
        }

        public override void Import()
        {
        	var raceMap = new Dictionary<long, Race>();
        	var shussoubaKeikaList = new List<ShussoubaKeika>();
        	var shussoubaHassouJoukyouList = new List<ShussoubaHassouJoukyou>();
            using (var fs = new BufferedStream(new FileStream(KolSei1Path, FileMode.Open, FileAccess.Read)))
            {
                importHistory.UncompressedFileName = Path.GetFileName(KolSei1Path);

                var buffer = new byte[BytesOfRace];
                var fileNengappi = File.GetLastWriteTime(KolSei1Path);

                while (fs.Read(buffer, 0, BytesOfRace) == BytesOfRace)
                {
                    try
                    {
			            using(var transaction = new Transaction()){
			            	var db = transaction.DB;
			            	var con = transaction.Connection;
	                        DateTime? dataSakuseiNengappi = DATE_GETTER.GetDateTime(buffer, RaceDataSakuseiNengappiIndex, 8);
	                        if (dataSakuseiNengappi == null)
	                        {
	                            dataSakuseiNengappi = fileNengappi;
	                        }
	                        long raceId = GetRaceId(buffer);
	                        var oldRace = db.TryFind<Race>(con, raceId);
	                        if (oldRace != null)
	                        {
	                            if (oldRace.SeisekiSakuseiNengappi != null &&
	                        	    dataSakuseiNengappi <= oldRace.SeisekiSakuseiNengappi)
	                            {
	                        		raceMap.Add(raceId, oldRace);
	                                continue;
	                            }
	                        }

	                        // 成績レースデータの格納
	                        Race race = BuildRace(buffer, raceId, dataSakuseiNengappi.Value);
	                        raceMap.Add(raceId, race);
	                        if (oldRace != null)
	                        {
	                        	// 既に成績レースデータが入っている場合
	                            race.YosouPace = oldRace.YosouPace;
	                            race.ShutsubahyouSakuseiNengappi = oldRace.ShutsubahyouSakuseiNengappi;
	                            db.Update<Race>(con, race);
	                        }
	                        else{
		                        db.Insert<Race>(con, race);
	                        }
	
	                        RaceHaitou raceHaitou = BuildRaceHaitou(race, buffer);
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
	
	                        var raceKeikaList = BuildRaceKeikaList(race, buffer);
	                        foreach (var raceKeika in raceKeikaList)
	                        {
	                        	db.Insert<RaceKeika>(con, raceKeika);
	                            shussoubaKeikaList.AddRange(BuildShussoubaKeikaList(raceKeika));
	                        }
	
	                        var raceHassouJoukyouList = BuildRaceHassouJoukyouList(race, buffer);
	                        foreach (var raceHassouJoukyou in raceHassouJoukyouList)
	                        {
	                        	db.Insert<RaceHassouJoukyou>(con, raceHassouJoukyou);
	                            shussoubaHassouJoukyouList.AddRange(BuildShussoubaHassouJoukyouList(raceHassouJoukyou));
	                        }
	                        
	                        transaction.Commit();
			            }
                    }
                    catch (Exception ex)
                    {
                        importHistory.AddImportLog(null, null, "予期せぬエラーが発生しました。",
                            CommonUtil.FlattenException(ex), ImportFileStatusEnum.一部失敗);
                    }
                    finally
                    {
                        importHistory.Index += BytesOfRace;
                    }
                }
            }
            using (var fs = new BufferedStream(new FileStream(KolSei2Path, FileMode.Open, FileAccess.Read)))
            {
                importHistory.UncompressedFileName = Path.GetFileName(KolSei2Path);

                var buffer = new byte[BytesOfShussouba];
                var ticks = File.GetLastWriteTime(KolSei2Path).Ticks;
                var fileNengappi = new DateTime(ticks);

                while (fs.Read(buffer, 0, BytesOfShussouba) == BytesOfShussouba)
                {
                    try
                    {
			            using(var transaction = new Transaction()){
			            	var db = transaction.DB;
			            	var con = transaction.Connection;
	                        DateTime? dataSakuseiNengappi = DATE_GETTER.GetDateTime(buffer, ShussoubaDataSakuseiNengappiIndex, 8);
	                        if (dataSakuseiNengappi == null)
	                        {
	                            dataSakuseiNengappi = fileNengappi;
	                        }
	                        var raceId = GetRaceId(buffer);
	                        var race = raceMap[raceId];
	                        var shussoubaId = GetShussoubaId(buffer, raceId);
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
							
	                        // 出走馬
	                        var shussouba = BuildShussouba(buffer, race, shussoubaId, dataSakuseiNengappi.Value);
	                        if (oldShussouba != null)
	                        {
	                            shussouba.ShutsubahyouSakuseiNengappi = oldShussouba.ShutsubahyouSakuseiNengappi;
	                            db.Update<Shussouba>(con, shussouba);
	                        }
	                        else{
		                        db.Insert<Shussouba>(con, shussouba);
	                        }
	
	                        if (oldShussouba == null)
	                        {
	                        	// 調教
				                var choukyou = BuildChoukyou(shussouba, buffer);
				                // 調教履歴
	                            var choukyouRirekiMap = BuildChoukyouRirekiMap(choukyou, buffer);
	                            // 調教タイム
	                            foreach (var choukyouRireki in choukyouRirekiMap.Keys)
	                            {
	                            	db.Insert<Choukyou>(con, choukyou);
	                                var choukyouTimeList = choukyouRirekiMap[choukyouRireki];
	                                db.Insert<ChoukyouRireki>(con, choukyouRireki);
	                                foreach (var choukyouTime in choukyouTimeList)
	                                {
	                                	db.Insert<ChoukyouTime>(con, choukyouTime);
	                                }
	                            }
	                        }
							
	                        // 出走馬通過順位
	                        var shussoubaTsuukaJuniList = BuildShussoubaTsuukaJuni(shussouba, buffer);
	                        foreach (var shussoubaTsuukaJuni in shussoubaTsuukaJuniList)
	                        {
	                        	db.Insert<ShussoubaTsuukaJuni>(con,shussoubaTsuukaJuni);
	                        }
	                        
			                // 成績出走馬データ格納後のカスタム処理
				        	foreach (var userSQL in ModelUtil.GetUserSQLList("PostSeisekiShussoubaImport")) {
				        		try{
					        		db.Execute(con, userSQL.SQL, shussouba);
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
                            CommonUtil.FlattenException(ex), ImportFileStatusEnum.一部失敗);
                    }
                    finally
                    {
                        importHistory.Index += BytesOfShussouba;
                    }
                }
            }
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
                // 出走馬経過 ※Raceデータより作成
                foreach (var shussoubaKeika in shussoubaKeikaList)
                {
                	db.Insert<ShussoubaKeika>(con, shussoubaKeika);
                }
                
                // 出走場発走状況 ※Raceデータより作成
                foreach (var shussoubaHassouJoukyou in shussoubaHassouJoukyouList)
                {
                	db.Insert<ShussoubaHassouJoukyou>(con, shussoubaHassouJoukyou);
                }
                
                // 成績レースデータ格納後のカスタム処理
                foreach (var race in raceMap.Values) {
		        	foreach (var userSQL in ModelUtil.GetUserSQLList("PostSeisekiRaceImport")) {
		        		try{
			        		db.Execute(con, userSQL.SQL, race);
		        		} catch(Exception ex){
		        			LOGGER.Error(CommonUtil.FlattenException(ex));
		        		}
		        	}
                }
                
                transaction.Commit();
            }
        }
        
        protected abstract RaceHaitou BuildRaceHaitou(Race Race, byte[] buffer);

        protected abstract int LapTimeIndex { get; }

        protected abstract int LapTimeIndexOfShougai { get; }

        protected readonly IDictionary<int, int> SHOUGAI_KEIKA_MAP = new Dictionary<int, int>()
        {
            {0, 5},
            {6, 4},
            {11, 4}
        };

        protected IList<RaceLapTime> BuildRaceLapTimeList(Race race, byte[] buffer, int index)
        {
            var raceLapTimeList = new List<RaceLapTime>();
            int kyori = race.Kyori;
            if (race.HeichiShougai == 1) // 障害
            {
                int i = 0;
                foreach (int offset in SHOUGAI_KEIKA_MAP.Keys)
                {
                    ++i;
                    double? lapTime = ZERO_TO_NULL_GETTER.GetDouble(buffer, index + offset, SHOUGAI_KEIKA_MAP[offset]);
                    if (lapTime == null)
                    {
                        continue;
                    }
                    var raceLapTime = new RaceLapTime();

                    raceLapTime.Id = race.Id * 100 + i;
                    raceLapTime.Bangou = i;
                    raceLapTime.RaceId = race.Id;
                    raceLapTime.LapTime = lapTime.Value;
                    switch (i)
                    {
                        case 1:
                            raceLapTime.KaishiKyori = kyori - 1600;
                            break;
                        case 2:
                            raceLapTime.KaishiKyori = kyori - 800;
                            break;
                        case 3:
                            raceLapTime.KaishiKyori = kyori - 600;
                            break;
                    }
                    raceLapTime.ShuuryouKyori = kyori;

                    raceLapTimeList.Add(raceLapTime);
                }
            }
            else if ((race.ChuuouChihouGaikoku == 2 // 公営
                || race.ChuuouChihouGaikoku == 3) // 道営
                && ONE_TENTH_GETTER.GetDouble(buffer, index, 3) == null)
            {
                for (int i = 0; i < 5; i++)
                {
                    var lapTime = ONE_TENTH_GETTER.GetDouble(buffer, index + 3 * (13 + i), 3);
                    if (lapTime == null)
                    {
                        continue;
                    }

                    var raceLapTime = new RaceLapTime();

                    raceLapTime.Id = race.Id * 100 + 14 + (i + 1);
                    raceLapTime.Bangou = i + 1;
                    raceLapTime.RaceId = race.Id;
                    raceLapTime.LapTime = lapTime.Value;
                    switch (i)
                    {
                        case 0: // 前半3F
                            raceLapTime.KaishiKyori = 0;
                            raceLapTime.ShuuryouKyori = 600;
                            break;
                        case 1: // 前半4F
                            raceLapTime.KaishiKyori = 0;
                            raceLapTime.ShuuryouKyori = 800;
                            break;
                        case 2: // 前半5F
                            raceLapTime.KaishiKyori = 0;
                            raceLapTime.ShuuryouKyori = 1000;
                            break;
                        case 3: // 後半4F
                            raceLapTime.KaishiKyori = kyori - 800;
                            raceLapTime.ShuuryouKyori = kyori;
                            break;
                        case 4: // 後半3F
                            raceLapTime.KaishiKyori = kyori - 600;
                            raceLapTime.ShuuryouKyori = kyori;
                            break;
                    }

                    raceLapTimeList.Add(raceLapTime);
                }
            }
            else
            {
                int count = (int)Math.Ceiling(race.Kyori / 200.0);
                bool odd = (race.Kyori % 200 != 0);
                int shuuryouKyori = 0;
                for (int i = 0; i < count; i++, index += 3)
                {
                    Double? lapTime = ONE_TENTH_GETTER.GetDouble(buffer, index, 3);
                    if (lapTime == null)
                    {
                        continue;
                    }

                    var raceLapTime = new RaceLapTime();

                    raceLapTime.Id = race.Id * 100 + (i + 1);
                    raceLapTime.Bangou = (i + 1);
                    raceLapTime.RaceId = race.Id;
                    raceLapTime.KaishiKyori = shuuryouKyori;
                    if (i == 0 && odd)
                    {
                        shuuryouKyori = 100;
                    }
                    else
                    {
                        shuuryouKyori += 200;
                    }
                    raceLapTime.ShuuryouKyori = shuuryouKyori;
                    raceLapTime.LapTime = lapTime.Value;

                    raceLapTimeList.Add(raceLapTime);
                }
            }
            return raceLapTimeList;
        }

        protected abstract int KeikaIndex { get; }

        protected virtual IList<RaceKeika> BuildRaceKeikaList(Race race, byte[] buffer)
        {
            IList<RaceKeika> raceKeikaList = new List<RaceKeika>();

            for (int bangou = 1, offset = KeikaIndex; bangou <= 9; bangou++, offset += 113)
            {
                var keika = DEFAULT_GETTER.GetString(buffer, offset + 3, 110);
                if (keika == null)
                {
                    continue;
                }

                var raceKeika = new RaceKeika();

                raceKeika.Id = race.Id * 10 + bangou;
                raceKeika.RaceId = race.Id;
                raceKeika.Bangou = bangou;
                raceKeika.Midashi1 = DEFAULT_GETTER.GetInt32(buffer, offset, 1);
                raceKeika.Midashi2 = DEFAULT_GETTER.GetInt32(buffer, offset + 1, 2);
                raceKeika.Keika = keika;

                raceKeikaList.Add(raceKeika);
            }

            return raceKeikaList;
        }

        protected static readonly IList<ShussoubaKeika> EMPTY_SHUSSOUBA_KEIKA_LIST = new List<ShussoubaKeika>(0);

        protected virtual IList<ShussoubaKeika> BuildShussoubaKeikaList(RaceKeika raceKeika)
        {
            var shussoubaKeikaList = new List<ShussoubaKeika>();
            var shussoubaIdList = new List<long>();

            String umaban = String.Empty;	// 馬番を格納する文字列の初期化
            String keika = raceKeika.Keika;
            if (keika == null)
            {
                return EMPTY_SHUSSOUBA_KEIKA_LIST;
            }

            var tate = new StringBuilder();	// 縦の位置
            var yoko = new StringBuilder();	// 横の位置
            bool bracket = false;	// 括弧の有無

            int length = keika.Length;
            for (int i = 0; i < length; i++)
            {
                // 文字を読み込む
                char ch = keika[i];
                // 数字ならば
                if (Char.IsDigit(ch))
                {
                    if (0 < i && keika[i - 1] == ')')
                    {
                        tate.Append('.');
                    }
                    umaban = umaban + ch;			// 数字を連結する
                    // 最後の文字が数字ならば
                    if (i == length - 1)
                    {
                        AddShussoubaKeika(shussoubaKeikaList, shussoubaIdList,
                            raceKeika, umaban, tate, yoko);
                    }
                    continue;
                }
                // 数字でなければ
                else
                {
                    // 数字を読み込んでいれば
                    if (umaban.Length > 0)
                    {
                        AddShussoubaKeika(shussoubaKeikaList, shussoubaIdList,
                            raceKeika, umaban, tate, yoko);
                        umaban = String.Empty;
                    }
                    // "("のあとの場合
                    if (bracket)
                    {
                        switch (ch)
                        {
                            case '.':
                                yoko.Append(ch);
                                break;
                            case ')':
                                yoko = new StringBuilder();
                                bracket = false;
                                break;
                            case '止':
                            case '落':
                                break;
                            default:
                                importHistory.AddImportLog(null, null, "不正な経過" + raceKeika.Id + " : " + keika, null, ImportFileStatusEnum.一部失敗);
                                return EMPTY_SHUSSOUBA_KEIKA_LIST;
                        }
                    }
                    else
                    {
                        switch (ch)
                        {
                            case '-':
                            case '=':
                            case '.':
                                tate.Append(ch);
                                break;
                            case '(':
                                tate.Append('.');
                                bracket = true;
                                break;
                            case '止':
                            case '落':
                                break;
                            default:
                                importHistory.AddImportLog(null, null, "不正な経過" + raceKeika.Id + " : " + keika, null, ImportFileStatusEnum.一部失敗);
                                return EMPTY_SHUSSOUBA_KEIKA_LIST;
                        }
                    }
                }
            }

            return shussoubaKeikaList;
        }

        protected virtual void AddShussoubaKeika(IList<ShussoubaKeika> shussoubaKeikaList,
            IList<long> shussoubaIdList, RaceKeika raceKeika, String umaban,
            StringBuilder tate, StringBuilder yoko)
        {
            int iUmaban = Int32.Parse(umaban);
            long shussoubaId = raceKeika.RaceId * 100 + iUmaban;
            if (shussoubaIdList.Contains(shussoubaId))
            {
                importHistory.AddImportLog(null, null,
                    "成績レース経過[" + raceKeika.Id + "]にて重複する馬番 : " + umaban,
                    null, ImportFileStatusEnum.一部失敗);
                return;
            }
            shussoubaIdList.Add(shussoubaId);

            ShussoubaKeika shussoubaKeika = new ShussoubaKeika();

            shussoubaKeika.Id = raceKeika.Id * 100 + iUmaban;
            shussoubaKeika.RaceKeikaId = raceKeika.Id;
            shussoubaKeika.ShussoubaId = shussoubaId;
            shussoubaKeika.Tate = tate.ToString();
            shussoubaKeika.Yoko = yoko.ToString();

            shussoubaKeikaList.Add(shussoubaKeika);
        }

        protected override Shussouba BuildShussouba(byte[] buffer, Race race, long shussoubaId, DateTime dataSakuseiNengappi)
        {
            Shussouba shussouba = new Shussouba();

            shussouba.Id = shussoubaId;
            shussouba.RaceId = race.Id;
            int kaisaiNen = GetKaisaiNen(shussouba.RaceId);
            shussouba.Umaban = (int)(shussoubaId % 100);
            shussouba.Wakuban = DEFAULT_GETTER.GetInt32(buffer, 22, 1).Value;
            shussouba.Gate = DEFAULT_GETTER.GetInt32(buffer, 25, 2).Value;
            shussouba.KyousoubaId = DEFAULT_GETTER.GetString(buffer, 27, 7);
            shussouba.KanaBamei = DEFAULT_GETTER.GetString(buffer, 34, 30);
            shussouba.UmaKigou = ZERO_TO_NULL_GETTER.GetInt32(buffer, 64, 2);
            shussouba.Seibetsu = DEFAULT_GETTER.GetInt32(buffer, 66, 1).Value;
            shussouba.Nenrei = GetNenrei(buffer, 67, kaisaiNen);
            shussouba.BanushiMei = DEFAULT_GETTER.GetString(buffer, 69, 40);
            shussouba.TanshukuBanushiMei = DEFAULT_GETTER.GetString(buffer, 109, 20);
            shussouba.Blinker = DEFAULT_GETTER.GetInt32(buffer, 149, 1);
            shussouba.Kinryou = ONE_TENTH_GETTER.GetDouble(buffer, 150, 3);
            shussouba.Bataijuu = ZERO_TO_NULL_GETTER.GetInt32(buffer, 153, 3);
            shussouba.Zougen = DEFAULT_GETTER.GetInt32(buffer, 156, 3);
            shussouba.RecordShisuu = ZERO_TO_NULL_GETTER.GetInt32(buffer, 159, 3);
            shussouba.KishuId = DEFAULT_GETTER.GetInt32(buffer, 162, 5).Value;
            shussouba.KishuMei = DEFAULT_GETTER.GetString(buffer, 167, 32);
            shussouba.TanshukuKishuMei = DEFAULT_GETTER.GetString(buffer, 199, 8);
            shussouba.KishuTouzaiBetsu = DEFAULT_GETTER.GetInt32(buffer, 207, 1);
            shussouba.KishuShozokuBasho = DEFAULT_GETTER.GetInt32(buffer, 208, 2);
            shussouba.KishuShozokuKyuushaId = DEFAULT_GETTER.GetInt32(buffer, 210, 5);
            shussouba.MinaraiKubun = DEFAULT_GETTER.GetInt32(buffer, 215, 1);
            shussouba.Norikawari = DEFAULT_GETTER.GetInt32(buffer, 216, 1);
            shussouba.KyuushaId = DEFAULT_GETTER.GetInt32(buffer, 217, 5);
            shussouba.KyuushaMei = DEFAULT_GETTER.GetString(buffer, 222, 32);
            shussouba.TanshukuKyuushaMei = DEFAULT_GETTER.GetString(buffer, 254, 8);
            shussouba.KyuushaShozokuBasho = DEFAULT_GETTER.GetInt32(buffer, 262, 2);
            shussouba.KyuushaRitsuHokuNanBetsu = DEFAULT_GETTER.GetInt32(buffer, 264, 1);
            shussouba.YosouShirushi = DEFAULT_GETTER.GetInt32(buffer, 265, 1);
            shussouba.YosouShirushiHonshi = DEFAULT_GETTER.GetInt32(buffer, 266, 1);
            shussouba.Ninki = ZERO_TO_NULL_GETTER.GetInt32(buffer, 267, 2);
            shussouba.Odds = ONE_TENTH_GETTER.GetDouble(buffer, 269, 5);
            shussouba.KakuteiChakujun = ZERO_TO_NULL_GETTER.GetInt32(buffer, 274, 2);
            shussouba.ChakujunFuka = DEFAULT_GETTER.GetInt32(buffer, 276, 2);
            shussouba.NyuusenChakujun = ZERO_TO_NULL_GETTER.GetInt32(buffer, 278, 2);
            shussouba.TorikeshiShubetsu = DEFAULT_GETTER.GetInt32(buffer, 280, 1);
            shussouba.RecordNinshiki = DEFAULT_GETTER.GetInt32(buffer, 281, 1);
            shussouba.Time = TIME_GETTER.GetDouble(buffer, 282, 4);
            shussouba.Chakusa1 = DEFAULT_GETTER.GetInt32(buffer, 286, 2);
            shussouba.Chakusa2 = DEFAULT_GETTER.GetInt32(buffer, 288, 1);
            shussouba.TimeSa = GetTimeSa(buffer, 289);
            if(race.Kyori >= 1200){
	            shussouba.Zenhan3F = ONE_TENTH_GETTER.GetDouble(buffer, 292, 3);
            }
            shussouba.Kouhan3F = ONE_TENTH_GETTER.GetDouble(buffer, 295, 3);
            shussouba.YonCornerIchiDori = DEFAULT_GETTER.GetInt32(buffer, 306, 1);
            shussouba.SeisekiSakuseiNengappi = dataSakuseiNengappi;
            shussouba.Seinen = GetSeinen(buffer, 432, 67, kaisaiNen);

            return shussouba;
        }

        protected virtual Choukyou BuildChoukyou(Shussouba shussouba, byte[] buffer)
        {
            var choukyou = new Choukyou();

            choukyou.Id = shussouba.Id;
            choukyou.KyousoubaId = shussouba.KyousoubaId;

            return choukyou;
        }

        protected abstract int HassouJoukyouIndex { get; }

        private static readonly Regex BASHIN = new Regex("([0-9.]+)馬身(半)?");

        private static readonly Regex BYOU = new Regex("([0-9.]+)秒(以上)?");

        private static readonly Regex UMABAN = new Regex(@"(\([0-9]+\))+?");

        protected virtual IList<RaceHassouJoukyou> BuildRaceHassouJoukyouList(Race race, byte[] buffer)
        {
            var raceHassouJoukyouList = new List<RaceHassouJoukyou>();

            for (int bangou = 1, offset = HassouJoukyouIndex; bangou <= 6; bangou++, offset += 80)
            {
                String s = DEFAULT_GETTER.GetString(buffer, offset, 80);
                if (s == null)
                {
                    continue;
                }

                if (!UMABAN.IsMatch(s))
                {
                    continue;
                }

                var raceHassouJoukyou = new RaceHassouJoukyou();

                raceHassouJoukyou.Id = race.Id * 10 + bangou;
                raceHassouJoukyou.RaceId = race.Id;
                StringBuilder sb = new StringBuilder();
                foreach (var umaban in UMABAN.Matches(s))
                {
                    sb.Append(umaban);
                }
                raceHassouJoukyou.UmabanGun = sb.ToString();
                raceHassouJoukyou.HassouJoukyou = UMABAN.Replace(s, "").Trim();

                Match m;
                if ((m = BASHIN.Match(s)).Success)
                {
                    raceHassouJoukyou.FuriByousuu = Double.Parse(m.Groups[1].Value) * 0.2; // 1馬身0.2秒
                    if (!String.Empty.Equals(m.Groups[2].Value))
                    {
                        raceHassouJoukyou.FuriByousuu += 0.1;
                    }
                }
                else if (s.Contains("半馬身"))
                {
                    raceHassouJoukyou.FuriByousuu = 0.1;
                }
                else if ((m = BYOU.Match(s)).Success)
                {
                    raceHassouJoukyou.FuriByousuu = Double.Parse(m.Groups[1].Value);
                    if (!String.Empty.Equals(m.Groups[2].Value))
                    {
                        raceHassouJoukyou.FuriByousuu += 0.5;
                    }
                }

                if (s.Contains("遅れ") || s.Contains("スタート") || s.Contains("ゲート")
                    || s.Contains("ダッシュ") || s.Contains("アオ") || s.Contains("好発")
                    || s.Contains("外枠発走"))
                {
                    raceHassouJoukyou.Ichi = 1;
                }
                else if (s.Contains("障害") || s.Contains("バンケット") || s.Contains("水ごう"))
                {
                    raceHassouJoukyou.Ichi = 4;
                }
                else if (s.Contains("正面") || s.Contains("直線") || s.Contains("ゴール")
                    || s.Contains("スタンド"))
                {
                    raceHassouJoukyou.Ichi = 2;
                }
                else if (s.Contains("角"))
                {
                    raceHassouJoukyou.Ichi = 3;
                }
                else
                {
                    raceHassouJoukyou.Ichi = 5;
                }

                if (s.Contains("好発"))
                {
                    raceHassouJoukyou.Joukyou = 50;
                }
                else if (s.Contains("遅れ") || s.Contains("スタート") || s.Contains("ゲート")
                    || s.Contains("ダッシュ") || s.Contains("アオ"))
                {
                    raceHassouJoukyou.Joukyou = 41;
                }
                else if (s.Contains("外枠発走"))
                {
                    raceHassouJoukyou.Joukyou = 42;
                }
                else if (s.Contains("落馬"))
                {
                    raceHassouJoukyou.Joukyou = 31;
                }
                else if (s.Contains("中止"))
                {
                    raceHassouJoukyou.Joukyou = 33;
                }
                else if (s.Contains("ふくれる") || s.Contains("ササる") || s.Contains("ささる")
                    || s.Contains("ヨレる") || s.Contains("よれる") || s.Contains("斜行")
                    || s.Contains("内ラチ") || s.Contains("切れる"))
                {
                    raceHassouJoukyou.Joukyou = 43;
                }
                else
                {
                    raceHassouJoukyou.Joukyou = 40;
                }

                raceHassouJoukyouList.Add(raceHassouJoukyou);
            }

            return raceHassouJoukyouList;
        }

        protected virtual IList<ShussoubaHassouJoukyou> BuildShussoubaHassouJoukyouList(RaceHassouJoukyou raceHassouJoukyou)
        {
            var shussoubaHassouJoukyouList = new List<ShussoubaHassouJoukyou>();
            var shussoubaIdList = new List<long>();

            foreach (Match m in UMABAN.Matches(raceHassouJoukyou.UmabanGun))
            {
                var umaban = Int32.Parse(m.Value.Substring(1, m.Value.Length - 2));
                var shussoubaId = raceHassouJoukyou.RaceId * 100 + umaban;
                if (shussoubaIdList.Contains(shussoubaId))
                {
                    importHistory.AddImportLog(null, null,
                        "成績レース発走状況[" + raceHassouJoukyou.Id + "]にて重複する馬番 : " + umaban,
                        null, ImportFileStatusEnum.一部失敗);
                    continue;
                }
                shussoubaIdList.Add(shussoubaId);

                var shussoubaHassouJoukyou = new ShussoubaHassouJoukyou();

                shussoubaHassouJoukyou.Id = raceHassouJoukyou.Id * 100 + umaban;
                shussoubaHassouJoukyou.RaceHassouJoukyouId = raceHassouJoukyou.Id;
                shussoubaHassouJoukyou.ShussoubaId = shussoubaId;

                shussoubaHassouJoukyouList.Add(shussoubaHassouJoukyou);
            }

            return shussoubaHassouJoukyouList;
        }

        protected abstract int TsuukaJuniIndex { get; }

        protected virtual IList<ShussoubaTsuukaJuni> BuildShussoubaTsuukaJuni(Shussouba shussouba, byte[] buffer)
        {
            var shussoubaTsuukaJuniList = new List<ShussoubaTsuukaJuni>();

            for (int bangou = 1, offset = TsuukaJuniIndex; bangou <= 4; bangou++, offset += 2)
            {
                int? juni = DEFAULT_GETTER.GetInt32(buffer, offset, 2);
                if (juni == null)
                {
                    continue;
                }

                var shussoubaTsuukaJuni = new ShussoubaTsuukaJuni();
                shussoubaTsuukaJuni.Id = shussouba.Id * 10 + bangou;
                shussoubaTsuukaJuni.ShussoubaId = shussouba.Id;
                shussoubaTsuukaJuni.Bangou = bangou;

                if (juni >= 40)
                {
                    shussoubaTsuukaJuni.Juni = juni - 40;
                    shussoubaTsuukaJuni.Joukyou = 40;
                }
                else
                {
                    if (juni <= 28)
                    {
                        shussoubaTsuukaJuni.Juni = juni;
                        shussoubaTsuukaJuni.Joukyou = null;
                    }
                    else
                    {
                        shussoubaTsuukaJuni.Juni = null;
                        shussoubaTsuukaJuni.Joukyou = juni;
                    }
                }

                shussoubaTsuukaJuniList.Add(shussoubaTsuukaJuni);
            }

            return shussoubaTsuukaJuniList;
        }

        protected virtual double? GetTimeSa(byte[] buffer, int index)
        {
            var timeSa = ONE_TENTH_GETTER.GetDouble(buffer, index, 3);
            if (99.7 <= timeSa)
            {
                return 0.0;
            }
            return timeSa;
        }
    }
}
