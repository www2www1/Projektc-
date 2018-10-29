using System;
using System.Net;
using System.Text;
using System.Xml;

namespace projekt
{

    public class Data

    {
        Form1 ss = new Form1();
        public Data() { }

        //    public void serializePodcast(string Url, int frekvens, string category)
        //    {
        //        sparaLocalt(Url);

        //    int antal = 0;
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(@"podcast.xml");


        //        ///här hämtar vi podcast namn av url //
        //        var podCastName = doc.DocumentElement.SelectSingleNode("channel/title");
        //    ///här hämtar vi en lista av avsnitt som podcasten har i sig///
        //    var ListOFEpisode = new List<Episode>();
        //        foreach (XmlNode item in doc.DocumentElement.SelectNodes("channel/item"))
        //        {
        //            antal++;
        //            var Name = item.SelectSingleNode("title").InnerText;
        //    var description = item.SelectSingleNode("description").InnerText;
        //    ListOFEpisode.Add(new Episode(description, Name));

        //        }

        //var allpodcast = new List<Podcast>();
        //allpodcast.Add(new Podcast(Url, category, frekvens, ListOFEpisode, antal));



        //        Stream strea = File.OpenWrite(Environment.CurrentDirectory + "\\podcast.xml");
        //XmlSerializer serializer = new XmlSerializer(typeof(List<Podcast>));
        //serializer.Serialize(strea, ListOFEpisode);
        //        strea.Close();
        //    }




        //för att hämta xml rss o spara den i en xml lockalt///
        public string[,] Sercher(string url)
        {
                int x = 1;

            string Stringxml = "";
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                Stringxml = client.DownloadString(url);

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(Stringxml);
                System.Xml.XmlNodeList rssItems = xml.SelectNodes("rss/channel/item");


                string[,] tempRssData = new string[200,2];
              
                for (int i = 0; i < tempRssData.Length; i++)
                {
                    x++;
                    

                    System.Xml.XmlNode rssNodeTitle = rssItems.Item(i).SelectSingleNode("title");

                    if (rssNodeTitle != null)
                    {
                        tempRssData[i, 0] = rssNodeTitle.InnerText;

                    }
                    else
                    {
                        tempRssData[i, 0] = "";
                        break;
                    }
                }
                for (int i = 0; i < tempRssData.Length; i++)
                {
                    x++;
                    System.Xml.XmlNode rssnodeDes = rssItems.Item(i).SelectSingleNode("description");
                    if (rssnodeDes != null)
                    {
                        tempRssData[i, 1] = rssnodeDes.InnerText;
                      
                    }
                    else
                    {
                        tempRssData[i, 1] = "";
                    }
                }
                return tempRssData;
            }

            
        }




    }
}










