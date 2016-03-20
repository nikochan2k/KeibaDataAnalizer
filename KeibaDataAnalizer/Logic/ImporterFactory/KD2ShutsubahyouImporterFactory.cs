using System;
using System.Collections.Generic;
using System.Text;

using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    public class KD2ShutsubahyouImporterFactory : AbstractImporterFactory
    {
        private readonly String[] KD2_FILE_NAMES = new String[] { "kol_den1.kd2", "kol_den2.kd2" };

        protected override string[] GetFileNames()
        {
            return KD2_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
            return new KD2ShutsubahyouImporter(importHistory, filePathes[0], filePathes[1]);
        }
    }
}
