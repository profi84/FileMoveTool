using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileMoveTool
{
    public class CopyMoveFunction
    {
        public CopyMoveFunction()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(SettingsProgrammJsonSingle.Instance().SourcePath);
            watcher.EnableRaisingEvents = true;
            //watcher.SynchronizingObject = this;
            watcher.Created += new FileSystemEventHandler(Watcher_Created);
            WriteLogFile.Instance().WriteLogFiles($"FileSystemWatcher wurde erstellt. Programm bereit!");
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            WriteLogFile.Instance().WriteLogFiles($"       # # # #   Datei: '{e.Name}'   # # # #");
            Thread.Sleep(1000);
            MoveFileFunction(e);
        }

        private void MoveFileFunction(FileSystemEventArgs sourceFile)
        {
            CopyFile(sourceFile.FullPath, sourceFile.Name);
            Thread.Sleep(1000);
            BackupFile(sourceFile.FullPath, sourceFile.Name);
            Thread.Sleep(1000);
            DeleteFile(sourceFile.FullPath, sourceFile.Name);
        }

        private void CopyFile(string fullPath, string sourceFile)
        {
            string temp = SettingsProgrammJsonSingle.Instance().DriveLetterTargetPath + ":" + "\\" + sourceFile;

            try
            {               
                File.Copy(fullPath, temp, true);
                WriteLogFile.Instance().WriteLogFiles($"Die Datei wurde erfolgreich kopiert!");
            }
            catch (Exception)
            {
                WriteLogFile.Instance().WriteLogFiles($"Kopieren der Datei ist fehlgeschlagen!");
            }
        }

        private void BackupFile(string fullPath, string sourceFile)
        {
            string backupPath = SettingsProgrammJsonSingle.Instance().BackupFolder + sourceFile;

            try
            {
                File.Copy(fullPath, backupPath, true);
                WriteLogFile.Instance().WriteLogFiles($"Die Datei wurde erfolgreich gesichert!");
            }
            catch (Exception)
            {
                WriteLogFile.Instance().WriteLogFiles($"Das Sichern der Datei ist fehlgeschlagen!");
            }
        }

        private void DeleteFile(string fullPath, string sourceFile)
        {
            try
            {
                File.Delete(fullPath);
                WriteLogFile.Instance().WriteLogFiles($"Die Datei wurde erfolgreich gelöscht!");
            }
            catch (Exception)
            {
                WriteLogFile.Instance().WriteLogFiles($"Löschen von der Datei ist fehlgeschlagen!");
            }
        }
    }
}
