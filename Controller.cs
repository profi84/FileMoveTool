using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileMoveTool
{
    public class Controller
    {

        public Controller()
        {            
            StartSystem();
        }
        
        CopyMoveFunction copyMoveFunction;

        private void StartSystem()
        {   
            if (SettingsProgrammJsonSingle.Instance().SourcePath != null)
            {
                WriteLogFile.Instance().WriteLogFiles($"Auslesen von JSON File erfolgreich!");

                MapNetworkDrive mapNetworkDrive = new MapNetworkDrive();

                Thread.Sleep(3000);
 
                copyMoveFunction = new CopyMoveFunction();
                
            }
            else
            {
                WriteLogFile.Instance().WriteLogFiles($"Auslesen von JSON File war nicht erfolgreich!");
            }
        }
    }
}
