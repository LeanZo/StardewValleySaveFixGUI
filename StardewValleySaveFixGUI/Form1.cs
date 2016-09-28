using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StardewValleySaveFixGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListBox listBox1 = new ListBox();
            MyClass obj = new MyClass();
            listBox1.DataSource = obj.listaSaves;
            Controls.Add(listBox1);
        }
    }
    public class MyClass
    {
        static string savesDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StardewValley\\Saves");
        public string[] listaSaves = Directory.GetDirectories(savesDir);
        public MyClass()
        {
            foreach (var item in listaSaves)
            {
                var item2 = item.Replace(savesDir + @"\", null);
                Console.WriteLine(item2);
            }

        }
    }








}
