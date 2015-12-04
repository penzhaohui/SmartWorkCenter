using com.smartwork.DataAccess;
using com.smartwork.Util;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace com.smartwork
{
    public partial class EmailSettingForm : Form
    {
        public EmailSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Update Daily Case Email Template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateDailyCaseEmailTemplate_Click(object sender, EventArgs e)
        {
            string from = this.txtDailyEmailFrom.Text;
            string to = this.txtDailyEmailTo.Text;
            string cc = this.txtDailyEmailCC.Text;
            string subject = this.txtDailyEmailSubject.Text;
            string content = this.txtDailyEmailContent.Text;

            StringBuilder sbSQLBuilder = new StringBuilder();          
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_TEMPLATE_FOR_DAILY_CASE', 'From', '" + from + "', 'From Email Address', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_TEMPLATE_FOR_DAILY_CASE', 'To', '" + to + "', 'To Email Address', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_TEMPLATE_FOR_DAILY_CASE', 'CC', '" + cc + "', 'CC Email Address', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_TEMPLATE_FOR_DAILY_CASE', 'Subject', '" + subject + "', 'Email Subject', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_TEMPLATE_FOR_DAILY_CASE', 'Content', '" + content + "', 'Email Content Template', 1; ");

            DbConnection conn = DBFactory.GetConnection("MSSQL", ConfigurationManager.ConnectionStrings["Missionsky.Dailycase.Properties.Settings.ConnectionString"].ConnectionString);
            conn.Open();
            DbCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = sbSQLBuilder.ToString();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Send Test Email
        /// </summary>
        private void btnTestEmailServer_Click(object sender, EventArgs e)
        {
            string from = this.txtDefaultSender.Text;
            string to = this.txtDefaultToReceiver.Text;
            string cc = this.txtDefaultCCReceiver.Text;
            string subject = "Email Send Test";
            string content = "This is one test email from Missionsky Daily Application, please ingore it! Thanks! ^_^";
            EmailUtil.SendEmail(from, to, cc, subject, content);

        }

        /// <summary>
        /// Update Email Server Setting
        /// </summary>
        private void btnUpdateEmailServerSetting_Click(object sender, EventArgs e)
        {
            string host = this.txtHost.Text;
            int port = int.Parse(this.txtPort.Text); 
            bool auth = this.chkAuth.Checked;
            string user = this.txtUser.Text;
            string password = this.txtPassword.Text;
            string from = this.txtDefaultSender.Text;
            string to = this.txtDefaultToReceiver.Text;
            string cc = this.txtDefaultCCReceiver.Text;

            StringBuilder sbSQLBuilder = new StringBuilder();
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_SERVER_SETTING', 'Host', '" + host + "', 'Missionsky Email Server', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_SERVER_SETTING', 'Port', '" + port + "', 'Default Port: 25', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_SERVER_SETTING', 'Auth', '" + auth + "', 'Enable Authentication', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_SERVER_SETTING', 'User', '" + user + "', 'User Account', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_SERVER_SETTING', 'Password', '" + password + "', 'Password', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_SERVER_SETTING', 'From', '" + from + "', 'Default From Email Address', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_SERVER_SETTING', 'To', '" + to + "', 'Default To Email Address', 1; ");
            sbSQLBuilder.Append("EXEC sp_UpdateSystemSetting 'EMAIL_SERVER_SETTING', 'CC', '" + cc + "', 'Default CC Email Address', 1; ");

            DbConnection conn = DBFactory.GetConnection("MSSQL", ConfigurationManager.ConnectionStrings["Missionsky.Dailycase.Properties.Settings.ConnectionString"].ConnectionString);
            conn.Open();
            DbCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = sbSQLBuilder.ToString();
            command.ExecuteNonQuery();
        }
    }
}
