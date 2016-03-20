/*
 * Created by SharpDevelop.
 * User: nikoc
 * Date: 2016/03/21
 * Time: 7:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
	/// <summary>
	/// Description of KD2YosouOddsImporter.
	/// </summary>
	public class KD2YosouOddsImporter : KD2OddsImporter
	{
		public KD2YosouOddsImporter(ImportHistory importHistory, String kolOdsPath)
			: base(importHistory, kolOdsPath)
		{
		}
		
		protected override YosouKakutei YosouOrKakutei {
			get {
				return YosouKakutei.Yosou;
			}
		}
	}
}
