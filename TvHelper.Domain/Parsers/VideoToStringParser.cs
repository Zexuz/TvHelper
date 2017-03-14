using System;
using TvHelper.Domain.Exceptions;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Servicies
{
    public class VideoToStringParser
    {

        public string ToSortString(Video video)
        {

            var epsideoString = video.EpisodeNr.ToString();
            var seasonString = video.SeasonNr.ToString();

            if(epsideoString.Equals(string.Empty))
            {
                throw new InvalidVideoException("The episode number can not nu empty");
            }

            if(seasonString.Equals(string.Empty))
            {
                throw new InvalidVideoException("The season number can not nu empty");
            }

            if(seasonString.Length == 1)
            {
                seasonString = "0" + seasonString;
            }


            if(epsideoString.Length == 1)
            {
                epsideoString = "0" + epsideoString;
            }

            return $"{video.Title} S{seasonString}E{epsideoString}";
        }
    }
}