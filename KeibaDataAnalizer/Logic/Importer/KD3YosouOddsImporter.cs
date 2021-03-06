﻿/*
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
		public KD3YosouOddsImporter(ImportHistory importHistory, String kolOdsPath, String kolOds2Path)
			: base(importHistory, kolOdsPath, kolOds2Path)
		{
		}
		
		protected override YosouKakutei YosouOrKakutei {
			get {
				return YosouKakutei.Yosou;
			}
		}
        
		protected override string KolOdds3Path {
			get {
				return null;
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
        
	}
}
