using System;
using System.Collections.Generic;
using System.Text;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Getter;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer
{
    public abstract class AbstractImporter : IImporter
    {
        protected DefaultGetter DEFAULT_GETTER;
        
        protected NoSpaceGetter NO_SPACE_GETTER;

        protected DateGetter DATE_GETTER;

        protected OneTenthGetter ONE_TENTH_GETTER;

        protected TimeGetter TIME_GETTER;

        protected ZeroToNullGetter ZERO_TO_NULL_GETTER;

        protected ImportHistory importHistory;

        protected AbstractImporter(ImportHistory importHistory)
        {
            this.importHistory = importHistory;
            DEFAULT_GETTER = new DefaultGetter(importHistory);
            NO_SPACE_GETTER = new NoSpaceGetter(importHistory);
            DATE_GETTER = new DateGetter(importHistory);
            ONE_TENTH_GETTER = new OneTenthGetter(importHistory);
            TIME_GETTER = new TimeGetter(importHistory);
            ZERO_TO_NULL_GETTER = new ZeroToNullGetter(importHistory);
        }

        public abstract void Import();

    }
}
