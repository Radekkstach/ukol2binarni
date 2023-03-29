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
                
                    int osc = Convert.ToInt32(polozky[0]);
                    string jmeno = polozky[1];
                    string prijmeni = polozky[2];
                    char pohlavi = Convert.ToChar(polozky[3]);
                    int vyska = Convert.ToInt32(polozky[4]);
                    int hmotnost = Convert.ToInt32(polozky[5]);

                    bw.Write(osc);
                    bw.Write(jmeno);
                    bw.Write(prijmeni);
                    bw.Write(pohlavi);
                    bw.Write(vyska);
                    bw.Write(hmotnost);

                
               
            }
             
            
            br.BaseStream.Position = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {

                string linetextbox = "" + br.ReadInt32() + ";" + br.ReadString() + ";" + br.ReadString() +
                                                                                    ";"
                                            + br.ReadChar() + ";" + br.ReadInt32() + ";" + br.ReadInt32();
                textBox1.AppendText(linetextbox + Environment.NewLine);

            }
            br.Close();
            bw.Close();
            ctenitxt.Close();
            fs.Close();
            
           
           
        }
    }
}
