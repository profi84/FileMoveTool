using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMoveTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {                
                startPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                controller = new Controller();                
            }
            catch (Exception)
            {
                MessageBox.Show("Funktioniert nicht!");
            }
        }
                
        private string startPath = String.Empty;
        Controller controller;        
    }
}
