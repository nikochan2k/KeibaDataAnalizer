using System;
using System.Collections.Generic;
using System.Text;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    public class KD3SeisekiImporterFactory : AbstractImporterFactory
    {
        private readonly String[] KD3_FILE_NAMES = new String[] { "kol_sei1.kd3", "kol_sei2.kd3", "kol_sei3.kd3" };

        protected override string[] GetFileNames()
        {
            return KD3_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
            return new KD3SeisekiImporter(importHistory, filePathes[0], filePathes[1], filePathes[2]);
        }
    }
}
