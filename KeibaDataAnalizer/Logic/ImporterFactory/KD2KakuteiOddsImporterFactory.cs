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
	/// Description of KD2KakuteiOddsImporterFactory.
	/// </summary>
	public class KD2KakuteiOddsImporterFactory : AbstractImporterFactory
	{
        private readonly String[] KD2_FILE_NAMES = new String[] { "kol_kod.kd2" };

        protected override string[] GetFileNames()
        {
            return KD2_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
        	return new KD2KakuteiOddsImporter(importHistory, filePathes[0]);
        }
	}
}
