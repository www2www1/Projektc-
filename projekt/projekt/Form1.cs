using projekt.classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace projekt
{


    public partial class Form1 : Form
    {
        public static List<string> Category = new List<string>{"Konst","Komedi","Utbildning","Spel",
        "Hälsa","Musik","Politik","Samhälle","Sport","Teknologi","Skräck"};

        public Dictionary<string, int> source = new Dictionary<string, int>();
        public Data ss;
        public String[,] rssData = null;
        public Validering validator = new Validering();
        public AllaFeeds AllFeeds;
        public RssFeed Rss;
        public List<RssFeed> listofRss;
        public Form1()
        {
            InitializeComponent();
            // Gör så att hela raden markeras när man väljer den:
            source.Add("Hourly", 3600000);
            source.Add("Daily", 3600000 * 24);
            source.Add("Weekly", 3600000 * 96);
            lvPodcast.FullRowSelect = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ListOfEpisodes = new List<Episode>();
            var podcast = new Podcast();
            var Allfeeds = new AllaFeeds();


            XmlDocument doc = new XmlDocument();
            doc.Load("Feeds.xml");
            System.Xml.XmlNodeList rssItems = doc.SelectNodes("ArrayOfRssFeed/RssFeed");
            foreach (XmlNode RssFeed in rssItems)
            {
                var UrlRss = RssFeed.SelectSingleNode("Url").InnerText;
                var UpdatingRss = RssFeed.SelectSingleNode("Updating").InnerText;
                var CateRss = RssFeed.SelectSingleNode("Category").InnerText;


                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(UrlRss);
                System.Net.WebResponse myResponse = myRequest.GetResponse();

                System.IO.Stream rssStream = myResponse.GetResponseStream();
                System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();

                rssDoc.Load(rssStream);
                System.Xml.XmlNode rssName = rssDoc.SelectSingleNode("rss/channel");
                var podcastName = rssName.InnerText;
                System.Xml.XmlNodeList xx = rssDoc.SelectNodes("rss/channel/item");
                int antalEpisoder = xx.Count;

                string[] RowPodCast = { antalEpisoder.ToString(), podcastName, UpdatingRss.ToString(), CateRss, UrlRss };
                var listItem = new ListViewItem(RowPodCast);
                lvPodcast.Items.Add(listItem);

            }
            CBKatigorier();
            UpdateInterval(tbUF);
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
        {
            var datan = new Data();



            var Url = tbUrl.Text;

            lbEpisode.Items.Clear();
            rssData = getRssData(tbUrl.Text);
            for (int i = 0; i < rssData.GetLength(0); i++)
            {

                if (rssData[i, 0] != null)
                {
                    lbEpisode.Items.Add(rssData[i, 0]);


                }


            }
        }


        //spara feedden 
        private void btUrlSpara_Click(object sender, EventArgs e)
        {
            var Validering = validator;
            var Url = tbUrl.Text;


            if (Validering.validateCategory(CBC) && Validering.intervalBoxNotEmpty(tbUF))
            {


                string category = CBC.SelectedItem.ToString();
                var s = tbUF.SelectedItem.ToString();
                int.TryParse(s, out int frekvens);

                if (Validering.urlValidation(Url))
                {
                    var listOfFeeds = new AllaFeeds();
                    listOfFeeds.allaFeeds(new RssFeed(Url, frekvens, category));
                }

            }
        }


        private void lvPordast_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        public void listviwed(string[,] getRssData)
        {
            lbEpisode.Items.Clear();

            for (int i = 0; i < getRssData.GetLength(0); i++)
            {

                if (getRssData[i, 0] != null)
                {
                    var listItem = new ListViewItem(
                        new[] {
                            getRssData[i, 0]
                        }
                        );
                    lbEpisode.Items.Add(listItem);


                }


            }

        }

        private void btUrlTaBort_Click(object sender, EventArgs e)
        {
            string sss = lvPodcast.SelectedItems[0].SubItems[4].Text;
            XmlDocument doc = new XmlDocument();
            doc.Load("Feeds.xml");
            System.Xml.XmlNodeList rssItems = doc.SelectNodes("ArrayOfRssFeed/RssFeed");

            foreach (XmlNode node in rssItems)
            {
                System.Xml.XmlNode rssNodeTitle = node.SelectSingleNode("Url");
                if (rssNodeTitle.InnerText == sss)
                {
                    XmlNode parent = node.ParentNode;
                    parent.RemoveChild(node);
                }

            }


            doc.Save("Feeds.xml");

        }

        private String[,] getRssData(String channel)
        {
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
            System.Net.WebResponse myResponse = myRequest.GetResponse();

            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();

            rssDoc.Load(rssStream);
            System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");



            String[,] tempRssData = new String[rssItems.Count, 3];
            for (int i = 0; i < rssItems.Count; i++)
            {


                System.Xml.XmlNode rssNode;
                rssNode = rssItems.Item(i).SelectSingleNode("title");

                if (rssNode != null)
                {

                    tempRssData[i, 0] = rssNode.InnerText;

                }
                else
                {
                    tempRssData[i, 0] = "";

                }

                rssNode = rssItems.Item(i).SelectSingleNode("description");
                if (rssNode != null)
                {
                    tempRssData[i, 1] = rssNode.InnerText;

                }
                else
                {
                    tempRssData[i, 1] = "";
                }

                rssNode = rssItems.Item(i).SelectSingleNode("link");
                if (rssNode != null)
                {
                    tempRssData[i, 2] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 2] = "";
                }

            }
            return tempRssData;
        }

        private void lbEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbEpisode.SelectedIndex;
            richTextBox1.Text = rssData[index, 1];
            linkLabel.Text = rssData[index, 2];
        }


        private void btSpara_Click(object sender, EventArgs e)
        {

            var sss = tbUrl.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load("Feeds.xml");
            System.Xml.XmlNodeList rssItems = doc.SelectNodes("ArrayOfRssFeed/RssFeed");

            foreach (XmlNode node in rssItems)
            {
                System.Xml.XmlNode rssNodeTitle = node.SelectSingleNode("Category");
                if (rssNodeTitle.InnerText == sss)
                {
                    XmlNode parent = node.ParentNode;
                }
            }
            doc.Save("Feeds.xml");

        }

        private void tbUF_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        public void UpdateInterval(ComboBox boxen)
        {

            foreach (var item in source)
            {
                boxen.Items.Add(item.Key);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btNy_Click(object sender, EventArgs e)
        {
            if (comboBox3.Items.Contains(textBox1.Text))
            {
                MessageBox.Show("Vänligen ange en kategori som inte finns");
            }
            else
            {
                MessageBox.Show("Kategorin har lagts till");
                CBC.Items.Add(textBox1.Text);
                comboBox3.Items.Add(textBox1.Text);

            }
            //UpdateInterval(tbUF);

        }

        private void lvPodcast_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            lbEpisode.Items.Clear();
            if (lvPodcast.SelectedItems.Count > 0)
            {
                string url = lvPodcast.SelectedItems[0].SubItems[4].Text;

                rssData = getRssData(url);

                listviwed(rssData);
            }
        }

        private void btTaBort_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The following category has been removed : " + comboBox3.Text);
            CBC.Items.Remove(comboBox3.Text);
            comboBox3.Items.Remove(comboBox3.Text);
        }
    }
    }





