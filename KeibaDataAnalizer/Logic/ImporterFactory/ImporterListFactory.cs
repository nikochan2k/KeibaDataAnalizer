using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    public class ImporterListFactory
    {
        private readonly IList<IImporterFactory> importerFactoryList = new List<IImporterFactory>();

        public ImporterListFactory()
        {
            importerFactoryList.Add(new KD1SeisekiImporterFactory());
            importerFactoryList.Add(new KD2SeisekiImporterFactory());
            importerFactoryList.Add(new KD3SeisekiImporterFactory());
            importerFactoryList.Add(new KD2ShutsubahyouImporterFactory());
            importerFactoryList.Add(new KD3ShutsubahyouImporterFactory());
            importerFactoryList.Add(new KD2KyousoubaImportFactory());
            importerFactoryList.Add(new KD3KyousoubaImportFactory());
            importerFactoryList.Add(new KD3YosouOddsImporterFactory());
            importerFactoryList.Add(new KD3KakuteiOddsImporterFactory());
        }

        public IList<IImporter> CreateImporterList(ImportHistory importHistory, string[] filePathes)
        {
            var importerList = new List<IImporter>();
            foreach(var importerFactory in importerFactoryList)
            {
                var importer = importerFactory.CreateImporter(importHistory, filePathes);
                if (importer != null)
                {
                    importerList.Add(importer);
                }
            }
            return importerList;
        }

    }
}
