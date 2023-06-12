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
                        try
                        {
                            line = sr.ReadLine();
                            data = line.Split(';');
                            int a = int.Parse(data[0]);
                            string b = data[1];
                            string c = data[2];
                            char d = char.Parse(data[3]);
                            int f = int.Parse(data[4]);
                            int g = int.Parse(data[5]);

                            br.Write(a);
                            br.Write(b);
                            br.Write(c);
                            br.Write(d);
                            br.Write(f);
                            br.Write(g);
                        }
                        catch (FormatException)
                        {

                        }
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
