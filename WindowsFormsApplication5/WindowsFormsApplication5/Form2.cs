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

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Global.fileName))
            {
                Global.Shifr = textBox1.Text;
                Global.Day = comboBox1.Text;
                Global.Time = comboBox2.Text;
                Global.NameSub = textBox2.Text;
                Global.NumAud = textBox3.Text;
                Global.NameLect = textBox4.Text;
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Заполните все поля", "Ошибка");
                }
                else
                {
                    string Zap;
                    int q = 0;
                    Global.aFile = new FileStream(Global.fileName, FileMode.Open);
                    Global.StreamRead = new StreamReader(Global.aFile);
                    while (!Global.StreamRead.EndOfStream)
                    {
                        Global.StreamRead.ReadLine();
                        q++;
                    }
                    Global.StreamRead.Close();
                    Global.aFile = new FileStream(Global.fileName, FileMode.Open);
                    Global.StreamRead = new StreamReader(Global.aFile);
                    string[] line = new string[q];
                    int i = 0;
                    while (!Global.StreamRead.EndOfStream)
                    {
                        Zap = Global.StreamRead.ReadLine();
                        line [i] = Zap;
                        i++;
                    }
                    Global.StreamRead.Close();
                    Global.aFile = new FileStream(Global.fileName, FileMode.Create);
                    Global.StreamWrite = new StreamWriter(Global.aFile);
                    Global.StreamWrite.WriteLine("{0},{1},{2},{3},{4},{5}", Global.Shifr, Global.Day, Global.Time, Global.NameSub, Global.NumAud, Global.NameLect);
                    for (i = 0; i < q; i++)
                    { Global.StreamWrite.WriteLine(line[i]); }
                    Global.StreamWrite.Close();
                    MessageBox.Show("Запись добавлена");
                    textBox1.Clear();
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
            }
            else
            {
                MessageBox.Show("Файл отсутствует", "Ошибка");
                this.Close();
            }
        }
    }
}
