using com.smartwork.Util;
using Octokit;
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
    public partial class CheckCommitCommentsOnGithubForm : Form
    {
        public CheckCommitCommentsOnGithubForm()
        {
            InitializeComponent();
            InitializeGithubClient();

            this.dtpStart.Value = DateTime.Today.AddDays(-3);
            this.dtpEnd.Value = DateTime.Today.AddDays(1);

            this.cmbRepositories.Enabled = false;
            this.btnScan.Enabled = false;
        }

        private async void InitializeGithubClient()
        {
            var gitHubClient = new GitHubClient(new ProductHeaderValue("SmartWork"))
            {
                //Credentials = new Credentials("pen_zhaohui@126.com", "xiangning520")
                Credentials = new Credentials("peter.peng@missionsky.com", "change_2017")
            };

            var repositories = await gitHubClient.Repository.GetAllForCurrent();

            this.cmbRepositories.Items.Clear();
            foreach (var repository in repositories)
            {
                if (repository.Name.EndsWith("_Prod"))
                {
                    this.cmbRepositories.Items.Add(repository);
                }
            }

            this.cmbRepositories.DisplayMember = "Name";
            this.cmbRepositories.Enabled = true;            
            //var credentials = new Credentials("pen_zhaohui@126.com", "change_2017");
        }

        private async void cmbRepositories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnScan.Enabled = false;
            this.cmbBranches.Enabled = false;

            var repository = this.cmbRepositories.SelectedItem as Repository;

            var gitHubClient = new GitHubClient(new ProductHeaderValue("SmartWork"))
            {
                //Credentials = new Credentials("pen_zhaohui@126.com", "xiangning520")
                Credentials = new Credentials("peter.peng@missionsky.com", "change_2017")
            };

            var branches = await gitHubClient.Repository.Branch.GetAll(repository.Id);

            this.cmbBranches.Items.Clear();
            foreach (var branch in branches)
            {
                if (branch.Name.EndsWith("_SP")
                    || branch.Name.EndsWith("_HF")
                    || branch.Name.EndsWith("_FP")
                    || branch.Name.EndsWith("_DEVINT"))
                {
                    this.cmbBranches.Items.Add(branch);               
                }
            }

            this.cmbBranches.DisplayMember = "Name";
            this.btnScan.Enabled = true;
            this.cmbBranches.Enabled = true;
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            this.btnScan.Enabled = false;

            var repository = this.cmbRepositories.SelectedItem as Repository;
            var branch = this.cmbBranches.SelectedItem as Branch;

            if (this.cmbRepositories.SelectedIndex < 0)
            {
                MessageBox.Show("Please select at least one repository.");
                this.btnScan.Enabled = true;
                return;
            }

            if (this.cmbBranches.SelectedIndex < 0)
            {
                MessageBox.Show("Please select at least one branch.");
                this.btnScan.Enabled = true;
                return;
            }

            var gitHubClient = new GitHubClient(new ProductHeaderValue("SmartWork"))
            {
                //Credentials = new Credentials("pen_zhaohui@126.com", "xiangning520")
                Credentials = new Credentials("peter.peng@missionsky.com", "change_2017")
            };

            DateTime start = this.dtpStart.Value;
            DateTime end = this.dtpEnd.Value;

            //var request = new CommitRequest { Since = DateTime.Today.AddDays(-2), Until = DateTime.Now };
            //var request = new CommitRequest { Author = "tracyxiang-tx" };
            //var commits = await gitHubClient.Repository.Commit.GetAll(repository.Id, request);
            // https://stackoverflow.com/questions/16517405/get-git-commits-by-branch-name-id-with-git-api
            var request = new CommitRequest { Since = start, Until = end, Sha = branch.Name };
            var commits = await gitHubClient.Repository.Commit.GetAll(repository.Id, request);

            List<CommitComment> commitComments = new List<CommitComment>();
            foreach (var commit in commits)
            {
                // var comments = await gitHubClient.Repository.Comment.GetAllForCommit(repository.Id, commit.Sha);
                // https://github.com/octokit/octokit.net/issues/869
                var comment = await gitHubClient.Repository.Commit.Get(repository.Id, commit.Sha);
                
                if (comment.Files != null)
                {
                    CommitComment commitComment = new CommitComment();
                    commitComment.Gitlink = comment.HtmlUrl;
                    commitComment.Message = comment.Commit.Message;
                    commitComment.AuthorName = comment.Commit.Author.Name;
                    commitComment.AuthorEmail = comment.Commit.Author.Email;
                    commitComment.CommitedDate = comment.Commit.Author.Date.Date;

                    commitComment.FileList = new List<CommitedFileInfo>();
                    foreach (var file in comment.Files)
                    {
                        CommitedFileInfo fileInfo = new CommitedFileInfo();
                        fileInfo.Name = file.Filename;
                        fileInfo.Status = file.Status;

                        commitComment.FileList.Add(fileInfo);
                    }

                    commitComments.Add(commitComment);
                }                
            }

            this.txtCommitCommentOutput.Text = "";
            StringBuilder sb = new StringBuilder();
            int index = 1;
            foreach (var commitComment in commitComments)
            {
                sb.Append("" + index + ". " + commitComment.Gitlink + Environment.NewLine);
                sb.Append("------------------------------------------------" + Environment.NewLine);
                sb.Append(commitComment.Message + Environment.NewLine);
                sb.Append("------ File List ------------" + Environment.NewLine);
                foreach (var fileInfo in commitComment.FileList)
                {
                    sb.Append("[" + fileInfo.Status + "]" + fileInfo.Name + Environment.NewLine);
                }
                sb.Append("------------------------------------------------" + Environment.NewLine);
                sb.Append("Author: " + commitComment.AuthorName + "[" + commitComment.AuthorEmail + "] - " + commitComment.CommitedDate.ToString() + Environment.NewLine);
                sb.Append(Environment.NewLine + Environment.NewLine);

                index++;
            }

            this.txtCommitCommentOutput.Text = sb.ToString();
            this.btnScan.Enabled = true;

        }

        class CommitComment
        { 
            public string Gitlink {get; set;}
            public string Message { get; set; }
            public List<CommitedFileInfo> FileList { get; set; }
            public string AuthorName { get; set; }
            public string AuthorEmail { get; set; }
            public DateTime CommitedDate { get; set; }
        }

        class CommitedFileInfo
        {
            public string Name { get; set; }
            public string Status { get; set; }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.btnSend.Enabled = false;

            var repository = this.cmbRepositories.SelectedItem as Repository;
            var branch = this.cmbBranches.SelectedItem as Branch;
            var start = this.dtpStart.Value;
            var end = this.dtpEnd.Value;

            string commits = this.txtCommitCommentOutput.Text;

            commits = commits.Replace("\r", "");
            commits = commits.Replace("\n", "<br/>");

            string content = @"Hi, All guys<br/><br/>Below is the code changes summary report.<br/><br/>" + commits + "Thanks<br/>Accela Support Team";
            string fromEmailAddress = "auto_sender@missionsky.com";
            string toEmailAddress = "peter.peng@missionsky.com;jessy.zhang@missionsky.com;alex.li@missionsky.com;trancy.zhai@missionsky.com";
            string ccEmailAddress = "accela-support-team@missionsky.com";
            string subject = "The code changes summary report on [" + repository.Name + "/" + branch.Name + "] - From: " + start.ToShortDateString() + "   To:" + end.ToShortDateString();

            try
            {
                EmailUtil.SendEmail(fromEmailAddress, toEmailAddress, ccEmailAddress, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            this.btnSend.Enabled = true;
        }
    }
}
