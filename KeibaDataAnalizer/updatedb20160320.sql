CREATE TABLE IF NOT EXISTS OddsKubun(
	Id BIGINT NOT NULL PRIMARY KEY
	,RaceId BIGINT NOT NULL REFERENCES Race(Id) ON DELETE CASCADE
	,YosouKakutei INT NOT NULL /* 1:�\�z�I�b�Y 2:�m��I�b�Y */
	,BakenShubetsu INT NOT NULL /* 1:�P�� 2:�g�A 3:�n�A 4:���� 5:���C�h 6:�n�P 7:�O�A�� 8:�O�A�P */
	,DataSakuseiNengappi DATE NOT NULL
);
CREATE UNIQUE INDEX IF NOT EXISTS UQ_OddsKubun ON OddsKubun(RaceId, YosouKakutei, BakenShubetsu);
CREATE INDEX IF NOT EXISTS IX_OddsKubun ON OddsKubun(RaceId);

CREATE TABLE IF NOT EXISTS Odds(
	OddsKubunId BIGINT NOT NULL REFERENCES OddsKubun(Id) ON DELETE CASCADE
	,Bangou1 INT NOT NULL
	,Bangou2 INT
	,Bangou3 INT
	,Odds1 REAL
	,Odds2 REAL
);
CREATE UNIQUE INDEX IF NOT EXISTS UQ_Odds ON Odds(OddsKubunId, Bangou1, Bangou2, Bangou3);
CREATE INDEX IF NOT EXISTS IX_Odds ON Odds(OddsKubunId);
