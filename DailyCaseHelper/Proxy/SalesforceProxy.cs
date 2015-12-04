using com.smartwork.Models;
using Salesforce.Common;
using Salesforce.Force;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Proxy
{
    public class SalesforceProxy
    {
        private static readonly string SecurityToken = ConfigurationManager.AppSettings["SecurityToken"];
        private static readonly string ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
        private static readonly string ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
        private static readonly string Username = ConfigurationManager.AppSettings["Username"];
        private static readonly string Password = ConfigurationManager.AppSettings["Password"] + SecurityToken;
        private static readonly string IsSandboxUser = ConfigurationManager.AppSettings["IsSandboxUser"];
        public static IForceClient Client = null;

        public static async Task<IForceClient> CreateAuthenticationClient()
        {
            var auth = new AuthenticationClient();

            // Authenticate with Salesforce           
            var url = IsSandboxUser.Equals("true", StringComparison.CurrentCultureIgnoreCase)
                ? "https://test.salesforce.com/services/oauth2/token"
                : "https://login.salesforce.com/services/oauth2/token";
            
            await auth.UsernamePasswordAsync(ConsumerKey, ConsumerSecret, Username, Password, url);

            Client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);

            return Client;
        }

        public static async Task<List<AccelaCase>> GetTopNCommentedCaseList(int n)
        {
            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, case.account.name, case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                  case.createdby.name, status, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name, 
                                  (select commentbody, casecomment.createdby.name, casecomment.lastmodifiedby.name, createddate, lastmodifieddate 
                                   from casecomments 
                                   where casecomment.createdby.name = 'Accela Support Team'
                                   order by createddate desc) 
                            from case 
                            where case.lastmodifiedby.name = 'Accela Support Team'
                            order by case.lastmodifieddate desc
                            limit " + n;

            var cases = new List<AccelaCase>();
            var results = await Client.QueryAsync<AccelaCase>(sql);
            var totalSize = results.TotalSize;

            Console.WriteLine("Queried " + totalSize + " records.");

            cases.AddRange(results.Records);

            return cases;
        }

        public static async Task<List<AccelaCase>> GetTopNNewCaseList(int n, bool isOnlyV80000 = false, bool isExclude80000 = false)
        {
            /*
            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, case.account.name, case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                  case.createdby.name, status, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name, 
                                  (select commentbody, casecomment.createdby.name, casecomment.lastmodifiedby.name, createddate, lastmodifieddate 
                                   from casecomments 
                                   where casecomment.createdby.name <> 'Accela Support Team'
                                   order by createddate desc) 
                            from case 
                            where status ='eng new'
                            and case.owner.name='engineering'
                            and product__c != 'Springbrook' 
                            and product__c != 'SoftRight' 
                            and product__c != 'Legislative Management' 
                            and product__c != 'Environmental Health' ";
             * */

            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, case.account.name, case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                  case.createdby.name, status, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name 
                            from case 
                            where status ='eng new'
                            and case.owner.name='engineering'
                            and product__c != 'Springbrook' 
                            and product__c != 'SoftRight' 
                            and product__c != 'Legislative Management' 
                            and product__c != 'Environmental Health' ";

            if (isOnlyV80000)
            {
                sql += " and current_version__c like '8.%' ";
            }

            if (isExclude80000)
            {
                sql += " and current_version__c <> '8.0.0.0.0' and current_version__c <> '8.0.1.0.0' ";
            }

            sql += "order by createddate desc limit " + n;

            var cases = new List<AccelaCase>();
            var results = await Client.QueryAsync<AccelaCase>(sql);
            var totalSize = results.TotalSize;

            Console.WriteLine("Queried " + totalSize + " records.");

            cases.AddRange(results.Records);

            return cases;
        }

        public static async Task<List<AccelaCase>> GetCaseList(List<string> caseIdList, bool isCommentFilter = true)
        {
//            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, case.account.name, 
//                                  case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
//                                  case.createdby.name, status, bzid__c, product__c, customer__r.name, 
//                                  (select commentbody, casecomment.createdby.name, casecomment.lastmodifiedby.name, createddate, lastmodifieddate 
//                                   from casecomments 
//                                   order by createddate desc nulls last limit 1 ) 
//                                  from case 
//                                  where status ='eng new' 
//                                        and case.product__c='accela aca' 
//                                        and case.owner.name='engineering'";
            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, rank_order__c, services_rank__c, case.account.name, 
                                              case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                              case.createdby.name, status, internal_type__c, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name, 
                                              (select commentbody, casecomment.createdby.name, casecomment.lastmodifiedby.name, createddate, lastmodifieddate 
                                               from casecomments ";
                if(isCommentFilter) {
                    sql += " where casecomment.createdby.name = 'Accela Support Team' or casecomment.createdby.name = 'Accela Engineering Team' ";
                }
                 
             sql += @" order by createddate desc) 
                       from case 
                       where product__c != 'Springbrook' 
                       and product__c != 'SoftRight' 
                       and product__c != 'Legislative Management' 
                       and product__c != 'Environmental Health' and ( ";

            bool isFirstCase = true;
            foreach(string caseId in caseIdList)
            {
                if (isFirstCase)
                {
                    sql += " casenumber='" + caseId + "' ";
                    isFirstCase = false;
                } 
                else
                {
                    sql += " OR casenumber='" + caseId + "' ";
                }
            }
            sql += ")";

            var cases = new List<AccelaCase>();
            var results = await Client.QueryAsync<AccelaCase>(sql);
            var totalSize = results.TotalSize;

            //Console.WriteLine("Queried " + totalSize + " records.");

            cases.AddRange(results.Records);

            return cases;
        }

        public static async Task<List<AccelaCase>> GetCaseInfoByID(string caseId)
        {
            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, rank_order__c, services_rank__c, case.account.name, 
                                              case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                              case.createdby.name, status, internal_type__c, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name
                           from case 
                           where product__c != 'Springbrook' 
                           and product__c != 'SoftRight' 
                           and product__c != 'Legislative Management' 
                           and product__c != 'Environmental Health' and ( ";

            sql += " casenumber='" + caseId + "' " + ")";

            var cases = new List<AccelaCase>();
            var results = await Client.QueryAsync<AccelaCase>(sql);
            var totalSize = results.TotalSize;

            cases.AddRange(results.Records);

            return cases;
        }

        public static async Task<List<AccelaCase>> GetHotCaseList(int n)
        {
            string sql = @"select id, casenumber, current_version__c, priority, rank_order__c, services_rank__c, go_live_critical__c, case.account.name, case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                  case.createdby.name, status, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name
                            from case 
                            where status ='eng new'
                            and case.owner.name='engineering'
                            and product__c != 'Springbrook' 
                            and product__c != 'SoftRight' 
                            and product__c != 'Legislative Management' 
                            and product__c != 'Environmental Health'
                            and ( rank_order__c != null OR services_rank__c != null ) ";

            sql += "order by createddate desc limit " + n;

            var cases = new List<AccelaCase>();
            var results = await Client.QueryAsync<AccelaCase>(sql);
            var totalSize = results.TotalSize;

            Console.WriteLine("Queried " + totalSize + " records.");

            cases.AddRange(results.Records);

            return cases;
        }
    }
}
