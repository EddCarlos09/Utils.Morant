using Microsoft.IdentityModel.Tokens;

namespace Utils.Morant.Utils
{
    public static class DateTimeMxExt
    {
        public static DateTime? ToMxDateTime(this DateTime? dateTimeUtc)
        {
            if (dateTimeUtc.HasValue)
            {
                var mxTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
                var mxTime = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc.Value, mxTimeZone);
                return mxTime;
            }
            else return dateTimeUtc;
        }
    }
}
