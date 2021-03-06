using System;
using Soma.Core;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Model 
{
    public partial class Race
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "KaisaiBasho", IsEnclosed = false)]
        public Int32 KaisaiBasho { get; set; }
        [Column(Name = "KaisaiNen", IsEnclosed = false)]
        public Int32 KaisaiNen { get; set; }
        [Column(Name = "KaisaiKaiji", IsEnclosed = false)]
        public Int32 KaisaiKaiji { get; set; }
        [Column(Name = "KaisaiNichiji", IsEnclosed = false)]
        public Int32 KaisaiNichiji { get; set; }
        [Column(Name = "RaceBangou", IsEnclosed = false)]
        public Int32 RaceBangou { get; set; }
        [Column(Name = "Nengappi", IsEnclosed = false)]
        public DateTime Nengappi { get; set; }
        [Column(Name = "Kyuujitsu", IsEnclosed = false)]
        public Int32 Kyuujitsu { get; set; }
        [Column(Name = "Youbi", IsEnclosed = false)]
        public Int32 Youbi { get; set; }
        [Column(Name = "KouryuuFlag", IsEnclosed = false)]
        public Int32? KouryuuFlag { get; set; }
        [Column(Name = "ChuuouChihouGaikoku", IsEnclosed = false)]
        public Int32 ChuuouChihouGaikoku { get; set; }
        [Column(Name = "IppanTokubetsu", IsEnclosed = false)]
        public Int32 IppanTokubetsu { get; set; }
        [Column(Name = "HeichiShougai", IsEnclosed = false)]
        public Int32 HeichiShougai { get; set; }
        [Column(Name = "JuushouKaisuu", IsEnclosed = false)]
        public Int32? JuushouKaisuu { get; set; }
        [Column(Name = "TokubetsuMei", IsEnclosed = false)]
        public String TokubetsuMei { get; set; }
        [Column(Name = "TanshukuTokubetsuMei", IsEnclosed = false)]
        public String TanshukuTokubetsuMei { get; set; }
        [Column(Name = "Grade", IsEnclosed = false)]
        public Int32? Grade { get; set; }
        [Column(Name = "JpnFlag", IsEnclosed = false)]
        public Int32? JpnFlag { get; set; }
        [Column(Name = "BetteiBareiHandi", IsEnclosed = false)]
        public Int32? BetteiBareiHandi { get; set; }
        [Column(Name = "BetteiBareiHandiShousai", IsEnclosed = false)]
        public String BetteiBareiHandiShousai { get; set; }
        [Column(Name = "JoukenFuka1", IsEnclosed = false)]
        public Int32? JoukenFuka1 { get; set; }
        [Column(Name = "JoukenFuka2", IsEnclosed = false)]
        public Int32? JoukenFuka2 { get; set; }
        [Column(Name = "JoukenKei", IsEnclosed = false)]
        public Int32 JoukenKei { get; set; }
        [Column(Name = "JoukenNenreiSeigen", IsEnclosed = false)]
        public Int32 JoukenNenreiSeigen { get; set; }
        [Column(Name = "Jouken1", IsEnclosed = false)]
        public Int32? Jouken1 { get; set; }
        [Column(Name = "Kumi1", IsEnclosed = false)]
        public Int32? Kumi1 { get; set; }
        [Column(Name = "IjouIkaMiman", IsEnclosed = false)]
        public Int32? IjouIkaMiman { get; set; }
        [Column(Name = "Jouken2", IsEnclosed = false)]
        public Int32? Jouken2 { get; set; }
        [Column(Name = "Kumi2", IsEnclosed = false)]
        public Int32? Kumi2 { get; set; }
        [Column(Name = "DirtShiba", IsEnclosed = false)]
        public Int32 DirtShiba { get; set; }
        [Column(Name = "MigiHidari", IsEnclosed = false)]
        public Int32 MigiHidari { get; set; }
        [Column(Name = "UchiSoto", IsEnclosed = false)]
        public Int32? UchiSoto { get; set; }
        [Column(Name = "Course", IsEnclosed = false)]
        public Int32? Course { get; set; }
        [Column(Name = "Kyori", IsEnclosed = false)]
        public Int32 Kyori { get; set; }
        [Column(Name = "CourseRecordFlag", IsEnclosed = false)]
        public Int32? CourseRecordFlag { get; set; }
        [Column(Name = "CourseRecordNengappi", IsEnclosed = false)]
        public DateTime? CourseRecordNengappi { get; set; }
        [Column(Name = "CourseRecordTime", IsEnclosed = false)]
        public Double? CourseRecordTime { get; set; }
        [Column(Name = "CourseRecordBamei", IsEnclosed = false)]
        public String CourseRecordBamei { get; set; }
        [Column(Name = "CourseRecordKinryou", IsEnclosed = false)]
        public Double? CourseRecordKinryou { get; set; }
        [Column(Name = "CourseRecordTanshukuKishuMei", IsEnclosed = false)]
        public String CourseRecordTanshukuKishuMei { get; set; }
        [Column(Name = "KyoriRecordNengappi", IsEnclosed = false)]
        public DateTime? KyoriRecordNengappi { get; set; }
        [Column(Name = "KyoriRecordTime", IsEnclosed = false)]
        public Double? KyoriRecordTime { get; set; }
        [Column(Name = "KyoriRecordBamei", IsEnclosed = false)]
        public String KyoriRecordBamei { get; set; }
        [Column(Name = "KyoriRecordKinryou", IsEnclosed = false)]
        public Double? KyoriRecordKinryou { get; set; }
        [Column(Name = "KyoriRecordTanshukuKishuMei", IsEnclosed = false)]
        public String KyoriRecordTanshukuKishuMei { get; set; }
        [Column(Name = "KyoriRecordBasho", IsEnclosed = false)]
        public Int32? KyoriRecordBasho { get; set; }
        [Column(Name = "RaceRecordNengappi", IsEnclosed = false)]
        public DateTime? RaceRecordNengappi { get; set; }
        [Column(Name = "RaceRecordTime", IsEnclosed = false)]
        public Double? RaceRecordTime { get; set; }
        [Column(Name = "RaceRecordBamei", IsEnclosed = false)]
        public String RaceRecordBamei { get; set; }
        [Column(Name = "RaceRecordKinryou", IsEnclosed = false)]
        public Double? RaceRecordKinryou { get; set; }
        [Column(Name = "RaceRecordTanshukuKishuMei", IsEnclosed = false)]
        public String RaceRecordTanshukuKishuMei { get; set; }
        [Column(Name = "RaceRecordBasho", IsEnclosed = false)]
        public Int32? RaceRecordBasho { get; set; }
        [Column(Name = "Shoukin1Chaku", IsEnclosed = false)]
        public Int32? Shoukin1Chaku { get; set; }
        [Column(Name = "Shoukin2Chaku", IsEnclosed = false)]
        public Int32? Shoukin2Chaku { get; set; }
        [Column(Name = "Shoukin3Chaku", IsEnclosed = false)]
        public Int32? Shoukin3Chaku { get; set; }
        [Column(Name = "Shoukin4Chaku", IsEnclosed = false)]
        public Int32? Shoukin4Chaku { get; set; }
        [Column(Name = "Shoukin5Chaku", IsEnclosed = false)]
        public Int32? Shoukin5Chaku { get; set; }
        [Column(Name = "Shoukin5ChakuDouchaku1", IsEnclosed = false)]
        public Int32? Shoukin5ChakuDouchaku1 { get; set; }
        [Column(Name = "Shoukin5ChakuDouchaku2", IsEnclosed = false)]
        public Int32? Shoukin5ChakuDouchaku2 { get; set; }
        [Column(Name = "FukaShou", IsEnclosed = false)]
        public Int32? FukaShou { get; set; }
        [Column(Name = "MaeuriFlag", IsEnclosed = false)]
        public Int32? MaeuriFlag { get; set; }
        [Column(Name = "YoteiHassouJikan", IsEnclosed = false)]
        public String YoteiHassouJikan { get; set; }
        [Column(Name = "Tousuu", IsEnclosed = false)]
        public Int32 Tousuu { get; set; }
        [Column(Name = "TorikeshiTousuu", IsEnclosed = false)]
        public Int32 TorikeshiTousuu { get; set; }
        [Column(Name = "SuiteiTimeRyou", IsEnclosed = false)]
        public Double? SuiteiTimeRyou { get; set; }
        [Column(Name = "SuiteiTimeOmoFuryou", IsEnclosed = false)]
        public Double? SuiteiTimeOmoFuryou { get; set; }
        [Column(Name = "YosouPace", IsEnclosed = false)]
        public Int32? YosouPace { get; set; }
        [Column(Name = "Pace", IsEnclosed = false)]
        public Int32? Pace { get; set; }
        [Column(Name = "Tenki", IsEnclosed = false)]
        public Int32? Tenki { get; set; }
        [Column(Name = "Baba", IsEnclosed = false)]
        public Int32? Baba { get; set; }
        [Column(Name = "Seed", IsEnclosed = false)]
        public Int32? Seed { get; set; }
        [Column(Name = "ShougaiHeikin1F", IsEnclosed = false)]
        public Double? ShougaiHeikin1F { get; set; }
        [Column(Name = "ShutsubahyouSakuseiNengappi", IsEnclosed = false)]
        public DateTime? ShutsubahyouSakuseiNengappi { get; set; }
        [Column(Name = "SeisekiSakuseiNengappi", IsEnclosed = false)]
        public DateTime? SeisekiSakuseiNengappi { get; set; }
    }
    
    public partial class RaceLapTime
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "RaceId", IsEnclosed = false)]
        public Int64 RaceId { get; set; }
        [Column(Name = "Bangou", IsEnclosed = false)]
        public Int32 Bangou { get; set; }
        [Column(Name = "KaishiKyori", IsEnclosed = false)]
        public Int32 KaishiKyori { get; set; }
        [Column(Name = "ShuuryouKyori", IsEnclosed = false)]
        public Int32 ShuuryouKyori { get; set; }
        [Column(Name = "LapTime", IsEnclosed = false)]
        public Double LapTime { get; set; }
    }
    
    public partial class RaceHaitou
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "TanUmaban1", IsEnclosed = false)]
        public Int32? TanUmaban1 { get; set; }
        [Column(Name = "TanshouHaitoukin1", IsEnclosed = false)]
        public Int32? TanshouHaitoukin1 { get; set; }
        [Column(Name = "TanUmaban2", IsEnclosed = false)]
        public Int32? TanUmaban2 { get; set; }
        [Column(Name = "TanshouHaitoukin2", IsEnclosed = false)]
        public Int32? TanshouHaitoukin2 { get; set; }
        [Column(Name = "TanUmaban3", IsEnclosed = false)]
        public Int32? TanUmaban3 { get; set; }
        [Column(Name = "TanshouHaitoukin3", IsEnclosed = false)]
        public Int32? TanshouHaitoukin3 { get; set; }
        [Column(Name = "FukuUmaban1", IsEnclosed = false)]
        public Int32? FukuUmaban1 { get; set; }
        [Column(Name = "FukushouHaitoukin1", IsEnclosed = false)]
        public Int32? FukushouHaitoukin1 { get; set; }
        [Column(Name = "FukuUmaban2", IsEnclosed = false)]
        public Int32? FukuUmaban2 { get; set; }
        [Column(Name = "FukushouHaitoukin2", IsEnclosed = false)]
        public Int32? FukushouHaitoukin2 { get; set; }
        [Column(Name = "FukuUmaban3", IsEnclosed = false)]
        public Int32? FukuUmaban3 { get; set; }
        [Column(Name = "FukushouHaitoukin3", IsEnclosed = false)]
        public Int32? FukushouHaitoukin3 { get; set; }
        [Column(Name = "FukuUmaban4", IsEnclosed = false)]
        public Int32? FukuUmaban4 { get; set; }
        [Column(Name = "FukushouHaitoukin4", IsEnclosed = false)]
        public Int32? FukushouHaitoukin4 { get; set; }
        [Column(Name = "FukuUmaban5", IsEnclosed = false)]
        public Int32? FukuUmaban5 { get; set; }
        [Column(Name = "FukushouHaitoukin5", IsEnclosed = false)]
        public Int32? FukushouHaitoukin5 { get; set; }
        [Column(Name = "Wakuren11", IsEnclosed = false)]
        public Int32? Wakuren11 { get; set; }
        [Column(Name = "Wakuren12", IsEnclosed = false)]
        public Int32? Wakuren12 { get; set; }
        [Column(Name = "WakurenHaitoukin1", IsEnclosed = false)]
        public Int32? WakurenHaitoukin1 { get; set; }
        [Column(Name = "WakurenNinki1", IsEnclosed = false)]
        public Int32? WakurenNinki1 { get; set; }
        [Column(Name = "Wakuren21", IsEnclosed = false)]
        public Int32? Wakuren21 { get; set; }
        [Column(Name = "Wakuren22", IsEnclosed = false)]
        public Int32? Wakuren22 { get; set; }
        [Column(Name = "WakurenHaitoukin2", IsEnclosed = false)]
        public Int32? WakurenHaitoukin2 { get; set; }
        [Column(Name = "WakurenNinki2", IsEnclosed = false)]
        public Int32? WakurenNinki2 { get; set; }
        [Column(Name = "Wakuren31", IsEnclosed = false)]
        public Int32? Wakuren31 { get; set; }
        [Column(Name = "Wakuren32", IsEnclosed = false)]
        public Int32? Wakuren32 { get; set; }
        [Column(Name = "WakurenHaitoukin3", IsEnclosed = false)]
        public Int32? WakurenHaitoukin3 { get; set; }
        [Column(Name = "WakurenNinki3", IsEnclosed = false)]
        public Int32? WakurenNinki3 { get; set; }
        [Column(Name = "Umaren11", IsEnclosed = false)]
        public Int32? Umaren11 { get; set; }
        [Column(Name = "Umaren12", IsEnclosed = false)]
        public Int32? Umaren12 { get; set; }
        [Column(Name = "UmarenHaitoukin1", IsEnclosed = false)]
        public Int32? UmarenHaitoukin1 { get; set; }
        [Column(Name = "UmarenNinki1", IsEnclosed = false)]
        public Int32? UmarenNinki1 { get; set; }
        [Column(Name = "Umaren21", IsEnclosed = false)]
        public Int32? Umaren21 { get; set; }
        [Column(Name = "Umaren22", IsEnclosed = false)]
        public Int32? Umaren22 { get; set; }
        [Column(Name = "UmarenHaitoukin2", IsEnclosed = false)]
        public Int32? UmarenHaitoukin2 { get; set; }
        [Column(Name = "UmarenNinki2", IsEnclosed = false)]
        public Int32? UmarenNinki2 { get; set; }
        [Column(Name = "Umaren31", IsEnclosed = false)]
        public Int32? Umaren31 { get; set; }
        [Column(Name = "Umaren32", IsEnclosed = false)]
        public Int32? Umaren32 { get; set; }
        [Column(Name = "UmarenHaitoukin3", IsEnclosed = false)]
        public Int32? UmarenHaitoukin3 { get; set; }
        [Column(Name = "UmarenNinki3", IsEnclosed = false)]
        public Int32? UmarenNinki3 { get; set; }
        [Column(Name = "WideUmaren11", IsEnclosed = false)]
        public Int32? WideUmaren11 { get; set; }
        [Column(Name = "WideUmaren12", IsEnclosed = false)]
        public Int32? WideUmaren12 { get; set; }
        [Column(Name = "WideUmarenHaitoukin1", IsEnclosed = false)]
        public Int32? WideUmarenHaitoukin1 { get; set; }
        [Column(Name = "WideUmarenNinki1", IsEnclosed = false)]
        public Int32? WideUmarenNinki1 { get; set; }
        [Column(Name = "WideUmaren21", IsEnclosed = false)]
        public Int32? WideUmaren21 { get; set; }
        [Column(Name = "WideUmaren22", IsEnclosed = false)]
        public Int32? WideUmaren22 { get; set; }
        [Column(Name = "WideUmarenHaitoukin2", IsEnclosed = false)]
        public Int32? WideUmarenHaitoukin2 { get; set; }
        [Column(Name = "WideUmarenNinki2", IsEnclosed = false)]
        public Int32? WideUmarenNinki2 { get; set; }
        [Column(Name = "WideUmaren31", IsEnclosed = false)]
        public Int32? WideUmaren31 { get; set; }
        [Column(Name = "WideUmaren32", IsEnclosed = false)]
        public Int32? WideUmaren32 { get; set; }
        [Column(Name = "WideUmarenHaitoukin3", IsEnclosed = false)]
        public Int32? WideUmarenHaitoukin3 { get; set; }
        [Column(Name = "WideUmarenNinki3", IsEnclosed = false)]
        public Int32? WideUmarenNinki3 { get; set; }
        [Column(Name = "WideUmaren41", IsEnclosed = false)]
        public Int32? WideUmaren41 { get; set; }
        [Column(Name = "WideUmaren42", IsEnclosed = false)]
        public Int32? WideUmaren42 { get; set; }
        [Column(Name = "WideUmarenHaitoukin4", IsEnclosed = false)]
        public Int32? WideUmarenHaitoukin4 { get; set; }
        [Column(Name = "WideUmarenNinki4", IsEnclosed = false)]
        public Int32? WideUmarenNinki4 { get; set; }
        [Column(Name = "WideUmaren51", IsEnclosed = false)]
        public Int32? WideUmaren51 { get; set; }
        [Column(Name = "WideUmaren52", IsEnclosed = false)]
        public Int32? WideUmaren52 { get; set; }
        [Column(Name = "WideUmarenHaitoukin5", IsEnclosed = false)]
        public Int32? WideUmarenHaitoukin5 { get; set; }
        [Column(Name = "WideUmarenNinki5", IsEnclosed = false)]
        public Int32? WideUmarenNinki5 { get; set; }
        [Column(Name = "WideUmaren61", IsEnclosed = false)]
        public Int32? WideUmaren61 { get; set; }
        [Column(Name = "WideUmaren62", IsEnclosed = false)]
        public Int32? WideUmaren62 { get; set; }
        [Column(Name = "WideUmarenHaitoukin6", IsEnclosed = false)]
        public Int32? WideUmarenHaitoukin6 { get; set; }
        [Column(Name = "WideUmarenNinki6", IsEnclosed = false)]
        public Int32? WideUmarenNinki6 { get; set; }
        [Column(Name = "WideUmaren71", IsEnclosed = false)]
        public Int32? WideUmaren71 { get; set; }
        [Column(Name = "WideUmaren72", IsEnclosed = false)]
        public Int32? WideUmaren72 { get; set; }
        [Column(Name = "WideUmarenHaitoukin7", IsEnclosed = false)]
        public Int32? WideUmarenHaitoukin7 { get; set; }
        [Column(Name = "WideUmarenNinki7", IsEnclosed = false)]
        public Int32? WideUmarenNinki7 { get; set; }
        [Column(Name = "Umatan11", IsEnclosed = false)]
        public Int32? Umatan11 { get; set; }
        [Column(Name = "Umatan12", IsEnclosed = false)]
        public Int32? Umatan12 { get; set; }
        [Column(Name = "UmatanHaitoukin1", IsEnclosed = false)]
        public Int32? UmatanHaitoukin1 { get; set; }
        [Column(Name = "UmatanNinki1", IsEnclosed = false)]
        public Int32? UmatanNinki1 { get; set; }
        [Column(Name = "Umatan21", IsEnclosed = false)]
        public Int32? Umatan21 { get; set; }
        [Column(Name = "Umatan22", IsEnclosed = false)]
        public Int32? Umatan22 { get; set; }
        [Column(Name = "UmatanHaitoukin2", IsEnclosed = false)]
        public Int32? UmatanHaitoukin2 { get; set; }
        [Column(Name = "UmatanNinki2", IsEnclosed = false)]
        public Int32? UmatanNinki2 { get; set; }
        [Column(Name = "Umatan31", IsEnclosed = false)]
        public Int32? Umatan31 { get; set; }
        [Column(Name = "Umatan32", IsEnclosed = false)]
        public Int32? Umatan32 { get; set; }
        [Column(Name = "UmatanHaitoukin3", IsEnclosed = false)]
        public Int32? UmatanHaitoukin3 { get; set; }
        [Column(Name = "UmatanNinki3", IsEnclosed = false)]
        public Int32? UmatanNinki3 { get; set; }
        [Column(Name = "Umatan41", IsEnclosed = false)]
        public Int32? Umatan41 { get; set; }
        [Column(Name = "Umatan42", IsEnclosed = false)]
        public Int32? Umatan42 { get; set; }
        [Column(Name = "UmatanHaitoukin4", IsEnclosed = false)]
        public Int32? UmatanHaitoukin4 { get; set; }
        [Column(Name = "UmatanNinki4", IsEnclosed = false)]
        public Int32? UmatanNinki4 { get; set; }
        [Column(Name = "Umatan51", IsEnclosed = false)]
        public Int32? Umatan51 { get; set; }
        [Column(Name = "Umatan52", IsEnclosed = false)]
        public Int32? Umatan52 { get; set; }
        [Column(Name = "UmatanHaitoukin5", IsEnclosed = false)]
        public Int32? UmatanHaitoukin5 { get; set; }
        [Column(Name = "UmatanNinki5", IsEnclosed = false)]
        public Int32? UmatanNinki5 { get; set; }
        [Column(Name = "Umatan61", IsEnclosed = false)]
        public Int32? Umatan61 { get; set; }
        [Column(Name = "Umatan62", IsEnclosed = false)]
        public Int32? Umatan62 { get; set; }
        [Column(Name = "UmatanHaitoukin6", IsEnclosed = false)]
        public Int32? UmatanHaitoukin6 { get; set; }
        [Column(Name = "UmatanNinki6", IsEnclosed = false)]
        public Int32? UmatanNinki6 { get; set; }
        [Column(Name = "Sanrenpuku11", IsEnclosed = false)]
        public Int32? Sanrenpuku11 { get; set; }
        [Column(Name = "Sanrenpuku12", IsEnclosed = false)]
        public Int32? Sanrenpuku12 { get; set; }
        [Column(Name = "Sanrenpuku13", IsEnclosed = false)]
        public Int32? Sanrenpuku13 { get; set; }
        [Column(Name = "SanrenpukuHaitoukin1", IsEnclosed = false)]
        public Int32? SanrenpukuHaitoukin1 { get; set; }
        [Column(Name = "SanrenpukuNinki1", IsEnclosed = false)]
        public Int32? SanrenpukuNinki1 { get; set; }
        [Column(Name = "Sanrenpuku21", IsEnclosed = false)]
        public Int32? Sanrenpuku21 { get; set; }
        [Column(Name = "Sanrenpuku22", IsEnclosed = false)]
        public Int32? Sanrenpuku22 { get; set; }
        [Column(Name = "Sanrenpuku23", IsEnclosed = false)]
        public Int32? Sanrenpuku23 { get; set; }
        [Column(Name = "SanrenpukuHaitoukin2", IsEnclosed = false)]
        public Int32? SanrenpukuHaitoukin2 { get; set; }
        [Column(Name = "SanrenpukuNinki2", IsEnclosed = false)]
        public Int32? SanrenpukuNinki2 { get; set; }
        [Column(Name = "Sanrenpuku31", IsEnclosed = false)]
        public Int32? Sanrenpuku31 { get; set; }
        [Column(Name = "Sanrenpuku32", IsEnclosed = false)]
        public Int32? Sanrenpuku32 { get; set; }
        [Column(Name = "Sanrenpuku33", IsEnclosed = false)]
        public Int32? Sanrenpuku33 { get; set; }
        [Column(Name = "SanrenpukuHaitoukin3", IsEnclosed = false)]
        public Int32? SanrenpukuHaitoukin3 { get; set; }
        [Column(Name = "SanrenpukuNinki3", IsEnclosed = false)]
        public Int32? SanrenpukuNinki3 { get; set; }
        [Column(Name = "Sanrentan11", IsEnclosed = false)]
        public Int32? Sanrentan11 { get; set; }
        [Column(Name = "Sanrentan12", IsEnclosed = false)]
        public Int32? Sanrentan12 { get; set; }
        [Column(Name = "Sanrentan13", IsEnclosed = false)]
        public Int32? Sanrentan13 { get; set; }
        [Column(Name = "SanrentanHaitoukin1", IsEnclosed = false)]
        public Int32? SanrentanHaitoukin1 { get; set; }
        [Column(Name = "SanrentanNinki1", IsEnclosed = false)]
        public Int32? SanrentanNinki1 { get; set; }
        [Column(Name = "Sanrentan21", IsEnclosed = false)]
        public Int32? Sanrentan21 { get; set; }
        [Column(Name = "Sanrentan22", IsEnclosed = false)]
        public Int32? Sanrentan22 { get; set; }
        [Column(Name = "Sanrentan23", IsEnclosed = false)]
        public Int32? Sanrentan23 { get; set; }
        [Column(Name = "SanrentanHaitoukin2", IsEnclosed = false)]
        public Int32? SanrentanHaitoukin2 { get; set; }
        [Column(Name = "SanrentanNinki2", IsEnclosed = false)]
        public Int32? SanrentanNinki2 { get; set; }
        [Column(Name = "Sanrentan31", IsEnclosed = false)]
        public Int32? Sanrentan31 { get; set; }
        [Column(Name = "Sanrentan32", IsEnclosed = false)]
        public Int32? Sanrentan32 { get; set; }
        [Column(Name = "Sanrentan33", IsEnclosed = false)]
        public Int32? Sanrentan33 { get; set; }
        [Column(Name = "SanrentanHaitoukin3", IsEnclosed = false)]
        public Int32? SanrentanHaitoukin3 { get; set; }
        [Column(Name = "SanrentanNinki3", IsEnclosed = false)]
        public Int32? SanrentanNinki3 { get; set; }
        [Column(Name = "Sanrentan41", IsEnclosed = false)]
        public Int32? Sanrentan41 { get; set; }
        [Column(Name = "Sanrentan42", IsEnclosed = false)]
        public Int32? Sanrentan42 { get; set; }
        [Column(Name = "Sanrentan43", IsEnclosed = false)]
        public Int32? Sanrentan43 { get; set; }
        [Column(Name = "SanrentanHaitoukin4", IsEnclosed = false)]
        public Int32? SanrentanHaitoukin4 { get; set; }
        [Column(Name = "SanrentanNinki4", IsEnclosed = false)]
        public Int32? SanrentanNinki4 { get; set; }
        [Column(Name = "Sanrentan51", IsEnclosed = false)]
        public Int32? Sanrentan51 { get; set; }
        [Column(Name = "Sanrentan52", IsEnclosed = false)]
        public Int32? Sanrentan52 { get; set; }
        [Column(Name = "Sanrentan53", IsEnclosed = false)]
        public Int32? Sanrentan53 { get; set; }
        [Column(Name = "SanrentanHaitoukin5", IsEnclosed = false)]
        public Int32? SanrentanHaitoukin5 { get; set; }
        [Column(Name = "SanrentanNinki5", IsEnclosed = false)]
        public Int32? SanrentanNinki5 { get; set; }
        [Column(Name = "Sanrentan61", IsEnclosed = false)]
        public Int32? Sanrentan61 { get; set; }
        [Column(Name = "Sanrentan62", IsEnclosed = false)]
        public Int32? Sanrentan62 { get; set; }
        [Column(Name = "Sanrentan63", IsEnclosed = false)]
        public Int32? Sanrentan63 { get; set; }
        [Column(Name = "SanrentanHaitoukin6", IsEnclosed = false)]
        public Int32? SanrentanHaitoukin6 { get; set; }
        [Column(Name = "SanrentanNinki6", IsEnclosed = false)]
        public Int32? SanrentanNinki6 { get; set; }
    }
    
    public partial class OddsKubun
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "RaceId", IsEnclosed = false)]
        public Int64 RaceId { get; set; }
        [Column(Name = "YosouKakutei", IsEnclosed = false)]
        public Int32 YosouKakutei { get; set; }
        [Column(Name = "BakenShubetsu", IsEnclosed = false)]
        public Int32 BakenShubetsu { get; set; }
        [Column(Name = "DataSakuseiNengappi", IsEnclosed = false)]
        public DateTime DataSakuseiNengappi { get; set; }
    }
    
    public partial class Odds
    {
        [Column(Name = "OddsKubunId", IsEnclosed = false)]
        public Int64 OddsKubunId { get; set; }
        [Column(Name = "Bangou1", IsEnclosed = false)]
        public Int32 Bangou1 { get; set; }
        [Column(Name = "Bangou2", IsEnclosed = false)]
        public Int32? Bangou2 { get; set; }
        [Column(Name = "Bangou3", IsEnclosed = false)]
        public Int32? Bangou3 { get; set; }
        [Column(Name = "Odds1", IsEnclosed = false)]
        public Double? Odds1 { get; set; }
        [Column(Name = "Odds2", IsEnclosed = false)]
        public Double? Odds2 { get; set; }
    }
    
    public partial class Shussouba
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "RaceId", IsEnclosed = false)]
        public Int64 RaceId { get; set; }
        [Column(Name = "Wakuban", IsEnclosed = false)]
        public Int32 Wakuban { get; set; }
        [Column(Name = "Umaban", IsEnclosed = false)]
        public Int32 Umaban { get; set; }
        [Column(Name = "Gate", IsEnclosed = false)]
        public Int32 Gate { get; set; }
        [Column(Name = "KyousoubaId", IsEnclosed = false)]
        public String KyousoubaId { get; set; }
        [Column(Name = "KanaBamei", IsEnclosed = false)]
        public String KanaBamei { get; set; }
        [Column(Name = "UmaKigou", IsEnclosed = false)]
        public Int32? UmaKigou { get; set; }
        [Column(Name = "Seibetsu", IsEnclosed = false)]
        public Int32 Seibetsu { get; set; }
        [Column(Name = "Nenrei", IsEnclosed = false)]
        public Int32 Nenrei { get; set; }
        [Column(Name = "BanushiMei", IsEnclosed = false)]
        public String BanushiMei { get; set; }
        [Column(Name = "TanshukuBanushiMei", IsEnclosed = false)]
        public String TanshukuBanushiMei { get; set; }
        [Column(Name = "Blinker", IsEnclosed = false)]
        public Int32? Blinker { get; set; }
        [Column(Name = "Kinryou", IsEnclosed = false)]
        public Double? Kinryou { get; set; }
        [Column(Name = "Bataijuu", IsEnclosed = false)]
        public Int32? Bataijuu { get; set; }
        [Column(Name = "Zougen", IsEnclosed = false)]
        public Int32? Zougen { get; set; }
        [Column(Name = "RecordShisuu", IsEnclosed = false)]
        public Int32? RecordShisuu { get; set; }
        [Column(Name = "KishuId", IsEnclosed = false)]
        public Int32 KishuId { get; set; }
        [Column(Name = "KishuMei", IsEnclosed = false)]
        public String KishuMei { get; set; }
        [Column(Name = "TanshukuKishuMei", IsEnclosed = false)]
        public String TanshukuKishuMei { get; set; }
        [Column(Name = "KishuTouzaiBetsu", IsEnclosed = false)]
        public Int32? KishuTouzaiBetsu { get; set; }
        [Column(Name = "KishuShozokuBasho", IsEnclosed = false)]
        public Int32? KishuShozokuBasho { get; set; }
        [Column(Name = "KishuShozokuKyuushaId", IsEnclosed = false)]
        public Int32? KishuShozokuKyuushaId { get; set; }
        [Column(Name = "MinaraiKubun", IsEnclosed = false)]
        public Int32? MinaraiKubun { get; set; }
        [Column(Name = "Norikawari", IsEnclosed = false)]
        public Int32? Norikawari { get; set; }
        [Column(Name = "KyuushaId", IsEnclosed = false)]
        public Int32? KyuushaId { get; set; }
        [Column(Name = "KyuushaMei", IsEnclosed = false)]
        public String KyuushaMei { get; set; }
        [Column(Name = "TanshukuKyuushaMei", IsEnclosed = false)]
        public String TanshukuKyuushaMei { get; set; }
        [Column(Name = "KyuushaShozokuBasho", IsEnclosed = false)]
        public Int32? KyuushaShozokuBasho { get; set; }
        [Column(Name = "KyuushaRitsuHokuNanBetsu", IsEnclosed = false)]
        public Int32? KyuushaRitsuHokuNanBetsu { get; set; }
        [Column(Name = "YosouShirushi", IsEnclosed = false)]
        public Int32? YosouShirushi { get; set; }
        [Column(Name = "YosouShirushiHonshi", IsEnclosed = false)]
        public Int32? YosouShirushiHonshi { get; set; }
        [Column(Name = "Ninki", IsEnclosed = false)]
        public Int32? Ninki { get; set; }
        [Column(Name = "Odds", IsEnclosed = false)]
        public Double? Odds { get; set; }
        [Column(Name = "KakuteiChakujun", IsEnclosed = false)]
        public Int32? KakuteiChakujun { get; set; }
        [Column(Name = "ChakujunFuka", IsEnclosed = false)]
        public Int32? ChakujunFuka { get; set; }
        [Column(Name = "NyuusenChakujun", IsEnclosed = false)]
        public Int32? NyuusenChakujun { get; set; }
        [Column(Name = "TorikeshiShubetsu", IsEnclosed = false)]
        public Int32? TorikeshiShubetsu { get; set; }
        [Column(Name = "RecordNinshiki", IsEnclosed = false)]
        public Int32? RecordNinshiki { get; set; }
        [Column(Name = "Time", IsEnclosed = false)]
        public Double? Time { get; set; }
        [Column(Name = "Chakusa1", IsEnclosed = false)]
        public Int32? Chakusa1 { get; set; }
        [Column(Name = "Chakusa2", IsEnclosed = false)]
        public Int32? Chakusa2 { get; set; }
        [Column(Name = "TimeSa", IsEnclosed = false)]
        public Double? TimeSa { get; set; }
        [Column(Name = "Zenhan3F", IsEnclosed = false)]
        public Double? Zenhan3F { get; set; }
        [Column(Name = "Kouhan3F", IsEnclosed = false)]
        public Double? Kouhan3F { get; set; }
        [Column(Name = "YonCornerIchiDori", IsEnclosed = false)]
        public Int32? YonCornerIchiDori { get; set; }
        [Column(Name = "Seinen", IsEnclosed = false)]
        public Int32 Seinen { get; set; }
        [Column(Name = "ShutsubahyouSakuseiNengappi", IsEnclosed = false)]
        public DateTime? ShutsubahyouSakuseiNengappi { get; set; }
        [Column(Name = "SeisekiSakuseiNengappi", IsEnclosed = false)]
        public DateTime? SeisekiSakuseiNengappi { get; set; }
    }
    
    public partial class Kishu
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int32 Id { get; set; }
        [Column(Name = "KishuMei", IsEnclosed = false)]
        public String KishuMei { get; set; }
        [Column(Name = "TanshukuKishuMei", IsEnclosed = false)]
        public String TanshukuKishuMei { get; set; }
        [Column(Name = "Furigana", IsEnclosed = false)]
        public String Furigana { get; set; }
        [Column(Name = "Seinengappi", IsEnclosed = false)]
        public DateTime? Seinengappi { get; set; }
        [Column(Name = "HatsuMenkyoNen", IsEnclosed = false)]
        public Int32? HatsuMenkyoNen { get; set; }
        [Column(Name = "KishuTouzaiBetsu", IsEnclosed = false)]
        public Int32? KishuTouzaiBetsu { get; set; }
        [Column(Name = "KishuShozokuBasho", IsEnclosed = false)]
        public Int32? KishuShozokuBasho { get; set; }
        [Column(Name = "KishuShikakuKubun", IsEnclosed = false)]
        public Int32? KishuShikakuKubun { get; set; }
        [Column(Name = "MinaraiKubun", IsEnclosed = false)]
        public Int32? MinaraiKubun { get; set; }
        [Column(Name = "KishuShozokuKyuushaId", IsEnclosed = false)]
        public Int32? KishuShozokuKyuushaId { get; set; }
        [Column(Name = "KishuShozokuKyuushaMei", IsEnclosed = false)]
        public String KishuShozokuKyuushaMei { get; set; }
        [Column(Name = "TanshukuKyuushaMei", IsEnclosed = false)]
        public String TanshukuKyuushaMei { get; set; }
        [Column(Name = "KyuushaShozokuBasho", IsEnclosed = false)]
        public Int32? KyuushaShozokuBasho { get; set; }
        [Column(Name = "KyuushaRitsuHokuNanBetsu", IsEnclosed = false)]
        public Int32? KyuushaRitsuHokuNanBetsu { get; set; }
        [Column(Name = "TourokuMasshouFlag", IsEnclosed = false)]
        public Int32? TourokuMasshouFlag { get; set; }
        [Column(Name = "DataSakuseiNengappi", IsEnclosed = false)]
        public DateTime? DataSakuseiNengappi { get; set; }
    }
    
    public partial class Kyuusha
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int32 Id { get; set; }
        [Column(Name = "KyuushaMei", IsEnclosed = false)]
        public String KyuushaMei { get; set; }
        [Column(Name = "TanshukuKyuushaMei", IsEnclosed = false)]
        public String TanshukuKyuushaMei { get; set; }
        [Column(Name = "Furigana", IsEnclosed = false)]
        public String Furigana { get; set; }
        [Column(Name = "Seinengappi", IsEnclosed = false)]
        public DateTime? Seinengappi { get; set; }
        [Column(Name = "HatsuMenkyoNen", IsEnclosed = false)]
        public Int32? HatsuMenkyoNen { get; set; }
        [Column(Name = "KyuushaTouzaiBetsu", IsEnclosed = false)]
        public Int32? KyuushaTouzaiBetsu { get; set; }
        [Column(Name = "KyuushaShozokuBasho", IsEnclosed = false)]
        public Int32? KyuushaShozokuBasho { get; set; }
        [Column(Name = "KyuushaRitsuHokuNanBetsu", IsEnclosed = false)]
        public Int32? KyuushaRitsuHokuNanBetsu { get; set; }
        [Column(Name = "TourokuMasshouFlag", IsEnclosed = false)]
        public Int32? TourokuMasshouFlag { get; set; }
        [Column(Name = "DataSakuseiNengappi", IsEnclosed = false)]
        public DateTime? DataSakuseiNengappi { get; set; }
    }
    
    public partial class Choukyou
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "KyousoubaId", IsEnclosed = false)]
        public String KyousoubaId { get; set; }
        [Column(Name = "Tanpyou", IsEnclosed = false)]
        public String Tanpyou { get; set; }
        [Column(Name = "HonsuuCourse", IsEnclosed = false)]
        public Int32? HonsuuCourse { get; set; }
        [Column(Name = "HonsuuHanro", IsEnclosed = false)]
        public Int32? HonsuuHanro { get; set; }
        [Column(Name = "HonsuuPool", IsEnclosed = false)]
        public Int32? HonsuuPool { get; set; }
        [Column(Name = "Rating", IsEnclosed = false)]
        public Double? Rating { get; set; }
        [Column(Name = "KyuuyouRiyuu", IsEnclosed = false)]
        public String KyuuyouRiyuu { get; set; }
    }
    
    public partial class ChoukyouRireki
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "ChoukyouId", IsEnclosed = false)]
        public Int64 ChoukyouId { get; set; }
        [Column(Name = "Oikiri", IsEnclosed = false)]
        public Int32? Oikiri { get; set; }
        [Column(Name = "Kijousha", IsEnclosed = false)]
        public String Kijousha { get; set; }
        [Column(Name = "Nengappi", IsEnclosed = false)]
        public DateTime? Nengappi { get; set; }
        [Column(Name = "Basho", IsEnclosed = false)]
        public String Basho { get; set; }
        [Column(Name = "ChoukyouCourse", IsEnclosed = false)]
        public String ChoukyouCourse { get; set; }
        [Column(Name = "ChoukyouBaba", IsEnclosed = false)]
        public String ChoukyouBaba { get; set; }
        [Column(Name = "Kaisuu", IsEnclosed = false)]
        public Int32? Kaisuu { get; set; }
        [Column(Name = "IchiDori", IsEnclosed = false)]
        public Int32? IchiDori { get; set; }
        [Column(Name = "Ashiiro", IsEnclosed = false)]
        public String Ashiiro { get; set; }
        [Column(Name = "Yajirushi", IsEnclosed = false)]
        public Int32? Yajirushi { get; set; }
        [Column(Name = "Reigai", IsEnclosed = false)]
        public String Reigai { get; set; }
        [Column(Name = "Awase", IsEnclosed = false)]
        public String Awase { get; set; }
    }
    
    public partial class ChoukyouTime
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "ChoukyouRirekiId", IsEnclosed = false)]
        public Int64 ChoukyouRirekiId { get; set; }
        [Column(Name = "F", IsEnclosed = false)]
        public Int32 F { get; set; }
        [Column(Name = "Time", IsEnclosed = false)]
        public Double? Time { get; set; }
        [Column(Name = "Comment", IsEnclosed = false)]
        public String Comment { get; set; }
    }
    
    public partial class ShussoubaTsuukaJuni
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "ShussoubaId", IsEnclosed = false)]
        public Int64 ShussoubaId { get; set; }
        [Column(Name = "Bangou", IsEnclosed = false)]
        public Int32 Bangou { get; set; }
        [Column(Name = "Juni", IsEnclosed = false)]
        public Int32? Juni { get; set; }
        [Column(Name = "Joukyou", IsEnclosed = false)]
        public Int32? Joukyou { get; set; }
    }
    
    public partial class RaceHassouJoukyou
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "RaceId", IsEnclosed = false)]
        public Int64 RaceId { get; set; }
        [Column(Name = "UmabanGun", IsEnclosed = false)]
        public String UmabanGun { get; set; }
        [Column(Name = "HassouJoukyou", IsEnclosed = false)]
        public String HassouJoukyou { get; set; }
        [Column(Name = "Ichi", IsEnclosed = false)]
        public Int32 Ichi { get; set; }
        [Column(Name = "Joukyou", IsEnclosed = false)]
        public Int32 Joukyou { get; set; }
        [Column(Name = "FuriByousuu", IsEnclosed = false)]
        public Double? FuriByousuu { get; set; }
    }
    
    public partial class ShussoubaHassouJoukyou
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "RaceHassouJoukyouId", IsEnclosed = false)]
        public Int64 RaceHassouJoukyouId { get; set; }
        [Column(Name = "ShussoubaId", IsEnclosed = false)]
        public Int64 ShussoubaId { get; set; }
    }
    
    public partial class RaceKeika
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "RaceId", IsEnclosed = false)]
        public Int64 RaceId { get; set; }
        [Column(Name = "Bangou", IsEnclosed = false)]
        public Int32 Bangou { get; set; }
        [Column(Name = "Keika", IsEnclosed = false)]
        public String Keika { get; set; }
        [Column(Name = "Midashi1", IsEnclosed = false)]
        public Int32? Midashi1 { get; set; }
        [Column(Name = "Midashi2", IsEnclosed = false)]
        public Int32? Midashi2 { get; set; }
    }
    
    public partial class ShussoubaKeika
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "RaceKeikaId", IsEnclosed = false)]
        public Int64 RaceKeikaId { get; set; }
        [Column(Name = "ShussoubaId", IsEnclosed = false)]
        public Int64 ShussoubaId { get; set; }
        [Column(Name = "Tate", IsEnclosed = false)]
        public String Tate { get; set; }
        [Column(Name = "Yoko", IsEnclosed = false)]
        public String Yoko { get; set; }
    }
    
    public partial class Kyousouba
    {
    	[Id, Column(Name = "Id", IsEnclosed = false)]
        public String Id { get; set; }
        [Column(Name = "KanaBamei", IsEnclosed = false)]
        public String KanaBamei { get; set; }
        [Column(Name = "KyuuBamei", IsEnclosed = false)]
        public String KyuuBamei { get; set; }
        [Column(Name = "Seinengappi", IsEnclosed = false)]
        public DateTime? Seinengappi { get; set; }
        [Column(Name = "Keiro", IsEnclosed = false)]
        public Int32? Keiro { get; set; }
        [Column(Name = "Kesshu", IsEnclosed = false)]
        public Int32? Kesshu { get; set; }
        [Column(Name = "Sanchi", IsEnclosed = false)]
        public Int32? Sanchi { get; set; }
        [Column(Name = "UmaKigou", IsEnclosed = false)]
        public Int32? UmaKigou { get; set; }
        [Column(Name = "Seibetsu", IsEnclosed = false)]
        public Int32? Seibetsu { get; set; }
        [Column(Name = "ChichiUmaId", IsEnclosed = false)]
        public String ChichiUmaId { get; set; }
        [Column(Name = "ChichiUmaMei", IsEnclosed = false)]
        public String ChichiUmaMei { get; set; }
        [Column(Name = "HahaUmaId", IsEnclosed = false)]
        public String HahaUmaId { get; set; }
        [Column(Name = "HahaUmaMei", IsEnclosed = false)]
        public String HahaUmaMei { get; set; }
        [Column(Name = "HahaChichiUmaId", IsEnclosed = false)]
        public String HahaChichiUmaId { get; set; }
        [Column(Name = "HahaChichiUmaMei", IsEnclosed = false)]
        public String HahaChichiUmaMei { get; set; }
        [Column(Name = "HahaHahaUmaId", IsEnclosed = false)]
        public String HahaHahaUmaId { get; set; }
        [Column(Name = "HahaHahaUmaMei", IsEnclosed = false)]
        public String HahaHahaUmaMei { get; set; }
        [Column(Name = "BanushiMei", IsEnclosed = false)]
        public String BanushiMei { get; set; }
        [Column(Name = "TanshukuBanushiMei", IsEnclosed = false)]
        public String TanshukuBanushiMei { get; set; }
        [Column(Name = "SeisanshaMei", IsEnclosed = false)]
        public String SeisanshaMei { get; set; }
        [Column(Name = "TanshukuSeisanshaMei", IsEnclosed = false)]
        public String TanshukuSeisanshaMei { get; set; }
        [Column(Name = "KyuushaId", IsEnclosed = false)]
        public Int32? KyuushaId { get; set; }
        [Column(Name = "KyuushaMei", IsEnclosed = false)]
        public String KyuushaMei { get; set; }
        [Column(Name = "TanshukuKyuushaMei", IsEnclosed = false)]
        public String TanshukuKyuushaMei { get; set; }
        [Column(Name = "KyuushaShozokuBasho", IsEnclosed = false)]
        public Int32? KyuushaShozokuBasho { get; set; }
        [Column(Name = "KyuushaRitsuHokuNanBetsu", IsEnclosed = false)]
        public Int32? KyuushaRitsuHokuNanBetsu { get; set; }
        [Column(Name = "KoueiGaikokuKyuushaMei", IsEnclosed = false)]
        public String KoueiGaikokuKyuushaMei { get; set; }
        [Column(Name = "MasshouFlag", IsEnclosed = false)]
        public Int32? MasshouFlag { get; set; }
        [Column(Name = "MasshouNengappi", IsEnclosed = false)]
        public DateTime? MasshouNengappi { get; set; }
        [Column(Name = "Jiyuu", IsEnclosed = false)]
        public String Jiyuu { get; set; }
        [Column(Name = "Ikisaki", IsEnclosed = false)]
        public String Ikisaki { get; set; }
        [Column(Name = "ChichiKyoriTekisei", IsEnclosed = false)]
        public Int32? ChichiKyoriTekisei { get; set; }
        [Column(Name = "HirabaOmoKousetsu", IsEnclosed = false)]
        public Int32? HirabaOmoKousetsu { get; set; }
        [Column(Name = "HirabaDirtKousetsu", IsEnclosed = false)]
        public Int32? HirabaDirtKousetsu { get; set; }
        [Column(Name = "ShougaiOmoKousetsu", IsEnclosed = false)]
        public Int32? ShougaiOmoKousetsu { get; set; }
        [Column(Name = "ShougaiDirtKousetsu", IsEnclosed = false)]
        public Int32? ShougaiDirtKousetsu { get; set; }
        [Column(Name = "DataSakuseiNengappi", IsEnclosed = false)]
        public DateTime DataSakuseiNengappi { get; set; }
    }
    
    public partial class ImportFile
    {
    	[Id(IdKind.Identity), Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "ImportDateTime", IsEnclosed = false)]
        public DateTime ImportDateTime { get; set; }
        [Column(Name = "FileName", IsEnclosed = false)]
        public String FileName { get; set; }
        [Column(Name = "FileSize", IsEnclosed = false)]
        public Int64 FileSize { get; set; }
        [Column(Name = "MD5", IsEnclosed = false)]
        public String MD5 { get; set; }
        [Column(Name = "Status", IsEnclosed = false)]
        public Int32 Status { get; set; }
    }
    
    public partial class ImportLog
    {
        [Id(IdKind.Identity), Column(Name = "Id", IsEnclosed = false)]
        public Int64 Id { get; set; }
        [Column(Name = "ImportFileId", IsEnclosed = false)]
        public Int64 ImportFileId { get; set; }
        [Column(Name = "UncompressedFileName", IsEnclosed = false)]
        public String UncompressedFileName { get; set; }
        [Column(Name = "TextIndex", IsEnclosed = false)]
        public Int32? TextIndex { get; set; }
        [Column(Name = "TextSize", IsEnclosed = false)]
        public Int32? TextSize { get; set; }
        [Column(Name = "Message", IsEnclosed = false)]
        public String Message { get; set; }
        [Column(Name = "DetailedMessage", IsEnclosed = false)]
        public String DetailedMessage { get; set; }
    }
    
    public partial class Code
    {
        [Id, Column(Name = "Domain", IsEnclosed = false)]
        public String Domain { get; set; }
        [Id, Column(Name = "Key", IsEnclosed = false)]
        public Int32 Key { get; set; }
        [Column(Name = "Val", IsEnclosed = false)]
        public String Val { get; set; }
    }
    
    public partial class Japanize
    {
        [Id, Column(Name = "Id", IsEnclosed = false)]
        public String Id { get; set; }
        [Column(Name = "Name", IsEnclosed = false)]
        public String Name { get; set; }
        [Column(Name = "Domain", IsEnclosed = false)]
        public String Domain { get; set; }
    }
    
    public partial class UserSQL
    {
        [Id, Column(Name = "Domain", IsEnclosed = false)]
        public String Domain { get; set; }
        [Id, Column(Name = "Name", IsEnclosed = false)]
        public String Name { get; set; }
        [Column(Name = "SQL", IsEnclosed = false)]
        public String SQL { get; set; }
        [Column(Name = "DetailColNames", IsEnclosed = false)]
        public String DetailColNames { get; set; }
        [Column(Name = "ParamColNames", IsEnclosed = false)]
        public String ParamColNames { get; set; }
        [Column(Name = "ListColNames", IsEnclosed = false)]
        public String ListColNames { get; set; }
        [Column(Name = "Editable", IsEnclosed = false)]
        public Int32 Editable { get; set; }
    }
    
}
