using System;
using System.Collections.Generic;
using System.Text;

using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    public class KD2KyousoubaImportFactory : AbstractImporterFactory
    {
        private readonly String[] KD2_FILE_NAMES = new String[] { "kol_uma.kd2" };

        protected override string[] GetFileNames()
        {
            return KD2_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
            return new KD2KyousoubaImporter(importHistory, filePathes[0]);
        }
    }
}
