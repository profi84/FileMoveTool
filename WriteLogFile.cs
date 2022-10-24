using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMoveTool
{
    public class WriteLogFile
    {
        protected WriteLogFile()
        {            
        }

        static WriteLogFile writeLogFile;

        public static WriteLogFile Instance()
        {
            if (writeLogFile == null)
                writeLogFile = new WriteLogFile();

            return writeLogFile;
        }

        public void WriteLogFiles(string logText)
        {
            using (StreamWriter sw = new StreamWriter(GetFullNameLogFile(), true))
            {
                sw.Write(logText + GetDateTimeNow());
                sw.WriteLine();
            }
        }

        private string GetFullNameLogFile()
        {            
            string fileName = "";
            bool ifFileExistTemp = false;

            DirectoryInfo di = new DirectoryInfo(SettingsProgrammJsonSingle.Instance().LogFileFolder);

            //var options = new EnumerationOptions()
            //{
            //    IgnoreInaccessible = true,
            //    RecurseSubdirectories = false
            //};

            List<FileSystemInfo> SearchAllLogFiles = di.GetFileSystemInfos(".txt").ToList();

            foreach (var item in SearchAllLogFiles)
            {
                if (item.Name.Contains(GetDate()))
                {
                    ifFileExistTemp = true;
                    fileName = item.Name;
                    break;
                }
            }

            if (ifFileExistTemp == false)
                fileName = "Log-" + GetDate() + ".txt";

            string fullPath = SettingsProgrammJsonSingle.Instance().LogFileFolder + fileName;

            return fullPath;
        }
        private string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        private string GetDateTimeNow()
        {
            return DateTime.Now.ToString(" - dd.MM.yyyy HH:mm");
        }
    }
}

