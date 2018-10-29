﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace projekt.classes
{
    class AllaFeeds
    {
        List<RssFeed> ListOfFeeds = new List<RssFeed>();

        public void ALlaFeeds(RssFeed feed)
        {
            if (File.Exists(@"Feeds.xml"))

            {
                ReadFreomXmlFile();
                ListOfFeeds.Add(feed);
                SaveToXmlFile();
            }
            else
            {
                ListOfFeeds.Add(feed);
                SaveToXmlFile();
            }
        }


        public void DeleteFeed(RssFeed Feed)
        {
            foreach (RssFeed dd in ListOfFeeds)
            {
                if (dd.Url == Feed.Url)
                {
                    ListOfFeeds.Remove(Feed);
                    SaveToXmlFile();

                }
            }

        }
        public void SaveToXmlFile()
        {
            StreamWriter writer = new StreamWriter(@"Feeds.xml");
            XmlSerializer xs = new XmlSerializer(typeof(List<RssFeed>));
            xs.Serialize(writer, ListOfFeeds);
            writer.Close();
        }


        public void ReadFreomXmlFile()
        {
            StreamReader redaer = new StreamReader(@"Feeds.xml");
            XmlSerializer xs = new XmlSerializer(typeof(List<RssFeed>));
            ListOfFeeds = (List<RssFeed>)xs.Deserialize(redaer);
            redaer.Close();

        }
    }


}
