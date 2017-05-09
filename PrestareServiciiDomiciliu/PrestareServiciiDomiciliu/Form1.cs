using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace PrestareServiciiDomiciliu
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        //actiune deschidere formular 2 pentru detalile de planificare
        private void button2_Click(object sender, EventArgs e) 
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.ShowDialog();
        }
        //initiailizare Form3 unde se poate vizualiza raportul aferent planificari
        private void button1_Click(object sender, EventArgs e)  
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {    //XslTransform
            XslTransform xslTransformer; 

            xslTransformer = new XslTransform();  
            xslTransformer.Load("prestare.xslt.xsl");
            xslTransformer.Transform("PrestareServiciiDomiciliu.xml", "prestareHtml.html");
            string dir = Directory.GetCurrentDirectory();
            Uri link = new Uri(String.Format("file:///{0}/prestareHtml.html", dir));
            webBrowser1.Navigate(link);
        }


        //buton iesire
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
