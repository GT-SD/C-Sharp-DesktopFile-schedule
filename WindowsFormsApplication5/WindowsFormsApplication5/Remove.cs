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
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int q = 0;
            dt[] dat = new dt[20];
            string Zap = "";
            char[] separator = new char[] { ',' };
            Global.aFile = new FileStream(Global.fileName, FileMode.Open);
            Global.StreamRead = new StreamReader(Global.aFile);
            while (!Global.StreamRead.EndOfStream)
            {
                Zap = Global.StreamRead.ReadLine();
                string[] sl = Zap.Split(separator);
                dat[q].Shifr = sl[0];
                dat[q].Day = sl[1];
                dat[q].Time = sl[2];
                dat[q].NameSub = sl[3];
                dat[q].NumAud = sl[4];
                dat[q].NameLect = sl[5];
                q++;
            }
            Global.StreamRead.Close();
            if (q < Convert.ToInt32(maskedTextBox1.Text))
            {
                MessageBox.Show("Запись не найдена", "Ошибка");
            }
            else
            {
                Global.aFile = new FileStream(Global.fileName, FileMode.Create);
                Global.StreamWrite = new StreamWriter(Global.aFile);
                for (int i = 0; i < q; i++)
                {
                    if ((i + 1) != Convert.ToInt32(maskedTextBox1.Text))
                    {
                        Global.StreamWrite.WriteLine("{0},{1},{2},{3},{4},{5}", dat[i].Shifr, dat[i].Day, dat[i].Time, dat[i].NameSub, dat[i].NumAud, dat[i].NameLect);
                    }
                }
                MessageBox.Show("Запись удалена");
                maskedTextBox1.Clear();
                Global.StreamWrite.Close();


            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            if (Global.CurrentRow != 0)
            {
                maskedTextBox1.Text = Convert.ToString(Global.CurrentRow);
                button1.PerformClick();
            }
        }
    }
}

