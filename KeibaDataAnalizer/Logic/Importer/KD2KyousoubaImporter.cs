using System;
using System.Collections.Generic;
using System.Text;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public class KD2KyousoubaImporter : KDKyousoubaImporter
    {
        private String kolUmaPath;
       
        public KD2KyousoubaImporter(ImportHistory importHistory, string kolUmaPath)
            : base(importHistory)
        {
            this.kolUmaPath = kolUmaPath;
        }
        
        protected override string KolUmaPath
        {
            get { return kolUmaPath; }
        }
    }
}
