namespace TvHelper.Models
{
    public class Video
    {
        public string Title { get; set; }
        public string SeasonNr { get; set; }
        public string EpisodeNr { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            return $"{Title} S{SeasonNr}E{EpisodeNr}";
        }
    }
}