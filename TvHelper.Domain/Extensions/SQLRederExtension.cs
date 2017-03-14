using System;
using System.Data;

namespace TvHelper.Domain.Extensions
{
    public static class SqlRederExtension
    {
        public static string GetStringNullCheck(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public static DateTime GetDateTimeNullCheck(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? DateTime.MinValue : reader.GetDateTime(ordinal);
        }
    }
}