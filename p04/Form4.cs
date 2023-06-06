using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
            long maxPos = 0;
            int max = int.MinValue;

            long poslPos = 0;
            int posl = 0;

            FileStream fs = new FileStream("cisla.dat", FileMode.Create, FileAccess.ReadWrite);
            using(BinaryWriter bw = new BinaryWriter(fs))
            {
                try
                {
                    for (int i = 0; i < textBox1.Lines.Count(); i++)
                    {
                        int line = int.Parse(textBox1.Lines[i]);
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
                        listBox1.Items.Add(br.ReadInt32());
                    }
                    fs.Seek(0, SeekOrigin.Begin);
                    int line = 0;
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        line = br.ReadInt32();
                        if (line > max)
                        {
                            max = line;
                            maxPos = br.BaseStream.Position - 4;
                        }
                    }
                    poslPos = br.BaseStream.Position - 4;
                    posl = line;
                }
            }
            FileStream fs2 = new FileStream("cisla.dat", FileMode.Open, FileAccess.ReadWrite);
            FileStream fs3 = new FileStream("prvocisla.dat", FileMode.Create, FileAccess.Write);
            using (BinaryWriter bw2 = new BinaryWriter(fs2))
            {
                bw2.BaseStream.Position = maxPos;
                bw2.Write(posl);
                bw2.BaseStream.Position = poslPos;
                bw2.Write(max);
                using (BinaryWriter bw3 = new BinaryWriter(fs3))
                {
                    using (BinaryReader br = new BinaryReader(fs2))
                    {
                        using(StreamWriter sw = new StreamWriter("prvocisla.txt"))
                        {
                            br.BaseStream.Seek(0, SeekOrigin.Begin);
                            while (br.BaseStream.Position < br.BaseStream.Length)
                            {
                                int line = br.ReadInt32();
                                listBox2.Items.Add(line);
                            
                                bool prvocis = true;
                                if (line == 1 || line > 2 && line % 2 == 0) prvocis = false;
                                else for (int del = 3; del <= Math.Sqrt(line) && prvocis; del += 2)
                                {
                                    if (line % del == 0) prvocis = false;
                                }
                                if (prvocis)
                                {
                                    bw3.Write(line);
                                    sw.WriteLine(line);
                                    listBox3.Items.Add(line);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
