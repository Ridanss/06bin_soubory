using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(StreamReader sr = new StreamReader("sport.txt"))
            {
                string line;
                string[] data;
                FileStream fs = new FileStream("sport.dat", FileMode.Create, FileAccess.Write);
                using(BinaryWriter br = new BinaryWriter(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        data = line.Split(';');
                        br.Write(int.Parse(data[0]));
                        br.Write(data[1]);
                        br.Write(data[2]);
                        br.Write(char.Parse(data[3]));
                        br.Write(int.Parse(data[4]));
                        br.Write(int.Parse(data[5]));
                    }
                }
            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("sport.dat", FileMode.Open, FileAccess.Read);
                using(BinaryReader br = new BinaryReader(fs))
                {
                    while(br.BaseStream.Position < br.BaseStream.Length)
                    {
                        textBox1.Text += br.ReadInt32() + ";";
                        textBox1.Text += br.ReadString() + ";";
                        textBox1.Text += br.ReadString() + ";";
                        textBox1.Text += br.ReadChar() + ";";
                        textBox1.Text += br.ReadInt32() + ";";
                        textBox1.Text += br.ReadInt32() + Environment.NewLine;
                    }
                }
            }   
            catch (FileNotFoundException)
            {

            }
            catch (FormatException)
            {

            }
        }
    }
}
