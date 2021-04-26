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
    public partial class Query : Form
    {
        public Query()
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
                string  Aud = "";
                char[] separator = new char[] { ',' };
                Global.aFile = new FileStream(Global.fileName, FileMode.Open);
                Global.StreamRead = new StreamReader(Global.aFile);
                while (!Global.StreamRead.EndOfStream)
                {
                    Zap = Global.StreamRead.ReadLine();
                    string[] sl = Zap.Split(separator);
                    if (sl[3] == textBox1.Text)
                    {
                        Aud += "\n" + sl[4];
                    }
                }
                if (Aud != "")
                {
                    MessageBox.Show("Аудитории по предмету " + textBox1.Text + ": " + Aud, "Запрос");
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
