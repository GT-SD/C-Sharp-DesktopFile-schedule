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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int q = 0;
        dt[] dat = new dt[20];
        private void button2_Click(object sender, EventArgs e)
        {
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
            if (q < Convert.ToInt32(maskedTextBox1.Text) || (maskedTextBox1.Text) == null)
            {
                MessageBox.Show("Запись не найдена", "Ошибка");
            }
            else
            {
                for (int i = 0; i < q; i++)
                {
                    if ((i + 1) == Convert.ToInt32(maskedTextBox1.Text))
                    {
                        textBox1.Text = dat[i].Shifr;
                        comboBox1.Text = dat[i].Day;
                        comboBox2.Text = dat[i].Time;
                        textBox2.Text = dat[i].NameSub;
                        textBox3.Text = dat[i].NumAud;
                        textBox4.Text = dat[i].NameLect;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt dats = new dt();
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка");
            }
            else
            {
                dats.Shifr = textBox1.Text;
                dats.Day = comboBox1.Text;
                dats.Time = comboBox2.Text;
                dats.NameSub = textBox2.Text;
                dats.NumAud = textBox3.Text;
                dats.NameLect = textBox4.Text;
            }
            Global.aFile = new FileStream(Global.fileName, FileMode.Create);
            Global.StreamWrite = new StreamWriter(Global.aFile);
            for (int i = 0; i < q; i++)
            {
                if ((i + 1) != Convert.ToInt32(maskedTextBox1.Text))
                {
                    Global.StreamWrite.WriteLine("{0},{1},{2},{3},{4},{5}", dat[i].Shifr, dat[i].Day, dat[i].Time, dat[i].NameSub, dat[i].NumAud, dat[i].NameLect);
                }
                else
                {
                    Global.StreamWrite.WriteLine("{0},{1},{2},{3},{4},{5}", dats.Shifr, dats.Day, dats.Time, dats.NameSub, dats.NumAud, dats.NameLect);
                    MessageBox.Show("Запись изменена");
                }
            }
            Global.StreamWrite.Close();
            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (Global.CurrentRow != 0)
            {
                maskedTextBox1.Text = Convert.ToString(Global.CurrentRow);
                button2.PerformClick();
            }
        }
    }
}
