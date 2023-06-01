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

namespace p04
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Create, FileAccess.ReadWrite);
            using(BinaryWriter bw = new BinaryWriter(fs))
            {
                try
                {
                    int line;
                    for (int i = 0; i < textBox1.Lines.Count(); i++)
                    {
                        line = int.Parse(textBox1.Lines[i]);
                        bw.Write(line);
                    }
                }
                catch (FormatException)
                {
                }
                using (BinaryReader br = new BinaryReader(fs))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        listBox2.Items.Add(br.ReadInt32());
                    }
                }
            }
        }
    }
}
