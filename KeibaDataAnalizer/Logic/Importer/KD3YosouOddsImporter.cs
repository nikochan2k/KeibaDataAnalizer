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
	/// Description of KD3YosouOddsImporter.
	/// </summary>
	public class KD3YosouOddsImporter : KD3OddsImporter
	{
		private readonly String kolOdsPath;

		private readonly String kolOds2Path;

		public KD3YosouOddsImporter(ImportHistory importHistory, String kolOdsPath, String kolOds2Path)
			: base(importHistory)
		{
			this.kolOdsPath = kolOdsPath;
			this.kolOds2Path = kolOds2Path;
		}
		
		protected override YosouKakutei YosouOrKakutei {
			get {
				return YosouKakutei.Yosou;
			}
		}
        
		protected override string KolOddsPath {
			get {
				return kolOdsPath;
			}
		}
        
		protected override string KolOdds2Path {
			get {
				return kolOds2Path;
			}
		}
		
		protected override string KolOdds3Path {
			get {
				return null;
			}
		}
        
		protected override bool HasFukushouOdds {
			get {
				return false;
			}
		}
        
		protected override bool HasWideOdds {
			get {
				return false;
			}
		}
        
		protected override bool HasUmatanOdds {
			get {
				return true;
			}
		}
        
		protected override bool HasSanrenpukuOdds {
			get {
				return true;
			}
		}
        
	}
}
