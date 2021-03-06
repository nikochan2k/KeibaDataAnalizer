﻿/*
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
	/// Description of KD3OddsImporter.
	/// </summary>
	public abstract class KD3OddsImporter : KDOddsImporter
	{
		private readonly String kolOddsPath;

		private readonly String kolOdds2Path;

		protected KD3OddsImporter(ImportHistory importHistory, String kolOddsPath, String kolOdds2Path)
			: base(importHistory)
		{
			this.kolOddsPath = kolOddsPath;
			this.kolOdds2Path = kolOdds2Path;
		}
		
		protected override string KolOddsPath {
			get {
				return kolOddsPath;
			}
		}
        
		protected override string KolOdds2Path {
			get {
				return kolOdds2Path;
			}
		}
		
		protected override int ByteOfOdds {
			get {
				return 1504;
			}
		}
        
		protected override int ByteOfOdds2 {
			get {
				return 9043;
			}
		}
		
		protected override int ByteOfOdds3 {
			get {
				return 49123;
			}
		}
        
		protected override int DataSakuseiNengappiIndex {
			get {
				return 114;
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
        
		protected override int UmatanOddsIndex {
			get {
				return 1799;
			}
		}
        
		protected override int SanrenpukuOddsIndex {
			get {
				return 3329;
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
