using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace PrestareServiciiDomiciliu
{
    public partial class Form3 : Form
    {
        private XmlDocument doc = new XmlDocument();   //se initializeaza campurile folosie

        static List<string> numeEchipa = new List<string>();
        static List<string> numeStadion = new List<string>();
        static List<string> numeArbitru = new List<string>();
        static List<string> scor = new List<string>();

        static List<string> numeEchipa1 = new List<string>();
        static List<string> numeEchipa2 = new List<string>();

        private int NrEchipe;

        public Form3()
        {
            InitializeComponent();
        }

        public void CautaDate() //functie in cadrul careia se cauta datele afisate si anume : nume echipa, nume stadion, nume arbitru si scor; aceste date se vor afisa ulteriol in tabela (dataGridView1).
        {
            XElement xml = XElement.Load("Campionat.xml.xml");

            IEnumerable<XElement> campionat = xml.Elements();

            foreach (XElement echipa in campionat) // din fisierul xml se extrage numele tuturor echipelor si se salveaza intr o lista "numeEchipa"
            {
                numeEchipa = new List<string>();
                numeEchipa.Clear();
                {
                    foreach (XElement numep in echipa.Descendants("nume_echipa"))
                    {
                        numeEchipa.Add((String)numep);
                    }
                }
                NrEchipe = numeEchipa.Count();
            }
            foreach (XElement echipa in campionat) //din fisierul xml se extrage numele tuturor stadioanelor pe care se joaca meciurile si se salveaza intr o lista "numeStadion"
            {
                numeStadion = new List<string>();
                numeStadion.Clear();
                {
                    foreach (XElement numeA in echipa.Descendants("nume_stadion"))
                    {
                        numeStadion.Add((String)numeA);
                    }
                }
            }
            foreach (XElement echipa in campionat) // din fisierul xml se extrage numele tuturor arbitrilor si se salveaza intr o lista "numeArbitru"
            {
                numeArbitru = new List<string>();
                numeArbitru.Clear();
                {
                    foreach (XElement numeA in echipa.Descendants("nume_arbitru"))
                    {
                        numeArbitru.Add((String)numeA);
                    }
                }
            }
            doc.Load("Campionat.xml.xml");

            XmlNodeList elemList = doc.GetElementsByTagName("scor"); // din fisierul xml se extrage scorul fiecarui meci si se salveaza intr o lista "scor"
            scor = new List<string>();

            for (int i = 0; i < elemList.Count; i++)
            {
                scor.Add(elemList[i].Attributes["val"].Value);
            }
        }

        private void button5_Click(object sender, EventArgs e) //butonul Iesire ce duce la pagina anterioana
        {
            Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e) // se afiseaza meciurile , stadionul pe care s-a jucat fiecare meci, scorul si arbitrul pentru grupa A
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Echipa";
            dataGridView1.Columns[1].Name = "Echipa";
            dataGridView1.Columns[2].Name = "Scor";
            dataGridView1.Columns[3].Name = "Stadion";
            dataGridView1.Columns[4].Name = "Arbitru";

            CautaDate();

            for (int i = 0; i < 8; i = i + 2)
            {
                numeEchipa1.Add((String)numeEchipa[i]);
            }

            for (int i = 1; i < 8; i = i + 2)
            {
                numeEchipa2.Add((String)numeEchipa[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                numeStadion.Add((String)numeStadion[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                numeArbitru.Add((String)numeArbitru[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                scor.Add((String)scor[i]);
            }

            for (int j = 0; j < 4; j++)
            {
                string[] rand = new string[] { numeEchipa1[j], numeEchipa2[j], scor[j], numeStadion[j], numeArbitru[j] };
                dataGridView1.Rows.Add(rand);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button2_Click(object sender, EventArgs e)  // se afiseaza meciurile , stadionul pe care s-a jucat fiecare meci, scorul si arbitrul pentru grupa B
        {
            List<string> numeS = new List<string>();
            List<string> numeA = new List<string>();
            List<string> sc = new List<string>();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Echipa";
            dataGridView1.Columns[1].Name = "Echipa";
            dataGridView1.Columns[2].Name = "Scor";
            dataGridView1.Columns[3].Name = "Stadion";
            dataGridView1.Columns[4].Name = "Arbitru";

            CautaDate();

            for (int i = 8; i < 16; i = i + 2)
            {
                numeEchipa1.Add((String)numeEchipa[i]);
            }

            for (int i = 9; i < 16; i = i + 2)
            {
                numeEchipa2.Add((String)numeEchipa[i]);
            }

            for (int i = 4; i < 8; i++)
            {
                numeS.Add((String)numeStadion[i]);
            }

            for (int i = 4; i < 8; i++)
            {
                numeA.Add((String)numeArbitru[i]);
            }

            for (int i = 4; i < 8; i++)
            {
                sc.Add((String)scor[i]);
            }

            for (int j = 0; j < 4; j++)
            {
                string[] rand = new string[] { numeEchipa1[j], numeEchipa2[j], sc[j], numeS[j], numeA[j] };
                dataGridView1.Rows.Add(rand);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button3_Click(object sender, EventArgs e) // se afiseaza meciurile , stadionul pe care s-a jucat fiecare meci, scorul si arbitrul pentru grupa C
        {
            List<string> numeS = new List<string>();
            List<string> numeA = new List<string>();
            List<string> sc = new List<string>();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Echipa";
            dataGridView1.Columns[1].Name = "Echipa";
            dataGridView1.Columns[2].Name = "Scor";
            dataGridView1.Columns[3].Name = "Stadion";
            dataGridView1.Columns[4].Name = "Arbitru";

            CautaDate();

            for (int i = 20; i < 28; i = i + 2)
            {
                numeEchipa1.Add((String)numeEchipa[i]);
            }

            for (int i = 21; i < 28; i = i + 2)
            {
                numeEchipa2.Add((String)numeEchipa[i]);
            }

            for (int i = 10; i < 14; i++)
            {
                numeS.Add((String)numeStadion[i]);
            }

            for (int i = 10; i < 14; i++)
            {
                numeA.Add((String)numeArbitru[i]);
            }

            for (int i = 10; i < 14; i++)
            {
                sc.Add((String)scor[i]);
            }

            for (int j = 0; j < 4; j++)
            {
                string[] rand = new string[] { numeEchipa1[j], numeEchipa2[j], sc[j], numeS[j], numeA[j] };
                dataGridView1.Rows.Add(rand);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button4_Click(object sender, EventArgs e) // se afiseaza meciurile , stadionul pe care s-a jucat fiecare meci, scorul si arbitrul pentru grupa D
        {
            List<string> numeS = new List<string>();
            List<string> numeA = new List<string>();
            List<string> sc = new List<string>();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Echipa";
            dataGridView1.Columns[1].Name = "Echipa";
            dataGridView1.Columns[2].Name = "Scor";
            dataGridView1.Columns[3].Name = "Stadion";
            dataGridView1.Columns[4].Name = "Arbitru";

            CautaDate();

            for (int i = 32; i < 40; i = i + 2)
            {
                numeEchipa1.Add((String)numeEchipa[i]);
            }

            for (int i = 33; i < 40; i = i + 2)
            {
                numeEchipa2.Add((String)numeEchipa[i]);
            }

            for (int i = 16; i < 20; i++)
            {
                numeS.Add((String)numeStadion[i]);
            }

            for (int i = 16; i < 20; i++)
            {
                numeA.Add((String)numeArbitru[i]);
            }

            for (int i = 16; i < 20; i++)
            {
                sc.Add((String)scor[i]);
            }

            for (int j = 0; j < 4; j++)
            {
                string[] rand = new string[] { numeEchipa1[j], numeEchipa2[j], sc[j], numeS[j], numeA[j] };
                dataGridView1.Rows.Add(rand);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
