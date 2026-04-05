namespace BillyNaCl.StaticUtils.Long2Date
{
    public static class Long2Date
    {
        public static string Long2Date_ymd(this long UNIXTime) 
            => UNIXTime.ToString("yyyy-MM-dd HH:mm:ss");

        public static string Long2Date_dmy(this long UNIXTime)
            => UNIXTime.ToString("dd-MM-yyyy HH:mm:ss");

        public static string Long2Date_mdy(this long UNIXTime)
            => UNIXTime.ToString("MM-dd-yyyy HH:mm:ss");

        public static string Long2Date_cn(this long UNIXTime)
            => UNIXTime.ToString("yyyy年MM月dd日HH:mm:ss");
    }
}
