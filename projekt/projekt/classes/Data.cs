using projekt.classes;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace projekt
{
 
    public class Data
    {
        public Data() { }
 
        public void serializePodcast(string Url, int frekvens, string category)
        {    Directory.CreateDirectory(@"\classes\datalagring\");

            //string path = @"\classes\datalagring\";
            string xmllocalstored = @"\classes\datalagring\xml.xml";
            int antal = 0;
            string xml = "";
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                xml = client.DownloadString(Url);
            }
            var dd = new System.Xml.XmlDocument();
            dd.LoadXml(xml);

            ///här hämtar vi podcast namn av url //
            var podCastName = dd.DocumentElement.SelectSingleNode("channel/title");
            ///här hämtar vi en lista av avsnitt som podcasten har i sig///
            var ListOFEpisode = new List<Episode>();
            foreach (XmlNode item in dd.DocumentElement.SelectNodes("channel/item"))
            {
                antal++;
                var Name = item.SelectSingleNode("title").InnerText;
                var description = item.SelectSingleNode("description").InnerText;
                ListOFEpisode.Add(new Episode(description, Name));
            }

            var allpodcast = new List<Podcast>();
            allpodcast.Add(new Podcast(Url, category, frekvens, ListOFEpisode, antal));




            var serializer = new XmlSerializer(typeof(AllPodcasts));
            using (var st = new StreamWriter(xmllocalstored))
            {
                serializer.Serialize(st, allpodcast);
            }

        }


    }


    //public void disSerializePodCast()
    //{

    //}

}

