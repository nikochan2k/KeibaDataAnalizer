using System;
using System.Collections.Generic;
using System.Text;

using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    public class KD3KyousoubaImportFactory : AbstractImporterFactory
    {
        private readonly String[] KD3_FILE_NAMES = new String[] { "kol_uma.kd3" };

        protected override string[] GetFileNames()
        {
            return KD3_FILE_NAMES;
        }

        protected override IImporter CreateImporterInternal(ImportHistory importHistory, string[] filePathes)
        {
            return new KD3KyousoubaImporter(importHistory, filePathes[0]);
        }
    }
}
