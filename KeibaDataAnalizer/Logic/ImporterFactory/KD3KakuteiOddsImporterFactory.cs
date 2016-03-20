/*
 * Created by SharpDevelop.
 * User: nikoc
 * Date: 2016/03/20
 * Time: 15:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
	/// <summary>
	/// Description of KD3KakuteiOddsImporterFactory.
	/// </summary>
	public class KD3KakuteiOddsImporterFactory : AbstractImporterFactory
	{
        private readonly String[] KD3_FILE_NAMES = new String[] { "kol_kod.kd3", "kol_kod2.kd3", "kol_kod3.kd3" };

        protected override string[] GetFileNames()
        {
            return KD3_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
        	return new KD3KakuteiOddsImporter(importHistory, filePathes[0], filePathes[1], filePathes[2]);
        }
	}
}
