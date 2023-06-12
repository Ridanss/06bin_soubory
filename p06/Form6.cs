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

namespace p06
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string line = string.Empty;
            FileStream fs = new FileStream("sport.dat", FileMode.Open, FileAccess.Read);
            using (BinaryReader br = new BinaryReader(fs))
            {
                while(br.BaseStream.Position < br.BaseStream.Length)
                {
                    try
                    {
                        line = br.ReadInt32().ToString() + ";";
                        line += br.Read() + ";";
                        line += br.Read() + ";";
                        line += br.ReadChar() + ";";
                        line += br.ReadInt32() + ";";
                        line += br.ReadInt32();
                        listBox1.Items.Add(line);
                    }
                    catch (FormatException)
                    {

                    }
                }
            }
        }
    }
}
