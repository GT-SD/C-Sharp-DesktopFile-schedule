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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.ShowDialog();
        }

        private void редкатироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            fr4.ShowDialog();
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            fr5.ShowDialog();
            this.Activate();
        }

        private void аудиторияПоПредметуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            fr6.ShowDialog();
        }

        private void преподавательПоПредметуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 fr7 = new Form7();
            fr7.ShowDialog();
        }
        private void SaveFile()
        {
            try
            {
                if (Global.fileName != null)
                {
                    File.WriteAllText(Global.fileName, textBox1.Text);
                    textBox1.Text = File.ReadAllText(Global.fileName);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Simple Editor",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void OpenFile()
        {
            try
            {
                textBox1.Clear();

                textBox1.Text = File.ReadAllText(Global.fileName);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Simple Editor",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("Raspisanie.txt"))
            {
                MessageBox.Show("Файл уже существует", "Ошибка");
            }
            else
            {
                Global.fileName = ("Raspisanie.txt");
                Global.aFile = new FileStream(Global.fileName, FileMode.Create);
                Global.StreamWrite = new StreamWriter(Global.aFile);
                MessageBox.Show("Файл создан");
                Global.StreamWrite.Close();
            }                                                                   
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.DefaultExt = "*.txt";
            dig.Filter = "txt|*.txt";
            if (dig.ShowDialog() == DialogResult.OK)
            {
                string directory = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
                dig.InitialDirectory = directory;
                Global.fileName = dig.FileName;
                OpenFile();
                MessageBox.Show("Файл открыт");
            }
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.DefaultExt = "*.txt";
            dig.Filter = "txt|*.txt";
            if (dig.ShowDialog() == DialogResult.OK)
            {
                string directory = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
                dig.InitialDirectory = directory;
                Global.fileName = dig.FileName;
            }
            SaveFile();
        }


    }

    public struct dt
    {
        public string Shifr;
        public string Day;
        public string Time;
        public string NameSub;
        public string NumAud;
        public string NameLect;
    };

}
