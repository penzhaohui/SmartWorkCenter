using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using com.smartwork.DataAccess;
using System.Data.Common;

namespace com.smartwork
{
    public partial class DBSettingForm : Form
    {
        public DBSettingForm()
        {
            InitializeComponent();
            initialize();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void initialize()
        {
            this.txtHost.Text = DatabaseUtil.DBHost;
            this.txtPort.Text = DatabaseUtil.DBPort.ToString();
            this.txtUser.Text = DatabaseUtil.DBUser;
            this.txtPassword.Text = DatabaseUtil.DBPassword;
            this.txtDatabaseName.Text = DatabaseUtil.DBInstance;
        }

        /// <summary>
        /// Test database connection
        /// </summary>
        private void btnTestDBConnection_Click(object sender, EventArgs e)
        {
            string dbServer = this.txtHost.Text + "," + this.txtPort.Text;
            string dbDatabase = this.txtDatabaseName.Text;
            string dbUser = this.txtUser.Text;
            string dbPassword = this.txtPassword.Text;
            string connString = "Data Source=" + dbServer + ";Initial Catalog=" + dbDatabase + ";Persist Security Info=True;User ID=" + dbUser + ";PWD=" + dbPassword;

            DbConnection conn = DBFactory.GetConnection("MSSQL", connString);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                MessageBox.Show("Connect database success!");                
            }
            else
            {
                MessageBox.Show("Fialed to connect database!");
            }

            conn.Close();
            conn = null;
        }

        /// <summary>
        /// Update database connection information into application config file
        /// </summary>
        private void btnUpdateDBConnection_Click(object sender, EventArgs e)
        {
            DatabaseUtil.Update("MSSQL", this.txtHost.Text, int.Parse(this.txtPort.Text), this.txtUser.Text, this.txtPassword.Text, this.txtDatabaseName.Text);
        }
    }
}
