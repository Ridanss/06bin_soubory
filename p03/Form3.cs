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

namespace p03
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("cisla", FileMode.Create, FileAccess.Write))
            {
                using(BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(1.1);
                    bw.Write(2.2);
                    bw.Write(3.3);
                    bw.Write(4.4);
                    bw.Write(5.5);
                }
            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            try
            {
                double soucet = 0;
                int n = int.Parse(textBoxN.Text);
                if (n == 0) throw new FormatException();
                using(FileStream fs = new FileStream("cisla", FileMode.Open, FileAccess.Read))
                {
                    using(BinaryReader br = new BinaryReader(fs))
                    {
                        for(int i = 0; i < n; i++)
                        {
                            soucet += br.ReadDouble();
                        }
                    }
                }
                MessageBox.Show(string.Format($"Průměr prvních {n} prvků je {soucet / n}"));

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (EndOfStreamException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
