using System;
using System.Collections.Generic;
using System.Text;

using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    public class KD3ShutsubahyouImporterFactory : AbstractImporterFactory
    {
        private readonly String[] KD3_FILE_NAMES = new String[] { "kol_den1.kd3", "kol_den2.kd3" };

        protected override string[] GetFileNames()
        {
            return KD3_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
            return new KD3ShutsubahyouImporter(importHistory, filePathes[0], filePathes[1]);
        }
    }
}
