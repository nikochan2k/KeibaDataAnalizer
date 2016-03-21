PRAGMA foreign_keys = true;
PRAGMA synchronous = OFF;
PRAGMA journal_mode = MEMORY;
PRAGMA temp_store = MEMORY;

CREATE TABLE Race(
	Id BIGINT NOT NULL PRIMARY KEY
	,KaisaiBasho INT NOT NULL
	,KaisaiNen INT NOT NULL
	,KaisaiKaiji INT NOT NULL
	,KaisaiNichiji INT NOT NULL
	,RaceBangou INT NOT NULL
	,Nengappi DATE NOT NULL
	,Kyuujitsu INT NOT NULL
	,Youbi INT NOT NULL
	,KouryuuFlag INT
	,ChuuouChihouGaikoku INT NOT NULL
	,IppanTokubetsu INT NOT NULL
	,HeichiShougai INT NOT NULL
	,JuushouKaisuu INT
	,TokubetsuMei TEXT
	,TanshukuTokubetsuMei TEXT
	,Grade INT
	,JpnFlag INT
	,BetteiBareiHandi INT
	,BetteiBareiHandiShousai TEXT
	,JoukenFuka1 INT
	,JoukenFuka2 INT
	,JoukenKei INT NOT NULL
	,JoukenNenreiSeigen INT NOT NULL
	,Jouken1 INT
	,Kumi1 INT
	,IjouIkaMiman INT
	,Jouken2 INT
	,Kumi2 INT
	,DirtShiba INT NOT NULL
	,MigiHidari INT NOT NULL
	,UchiSoto INT
	,Course INT
	,Kyori INT NOT NULL
	,CourseRecordFlag INT
	,CourseRecordNengappi DATE
	,CourseRecordTime REAL
	,CourseRecordBamei TEXT
	,CourseRecordKinryou REAL
	,CourseRecordTanshukuKishuMei TEXT
	,KyoriRecordNengappi DATE
	,KyoriRecordTime REAL
	,KyoriRecordBamei TEXT
	,KyoriRecordKinryou REAL
	,KyoriRecordTanshukuKishuMei TEXT
	,KyoriRecordBasho INT
	,RaceRecordNengappi DATE
	,RaceRecordTime REAL
	,RaceRecordBamei TEXT
	,RaceRecordKinryou REAL
	,RaceRecordTanshukuKishuMei TEXT
	,RaceRecordBasho INT
	,Shoukin1Chaku INT
	,Shoukin2Chaku INT
	,Shoukin3Chaku INT
	,Shoukin4Chaku INT
	,Shoukin5Chaku INT
	,Shoukin5ChakuDouchaku1 INT
	,Shoukin5ChakuDouchaku2 INT
	,FukaShou INT
	,MaeuriFlag INT
	,YoteiHassouJikan TEXT
	,Tousuu INT NOT NULL
	,TorikeshiTousuu INT NOT NULL
	,SuiteiTimeRyou REAL
	,SuiteiTimeOmoFuryou REAL
	,YosouPace INT
	,Pace INT
	,Tenki INT
	,Baba INT
	,Seed INT
	,ShougaiHeikin1F REAL
	,ShutsubahyouSakuseiNengappi DATE
	,SeisekiSakuseiNengappi DATE
);
CREATE INDEX UQ_Race ON Race(Nengappi, KaisaiBasho, RaceBangou);

CREATE TABLE RaceLapTime(
	Id BIGINT NOT NULL PRIMARY KEY
	,RaceId BIGINT NOT NULL REFERENCES Race(Id) ON DELETE CASCADE
	,Bangou INT NOT NULL
	,KaishiKyori INT NOT NULL
	,ShuuryouKyori INT NOT NULL
	,LapTime REAL NOT NULL
);
CREATE UNIQUE INDEX UQ_RaceLapTime ON RaceLapTime(RaceId, Bangou);

CREATE TABLE RaceHaitou(
	Id BIGINT NOT NULL PRIMARY KEY REFERENCES Race(Id) ON DELETE CASCADE
	,TanUmaban1 INT
	,TanshouHaitoukin1 INT
	,TanUmaban2 INT
	,TanshouHaitoukin2 INT
	,TanUmaban3 INT
	,TanshouHaitoukin3 INT
	,FukuUmaban1 INT
	,FukushouHaitoukin1 INT
	,FukuUmaban2 INT
	,FukushouHaitoukin2 INT
	,FukuUmaban3 INT
	,FukushouHaitoukin3 INT
	,FukuUmaban4 INT
	,FukushouHaitoukin4 INT
	,FukuUmaban5 INT
	,FukushouHaitoukin5 INT
	,Wakuren11 INT
	,Wakuren12 INT
	,WakurenHaitoukin1 INT
	,WakurenNinki1 INT
	,Wakuren21 INT
	,Wakuren22 INT
	,WakurenHaitoukin2 INT
	,WakurenNinki2 INT
	,Wakuren31 INT
	,Wakuren32 INT
	,WakurenHaitoukin3 INT
	,WakurenNinki3 INT
	,Umaren11 INT
	,Umaren12 INT
	,UmarenHaitoukin1 INT
	,UmarenNinki1 INT
	,Umaren21 INT
	,Umaren22 INT
	,UmarenHaitoukin2 INT
	,UmarenNinki2 INT
	,Umaren31 INT
	,Umaren32 INT
	,UmarenHaitoukin3 INT
	,UmarenNinki3 INT
	,WideUmaren11 INT
	,WideUmaren12 INT
	,WideUmarenHaitoukin1 INT
	,WideUmarenNinki1 INT
	,WideUmaren21 INT
	,WideUmaren22 INT
	,WideUmarenHaitoukin2 INT
	,WideUmarenNinki2 INT
	,WideUmaren31 INT
	,WideUmaren32 INT
	,WideUmarenHaitoukin3 INT
	,WideUmarenNinki3 INT
	,WideUmaren41 INT
	,WideUmaren42 INT
	,WideUmarenHaitoukin4 INT
	,WideUmarenNinki4 INT
	,WideUmaren51 INT
	,WideUmaren52 INT
	,WideUmarenHaitoukin5 INT
	,WideUmarenNinki5 INT
	,WideUmaren61 INT
	,WideUmaren62 INT
	,WideUmarenHaitoukin6 INT
	,WideUmarenNinki6 INT
	,WideUmaren71 INT
	,WideUmaren72 INT
	,WideUmarenHaitoukin7 INT
	,WideUmarenNinki7 INT
	,Umatan11 INT
	,Umatan12 INT
	,UmatanHaitoukin1 INT
	,UmatanNinki1 INT
	,Umatan21 INT
	,Umatan22 INT
	,UmatanHaitoukin2 INT
	,UmatanNinki2 INT
	,Umatan31 INT
	,Umatan32 INT
	,UmatanHaitoukin3 INT
	,UmatanNinki3 INT
	,Umatan41 INT
	,Umatan42 INT
	,UmatanHaitoukin4 INT
	,UmatanNinki4 INT
	,Umatan51 INT
	,Umatan52 INT
	,UmatanHaitoukin5 INT
	,UmatanNinki5 INT
	,Umatan61 INT
	,Umatan62 INT
	,UmatanHaitoukin6 INT
	,UmatanNinki6 INT
	,Sanrenpuku11 INT
	,Sanrenpuku12 INT
	,Sanrenpuku13 INT
	,SanrenpukuHaitoukin1 INT
	,SanrenpukuNinki1 INT
	,Sanrenpuku21 INT
	,Sanrenpuku22 INT
	,Sanrenpuku23 INT
	,SanrenpukuHaitoukin2 INT
	,SanrenpukuNinki2 INT
	,Sanrenpuku31 INT
	,Sanrenpuku32 INT
	,Sanrenpuku33 INT
	,SanrenpukuHaitoukin3 INT
	,SanrenpukuNinki3 INT
	,Sanrentan11 INT
	,Sanrentan12 INT
	,Sanrentan13 INT
	,SanrentanHaitoukin1 INT
	,SanrentanNinki1 INT
	,Sanrentan21 INT
	,Sanrentan22 INT
	,Sanrentan23 INT
	,SanrentanHaitoukin2 INT
	,SanrentanNinki2 INT
	,Sanrentan31 INT
	,Sanrentan32 INT
	,Sanrentan33 INT
	,SanrentanHaitoukin3 INT
	,SanrentanNinki3 INT
	,Sanrentan41 INT
	,Sanrentan42 INT
	,Sanrentan43 INT
	,SanrentanHaitoukin4 INT
	,SanrentanNinki4 INT
	,Sanrentan51 INT
	,Sanrentan52 INT
	,Sanrentan53 INT
	,SanrentanHaitoukin5 INT
	,SanrentanNinki5 INT
	,Sanrentan61 INT
	,Sanrentan62 INT
	,Sanrentan63 INT
	,SanrentanHaitoukin6 INT
	,SanrentanNinki6 INT
);

CREATE TABLE OddsKubun(
	Id BIGINT NOT NULL PRIMARY KEY
	,RaceId BIGINT NOT NULL REFERENCES Race(Id) ON DELETE CASCADE
	,YosouKakutei INT NOT NULL /* 1:�\�z�I�b�Y 2:�m��I�b�Y */
	,BakenShubetsu INT NOT NULL /* 1:�P�� 2:�g�A 3:�n�A 4:���� 5:���C�h 6:�n�P 7:�O�A�� 8:�O�A�P */
	,DataSakuseiNengappi DATE NOT NULL
);
CREATE UNIQUE INDEX UQ_OddsKubun ON OddsKubun(RaceId, YosouKakutei, BakenShubetsu);
CREATE INDEX IX_OddsKubun ON OddsKubun(RaceId);

CREATE TABLE Odds(
	OddsKubunId BIGINT NOT NULL REFERENCES OddsKubun(Id) ON DELETE CASCADE
	,Bangou1 INT NOT NULL
	,Bangou2 INT
	,Bangou3 INT
	,Odds1 REAL
	,Odds2 REAL
);
CREATE UNIQUE INDEX UQ_Odds ON Odds(OddsKubunId, Bangou1, Bangou2, Bangou3);
CREATE INDEX IX_Odds ON Odds(OddsKubunId);

CREATE TABLE Shussouba(
	Id BIGINT NOT NULL PRIMARY KEY
	,RaceId BIGINT NOT NULL REFERENCES Race(Id) ON DELETE CASCADE
	,Wakuban INT NOT NULL
	,Umaban INT NOT NULL
	,Gate INT NOT NULL
	,KyousoubaId TEXT
	,KanaBamei TEXT NOT NULL
	,UmaKigou INT
	,Seibetsu INT NOT NULL
	,Nenrei INT NOT NULL
	,BanushiMei TEXT
	,TanshukuBanushiMei TEXT
	,Blinker INT
	,Kinryou REAL
	,Bataijuu INT
	,Zougen INT
	,RecordShisuu INT
	,KishuId INT NOT NULL
	,KishuMei TEXT NOT NULL
	,TanshukuKishuMei TEXT
	,KishuTouzaiBetsu INT
	,KishuShozokuBasho INT
	,KishuShozokuKyuushaId INT
	,MinaraiKubun INT
	,Norikawari INT
	,KyuushaId INT
	,KyuushaMei TEXT
	,TanshukuKyuushaMei TEXT
	,KyuushaShozokuBasho INT
	,KyuushaRitsuHokuNanBetsu INT
	,YosouShirushi INT
	,YosouShirushiHonshi INT
	,Ninki INT
	,Odds REAL
	,KakuteiChakujun INT
	,ChakujunFuka INT
	,NyuusenChakujun INT
	,TorikeshiShubetsu INT
	,RecordNinshiki INT
	,Time REAL
	,Chakusa1 INT
	,Chakusa2 INT
	,TimeSa REAL
	,Zenhan3F REAL
  ,Chuukan REAL
  ,Kouhan3FMade REAL
	,Kouhan3F REAL
	,YonCornerIchiDori INT
	,Seinen INT NOT NULL
	,ShutsubahyouSakuseiNengappi DATE
	,SeisekiSakuseiNengappi DATE
);
CREATE UNIQUE INDEX UQ_Shussouba ON Shussouba(RaceId, Umaban);
CREATE INDEX IX_Shussouba01 ON Shussouba(Time);
CREATE INDEX IX_Shussouba02 ON Shussouba(Zenhan3F);
CREATE INDEX IX_Shussouba03 ON Shussouba(Kouhan3F);
CREATE INDEX IX_Shussouba04 ON Shussouba(KyousoubaId);
CREATE INDEX IX_Shussouba05 ON Shussouba(KanaBamei);
CREATE INDEX IX_Shussouba06 ON Shussouba(KishuId);
CREATE INDEX IX_Shussouba07 ON Shussouba(KyuushaId);

CREATE TABLE Kishu(
	Id INT NOT NULL PRIMARY KEY
	,KishuMei TEXT NOT NULL
	,TanshukuKishuMei TEXT
	,Furigana TEXT
	,Seinengappi DATE
	,HatsuMenkyoNen INT
	,KishuTouzaiBetsu INT
	,KishuShozokuBasho INT
	,KishuShikakuKubun INT
	,MinaraiKubun INT
	,KishuShozokuKyuushaId INT
	,TourokuMasshouFlag INT
	,DataSakuseiNengappi DATE
);
CREATE UNIQUE INDEX UQ_Kishu ON Kishu(TanshukuKishuMei);

CREATE TABLE Kyuusha(
	Id INT NOT NULL PRIMARY KEY
	,KyuushaMei TEXT NOT NULL
	,TanshukuKyuushaMei TEXT
	,Furigana TEXT
	,Seinengappi DATE
	,HatsuMenkyoNen INT
	,KyuushaTouzaiBetsu INT
	,KyuushaShozokuBasho INT
	,KyuushaRitsuHokuNanBetsu INT
	,TourokuMasshouFlag INT
	,DataSakuseiNengappi DATE
);
CREATE UNIQUE INDEX UQ_Kyuusha ON Kyuusha(TanshukuKyuushaMei);
INSERT INTO Kyuusha
(
  Id
  ,KyuushaMei
  ,TanshukuKyuushaMei
)
VALUES
(
  0
  ,'�t���['
  ,'�t���['
);

CREATE TABLE Choukyou(
	Id BIGINT NOT NULL PRIMARY KEY REFERENCES Shussouba(Id) ON DELETE CASCADE
	,KyousoubaId TEXT NOT NULL
	,Tanpyou TEXT
	,HonsuuCourse INT
	,HonsuuHanro INT
	,HonsuuPool INT
	,Rating REAL
  ,KyuuyouRiyuu TEXT
);
CREATE INDEX IX_Choukyou ON Choukyou(KyousoubaId);

