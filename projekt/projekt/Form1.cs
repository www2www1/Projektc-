using projekt.classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projekt
{


    public partial class Form1 : Form
    {
        public static string[] Category = new string[]{"Konst","Komedi","Utbildning","Spel",
        "Hälsa","Musik","Politik","Samhälle","Sport","Teknologi","Skräck"};

        public Data ss;

      

        public Form1()
        {
            InitializeComponent();
            // Gör så att hela raden markeras när man väljer den:
            lvEpisode.FullRowSelect = true;
            lvPordast.FullRowSelect = true;

          
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
                CBC.Items.Add(cato);
                comboBox3.Items.Add(cato);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {  var datan = new Data();
          
           

            var Url = tbUrl.Text;
          listviwed (datan.Sercher(Url));
            

        }
        public void listviwed(string[,] getRssData)
        {
            lvEpisode.Items.Clear();

            for (int i = 0; i < getRssData.GetLength(0); i++)
            {

                if (getRssData[i, 0] != null)
                {
                    var listItem = new ListViewItem(
                        new[] {
                            getRssData[i, 0],getRssData[i,1]
                        }
                        );
                    lvEpisode.Items.Add(listItem);


                }


            }

        }


        //spara feedden 
        private void btUrlSpara_Click(object sender, EventArgs e)
        {
            var Url = tbUrl.Text;
            var s = tbUF.Text;

            int.TryParse(s, out int frekvens);

            string category = CBC.SelectedItem.ToString();
            var listOfFeeds = new AllaFeeds();
            listOfFeeds.ALlaFeeds(new RssFeed(Url, frekvens, category));

        }

        private void lvPordast_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void lvEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


 
    }
}



