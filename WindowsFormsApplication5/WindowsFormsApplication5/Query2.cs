using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication5
{
    public partial class Query2 : Form
    {
        public Query2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите название предмета", "Ошибка");
            }
            else
            {
                string Zap = "";
                string Fam = "";
                char[] separator = new char[] { ',' };
                Global.aFile = new FileStream(Global.fileName, FileMode.Open);
                Global.StreamRead = new StreamReader(Global.aFile);
                while (!Global.StreamRead.EndOfStream)
                {
                    Zap = Global.StreamRead.ReadLine();
                    string[] sl = Zap.Split(separator);
                    Global.Shifr = sl[0];
                    Global.Day = sl[1];
                    Global.Time = sl[2];
                    Global.NameSub = sl[3];
                    Global.NumAud = sl[4];
                    Global.NameLect = sl[5];
                    if (sl[3] == textBox1.Text)
                    {
                        Fam += "\n" + sl[5];
                    }
                }
                if (Fam != "")
                {
                    MessageBox.Show("Фамилии преподавателей по предмету " + textBox1.Text + ": " + Fam, "Запрос");
                }
                else
                {
                    MessageBox.Show("Такого предмета нет", "Ошибка");
                }

                Global.StreamRead.Close();
            }
        }
    }
}