CREATE TABLE ChoukyouRireki(
	Id BIGINT NOT NULL PRIMARY KEY
	,ChoukyouId BIGINT NOT NULL REFERENCES Choukyou(Id) ON DELETE CASCADE
	,Oikiri INT
	,Kijousha TEXT
	,Nengappi DATE
	,Basho TEXT
	,ChoukyouCourse TEXT
	,ChoukyouBaba TEXT
	,Kaisuu INT
	,IchiDori INT
	,Ashiiro TEXT
	,Yajirushi INT
	,Reigai TEXT
	,Awase TEXT
);
CREATE INDEX IX_ChoukyouRireki ON ChoukyouRireki(ChoukyouId);

CREATE TABLE ChoukyouTime(
	Id BIGINT NOT NULL PRIMARY KEY
	,ChoukyouRirekiId BIGINT NOT NULL REFERENCES ChoukyouRireki(Id) ON DELETE CASCADE
	,F INT NOT NULL
	,Time REAL
	,Comment TEXT
);
CREATE INDEX UQ_ChoukyouTime ON ChoukyouTime(ChoukyouRirekiId, F);

CREATE TABLE ShussoubaTsuukaJuni(
	Id BIGINT NOT NULL PRIMARY KEY
	,ShussoubaId BIGINT NOT NULL REFERENCES Shussouba(Id) ON DELETE CASCADE
	,Bangou INT NOT NULL
	,Juni INT
	,Joukyou INT
);
CREATE INDEX UQ_ShussoubaTsuukaJuni ON ShussoubaTsuukaJuni(ShussoubaId, Bangou);

CREATE TABLE RaceHassouJoukyou(
	Id BIGINT NOT NULL PRIMARY KEY
	,RaceId BIGINT NOT NULL REFERENCES Race(Id) ON DELETE CASCADE
	,UmabanGun TEXT NOT NULL
	,HassouJoukyou TEXT NOT NULL
	,Ichi INT NOT NULL
	,Joukyou INT NOT NULL
	,FuriByousuu REAL
);
CREATE INDEX IX_RaceHassouJoukyou ON RaceHassouJoukyou(RaceId);

CREATE TABLE ShussoubaHassouJoukyou(
	Id BIGINT NOT NULL PRIMARY KEY
	,RaceHassouJoukyouId BIGINT NOT NULL REFERENCES RaceHassouJoukyou(Id) ON DELETE CASCADE
	,ShussoubaId BIGINT NOT NULL REFERENCES Shussouba(Id) ON DELETE CASCADE
);
CREATE INDEX IX_ShussoubaHassouJoukyou01 ON ShussoubaHassouJoukyou(RaceHassouJoukyouId);
CREATE INDEX IX_ShussoubaHassouJoukyou02 ON ShussoubaHassouJoukyou(ShussoubaId);

CREATE TABLE RaceKeika(
	Id BIGINT NOT NULL PRIMARY KEY
	,RaceId BIGINT NOT NULL REFERENCES Race(Id) ON DELETE CASCADE
	,Bangou INT NOT NULL
	,Keika TEXT NOT NULL
	,Midashi1 INT
	,Midashi2 INT
);
CREATE UNIQUE INDEX UQ_RaceKeika ON RaceKeika(RaceId, Bangou);

CREATE TABLE ShussoubaKeika(
	Id BIGINT NOT NULL PRIMARY KEY
	,RaceKeikaId BIGINT NOT NULL REFERENCES RaceKeika(Id) ON DELETE CASCADE
	,ShussoubaId BIGINT NOT NULL REFERENCES Shussouba(Id) ON DELETE CASCADE
	,Tate TEXT
	,Yoko TEXT
);
CREATE INDEX IX_ShussoubaKeika01 ON ShussoubaKeika(RaceKeikaId);
CREATE INDEX IX_ShussoubaKeika02 ON ShussoubaKeika(ShussoubaId);

CREATE TABLE Kyousouba(
	Id TEXT NOT NULL PRIMARY KEY
	,KanaBamei TEXT NOT NULL
	,KyuuBamei TEXT
	,Seinengappi DATE
	,Keiro INT
	,Kesshu INT
	,Sanchi INT
	,UmaKigou INT
	,Seibetsu INT
	,ChichiUmaId TEXT
	,ChichiUmaMei TEXT
	,HahaUmaId TEXT
	,HahaUmaMei TEXT
	,HahaChichiUmaId TEXT
	,HahaChichiUmaMei TEXT
	,HahaHahaUmaId TEXT
	,HahaHahaUmaMei TEXT
	,BanushiMei TEXT
	,TanshukuBanushiMei TEXT
	,SeisanshaMei TEXT
	,TanshukuSeisanshaMei TEXT
	,KyuushaId INT
	,KyuushaMei TEXT
	,TanshukuKyuushaMei TEXT
	,KyuushaShozokuBasho INT
	,KyuushaRitsuHokuNanBetsu INT
	,KoueiGaikokuKyuushaMei TEXT
	,MasshouFlag INT
	,MasshouNengappi DATE
	,Jiyuu TEXT
	,Ikisaki TEXT
	,ChichiKyoriTekisei INT
	,HirabaOmoKousetsu INT
	,HirabaDirtKousetsu INT
	,ShougaiOmoKousetsu INT
	,ShougaiDirtKousetsu INT
	,DataSakuseiNengappi DATE NOT NULL
);

CREATE TABLE ImportFile(
	Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
	,ImportDateTime DATETIME NOT NULL
	,FileName TEXT NOT NULL
	,FileSize BIGINT NOT NULL
	,MD5 TEXT NOT NULL
	,Status INT NOT NULL
);

CREATE TABLE Course(
  KaisaiBasho INT NOT NULL
  ,DirtShiba INT NOT NULL
  ,UchiSoto INT
  ,Course INT
  ,ChokusenKyori REAL NOT NULL
  ,ChokusenKouteisa REAL NOT NULL
  ,PRIMARY KEY(KaisaiBasho, DirtShiba, UchiSoto, Course)
);
INSERT INTO Course VALUES(0,0,NULL,NULL,329,0.0);
INSERT INTO Course VALUES(0,1,0,0,328,0.0);
INSERT INTO Course VALUES(0,1,0,1,323,0.0);
INSERT INTO Course VALUES(0,1,0,2,323,0.0);
INSERT INTO Course VALUES(0,1,0,3,323,0.0);
INSERT INTO Course VALUES(0,1,1,0,404,0.0);
INSERT INTO Course VALUES(0,1,1,1,399,0.0);
INSERT INTO Course VALUES(0,1,1,2,399,0.0);
INSERT INTO Course VALUES(0,1,1,3,399,0.0);
INSERT INTO Course VALUES(1,0,NULL,NULL,352.5,-1.4);
INSERT INTO Course VALUES(1,1,0,0,356.5,-1.4);
INSERT INTO Course VALUES(1,1,0,1,359.1,-1.4);
INSERT INTO Course VALUES(1,1,1,0,473.6,-0.5);
INSERT INTO Course VALUES(1,1,1,1,476.3,-0.5);
INSERT INTO Course VALUES(2,0,NULL,NULL,312,0.9);
INSERT INTO Course VALUES(2,1,NULL,0,314,0.5);
INSERT INTO Course VALUES(2,1,NULL,1,314,0.5);
INSERT INTO Course VALUES(2,1,NULL,2,314,0.5);
INSERT INTO Course VALUES(3,0,NULL,NULL,291,-0.3);
INSERT INTO Course VALUES(3,1,NULL,0,293,0);
INSERT INTO Course VALUES(3,1,NULL,1,293,0);
INSERT INTO Course VALUES(3,1,NULL,2,293,0);
INSERT INTO Course VALUES(4,0,NULL,NULL,501,-2.5);
INSERT INTO Course VALUES(4,1,NULL,0,525.9,-2.1);
INSERT INTO Course VALUES(4,1,NULL,1,525.9,-2.1);
INSERT INTO Course VALUES(4,1,NULL,2,525.9,-2.1);
INSERT INTO Course VALUES(4,1,NULL,3,525.9,-2.1);
INSERT INTO Course VALUES(5,0,NULL,NULL,308,-2.2);
INSERT INTO Course VALUES(5,1,0,0,310,-2.5);
INSERT INTO Course VALUES(5,1,0,1,310,-2.5);
INSERT INTO Course VALUES(5,1,0,2,310,-2.5);
INSERT INTO Course VALUES(5,1,1,0,310,-2.5);
INSERT INTO Course VALUES(5,1,1,1,310,-2.5);
INSERT INTO Course VALUES(5,1,1,2,310,-2.5);
INSERT INTO Course VALUES(6,0,NULL,NULL,295.7,-0.9);
INSERT INTO Course VALUES(6,1,NULL,0,292,-0.5);
INSERT INTO Course VALUES(6,1,NULL,1,297.5,-0.5);
INSERT INTO Course VALUES(6,1,NULL,2,299.7,-0.5);
INSERT INTO Course VALUES(7,0,NULL,NULL,354,0);
INSERT INTO Course VALUES(7,1,NULL,0,600,0.2);
INSERT INTO Course VALUES(7,1,NULL,1,600,0.2);
INSERT INTO Course VALUES(7,1,0,0,359,0.1);
INSERT INTO Course VALUES(7,1,0,1,359,0.1);
INSERT INTO Course VALUES(7,1,1,0,600,0.2);
INSERT INTO Course VALUES(7,1,1,1,600,0.2);
INSERT INTO Course VALUES(8,0,NULL,NULL,264,-0.1);
INSERT INTO Course VALUES(8,1,NULL,0,266,-0.1);
INSERT INTO Course VALUES(8,1,NULL,1,266,-0.1);
INSERT INTO Course VALUES(8,1,NULL,2,266,-0.1);
INSERT INTO Course VALUES(9,0,NULL,NULL,260,1);
INSERT INTO Course VALUES(9,1,NULL,0,262,1);
INSERT INTO Course VALUES(9,1,NULL,1,262,1);
INSERT INTO Course VALUES(9,1,NULL,2,262,1);

CREATE TABLE ImportLog(
	Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
	,ImportFileId BIGINT NOT NULL REFERENCES ImportFile(Id) ON DELETE CASCADE
	,UncompressedFileName TEXT
	,TextIndex INT
	,TextSize INT
	,Message TEXT NOT NULL
	,DetailedMessage TEXT
);
CREATE INDEX IX_ImportLog ON ImportLog(ImportFileId);

