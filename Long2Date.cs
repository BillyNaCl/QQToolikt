namespace BillyNaCl.StaticUtils.Long2Date
{
    public static class Long2Date
    {
        public static string Long2Date_ymd(this long UNIXTime) 
            => DateTimeOffset.FromUnixTimeSeconds(UNIXTime).LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss");

        public static string Long2Date_dmy(this long UNIXTime)
            => DateTimeOffset.FromUnixTimeSeconds(UNIXTime).LocalDateTime.ToString("dd-MM-yyyy HH:mm:ss");

        public static string Long2Date_mdy(this long UNIXTime)
            => DateTimeOffset.FromUnixTimeSeconds(UNIXTime).LocalDateTime.ToString("MM-dd-yyyy HH:mm:ss");

        public static string Long2Date_cn(this long UNIXTime)
            => DateTimeOffset.FromUnixTimeSeconds(UNIXTime).LocalDateTime.ToString("yyyy年MM月dd日HH:mm:ss");
    }
}
