using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt.classes
{


    class Podcast

    {
        public string Url { get; set; }
        public string CategoryOfPodcast { set; get; }
        public int TimeInterval { get; set; }
        public string NameOfPodCast { get; set; }
        public List<Episode> ListOFEpisode = new List<Episode>();

        public Podcast(string Url, string CategoryOfPodcast, int TimeInterval, List<Episode> ListOFEpisode)
        {
            this.Url = Url;
            this.CategoryOfPodcast = CategoryOfPodcast;
            this.TimeInterval = TimeInterval;
            this.ListOFEpisode = ListOFEpisode;
        }
    }
}



