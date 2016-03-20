using System;
using System.Collections.Generic;
using System.Text;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;


namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    interface IImporterFactory
    {
        IImporter CreateImporter(ImportHistory importHistory, String[] filePathes);
    }
}
