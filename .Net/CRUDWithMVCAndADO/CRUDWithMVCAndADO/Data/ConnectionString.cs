namespace CRUDWithMVCAndADO.Data
{
    public static class ConnectionString
    {
        private static string cs = "Server=LAPTOP-ASRK055L\\SQLEXPRESS; Database=crud; Trusted_Connection=True";

        public static string dbcs {
            get { return cs; }
        }


    }
}
