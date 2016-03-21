using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Generator
{
    /// <summary>
    /// Description of RatingGenerator.
    /// </summary>
    public class TaisenSeisekiGenerator : AbstractGenerator
    {
        
        public override string Name {
            get {
                return "対戦成績生成";
            }
        }
        
        protected override void Generate(Updater updater)
        {
            int raceCount;
            dynamic raceList;
            using (var t = new Transaction())
            {
                var con = t.Connection;
                var db = t.DB;

                var raceCountList = db.Query<int>(
                    con,
                    "SELECT COUNT(*) FROM Race"
                );
                raceCount = raceCountList[0];

                raceList = db.QueryOnDemand<dynamic>(
                    con,
@"SELECT
  Id,
  KaisaiNen
FROM
  Race
ORDER BY
  Nengappi,
  KaisaiBasho,
  RaceBangou"
                );
                t.Commit();
            }

            const string message = "{0}/{1}を処理しています";
            var i = 1;
            foreach (dynamic race in raceList)
            {
                updater.Text = string.Format(message, i, raceCount);
                using (var t = new Transaction())
                {
                    var con = t.Connection;
                    var db = t.DB;

                    InsertTaisenSeiseki(con, db, (long)race.Id, (int)race.KaisaiNen);

                    t.Commit();
                }
                i++;
            }

        }

        private const string shussoubaSql =
@"SELECT
  Id,
  KyousoubaId
FROM
  Shussouba
WHERE
  RaceId = /* RaceId */0";

        private const string shussoubaFukaUpdateSql =
@"UPDATE
  ShussoubaFuka
SET
  ChokusetsuTaisenTimeSa =
  (
    SELECT
      IFNULL(SUM(TS.TimeSa), 0.0)
    FROM
      TaisenSeiseki TS
    WHERE
      TS.KyousoubaId = ShussoubaFuka.KyousoubaId
    AND
      TS.AiteKyousoubaId IN
      (
        SELECT
          S2.KyousoubaId
        FROM
          Shussouba S2
        WHERE
          S2.RaceId = ShussoubaFuka.RaceId
      )
  ),
  KansetsuTaisenTimeSa =
  (
    SELECT
      IFNULL(SUM(TS.TimeSa - TSA.TimeSa), 0.0)
    FROM
      TaisenSeiseki TS,
      Shussouba SA
      INNER JOIN TaisenSeiseki TSA ON SA.KyousoubaId = TSA.KyousoubaId
    WHERE
      TS.KyousoubaId = ShussoubaFuka.KyousoubaId
    AND
      SA.RaceId = ShussoubaFuka.RaceId
    AND
      TSA.KyousoubaId <> ShussoubaFuka.KyousoubaId
    AND
      TSA.AiteKyousoubaId <> ShussoubaFuka.KyousoubaId
    AND
      TSA.AiteKyousoubaId = TS.AiteKyousoubaId
  )
WHERE
  Id = /* Id */0";

        private const string raceFukaUpdateSql =
@"UPDATE
  RaceFuka
SET
  ChokusetsuTaisenTimeSaMean =
  (
    SELECT
      AVG(ChokusetsuTaisenTimeSa)
    FROM
      ShussoubaFuka SF
    WHERE
      SF.RaceId = RaceFuka.Id
  ),
  KansetsuTaisenTimeSaMean =
  (
    SELECT
      AVG(KansetsuTaisenTimeSa)
    FROM
      ShussoubaFuka SF
    WHERE
      SF.RaceId = RaceFuka.Id
  )
WHERE
  Id = /* RaceId */0";

        private const string taisenSeisekiReplaceSql =
@"REPLACE INTO
  TaisenSeiseki
SELECT
  KyousoubaId,
  AiteKyousoubaId,
  SUM(TimeSa) AS TimeSa
FROM
  (
    SELECT
      S.KyousoubaId AS KyousoubaId,
      T.KyousoubaId AS AiteKyousoubaId,
      T.Time - S.Time AS TimeSa
    FROM
      Shussouba S,
      Shussouba T
    WHERE
      S.Id = /* Id */0
    AND
      S.RaceId = T.RaceId
    AND
      S.Time IS NOT NULL
    AND
      S.KyousoubaId <> T.KyousoubaId
    AND
      T.Time IS NOT NULL
    UNION ALL
    SELECT
      KyousoubaId,
      AiteKyousoubaId,
      TimeSa
    FROM
      TaisenSeiseki
    WHERE
      KyousoubaId = /* KyousoubaId */0
  )
GROUP BY
  KyousoubaId,
  AiteKyousoubaId";

        private void InsertTaisenSeiseki(DbConnection con, ILocalDb db, long raceId, int kaisaiNen)
        {
            var shussoubaList = db.Query<Shussouba>(
                con,
                shussoubaSql,
                new { RaceId = raceId }
            );

            foreach(var shussouba in shussoubaList)
            {
                db.Execute(
                    con,
                    shussoubaFukaUpdateSql,
                    shussouba
                );
            }

            db.Execute(
                con,
                raceFukaUpdateSql,
                new { RaceId = raceId }
            );

            foreach (var shussouba in shussoubaList)
            {
                db.Execute(
                    con,
                    taisenSeisekiReplaceSql,
                    shussouba
                );
            }
        }
    
    }
}
