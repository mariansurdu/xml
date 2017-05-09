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
        private XmlDocument doc = new XmlDocument();   //creare camp privat de tip XML document pentru accesarea elementelor din fisierul xml

        //initializare liste pentru adaugarea datelor din fisier si afisarea acestora in interfata
        static List<string> numePersContact = new List<string>();
        static List<string> data_assign = new List<string>();
        static List<string> numeEchipa = new List<string>();
        static List<string> numeLocatie = new List<string>();
        static List<string> numeEchipa1 = new List<string>();
        static List<string> echipaUrgenta = new List<string>();




        private int NrEchipe;

        public Form3()
        {
            InitializeComponent();
        }

        public void Search() //cautare dupa nume_tag
        {
            XElement xml = XElement.Load("PrestareServiciiDomiciliu.xml");

            IEnumerable<XElement> companie = xml.Elements();

            foreach (XElement echipa in companie) // din fisierul xml se extrage numele tuturor echipelor din companie si se salveaza intr o lista "numeEchipa"
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
            foreach (XElement echipa in companie) 
            {
                numeLocatie = new List<string>();
                numeLocatie.Clear();
                {
                    foreach (XElement numeA in echipa.Descendants("adresa"))
                    {
                        numeLocatie.Add((String)numeA);
                    }
                }
            }
            foreach (XElement echipa in companie) 
            {
                numePersContact = new List<string>();
                numePersContact.Clear();
                {
                    foreach (XElement numeA in echipa.Descendants("nume_persoana_de_contact"))
                    {
                        numePersContact.Add((String)numeA);
                    }
                }
            }
            doc.Load("PrestareServiciiDomiciliu.xml");

            XmlNodeList elemList = doc.GetElementsByTagName("data_assign"); 
            data_assign = new List<string>();

            for (int i = 0; i < elemList.Count; i++)
            {
                data_assign.Add(elemList[i].Attributes["val"].Value);
            }
        }

        private void button5_Click(object sender, EventArgs e) //initialiare meniu principal
        {
            Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Echipa";
            dataGridView1.Columns[1].Name = "In caz de urgenta";
            dataGridView1.Columns[2].Name = "Data";
            dataGridView1.Columns[3].Name = "Adresa";
            dataGridView1.Columns[4].Name = "Persoana de contact";
            //campuri ce vor fi afisate in interfata cu datele aferenta in cadrul unei echipe sau assignment 
            numeEchipa1 = new List<string>();
            echipaUrgenta = new List<string>();

            Search();

            for (int i = 0; i < 7; i = i + 2)
            {
                numeEchipa1.Add((String)numeEchipa[i]);
            }

            for (int i = 1; i < 8; i = i + 2)
            {
                echipaUrgenta.Add((String)numeEchipa[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                numeLocatie.Add((String)numeLocatie[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                numePersContact.Add((String)numePersContact[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                data_assign.Add((String)data_assign[i]);
            }

            for (int j = 0; j < 4; j++)
            {
                string[] rand = new string[] { numeEchipa1[j], echipaUrgenta[j], data_assign[j], numeLocatie[j], numePersContact[j] };
                dataGridView1.Rows.Add(rand);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            List<string> numeS = new List<string>();
            List<string> numeA = new List<string>();
            List<string> sc = new List<string>();
            numeEchipa1 = new List<string>();
            echipaUrgenta = new List<string>();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Echipa";
            dataGridView1.Columns[1].Name = "In caz de urgenta";
            dataGridView1.Columns[2].Name = "Data";
            dataGridView1.Columns[3].Name = "Adresa";
            dataGridView1.Columns[4].Name = "Persoana de contact";

            Search();

            for (int i = 8; i < 15; i = i + 2)
            {
                numeEchipa1.Add((String)numeEchipa[i]);
            }

            for (int i = 9; i < 16; i = i + 2)
            {
                echipaUrgenta.Add((String)numeEchipa[i]);
            }

            for (int i = 4; i < 8; i++)
            {
                numeS.Add((String)numeLocatie[i]);
            }

            for (int i = 4; i < 8; i++)
            {
                numeA.Add((String)numePersContact[i]);
            }

            for (int i = 4; i < 8; i++)
            {
                sc.Add((String)data_assign[i]);
            }

            for (int j = 0; j < 4; j++)
            {
                string[] rand = new string[] { numeEchipa1[j], echipaUrgenta[j], sc[j], numeS[j], numeA[j] };
                dataGridView1.Rows.Add(rand);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            List<string> numeS = new List<string>();
            List<string> numeA = new List<string>();
            List<string> sc = new List<string>();
            numeEchipa1 = new List<string>();
            echipaUrgenta = new List<string>();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Echipa";
            dataGridView1.Columns[1].Name = "In caz de urgenta";
            dataGridView1.Columns[2].Name = "Data";
            dataGridView1.Columns[3].Name = "Adresa";
            dataGridView1.Columns[4].Name = "Persoana de contact";

            Search();

            for (int i = 17; i < 21; i = i + 1)
            {
                numeEchipa1.Add((String)numeEchipa[i]);
            }

            for (int i = 18; i < 22; i = i + 1)
            {
                echipaUrgenta.Add((String)numeEchipa[i]);
            }

            for (int i = 7; i < 11; i++)
            {
                numeS.Add((String)numeLocatie[i]);
            }

            for (int i = 6; i < 10; i++)
            {
                numeA.Add((String)numePersContact[i]);
            }

            for (int i = 8; i < 12; i++)
            {
                sc.Add((String)data_assign[i]);
            }

            for (int j = 0; j < 4; j++)
            {
                string[] rand = new string[] { numeEchipa1[j], echipaUrgenta[j], sc[j], numeS[j], numeA[j] };
                dataGridView1.Rows.Add(rand);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            List<string> numeS = new List<string>();
            List<string> numeA = new List<string>();
            List<string> sc = new List<string>();
            numeEchipa1 = new List<string>();
            echipaUrgenta = new List<string>();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Echipa";
            dataGridView1.Columns[1].Name = "In caz de urgenta";
            dataGridView1.Columns[2].Name = "Data";
            dataGridView1.Columns[3].Name = "Adresa";
            dataGridView1.Columns[4].Name = "Persoana de contact";

            Search();

            for (int i = 22; i < 24; i = i + 1)
            {
                numeEchipa1.Add((String)numeEchipa[i]);
            }

            for (int i = 24; i < 26; i = i + 1)
            {
                echipaUrgenta.Add((String)numeEchipa[i]);
            }

            for (int i = 10; i < 12; i++)
            {
                numeS.Add((String)numeLocatie[i]);
            }

            for (int i = 10; i < 12; i++)
            {
                numeA.Add((String)numePersContact[i]);
            }

            for (int i = 10; i < 12; i++)
            {
                sc.Add((String)data_assign[i]);
            }

            for (int j = 0; j < 2; j++)
            {
                string[] rand = new string[] { numeEchipa1[j], echipaUrgenta[j], sc[j], numeS[j], numeA[j] };
                dataGridView1.Rows.Add(rand);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
