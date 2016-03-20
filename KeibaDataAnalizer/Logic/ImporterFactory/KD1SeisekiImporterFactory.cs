using System;
using System.Collections.Generic;
using System.Text;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    public class KD1SeisekiImporterFactory : AbstractImporterFactory
    {
        private readonly String[] KD1_FILE_NAMES = new String[] { "kol_sei.dat" };

        protected override string[] GetFileNames()
        {
            return KD1_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
            return new KD1SeisekiImporter(importHistory, filePathes[0]);
        }
    }
}
