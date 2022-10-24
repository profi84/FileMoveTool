using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMoveTool
{
    public class SettingsProgrammJsonSingle
    {

        protected SettingsProgrammJsonSingle()
        {
            jsonSettingsNested = new JsonSettingsNested();

            try
            {
                ReadJson();
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show("Json kann nicht gelesen werden. bitte überprüfen.");
            }
        }

        public static SettingsProgrammJsonSingle Instance()
        {
            if (settingsJsonFileSingle == null)
                settingsJsonFileSingle = new SettingsProgrammJsonSingle();

            return settingsJsonFileSingle;
        }

        static SettingsProgrammJsonSingle settingsJsonFileSingle; // SingleTon Object
        private JsonSettingsNested jsonSettingsNested; // = new JsonSettingsNested(); //Object Nested Class

        private string startPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private string settingFile = @"\ObjectJsonSetting.json";
        private string backupFolder = @"\BackupFiles\";
        private string logFileFolder = @"\LogFiles\";

        //private string 

        #region // Public Get/Set Methoden

        public string BackupFolder
        {
            get
            {  return startPath + backupFolder; }
        }

        public string LogFileFolder
        {
            get
            { return startPath + logFileFolder; }
        }

        public string SourcePath
        {
            get
            { return jsonSettingsNested.sourcePath; }
            set
            { jsonSettingsNested.sourcePath = value; }
        }

        public string TargetPath
        {
            get
            { return jsonSettingsNested.targetPath; }
            set
            { jsonSettingsNested.targetPath = value; }
        }

        public string UserNameTargetPath
        {
            get
            { return jsonSettingsNested.userNameTargetPath; }
            set
            { jsonSettingsNested.userNameTargetPath = value; }
        }

        public string PasswordTargetPath
        {
            get
            { return jsonSettingsNested.passwordTargetPath; }
            set
            { jsonSettingsNested.passwordTargetPath = value; }
        }

        public string DriveLetterTargetPath
        {
            get
            { return jsonSettingsNested.driveLetterTargetPath; }
            set
            { jsonSettingsNested.driveLetterTargetPath = value; }
        }

        #endregion

        private void ReadJson()
        {
            string pathSetting = startPath + settingFile;

            using (StreamReader file = File.OpenText(pathSetting))
            {
                JsonSerializer serializer = new JsonSerializer();
                jsonSettingsNested = (JsonSettingsNested)serializer.Deserialize(file, typeof(JsonSettingsNested));
            }
        }

        //private void WriteJson()
        //{
        //    using (StreamWriter files = File.CreateText(pathSetting))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        serializer.Serialize(files, jsonSettingsNested);
        //    }
        //}

        class JsonSettingsNested
        {
            // Können geändert werden.
            public string sourcePath;
            //public bool IfNetDriveSourcePath { get; set; }
            //public string UserNameSourcePath { get; set; }
            //public string PasswordSourcePath { get; set; }
            //public string DriveLetterSourcePath { get; set; }

            public string targetPath;
            //public bool IfNetDriveTargetPath { get; set; }
            public string userNameTargetPath;
            public string passwordTargetPath;
            public string driveLetterTargetPath;
        }
    }
}

