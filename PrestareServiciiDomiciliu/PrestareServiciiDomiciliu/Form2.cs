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
    public partial class Form2 : Form
    {
        private string an;
        private string aux;

        private int NrEchipe;

        private XmlDocument doc = new XmlDocument();

        static List<string> nume = new List<string>();

        public Form2()  // initializare Form2
        {
            InitializeComponent();
            //functie cu rolul de incarcare a fisierului XML
            doc.Load("PrestareServiciiDomiciliu.xml"); 

            //se initializeaza un nod de tipul XmlNodeList si se ia cel cu numele planificare
            XmlNodeList elemList = doc.GetElementsByTagName("planificare");   
            for (int i = 0; i < elemList.Count; i++)
            {
                an = elemList[i].Attributes["AN"].Value;
                aux = elemList[i].ChildNodes[i].InnerText;
            }
           

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
        }
        //functie pentru popularea campurilor ce necesita echipe..se vor popula toate echipele..//ce prezinta tagul <nume_echipa>
        public void CautaEchipe() 
        {
            XElement xml = XElement.Load("PrestareServiciiDomiciliu.xml");

            IEnumerable<XElement> campionat = xml.Elements();

            foreach (XElement echipa in campionat)
            {
                nume = new List<string>(); //lista ce contine numele echipelor
                nume.Clear();
                {
                    foreach (XElement numep in echipa.Descendants("nume_echipa")) 
                    {
                        nume.Add((String)numep); //adaugare in lista
                    }
                }

                NrEchipe = nume.Count();
            }
        }

        private void button1_Click(object sender, EventArgs e) // buton pentru vizualizarea echipelor de curatenie
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Echipe de curatenie";

            CautaEchipe();

            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows.Add(nume[i]);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button2_Click(object sender, EventArgs e) // buton pentru vizualizarea echipelor de coafura
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Echipe de coafura";

            CautaEchipe();

            for (int i = 8; i < 12; i++)
            {
                dataGridView1.Rows.Add(nume[i]);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void button3_Click(object sender, EventArgs e) // definire Buton pentru vizualizarea echipelor responsabile cu amenajarile interioare
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Echipe amenajari interioare";

            CautaEchipe();

            for (int i = 17; i < 21; i++)
            {
                dataGridView1.Rows.Add(nume[i]);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button4_Click(object sender, EventArgs e) // //definire Buton pentru vizualizarea echipelor de manichiura/pedichiura
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Echipe salon";

            CautaEchipe();

            for (int i = 22; i < NrEchipe; i++)
            {
                dataGridView1.Rows.Add(nume[i]);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button5_Click(object sender, EventArgs e) //buton ce initializeaza Form1 ..initializare meniu principal
        {
            Hide();
            new Form1().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
