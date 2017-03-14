using System.Collections.Generic;
using System.Data.SqlClient;
using TvHelper.Domain.Extensions;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Repositories
{
    public class VideoRepository
    {
        public List<Video> GetAllVideo()
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
                    var video = new Video();

                    video.Title = reader.GetString(1);
                    video.SeasonNr = reader.GetInt32(2);
                    video.EpisodeNr = reader.GetInt32(5);

                    video.StartTime = reader.GetDateTimeNullCheck(3);
                    video.Path = reader.GetString(6);

                    list.Add(video);
                }
            }


            return list;
        }
    }
}