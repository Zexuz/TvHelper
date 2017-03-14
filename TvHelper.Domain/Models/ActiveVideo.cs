using System;

namespace TvHelper.Domain.Models
{
    public class ActiveVideo : Video
    {
        public bool IsPlaying { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan CurrentPosition { get; set; }
    }
}