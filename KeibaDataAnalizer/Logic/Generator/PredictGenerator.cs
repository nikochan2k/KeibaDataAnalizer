using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Soma.Core;

using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Generator
{
    public class PredictGenerator : AbstractGenerator
    {
        public override string Name
        {
            get { return "予想データ生成"; }
        }

        protected override void Generate(Updater updater)
        {
            using (var t = new Transaction())
            {
                var db = t.DB;
                var con = t.Connection;
                updater.Text = "予測ベースデータを作成中です";
                InsertPredictBase(db, con);
                UpdatePredictBase(db, con);
                InsertPredictShussouba(db, con);
                InsertPredictRace(db, con);

                t.Commit();
            }
        }

        private void InsertPredictBase(ILocalDb db, DbConnection con)
        {
            const string SQL =
@"INSERT INTO PredictBase
(
  Id,
	ShussouKaisuu,
	DeokureKaisuu,
	RaceKankaku,
	BlinkerHenka
)
SELECT
  SF.Id,
  (
    SELECT
      COUNT(*)
    FROM
      Race R2
      INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
    WHERE
      R2.Nengappi < R.Nengappi
    AND
      S2.KyousoubaId = S.KyousoubaId 
    AND
      S2.TorikeshiShubetsu IS NULL
  ),
  (
    SELECT
      SUM(CASE WHEN SF2.DeokureByousuu > 0.0 THEN 1 ELSE 0 END)
    FROM
      Race R2
      INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
      INNER JOIN ShussoubaFuka SF2 ON S2.Id = SF2.Id
    WHERE
      R2.Nengappi < R.Nengappi
    AND
      S2.KyousoubaId = S.KyousoubaId 
    AND
      S2.TorikeshiShubetsu IS NULL
  ),
  (
    JULIANDAY(
      R.Nengappi
    )
    -
    JULIANDAY(
      (
        SELECT
          R2.Nengappi
        FROM
          Race R2
          INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
        WHERE
          R2.Nengappi < R.Nengappi
        AND
          S2.KyousoubaId = S.KyousoubaId 
        AND
          S2.TorikeshiShubetsu IS NULL
        ORDER BY
          R2.Nengappi DESC
        LIMIT
          1
      )
    )
  ),
  (
    CASE
      WHEN S.Blinker = 1 THEN
      (
        CASE
          WHEN SF.ZensouId IS NULL THEN 2
          WHEN NOT EXISTS
          (
            SELECT
              *
            FROM
              Race R2
              INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
            WHERE
              R2.Nengappi < R.Nengappi
            AND
              S2.KyousoubaId = S.KyousoubaId
            AND
              S2.TorikeshiShubetsu IS NULL
            AND
              S2.Blinker = 1
          ) THEN 2
          ELSE
          (
            SELECT
              (CASE WHEN S2.Blinker IN (1, 2) THEN NULL ELSE 1 END)
            FROM
              Shussouba S2
            WHERE
              S2.Id = SF.ZensouId
          )
        END
      )
      ELSE
      (
        CASE
          WHEN SF.ZensouId IS NULL THEN NULL
          ELSE
          (
            SELECT
              (CASE WHEN S2.Blinker IN (1, 2) THEN 0 ELSE NULL END)
            FROM
              Shussouba S2
            WHERE
              S2.Id = SF.ZensouId
          )
        END
      )
    END
  )
FROM
  Race R
  INNER JOIN Shussouba S ON R.Id = S.RaceId
  INNER JOIN ShussoubaFuka SF ON S.Id = SF.Id
  LEFT JOIN PredictBase PB ON SF.Id = PB.Id
WHERE
  PB.Id IS NULL";

            db.Execute(con, SQL);
        }

        private void UpdatePredictBase(ILocalDb db, DbConnection con)
        {
            const string SQL =
@"UPDATE PredictBase
SET
  DeokureKakuritsu = CAST(DeokureKaisuu AS REAL) / CAST(ShussouKaisuu AS REAL)
WHERE
  DeokureKakuritsu IS NULL";

            db.Execute(con, SQL);
        }

        private void InsertPredictShussouba(ILocalDb db, DbConnection con)
        {
            const string SQL =
@"INSERT INTO PredictShussouba
SELECT
  S.Id,
  R.Id AS RaceId,
  AVG(SF.Kouhan3FMade_SS),
  AVG(SF.Kouhan3F_SS)
FROM
  Race R
  INNER JOIN Shussouba S ON R.Id = S.RaceId,
  Race R2
  INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
  INNER JOIN ShussoubaFuka SF ON S2.Id = SF.Id
  LEFT JOIN PredictShussouba PS ON SF.Id = PS.Id
WHERE
  R2.Nengappi < R.Nengappi
AND
  S2.KyousoubaId = S.KyousoubaId
AND
  S2.NyuusenChakujun <= 3
AND
  PS.Id IS NULL
GROUP BY
  R.Id,
  S.Id";

            db.Execute(con, SQL);
        }

        private void InsertPredictRace(ILocalDb db, DbConnection con)
        {
            const string SQL =
@"INSERT INTO PredictRace
SELECT
  RaceId,
  AVG(M_Kouhan3FMade_SS)
FROM
  PredictShussouba
GROUP BY
  RaceId";

            db.Execute(con, SQL);
        }

    }
}
