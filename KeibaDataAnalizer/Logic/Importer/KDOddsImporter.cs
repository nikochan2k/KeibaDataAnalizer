/*
 * Created by SharpDevelop.
 * User: nikoc
 * Date: 2016/03/20
 * Time: 5:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using NLog;
using Nikochan.Keiba.KeibaDataAnalyzer.Enum;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
	/// <summary>
	/// Description of KDOddsImporter.
	/// </summary>
	public abstract class KDOddsImporter : AbstractImporter
	{
		protected enum YosouKakutei
		{
			Yosou = 1,
			Kakutei
		}
		
		protected enum BakenShubetsu
		{
			Tanshou = 1,
			Wakuren,
			Umaren,
			Fukushou,
			Wide,
			Umatan,
			Sanrenpuku,
			Sanrentan
		}
		
		private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

		private static bool importTanshouOdds;
		
		private static bool importWakurenOdds;
		
		private static bool importUmarenOdds;
		
		private static bool importFukushouOdds;
		
		private static bool importWideOdds;
		
		private static bool importUmatanOdds;
		
		private static bool importSanrenpukuOdds;
		
		private static bool importSanrentanOdds;
		
		static KDOddsImporter()
		{
			bool.TryParse(ConfigurationManager.AppSettings["ImportTanshouOdds"], out importTanshouOdds);
			bool.TryParse(ConfigurationManager.AppSettings["ImportWakurenOdds"], out importWakurenOdds);
			bool.TryParse(ConfigurationManager.AppSettings["ImportUmarenOdds"], out importUmarenOdds);
			bool.TryParse(ConfigurationManager.AppSettings["ImportFukushouOdds"], out importFukushouOdds);
			bool.TryParse(ConfigurationManager.AppSettings["ImportWideOdds"], out importWideOdds);
			bool.TryParse(ConfigurationManager.AppSettings["ImportUmatanOdds"], out importUmatanOdds);
			bool.TryParse(ConfigurationManager.AppSettings["ImportSanrenpukuOdds"], out importSanrenpukuOdds);
			bool.TryParse(ConfigurationManager.AppSettings["ImportSanrentanOdds"], out importSanrentanOdds);
		}
		
		protected KDOddsImporter(ImportHistory importHistory)
			: base(importHistory)
		{
		}
		
		protected abstract bool HasFukushouOdds { get; }
		
		protected abstract bool HasWideOdds { get; }
		
		protected abstract bool HasUmatanOdds { get; }
		
		protected abstract bool HasSanrenpukuOdds { get; }
		
		protected abstract int TanshouOddsIndex { get; }
		
		protected abstract int WakurenOddsIndex{ get; }
		
		protected abstract int UmarenOddsIndex{ get; }
		
		protected abstract int FukushouOddsIndex { get; }
		
		protected abstract int WideOddsIndex { get; }
		
		protected abstract int UmatanOddsIndex{ get; }
		
		protected abstract int SanrenpukuOddsIndex{ get; }
		
		protected abstract int SanrentanOddsIndex{ get; }
		
		protected abstract int DataSakuseiNengappiIndex { get; }
		
		protected bool ImportTanshouOdds {
			get {
				return importTanshouOdds;
			}
		}
		
		protected bool ImportWakurenOdds {
			get {
				return importWakurenOdds;
			}
		}
		
		protected bool ImportUmarenOdds {
			get {
				return importUmarenOdds;
			}
		}
		
		protected bool ImportFukushouOdds {
			get {
				return importFukushouOdds && HasFukushouOdds;
			}
		}
		
		protected bool ImportWideOdds {
			get {
				return importWideOdds && HasWideOdds;
			}
		}
		
		protected bool ImportUmatanOdds {
			get {
				return importUmatanOdds && HasUmatanOdds;
			}
		}
		
		protected bool ImportSanrenpukuOdds {
			get {
				return importSanrenpukuOdds && HasSanrenpukuOdds;
			}
		}
		
		protected bool ImportSanrentanOdds {
			get {
				return importSanrentanOdds;
			}
		}
		
		protected OddsKubun CreateOddsKubun(long raceId, BakenShubetsu bakenShubetsu,
			DateTime dataSakuseiNengappi)
		{
			var oddsKubun = new OddsKubun();
			oddsKubun.Id = raceId * 100 + (int)YosouOrKakutei * 10 + (int)bakenShubetsu;
			oddsKubun.RaceId = raceId;
			oddsKubun.YosouKakutei = (int)YosouOrKakutei;
			oddsKubun.BakenShubetsu = (int)bakenShubetsu;
			oddsKubun.DataSakuseiNengappi = dataSakuseiNengappi;
			return oddsKubun;
		}
        
		protected virtual double? ParseOdds(string strOdds, double limit)
		{
			if (String.IsNullOrWhiteSpace(strOdds)) {
				return null;
			}
			
			double? odds;
			int intOdds;
			if (Int32.TryParse(strOdds, out intOdds)) {
				odds = (double)intOdds / 10;
			} else if (strOdds.Contains("*")) {
				odds = limit;
			} else {
				odds = null;
			}
			return odds;
		}
		
		protected virtual Odds CreateOdds(long oddsKubunId)
		{
			var odds = new Odds(){ OddsKubunId = oddsKubunId };
			return odds;
		}
		
		protected virtual bool NeedToImport(long raceId, DateTime dataSakuseiNengappi,
			YosouKakutei yosouKakutei, params BakenShubetsu[] bakenShubetsuList)
		{
			var bakenShubetsuArray = from item in bakenShubetsuList
			                         select (int)item;
			var condition = new {
				RaceId = raceId,
				YosouKakutei = (int)yosouKakutei,
				BakenShubetsuList = bakenShubetsuArray
			};
			
			using (var transaction = new Transaction()) {
				var db = transaction.DB;
				var con = transaction.Connection;
				
				var oldNengappi =
					db.Query<DateTime?>(
						con,
						"SELECT MIN(DataSakuseiNengappi) FROM OddsKubun " +
						"WHERE RaceId = /* RaceId */0 AND YosouKakutei = /* YosouKakutei */0 " +
						"AND BakenShubetsu IN /* BakenShubetsuList*/(0,1)",
						condition
					).FirstOrDefault();
				
				if (oldNengappi != null) {
					if (dataSakuseiNengappi <= oldNengappi) {
						return false;
					}
					
					DatabaseUtil.SetForeignKey(db, con, true);
					db.Execute(
						con,
						"DELETE FROM " +
						"WHERE RaceId = /* RaceId */0 AND YosouKakutei = /* YosouKakutei */0 " +
						"AND BakenShubetsu IN /* BakenShubetsuList*/(0,1)",
						condition
					);
					DatabaseUtil.SetForeignKey(db, con, false);
				}
				
				return true;
			}
		}
		
		protected virtual void InsertOdds(long raceId, DateTime dataSakuseiNengappi, byte[] buffer,
			BakenShubetsu bakenShubetsu, Func<long, byte[], int, IEnumerable<Odds>> createOdds, int oddsIndex)
		{
			using (var transaction = new Transaction()) {
				var db = transaction.DB;
				var con = transaction.Connection;
				
				var oddsKubun = CreateOddsKubun(raceId, bakenShubetsu, dataSakuseiNengappi);
				db.Insert(con, oddsKubun);
				foreach (var odds in createOdds(oddsKubun.Id, buffer, oddsIndex)) {
					db.Insert(con, odds);
				}
				
				transaction.Commit();
			}
		}
		
		protected virtual void InsertTanshouOdds(long raceId, DateTime dataSakuseiNengappi, byte[] buffer)
		{
			if (!ImportTanshouOdds) {
				return;
			}
			
			InsertOdds(raceId, dataSakuseiNengappi, buffer, BakenShubetsu.Tanshou,
				CreateTanshouOdds, TanshouOddsIndex);
		}
		
		protected virtual IEnumerable<Odds> CreateTanshouOdds(long oddsKubunId, byte[] buffer, int start)
		{
			const int byteCount = 5;
			const int tousuu = 18;
			double oddsLimit = YosouOrKakutei == YosouKakutei.Yosou ? 50.0 : 10000.0;
			var oddsList = new List<Odds>();
			for (int i = start, umaban = 1; umaban <= tousuu; umaban++) {
				var strOdds = DEFAULT_GETTER.GetString(buffer, i, byteCount);
				i += byteCount;
				var odds1 = ParseOdds(strOdds, oddsLimit);
				if (odds1 == null) {
					continue;
				}
				
				var odds = CreateOdds(oddsKubunId);
				odds.Bangou1 = umaban;
				odds.Odds1 = odds1;
				oddsList.Add(odds);
			}
			return oddsList;
		}
		
		protected virtual void InsertWakurenOdds(long raceId, DateTime dataSakuseiNengappi, byte[] buffer)
		{
			if (!ImportWakurenOdds) {
				return;
			}
			
			InsertOdds(raceId, dataSakuseiNengappi, buffer, BakenShubetsu.Wakuren,
				CreateWakurenOdds, WakurenOddsIndex);
		}
        
		protected virtual IEnumerable<Odds> CreateWakurenOdds(long oddsKubunId, byte[] buffer, int start)
		{
			const int byteCount = 5;
			const int wakusuu = 8;
			double oddsLimit = YosouOrKakutei == YosouKakutei.Yosou ? 100.0 : 10000.0;
			var oddsList = new List<Odds>();
			for (int i = start, wakuban1 = 1; wakuban1 <= wakusuu; wakuban1++) {
				for (var wakuban2 = 1; wakuban2 <= wakusuu; wakuban2++) {
					var strOdds1 = DEFAULT_GETTER.GetString(buffer, i, byteCount);
					i += byteCount;
					var odds1 = ParseOdds(strOdds1, oddsLimit);
					if (odds1 == null) {
						continue;
					}
					
					var odds = CreateOdds(oddsKubunId);
					odds.Bangou1 = wakuban1;
					odds.Bangou2 = wakuban2;
					odds.Odds1 = odds1;
					oddsList.Add(odds);
				}
			}
			return oddsList;
		}
		
		protected virtual void InsertUmarenOdds(long raceId, DateTime dataSakuseiNengappi, byte[] buffer)
		{
			if (!ImportUmarenOdds) {
				return;
			}
			
			InsertOdds(raceId, dataSakuseiNengappi, buffer, BakenShubetsu.Umaren,
				CreateUmarenOdds, UmarenOddsIndex);
		}
        
		protected virtual IEnumerable<Odds> CreateUmarenOdds(long oddsKubunId, byte[] buffer, int start)
		{
			const int byteCount = 7;
			const int tousuu = 18;
			double oddsLimit = YosouOrKakutei == YosouKakutei.Yosou ? 1000.0 : 1000000.0;
			var oddsList = new List<Odds>();
			for (int i = start, umaban1 = 1; umaban1 <= tousuu - 1; umaban1++) {
				for (var umaban2 = umaban1 + 1; umaban2 <= tousuu; umaban2++) {
					var strOdds1 = DEFAULT_GETTER.GetString(buffer, i, byteCount);
					i += byteCount;
					var odds1 = ParseOdds(strOdds1, oddsLimit);
					if (odds1 == null) {
						continue;
					}
					
					var odds = CreateOdds(oddsKubunId);
					odds.Bangou1 = umaban1;
					odds.Bangou2 = umaban2;
					odds.Odds1 = odds1;
					oddsList.Add(odds);
				}
			}
			return oddsList;
		}
		
		protected virtual void InsertFukushouOdds(long raceId, DateTime dataSakuseiNengappi, byte[] buffer)
		{
			if (!ImportFukushouOdds) {
				return;
			}
			
			InsertOdds(raceId, dataSakuseiNengappi, buffer, BakenShubetsu.Fukushou,
				CreateFukushouOdds, FukushouOddsIndex);
		}
        
		protected virtual IEnumerable<Odds> CreateFukushouOdds(long oddsKubunId, byte[] buffer, int start)
		{
			const int byteCount = 3;
			const int tousuu = 18;
			const double oddsLimit = 100.0;
			var oddsList = new List<Odds>();
			for (int i = start, umaban = 1; umaban <= tousuu; umaban++) {
				var strOdds1 = DEFAULT_GETTER.GetString(buffer, i, byteCount);
				i += byteCount;
				var odds1 = ParseOdds(strOdds1, oddsLimit);
				if (odds1 == null) {
					continue;
				}
				
				var strOdds2 = DEFAULT_GETTER.GetString(buffer, i, byteCount);
				i += byteCount;
				var odds2 = ParseOdds(strOdds2, oddsLimit);
				if (odds2 == null) {
					continue;
				}
				
				var odds = CreateOdds(oddsKubunId);
				odds.Bangou1 = umaban;
				odds.Odds1 = odds1;
				odds.Odds2 = odds2;
				oddsList.Add(odds);
			}
			return oddsList;
		}
		
		protected virtual void InsertWideOdds(long raceId, DateTime dataSakuseiNengappi, byte[] buffer)
		{
			if (!ImportWideOdds) {
				return;
			}
			
			InsertOdds(raceId, dataSakuseiNengappi, buffer, BakenShubetsu.Wide,
				CreateWideOdds, WideOddsIndex);
		}
        
		protected virtual IEnumerable<Odds> CreateWideOdds(long oddsKubunId, byte[] buffer, int start)
		{
			const int byteCount = 5;
			const int tousuu = 18;
			const double oddsLimit = 1000.0;
			var oddsList = new List<Odds>();
			for (int i = start, umaban1 = 1; umaban1 <= tousuu - 1; umaban1++) {
				for (var umaban2 = umaban1 + 1; umaban2 <= tousuu; umaban2++) {
					var strOdds1 = DEFAULT_GETTER.GetString(buffer, i, byteCount);
					i += byteCount;
					var odds1 = ParseOdds(strOdds1, oddsLimit);
					if (odds1 == null) {
						continue;
					}
					
					var strOdds2 = DEFAULT_GETTER.GetString(buffer, i, byteCount);
					i += byteCount;
					var odds2 = ParseOdds(strOdds2, oddsLimit);
					if (odds2 == null) {
						continue;
					}
					
					var odds = CreateOdds(oddsKubunId);
					odds.Bangou1 = umaban1;
					odds.Bangou2 = umaban2;
					odds.Odds1 = odds1;
					odds.Odds2 = odds2;
					oddsList.Add(odds);
				}
			}
			return oddsList;
		}
		
		protected virtual void InsertUmatanOdds(long raceId, DateTime dataSakuseiNengappi, byte[] buffer)
		{
			if (!ImportUmatanOdds) {
				return;
			}
			
			InsertOdds(raceId, dataSakuseiNengappi, buffer, BakenShubetsu.Umatan,
				CreateUmatanOdds, UmatanOddsIndex);
		}
        
		protected virtual IEnumerable<Odds> CreateUmatanOdds(long oddsKubunId, byte[] buffer, int start)
		{
			const int byteCount = 5;
			const int tousuu = 18;
			double oddsLimit = YosouOrKakutei == YosouKakutei.Yosou ? 1000.0 : 10000.0;
			var oddsList = new List<Odds>();
			for (int i = start, umaban1 = 1; umaban1 <= tousuu; umaban1++) {
				for (var umaban2 = 1; umaban2 <= tousuu; umaban2++) {
					if (umaban1 == umaban2) {
						continue;
					}
					var strOdds1 = DEFAULT_GETTER.GetString(buffer, i, byteCount);
					i += byteCount;
					var odds1 = ParseOdds(strOdds1, oddsLimit);
					if (odds1 == null) {
						continue;
					}
					
					var odds = CreateOdds(oddsKubunId);
					odds.Bangou1 = umaban1;
					odds.Bangou2 = umaban2;
					odds.Odds1 = odds1;
					oddsList.Add(odds);
				}
			}
			return oddsList;
		}
		
		protected virtual void InsertSanrenpukuOdds(long raceId, DateTime dataSakuseiNengappi, byte[] buffer)
		{
			if (!ImportSanrenpukuOdds) {
				return;
			}
			
			InsertOdds(raceId, dataSakuseiNengappi, buffer, BakenShubetsu.Sanrenpuku,
				CreateSanrenpukuOdds, SanrenpukuOddsIndex);
		}
        
		protected virtual IEnumerable<Odds> CreateSanrenpukuOdds(long oddsKubunId, byte[] buffer, int start)
		{
			const int byteCount = 7;
			const int tousuu = 18;
			double oddsLimit = YosouOrKakutei == YosouKakutei.Yosou ? 1000.0 : 1000000.0;
			var oddsList = new List<Odds>();
			for (int i = start, umaban1 = 1; umaban1 <= tousuu - 2; umaban1++) {
				for (var umaban2 = umaban1 + 1; umaban2 <= tousuu - 1; umaban2++) {
					for (var umaban3 = umaban2 + 1; umaban3 <= tousuu; umaban3++) {
						var strOdds1 = DEFAULT_GETTER.GetString(buffer, i, byteCount);
						i += byteCount;
						var odds1 = ParseOdds(strOdds1, oddsLimit);
						if (odds1 == null) {
							continue;
						}
						
						var odds = CreateOdds(oddsKubunId);
						odds.Bangou1 = umaban1;
						odds.Bangou2 = umaban2;
						odds.Bangou3 = umaban3;
						odds.Odds1 = odds1;
						oddsList.Add(odds);
					}
				}
			}
			return oddsList;
		}
		
		protected virtual void InsertSanrentanOdds(long raceId, DateTime dataSakuseiNengappi, byte[] buffer)
		{
			if (!ImportSanrentanOdds) {
				return;
			}
			
			InsertOdds(raceId, dataSakuseiNengappi, buffer, BakenShubetsu.Sanrentan,
				CreateSanrentanOdds, SanrentanOddsIndex);
		}
        
		protected virtual IEnumerable<Odds> CreateSanrentanOdds(long oddsKubunId, byte[] buffer, int start)
		{
			const int byteCount = 10;
			const int tousuu = 18;
			const double oddsLimit = 100000000.0;
			var oddsList = new List<Odds>();
			for (int i = start, umaban1 = 1; umaban1 <= tousuu; umaban1++) {
				for (var umaban2 = 1; umaban2 <= tousuu; umaban2++) {
					if (umaban1 == umaban2) {
						continue;
					}
					
					for (var umaban3 = 1; umaban3 <= tousuu; umaban3++) {
						if (umaban1 == umaban3 || umaban2 == umaban3) {
							continue;
						}
						
						var strOdds1 = DEFAULT_GETTER.GetString(buffer, i, byteCount);
						i += byteCount;
						var odds1 = ParseOdds(strOdds1, oddsLimit);
						if (odds1 == null) {
							continue;
						}
						
						var odds = CreateOdds(oddsKubunId);
						odds.Bangou1 = umaban1;
						odds.Bangou2 = umaban2;
						odds.Bangou3 = umaban3;
						odds.Odds1 = odds1;
						oddsList.Add(odds);
					}
				}
			}
			return oddsList;
		}
		
		
		protected abstract String KolOddsPath { get; }

		protected abstract String KolOdds2Path { get; }

		protected abstract String KolOdds3Path { get; }
        
		protected abstract int ByteOfOdds { get; }
        
		protected abstract int ByteOfOdds2 { get; }
        
		protected abstract int ByteOfOdds3 { get; }
		
		protected abstract YosouKakutei YosouOrKakutei { get; }
		
		public override void Import()
		{
			ImportOdds();
			ImportOdds2();
			ImportOdds3();
		}
		
		protected void ImportOdds()
		{
			using (var fs = new BufferedStream(new FileStream(KolOddsPath, FileMode.Open, FileAccess.Read))) {
				importHistory.UncompressedFileName = Path.GetFileName(KolOddsPath);

				var buffer = new byte[ByteOfOdds];
				var fileNengappi = File.GetLastWriteTime(KolOddsPath);

				while (fs.Read(buffer, 0, ByteOfOdds) == ByteOfOdds) {
					try {
						using (var transaction = new Transaction()) {
							var db = transaction.DB;
							var con = transaction.Connection;
							
							var raceId = DEFAULT_GETTER.GetInt64(buffer, 0, 12).Value;
							var dataSakuseiNengappi =
								DATE_GETTER.GetDateTime(buffer, DataSakuseiNengappiIndex, 8) ?? fileNengappi;
	                        
							if (!NeedToImport(raceId, dataSakuseiNengappi, YosouOrKakutei,
								    BakenShubetsu.Tanshou, BakenShubetsu.Wakuren, BakenShubetsu.Umaren)) {
								continue;
							}
							
							InsertTanshouOdds(raceId, dataSakuseiNengappi, buffer);
							InsertWakurenOdds(raceId, dataSakuseiNengappi, buffer);
							InsertUmarenOdds(raceId, dataSakuseiNengappi, buffer);
							
							transaction.Commit();
						}
					} catch (Exception ex) {
						importHistory.AddImportLog(null, null, "予期せぬエラーが発生しました。",
							CommonUtil.FlattenException(ex), ImportFileStatusEnum.一部失敗);
					} finally {
						importHistory.Index += ByteOfOdds;
					}
				}
			}
		}
		
		protected void ImportOdds2()
		{
			if (String.IsNullOrEmpty(KolOdds2Path)) {
				return;
			}
			
			using (var fs = new BufferedStream(new FileStream(KolOdds2Path, FileMode.Open, FileAccess.Read))) {
				importHistory.UncompressedFileName = Path.GetFileName(KolOdds2Path);

				var buffer = new byte[ByteOfOdds2];
				var fileNengappi = File.GetLastWriteTime(KolOdds2Path);

				while (fs.Read(buffer, 0, ByteOfOdds2) == ByteOfOdds2) {
					try {
						using (var transaction = new Transaction()) {
							var db = transaction.DB;
							var con = transaction.Connection;
			            	
							var raceId = DEFAULT_GETTER.GetInt64(buffer, 0, 12).Value;
							var dataSakuseiNengappi =
								DATE_GETTER.GetDateTime(buffer, DataSakuseiNengappiIndex, 8) ?? fileNengappi;
	                        
							if (!NeedToImport(raceId, dataSakuseiNengappi, YosouOrKakutei,
								    BakenShubetsu.Fukushou, BakenShubetsu.Wide,
								    BakenShubetsu.Umatan, BakenShubetsu.Sanrenpuku)) {
								continue;
							}
							
							InsertFukushouOdds(raceId, dataSakuseiNengappi, buffer);
							InsertWideOdds(raceId, dataSakuseiNengappi, buffer);
							InsertUmatanOdds(raceId, dataSakuseiNengappi, buffer);
							InsertSanrenpukuOdds(raceId, dataSakuseiNengappi, buffer);
	                        
							transaction.Commit();
						}
					} catch (Exception ex) {
						importHistory.AddImportLog(null, null, "予期せぬエラーが発生しました。",
							CommonUtil.FlattenException(ex), ImportFileStatusEnum.一部失敗);
					} finally {
						importHistory.Index += ByteOfOdds2;
					}
				}
			}
		}
		
		protected void ImportOdds3()
		{
			if (String.IsNullOrEmpty(KolOdds3Path)) {
				return;
			}
			
			using (var fs = new BufferedStream(new FileStream(KolOdds3Path, FileMode.Open, FileAccess.Read))) {
				importHistory.UncompressedFileName = Path.GetFileName(KolOdds3Path);

				var buffer = new byte[ByteOfOdds3];
				var fileNengappi = File.GetLastWriteTime(KolOdds3Path);

				while (fs.Read(buffer, 0, ByteOfOdds3) == ByteOfOdds3) {
					try {
						using (var transaction = new Transaction()) {
							var db = transaction.DB;
							var con = transaction.Connection;
							
							var raceId = DEFAULT_GETTER.GetInt64(buffer, 0, 12).Value;
							var dataSakuseiNengappi =
								DATE_GETTER.GetDateTime(buffer, DataSakuseiNengappiIndex, 8) ?? fileNengappi;
	                        
							if (!NeedToImport(raceId, dataSakuseiNengappi, YosouOrKakutei,
								    BakenShubetsu.Sanrentan)) {
								continue;
							}
							
							InsertSanrentanOdds(raceId, dataSakuseiNengappi, buffer);
							
							transaction.Commit();
						}
					} catch (Exception ex) {
						importHistory.AddImportLog(null, null, "予期せぬエラーが発生しました。",
							CommonUtil.FlattenException(ex), ImportFileStatusEnum.一部失敗);
					} finally {
						importHistory.Index += ByteOfOdds3;
					}
				}
			}
		}
	}
	
}
