using com.smartwork.Model;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Util
{
    public class AccelaDBUtil
    {
        public static Dictionary<string, AcccelaDBModel> GetAccelaDatabaseMapper()
        {
            Dictionary<string, AcccelaDBModel> AccelaDBMapper = new Dictionary<string, AcccelaDBModel>();

            // C# 连接 Oracle 的几种方式: http://www.cnblogs.com/storys/archive/2013/03/06/2945914.html
            string connString = "User ID=dbmread;Password=dbmread;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.156)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = dbs156)))";
            OracleConnection conn = new OracleConnection(connString);

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT DB_TYPE,
                                       CUSTOMER,                                      
                                       VERSION_CUR,
                                       DB_IP,
                                       DB_PORT,
                                       DB_SID,
                                       DB_NAME,
                                       DB_USER,
                                       DB_PASS,
                                       USER_REQUESTOR,
                                       DB_USAGE,
                                       AGENCY
                                  FROM DB_SHEET
                                 WHERE DB_STATUS = 'USING' 
                                 ORDER BY DB_CREATED DESC ";

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                AcccelaDBModel accelaDBModel = new AcccelaDBModel();

                accelaDBModel.DBType = reader.GetOracleString(0).ToString();       // DB_TYPE
                accelaDBModel.Customer = reader.GetOracleString(1).ToString();     // CUSTOMER
                accelaDBModel.Version = reader.GetOracleString(2).ToString();      // VERSION_CUR
                accelaDBModel.IP = reader.GetOracleString(3).ToString();           // DB_IP
                accelaDBModel.Port = reader.GetOracleString(4).ToString();         // DB_PORT
                accelaDBModel.SID = reader.GetOracleString(5).ToString();          // DB_SID
                accelaDBModel.DBName = reader.GetOracleString(6).ToString();       // DB_NAME
                accelaDBModel.User = reader.GetOracleString(7).ToString();         // DB_USER
                accelaDBModel.Password = reader.GetOracleString(8).ToString();     // DB_PASS
                accelaDBModel.Owner = reader.GetOracleString(9).ToString();        // USER_REQUESTOR
                accelaDBModel.SFCase = reader.GetOracleString(10).ToString();      // DB_USAGE

                if (!AccelaDBMapper.ContainsKey(accelaDBModel.Customer))
                {
                    if (accelaDBModel.DBName.IndexOf("_jet", StringComparison.InvariantCultureIgnoreCase) < 0)
                    {
                        AccelaDBMapper.Add(accelaDBModel.Customer, accelaDBModel);
                    }
                }
            }

            return AccelaDBMapper;
        }
    }
}
