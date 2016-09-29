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
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml;

namespace StardewValleySaveFixGUI
{
    public partial class Form1 : Form
    {
        ComboBox comboBoxSaves;
        public Form1()
        {
            InitializeComponent();
            MyClass obj = new MyClass();
            comboBoxSaves = new ComboBox();
            comboBoxSaves.Location = new System.Drawing.Point(27, 47);
            comboBoxSaves.DropDownStyle = ComboBoxStyle.DropDownList;

            int numeroSaves = obj.listaSaves.Length;
            string lista = "undefined";
            string savesDir2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StardewValley\\Saves");
            for (int i = 0; i < obj.listaSaves.Length; i++)
            {
                lista = obj.listaSaves[i];
                lista = lista.Replace(savesDir2 + @"\", null);
                obj.listaSaves[i] = lista;
            }
            comboBoxSaves.DataSource = obj.listaSaves;

            this.Controls.Add(comboBoxSaves);
        }


        //SaveConv
        static void ConvertSave(Dictionary<String, String> convertMap, string savenome)
        {
            var appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var savesDir = Path.Combine(appDataDir, "StardewValley\\Saves");

            var save = Path.Combine(Path.Combine(savesDir, savenome), savenome);
            var savegameinfo = Path.Combine(Path.Combine(savesDir, savenome), "SaveGameInfo");

            File.Copy(save, Path.ChangeExtension(save, ".bak"), true);

            XDocument doc = XDocument.Load(save);
            var leaves =
                from e in doc.Descendants()
                where !e.Elements().Any()
                select e;

            foreach (var leaf in leaves)
            {
                var value = leaf.Value;
                while (convertMap.ContainsKey(value))
                {
                    value = convertMap[value];
                }

                leaf.Value = value;
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false); // The false means, do not emit the BOM.
            using (XmlWriter w = XmlWriter.Create(save, settings))
            {
                doc.Save(w);
            }

           // MessageBox.Show("Substituindo caracteres 0/2...");

            string text = File.ReadAllText(save);
            text = text.Replace('é', 'e');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('É', 'E');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Á', 'A');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('á', 'a');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('À', 'A');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('à', 'a');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ã', 'A');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ã', 'a');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Â', 'A');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('â', 'a');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ê', 'E');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ê', 'e');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Í', 'I');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('í', 'i');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ó', 'O');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ó', 'o');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ô', 'O');
            File.WriteAllText(save, text);
            Console.WriteLine("...");
            text = File.ReadAllText(save);
            text = text.Replace('ô', 'o');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Õ', 'O');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('õ', 'o');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ú', 'U');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ú', 'u');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ç', 'C');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ç', 'c');
            File.WriteAllText(save, text);

            // MessageBox.Show("Substituindo caracteres 1/2...");

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('é', 'e');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('É', 'E');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Á', 'A');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('á', 'a');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('À', 'A');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('à', 'a');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ã', 'A');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ã', 'a');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Â', 'A');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('â', 'a');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ê', 'E');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ê', 'e');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Í', 'I');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('í', 'i');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ó', 'O');
            File.WriteAllText(savegameinfo, text);
            Console.WriteLine("...");
            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ó', 'o');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ô', 'O');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ô', 'o');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Õ', 'O');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('õ', 'o');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ú', 'U');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ú', 'u');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ç', 'C');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ç', 'c');
            File.WriteAllText(savegameinfo, text);

           // MessageBox.Show("Substituindo caracteres 2/2...");

           // MessageBox.Show("Correção concluida");

        } //Responsavel por realizar a conversao do save
        //SaveConv



        private void comboBoxSaves_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, System.EventArgs e)
        {
            int selected = comboBoxSaves.SelectedIndex;
          //  MessageBox.Show(selected.ToString());
            string current = (string)comboBoxSaves.SelectedItem;
          //  MessageBox.Show(current);
            //
            // Main SaveConv
            //
            FileStream stream;

            try
            {
                stream = new FileStream("SaveFix.json", FileMode.Open, FileAccess.Read);
            }
            catch (IOException)
            {
                MessageBox.Show("Arquivo SaveFix.json não foi encontrado");
                return;
            }

            var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            reader.Close();

            Dictionary<string, string> conversions = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            var running = true;
            while (running)
            {
                ConvertSave(conversions, current);
                MessageBox.Show("Correção Concluida! \n Você pode corrigir outro save.");
                running = false;
            }
            //
            // Main SaveConv
            //
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
