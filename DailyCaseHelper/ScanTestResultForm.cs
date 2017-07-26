using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestRail;
using Newtonsoft.Json;

namespace com.smartwork
{
    public partial class ScanTestResultForm : Form
    {
        Dictionary<ulong, TestRail.Types.User> TestrailUserDic = new Dictionary<ulong, TestRail.Types.User>();
        public ScanTestResultForm()
        {
            InitializeComponent();

            var client = new TestRailClient("https://accela.testrail.net/", "peter.peng@missionsky.com", "Change_2017");
            var users = client.GetUsers();
            TestrailUserDic.Clear();
            foreach (var user in users)
            {
                TestrailUserDic.Add(user.ID, user);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            var testRunUrl = this.txtTestRunUrl.Text;
            if (testRunUrl.StartsWith("https://accela.testrail.net/index.php?/runs/view/") == false)
            {
                MessageBox.Show("The format of test run url should be https://accela.testrail.net/index.php?/runs/view/XXXX");
                return;
            }

            testRunUrl = testRunUrl.Remove(0, "https://accela.testrail.net/index.php?/runs/view/".Length);
            var testRunID = testRunUrl.IndexOf("&") > 0 ? ulong.Parse(testRunUrl.Substring(0, testRunUrl.IndexOf("&"))) : ulong.Parse(testRunUrl);

            var client = new TestRailClient("https://accela.testrail.net/", "peter.peng@missionsky.com", "Change_2017");
            var testRun = client.GetRun((ulong)testRunID);
            var testcases = client.GetTests((ulong)testRunID);

            List<TestResult> testResults = new List<TestResult>();
            foreach (var testcase in testcases)
            {
               
                var testcaseFields = JsonConvert.DeserializeObject<TestCaseFields>(testcase.JsonFromResponse.ToString());
                TestResult testResult = new TestResult();
                testResult.JiraKey = testcaseFields.JiraKey;
                testResult.TestRunID = testRunID;
                testResult.TestRunTitle = testRun.Name;
                testResult.TestRunUrl = testRun.Url;
                testResult.TestCaseID = testcase.CaseID;
                testResult.TestCaseTitle = testcase.Title;
                testResult.Status = testcase.Status.ToString();
                testResult.AssignedTo = testcase.AssignedToID != null ? TestrailUserDic[(ulong)testcase.AssignedToID].Name : "";
                //testResult.LastUpdateTime = 

                var results = client.GetResultsForCase((ulong)testRunID, (ulong)testcase.CaseID);
                foreach (var result in results)
                {
                    testResult.AssignedTo = TestrailUserDic[(ulong)result.CreatedBy].Name;
                    testResult.LastUpdateTime = result.CreatedOn;
                    break;
                }

                testResults.Add(testResult);
            }

            foreach (var testResult in testResults)
            {
            }
        }

        class TestCaseFields
        {
            [JsonProperty(PropertyName = "refs")]
            public string JiraKey { get; set; }
        }

        class TestResult
        {            
            public string JiraKey { get; set; }            
            public ulong TestRunID { get; set; }
            public string TestRunTitle { get; set; }
            public string TestRunUrl { get; set; }
            public ulong? TestCaseID { get; set; }
            public string TestCaseTitle { get; set; }
            public string Status { get; set; }
            public string AssignedTo { get; set; }
            public DateTime? LastUpdateTime { get; set; }
        }
    }
}
