﻿using System;
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

        public Form2()  // se va afisa anul campionatului si tara gazda
        {
            InitializeComponent();

            doc.Load("PrestareServiciiDomiciliu.xml"); //se incarca fisierul /xml

            XmlNodeList elemList = doc.GetElementsByTagName("planificare");  //se cauta in acesta si se iau : atributul AN al elementului "Planificare" 
            for (int i = 0; i < elemList.Count; i++)
            {
                an = elemList[i].Attributes["AN"].Value;
                aux = elemList[i].ChildNodes[i].InnerText;
            }
            // label2.Text = an;  //anul se afiseaza in label2
            // label4.Text = aux; // numele tarii se afiseaza in label 4

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
        }

        public void CautaEchipe() //functie ce umple campul "nume" de tip lista cu numele echipelor din fisierul xml ;
        {
            XElement xml = XElement.Load("PrestareServiciiDomiciliu.xml");

            IEnumerable<XElement> campionat = xml.Elements();

            foreach (XElement echipa in campionat)
            {
                nume = new List<string>();
                nume.Clear();
                {
                    foreach (XElement numep in echipa.Descendants("nume_echipa")) //se ia fiecare nume al echipei si se pune in lista "nume"
                    {
                        nume.Add((String)numep);
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
            dataGridView1.Columns[0].Name = "Membrii echipei de curatenie";

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
            dataGridView1.Columns[0].Name = "Membrii echipei de coafura";

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
            dataGridView1.Columns[0].Name = "Membrii echipa amenajari interioare";

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
            dataGridView1.Columns[0].Name = "Membrii echipa salon";

            CautaEchipe();

            for (int i = 22; i < NrEchipe; i++)
            {
                dataGridView1.Rows.Add(nume[i]);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button5_Click(object sender, EventArgs e) //butonul ce duce la pagina anterioara Start Page
        {
            Hide();
            new Form1().Show();
        }
    }
}