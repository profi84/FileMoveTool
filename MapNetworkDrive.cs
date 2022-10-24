using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FileMoveTool
{
    public class MapNetworkDrive
    {       
        public MapNetworkDrive()
        {
            MapNetwork();
        }
        private void MapNetwork()
        {
            string path = SettingsProgrammJsonSingle.Instance().TargetPath;
            string user = SettingsProgrammJsonSingle.Instance().UserNameTargetPath;
            string password = SettingsProgrammJsonSingle.Instance().PasswordTargetPath;
            string driveLetter = SettingsProgrammJsonSingle.Instance().DriveLetterTargetPath;

            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "net.exe";
                p.StartInfo.Arguments = string.Format("use {0}: {1} /user:{2} {3} ", driveLetter, path, user, password); // /persistent:yes
                p.StartInfo.UseShellExecute = false;
                p.Start();

                WriteLogFile.Instance().WriteLogFiles($"Netzlaufwerk wurde erfolgreich verbunden.");
            }
            catch (Exception ex)
            {
                WriteLogFile.Instance().WriteLogFiles($"Verbinden von Netzlaufwerk ist fehlgeschlagen!");
            }
        }
    }
}