CREATE TABLE Code(
	Domain TEXT NOT NULL
	,Key INT NOT NULL
	,Val TEXT NOT NULL
	,PRIMARY KEY(Domain, Key)
);
INSERT INTO "Code" VALUES('Basho',0,'���s');
INSERT INTO "Code" VALUES('Basho',1,'��_');
INSERT INTO "Code" VALUES('Basho',2,'����');
INSERT INTO "Code" VALUES('Basho',3,'���q');
INSERT INTO "Code" VALUES('Basho',4,'����');
INSERT INTO "Code" VALUES('Basho',5,'���R');
INSERT INTO "Code" VALUES('Basho',6,'����');
INSERT INTO "Code" VALUES('Basho',7,'�V��');
INSERT INTO "Code" VALUES('Basho',8,'�D�y');
INSERT INTO "Code" VALUES('Basho',9,'����');
INSERT INTO "Code" VALUES('Basho',10,'���');
INSERT INTO "Code" VALUES('Basho',11,'���');
INSERT INTO "Code" VALUES('Basho',12,'�D��');
INSERT INTO "Code" VALUES('Basho',13,'�Y�a');
INSERT INTO "Code" VALUES('Basho',14,'�〈');
INSERT INTO "Code" VALUES('Basho',15,'����');
INSERT INTO "Code" VALUES('Basho',16,'�эL');
INSERT INTO "Code" VALUES('Basho',17,'��c');
INSERT INTO "Code" VALUES('Basho',18,'�k��');
INSERT INTO "Code" VALUES('Basho',19,'�}��');
INSERT INTO "Code" VALUES('Basho',20,'����');
INSERT INTO "Code" VALUES('Basho',21,'�r��');
INSERT INTO "Code" VALUES('Basho',22,'�F�s');
INSERT INTO "Code" VALUES('Basho',23,'����');
INSERT INTO "Code" VALUES('Basho',24,'����');
INSERT INTO "Code" VALUES('Basho',25,'����');
INSERT INTO "Code" VALUES('Basho',26,'���m');
INSERT INTO "Code" VALUES('Basho',27,'����');
INSERT INTO "Code" VALUES('Basho',28,'��R');
INSERT INTO "Code" VALUES('Basho',29,'����');
INSERT INTO "Code" VALUES('Basho',30,'�O��');
INSERT INTO "Code" VALUES('Basho',31,'�I��');
INSERT INTO "Code" VALUES('Basho',32,'�v�c');
INSERT INTO "Code" VALUES('Basho',33,'����');
INSERT INTO "Code" VALUES('Basho',34,'����');
INSERT INTO "Code" VALUES('Basho',35,'�D�y');
INSERT INTO "Code" VALUES('Basho',36,'����');
INSERT INTO "Code" VALUES('Basho',37,'���c');
INSERT INTO "Code" VALUES('Basho',38,'���R');
INSERT INTO "Code" VALUES('Basho',39,'�P�H');
INSERT INTO "Code" VALUES('Basho',40,'����');
INSERT INTO "Code" VALUES('Basho',41,'�V��');
INSERT INTO "Code" VALUES('Basho',42,'���');
INSERT INTO "Code" VALUES('Basho',43,'��x');
INSERT INTO "Code" VALUES('Basho',44,'����');
INSERT INTO "Code" VALUES('Basho',45,'���e');
INSERT INTO "Code" VALUES('Basho',46,'����');
INSERT INTO "Code" VALUES('Basho',47,'����');
INSERT INTO "Code" VALUES('Basho',50,'�I��');
INSERT INTO "Code" VALUES('Basho',51,'���Y��');
INSERT INTO "Code" VALUES('Basho',52,'���Y�k');
INSERT INTO "Code" VALUES('Basho',53,'����');
INSERT INTO "Code" VALUES('Basho',54,'���c');
INSERT INTO "Code" VALUES('Basho',55,'���');
INSERT INTO "Code" VALUES('Basho',56,'�〈');
INSERT INTO "Code" VALUES('Basho',57,'����');
INSERT INTO "Code" VALUES('Basho',58,'�эL');
INSERT INTO "Code" VALUES('Basho',59,'�k��');
INSERT INTO "Code" VALUES('Basho',60,'���`');
INSERT INTO "Code" VALUES('Basho',61,'�č�');
INSERT INTO "Code" VALUES('Basho',62,'�p��');
INSERT INTO "Code" VALUES('Basho',63,'����');
INSERT INTO "Code" VALUES('Basho',64,'����');
INSERT INTO "Code" VALUES('Basho',65,'UAE');
INSERT INTO "Code" VALUES('Basho',66,'����');
INSERT INTO "Code" VALUES('Basho',67,'�ɍ�');
INSERT INTO "Code" VALUES('Basho',68,'�ƍ�');
INSERT INTO "Code" VALUES('Basho',69,'���B');
INSERT INTO "Code" VALUES('Basho',70,'����');
INSERT INTO "Code" VALUES('Basho',71,'�V��');
INSERT INTO "Code" VALUES('Basho',72,'�`��');
INSERT INTO "Code" VALUES('Basho',73,'����');
INSERT INTO "Code" VALUES('Basho',74,'����');
INSERT INTO "Code" VALUES('Basho',75,'�V�Ú�');
INSERT INTO "Code" VALUES('Basho',76,'���T');
INSERT INTO "Code" VALUES('Basho',77,'���ǉ�');
INSERT INTO "Code" VALUES('Basho',78,'����');
INSERT INTO "Code" VALUES('Basho',79,'�����`');
INSERT INTO "Code" VALUES('Basho',80,'�}�J�I');
INSERT INTO "Code" VALUES('Basho',81,'�ҍ�');
INSERT INTO "Code" VALUES('Basho',90,'����');
INSERT INTO "Code" VALUES('Basho',91,'�Ȗ�');
INSERT INTO "Code" VALUES('Basho',99,'�k�C');
INSERT INTO "Code" VALUES('Kyuujitsu',0,'����');
INSERT INTO "Code" VALUES('Kyuujitsu',1,'�j��');
INSERT INTO "Code" VALUES('Kyuujitsu',2,'�U�֋x��');
INSERT INTO "Code" VALUES('Kyuujitsu',3,'�����̋x��');
INSERT INTO "Code" VALUES('Youbi',1,'�y');
INSERT INTO "Code" VALUES('Youbi',2,'��');
INSERT INTO "Code" VALUES('Youbi',3,'��');
INSERT INTO "Code" VALUES('Youbi',4,'��');
INSERT INTO "Code" VALUES('Youbi',5,'��');
INSERT INTO "Code" VALUES('Youbi',6,'��');
INSERT INTO "Code" VALUES('Youbi',7,'��');
INSERT INTO "Code" VALUES('KouryuuFlag',1,'��');
INSERT INTO "Code" VALUES('ChuuouChihouGaikoku',0,'����');
INSERT INTO "Code" VALUES('ChuuouChihouGaikoku',1,'��֓�');
INSERT INTO "Code" VALUES('ChuuouChihouGaikoku',2,'���c');
INSERT INTO "Code" VALUES('ChuuouChihouGaikoku',3,'���c');
INSERT INTO "Code" VALUES('ChuuouChihouGaikoku',4,'�O��');
INSERT INTO "Code" VALUES('IppanTokubetsu',0,'���');
INSERT INTO "Code" VALUES('IppanTokubetsu',1,'����');
INSERT INTO "Code" VALUES('IppanTokubetsu',2,'���d��');
INSERT INTO "Code" VALUES('IppanTokubetsu',3,'�d��');
INSERT INTO "Code" VALUES('HeichiShougai',0,'���n');
INSERT INTO "Code" VALUES('HeichiShougai',1,'��Q');
INSERT INTO "Code" VALUES('Grade',0,'G1');
INSERT INTO "Code" VALUES('Grade',1,'G2');
INSERT INTO "Code" VALUES('Grade',2,'G3');
INSERT INTO "Code" VALUES('Grade',3,'JG1');
INSERT INTO "Code" VALUES('Grade',4,'JG2');
INSERT INTO "Code" VALUES('Grade',5,'JG3');
INSERT INTO "Code" VALUES('BetteiBareiHandi',0,'�ʒ�');
INSERT INTO "Code" VALUES('BetteiBareiHandi',1,'�n��');
INSERT INTO "Code" VALUES('BetteiBareiHandi',2,'�n���f');
INSERT INTO "Code" VALUES('BetteiBareiHandi',3,'���');
INSERT INTO "Code" VALUES('BetteiBareiHandi',90,'�K��');
INSERT INTO "Code" VALUES('JoukenFuka1',0,'����');
INSERT INTO "Code" VALUES('JoukenFuka1',1,'��B�Y�n');
INSERT INTO "Code" VALUES('JoukenFuka1',2,'����');
INSERT INTO "Code" VALUES('JoukenFuka1',3,'��');
INSERT INTO "Code" VALUES('JoukenFuka1',4,'����');
INSERT INTO "Code" VALUES('JoukenFuka1',5,'����');
INSERT INTO "Code" VALUES('JoukenFuka1',6,'����');
INSERT INTO "Code" VALUES('JoukenFuka1',7,'���s����');
INSERT INTO "Code" VALUES('JoukenFuka1',8,'��������');
INSERT INTO "Code" VALUES('JoukenFuka1',9,'����');
INSERT INTO "Code" VALUES('JoukenFuka1',10,'������');
INSERT INTO "Code" VALUES('JoukenFuka1',11,'���s');
INSERT INTO "Code" VALUES('JoukenFuka1',12,'����');
INSERT INTO "Code" VALUES('JoukenFuka1',13,'�������w');
INSERT INTO "Code" VALUES('JoukenFuka1',14,'��������');
INSERT INTO "Code" VALUES('JoukenFuka1',15,'�����֐��z�z�n');
INSERT INTO "Code" VALUES('JoukenFuka1',16,'�����֓��z�z�n');
INSERT INTO "Code" VALUES('JoukenFuka1',17,'�����֐��z�z�n');
INSERT INTO "Code" VALUES('JoukenFuka1',18,'�����֓��z�z�n');
INSERT INTO "Code" VALUES('JoukenFuka1',19,'���s�����֐��z�z�n');
INSERT INTO "Code" VALUES('JoukenFuka1',20,'���s�����֓��z�z�n');
INSERT INTO "Code" VALUES('JoukenFuka1',21,'���w');
INSERT INTO "Code" VALUES('JoukenFuka1',22,'����');
INSERT INTO "Code" VALUES('JoukenFuka1',23,'�I��');
INSERT INTO "Code" VALUES('JoukenFuka1',24,'��');
INSERT INTO "Code" VALUES('JoukenFuka1',25,'��');
INSERT INTO "Code" VALUES('JoukenFuka1',26,'��t�Y');
INSERT INTO "Code" VALUES('JoukenFuka1',27,'����������n');
INSERT INTO "Code" VALUES('JoukenFuka1',28,'������n');
INSERT INTO "Code" VALUES('JoukenFuka1',29,'����');
INSERT INTO "Code" VALUES('JoukenFuka1',30,'���w��');
INSERT INTO "Code" VALUES('JoukenFuka1',31,'�����w');
INSERT INTO "Code" VALUES('JoukenFuka1',32,'���w��');
INSERT INTO "Code" VALUES('JoukenFuka1',33,'���E��');
INSERT INTO "Code" VALUES('JoukenFuka1',34,'JRA�F��');
INSERT INTO "Code" VALUES('JoukenFuka1',35,'�Ĕn������');
INSERT INTO "Code" VALUES('JoukenFuka1',36,'���E��');
INSERT INTO "Code" VALUES('JoukenFuka1',37,'������');
INSERT INTO "Code" VALUES('JoukenFuka1',38,'�������E��');
INSERT INTO "Code" VALUES('JoukenFuka1',39,'JRA�w��');
INSERT INTO "Code" VALUES('JoukenFuka1',40,'�����ۉ��E��');
INSERT INTO "Code" VALUES('JoukenFuka2',1,'���w��');
INSERT INTO "Code" VALUES('JoukenFuka2',2,'�����w');
INSERT INTO "Code" VALUES('JoukenFuka2',3,'���w��');
INSERT INTO "Code" VALUES('JoukenFuka2',4,'���w');
INSERT INTO "Code" VALUES('JoukenKei',0,'�T���n');
INSERT INTO "Code" VALUES('JoukenKei',1,'�A���u�n');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',0,'2��');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',1,'3��');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',2,'4��');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',3,'3,4,5��');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',4,'4,5,6��');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',5,'3�Έȏ�');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',6,'4�Έȏ�');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',7,'3,4��');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',8,'4,5��');
INSERT INTO "Code" VALUES('JoukenNenreiSeigen',9,'�Ȃ�');
INSERT INTO "Code" VALUES('Jouken',0,'����');
INSERT INTO "Code" VALUES('Jouken',1,'�V�n');
INSERT INTO "Code" VALUES('Jouken',2,'���o��');
INSERT INTO "Code" VALUES('Jouken',3,'������');
INSERT INTO "Code" VALUES('Jouken',4,'�I�[�v��');
INSERT INTO "Code" VALUES('Jouken',5,'�I�[�v��,�Ĕn');
INSERT INTO "Code" VALUES('Jouken',6,'�w��n');
INSERT INTO "Code" VALUES('Jouken',7,'�����I�[�v��');
INSERT INTO "Code" VALUES('Jouken',8,'�Ĕn');
INSERT INTO "Code" VALUES('Jouken',9,'�I�[�u��,�Ĕn,�A���u����');
INSERT INTO "Code" VALUES('Jouken',10,'A');
INSERT INTO "Code" VALUES('Jouken',11,'A1');
INSERT INTO "Code" VALUES('Jouken',12,'A2');
INSERT INTO "Code" VALUES('Jouken',13,'A3');
INSERT INTO "Code" VALUES('Jouken',14,'A4');
INSERT INTO "Code" VALUES('Jouken',20,'B');
INSERT INTO "Code" VALUES('Jouken',21,'B1');
INSERT INTO "Code" VALUES('Jouken',22,'B2');
INSERT INTO "Code" VALUES('Jouken',23,'B3');
INSERT INTO "Code" VALUES('Jouken',24,'B4');
INSERT INTO "Code" VALUES('Jouken',30,'C');
INSERT INTO "Code" VALUES('Jouken',31,'C1');
INSERT INTO "Code" VALUES('Jouken',32,'C2');
INSERT INTO "Code" VALUES('Jouken',33,'C3');
INSERT INTO "Code" VALUES('Jouken',34,'C4');
INSERT INTO "Code" VALUES('Jouken',40,'D');
INSERT INTO "Code" VALUES('Jouken',41,'D1');
INSERT INTO "Code" VALUES('Jouken',42,'D2');
INSERT INTO "Code" VALUES('Jouken',43,'D3');
INSERT INTO "Code" VALUES('Jouken',44,'D4');
INSERT INTO "Code" VALUES('Jouken',93,'��������');
INSERT INTO "Code" VALUES('Jouken',94,'�\�͎���');
INSERT INTO "Code" VALUES('Jouken',5000,'500��');
INSERT INTO "Code" VALUES('Jouken',9000,'900��');
INSERT INTO "Code" VALUES('Jouken',10000,'1000��');
INSERT INTO "Code" VALUES('Jouken',15000,'1500��');
INSERT INTO "Code" VALUES('Jouken',16000,'1600��');
INSERT INTO "Code" VALUES('Jouken',-13,'���o');
INSERT INTO "Code" VALUES('Jouken',-14,'����');
INSERT INTO "Code" VALUES('Jouken',-15,'�V�n');
INSERT INTO "Code" VALUES('Jouken',-16,'�I�[�v��');
INSERT INTO "Code" VALUES('Jouken',-42,'3��');
INSERT INTO "Code" VALUES('Jouken',-43,'4��');
INSERT INTO "Code" VALUES('Jouken',-44,'�\��');
INSERT INTO "Code" VALUES('Jouken',-50,'����');
INSERT INTO "Code" VALUES('Jouken',-51,'G�T');
INSERT INTO "Code" VALUES('Jouken',-52,'G�U');
INSERT INTO "Code" VALUES('Jouken',-53,'G�V');
INSERT INTO "Code" VALUES('Jouken',-54,'G�W');
INSERT INTO "Code" VALUES('Jouken',-55,'G�X');
INSERT INTO "Code" VALUES('Jouken',-56,'5��');
INSERT INTO "Code" VALUES('Jouken',-57,'C5');
INSERT INTO "Code" VALUES('Jouken',-58,'C6');
INSERT INTO "Code" VALUES('Jouken',-59,'2��');
INSERT INTO "Code" VALUES('Jouken',-60,'�F���o');
INSERT INTO "Code" VALUES('Jouken',-61,'�F����');
INSERT INTO "Code" VALUES('Jouken',-62,'�F��');
INSERT INTO "Code" VALUES('Jouken',-63,'�T��');
INSERT INTO "Code" VALUES('Jouken',-64,'E');
INSERT INTO "Code" VALUES('Jouken',-65,'F');
INSERT INTO "Code" VALUES('IjouIkaMiman',0,'�ȏ�');
INSERT INTO "Code" VALUES('IjouIkaMiman',1,'�ȉ�');
INSERT INTO "Code" VALUES('IjouIkaMiman',2,'�`');
INSERT INTO "Code" VALUES('IjouIkaMiman',3,'����');
INSERT INTO "Code" VALUES('IjouIkaMiman',4,'�E');
INSERT INTO "Code" VALUES('IjouIkaMiman',5,'�ȏ�');
INSERT INTO "Code" VALUES('IjouIkaMiman',6,'�ȉ�');
INSERT INTO "Code" VALUES('IjouIkaMiman',7,'����');
INSERT INTO "Code" VALUES('DirtShiba',0,'�_�[�g');
INSERT INTO "Code" VALUES('DirtShiba',1,'��');
INSERT INTO "Code" VALUES('MigiHidari',0,'�E');
INSERT INTO "Code" VALUES('MigiHidari',1,'��');
INSERT INTO "Code" VALUES('MigiHidari',2,'����');
INSERT INTO "Code" VALUES('UchiSoto',0,'��');
INSERT INTO "Code" VALUES('UchiSoto',1,'�O');
INSERT INTO "Code" VALUES('UchiSoto',2,'�O����');
INSERT INTO "Code" VALUES('UchiSoto',3,'�^�k�L');
INSERT INTO "Code" VALUES('UchiSoto',4,'���Q');
INSERT INTO "Code" VALUES('UchiSoto',5,'��2��');
INSERT INTO "Code" VALUES('UchiSoto',6,'�����O');
INSERT INTO "Code" VALUES('Course',0,'A');
INSERT INTO "Code" VALUES('Course',1,'B');
INSERT INTO "Code" VALUES('Course',2,'C');
INSERT INTO "Code" VALUES('Course',3,'D');
INSERT INTO "Code" VALUES('Course',4,'A1');
INSERT INTO "Code" VALUES('Course',5,'A2');
INSERT INTO "Code" VALUES('RecordFlag',0,'�');
INSERT INTO "Code" VALUES('RecordFlag',1,'���R�[�h');
INSERT INTO "Code" VALUES('RecordFlag',2,'�Q�l');
INSERT INTO "Code" VALUES('MaeuriFlag',1,'�O����');
INSERT INTO "Code" VALUES('Pace',0,'H');
INSERT INTO "Code" VALUES('Pace',1,'M');
INSERT INTO "Code" VALUES('Pace',2,'S');
INSERT INTO "Code" VALUES('Tenki',0,'��');
INSERT INTO "Code" VALUES('Tenki',1,'��');
INSERT INTO "Code" VALUES('Tenki',2,'�J');
INSERT INTO "Code" VALUES('Tenki',3,'���J');
INSERT INTO "Code" VALUES('Tenki',4,'��');
INSERT INTO "Code" VALUES('Tenki',5,'��');
INSERT INTO "Code" VALUES('Tenki',6,'����');
INSERT INTO "Code" VALUES('Baba',0,'��');
INSERT INTO "Code" VALUES('Baba',1,'�c�d');
INSERT INTO "Code" VALUES('Baba',2,'�d');
INSERT INTO "Code" VALUES('Baba',3,'�s��');
INSERT INTO "Code" VALUES('Seed',1,'�V�[�h');
INSERT INTO "Code" VALUES('Midashi1',1,'�t');
INSERT INTO "Code" VALUES('Midashi1',2,'1��');
INSERT INTO "Code" VALUES('Midashi1',3,'�t1��');
INSERT INTO "Code" VALUES('Midashi1',4,'2��');
INSERT INTO "Code" VALUES('Midashi2',0,'�X�^���h�O');
INSERT INTO "Code" VALUES('Midashi2',1,'������');
INSERT INTO "Code" VALUES('Midashi2',2,'2�p');
INSERT INTO "Code" VALUES('Midashi2',3,'3�p');
INSERT INTO "Code" VALUES('Midashi2',4,'4�p ');
INSERT INTO "Code" VALUES('Midashi2',5,'�^�k�L');
INSERT INTO "Code" VALUES('Midashi2',6,'�o���P�b�g');
INSERT INTO "Code" VALUES('Midashi2',7,'����');
INSERT INTO "Code" VALUES('Midashi2',8,'��|��');
INSERT INTO "Code" VALUES('Midashi2',9,'��y��');
INSERT INTO "Code" VALUES('Midashi2',10,'�ԃ����K');
INSERT INTO "Code" VALUES('Midashi2',11,'���n');
INSERT INTO "Code" VALUES('Midashi2',12,'1�p');
INSERT INTO "Code" VALUES('Midashi2',13,'�傢���_');
INSERT INTO "Code" VALUES('Midashi2',14,'3F');
INSERT INTO "Code" VALUES('UmaKigou',1,'����');
INSERT INTO "Code" VALUES('UmaKigou',2,'����');
INSERT INTO "Code" VALUES('UmaKigou',3,'����');
INSERT INTO "Code" VALUES('UmaKigou',4,'���s');
INSERT INTO "Code" VALUES('UmaKigou',5,'���n');
INSERT INTO "Code" VALUES('UmaKigou',6,'���O');
INSERT INTO "Code" VALUES('UmaKigou',7,'��������');
INSERT INTO "Code" VALUES('UmaKigou',8,'�������s');
INSERT INTO "Code" VALUES('UmaKigou',9,'�������n');
INSERT INTO "Code" VALUES('UmaKigou',10,'���s���n');
INSERT INTO "Code" VALUES('UmaKigou',11,'���O���n');
INSERT INTO "Code" VALUES('UmaKigou',12,'�������s���n');
INSERT INTO "Code" VALUES('UmaKigou',15,'����');
INSERT INTO "Code" VALUES('UmaKigou',16,'�������O');
INSERT INTO "Code" VALUES('UmaKigou',17,'��������');
INSERT INTO "Code" VALUES('UmaKigou',18,'�������s');
INSERT INTO "Code" VALUES('UmaKigou',19,'�����������s');
INSERT INTO "Code" VALUES('UmaKigou',20,'�������O');
INSERT INTO "Code" VALUES('UmaKigou',21,'���n');
INSERT INTO "Code" VALUES('UmaKigou',22,'���O���n');
INSERT INTO "Code" VALUES('UmaKigou',23,'�������n');
INSERT INTO "Code" VALUES('UmaKigou',24,'���s���n');
INSERT INTO "Code" VALUES('UmaKigou',25,'�������s���n');
INSERT INTO "Code" VALUES('UmaKigou',26,'���O');
INSERT INTO "Code" VALUES('UmaKigou',27,'�������O');
INSERT INTO "Code" VALUES('UmaKigou',40,'�������O���n');
INSERT INTO "Code" VALUES('UmaKigou',41,'�������O���n');
INSERT INTO "Code" VALUES('Seibetsu',0,'��');
INSERT INTO "Code" VALUES('Seibetsu',1,'��');
INSERT INTO "Code" VALUES('Seibetsu',2,'����');
INSERT INTO "Code" VALUES('Blinker',1,'�u�����J�[');
INSERT INTO "Code" VALUES('KishuTouzaiBetsu',1,'��');
INSERT INTO "Code" VALUES('KishuTouzaiBetsu',2,'��');
INSERT INTO "Code" VALUES('KishuTouzaiBetsu',3,'����');
INSERT INTO "Code" VALUES('KyuushaTouzaiBetsu',1,'��');
INSERT INTO "Code" VALUES('KyuushaTouzaiBetsu',2,'��');
INSERT INTO "Code" VALUES('MinaraiKubun',1,'1kg��');
INSERT INTO "Code" VALUES('MinaraiKubun',2,'2kg��');
INSERT INTO "Code" VALUES('MinaraiKubun',3,'3kg��');
INSERT INTO "Code" VALUES('Norikawari',1,'���ւ�');
INSERT INTO "Code" VALUES('KyuushaRitsuHokuNanBetsu',1,'�I��');
INSERT INTO "Code" VALUES('KyuushaRitsuHokuNanBetsu',2,'���Y��');
INSERT INTO "Code" VALUES('KyuushaRitsuHokuNanBetsu',3,'���Y�k');
INSERT INTO "Code" VALUES('Yosou',0,'��');
INSERT INTO "Code" VALUES('Yosou',1,'��');
INSERT INTO "Code" VALUES('Yosou',2,'��');
INSERT INTO "Code" VALUES('Yosou',3,'��');
INSERT INTO "Code" VALUES('Yosou',4,'�~');
INSERT INTO "Code" VALUES('ChakujunFuka',31,'���n');
INSERT INTO "Code" VALUES('ChakujunFuka',32,'���i');
INSERT INTO "Code" VALUES('ChakujunFuka',33,'���~');
INSERT INTO "Code" VALUES('ChakujunFuka',34,'���');
INSERT INTO "Code" VALUES('ChakujunFuka',35,'���O');
INSERT INTO "Code" VALUES('ChakujunFuka',36,'�~��');
INSERT INTO "Code" VALUES('ChakujunFuka',37,'�J��');
INSERT INTO "Code" VALUES('ChakujunFuka',40,'�s��');
INSERT INTO "Code" VALUES('TorikeshiShubetsu',1,'�o�����');
INSERT INTO "Code" VALUES('TorikeshiShubetsu',2,'�o�����O');
INSERT INTO "Code" VALUES('TorikeshiShubetsu',3,'�������O');
INSERT INTO "Code" VALUES('TorikeshiShubetsu',4,'�������~');
INSERT INTO "Code" VALUES('TorikeshiShubetsu',5,'���n');
INSERT INTO "Code" VALUES('TorikeshiShubetsu',6,'�������O');
INSERT INTO "Code" VALUES('Chakusa2',0,'�n�i');
INSERT INTO "Code" VALUES('Chakusa2',1,'�A�^�}');
INSERT INTO "Code" VALUES('Chakusa2',2,'�N�r');
INSERT INTO "Code" VALUES('Chakusa2',3,'1/2');
INSERT INTO "Code" VALUES('Chakusa2',4,'1/4');
INSERT INTO "Code" VALUES('Chakusa2',5,'3/4');
INSERT INTO "Code" VALUES('Chakusa2',7,'�卷');
INSERT INTO "Code" VALUES('Chakusa2',8,'����');
INSERT INTO "Code" VALUES('YonCornerIchiDori',0,'�œ�');
INSERT INTO "Code" VALUES('YonCornerIchiDori',1,'��');
INSERT INTO "Code" VALUES('YonCornerIchiDori',2,'��');
INSERT INTO "Code" VALUES('YonCornerIchiDori',3,'�O');
INSERT INTO "Code" VALUES('YonCornerIchiDori',4,'��O');
INSERT INTO "Code" VALUES('Oikiri',0,'�O��');
INSERT INTO "Code" VALUES('Oikiri',1,'�ǐ؂�');
INSERT INTO "Code" VALUES('AwaseFlag',1,'����1�̕���');
INSERT INTO "Code" VALUES('AwaseFlag',2,'����2�̕���');
INSERT INTO "Code" VALUES('AwaseFlag',3,'����3�̕���');
INSERT INTO "Code" VALUES('Yajirushi',1,'���');
INSERT INTO "Code" VALUES('Yajirushi',2,'���s');
INSERT INTO "Code" VALUES('Yajirushi',3,'���~');
INSERT INTO "Code" VALUES('Yajirushi',4,'�ǉ�');
INSERT INTO "Code" VALUES('Yajirushi',5,'���~�C��');
INSERT INTO "Code" VALUES('Ichi',1,'�e��');
INSERT INTO "Code" VALUES('Ichi',2,'����');
INSERT INTO "Code" VALUES('Ichi',3,'�A�K��');
INSERT INTO "Code" VALUES('Joukyou',31,'���n');
INSERT INTO "Code" VALUES('Joukyou',33,'���~');
INSERT INTO "Code" VALUES('Joukyou',40,'�s��');
INSERT INTO "Code" VALUES('Joukyou',41,'�o�x��');
INSERT INTO "Code" VALUES('Joukyou',42,'�O�g����');
INSERT INTO "Code" VALUES('Joukyou',43,'�΍s');
INSERT INTO "Code" VALUES('Joukyou',50,'�D��');
INSERT INTO "Code" VALUES('Keiro',1,'�I');
INSERT INTO "Code" VALUES('Keiro',2,'�ȌI');
INSERT INTO "Code" VALUES('Keiro',3,'��');
INSERT INTO "Code" VALUES('Keiro',4,'����');
INSERT INTO "Code" VALUES('Keiro',5,'��');
INSERT INTO "Code" VALUES('Keiro',6,'��');
INSERT INTO "Code" VALUES('Keiro',7,'��');
INSERT INTO "Code" VALUES('Keiro',8,'�I��');
INSERT INTO "Code" VALUES('Keiro',9,'����');
INSERT INTO "Code" VALUES('Keiro',10,'��');
INSERT INTO "Code" VALUES('Keiro',11,'��');
INSERT INTO "Code" VALUES('Keiro',12,'����');
INSERT INTO "Code" VALUES('Keiro',13,'��');
INSERT INTO "Code" VALUES('Keiro',20,'����');
INSERT INTO "Code" VALUES('Keiro',21,'��');
INSERT INTO "Code" VALUES('Keiro',22,'��');
INSERT INTO "Code" VALUES('Keiro',23,'��');
INSERT INTO "Code" VALUES('Keiro',24,'����');
INSERT INTO "Code" VALUES('Keiro',25,'��');
INSERT INTO "Code" VALUES('Keiro',26,'��');
INSERT INTO "Code" VALUES('Keiro',27,'��');
INSERT INTO "Code" VALUES('Keiro',28,'��');
INSERT INTO "Code" VALUES('Keiro',29,'��');
INSERT INTO "Code" VALUES('Keiro',30,'��');
INSERT INTO "Code" VALUES('Keiro',31,'����');
INSERT INTO "Code" VALUES('Keiro',32,'����');
INSERT INTO "Code" VALUES('Keiro',33,'����');
INSERT INTO "Code" VALUES('Keiro',34,'����');
INSERT INTO "Code" VALUES('Keiro',35,'����');
INSERT INTO "Code" VALUES('Kesshu',1,'�T��');
INSERT INTO "Code" VALUES('Kesshu',2,'�A��');
INSERT INTO "Code" VALUES('Kesshu',3,'�A�A');
INSERT INTO "Code" VALUES('Kesshu',4,'�T���n');
INSERT INTO "Code" VALUES('Kesshu',5,'�A���n');
INSERT INTO "Code" VALUES('Kesshu',7,'�y��');
INSERT INTO "Code" VALUES('Kesshu',8,'����');
INSERT INTO "Code" VALUES('Kesshu',10,'�d��');
INSERT INTO "Code" VALUES('Kesshu',11,'�A�m');
INSERT INTO "Code" VALUES('Kesshu',12,'�A�m�n');
INSERT INTO "Code" VALUES('Kesshu',13,'�N��');
INSERT INTO "Code" VALUES('Kesshu',14,'�N���n');
INSERT INTO "Code" VALUES('Kesshu',15,'�g��');
INSERT INTO "Code" VALUES('Kesshu',16,'�g���n');
INSERT INTO "Code" VALUES('Kesshu',17,'�m�j');
INSERT INTO "Code" VALUES('Kesshu',18,'�m�j�n');
INSERT INTO "Code" VALUES('Kesshu',19,'�n�N');
INSERT INTO "Code" VALUES('Kesshu',20,'�n�N�n');
INSERT INTO "Code" VALUES('Kesshu',50,'�T���n');
INSERT INTO "Code" VALUES('Sanchi',0,'�k�w�R');
INSERT INTO "Code" VALUES('Sanchi',1,'�����');
INSERT INTO "Code" VALUES('Sanchi',2,'�l��');
INSERT INTO "Code" VALUES('Sanchi',3,'�Y��');
INSERT INTO "Code" VALUES('Sanchi',4,'�O��');
INSERT INTO "Code" VALUES('Sanchi',5,'�Ó�');
INSERT INTO "Code" VALUES('Sanchi',6,'�V��');
INSERT INTO "Code" VALUES('Sanchi',7,'���');
INSERT INTO "Code" VALUES('Sanchi',8,'����');
INSERT INTO "Code" VALUES('Sanchi',9,'����');
INSERT INTO "Code" VALUES('Sanchi',10,'����');
INSERT INTO "Code" VALUES('Sanchi',11,'���V');
INSERT INTO "Code" VALUES('Sanchi',12,'����');
INSERT INTO "Code" VALUES('Sanchi',13,'�ɒB');
INSERT INTO "Code" VALUES('Sanchi',14,'���c');
INSERT INTO "Code" VALUES('Sanchi',15,'����');
INSERT INTO "Code" VALUES('Sanchi',16,'���^');
INSERT INTO "Code" VALUES('Sanchi',17,'�ԑ�');
INSERT INTO "Code" VALUES('Sanchi',18,'�r�c');
INSERT INTO "Code" VALUES('Sanchi',19,'�L��');
INSERT INTO "Code" VALUES('Sanchi',20,'�Y�y');
INSERT INTO "Code" VALUES('Sanchi',21,'�b��');
INSERT INTO "Code" VALUES('Sanchi',22,'�]��');
INSERT INTO "Code" VALUES('Sanchi',23,'�Ǖ�');
INSERT INTO "Code" VALUES('Sanchi',24,'������');
INSERT INTO "Code" VALUES('Sanchi',25,'���X');
INSERT INTO "Code" VALUES('Sanchi',26,'����');
INSERT INTO "Code" VALUES('Sanchi',27,'�эL');
INSERT INTO "Code" VALUES('Sanchi',28,'�͐�');
INSERT INTO "Code" VALUES('Sanchi',29,'���H');
INSERT INTO "Code" VALUES('Sanchi',30,'�I�R');
INSERT INTO "Code" VALUES('Sanchi',31,'������');
INSERT INTO "Code" VALUES('Sanchi',32,'�D�y');
INSERT INTO "Code" VALUES('Sanchi',33,'����');
INSERT INTO "Code" VALUES('Sanchi',34,'����');
INSERT INTO "Code" VALUES('Sanchi',35,'�W��');
INSERT INTO "Code" VALUES('Sanchi',36,'���f');
INSERT INTO "Code" VALUES('Sanchi',37,'�V��');
INSERT INTO "Code" VALUES('Sanchi',38,'���');
INSERT INTO "Code" VALUES('Sanchi',39,'�鐲');
INSERT INTO "Code" VALUES('Sanchi',40,'���');
INSERT INTO "Code" VALUES('Sanchi',41,'����');
INSERT INTO "Code" VALUES('Sanchi',42,'�m�y');
INSERT INTO "Code" VALUES('Sanchi',43,'��q��');
INSERT INTO "Code" VALUES('Sanchi',44,'�Ϗ��q');
INSERT INTO "Code" VALUES('Sanchi',45,'�L�Y');
INSERT INTO "Code" VALUES('Sanchi',46,'�L��');
INSERT INTO "Code" VALUES('Sanchi',47,'����');
INSERT INTO "Code" VALUES('Sanchi',48,'�o��');
INSERT INTO "Code" VALUES('Sanchi',49,'����');
INSERT INTO "Code" VALUES('Sanchi',50,'�l��');
INSERT INTO "Code" VALUES('Sanchi',51,'�L��');
INSERT INTO "Code" VALUES('Sanchi',52,'�[��');
INSERT INTO "Code" VALUES('Sanchi',53,'���');
INSERT INTO "Code" VALUES('Sanchi',54,'�{��');
INSERT INTO "Code" VALUES('Sanchi',55,'�X');
INSERT INTO "Code" VALUES('Sanchi',56,'���_');
INSERT INTO "Code" VALUES('Sanchi',57,'�X');
INSERT INTO "Code" VALUES('Sanchi',58,'���');
INSERT INTO "Code" VALUES('Sanchi',59,'�{��');
INSERT INTO "Code" VALUES('Sanchi',60,'�R�`');
INSERT INTO "Code" VALUES('Sanchi',61,'����');
INSERT INTO "Code" VALUES('Sanchi',62,'�Ȗ�');
INSERT INTO "Code" VALUES('Sanchi',63,'�Q�n');
INSERT INTO "Code" VALUES('Sanchi',64,'���');
INSERT INTO "Code" VALUES('Sanchi',65,'���');
INSERT INTO "Code" VALUES('Sanchi',66,'��t');
INSERT INTO "Code" VALUES('Sanchi',67,'����');
INSERT INTO "Code" VALUES('Sanchi',68,'���s');
INSERT INTO "Code" VALUES('Sanchi',69,'���m');
INSERT INTO "Code" VALUES('Sanchi',70,'�{��');
INSERT INTO "Code" VALUES('Sanchi',71,'������');
INSERT INTO "Code" VALUES('Sanchi',72,'�F�{');
INSERT INTO "Code" VALUES('Sanchi',73,'�č�');
INSERT INTO "Code" VALUES('Sanchi',74,'�p��');
INSERT INTO "Code" VALUES('Sanchi',75,'����');
INSERT INTO "Code" VALUES('Sanchi',76,'����');
INSERT INTO "Code" VALUES('Sanchi',77,'�ɍ�');
INSERT INTO "Code" VALUES('Sanchi',78,'�ƍ�');
INSERT INTO "Code" VALUES('Sanchi',79,'�J�i�_');
INSERT INTO "Code" VALUES('Sanchi',80,'�V��');
INSERT INTO "Code" VALUES('Sanchi',81,'���B');
INSERT INTO "Code" VALUES('Sanchi',82,'����');
INSERT INTO "Code" VALUES('Sanchi',83,'����');
INSERT INTO "Code" VALUES('Sanchi',84,'��m��');
INSERT INTO "Code" VALUES('Sanchi',85,'����');
INSERT INTO "Code" VALUES('Sanchi',86,'����');
INSERT INTO "Code" VALUES('Sanchi',87,'����');
INSERT INTO "Code" VALUES('Sanchi',88,'�s��');
INSERT INTO "Code" VALUES('Sanchi',89,'����');
INSERT INTO "Code" VALUES('Sanchi',90,'����');
INSERT INTO "Code" VALUES('Sanchi',91,'�ʊC');
INSERT INTO "Code" VALUES('Sanchi',92,'����');
INSERT INTO "Code" VALUES('Sanchi',93,'�_�ސ�');
INSERT INTO "Code" VALUES('Sanchi',94,'����');
INSERT INTO "Code" VALUES('Sanchi',95,'����');
INSERT INTO "Code" VALUES('Sanchi',96,'����');
INSERT INTO "Code" VALUES('Sanchi',97,'�싽');
INSERT INTO "Code" VALUES('Sanchi',98,'�X��');
INSERT INTO "Code" VALUES('Sanchi',99,'�`��');
INSERT INTO "Code" VALUES('Sanchi',100,'����');
INSERT INTO "Code" VALUES('Sanchi',101,'�莺');
INSERT INTO "Code" VALUES('Sanchi',102,'���W��');
INSERT INTO "Code" VALUES('Sanchi',103,'�R��');
INSERT INTO "Code" VALUES('Sanchi',104,'����');
INSERT INTO "Code" VALUES('Sanchi',105,'����');
INSERT INTO "Code" VALUES('Sanchi',106,'����');
INSERT INTO "Code" VALUES('Sanchi',107,'���v��');
INSERT INTO "Code" VALUES('Sanchi',108,'�W��');
INSERT INTO "Code" VALUES('Sanchi',109,'�啪');
INSERT INTO "Code" VALUES('Sanchi',110,'�É�');
INSERT INTO "Code" VALUES('Sanchi',111,'�R�m');
INSERT INTO "Code" VALUES('Sanchi',112,'�،Ó�');
INSERT INTO "Code" VALUES('Sanchi',113,'�y��');
INSERT INTO "Code" VALUES('Sanchi',114,'�䍑');
INSERT INTO "Code" VALUES('Sanchi',115,'����');
INSERT INTO "Code" VALUES('Sanchi',116,'�t�`�d');
INSERT INTO "Code" VALUES('Sanchi',117,'�L��');
INSERT INTO "Code" VALUES('Sanchi',118,'��A��');
INSERT INTO "Code" VALUES('Sanchi',119,'�ނ���');
INSERT INTO "Code" VALUES('Sanchi',120,'����');
INSERT INTO "Code" VALUES('Sanchi',121,'�V�Ђ���');
INSERT INTO "Code" VALUES('Sanchi',122,'�����');
INSERT INTO "Code" VALUES('Sanchi',123,'�I��');
INSERT INTO "Code" VALUES('Sanchi',124,'�H�c');
INSERT INTO "Code" VALUES('Sanchi',200,'�A���W');
INSERT INTO "Code" VALUES('Sanchi',201,'�ҍ�');
INSERT INTO "Code" VALUES('Sanchi',202,'�o���o');
INSERT INTO "Code" VALUES('Sanchi',203,'�u���K');
INSERT INTO "Code" VALUES('Sanchi',204,'�R����');
INSERT INTO "Code" VALUES('Sanchi',205,'�L���[');
INSERT INTO "Code" VALUES('Sanchi',206,'�L�v��');
INSERT INTO "Code" VALUES('Sanchi',207,'�`�F�R');
INSERT INTO "Code" VALUES('Sanchi',208,'����');
INSERT INTO "Code" VALUES('Sanchi',209,'���ƍ�');
INSERT INTO "Code" VALUES('Sanchi',210,'�G�N�A');
INSERT INTO "Code" VALUES('Sanchi',211,'����');
INSERT INTO "Code" VALUES('Sanchi',212,'��');
INSERT INTO "Code" VALUES('Sanchi',213,'����');
INSERT INTO "Code" VALUES('Sanchi',214,'���`');
INSERT INTO "Code" VALUES('Sanchi',215,'�^��');
INSERT INTO "Code" VALUES('Sanchi',216,'��x');
INSERT INTO "Code" VALUES('Sanchi',217,'�C���h');
INSERT INTO "Code" VALUES('Sanchi',218,'�C����');
INSERT INTO "Code" VALUES('Sanchi',219,'�C�X��');
INSERT INTO "Code" VALUES('Sanchi',220,'�W���}');
INSERT INTO "Code" VALUES('Sanchi',221,'���{');
INSERT INTO "Code" VALUES('Sanchi',222,'�P�j�A');
INSERT INTO "Code" VALUES('Sanchi',223,'���o�m');
INSERT INTO "Code" VALUES('Sanchi',224,'���x�A');
INSERT INTO "Code" VALUES('Sanchi',225,'���N�Z');
INSERT INTO "Code" VALUES('Sanchi',226,'�}���[');
INSERT INTO "Code" VALUES('Sanchi',227,'�}���^');
INSERT INTO "Code" VALUES('Sanchi',229,'���[��');
INSERT INTO "Code" VALUES('Sanchi',230,'���L�V');
INSERT INTO "Code" VALUES('Sanchi',231,'�����R');
INSERT INTO "Code" VALUES('Sanchi',232,'�m���E');
INSERT INTO "Code" VALUES('Sanchi',233,'�p�L�X');
INSERT INTO "Code" VALUES('Sanchi',234,'�p�i�}');
INSERT INTO "Code" VALUES('Sanchi',235,'�鍑');
INSERT INTO "Code" VALUES('Sanchi',236,'�䍑');
INSERT INTO "Code" VALUES('Sanchi',237,'�g��');
INSERT INTO "Code" VALUES('Sanchi',238,'����');
INSERT INTO "Code" VALUES('Sanchi',239,'�v�G��');
INSERT INTO "Code" VALUES('Sanchi',240,'����');
INSERT INTO "Code" VALUES('Sanchi',241,'�V���K');
INSERT INTO "Code" VALUES('Sanchi',242,'�숢��');
INSERT INTO "Code" VALUES('Sanchi',243,'�\�A');
INSERT INTO "Code" VALUES('Sanchi',244,'����');
INSERT INTO "Code" VALUES('Sanchi',245,'�X����');
INSERT INTO "Code" VALUES('Sanchi',246,'�X�[�_');
INSERT INTO "Code" VALUES('Sanchi',247,'�X�C�X');
INSERT INTO "Code" VALUES('Sanchi',248,'�g���j');
INSERT INTO "Code" VALUES('Sanchi',249,'�`���j');
INSERT INTO "Code" VALUES('Sanchi',250,'�y��');
INSERT INTO "Code" VALUES('Sanchi',251,'�E���O');
INSERT INTO "Code" VALUES('Sanchi',252,'�y�l�Y');
INSERT INTO "Code" VALUES('Sanchi',253,'���[�S');
INSERT INTO "Code" VALUES('Sanchi',254,'�W���o');
INSERT INTO "Code" VALUES('Sanchi',255,'���V�A');
INSERT INTO "Code" VALUES('Sanchi',256,'�V���A');
INSERT INTO "Code" VALUES('Sanchi',257,'����');
INSERT INTO "Code" VALUES('Sanchi',258,'�؍�');
INSERT INTO "Code" VALUES('Sanchi',259,'����');
INSERT INTO "Code" VALUES('MasshouFlag',1,'����');
INSERT INTO "Code" VALUES('KishuShikakuKubun',0,'���i�Ȃ�');
INSERT INTO "Code" VALUES('KishuShikakuKubun',1,'���n�E��Q');
INSERT INTO "Code" VALUES('KishuShikakuKubun',2,'���n');
INSERT INTO "Code" VALUES('KishuShikakuKubun',3,'��Q');
INSERT INTO "Code" VALUES('TourokuMasshouFlag',0,'����');
INSERT INTO "Code" VALUES('TourokuMasshouFlag',1,'����');
INSERT INTO "Code" VALUES('TourokuMasshouFlag',2,'����');
INSERT INTO "Code" VALUES('KyoriTekisei',1,'�Z');
INSERT INTO "Code" VALUES('KyoriTekisei',2,'��');
INSERT INTO "Code" VALUES('KyoriTekisei',3,'��');
INSERT INTO "Code" VALUES('Kousetsu',1,'��');
INSERT INTO "Code" VALUES('Kousetsu',2,'��');
INSERT INTO "Code" VALUES('Kousetsu',3,'��');


