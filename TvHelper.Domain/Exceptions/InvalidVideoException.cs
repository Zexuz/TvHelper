using System;

namespace TvHelper.Domain.Exceptions
{
    public class InvalidVideoException:Exception
    {
        public InvalidVideoException(string msg) : base(msg)
        {

        }

    }
}