namespace com.smartwork.DataAccess
{
    /// <summary>
    /// The class is used to get connection infomation from config file.
    /// </summary>
    public static class ConnectionInfo
    {
        private static string dbPassword = DatabaseUtil.DBPassword;
        private static string dbUser = DatabaseUtil.DBUser;
        private static string dbServer = DatabaseUtil.DBHost;
        private static string dbDatabase = DatabaseUtil.DBInstance;
        private static string dbDatabaseType = DatabaseUtil.DBType;

        /// <summary>
        /// Get Connetion String
        /// </summary>
        /// <returns></returns>
        public static string GetConnString()
        {
            string databaseType;
            string connString;
            if (dbDatabaseType == "ORACLE")
            {
                databaseType = "MSDAORA";
                connString = "Provider=" + databaseType + ";Data Source=" + dbServer + ";User ID=" + dbUser + ";password=" + dbPassword + ";";
            }
            else if (dbDatabaseType == "MSSQL")
            {
                databaseType = "SQLOLEDB";
                connString = "Provider=" + databaseType + ";Data Source=" + dbServer + ";Initial Catalog=" + dbDatabase + ";User ID=" + dbUser + ";password=" + dbPassword + ";";
            }
            else
            {
                return "ERROR - DATABASE TYPE NOT SET";
            }

            return connString;
        }

        /// <summary>
        /// Get DbType String, ORACLE or MSSQL
        /// </summary>
        public static string DbType
        {
            get
            {
                return dbDatabaseType;
            }
        }
    }
}
