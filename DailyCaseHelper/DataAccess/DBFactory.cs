namespace com.smartwork.DataAccess
{
    using System;
    using System.Data.Common;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Text;

    /// <summary>
    /// DB related objects factory.
    /// </summary>
    public static class DBFactory
    {
        #region Fields

        /// <summary>
        /// const string for Oracle db type
        /// </summary>
        private const string Oracle = "ORACLE";

        /// <summary>
        /// const string for MS SQL db type
        /// </summary>
        private const string SqlServer = "MSSQL";

        #endregion Fields

        #region Methods

        public static DbDataAdapter CreateDataAdapter(string sql, DbConnection connection)
        {
            DbDataAdapter dataAdapter = null;

            if (connection is OracleConnection)
            {
                dataAdapter = new OracleDataAdapter(sql, connection as OracleConnection);
            }
            else
            {
                dataAdapter = new SqlDataAdapter(sql, connection as SqlConnection);
            }

            if (dataAdapter.SelectCommand != null &&
                dataAdapter.SelectCommand.Connection == null)
            {
                dataAdapter.SelectCommand.Connection = connection;
            }

            return dataAdapter;
        
        }

        /// <summary>
        /// Create the specific DbDataAdapter instance according to the database type
        /// </summary>
        /// <param name="sql">the select sentence</param>
        /// <returns>the new DataAdapter instance.</returns>
        public static DbDataAdapter CreateDataAdapter(string sql)
        {
            return CreateDataAdapter(sql, GetConnection());            
        }

        public static DbConnection GetConnection(string dbType, string connectionStr)
        {
            DbConnection connection = null;
            if (dbType == Oracle)
            {                
                connection = new OracleConnection(connectionStr);
            }
            else
            {                
                connection = new SqlConnection(connectionStr);
            }

            return connection;
        }

        /// <summary>
        /// Get data connection according to the database type settings.
        /// </summary>
        /// <returns>new instance of db connection</returns>
        public static DbConnection GetConnection()
        {
            string connString;
            if (DatabaseUtil.DBType == Oracle)
            {
                connString = "Data Source={0};User ID={1};password={2};Unicode=True";
                return new OracleConnection(string.Format(connString, DatabaseUtil.DBHost, DatabaseUtil.DBUser, DatabaseUtil.DBPassword));
            }
            else
            {
                connString = "Data Source={0};Initial Catalog={1};User ID={2};PWD={3};Persist Security Info=True;";
                return new SqlConnection(string.Format(connString, DatabaseUtil.DBHost, DatabaseUtil.DBInstance, DatabaseUtil.DBUser, DatabaseUtil.DBPassword));
            }
        }       

        /// <summary>
        /// Get data connection according to the database type settings.
        /// </summary>
        /// <param name="server">to connect database server</param>
        /// <param name="dbName">the name of the database to connect to</param>
        /// <param name="user">the user name used to connect to the specified database</param>
        /// <param name="password">the password used to connect to the specified database.</param>
        /// <returns>new instance of db connection</returns>
        public static DbConnection GetConnection(string dbType, string server,string dbName,string user,string password)
        {
            string connString;
            if (dbType == Oracle)
            {
                connString = "Data Source={0};User ID={1};password={2};Unicode=True";
                return new OracleConnection(string.Format(connString, server, user, password));
            }
            else
            {
                connString = "Data Source={0};Initial Catalog={1};User ID={2};PWD={3};Persist Security Info=True;";
                return new SqlConnection(string.Format(connString, server, dbName, user, password));
            }
        }

        /// <summary>
        /// get the string of condition to compare the date by column
        /// </summary>
        /// <param name="date">the date to compare</param>
        /// <param name="column">the db column to compare</param>
        /// <param name="operatorType">operation type</param>
        /// <returns>condition sql string</returns>
        public static string GetDateCompareString(DateTime date, string column, string operatorType)
        {
            if (DatabaseUtil.DBType == Oracle)
            {
                string condition = "('{0}' {1} to_char({2},'yyyy-mm-dd HH24:MI:SS'))";
                return string.Format(condition, Convert.ToDateTime(date).ToString("yyyy-MM-dd HH:mm:ss"), column, operatorType);
            }
            else
            {
                return string.Format("('{0}'{1} {2})", date, column, operatorType);
            }
        }

        /// <summary>
        /// Get the function name of Getting server date according to the db type
        /// </summary>
        /// <returns>function name</returns>
        public static string GetDateString()
        {
            if (DatabaseUtil.DBType == Oracle)
            {
                return "SYSDATE";
            }
            else
            {
                return "GetDate()";
            }
        }

        /// <summary>
        /// Gets the db data adapter.
        /// </summary>
        /// <param name="cmd">The db command args.</param>
        /// <returns>The data adapter</returns>
        public static DbDataAdapter GetDbDataAdapter(DbCommand cmd)
        {
            if (cmd is OracleCommand)
            {
                return new OracleDataAdapter((OracleCommand)cmd);

            }
            else if(cmd is SqlCommand)
            {
                return new SqlDataAdapter((SqlCommand) cmd);
            }
            else
            {
                return null;
            }
        }



        #endregion Methods        
    }
}