using System;

namespace TvHelper.Models
{
    public class Video
    {
        public string Title { get; set; }
        public int SeasonNr { get; set; }
        public int EpisodeNr { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan WatchedTime { get; set; }
        public TimeSpan Duration { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            return $"{Title} S{SeasonNr}E{EpisodeNr}";
        }
    }
}