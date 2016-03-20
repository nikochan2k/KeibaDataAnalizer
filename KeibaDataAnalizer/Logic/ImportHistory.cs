using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.ComponentModel;

using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Enum;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic
{
    public class ImportHistory : INotifyPropertyChanged
    {
        public static ImportHistory CreateInstance(String filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var extension = Path.GetExtension(fileName).ToLower();
            if (!".lzh".Equals(extension))
            {
                return null;
            }

            var importHistory = new ImportHistory();

            importHistory.FileName = fileName;
            importHistory.ImportFile.ImportDateTime = DateTime.Now;
            importHistory.FilePath = filePath;
            var info = new FileInfo(filePath);
            importHistory.ImportFile.FileSize = info.Length;
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var provider = new MD5CryptoServiceProvider();
                var hash = provider.ComputeHash(fs);
                var builder = new StringBuilder();
                foreach (var b in hash)
                {
                    builder.Append(b.ToString("x2"));
                }
                importHistory.ImportFile.MD5 = builder.ToString();
            }

            return importHistory;
        }

        #region INotifyPropertyChanged メンバ

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private IList<ImportLog> importLogList;

        private ImportHistory()
        {
            ImportFile = new ImportFile();
            Status = ImportFileStatusEnum.未取込;
            importLogList = new List<ImportLog>();
        }

        private ImportFile ImportFile { get; set; }

        public String FileName
        {
            get
            {
                return ImportFile.FileName;
            }
            set
            {
                ImportFile.FileName = value;
            }
        }

        public String FilePath { get; set; }

        private String uncompressedFileName;

        public String UncompressedFileName
        {
            get
            {
                return uncompressedFileName;
            }
            set
            {
                uncompressedFileName = value;
                UncompressedFileIndex = 0;
            }
        }

        public long Length { get; set; }

        private int index;

        public int Index { 
            get 
            {
                return index;
            } 
            set 
            {
                if (value != index)
                {
                	Progress = (int)Math.Round((double)index / Length * 100.0);
                    NotifyPropertyChanged("Progress");
                    UncompressedFileIndex += (value - index);
                }
                index = value;
            }
        }

        public int UncompressedFileIndex { get; protected set; }

        public long FileSize
        {
            get
            {
                return ImportFile.FileSize;
            }
        }

        public ImportFileStatusEnum Status
        {
            get
            {
                return (ImportFileStatusEnum)ImportFile.Status;
            }
            set
            {
                if ((int)value != ImportFile.Status)
                {
                    NotifyPropertyChanged("Status");
                }
                ImportFile.Status = (int)value;
            }
        }

        public int Progress { get; protected set; }

        public void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                catch
                {
                }
            }
        }

        public void AddImportLog(int? index, int? size, String message, String detailedMessage, ImportFileStatusEnum status)
        {
            var importLog = new ImportLog();

            importLog.UncompressedFileName = this.UncompressedFileName;
            importLog.TextIndex = UncompressedFileIndex;
            importLog.TextSize = index != null ? size : null;
            importLog.Message = message;
            importLog.DetailedMessage = detailedMessage;

            this.importLogList.Add(importLog);

            this.Status = status;
        }

        public void Save()
        {
            if (this.Status == ImportFileStatusEnum.取込中)
            {
                this.Status = ImportFileStatusEnum.成功;
                this.Progress = 100;
                NotifyPropertyChanged("Progress");
            }
            
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
        		db.Insert<ImportFile>(con, ImportFile);
	            foreach (var importLog in importLogList)
	            {
	                importLog.ImportFileId = ImportFile.Id;
	                db.Insert<ImportLog>(con, importLog);
	            }
            	transaction.Commit();
            }
        }

        public override bool Equals(object obj)
        {
            var importHistory = obj as ImportHistory;
            if (importHistory == null)
            {
                return false;
            }
            if (this.FileSize == importHistory.FileSize && this.ImportFile.MD5.Equals(importHistory.ImportFile.MD5))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ImportFile.MD5.GetHashCode();
        }

    }
}
