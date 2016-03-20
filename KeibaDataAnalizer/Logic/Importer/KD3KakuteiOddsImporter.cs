/*
 * Created by SharpDevelop.
 * User: nikoc
 * Date: 2016/03/20
 * Time: 13:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
	/// <summary>
	/// Description of KD3KakuteiOddsImporter.
	/// </summary>
	public class KD3KakuteiOddsImporter : KD3OddsImporter
	{
		private readonly String kolKod3Path;

		public KD3KakuteiOddsImporter(ImportHistory importHistory, String kolKodPath,
			String kolKod2Path, String kolKod3Path)
			: base(importHistory, kolKodPath, kolKod2Path)
		{
			this.kolKod3Path = kolKod3Path;
		}
        
		protected override YosouKakutei YosouOrKakutei {
			get {
				return YosouKakutei.Kakutei;
			}
		}
		
		protected override string KolOdds3Path {
			get {
				return kolKod3Path;
			}
		}
       
		protected override int FukushouOddsIndex {
			get {
				return 161;
			}
		}
		
		protected override int WideOddsIndex {
			get {
				return 269;
			}
		}
		
		protected override int SanrentanOddsIndex {
			get {
				return 161;
			}
		}
        
		protected override bool HasFukushouOdds {
			get {
				return true;
			}
		}
        
		protected override bool HasWideOdds {
			get {
				return true;
			}
		}
        
	}
}
