using com.smartwork.Model;
using com.smartwork.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace com.smartwork
{
    public partial class DBManager : Form
    {
        public DBManager()
        {
            InitializeComponent();
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;

            // C# 连接 Oracle 的几种方式: http://www.cnblogs.com/storys/archive/2013/03/06/2945914.html
            string connString = "User ID=dbmread;Password=dbmread;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.156)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = dbs156)))";
            OracleConnection conn = new OracleConnection(connString);
            try
            {
                conn.Open();

              

                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT DB_TYPE,
                                       CUSTOMER,
                                       VERSION_ORI,
                                       VERSION_CUR,
                                       DB_IP,
                                       DB_PORT,
                                       DB_SID,
                                       DB_NAME,
                                       DB_USER,
                                       DB_PASS,
                                       DB_CREATED,
                                       USER_REQUESTOR,
                                       DB_USAGE,
                                       AGENCY
                                  FROM DB_SHEET
                                 WHERE DB_GROUP = 'MAINTENANCE' ";

                OracleDataReader reader = cmd.ExecuteReader();

                List<AcccelaDBModel> accelaDBModelList = new List<AcccelaDBModel>();
                 while (reader.Read()){

                     AcccelaDBModel accelaDBModel = new AcccelaDBModel();

                     accelaDBModel.Type = reader.GetOracleString(0).ToString();         // DB_TYPE
                     accelaDBModel.Customer = reader.GetOracleString(1).ToString();     // CUSTOMER
                     accelaDBModel.Version = reader.GetOracleString(2).ToString();      // VERSION_ORI
                     accelaDBModel.IP = reader.GetOracleString(4).ToString();           // DB_IP
                     accelaDBModel.Port = reader.GetOracleString(5).ToString();         // DB_PORT
                     accelaDBModel.SID = reader.GetOracleString(6).ToString();          // DB_SID
                     accelaDBModel.Type = reader.GetOracleString(7).ToString();         // DB_NAME
                     accelaDBModel.Name = reader.GetOracleString(8).ToString();         // DB_USER
                     accelaDBModel.User = reader.GetOracleString(9).ToString();         // DB_PASS
                     accelaDBModel.Password = reader.GetDateTime(10).ToShortDateString();
                     //accelaDBModel.CreatedDate = reader.GetOracleString(11).ToString();// DB_CREATED
                     accelaDBModel.Owner = reader.GetOracleString(12).ToString();       // USER_REQUESTOR
                     accelaDBModel.SFCase = reader.GetOracleString(13).ToString();      // DB_USAGE

                     accelaDBModelList.Add(accelaDBModel);
                 }

                XmlDocument xmlDoc = new XmlDocument();
                //创建Xml声明部分，即<?xml version="1.0" encoding="utf-8" ?>
                XmlDeclaration Declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);

                //创建根节点
                XmlNode rootNode = xmlDoc.CreateElement("AccelaDBList");
                xmlDoc.AppendChild(rootNode);

                //附加根节点            
                xmlDoc.InsertBefore(Declaration, xmlDoc.DocumentElement);
                foreach(AcccelaDBModel accelaDBModel in accelaDBModelList)
                {
                    string type = accelaDBModel.Type;
                    string customer = accelaDBModel.Customer;
                    string version = accelaDBModel.Version;
                    string ip = accelaDBModel.IP;
                    string port = accelaDBModel.Port;
                    string sid = accelaDBModel.SID;
                    string name = accelaDBModel.SID;
                    string user = accelaDBModel.User;
                    string password = accelaDBModel.Password;
                    string createdDate = accelaDBModel.CreatedDate.ToShortTimeString();
                    string owner = accelaDBModel.Owner;
                    string sfCase = accelaDBModel.SFCase;
                    string agencyList = accelaDBModel.AgencyList;

                    //
                    XmlNode accelaDB = xmlDoc.CreateElement("AccelaDB");
                    rootNode.AppendChild(accelaDB);

                    XmlAttribute typeNode = xmlDoc.CreateAttribute("Type");
                    typeNode.Value = type;
                    accelaDB.Attributes.Append(typeNode);

                    XmlAttribute ipNode = xmlDoc.CreateAttribute("IP");
                    ipNode.Value = ip;
                    accelaDB.Attributes.Append(ipNode);

                    XmlAttribute portNode = xmlDoc.CreateAttribute("Port");
                    portNode.Value = port;
                    accelaDB.Attributes.Append(portNode);

                    XmlAttribute sidNode = xmlDoc.CreateAttribute("SID");
                    sidNode.Value = sid;
                    accelaDB.Attributes.Append(sidNode);

                    XmlAttribute nameNode = xmlDoc.CreateAttribute("Name");
                    nameNode.Value = name;
                    accelaDB.Attributes.Append(nameNode);

                    XmlAttribute userNode = xmlDoc.CreateAttribute("User");
                    userNode.Value = user;
                    accelaDB.Attributes.Append(userNode);

                    XmlAttribute passwordNode = xmlDoc.CreateAttribute("Password");
                    passwordNode.Value = password;
                    accelaDB.Attributes.Append(passwordNode);

                    XmlAttribute createdDateNode = xmlDoc.CreateAttribute("CreatedDate");
                    createdDateNode.Value = createdDate;
                    accelaDB.Attributes.Append(createdDateNode);

                    XmlAttribute ownerNode = xmlDoc.CreateAttribute("Owner");
                    ownerNode.Value = owner;
                    accelaDB.Attributes.Append(ownerNode);

                    XmlAttribute sfCaseNode = xmlDoc.CreateAttribute("SFCase");
                    sfCaseNode.Value = sfCase;
                    accelaDB.Attributes.Append(sfCaseNode);

                    var GetCustomer = await getCustomerOrAccountBySF(sfCase);

                    XmlAttribute customerNode = xmlDoc.CreateAttribute("Customer");
                    customerNode.Value = GetCustomer;
                    accelaDB.Attributes.Append(customerNode);

                    string versionAndAgencyList = getVersionAndAgencyList(type, ip, port, sid, user, password);
                    int index = versionAndAgencyList.IndexOf(";");

                    if (index > 0)
                    {
                        XmlAttribute versionNode = xmlDoc.CreateAttribute("Version");
                        versionNode.Value = versionAndAgencyList.Substring(0, index);
                        accelaDB.Attributes.Append(versionNode);

                        XmlAttribute agencyListNode = xmlDoc.CreateAttribute("AgencyList");
                        agencyListNode.Value = versionAndAgencyList.Substring(index + 1); ;
                        accelaDB.Attributes.Append(agencyListNode);
                    }
                }

                xmlDoc.AppendChild(rootNode);
                //保存Xml文档
                xmlDoc.Save(@".\AccelaDBSheet.xml");

                Console.WriteLine("已保存Xml文档");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                MessageBox.Show("Sync finish!");
                conn.Close();
            }

            this.btnSync.Enabled = true;
        }

        private async Task<string> getCustomerOrAccountBySF(string sfID)
        {
            string accountInfo = string.Empty;
            var GetCaseInfoList = SalesforceProxy.GetCaseInfoByID(sfID);
            var caseInfoList = await GetCaseInfoList;
            foreach (var caseInfo in caseInfoList)
            {
                if (caseInfo.Customer != null && string.IsNullOrEmpty(caseInfo.Customer.Name))
                {
                    accountInfo = caseInfo.Customer.Name;
                }
                else if (caseInfo.Account != null && string.IsNullOrEmpty(caseInfo.Account.Name))
                {
                    accountInfo = caseInfo.Account.Name;
                }
            }

            return accountInfo;
        }

        private string getVersionAndAgencyList(string type, string ip, string port, string sid, string user, string password)
        {
            string version = string.Empty;
            string agencyList = string.Empty;

            if ("Oracle".Equals(type, StringComparison.InvariantCultureIgnoreCase))
            {
                string connString = String.Format("User ID={0};Password={1};Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = {2})(PORT = {3}))) (CONNECT_DATA = (SERVICE_NAME = {4})))", user, password, ip, port, sid);
                OracleConnection conn = new OracleConnection(connString);
                try
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"SELECT SCRIPT_NAME FROM UPGRADE_SCRIPTS
                                        ORDER BY SCRIPT_NAME DESC";

                     OracleDataReader reader = cmd.ExecuteReader();
                     while (reader.Read())
                     {
                         version = reader.GetOracleString(0).ToString();
                         break;
                     }
                     reader.Close();

                     cmd.CommandText = @"SELECT SERV_PROV_CODE FROM RSERV_PROV 
                                         WHERE SERV_PROV_CODE NOT IN ('ADMIN', 'STANDARDDATA')";

                     reader = cmd.ExecuteReader();
                     while (reader.Read())
                     {
                         if (String.IsNullOrEmpty(agencyList))
                         {
                             agencyList = reader.GetOracleString(0).ToString();
                         }
                         else
                         {
                             agencyList += "," + reader.GetOracleString(0).ToString();
                         }
                          
                     }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }

            return version + ";" + agencyList;
        }

        private void btnRestPWD_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void DBManager_Load(object sender, EventArgs e)
        {

        }
    }
}
