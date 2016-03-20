using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
	public abstract class KDRaceShussoubaImporter : AbstractImporter
	{

		protected KDRaceShussoubaImporter(ImportHistory importHistory)
			: base(importHistory)
		{
		}

		protected abstract int BytesOfRace { get; }

		protected abstract int RaceDataSakuseiNengappiIndex { get; }

		protected abstract Race BuildRace(byte[] buffer, long raceId, DateTime dataSakuseiNengappi);

		protected abstract int BytesOfShussouba { get; }

		protected abstract int ShussoubaDataSakuseiNengappiIndex { get; }

		protected abstract Shussouba BuildShussouba(byte[] buffer, Race race, long shussoubaId, DateTime dataSakuseiNengappi);

		protected long GetRaceId(byte[] buffer)
		{
			long? radeId = DEFAULT_GETTER.GetInt64(buffer, 0, 12);
			return radeId.Value;
		}

		protected long GetShussoubaId(byte[] buffer, long raceId)
		{
			int umaban = GetUmaban(buffer);
			long shussoubaId = raceId * 100 + umaban;
			return shussoubaId;
		}

		protected int GetJoukenKei(byte[] buffer, int index)
		{
			String joukenCut = DEFAULT_GETTER.GetString(buffer, index, 1);
			switch (joukenCut) {
				case "0":
				case "1":
				case "2":
				case "3":
				case "4":
				case "8":
				case "9":
				case "B":
				case "K":
					return 0; // サラ系
				case "5":
				case "6":
				case "7":
				case "A":
				case "C":
					return 1; // アラブ系
			}
			throw new ArgumentException("予期せぬJoukenCut: " + joukenCut);
		}

		protected int GetJoukenNenreiSeigen(byte[] buffer, int jcIndex, int jnrIndex)
		{
			String s = DEFAULT_GETTER.GetString(buffer, jnrIndex, 1);
			if (s != null) {
				return int.Parse(s);
			} else {
				String joukenCut = DEFAULT_GETTER.GetString(buffer, jcIndex, 1);
				switch (joukenCut) {
					case "0":
					case "K":
						return 9; // なし
					case "1":
					case "5":
						return 0; // 2歳
					case "2":
					case "6":
						return 1; // 3歳
					case "3":
					case "7":
					case "8":
						return 5; // 3歳以上
					case "4":
					case "9":
					case "A":
						return 6; // 4歳以上
					case "B":
					case "C":
						return 2; // 4歳
				}
				throw new ArgumentException("予期せぬJoukenCut: " + joukenCut);
			}
		}

		protected virtual int GetUmaban(byte[] buffer)
		{
			int? umaban = DEFAULT_GETTER.GetInt32(buffer, 23, 2);
			return umaban.Value;
		}

		protected int GetKaisaiNen(long raceId)
		{
			int kaisaiNen = (int)((raceId % 10000000000L) / 1000000L);
			return kaisaiNen;
		}

		protected virtual int GetNenrei(byte[] buffer, int index, int kaisaiNen)
		{
			int nenrei = DEFAULT_GETTER.GetInt32(buffer, index, 2).Value;
			if (kaisaiNen <= 2000) {
				nenrei--;
			}
			return nenrei;
		}

		protected int GetSeinen(byte[] buffer, int seinenIndex, int nenreiIndex, int kaisaiNen)
		{
			String s = DEFAULT_GETTER.GetString(buffer, seinenIndex, 4);
			int seinen;
			if (s != null) {
				seinen = Int32.Parse(s);
			} else {
				int? nenrei = DEFAULT_GETTER.GetInt32(buffer, nenreiIndex, 2);
				seinen = kaisaiNen - nenrei.Value;
			}
			return seinen;
		}


		protected abstract int? ChoukyouAwaseFlagIndex { get; }

		protected abstract int? ChoukyouAwaseIndex { get; }

		protected abstract IDictionary<int, int> ChoukyouIndexMap { get; }

		protected virtual IDictionary<ChoukyouRireki, IList<ChoukyouTime>> BuildChoukyouRirekiMap(Choukyou choukyou, byte[] buffer)
		{
			var choukyouRirekiMap = new Dictionary<ChoukyouRireki, IList<ChoukyouTime>>();

			foreach (int bangou in ChoukyouIndexMap.Keys) {
				var index = ChoukyouIndexMap[bangou];

				var choukyouRireki = new ChoukyouRireki();

				var nengappi = DATE_GETTER.GetDateTime(buffer, index + 9, 8);
				if (nengappi == null) {
					continue;
				}
				choukyouRireki.ChoukyouId = choukyou.Id;
				choukyouRireki.Id = choukyou.Id * 10 + bangou;
				choukyouRireki.Oikiri = DEFAULT_GETTER.GetInt32(buffer, index, 1);
				choukyouRireki.Kijousha = DEFAULT_GETTER.GetString(buffer, index + 1, 8);
				choukyouRireki.Nengappi = nengappi;
				choukyouRireki.Basho = DEFAULT_GETTER.GetString(buffer, index + 17, 6);
				choukyouRireki.ChoukyouCourse = DEFAULT_GETTER.GetString(buffer, index + 23, 2);
				choukyouRireki.ChoukyouBaba = DEFAULT_GETTER.GetString(buffer, index + 25, 2);

				var choukyouTimeList = new List<ChoukyouTime>();

				if (choukyouRireki.ChoukyouCourse == null) {
					choukyouRirekiMap.Add(choukyouRireki, new List<ChoukyouTime>(0));
					return choukyouRirekiMap;
				}
				int _8f = index + 27;
				int _7f = index + 33;
				int _6f_kaisuu = index + 39;
				int _5f_h4f = index + 45;
				int _4f_h3f = index + 51;
				int _3f_h2f = index + 57;
				int _1f_h1f = index + 63;

				String s = DEFAULT_GETTER.GetString(buffer, _6f_kaisuu, 6);
				IDictionary<int, int> map;
				if (choukyouRireki.ChoukyouCourse.Contains("プール")) {
					choukyouRireki.Kaisuu = GetChoukyouKaisuu(s, "周");
					choukyouRirekiMap.Add(choukyouRireki, new List<ChoukyouTime>(0));
					return choukyouRirekiMap;
				} else if (choukyouRireki.ChoukyouCourse.Contains("坂")) {
					choukyouRireki.Kaisuu = GetChoukyouKaisuu(s, "回");
					map = new Dictionary<int, int>() {
						{ _5f_h4f, 4 },
						{ _4f_h3f, 3 },
						{ _3f_h2f, 2 },
						{ _1f_h1f, 1 }
					};
				} else {
					map = new Dictionary<int, int>() {
						{ _8f, 8 },
						{ _7f, 7 },
						{ _6f_kaisuu, 6 },
						{ _5f_h4f, 5 },
						{ _4f_h3f, 4 },
						{ _3f_h2f, 3 },
						{ _1f_h1f, 1 }
					};
				}
				foreach (int i in map.Keys) {
					String comment = DEFAULT_GETTER.GetString(buffer, i, 6);
					if (comment == null) {
						continue;
					}

					var choukyouTime = new ChoukyouTime();

					choukyouTime.ChoukyouRirekiId = choukyouRireki.Id;
					choukyouTime.F = map[i];
					choukyouTime.Id = choukyouTime.ChoukyouRirekiId * 10 + choukyouTime.F;
					Double time;
					if (Double.TryParse(comment, out time)) {
						if (2 <= choukyouTime.F && time <= 20) {
							continue;
						}
						choukyouTime.Time = time;
					} else {
						if ("-".Equals(comment)) {
							continue;
						}
						choukyouTime.Comment = comment;
					}

					choukyouTimeList.Add(choukyouTime);
				}

				choukyouRireki.IchiDori = DEFAULT_GETTER.GetInt32(buffer, index + 69, 1);
				choukyouRireki.Ashiiro = NO_SPACE_GETTER.GetString(buffer, index + 70, 6);
				choukyouRireki.Yajirushi = DEFAULT_GETTER.GetInt32(buffer, index + 76, 1);
				choukyouRireki.Reigai = DEFAULT_GETTER.GetString(buffer, index + 77, 40);

				if (ChoukyouAwaseFlagIndex != null) {
					var awaseFlag = DEFAULT_GETTER.GetInt32(buffer, ChoukyouAwaseFlagIndex.Value, 1);
					if (awaseFlag == bangou) {
						choukyouRireki.Awase = DEFAULT_GETTER.GetString(buffer, ChoukyouAwaseIndex.Value, 86);
					}
				}

				choukyouRirekiMap.Add(choukyouRireki, choukyouTimeList);
			}

			return choukyouRirekiMap;
		}

		protected int? GetChoukyouKaisuu(String s, String keyword)
		{
			if (s == null) {
				return null;
			}

			int? result = null;

			int found;
			if ((found = s.IndexOf(keyword)) >= 0) {
				String kaisuu = String.Empty;
				for (int i = found - 1; i >= 0; i--) {
					char ch = s[i];
					if (Char.IsDigit(ch)) {
						kaisuu = ch + kaisuu;
					} else {
						break;
					}
				}
				result = int.Parse(kaisuu);
			}

			return result;
		}

	}
}
