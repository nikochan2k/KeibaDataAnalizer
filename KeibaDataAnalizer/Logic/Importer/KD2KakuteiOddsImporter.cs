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
	/// Description of KD2KakuteiOddsImporter.
	/// </summary>
	public class KD2KakuteiOddsImporter : KD2OddsImporter
	{
		public KD2KakuteiOddsImporter(ImportHistory importHistory, String kolKodPath)
			: base(importHistory, kolKodPath)
		{
		}
        
		protected override YosouKakutei YosouOrKakutei {
			get {
				return YosouKakutei.Kakutei;
			}
		}
        
	}
}
