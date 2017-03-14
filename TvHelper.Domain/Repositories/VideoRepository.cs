using System.Collections.Generic;
using System.Data.SqlClient;
using TvHelper.Domain.Extensions;
using TvHelper.Domain.Interfaces;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        public List<Video> GetAllVideosFromDatabase()
        {
            var connectionString = "Data Source=DESKTOP-4LSH009\\SQLEXPRESS02;" +
                                   "Initial Catalog=tvhelper;" +
                                   "User id=sa;" +
                                   "Password=test;";
            var conn = new SqlConnection(connectionString);

            conn.Open();

            var command = new SqlCommand("SELECT * FROM WatchedVideos", conn);

            var list = new List<Video>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var video = new Video
                    {
                        Title = reader.GetString(1),
                        SeasonNr = reader.GetInt32(2),
                        EpisodeNr = reader.GetInt32(5),
                        StartTime = reader.GetDateTimeNullCheck(3),
                        Path = reader.GetString(6)
                    };

                    list.Add(video);
                }
            }


            return list;
        }

        public void InsertVideos(List<Video> newVideos)
        {
            var connectionString = "Data Source=DESKTOP-4LSH009\\SQLEXPRESS02;" +
                                   "Initial Catalog=tvhelper;" +
                                   "User id=sa;" +
                                   "Password=test;";
            var conn = new SqlConnection(connectionString);

            conn.Open();


            var queryString = "";

            foreach (var video in newVideos)
            {
                queryString +=
                    "INSERT INTO tvhelper.dbo.WatchedVideos (Title, Season, [StartTime], WatchedTime, Episode, FilePath, DurationInSec)" +
                    $"VALUES ('{video.Title}', {video.SeasonNr}, NULL, NULL, {video.EpisodeNr},'{video.Path}',NULL)";
            }

            var command = new SqlCommand(queryString, conn);
            command.ExecuteReader();
        }
    }
}