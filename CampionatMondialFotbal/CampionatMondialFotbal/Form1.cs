using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace CampionatMondialFotbal
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //Se va deschide Form -ul 2 unde se pot vedea detaliile despre campionat
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) ////Se va deschide Form -ul 3 unde se pot vedea meciurile jucate 
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) // butonul "Vezi Detalii Campionat" ce permite afisarea XSL-ului
        {
            XslTransform myXslTransform;  //se declara  XslTransform

            myXslTransform = new XslTransform();  // se initializeaza
            myXslTransform.Load("campionat.xslt.xsl"); //se incarca documentul .xsl
            myXslTransform.Transform("Campionat.xml.xml", "rezultat.html"); 
            string dir = Directory.GetCurrentDirectory();
            Debug.WriteLine("Locatie:  " + dir);
            Uri link = new Uri(String.Format("file:///{0}/rezultat.html", dir));
            webBrowser1.Navigate(link);
        }
    }
}
