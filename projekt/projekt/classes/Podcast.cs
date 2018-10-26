using System.Collections.Generic;

namespace projekt.classes
{


    class Podcast

    {
        public string Url { get; set; }
        public string CategoryOfPodcast { set; get; }
        public int TimeInterval { get; set; }
        public string NameOfPodCast { get; set; }
        public List<Episode> ListOFEpisode = new List<Episode>();
        public int AllaEpisode { get; set; }

        public Podcast(string Url, string CategoryOfPodcast, int TimeInterval, List<Episode> ListOFEpisode, int AllaEpisode)
        {
            this.Url = Url;
            this.CategoryOfPodcast = CategoryOfPodcast;
            this.TimeInterval = TimeInterval;
            this.ListOFEpisode = ListOFEpisode;
            this.AllaEpisode = AllaEpisode;
        }
    }
}



