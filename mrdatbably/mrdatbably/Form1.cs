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

namespace mrdatbably
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            StreamReader ctenitxt = new StreamReader("sport.txt");
            FileStream fs = new FileStream("sport.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);
            while (!ctenitxt.EndOfStream)
            {
                string radek = ctenitxt.ReadLine();
                string[] polozky = radek.Split(';');
                while ((radek = ctenitxt.ReadLine()) != null)
                {
                    int osc = int.Parse(polozky[0]);
                    string jmeno = polozky[1];
                    string prijmeni = polozky[2];
                    char pohlavi = char.Parse(polozky[3]);
                    int vyska = int.Parse(polozky[4]);
                    int hmotnost = int.Parse(polozky[5]);

                    bw.Write(osc);
                    bw.Write(jmeno);
                    bw.Write(prijmeni);
                    bw.Write(pohlavi);
                    bw.Write(vyska);
                    bw.Write(hmotnost);

                }
                
            }

            StringBuilder sb = new StringBuilder();
            br.BaseStream.Position = 0;
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                

                int osc = br.ReadInt32();
                string jmeno = br.ReadString();
                string prijmeni = br.ReadString();
                char pohlavi = br.ReadChar();
                int vyska = br.ReadInt32();
                int hmotnost = br.ReadInt32();

                sb.AppendFormat("{0};{1};{2};{3};{4};{5}\r\n", osc, jmeno, prijmeni, pohlavi, vyska, hmotnost);

            }

            textBox1.Text = sb.ToString();
            fs.Close();
            ctenitxt.Close();
        }
    }
}
