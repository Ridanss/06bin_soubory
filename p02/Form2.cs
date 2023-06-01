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

namespace p02
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            string file = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using(StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using(BinaryReader br = new BinaryReader(fs))
                            {
                                while(br.BaseStream.Position < br.BaseStream.Length)
                                {
                                    sw.WriteLine(br.ReadInt32() + "\n");
                                }
                            }
                        }
                    }
                }
            }
            
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.Write(file);
                }
            }   
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            using(StreamReader sr = new StreamReader(saveFileDialog1.FileName))
            {
                while (!sr.EndOfStream)
                {
                    listBox1.Items.Add(sr.ReadLine());
                }
            }
        }
    }
}
