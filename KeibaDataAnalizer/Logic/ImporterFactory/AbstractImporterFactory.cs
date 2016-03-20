using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory
{
    public abstract class AbstractImporterFactory : IImporterFactory
    {

        #region IImporterFactory メンバ

        public IImporter CreateImporter(ImportHistory importHistory, string[] filePathes)
        {
            var fileNames = GetFileNames();
            var max = fileNames.Length;
            var matchPathes = new String[max];
            foreach (var filePath in filePathes)
            {
                var fileName = Path.GetFileName(filePath).ToLower();
                var index = Array.BinarySearch<String>(fileNames, fileName);
                if (index >= 0)
                {
                    matchPathes[index] = filePath;
                }
            }
            return Array.BinarySearch(matchPathes, null) < 0 ? CreateImporterInternal(importHistory, matchPathes) : null;
        }

        #endregion

        protected abstract String[] GetFileNames();

        protected abstract IImporter CreateImporterInternal(ImportHistory importHistory, string[] matchPathes);
    }
}
