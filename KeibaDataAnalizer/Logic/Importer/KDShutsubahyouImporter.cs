using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Enum;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

using NLog;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public abstract class KDShutsubahyouImporter : KDRaceShussoubaImporter
    {
		private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
		
        protected KDShutsubahyouImporter(ImportHistory importHistory)
            : base(importHistory)
        {
        }

        protected abstract String KolDen1Path { get; }

        protected abstract String KolDen2Path { get; }

        public override void Import()
        {
            long length = new FileInfo(KolDen1Path).Length + new FileInfo(KolDen2Path).Length;

        	var raceMap = new Dictionary<long, Race>();
            using (var fs = new BufferedStream(new FileStream(KolDen1Path, FileMode.Open, FileAccess.Read)))
            {
                importHistory.UncompressedFileName = Path.GetFileName(KolDen1Path);

                var buffer = new byte[BytesOfRace];
                var ticks = File.GetLastWriteTime(KolDen1Path).Ticks;
                var fileNengappi = new DateTime(ticks);

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
							
	                        // 出馬表レースデータ
	                        Race race;
	                        var oldRace = db.TryFind<Race>(con, raceId);
	                        if (oldRace != null)
	                        {
	                            if (oldRace.SeisekiSakuseiNengappi == null)
	                            {
	                            	// 出馬表レースデータが既に入っている場合
	                            	
		                            if (dataSakuseiNengappi <= oldRace.ShutsubahyouSakuseiNengappi)
		                            {
		                            	// 既に最新の出馬表レースデータが入っている場合
		                            	raceMap.Add(raceId, oldRace);
		                                continue;
		                            }
		                            
	                            	DatabaseUtil.SetForeignKey(db, con, true);
	                            	db.Delete<Race>(con, oldRace);
	                            	DatabaseUtil.SetForeignKey(db, con, false);
	
	                                race = BuildRace(buffer, raceId, dataSakuseiNengappi.Value);
	                                race.YosouPace = oldRace.YosouPace;
	                                db.Insert<Race>(con, race);
	                            }
	                            else
	                            {
	                            	// 成績レースデータが既に入っている場合、データ作成年月日のみ更新
	                                race = oldRace;
	                                race.ShutsubahyouSakuseiNengappi = dataSakuseiNengappi;
	                                db.Update<Race>(con, race);
	                            }
	                        }
	                        else
	                        {
	                            race = BuildRace(buffer, raceId, dataSakuseiNengappi.Value);
	                            db.Insert<Race>(con, race);
	                        }
	                        raceMap.Add(raceId, race);
	                        
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
            using (var fs = new BufferedStream(new FileStream(KolDen2Path, FileMode.Open, FileAccess.Read)))
            {
                importHistory.UncompressedFileName = Path.GetFileName(KolDen2Path);

                var buffer = new byte[BytesOfShussouba];
                var ticks = File.GetLastWriteTime(KolDen2Path).Ticks;
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

	                        // 出走馬
	                        Shussouba shussouba;
	                        var oldShussouba = db.TryFind<Shussouba>(con, shussoubaId);
	                        if (oldShussouba != null)
	                        {
	                        	// 既に成績出走馬データか出馬表出走馬データが入っている場合
	                            if (oldShussouba.SeisekiSakuseiNengappi == null)
	                            {
	                            	// 既に出馬表出走馬データが入っている場合
	                            	
		                            if (dataSakuseiNengappi <= oldShussouba.ShutsubahyouSakuseiNengappi)
		                            {
		                        		// 既に最新の出馬表が入っている場合
		                                continue;
		                            }
	                            	DatabaseUtil.SetForeignKey(db, con, true);
	                            	db.Delete<Shussouba>(con, oldShussouba);
	                            	DatabaseUtil.SetForeignKey(db, con, false);
	
	                                shussouba = BuildShussouba(buffer, race, shussoubaId, dataSakuseiNengappi.Value);
	                                db.Insert<Shussouba>(con, shussouba);
	                            }
	                            else
	                            {
	                            	// 既に成績レースデータが入っている場合、データ作成年月日のみ更新
	                                shussouba = oldShussouba;
	                                shussouba.ShutsubahyouSakuseiNengappi = dataSakuseiNengappi;
	                                db.Update<Shussouba>(con, shussouba);
									
	                                // 既に成績レースデータが入っている場合は調教を削除する
	                            	var oldChoukyou = db.TryFind<Choukyou>(con, shussouba.Id);
	                            	if(oldChoukyou != null){
		                            	DatabaseUtil.SetForeignKey(db, con, true);
		                            	db.Delete<Choukyou>(con, oldChoukyou);
		                            	DatabaseUtil.SetForeignKey(db, con, false);
	                            	}
	                            }
	                        }
	                        else
	                        {
	                        	// 成績出走馬データか出馬表出走馬データのいずれも入っていない場合
	                            shussouba = BuildShussouba(buffer, race, shussoubaId, dataSakuseiNengappi.Value);
                                db.Insert<Shussouba>(con, shussouba);
	                        }
							
	                        // 調教
	                        var choukyou = BuildChoukyou(shussouba, buffer);
	                        db.Insert<Choukyou>(con, choukyou);
	                        
	                        // 調教履歴
	                        var choukyouRirekiMap = BuildChoukyouRirekiMap(choukyou, buffer);
	                        foreach (var choukyouRireki in choukyouRirekiMap.Keys)
	                        {
	                            db.Insert<ChoukyouRireki>(con, choukyouRireki);
	                            
	                            // 調教タイム
	                            var choukyouTimeList = choukyouRirekiMap[choukyouRireki];
	                            foreach (var choukyouTime in choukyouTimeList)
	                            {
	                            	db.Insert<ChoukyouTime>(con, choukyouTime);
	                            }
	                        }
	                        
	                        // 出馬表出走馬データ格納後のカスタム処理
				        	foreach (var userSQL in ModelUtil.GetUserSQLList("PostShutsubahyouShussoubaImport")) {
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
            	
                // 出馬表レースデータ格納後のカスタム処理
                foreach (var race in raceMap.Values) {
		        	foreach (var userSQL in ModelUtil.GetUserSQLList("PostShutsubahyouRaceImport")) {
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

        protected abstract Choukyou BuildChoukyou(Shussouba shussouba, byte[] buffer);

    }
}
