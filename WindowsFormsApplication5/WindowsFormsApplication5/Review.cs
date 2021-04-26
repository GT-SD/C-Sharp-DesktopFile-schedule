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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            button1.Visible = false;
            button2.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Global.CurrentRow = e.RowIndex+1;
            if (Global.CurrentRow != 0)
            {
                button1.Visible = true;
                button2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Global.fileName))
            {
                dataGridView1.Rows.Clear();
                int q = 0;
                string Zap = "";
                char[] separator = new char[] { ',' };
                Global.aFile = new FileStream(Global.fileName, FileMode.Open);
                Global.StreamRead = new StreamReader(Global.aFile);

                while (!Global.StreamRead.EndOfStream)
                {
                    Zap = Global.StreamRead.ReadLine();
                    string[] sl = Zap.Split(separator);
                    this.dataGridView1.Rows.Add();
                    this.dataGridView1[0, q].Value = Convert.ToString(sl[0]);
                    this.dataGridView1[1, q].Value = Convert.ToString(sl[1]);
                    this.dataGridView1[2, q].Value = Convert.ToString(sl[2]);
                    this.dataGridView1[3, q].Value = Convert.ToString(sl[3]);
                    this.dataGridView1[4, q].Value = Convert.ToString(sl[4]);
                    this.dataGridView1[5, q].Value = Convert.ToString(sl[5]);
                    q++;
                }

                Global.StreamRead.Close();

            }
            else
            {
                MessageBox.Show("Файл отсутствует", "Ошибка");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            fr4.ShowDialog();
        }
    }
}
