INSERT INTO PredictBase
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
      S2.TorikeshiShubetsu IS NOT NULL
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
      S2.TorikeshiShubetsu IS NOT NULL
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
          S2.TorikeshiShubetsu IS NOT NULL
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
              S2.TorikeshiShubetsu IS NOT NULL
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
  PB.Id IS NULL
;
UPDATE PredictBase
SET
  DeokureKakuritsu = DeokureKaisuu / ShussouKaisuu
WHERE
  DeokureKakuritsu IS NULL
;

INSERT INTO PredictShussouba
SELECT
  /* domain */'',
  S.Id,
  R.Id AS RaceId,
  AVG(SF.HoseiTimeHensachi),
  STD(SF.HoseiTimeHensachi),
	AVG(SF.HoseiZenhan3FHensachi),
	STD(SF.HoseiZenhan3FHensachi),
	AVG(SF.HoseiChuukanHensachi),
	STD(SF.HoseiChuukanHensachi),
	AVG(SF.HoseiKouhan3FMadeHensachi),
	STD(SF.HoseiKouhan3FMadeHensachi),
	AVG(SF.HoseiKouhan3FHensachi),
	STD(SF.HoseiKouhan3FHensachi)
FROM
  ({0}) R
  INNER JOIN Shussouba S ON R.Id = S.RaceId,
  ({0}) R2
  INNER JOIN Shussouba S2 ON R2.Id = S2.RaceId
  INNER JOIN ShussoubaFuka SF ON S2.Id = SF.Id
  LEFT JOIN PredictShussouba PS ON SF.Id = PS.Id AND PS.Domain = /* domain */''
WHERE
  R2.Nengappi < R.Nengappi
AND
  S2.KyousoubaId = S.KyousoubaId
AND
  PS.Id IS NULL
GROUP BY
  R.Id,
  S.Id
;

INSERT INTO PredictRace
SELECT
  /* domain */'',
  Id,
  AVG(TimeHMean),
  STD(TimeHMean),
  AVG(Zenhan3FHMean),
  STD(Zenhan3FHMean),
  AVG(ChuukanHMean),
  STD(ChuukanHMean),
  AVG(Kouhan3FMadeHMean),
  STD(Kouhan3FMadeHMean),
  AVG(Kouhan3FHMean),
  STD(Kouhan3FHMean)
FROM
  PredictShussouba
WHERE
  Domain = /* domain */''
GROUP BY
  RaceId
;

INSERT INTO PredictTenkai
SELECT
  /* domain */'',
  PS.Id,
  10.0 * (TimeHMean - M_TimeHMean) / SD_TimeHMean + 50.0,
  10.0 * (Zenhan3FHMean - M_Zenhan3FHMean) / SD_Zenhan3FHMean + 50.0,
  10.0 * (ChuukanHMean - M_ChuukanHMean) / SD_ChuukanHMean + 50.0,
  10.0 * (Kouhan3FMadeHMean - M_Kouhan3FMadeHMean) / SD_Kouhan3FMadeHMean + 50.0,
  10.0 * (Kouhan3FHMean - M_Kouhan3FHMean) / SD_Kouhan3FHMean + 50.0
FROM
  PredictRace PR
  INNER JOIN PredictShussouba PS ON PR.Id = PS.RaceId AND PS.Domain = /* domain */''
  LEFT JOIN PredictTenkai PT ON PS.Id = PT.Id AND PT.Domain = /* domain */''
WHERE
  PR.Domain = /* domain */''
AND
  PT.Id IS NULL
;

CREATE VIEW LearningSprint
AS
SELECT
  PB.Id,
  PB.DeokureKakuritsu,
  PTS.TimeHH,
  PTS.Zenhan3FHH,
  PTS.ChuukanHH,
  PTS.Kouhan3FMadeHH,
  PTS.Kouhan3FHH,
  PTM.TimeHH,
  PTM.Zenhan3FHH,
  PTM.ChuukanHH,
  PTM.Kouhan3FMadeHH,
  PTM.Kouhan3FHH,
  S.Gate,
  SF.HoseiTimeHensachi
FROM
  Race R
  LEFT JOIN Shussouba S ON R.Id = S.RaceId
  LEFT JOIN ShussoubaFuka SF on S.Id = SF.Id
  LEFT JOIN PredictBase PB ON S.Id = PB.Id
  LEFT JOIN PredictTenkai PTS ON PB.Id = PTS.Id AND PTS.Domain = 'Sprint'
  LEFT JOIN PredictTenkai PTM ON PB.Id = PTM.Id AND PTM.Domain = 'Mile'
WHERE
  R.KaisaiNen < 2011
AND
  R.HeichiShougai = 0
AND
  R.Kyori < 1400
AND
  R.Jouken1 NOT IN (0, 1, 2, 3)
;
CREATE VIEW PredictSprint
AS
SELECT
  PB.Id,
  PB.DeokureKakuritsu,
  PTS.TimeHH,
  PTS.Zenhan3FHH,
  PTS.ChuukanHH,
  PTS.Kouhan3FMadeHH,
  PTS.Kouhan3FHH,
  PTM.TimeHH,
  PTM.Zenhan3FHH,
  PTM.ChuukanHH,
  PTM.Kouhan3FMadeHH,
  PTM.Kouhan3FHH,
  S.Gate
FROM
  Race R
  LEFT JOIN Shussouba S ON R.Id = S.RaceId
  LEFT JOIN PredictBase PB ON S.Id = PB.Id
  LEFT JOIN PredictTenkai PTS ON PB.Id = PTS.Id AND PTS.Domain = 'Sprint'
  LEFT JOIN PredictTenkai PTM ON PB.Id = PTM.Id AND PTM.Domain = 'Mile'
WHERE
  R.KaisaiNen = 2011
AND
  R.HeichiShougai = 0
AND
  R.Kyori < 1400
AND
  R.Jouken1 NOT IN (0, 1, 2, 3)
;