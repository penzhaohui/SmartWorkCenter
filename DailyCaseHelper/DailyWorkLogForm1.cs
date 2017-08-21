using com.smartwork.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.smartwork
{
    public partial class DailyWorkLogForm1 : Form
    {
        public DailyWorkLogForm1()
        {
            InitializeComponent();

            this.dtpFrom.Value = DateTime.Today;
            this.dtpTo.Value = DateTime.Today.AddDays(1);
        }

        private List<string> GetSupportTeamMembers()
        {
            List<string> members = new List<string>();

            //members.Add("peter.peng@missionsky.com");
            members.Add("john.huang@missionsky.com");
            members.Add("jane.hu@missionsky.com");
            members.Add("gordon.chen@missionsky.com");
            members.Add("trancy.zhai@missionsky.com");

            return members;
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;

            DateTime from = this.dtpFrom.Value;
            DateTime to = this.dtpTo.Value;
            var issues = await JiraProxy.GetUpdatedIssueListByAssigneeList(from, to, GetSupportTeamMembers());
            this.btnSync.Enabled = true;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}
