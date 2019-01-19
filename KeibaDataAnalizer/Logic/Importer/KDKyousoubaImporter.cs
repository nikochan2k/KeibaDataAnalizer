using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

using NLog;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public abstract class KDKyousoubaImporter : AbstractImporter
    {
		private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IList<UserSQL> postKyousoubaImportSQLList;
        
    	public KDKyousoubaImporter(ImportHistory importHistory)
            : base(importHistory)
        {
        	postKyousoubaImportSQLList = ModelUtil.GetUserSQLList("PostKyousoubaImport");
        }

        protected virtual int BytesOfKyousouba
        {
            get
            {
                return 5166;
            }
        }
        
        protected virtual int DataSakuseiNengappiIndex
        {
        	get
        	{
        		return 624;
        	}
        }

        protected abstract String KolUmaPath { get; }

        protected virtual string GetKyousoubaId(byte[] buffer)
        {
            return DEFAULT_GETTER.GetString(buffer, 0, 7);
        }

        public override void Import()
        {
            using (var fs = new BufferedStream(new FileStream(KolUmaPath, FileMode.Open, FileAccess.Read)))
            {
                importHistory.UncompressedFileName = Path.GetFileName(KolUmaPath);

                var buffer = new byte[BytesOfKyousouba];
                var ticks = File.GetLastWriteTime(KolUmaPath).Ticks;
                var fileNengappi = new DateTime(ticks);

                while (fs.Read(buffer, 0, BytesOfKyousouba) == BytesOfKyousouba)
                {
                    try
                    {
			            using(var transaction = new Transaction()){
			            	var db = transaction.DB;
			            	var con = transaction.Connection;
	                        DateTime dataSakuseiNengappi = DATE_GETTER.GetDateTime(buffer, DataSakuseiNengappiIndex, 8).Value;
	                        if (dataSakuseiNengappi == null)
	                        {
	                            dataSakuseiNengappi = fileNengappi;
	                        }
	                        string kyousoubaId = GetKyousoubaId(buffer);
	
	                        Kyousouba oldKyousouba = db.TryFind<Kyousouba>(con, new object[]{kyousoubaId});
	
	                        Kyousouba kyousouba;
	                        if (oldKyousouba != null)
	                        {
	                            if (dataSakuseiNengappi <= oldKyousouba.DataSakuseiNengappi)
	                            {
	                                continue;
	                            }
	
	                            DatabaseUtil.SetForeignKey(db, con, true);
	                            db.Delete<Kyousouba>(con, oldKyousouba);
	                            DatabaseUtil.SetForeignKey(db, con, false);
	                        }
	                        kyousouba = BuildKyousouba(buffer, kyousoubaId, dataSakuseiNengappi);
	                        db.Insert<Kyousouba>(con, kyousouba);
	                        
				        	foreach (var userSQL in postKyousoubaImportSQLList) {
				        		try{
					        		db.Execute(con, userSQL.SQL, kyousouba);
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
                        importHistory.Index += BytesOfKyousouba;
                    }
                }
            }
        }

        protected virtual Kyousouba BuildKyousouba(byte[] buffer, string kyousoubaId, DateTime dataSakuseiNengappi)
        {
            Kyousouba kyousouba = new Kyousouba();

            kyousouba.Id = kyousoubaId;
            kyousouba.KanaBamei = DEFAULT_GETTER.GetString(buffer, 7, 30);
            kyousouba.KyuuBamei = DEFAULT_GETTER.GetString(buffer, 37, 40);
            kyousouba.Seinengappi = DATE_GETTER.GetDateTime(buffer, 77, 8);
            kyousouba.Keiro = DEFAULT_GETTER.GetInt32(buffer, 85, 2);
            kyousouba.Kesshu = DEFAULT_GETTER.GetInt32(buffer, 87, 2);
            kyousouba.Sanchi = DEFAULT_GETTER.GetInt32(buffer, 89, 3);
            kyousouba.UmaKigou = ZERO_TO_NULL_GETTER.GetInt32(buffer, 92, 2);
            kyousouba.Seibetsu = DEFAULT_GETTER.GetInt32(buffer, 94, 1);
            kyousouba.ChichiUmaId = DEFAULT_GETTER.GetString(buffer, 97, 7);
            kyousouba.ChichiUmaMei = DEFAULT_GETTER.GetString(buffer, 104, 34);
            kyousouba.HahaUmaId = DEFAULT_GETTER.GetString(buffer, 138, 7);
            kyousouba.HahaUmaMei = DEFAULT_GETTER.GetString(buffer, 145, 34);
            kyousouba.HahaChichiUmaId = DEFAULT_GETTER.GetString(buffer, 179, 7);
            kyousouba.HahaChichiUmaMei = DEFAULT_GETTER.GetString(buffer, 186, 34);
            kyousouba.HahaHahaUmaId = DEFAULT_GETTER.GetString(buffer, 220, 7);
            kyousouba.HahaHahaUmaMei = DEFAULT_GETTER.GetString(buffer, 227, 34);
            kyousouba.BanushiMei = DEFAULT_GETTER.GetString(buffer, 343, 40);
            kyousouba.TanshukuBanushiMei = DEFAULT_GETTER.GetString(buffer, 383, 20);
            kyousouba.SeisanshaMei = DEFAULT_GETTER.GetString(buffer, 423, 40);
            kyousouba.TanshukuSeisanshaMei = DEFAULT_GETTER.GetString(buffer, 463, 20);
            kyousouba.KyuushaId = DEFAULT_GETTER.GetInt32(buffer, 488, 5);
            kyousouba.KyuushaMei = DEFAULT_GETTER.GetString(buffer, 493, 32);
            kyousouba.TanshukuKyuushaMei = DEFAULT_GETTER.GetString(buffer, 525, 8);
            kyousouba.KyuushaShozokuBasho = DEFAULT_GETTER.GetInt32(buffer, 533, 2);
            kyousouba.KyuushaRitsuHokuNanBetsu = DEFAULT_GETTER.GetInt32(buffer, 535, 1);
            kyousouba.KoueiGaikokuKyuushaMei = DEFAULT_GETTER.GetString(buffer, 536, 8);
            kyousouba.MasshouFlag = DEFAULT_GETTER.GetInt32(buffer, 544, 1);
            kyousouba.MasshouNengappi = DATE_GETTER.GetDateTime(buffer, 545, 8);
            kyousouba.Jiyuu = DEFAULT_GETTER.GetString(buffer, 553, 6);
            kyousouba.Ikisaki = DEFAULT_GETTER.GetString(buffer, 559, 10);
            kyousouba.ChichiKyoriTekisei = DEFAULT_GETTER.GetInt32(buffer, 619, 1);
            kyousouba.HirabaOmoKousetsu = DEFAULT_GETTER.GetInt32(buffer, 620, 1);
            kyousouba.HirabaDirtKousetsu = DEFAULT_GETTER.GetInt32(buffer, 621, 1);
            kyousouba.ShougaiOmoKousetsu = DEFAULT_GETTER.GetInt32(buffer, 622, 1);
            kyousouba.ShougaiDirtKousetsu = DEFAULT_GETTER.GetInt32(buffer, 623, 1);
            kyousouba.DataSakuseiNengappi = dataSakuseiNengappi;

            return kyousouba;
        }
    }
}
