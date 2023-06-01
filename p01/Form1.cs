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

namespace p01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("cisla.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        listBox1.Items.Add(sr.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                buttonExecute.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("cisla", FileMode.Create, FileAccess.Write))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                using(StreamReader sr = new StreamReader("cisla.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        try
                        {
                            int li = int.Parse(line);
                            bw.Write(li);
                            listBox2.Items.Add(li);
                        }
                        catch (FormatException)
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}
