/*
 * Created by SharpDevelop.
 * User: nikoc
 * Date: 2016/03/20
 * Time: 14:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
	/// <summary>
	/// Description of KD2OddsImporter.
	/// </summary>
	public abstract class KD2OddsImporter : KDOddsImporter
	{
		private readonly String kolOddsPath;
		
		protected KD2OddsImporter(ImportHistory importHistory, String kolOddsPath)
			: base(importHistory)
		{
			this.kolOddsPath = kolOddsPath;
		}
		
		protected override string KolOddsPath {
			get {
				return kolOddsPath;
			}
		}
        
		protected override string KolOdds2Path {
			get {
				return null;
			}
		}
		
		protected override string KolOdds3Path {
			get {
				return null;
			}
		}
		
		protected override int ByteOfOdds {
			get {
				return 1504;
			}
		}
        
		protected override int ByteOfOdds2 {
			get {
				return 0;
			}
		}
		
		protected override int ByteOfOdds3 {
			get {
				return 0;
			}
		}
        
		protected override int DataSakuseiNengappiIndex {
			get {
				return 113;
			}
		}
		
		protected override int TanshouOddsIndex {
			get {
				return 161;
			}
		}
        
		protected override int WakurenOddsIndex {
			get {
				return 251;
			}
		}
        
		protected override int UmarenOddsIndex {
			get {
				return 431;
			}
		}
        
		protected override int FukushouOddsIndex {
			get {
				return 0;
			}
		}
		
		protected override int WideOddsIndex {
			get {
				return 0;
			}
		}
		
		protected override int UmatanOddsIndex {
			get {
				return 0;
			}
		}
        
		protected override int SanrenpukuOddsIndex {
			get {
				return 0;
			}
		}
		
		protected override int SanrentanOddsIndex {
			get {
				return 0;
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
				return false;
			}
		}
        
		protected override bool HasSanrenpukuOdds {
			get {
				return false;
			}
		}
	}
}
