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

namespace SmartTestrail
{
    public partial class TestrailClient : Form
    {
        public TestrailClient()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var client = new TestRailClient("https://accela.testrail.net/","peter.peng@missionsky.com", "Change_2017");
            var projects = client.GetProjects();            

            foreach (var project in projects)
            {
                if (project.Name == "Accela 9.2.0&9.1.X Test Execution")
                { 
                    var plans = client.GetPlans(project.ID);
                    foreach(var plan in plans)
                    {
                        if(plan.Name == "Accela Automation 9.2.0 Release")
                        {
                            var testPlan = client.GetPlan(plan.ID);
                            foreach (var entry in testPlan.Entries)
                            {
                                if (entry.Name == "9.1.2 Code Merge to 9.2.0")
                                {
                                    foreach (var run in entry.RunList)
                                    {
                                        if (run.Name == "9.1.2 Code Merge to 9.2.0")
                                        {
                                            var testcases = client.GetTests((ulong)run.ID);
                                            foreach (var testcase in testcases)
                                            {
                                                var results = client.GetResultsForCase((ulong)run.ID, (ulong)testcase.CaseID);
                                            }

                                            /*
                                            var results = client.GetResultsForRun((ulong)run.ID);
                                            foreach(var result in results)
                                            {
                                                var testcase = client.GetTest(result.TestID);

                                                var testcaseInfo = testcase.JsonFromResponse;
                                                testcaseInfo.GetValue("");
                                            }  
                                            */
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    /*
                    var milestomes = client.GetMilestones(project.ID);
                    
                    foreach (var milestone in milestomes)
                    {
                        if (milestone.Name == "Accela Automation 9.2.0 Release")
                        {                            
                        }                       
                    }                    

                    var runs = client.GetRuns(project.ID);
                    */
                }
            }
        }        
    }
}
