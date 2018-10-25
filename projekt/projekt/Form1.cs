using projekt.classes;
using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace projekt
{


    public partial class Form1 : Form
    {
        public static string[] Category = new string[]{"Konst","Komedi","Utbildning","Spel",
        "Hälsa","Musik","Politik","Samhälle","Sport","Teknologi","Skräck"};

        private Validering Validering;
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CBKatigorier();
        }


        //en metod för att fylla combo boxen med olika alternativ ///
        public void CBKatigorier()
        {
            foreach (string cato in Category)
            {
                cbCate.Items.Add(cato);
                comboBox3.Items.Add(cato);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            var Url = tbUrl.Text;
            var s = tbUF.Text;
            int frekvens = 0;
            int.TryParse(s, out frekvens);

            var category = cbCate.Items.ToString();
    
    
    }

        private void getXmlOfUrl(string url)
        {

        }


    }
}



