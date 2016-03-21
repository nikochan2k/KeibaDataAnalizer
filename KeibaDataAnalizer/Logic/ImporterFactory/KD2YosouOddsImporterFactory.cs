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
	/// Description of KD2YosouOddsImporterFactory.
	/// </summary>
	public class KD2YosouOddsImporterFactory : AbstractImporterFactory
	{
        private readonly String[] KD2_FILE_NAMES = new String[] { "kol_ods.kd2" };

        protected override string[] GetFileNames()
        {
            return KD2_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
        	return new KD2YosouOddsImporter(importHistory, filePathes[0]);
        }
	}
}
