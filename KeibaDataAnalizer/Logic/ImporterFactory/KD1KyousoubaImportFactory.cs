/*
 * Created by SharpDevelop.
 * User: Yoshihiro
 * Date: 2011/09/27
 * Time: 0:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
	/// <summary>
	/// Description of KD1KyousoubaImportFactory.
	/// </summary>
	public class KD1KyousoubaImportFactory : AbstractImporterFactory
	{
        private readonly String[] KD1_FILE_NAMES = new String[] { "kol_uma.dat" };

        protected override string[] GetFileNames()
        {
            return KD1_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
            return new KD1KyousoubaImporter(importHistory, filePathes[0]);
        }
	}
}
