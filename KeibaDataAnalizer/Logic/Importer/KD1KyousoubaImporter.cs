using System;

using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public class KD1KyousoubaImporter : KDKyousoubaImporter
    {
        private String kolUmaPath;
       
        public KD1KyousoubaImporter(ImportHistory importHistory, string kolUmaPath)
            : base(importHistory)
        {
            this.kolUmaPath = kolUmaPath;
        }

        protected override int BytesOfKyousouba
        {
            get
            {
                return 2247;
            }
        }
        
		protected override int DataSakuseiNengappiIndex {
			get
			{
				return 2237;
			}
		}
        
        protected override string KolUmaPath
        {
            get { return kolUmaPath; }
        }
        
		protected override Kyousouba BuildKyousouba(byte[] buffer, string kyousoubaId, DateTime dataSakuseiNengappi)
		{
			var kyousouba = new Kyousouba();
			
            kyousouba.Id = kyousoubaId;
            kyousouba.KanaBamei = DEFAULT_GETTER.GetString(buffer, 7, 30);
            kyousouba.Seinengappi = DATE_GETTER.GetDateTime(buffer, 37, 8);
            kyousouba.Keiro = DEFAULT_GETTER.GetInt32(buffer, 45, 2);
            kyousouba.UmaKigou = ZERO_TO_NULL_GETTER.GetInt32(buffer, 47, 2);
            kyousouba.Kesshu = DEFAULT_GETTER.GetInt32(buffer, 49, 2);
            kyousouba.Sanchi = DEFAULT_GETTER.GetInt32(buffer, 51, 3);
            kyousouba.Seibetsu = DEFAULT_GETTER.GetInt32(buffer, 54, 1);
            kyousouba.KyuushaId = DEFAULT_GETTER.GetInt32(buffer, 57, 5);
            kyousouba.BanushiMei = DEFAULT_GETTER.GetString(buffer, 62, 40);
            kyousouba.TanshukuBanushiMei = DEFAULT_GETTER.GetString(buffer, 102, 20);
            kyousouba.SeisanshaMei = DEFAULT_GETTER.GetString(buffer, 122, 40);
            kyousouba.TanshukuSeisanshaMei = DEFAULT_GETTER.GetString(buffer, 162, 20);
            kyousouba.ChichiUmaId = DEFAULT_GETTER.GetString(buffer, 182, 7);
            kyousouba.MasshouFlag = DEFAULT_GETTER.GetInt32(buffer, 189, 1);
            kyousouba.KoueiGaikokuKyuushaMei = DEFAULT_GETTER.GetString(buffer, 240, 8);
            kyousouba.ChichiUmaMei = DEFAULT_GETTER.GetString(buffer, 296, 34);
            kyousouba.HahaUmaMei = DEFAULT_GETTER.GetString(buffer, 330, 34);
            kyousouba.HahaChichiUmaMei = DEFAULT_GETTER.GetString(buffer, 364, 34);
            kyousouba.HahaHahaUmaMei = DEFAULT_GETTER.GetString(buffer, 398, 34);
            kyousouba.DataSakuseiNengappi = dataSakuseiNengappi;
            
            return kyousouba;
		}
    }
}
