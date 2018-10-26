using projekt.classes;
using System;
using System.Windows.Forms;

namespace projekt
{


    public partial class Form1 : Form
    {
        public static string[] Category = new string[]{"Konst","Komedi","Utbildning","Spel",
        "Hälsa","Musik","Politik","Samhälle","Sport","Teknologi","Skräck"};


    
     


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
                //cbCate.Items.Add(cato);
                comboBox3.Items.Add(cato);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
           var xx=new Data ();
        var Url = tbUrl.Text;
            var s = tbUF.Text;
           
            int.TryParse(s, out int frekvens);
             
            string category = textBox2.Text;


            xx.serializePodcast(Url, frekvens, category);

        }

    


    }
}