CREATE TABLE Japanize(
	Id TEXT PRIMARY KEY NOT NULL
	,Name TEXT NOT NULL
	,Domain TEXT
);
INSERT INTO "Japanize" VALUES('KaisaiBasho','�J�Ïꏊ','Basho');
INSERT INTO "Japanize" VALUES('KaisaiNen','�J�ÔN',NULL);
INSERT INTO "Japanize" VALUES('KaisaiKaiji','�J�É�',NULL);
INSERT INTO "Japanize" VALUES('KaisaiNichiji','�J�Ó���',NULL);
INSERT INTO "Japanize" VALUES('RaceBangou','���[�X�ԍ�',NULL);
INSERT INTO "Japanize" VALUES('Nengappi','�N����',NULL);
INSERT INTO "Japanize" VALUES('Kyuujitsu','�x��','Kyuujitsu');
INSERT INTO "Japanize" VALUES('Youbi','�j��','Youbi');
INSERT INTO "Japanize" VALUES('KouryuuFlag','�𗬃t���O','KouryuuFlag');
INSERT INTO "Japanize" VALUES('ChuuouChihouGaikoku','�����E�n���E�O��','ChuuouChihouGaikoku');
INSERT INTO "Japanize" VALUES('IppanTokubetsu','��E��','IppanTokubetsu');
INSERT INTO "Japanize" VALUES('HeichiShougai','���E��','HeichiShougai');
INSERT INTO "Japanize" VALUES('JuushouKaisuu','�d�܉�',NULL);
INSERT INTO "Japanize" VALUES('TokubetsuMei','���ʖ�',NULL);
INSERT INTO "Japanize" VALUES('TanshukuTokubetsuMei','�Z�k���ʖ�',NULL);
INSERT INTO "Japanize" VALUES('Grade','�O���[�h','Grade');
INSERT INTO "Japanize" VALUES('JpnFlag','Jpn�t���O',NULL);
INSERT INTO "Japanize" VALUES('BetteiBareiHandi','�ʒ�n��n���f�T�v','BetteiBareiHandi');
INSERT INTO "Japanize" VALUES('BetteiBareiHandiShousai','�ʒ�n��n���f�ڍ�',NULL);
INSERT INTO "Japanize" VALUES('JoukenFuka1','�����t��1','JoukenFuka1');
INSERT INTO "Japanize" VALUES('JoukenFuka2','�����t��2','JoukenFuka2');
INSERT INTO "Japanize" VALUES('JoukenKei','�����n','JoukenKei');
INSERT INTO "Japanize" VALUES('JoukenNenreiSeigen','�����N���','JoukenNenreiSeigen');
INSERT INTO "Japanize" VALUES('Jouken1','����1 ���c(�N���X)','Jouken');
INSERT INTO "Japanize" VALUES('Kumi1','�g1',NULL);
INSERT INTO "Japanize" VALUES('IjouIkaMiman','�ȏ�E�ȉ��E�`�E����','IjouIkaMiman');
INSERT INTO "Japanize" VALUES('Jouken2','����2 ���c(�N���X)','Jouken');
INSERT INTO "Japanize" VALUES('Kumi2','�g2',NULL);
INSERT INTO "Japanize" VALUES('DirtShiba','�_�E��','DirtShiba');
INSERT INTO "Japanize" VALUES('MigiHidari','�E�E��','MigiHidari');
INSERT INTO "Japanize" VALUES('UchiSoto','���E�O','UchiSoto');
INSERT INTO "Japanize" VALUES('Course','�R�[�X','Course');
INSERT INTO "Japanize" VALUES('Kyori','����',NULL);
INSERT INTO "Japanize" VALUES('CourseRecordFlag','�R�[�X���R�[�h�t���O','RecordFlag');
INSERT INTO "Japanize" VALUES('CourseRecordNengappi','�R�[�X���R�[�h���t',NULL);
INSERT INTO "Japanize" VALUES('CourseRecordTime','�R�[�X���R�[�h�^�C��',NULL);
INSERT INTO "Japanize" VALUES('CourseRecordBamei','�R�[�X���R�[�h�n��',NULL);
INSERT INTO "Japanize" VALUES('CourseRecordKinryou','�R�[�X���R�[�h�җ�',NULL);
INSERT INTO "Japanize" VALUES('CourseRecordTanshukuKishuMei','�R�[�X���R�[�h�Z�k�R�薼',NULL);
INSERT INTO "Japanize" VALUES('KyoriRecordNengappi','�������R�[�h���t',NULL);
INSERT INTO "Japanize" VALUES('KyoriRecordTime','�������R�[�h�^�C��',NULL);
INSERT INTO "Japanize" VALUES('KyoriRecordBamei','�������R�[�h�n��',NULL);
INSERT INTO "Japanize" VALUES('KyoriRecordKinryou','�������R�[�h�җ�',NULL);
INSERT INTO "Japanize" VALUES('KyoriRecordTanshukuKishuMei','�������R�[�h�Z�k�R�薼',NULL);
INSERT INTO "Japanize" VALUES('KyoriRecordBasho','�������R�[�h�ꏊ','Basho');
INSERT INTO "Japanize" VALUES('RaceRecordNengappi','���[�X���R�[�h���t',NULL);
INSERT INTO "Japanize" VALUES('RaceRecordTime','���[�X���R�[�h�^�C��',NULL);
INSERT INTO "Japanize" VALUES('RaceRecordBamei','���[�X���R�[�h�n��',NULL);
INSERT INTO "Japanize" VALUES('RaceRecordKinryou','���[�X���R�[�h�җ�',NULL);
INSERT INTO "Japanize" VALUES('RaceRecordKishuMei','���[�X���R�[�h�Z�k�R�薼',NULL);
INSERT INTO "Japanize" VALUES('RaceRecordBasho','���[�X���R�[�h�ꏊ','Basho');
INSERT INTO "Japanize" VALUES('Shoukin1Chaku','�܋�1��',NULL);
INSERT INTO "Japanize" VALUES('Shoukin2Chaku','�܋�2��',NULL);
INSERT INTO "Japanize" VALUES('Shoukin3Chaku','�܋�3��',NULL);
INSERT INTO "Japanize" VALUES('Shoukin4Chaku','�܋�4��',NULL);
INSERT INTO "Japanize" VALUES('Shoukin5Chaku','�܋�5��',NULL);
INSERT INTO "Japanize" VALUES('Shoukin5ChakuDouchaku1','�܋�5������',NULL);
INSERT INTO "Japanize" VALUES('Shoukin5ChakuDouchaku2','�܋�5������2',NULL);
INSERT INTO "Japanize" VALUES('FukaShou','������',NULL);
INSERT INTO "Japanize" VALUES('MaeuriFlag','�O����t���O','MaeuriFlag');
INSERT INTO "Japanize" VALUES('YoteiHassouJikan','�\�蔭������',NULL);
INSERT INTO "Japanize" VALUES('Tousuu','����',NULL);
INSERT INTO "Japanize" VALUES('TorikeshiTousuu','�������',NULL);
INSERT INTO "Japanize" VALUES('SuiteiTimeRyou','����^�C�� ��',NULL);
INSERT INTO "Japanize" VALUES('SuiteiTimeOmoFuryou','����^�C�� �d�E�s��',NULL);
INSERT INTO "Japanize" VALUES('YosouPace','�\�z�y�[�X','Pace');
INSERT INTO "Japanize" VALUES('Pace','�y�[�X','Pace');
INSERT INTO "Japanize" VALUES('Tenki','�V�C','Tenki');
INSERT INTO "Japanize" VALUES('Baba','�n��','Baba');
INSERT INTO "Japanize" VALUES('Seed','�V�[�h','Seed');
INSERT INTO "Japanize" VALUES('ShougaiHeikin1F','��Q����1F',NULL);
INSERT INTO "Japanize" VALUES('Midashi1','���o��1','Midashi1');
INSERT INTO "Japanize" VALUES('Midashi2','���o��2','Midashi2');
INSERT INTO "Japanize" VALUES('Keika','�o��',NULL);
INSERT INTO "Japanize" VALUES('HassouJoukyou','������',NULL);
INSERT INTO "Japanize" VALUES('KaishiKyori','�J�n����',NULL);
INSERT INTO "Japanize" VALUES('ShuuryouKyori','�I������',NULL);
INSERT INTO "Japanize" VALUES('LapTime','���b�v�^�C��',NULL);
INSERT INTO "Japanize" VALUES('TanUmaban1','�P�n��1',NULL);
INSERT INTO "Japanize" VALUES('TanshouHaitoukin1','�P���z����1',NULL);
INSERT INTO "Japanize" VALUES('TanUmaban2','�P�n��2',NULL);
INSERT INTO "Japanize" VALUES('TanshouHaitoukin2','�P���z����2',NULL);
INSERT INTO "Japanize" VALUES('TanUmaban3','�P�n��3',NULL);
INSERT INTO "Japanize" VALUES('TanshouHaitoukin3','�P���z����3',NULL);
INSERT INTO "Japanize" VALUES('FukuUmaban1','���n��1',NULL);
INSERT INTO "Japanize" VALUES('FukushouHaitoukin1','�����z����1',NULL);
INSERT INTO "Japanize" VALUES('FukuUmaban2','���n��2',NULL);
INSERT INTO "Japanize" VALUES('FukushouHaitoukin2','�����z����2',NULL);
INSERT INTO "Japanize" VALUES('FukuUmaban3','���n��3',NULL);
INSERT INTO "Japanize" VALUES('FukushouHaitoukin3','�����z����3',NULL);
INSERT INTO "Japanize" VALUES('FukuUmaban4','���n��4',NULL);
INSERT INTO "Japanize" VALUES('FukushouHaitoukin4','�����z����4',NULL);
INSERT INTO "Japanize" VALUES('FukuUmaban5','���n��5',NULL);
INSERT INTO "Japanize" VALUES('FukushouHaitoukin5','�����z����5',NULL);
INSERT INTO "Japanize" VALUES('Wakuren11','�g�A1-1',NULL);
INSERT INTO "Japanize" VALUES('Wakuren12','�g�A1-2',NULL);
INSERT INTO "Japanize" VALUES('WakurenHaitoukin1','�g�A�z����1',NULL);
INSERT INTO "Japanize" VALUES('WakurenNinki1','�g�A�l�C1',NULL);
INSERT INTO "Japanize" VALUES('Wakuren21','�g�A2-1',NULL);
INSERT INTO "Japanize" VALUES('Wakuren22','�g�A2-2',NULL);
INSERT INTO "Japanize" VALUES('WakurenHaitoukin2','�g�A�z����2',NULL);
INSERT INTO "Japanize" VALUES('WakurenNinki2','�g�A�l�C2',NULL);
INSERT INTO "Japanize" VALUES('Wakuren31','�g�A3-1',NULL);
INSERT INTO "Japanize" VALUES('Wakuren32','�g�A3-2',NULL);
INSERT INTO "Japanize" VALUES('WakurenHaitoukin3','�g�A�z����3',NULL);
INSERT INTO "Japanize" VALUES('WakurenNinki3','�g�A�l�C3',NULL);
INSERT INTO "Japanize" VALUES('Umaren11','�n�A1-1',NULL);
INSERT INTO "Japanize" VALUES('Umaren12','�n�A1-2',NULL);
INSERT INTO "Japanize" VALUES('UmarenHaitoukin1','�n�A�z����1',NULL);
INSERT INTO "Japanize" VALUES('UmarenNinki1','�n�A�l�C1',NULL);
INSERT INTO "Japanize" VALUES('Umaren21','�n�A2-1',NULL);
INSERT INTO "Japanize" VALUES('Umaren22','�n�A2-2',NULL);
INSERT INTO "Japanize" VALUES('UmarenHaitoukin2','�n�A�z����2',NULL);
INSERT INTO "Japanize" VALUES('UmarenNinki2','�n�A�l�C2',NULL);
INSERT INTO "Japanize" VALUES('Umaren31','�n�A3-1',NULL);
INSERT INTO "Japanize" VALUES('Umaren32','�n�A3-2',NULL);
INSERT INTO "Japanize" VALUES('UmarenHaitoukin3','�n�A�z����3',NULL);
INSERT INTO "Japanize" VALUES('UmarenNinki3','�n�A�l�C3',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren11','���C�h�n�A1-1',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren12','���C�h�n�A1-2',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenHaitoukin1','���C�h�n�A�z����1',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenNinki1','���C�h�n�A�l�C1',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren21','���C�h�n�A2-1',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren22','���C�h�n�A2-2',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenHaitoukin2','���C�h�n�A�z����2',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenNinki2','���C�h�n�A�l�C2',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren31','���C�h�n�A3-1',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren32','���C�h�n�A3-2',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenHaitoukin3','���C�h�n�A�z����3',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenNinki3','���C�h�n�A�l�C3',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren41','���C�h�n�A4-1',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren42','���C�h�n�A4-2',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenHaitoukin4','���C�h�n�A�z����4',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenNinki4','���C�h�n�A�l�C4',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren51','���C�h�n�A5-1',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren52','���C�h�n�A5-2',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenHaitoukin5','���C�h�n�A�z����5',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenNinki5','���C�h�n�A�l�C5',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren61','���C�h�n�A6-1',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren62','���C�h�n�A6-2',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenHaitoukin6','���C�h�n�A�z����6',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenNinki6','���C�h�n�A�l�C6',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren71','���C�h�n�A7-1',NULL);
INSERT INTO "Japanize" VALUES('WideUmaren72','���C�h�n�A7-2',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenHaitoukin7','���C�h�n�A�z����7',NULL);
INSERT INTO "Japanize" VALUES('WideUmarenNinki7','���C�h�n�A�l�C7',NULL);
INSERT INTO "Japanize" VALUES('Umatan11','�n�P1-1',NULL);
INSERT INTO "Japanize" VALUES('Umatan12','�n�P1-2',NULL);
INSERT INTO "Japanize" VALUES('UmatanHaitoukin1','�n�P�z����1',NULL);
INSERT INTO "Japanize" VALUES('UmatanNinki1','�n�P�l�C1',NULL);
INSERT INTO "Japanize" VALUES('Umatan21','�n�P2-1',NULL);
INSERT INTO "Japanize" VALUES('Umatan22','�n�P2-2',NULL);
INSERT INTO "Japanize" VALUES('UmatanHaitoukin2','�n�P�z����2',NULL);
INSERT INTO "Japanize" VALUES('UmatanNinki2','�n�P�l�C2',NULL);
INSERT INTO "Japanize" VALUES('Umatan31','�n�P3-1',NULL);
INSERT INTO "Japanize" VALUES('Umatan32','�n�P3-2',NULL);
INSERT INTO "Japanize" VALUES('UmatanHaitoukin3','�n�P�z����3',NULL);
INSERT INTO "Japanize" VALUES('UmatanNinki3','�n�P�l�C3',NULL);
INSERT INTO "Japanize" VALUES('Umatan41','�n�P4-1',NULL);
INSERT INTO "Japanize" VALUES('Umatan42','�n�P4-2',NULL);
INSERT INTO "Japanize" VALUES('UmatanHaitoukin4','�n�P�z����4',NULL);
INSERT INTO "Japanize" VALUES('UmatanNinki4','�n�P�l�C4',NULL);
INSERT INTO "Japanize" VALUES('Umatan51','�n�P5-1',NULL);
INSERT INTO "Japanize" VALUES('Umatan52','�n�P5-2',NULL);
INSERT INTO "Japanize" VALUES('UmatanHaitoukin5','�n�P�z����5',NULL);
INSERT INTO "Japanize" VALUES('UmatanNinki5','�n�P�l�C5',NULL);
INSERT INTO "Japanize" VALUES('Umatan61','�n�P6-1',NULL);
INSERT INTO "Japanize" VALUES('Umatan62','�n�P6-2',NULL);
INSERT INTO "Japanize" VALUES('UmatanHaitoukin6','�n�P�z����6',NULL);
INSERT INTO "Japanize" VALUES('UmatanNinki6','�n�P�l�C6',NULL);
INSERT INTO "Japanize" VALUES('Sanrenpuku11','3�A��1-1',NULL);
INSERT INTO "Japanize" VALUES('Sanrenpuku12','3�A��1-2',NULL);
INSERT INTO "Japanize" VALUES('Sanrenpuku13','3�A��1-3',NULL);
INSERT INTO "Japanize" VALUES('SanrenpukuHaitoukin1','3�A���z����1',NULL);
INSERT INTO "Japanize" VALUES('SanrenpukuNinki1','3�A���l�C1',NULL);
INSERT INTO "Japanize" VALUES('Sanrenpuku21','3�A��2-1',NULL);
INSERT INTO "Japanize" VALUES('Sanrenpuku22','3�A��2-2',NULL);
INSERT INTO "Japanize" VALUES('Sanrenpuku23','3�A��2-3',NULL);
INSERT INTO "Japanize" VALUES('SanrenpukuHaitoukin2','3�A���z����2',NULL);
INSERT INTO "Japanize" VALUES('SanrenpukuNinki2','3�A���l�C2',NULL);
INSERT INTO "Japanize" VALUES('Sanrenpuku31','3�A��3-1',NULL);
INSERT INTO "Japanize" VALUES('Sanrenpuku32','3�A��3-2',NULL);
INSERT INTO "Japanize" VALUES('Sanrenpuku33','3�A��3-3',NULL);
INSERT INTO "Japanize" VALUES('SanrenpukuHaitoukin3','3�A���z����3',NULL);
INSERT INTO "Japanize" VALUES('SanrenpukuNinki3','3�A���l�C3',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan11','3�A�P1-1',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan12','3�A�P1-2',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan13','3�A�P1-3',NULL);
INSERT INTO "Japanize" VALUES('SanrentanHaitoukin1','3�A�P�z����1',NULL);
INSERT INTO "Japanize" VALUES('SanrentanNinki1','3�A�P�l�C1',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan21','3�A�P2-1',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan22','3�A�P2-2',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan23','3�A�P2-3',NULL);
INSERT INTO "Japanize" VALUES('SanrentanHaitoukin2','3�A�P�z����2',NULL);
INSERT INTO "Japanize" VALUES('SanrentanNinki2','3�A�P�l�C2',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan31','3�A�P3-1',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan32','3�A�P3-2',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan33','3�A�P3-3',NULL);
INSERT INTO "Japanize" VALUES('SanrentanHaitoukin3','3�A�P�z����3',NULL);
INSERT INTO "Japanize" VALUES('SanrentanNinki3','3�A�P�l�C3',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan41','3�A�P4-1',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan42','3�A�P4-2',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan43','3�A�P4-3',NULL);
INSERT INTO "Japanize" VALUES('SanrentanHaitoukin4','3�A�P�z����4',NULL);
INSERT INTO "Japanize" VALUES('SanrentanNinki4','3�A�P�l�C4',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan51','3�A�P5-1',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan52','3�A�P5-2',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan53','3�A�P5-3',NULL);
INSERT INTO "Japanize" VALUES('SanrentanHaitoukin5','3�A�P�z����5',NULL);
INSERT INTO "Japanize" VALUES('SanrentanNinki5','3�A�P�l�C5',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan61','3�A�P6-1',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan62','3�A�P6-2',NULL);
INSERT INTO "Japanize" VALUES('Sanrentan63','3�A�P6-3',NULL);
INSERT INTO "Japanize" VALUES('SanrentanHaitoukin6','3�A�P�z����6',NULL);
INSERT INTO "Japanize" VALUES('SanrentanNinki6','3�A�P�l�C6',NULL);
INSERT INTO "Japanize" VALUES('Wakuban','�g��',NULL);
INSERT INTO "Japanize" VALUES('Umaban','�n��',NULL);
INSERT INTO "Japanize" VALUES('Gate','�Q�[�g',NULL);
INSERT INTO "Japanize" VALUES('KyousoubaId','�����nID',NULL);
INSERT INTO "Japanize" VALUES('KanaBamei','�J�i�n��',NULL);
INSERT INTO "Japanize" VALUES('UmaKigou','�n�L��','UmaKigou');
INSERT INTO "Japanize" VALUES('Seibetsu','����','Seibetsu');
INSERT INTO "Japanize" VALUES('Nenrei','�N��',NULL);
INSERT INTO "Japanize" VALUES('BanushiMei','�n�喼',NULL);
INSERT INTO "Japanize" VALUES('TanshukuBanushiMei','�Z�k�n�喼',NULL);
INSERT INTO "Japanize" VALUES('Blinker','�u�����J�[','Blinker');
INSERT INTO "Japanize" VALUES('Kinryou','�җ�',NULL);
INSERT INTO "Japanize" VALUES('Bataijuu','�n�̏d',NULL);
INSERT INTO "Japanize" VALUES('Zougen','����',NULL);
INSERT INTO "Japanize" VALUES('RecordShisuu','���R�[�h�w��',NULL);
INSERT INTO "Japanize" VALUES('KishuId','�R��ID',NULL);
INSERT INTO "Japanize" VALUES('KishuMei','�R�薼',NULL);
INSERT INTO "Japanize" VALUES('TanshukuKishuMei','�Z�k�R�薼',NULL);
INSERT INTO "Japanize" VALUES('KishuTouzaiBetsu','�R�蓌����',NULL);
INSERT INTO "Japanize" VALUES('KishuShozokuBasho','�R�菊���ꏊ','Basho');
INSERT INTO "Japanize" VALUES('KishuShozokuKyuushaId','�R�菊���X��ID',NULL);
INSERT INTO "Japanize" VALUES('MinaraiKubun','���K���敪','MinaraiKubun');
INSERT INTO "Japanize" VALUES('Norikawari','���ւ�','Norikawari');
INSERT INTO "Japanize" VALUES('KyuushaId','�X��ID',NULL);
INSERT INTO "Japanize" VALUES('KyuushaMei','�X�ɖ�',NULL);
INSERT INTO "Japanize" VALUES('TanshukuKyuushaMei','�Z�k�X�ɖ�',NULL);
INSERT INTO "Japanize" VALUES('KyuushaShozokuBasho','�X�ɏ����ꏊ','Basho');
INSERT INTO "Japanize" VALUES('KyuushaRitsuHokuNanBetsu','�X�ɌI�k���','KyuushaRitsuHokuNanBetsu');
INSERT INTO "Japanize" VALUES('YosouShirushi','�o�n�\�̗\�z��','Yosou');
INSERT INTO "Japanize" VALUES('YosouShirushiHonshi','�\�z(�{��)','Yosou');
INSERT INTO "Japanize" VALUES('Ninki','�l�C',NULL);
INSERT INTO "Japanize" VALUES('Odds','�I�b�Y',NULL);
INSERT INTO "Japanize" VALUES('KakuteiChakujun','�m�蒅��',NULL);
INSERT INTO "Japanize" VALUES('ChakujunFuka','��������','ChakujunFuka');
INSERT INTO "Japanize" VALUES('NyuusenChakujun','��������',NULL);
INSERT INTO "Japanize" VALUES('TorikeshiShubetsu','������','TorikeshiShubetsu');
INSERT INTO "Japanize" VALUES('RecordNinshiki','���R�[�h�F��','RecordFlag');
INSERT INTO "Japanize" VALUES('Time','�^�C��',NULL);
INSERT INTO "Japanize" VALUES('Chakusa1','����1',NULL);
INSERT INTO "Japanize" VALUES('Chakusa2','����2','Chakusa2');
INSERT INTO "Japanize" VALUES('TimeSa','�^�C����',NULL);
INSERT INTO "Japanize" VALUES('Zenhan3F','�O��3F',NULL);
INSERT INTO "Japanize" VALUES('Kouhan3F','�㔼3F',NULL);
INSERT INTO "Japanize" VALUES('Juni','����',NULL);
INSERT INTO "Japanize" VALUES('YonCornerIchiDori','4�p�ʒu���','YonCornerIchiDori');
INSERT INTO "Japanize" VALUES('ChoukyouFlag','�����t���O','ChoukyouFlag');
INSERT INTO "Japanize" VALUES('AwaseFlag','�����t���O','AwaseFlag');
INSERT INTO "Japanize" VALUES('Awase','����',NULL);
INSERT INTO "Japanize" VALUES('Tanpyou','�Z�]',NULL);
INSERT INTO "Japanize" VALUES('HonsuuCourse','�{���R�[�X',NULL);
INSERT INTO "Japanize" VALUES('HonsuuHanro','�{����H',NULL);
INSERT INTO "Japanize" VALUES('HonsuuPool','�{���v�[��',NULL);
INSERT INTO "Japanize" VALUES('Rating','���C�e�B���O',NULL);
INSERT INTO "Japanize" VALUES('KyuuyouRiyuu','�x�{���R',NULL);
INSERT INTO "Japanize" VALUES('Kijousha','�R���',NULL);
INSERT INTO "Japanize" VALUES('Basho','�ꏊ',NULL);
INSERT INTO "Japanize" VALUES('ChoukyouCourse','�R�[�X',NULL);
INSERT INTO "Japanize" VALUES('ChoukyouBaba','�n��',NULL);
INSERT INTO "Japanize" VALUES('Kaisuu','��',NULL);
INSERT INTO "Japanize" VALUES('IchiDori','�ʒu���',NULL);
INSERT INTO "Japanize" VALUES('Ashiiro','�r�F',NULL);
INSERT INTO "Japanize" VALUES('Yajirushi','�������','Yajirushi');
INSERT INTO "Japanize" VALUES('Reigai','��O',NULL);
INSERT INTO "Japanize" VALUES('Seinen','���N',NULL);
INSERT INTO "Japanize" VALUES('F','�n����',NULL);
INSERT INTO "Japanize" VALUES('Comment','�R�����g',NULL);
INSERT INTO "Japanize" VALUES('Ichi','�ʒu','Ichi');
INSERT INTO "Japanize" VALUES('Joukyou','��','Joukyou');
INSERT INTO "Japanize" VALUES('FuriByousuu','�s���b��',NULL);
INSERT INTO "Japanize" VALUES('Shisuu','�w��',NULL);
INSERT INTO "Japanize" VALUES('Tate','�c',NULL);
INSERT INTO "Japanize" VALUES('Yoko','��',NULL);
INSERT INTO "Japanize" VALUES('Keiro','�ѐF','Keiro');
INSERT INTO "Japanize" VALUES('Kesshu','����','Kesshu');
INSERT INTO "Japanize" VALUES('Sanchi','�Y�n','Sanchi');
INSERT INTO "Japanize" VALUES('ChichiUmaId','���nID',NULL);
INSERT INTO "Japanize" VALUES('ChichiUmaMei','���n��',NULL);
INSERT INTO "Japanize" VALUES('HahaUmaId','��nID',NULL);
INSERT INTO "Japanize" VALUES('HahaUmaMei','��n��',NULL);
INSERT INTO "Japanize" VALUES('HahaChichiUmaId','�ꕃ�nID',NULL);
INSERT INTO "Japanize" VALUES('HahaChichiUmaMei','�ꕃ�n',NULL);
INSERT INTO "Japanize" VALUES('HahaHahaUmaId','���nID',NULL);
INSERT INTO "Japanize" VALUES('HahaHahaUmaMei','���n��',NULL);
INSERT INTO "Japanize" VALUES('SeisanshaMei','���Y�Җ�',NULL);
INSERT INTO "Japanize" VALUES('TanshukuSeisanshaMei','�Z�k���Y�Җ�',NULL);
INSERT INTO "Japanize" VALUES('KoueiGaikokuKyuushaMei','���c�O���X�ɖ�',NULL);
INSERT INTO "Japanize" VALUES('MasshouFlag','�����t���O','MasshouFlag');
INSERT INTO "Japanize" VALUES('MasshouNengappi','�����N����',NULL);
INSERT INTO "Japanize" VALUES('Jiyuu','���R',NULL);
INSERT INTO "Japanize" VALUES('Ikisaki','�s��',NULL);
INSERT INTO "Japanize" VALUES('Furigana','�t���K�i',NULL);
INSERT INTO "Japanize" VALUES('Seinengappi','���N����',NULL);
INSERT INTO "Japanize" VALUES('HatsuMenkyoNen','���Ƌ��N',NULL);
INSERT INTO "Japanize" VALUES('KishuShikakuKubun','�R�掑�i�敪',NULL);
INSERT INTO "Japanize" VALUES('TourokuMasshouFlag','�o�^�����t���O',NULL);
INSERT INTO "Japanize" VALUES('ShutsubahyouSakuseiNengappi','�o�n�\�쐬�N����',NULL);
INSERT INTO "Japanize" VALUES('SeisekiSakuseiNengappi','���э쐬�N����',NULL);
INSERT INTO "Japanize" VALUES('DataSakuseiNengappi','�f�[�^�쐬�N����',NULL);
INSERT INTO "Japanize" VALUES('ChichiKyoriTekisei','�������K��','KyoriTekisei');
INSERT INTO "Japanize" VALUES('HirabaOmoKousetsu','����d�I��','Kousetsu');
INSERT INTO "Japanize" VALUES('HirabaDirtKousetsu','����_�[�g�I��','Kousetsu');
INSERT INTO "Japanize" VALUES('ShougaiOmoKousetsu','��Q�d�I��','Kousetsu');
INSERT INTO "Japanize" VALUES('ShougaiDirtKousetsu','��Q�_�[�g�I��','Kousetsu');
INSERT INTO "Japanize" VALUES('Oikiri','�ǐ؂�','Oikiri');
INSERT INTO "Japanize" VALUES('KyuushaTouzaiBetsu','�X�ɓ�����','KyuushaTouzaiBetsu');
INSERT INTO "Japanize" VALUES('Bangou','�ԍ�',NULL);
INSERT INTO "Japanize" VALUES('KyuuBamei','���n��',NULL);

CREATE TABLE UserSQL(
	Domain TEXT NOT NULL
	,Name TEXT NOT NULL
	,SQL TEXT NOT NULL
	,DetailColNames TEXT
	,ParamColNames TEXT
	,ListColNames TEXT
	,Editable INT NOT NULL DEFAULT 1
	,PRIMARY KEY(Domain, Name)
);
INSERT INTO "UserSQL" VALUES(
'Race',
'���[�X����(�W��)',
'SELECT
    *
FROM
    Shussouba
WHERE
    RaceId = /* Id */0
ORDER BY
    KakuteiChakujun,
    Umaban
',
'Nengappi,RaceBangou,TokubetsuMei,Grade,JoukenNenreiSeigen,Jouken1,BetteiBareiHandi,JoukenFuka1,JoukenFuka2,DirtShiba,Kyori',
'Id',
'KakuteiChakujun,Wakuban,Umaban,KanaBamei,Seibetsu,Nenrei,Kinryou,TanshukuKishuMei,Time,Chakusa1,Chakusa2,Zenhan3F,Kouhan3F,Odds,Ninki,Bataijuu,Zougen,TanshukuKyuushaMei'
,0);
INSERT INTO "UserSQL" VALUES(
'Shussouba',
'����',
'SELECT
	Oikiri,
	Kijousha,
	Nengappi,
	Basho,
	ChoukyouCourse,
	ChoukyouBaba,
	Kaisuu,
	IchiDori,
	Ashiiro,
	Yajirushi,
	Reigai,
	Awase,
	F,
	Time
FROM
	Choukyou c
	INNER JOIN ChoukyouRireki r ON c.Id = r.ChoukyouId
	INNER JOIN ChoukyouTime t ON r.Id = t.ChoukyouRirekiId
WHERE
	c.Id = /* Id */0
AND
	Time IS NOT NULL
ORDER BY
	Nengappi,
	F
',
'',
'Id',
'Oikiri,Kijousha,Nengappi,Basho,ChoukyouCourse,ChoukyouBaba,Kaisuu,IchiDori,Ashiiro,Yajirushi,Reigai,Awase,F,Time',
0);
INSERT INTO "UserSQL" VALUES(
'Shussouba',
'������',
'SELECT
	r.HassouJoukyou,
	r.Ichi,
	r.Joukyou,
	r.FuriByousuu,
	k.ShussoubaId / 100 AS Umaban
FROM
	RaceHassouJoukyou r
	INNER JOIN ShussoubaHassouJoukyou k ON r.Id = k.RaceHassouJoukyouId
WHERE
	k.ShussoubaId = /* Id */0
ORDER BY
	r.Ichi,
	k.ShussoubaId
',
'',
'Id',
'Ichi,Joukyou,FuriByousuu',
0);
INSERT INTO "UserSQL" VALUES(
'Shussouba',
'�o��',
'SELECT
	r.Midashi1,
	r.Midashi2,
	k.Tate,
	k.Yoko
FROM
	RaceKeika r
	INNER JOIN ShussoubaKeika k ON r.Id = k.RaceKeikaId
WHERE
	k.ShussoubaId = /* Id */0
ORDER BY
	r.Id
',
'',
'Id',
'Tate,Yoko',
0);
INSERT INTO "UserSQL" VALUES(
'TekichuuRace',
'�S���[�X',
'SELECT
	Id
FROM
	Race
',
'',
'',
'Id',
0);
INSERT INTO "UserSQL" VALUES(
'TekichuuShussouba',
'�l�C��',
'SELECT
	Umaban,
	Wakuban
FROM
	Shussouba
WHERE
    RaceId = /* Id */0
ORDER BY
    Ninki
',
'',
'Id',
'Umaban',
0);
INSERT INTO 'UserSQL' VALUES('PreImport','UQ_Race','DROP INDEX IF EXISTS UQ_Race',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','UQ_RaceLapTime','DROP INDEX IF EXISTS UQ_RaceLapTime',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','UQ_RaceKeika','DROP INDEX IF EXISTS UQ_RaceKeika',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_RaceHassouJoukyou','DROP INDEX IF EXISTS IX_RaceHassouJoukyou',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','UQ_Shussouba','DROP INDEX IF EXISTS UQ_Shussouba',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_Shussouba01','DROP INDEX IF EXISTS IX_Shussouba01',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_Shussouba02','DROP INDEX IF EXISTS IX_Shussouba02',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_Shussouba03','DROP INDEX IF EXISTS IX_Shussouba03',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_Shussouba04','DROP INDEX IF EXISTS IX_Shussouba04',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_Shussouba05','DROP INDEX IF EXISTS IX_Shussouba05',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_Shussouba06','DROP INDEX IF EXISTS IX_Shussouba06',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_Shussouba07','DROP INDEX IF EXISTS IX_Shussouba07',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_Choukyou','DROP INDEX IF EXISTS IX_Choukyou',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_ChoukyouRireki','DROP INDEX IF EXISTS IX_ChoukyouRireki',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','UQ_ChoukyouTime','DROP INDEX IF EXISTS UQ_ChoukyouTime',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','UQ_ShussoubaTsuukaJuni','DROP INDEX IF EXISTS UQ_ShussoubaTsuukaJuni',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_ShussoubaKeika01','DROP INDEX IF EXISTS IX_ShussoubaKeika01',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_ShussoubaKeika02','DROP INDEX IF EXISTS IX_ShussoubaKeika02',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_ShussoubaHassouJoukyou01','DROP INDEX IF EXISTS IX_ShussoubaHassouJoukyou01',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PreImport','IX_ShussoubaHassouJoukyou02','DROP INDEX IF EXISTS IX_ShussoubaHassouJoukyou02',NULL,NULL,NULL,0);

INSERT INTO 'UserSQL' VALUES('PostImport','UQ_Race','CREATE INDEX UQ_Race ON Race(Nengappi, KaisaiBasho, RaceBangou)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','UQ_RaceLapTime','CREATE UNIQUE INDEX UQ_RaceLapTime ON RaceLapTime(RaceId, Bangou)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','UQ_RaceKeika','CREATE UNIQUE INDEX UQ_RaceKeika ON RaceKeika(RaceId, Bangou)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_RaceHassouJoukyou','CREATE INDEX IX_RaceHassouJoukyou ON RaceHassouJoukyou(RaceId)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','UQ_Shussouba','CREATE UNIQUE INDEX UQ_Shussouba ON Shussouba(RaceId, Umaban)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_Shussouba01','CREATE INDEX IX_Shussouba01 ON Shussouba(Time)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_Shussouba02','CREATE INDEX IX_Shussouba02 ON Shussouba(Zenhan3F)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_Shussouba03','CREATE INDEX IX_Shussouba03 ON Shussouba(Kouhan3F)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_Shussouba04','CREATE INDEX IX_Shussouba04 ON Shussouba(KyousoubaId)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_Shussouba05','CREATE INDEX IX_Shussouba05 ON Shussouba(KanaBamei)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_Shussouba06','CREATE INDEX IX_Shussouba06 ON Shussouba(KishuId)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_Shussouba07','CREATE INDEX IX_Shussouba07 ON Shussouba(KyuushaId)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_Choukyou','CREATE INDEX IX_Choukyou ON Choukyou(KyousoubaId)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_ChoukyouRireki','CREATE INDEX IX_ChoukyouRireki ON ChoukyouRireki(ChoukyouId)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','UQ_ChoukyouTime','CREATE INDEX UQ_ChoukyouTime ON ChoukyouTime(ChoukyouRirekiId, F)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','UQ_ShussoubaTsuukaJuni','CREATE INDEX UQ_ShussoubaTsuukaJuni ON ShussoubaTsuukaJuni(ShussoubaId, Bangou)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_ShussoubaKeika01','CREATE INDEX IX_ShussoubaKeika01 ON ShussoubaKeika(RaceKeikaId)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_ShussoubaKeika02','CREATE INDEX IX_ShussoubaKeika02 ON ShussoubaKeika(ShussoubaId)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_ShussoubaHassouJoukyou01','CREATE INDEX IX_ShussoubaHassouJoukyou01 ON ShussoubaHassouJoukyou(RaceHassouJoukyouId)',NULL,NULL,NULL,0);
INSERT INTO 'UserSQL' VALUES('PostImport','IX_ShussoubaHassouJoukyou02','CREATE INDEX IX_ShussoubaHassouJoukyou02 ON ShussoubaHassouJoukyou(ShussoubaId)',NULL,NULL,NULL,0);

INSERT INTO 'UserSQL' VALUES(
'PostImport',
'Kishu',
'INSERT OR REPLACE INTO Kishu
(
  Id,
  KishuMei,
  TanshukuKishuMei,
  KishuTouzaiBetsu,
  KishuShozokuBasho,
  KishuShozokuKyuushaId,
  MinaraiKubun,
  DataSakuseiNengappi
)
SELECT
  S.KishuId,
  S.KishuMei,
  S.TanshukuKishuMei,
  S.KishuTouzaiBetsu,
  S.KishuShozokuBasho,
  S.KishuShozokuKyuushaId,
  S.MinaraiKubun,
  IFNULL(S.SeisekiSakuseiNengappi, S.ShutsubahyouSakuseiNengappi)
FROM
  Shussouba S
  INNER JOIN
  (
    SELECT
    KishuId,
      MAX(Id % 1000000000000) AS Id2
    FROM
      Shussouba
    GROUP BY
      KishuId
  ) S2 ON S.KishuId = S2.KishuId AND (S.Id % 1000000000000) = S2.Id2
WHERE
  NOT EXISTS(
    SELECT
    *
  FROM
    Kishu
  WHERE
    Id = S.KishuId
  )
OR
  EXISTS(
    SELECT
    *
  FROM
    Kishu K
  WHERE
    Id = S.KishuId
  AND
    (
      K.KishuMei <> S.KishuMei
    OR
      K.TanshukuKishuMei <> S.TanshukuKishuMei
      OR
      K.KishuTouzaiBetsu <> S.KishuTouzaiBetsu
    OR
      K.KishuShozokuBasho <> S.KishuShozokuBasho
    OR
      K.KishuShozokuKyuushaId <> S.KishuShozokuKyuushaId
      OR
        K.MinaraiKubun <> S.MinaraiKubun
      )
  )
',
NULL,
NULL,
NULL,
0
);

INSERT INTO 'UserSQL' VALUES(
'PostImport',
'Kyuusha',
'INSERT OR REPLACE INTO Kyuusha
(
  Id,
  KyuushaMei,
  TanshukuKyuushaMei,
  KyuushaShozokuBasho,
  KyuushaRitsuHokuNanBetsu,
  DataSakuseiNengappi
)
SELECT
  S.KyuushaId,
  S.KyuushaMei,
  S.TanshukuKyuushaMei,
  S.KyuushaShozokuBasho,
  S.KyuushaRitsuHokuNanBetsu,
  IFNULL(S.SeisekiSakuseiNengappi, S.ShutsubahyouSakuseiNengappi)
FROM
  Shussouba S
  INNER JOIN
  (
    SELECT
    KyuushaId,
      MAX(Id % 1000000000000) AS Id2
    FROM
      Shussouba
    GROUP BY
      KyuushaId
  ) S2 ON S.KyuushaId = S2.KyuushaId AND (S.Id % 1000000000000) = S2.Id2
WHERE
  NOT EXISTS(
    SELECT
    *
  FROM
    Kyuusha
  WHERE
    Id = S.KyuushaId
  )
OR
  EXISTS(
    SELECT
    *
  FROM
    Kyuusha K
  WHERE
    Id = S.KyuushaId
  AND
    (
      K.KyuushaMei <> S.KyuushaMei
    OR
      K.TanshukuKyuushaMei <> S.TanshukuKyuushaMei
      OR
      K.KyuushaShozokuBasho <> S.KyuushaShozokuBasho
    OR
      K.KyuushaRitsuHokuNanBetsu <> S.KyuushaRitsuHokuNanBetsu
      )
  )
',
NULL,
NULL,
NULL,
0
);

CREATE VIEW ChoukyouYodo AS
SELECT
  c.*,
  r.*,
  c1.Time AS ChoukyouTime1F,
  c2.Time AS ChoukyouTime2F,
  c3.Time AS ChoukyouTime3F,
  c4.Time AS ChoukyouTime4F,
  c5.Time AS ChoukyouTime5F,
  c6.Time AS ChoukyouTime6F,
  c7.Time AS ChoukyouTime7F,
  c8.Time AS ChoukyouTime8F,
  COALESCE(ht1.TanshouHaitoukin1, ht2.TanshouHaitoukin2, ht3.TanshouHaitoukin3) AS TanshouHaitoukin,
  COALESCE(hf1.FukushouHaitoukin1, hf2.FukushouHaitoukin2, hf3.FukushouHaitoukin3, hf4.FukushouHaitoukin4, hf5.FukushouHaitoukin5) AS FukushouHaitoukin  
FROM
  Shussouba sk
  INNER JOIN Choukyou c ON sk.Id = c.Id
  INNER JOIN ChoukyouRireki r ON c.Id = r.ChoukyouId
  LEFT OUTER JOIN ChoukyouTime c1 ON r.Id = c1.ChoukyouRirekiId AND c1.F = 1
  LEFT OUTER JOIN ChoukyouTime c2 ON r.Id = c2.ChoukyouRirekiId AND c2.F = 2
  LEFT OUTER JOIN ChoukyouTime c3 ON r.Id = c3.ChoukyouRirekiId AND c3.F = 3
  LEFT OUTER JOIN ChoukyouTime c4 ON r.Id = c4.ChoukyouRirekiId AND c4.F = 4
  LEFT OUTER JOIN ChoukyouTime c5 ON r.Id = c5.ChoukyouRirekiId AND c5.F = 5
  LEFT OUTER JOIN ChoukyouTime c6 ON r.Id = c6.ChoukyouRirekiId AND c6.F = 6
  LEFT OUTER JOIN ChoukyouTime c7 ON r.Id = c7.ChoukyouRirekiId AND c7.F = 7
  LEFT OUTER JOIN ChoukyouTime c8 ON r.Id = c8.ChoukyouRirekiId AND c8.F = 8
  LEFT OUTER JOIN RaceHaitou ht1 ON sk.RaceId = ht1.Id AND ht1.TanUmaban1 = sk.Umaban
  LEFT OUTER JOIN RaceHaitou ht2 ON sk.RaceId = ht2.Id AND ht2.TanUmaban2 = sk.Umaban
  LEFT OUTER JOIN RaceHaitou ht3 ON sk.RaceId = ht3.Id AND ht3.TanUmaban3 = sk.Umaban
  LEFT OUTER JOIN RaceHaitou hf1 ON sk.RaceId = hf1.Id AND hf1.FukuUmaban1 = sk.Umaban
  LEFT OUTER JOIN RaceHaitou hf2 ON sk.RaceId = hf2.Id AND hf2.FukuUmaban2 = sk.Umaban
  LEFT OUTER JOIN RaceHaitou hf3 ON sk.RaceId = hf3.Id AND hf3.FukuUmaban3 = sk.Umaban
  LEFT OUTER JOIN RaceHaitou hf4 ON sk.RaceId = hf4.Id AND hf4.FukuUmaban4 = sk.Umaban
  LEFT OUTER JOIN RaceHaitou hf5 ON sk.RaceId = hf5.Id AND hf5.FukuUmaban5 = sk.Umaban
;

CREATE TABLE RaceFuka(
  Id BIGINT NOT NULL PRIMARY KEY REFERENCES Race(Id) ON DELETE CASCADE
  ,KaisaiNissuu INT
  ,CourseNissuu INT
  ,ChokusetsuTaisenTimeSaMean REAL
  ,ChokusetsuTaisenTimeSaSD REAL
  ,KansetsuTaisenTimeSaMean REAL
  ,KansetsuTaisenTimeSaSD REAL
);

CREATE TABLE ShussoubaFuka(
  Id BIGINT NOT NULL PRIMARY KEY REFERENCES Shussouba(Id) ON DELETE CASCADE
  ,RaceId BIGINT NOT NULL REFERENCES RaceFuka(Id) ON DELETE CASCADE
  ,KyousoubaId TEXT NOT NULL
  ,DeokureByousuu REAL
  ,FuriByousuu REAL
  ,ShussouKaisuu INT
  ,DeokureKaisuu INT
  ,RaceKankaku INT
  ,BlinkerHenka INT
  ,Zenhan3FTimeSa REAL
  ,Kouhan3FMadeTimeSa REAL
  ,Kouhan3FTimeSa REAL
  ,DeokureKakuritsu REAL
  ,KakoZenhan3FTimeSa REAL
  ,KakoKouhan3FMadeTimeSa REAL
  ,KakoKouhan3FTimeSa REAL
  ,KakoTimeSa REAL
  ,ChokusetsuTaisenTimeSa REAL
  ,KansetsuTaisenTimeSa REAL
);
CREATE INDEX IX_ShussoubaFuka01 ON ShussoubaFuka(RaceId);
CREATE INDEX IX_ShussoubaFuka02 ON ShussoubaFuka(KyousoubaId);

CREATE TABLE TaisenSeiseki(
  KyousoubaId BIGINT NOT NULL REFERENCES Kyousouba(Id) ON DELETE CASCADE
  ,AiteKyousoubaId TEXT NOT NULL
  ,Chakusa NOT NULL
  ,PRIMARY KEY(KyousoubaId, AiteKyousoubaId)
);
CREATE INDEX IX_TaisenSeiseki01 ON TaisenSeiseki(KyousoubaId);
CREATE INDEX IX_TaisenSeiseki02 ON TaisenSeiseki(AiteKyousoubaId);
