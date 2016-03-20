using System;
using System.Collections.Generic;
using System.Text;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    public class KD2SeisekiImporterFactory : AbstractImporterFactory
    {
        private readonly String[] KD2_FILE_NAMES = new String[] { "kol_sei1.kd2", "kol_sei2.kd2" };

        protected override string[] GetFileNames()
        {
            return KD2_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
            return new KD2SeisekiImporter(importHistory, filePathes[0], filePathes[1]);
        }
    }
}
