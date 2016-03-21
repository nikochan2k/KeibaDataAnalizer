using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;

using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Generator
{
    /// <summary>
    /// Description of FukaDataGenerator.
    /// </summary>
    public class FukaDataGenerator : AbstractGenerator
    {
        public override string Name{
            get
            {
                return "付加データ生成";
            }
        }
        
        protected override void Generate(Updater updater)
        {
            InsertRace(updater);
            InsertShussouba(updater);
            UpdateShussouba(updater);
            // GenerateRating(updater);
        }

        #region レース付加データ

        private void InsertRace(Updater updater){
            InsertRaceFuka(updater);
            for(var kb = 0; kb <= 9; kb++){
                var prefix = (kb+1).ToString() + "件目の";
                const string suffix = "を更新中です";
                using(var t = new Transaction()){
                    var con = t.Connection;
                    var db = t.DB;
                    updater.Text = prefix + "開催日数" + suffix;
                    UpdateKaisaiNissuu(con, db, kb);
                    updater.Text = prefix + "コース日数" + suffix;
                    UpdateCourseNissuu(con, db, kb);
                    
                    t.Commit();
                }
            }
        }

        private void InsertRaceFuka(Updater updater)
        {
            updater.Text = "レース付加データを生成しています";
            using (var t = new Transaction())
            {
                var con = t.Connection;
                var db = t.DB;
                db.Execute(
                    con,
@"INSERT INTO RaceFuka
(
  Id
)
SELECT
  R.Id
FROM
  Race R"
                );
            }
        }

        private void UpdateKaisaiNissuu(DbConnection con, ILocalDb db, int kb){
            var kaisaiBashoList = db.Query<Race>(
                con,
@"SELECT
  Nengappi
FROM
  Race
WHERE
  KaisaiBasho = /* kaisaiBasho */0
AND
  RaceBangou = 1
ORDER BY
  Nengappi DESC",
                new { kaisaiBasho = kb }
            );
            var start = 0;
            var end = 0;
            Race previous = null;
            for(; end < kaisaiBashoList.Count; end++){
                var current = kaisaiBashoList[end];
                if(end > 0){
                    var ts = previous.Nengappi.Subtract(current.Nengappi);
                    if(ts.Days > 30){
                        UpdateKaisaiNissuu(con, db, start, end, kaisaiBashoList, kb, previous);
                        start = end;
                    }
                }
                previous = current;
            }
            if(previous != null){
                UpdateKaisaiNissuu(con, db, start, end, kaisaiBashoList, kb, previous);
            }
        }

        private void UpdateKaisaiNissuu(DbConnection con, ILocalDb db, int start,
            int end, IList<Race> kaisaiBashoList, int kb, Race first){
            for(var i = start; i < end; i++){
                var target = kaisaiBashoList[i];
                var knTS = target.Nengappi.Subtract(first.Nengappi);
                db.Execute(
                    con,
@"UPDATE RaceFuka
SET
  KaisaiNissuu = /* kaisaiNissuu */0
WHERE
  KaisaiNissuu IS NULL
AND
  EXISTS(
    SELECT
      *
    FROM
      Race R
    WHERE
      R.Id = RaceFuka.Id
    AND
      R.KaisaiBasho = /* kaisaiBasho */0
    AND
      R.Nengappi = /* nengappi */0
  )",
                    new {
                        kaisaiNissuu = knTS.Days,
                        kaisaiBasho = kb,
                        nengappi = target.Nengappi
                    }
                );
            }
        }
        
        private void UpdateCourseNissuu(DbConnection con, ILocalDb db, int kb){
            var courseList = db.Query<Race>(
                con,
@"SELECT
  DirtShiba,
  Course,
  Nengappi
FROM
  Race
WHERE
  KaisaiBasho = /* kaisaiBasho */0
GROUP BY
  DirtShiba,
  Course,
  Nengappi
ORDER BY
  DirtShiba,
  Course,
  Nengappi DESC",
                new { kaisaiBasho = kb }
            );
            var start = 0;
            var end = 0;
            Race previous = null;
            for(; end < courseList.Count; end++){
                var current = courseList[end];
                if(end > 0){
                    var ts = previous.Nengappi.Subtract(current.Nengappi);
                    if(ts.Days > 30 || current.DirtShiba != previous.DirtShiba || current.Course != previous.Course){
                        UpdateCourseNisuu(con, db, start, end, courseList, kb, previous);
                        start = end;
                    }
                }
                previous = current;
            }
            if(previous != null){
                UpdateCourseNisuu(con, db, start, end, courseList, kb, previous);
            }
        }
        
        private void UpdateCourseNisuu(DbConnection con, ILocalDb db, int start,
            int end, IList<Race> kaisaiBashoList, int kb, Race first){
            for(var i = start; i < end; i++){
                var target = kaisaiBashoList[i];
                var crsTS = target.Nengappi.Subtract(first.Nengappi);
                db.Execute(
                    con,
@"UPDATE
  RaceFuka
SET
  CourseNissuu = /* courseNissuu */0
WHERE
  CourseNissuu IS NULL
AND
  EXISTS(
    SELECT
      *
    FROM
      Race R
    WHERE
      R.Id = RaceFuka.Id
    AND
      KaisaiBasho = /* kaisaiBasho */0
    AND
      DirtShiba = /* dirtShiba */0
    AND
      IFNULL(Course, -1) = IFNULL(/* course */0, -1)
    AND
      Nengappi = /* nengappi */0
  )",
                    new {
                        courseNissuu = crsTS.Days,
                        kaisaiBasho = kb,
                        dirtShiba = first.DirtShiba,
                        course = first.Course,
                        nengappi = target.Nengappi
                    }
                );
            }
        }

        #endregion


        #region 出走馬付加データ

        private void InsertShussouba(Updater updater){
            using(var t = new Transaction()){
                var con = t.Connection;
                var db = t.DB;
                updater.Text = "出走馬予想データを作成中です";
                db.Execute(
                    con,
@"INSERT INTO ShussoubaFuka
(
  Id,
  RaceId,
  KyousoubaId,
  DeokureByousuu,
  FuriByousuu
)
SELECT
  S.Id,
  S.RaceId,
  S.KyousoubaId,
  IFNULL(SUM(CASE WHEN RHJ.Joukyou = 41 THEN RHJ.FuriByousuu ELSE 0.0 END), 0.0),
  IFNULL(SUM(CASE WHEN RHJ.Joukyou <> 41 THEN RHJ.FuriByousuu ELSE 0.0 END), 0.0)
FROM
  Race R
  INNER JOIN Shussouba S ON R.Id = S.RaceId
  LEFT JOIN ShussoubaHassouJoukyou SHJ ON S.Id = SHJ.ShussoubaId
  LEFT JOIN RaceHassouJoukyou RHJ ON SHJ.RaceHassouJoukyouId = RHJ.Id
  LEFT JOIN ShussoubaFuka SF ON S.Id = SF.Id
WHERE
  R.HeichiShougai = 0
AND
  S.TorikeshiShubetsu IS NULL
AND
  SF.Id IS NULL
GROUP BY
  S.RaceId,
  S.KyousoubaId,
  S.Id"
                );
            }
        }

        private void UpdateShussouba(Updater updater){
            using (var t = new Transaction())
            {
                var con = t.Connection;
                var db = t.DB;

                updater.Text = "出走回数～順位までを生成しています";
                var shussoubaFukaList = db.QueryOnDemand<ShussoubaFuka>(
                    con,
@"SELECT
  SF.Id,
  SF.RaceId,
  SF.KyousoubaId,
  SF.DeokureByousuu,
  SF.FuriByousuu,
  (
    SELECT
      COUNT(*)
    FROM
      Race R2
      INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
    WHERE
      R2.HeichiShougai = 0
    AND
      R2.Nengappi < R.Nengappi
    AND
      S2.KyousoubaId = S.KyousoubaId 
    AND
      S2.TorikeshiShubetsu IS NULL
  ) AS ShussouKaisuu,
  (
    SELECT
      SUM(CASE WHEN SF2.DeokureByousuu > 0.0 THEN 1 ELSE 0 END)
    FROM
      Race R2
      INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
      INNER JOIN ShussoubaFuka SF2 ON S2.Id = SF2.Id
    WHERE
      R2.HeichiShougai = 0
    AND
      R2.Nengappi < R.Nengappi
    AND
      S2.KyousoubaId = S.KyousoubaId 
    AND
      S2.TorikeshiShubetsu IS NULL
  ) AS DeokureKaisuu,
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
          R2.HeichiShougai = 0
        AND
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
  ) AS RaceKankaku,
  (
    CASE
      WHEN S.Blinker = 1 THEN
      (
        CASE
          WHEN NOT EXISTS
          (
            SELECT
              *
            FROM
              Race R2
              INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
            WHERE
              R2.HeichiShougai = 0
            AND
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
              Race R2
              INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
            WHERE
              R2.HeichiShougai = 0
            AND
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
        END
      )
      ELSE
      (
        (
          SELECT
            (CASE WHEN S2.Blinker IN (1, 2) THEN 0 ELSE NULL END)
          FROM
            Race R2
            INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
          WHERE
            R2.HeichiShougai = 0
          AND
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
    END
  ) AS BlinkerHenka,
  (CASE WHEN Zenhan3F IS NULL THEN NULL ELSE (
    SELECT
      MIN(S2.Zenhan3F)
    FROM
      Shussouba S2
    WHERE
      S2.RaceId = R.Id
  ) - S.Zenhan3F END) AS Zenhan3FTimeSa,
  (CASE WHEN Kouhan3FMade IS NULL THEN NULL ELSE (
    SELECT
      MIN(S2.Kouhan3FMade)
    FROM
      Shussouba S2
    WHERE
      S2.RaceId = R.Id
  ) - S.Kouhan3FMade END) AS Kouhan3FMadeTimeSa,
  (CASE WHEN Kouhan3F IS NULL THEN NULL ELSE (
    SELECT
      MIN(S2.Kouhan3F)
    FROM
      Shussouba S2
    WHERE
      S2.RaceId = R.Id
  ) - S.Kouhan3F END) AS Kouhan3FTimeSa
FROM
  Race R
  INNER JOIN RaceFuka RF ON R.Id = RF.Id
  INNER JOIN Shussouba S ON R.Id = S.RaceId
  INNER JOIN ShussoubaFuka SF ON S.Id = SF.Id
WHERE
  R.HeichiShougai = 0
AND
  SF.ShussouKaisuu IS NULL"
);
                foreach (var shussoubaFuka in shussoubaFukaList) {
                    db.Update<ShussoubaFuka>(con, shussoubaFuka);
                }

                updater.Text = "出遅れ確率～後半3Fまで偏差値平均までを生成しています";
                db.Execute(con,
@"UPDATE ShussoubaFuka
SET
  DeokureKakuritsu =
    CAST(DeokureKaisuu AS REAL) / CAST(ShussouKaisuu AS REAL),
  KakoZenhan3FTimeSa =
  (
    SELECT
      AVG(Zenhan3FTimeSa)
    FROM
    (
      SELECT
        SF2.Zenhan3FTimeSa
      FROM
        Race R,
        Race R2
        INNER JOIN ShussoubaFuka SF2 ON R2.Id = SF2.RaceId
      WHERE
        R.Id = ShussoubaFuka.RaceId
      AND
        R2.HeichiShougai = 0
      AND
        R2.Nengappi < R.Nengappi
      AND
        SF2.KyousoubaId = ShussoubaFuka.KyousoubaId
      AND
        SF2.Zenhan3FTimeSa IS NOT NULL
      ORDER BY
        R2.Nengappi DESC
      LIMIT
        3
    )
  ),
  KakoKouhan3FMadeTimeSa =
  (
    SELECT
      AVG(Kouhan3FMadeTimeSa)
    FROM
    (
      SELECT
        SF2.Kouhan3FMadeTimeSa
      FROM
        Race R,
        Race R2
        INNER JOIN ShussoubaFuka SF2 ON R2.Id = SF2.RaceId
      WHERE
        R.Id = ShussoubaFuka.RaceId
      AND
        R2.HeichiShougai = 0
      AND
        R2.Nengappi < R.Nengappi
      AND
        SF2.KyousoubaId = ShussoubaFuka.KyousoubaId
      AND
        SF2.Kouhan3FMadeTimeSa IS NOT NULL
      ORDER BY
        R2.Nengappi DESC
      LIMIT
        3
    )
  ),
  KakoKouhan3FTimeSa =
  (
    SELECT
      AVG(Kouhan3FTimeSa)
    FROM
    (
      SELECT
        SF2.Kouhan3FTimeSa
      FROM
        Race R,
        Race R2
        INNER JOIN ShussoubaFuka SF2 ON R2.Id = SF2.RaceId
      WHERE
        R.Id = ShussoubaFuka.RaceId
      AND
        R2.HeichiShougai = 0
      AND
        R2.Nengappi < R.Nengappi
      AND
        SF2.KyousoubaId = ShussoubaFuka.KyousoubaId
      AND
        SF2.Kouhan3FTimeSa IS NOT NULL
      ORDER BY
        R2.Nengappi DESC
      LIMIT
        3
    )
  ),
  KakoTimeSa =
  (
    SELECT
      AVG(TimeSa)
    FROM
    (
      SELECT
        S2.TimeSa
      FROM
        Race R,
        Race R2
        INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
      WHERE
        R.Id = ShussoubaFuka.RaceId
      AND
        R2.HeichiShougai = 0
      AND
        R2.Nengappi < R.Nengappi
      AND
        S2.KyousoubaId = ShussoubaFuka.KyousoubaId
      AND
        S2.TimeSa IS NOT NULL
      ORDER BY
        R2.Nengappi DESC
      LIMIT
        3
    )
  )
WHERE
  DeokureKakuritsu IS NULL"
                );

            }

        }

        #endregion


    }

}
