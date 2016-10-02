using com.smartwork.Models;
using com.smartwork.Proxy.models;
using Salesforce.Common;
using Salesforce.Force;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

        public static async Task<List<AccelaCase>> GetTopNNewCaseList(int n, bool isExcludeEngQA = false, bool isOnlyEngQA = false, bool isIncludeComments = false)
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
                                  case.createdby.name, status, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name ";
           
            /*
            sql += @" , (select commentbody, casecomment.createdby.name, casecomment.lastmodifiedby.name, createddate, lastmodifieddate 
                                   from casecomments 
                                   where casecomment.createdby.name <> 'Accela Support Team'
                                   order by createddate desc) ";
             * */

            sql += @"      from case 
                            where case.owner.name='engineering'
                            and product__c != 'Springbrook' 
                            and product__c != 'SoftRight' 
                            and product__c != 'Legislative Management' 
                            and product__c != 'Environmental Health'
                            and product__c != 'Kiva' 
                            and product__c != 'KVS Standard' ";

            if (isOnlyEngQA)
            {
                sql += " and (status ='eng qa' or status ='qa in progress' or status ='engqa') ";
            }

            if (isExcludeEngQA)
            {
                sql += " and status ='eng new' ";
            }

            if (isOnlyEngQA == false && isExcludeEngQA == false)
            {
                sql += " and (status ='eng new' or status ='eng qa' or status ='qa in progress' or status ='engqa') ";
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
                                              case.createdby.name, status, internal_type__c, engineering_status__c, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name, 
                                              (select commentbody, casecomment.createdby.name, casecomment.lastmodifiedby.name, createddate, lastmodifieddate 
                                               from casecomments ";
                if(isCommentFilter) {
                    sql += " where casecomment.createdby.name = 'Accela Support Team' ";
                    sql += "       or casecomment.createdby.name = 'Accela Engineering Team' ";
                    //sql += "       or casecomment.createdby.name = 'Jerry Lu' ";
                    //sql += "       or casecomment.createdby.name = 'Robinson Leung' ";
                    //sql += "       or casecomment.createdby.name = 'Anderson Liu' ";
                    //sql += "       or casecomment.createdby.name = 'Greg Mietelski' ";
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

        public static async Task<List<AccelaCase>> GetCaseAttachmentInfoByID(List<string> caseIdList)
        {
            // http://stackoverflow.com/questions/4952379/salesforce-soql-query-for-notes-and-attachments-of-a-site
            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, rank_order__c, services_rank__c, case.account.name, 
                                              case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                              case.createdby.name, status, internal_type__c, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name,
                                              (select Id, Name, ContentType, BodyLength, Description, IsPrivate, OwnerId, ParentId, CreatedDate, CreatedById, LastModifiedDate, LastModifiedById from Attachments) 
                           from case 
                           where product__c != 'Springbrook' 
                           and product__c != 'SoftRight' 
                           and product__c != 'Legislative Management' 
                           and product__c != 'Environmental Health' and ( ";

            bool isFirstCase = true;
            foreach (string caseId in caseIdList)
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

            cases.AddRange(results.Records);

            return cases;
        }

        public static byte[] GetCaseAttachmentById(string attachmentId)
        {
            // https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_sobject_blob_retrieve.htm
            // Salesforce REST API Read File - http://danlb.blogspot.com/2012/06/salesforce-rest-api-read-file.html
            // Salesforce REST API File Upload - http://danlb.blogspot.com/2012/06/salesforce-rest-api-file-upload.html

            //string sql = "Select Name, Body, ContentType from Attachment where id = '" + attachmentId + "'";
            //var result = await Client.QueryAsync<AccelaCaseAttachment>(sql);

            var uri = "https://na26.salesforce.com//services/data/v32.0/sobjects/Attachment/" + attachmentId + "/body";
            var req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            req.Headers.Add("Authorization: OAuth " + "00D300000000B1r!AQMAQNMJOSIlO5nn.h399Yq7kWkBqgLwi_3uDgOwDCP1jbgDOxPmVpqOXdTOzBIAc8bQyteeSjZaTdK3ReQ8tUXdrWPQ9zug");
            req.ContentType = "application/json";
            req.Method = "GET";
            var resp = req.GetResponse();
            var sr = new System.IO.StreamReader(resp.GetResponseStream());
            //var result = sr.ReadToEnd();

            var bytes = default(byte[]);
            using (var memstream = new MemoryStream())
            {
                var buffer = new byte[512];
                var bytesRead = default(int);
                while ((bytesRead = sr.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                    memstream.Write(buffer, 0, bytesRead);
                bytes = memstream.ToArray();
                //memstream.Position = 0;
                //memstream.Close();
                //return memstream;
            }

            return bytes;
        }

        public static async Task<User> GetUserInfoById(string id)
        {
            var result = await Client.QueryByIdAsync<User>("User", id);

            return result;
        }

        public static async void GetReleaseInfoById(string id)
        {
            //var result = await Client.QueryByIdAsync<User>("release_info__c", id);

            var uri = "https://na26.salesforce.com//services/data/v32.0/sobjects/release_info__c/" + id;
            var req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            req.Headers.Add("Authorization: OAuth " + "00D300000000B1r!AQMAQBb3Nv5DaNTlgPJz3Pzmvry2J4mJ4f4vF9aRbjHVQcxOMHRIZXGsbpLn_IhfoHObdV9jBhdwVg5XTa5V5Bw_tr7Zql.f");
            req.ContentType = "application/json";
            req.Method = "GET";
            var resp = req.GetResponse();

            //return result;
        }

        public static async Task<User> GetTargetedReleaseById(string id)
        {
            var result = await Client.QueryByIdAsync<User>("targeted_release__c", id);

            return result;
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

        public static Dictionary<string, string> GetReviewerNamesList(bool isExcludeAccelaEngineer = false)
        {
            Dictionary<string, string> Reviewers = new Dictionary<string, string>();
            Reviewers.Add("Jessy", "Jessy.Zhang");
            Reviewers.Add("Adger", "Adger.Chen");
            Reviewers.Add("Tim", "Tim.Liu");

            Reviewers.Add("Mia", "Mia.Huang");
            Reviewers.Add("Alvin", "Alvin.Li");
            Reviewers.Add("Mina", "Mina.Xiong");

            Reviewers.Add("Alex", "Alex.Li");
            Reviewers.Add("Peter", "Peter.Peng");
            Reviewers.Add("John", "John.Huang");
            Reviewers.Add("Bass", "Bass.Yang");
            Reviewers.Add("Star", "Star.Li");
            Reviewers.Add("Shaun", "Shaun.Qiu");
            Reviewers.Add("Lex", "Lex.Wu");
            Reviewers.Add("Louis", "Louis.He");
            Reviewers.Add("Likko", "Likko.Zhang");
            Reviewers.Add("Sandy", "Sandy.Zheng");
            Reviewers.Add("Weber", "Weber.Yan");
            Reviewers.Add("Rick", "Rick.Liu");
            Reviewers.Add("Matt", "Matt.Ao");
            Reviewers.Add("Hyman", "Hyman.Zhang");
            Reviewers.Add("Feng", "Feng.Xuan");
            Reviewers.Add("Cheng", "Cheng.Xu");
            Reviewers.Add("Felix", "Felix.Chen");
            Reviewers.Add("Frank", "Frank.Deng");
            //Reviewers.Add("Howe", "Howe.Deng");
            Reviewers.Add("Michael", "Michael.He");


            Reviewers.Add("Mandy", "Mandy.Zhou");
            Reviewers.Add("Linda", "Linda.Xiao");
            Reviewers.Add("Leo", "Leo.Liu");
            Reviewers.Add("Jane", "Jane.Hu");
            Reviewers.Add("Abel", "Abel.Yu");
            Reviewers.Add("Claire", "Claire.Cao");
            Reviewers.Add("Viola", "Viola.Shi");
            Reviewers.Add("Larry", "Larry.Francisco");
            Reviewers.Add("Yummy", "Yummy.Xie");
            Reviewers.Add("Lola", "Lola.He");
            Reviewers.Add("Nicole", "Nicole.Guo");
            Reviewers.Add("Mamie", "Mamie.Li");
            Reviewers.Add("Vicky", "Vicky.Chen");
            Reviewers.Add("June", "June.Liu");

            Reviewers.Add("Joanna", "Joanna.Mae.Ramirez");

            Reviewers.Add("Fay", "Fay.Ding");

            Reviewers.Add("Gordon", "Gordon.Chen");
            Reviewers.Add("Tracy", "Tracy.Xiang");
            Reviewers.Add("Evelyn", "Evelyn.Zhang");

            Reviewers.Add("Apia", "Apia.Liu");
            Reviewers.Add("Jessie", "Jessie.Zhang");
            Reviewers.Add("William", "William.Wang");
            Reviewers.Add("Iron", "Iron.Tang");
            Reviewers.Add("Rev", "Rev.Vergara");
            Reviewers.Add("Lisa", "Lisa.Kang");

            Reviewers.Add("Carly", "Carly.Xu");
            Reviewers.Add("Janice", "Janice.Zhong");
            Reviewers.Add("Trancy", "Trancy.Zhai");
            Reviewers.Add("Amy", "Amy.Bao");
            Reviewers.Add("Iris", "Iris.Wang");
            Reviewers.Add("Grace", "Grace.Tang");
            Reviewers.Add("Cloud", "Cloud.Qi");
            Reviewers.Add("Carol", "Carol.Gong");

            if (!isExcludeAccelaEngineer)
            {
                Reviewers.Add("Manasi", "mkarvat@accela.com");
                Reviewers.Add("Sasirekha", "sbalaji@accela.com");
                Reviewers.Add("Jerry", "Jerry.Lu");
                Reviewers.Add("Anderson", "Anderson.Liu");
                Reviewers.Add("Robinson", "Robinson.Leung");
                Reviewers.Add("Greg", "Greg.Mietelski");
                Reviewers.Add("Prakash", "Prakash.Dhanore");
                Reviewers.Add("Shijie", "Shijie.Zhou");
            }

            return Reviewers;
        }

        public static List<string> GetSupportDevList1(bool isExcludeAccelaEngineer = false)
        {
            List<string> Reviewers = new List<string>();
            Reviewers.Add("Jessy.Zhang");

            Reviewers.Add("Alvin.Li");           
            Reviewers.Add("Rev.Vergara");
            Reviewers.Add("Lisa.Kang");
        
            Reviewers.Add("Alex.Li");
            Reviewers.Add("Peter.Peng");
            Reviewers.Add("John.Huang");
            Reviewers.Add("Bass.Yang");
            Reviewers.Add("Star.Li");
            Reviewers.Add("Shaun.Qiu");
            Reviewers.Add("Lex.Wu");
            Reviewers.Add("Louis.He");
            Reviewers.Add("Likko.Zhang");            
            Reviewers.Add("Weber.Yan");            
            Reviewers.Add("Felix.Chen");
            Reviewers.Add("Frank.Deng");
            //Reviewers.Add("Howe.Deng");
            Reviewers.Add("Michael.He");

            //Reviewers.Add("Mandy.Zhou");
            Reviewers.Add("Linda.Xiao");
            //Reviewers.Add("Leo.Liu");
            //Reviewers.Add("Abel.Yu");            
            Reviewers.Add("Nicole.Guo");
            Reviewers.Add("Mamie.Li");
            //Reviewers.Add("June.Liu");
            
            Reviewers.Add("Joanna.Mae.Ramirez");

            Reviewers.Add("Gordon.Chen");
            Reviewers.Add("Tracy.Xiang");
            Reviewers.Add("Evelyn.Zhang");

            Reviewers.Add("Apia.Liu");
            Reviewers.Add("Jessie.Zhang");
            Reviewers.Add("Iron.Tang");
            

            Reviewers.Add("Carly.Xu");
            Reviewers.Add("Janice.Zhong");
            Reviewers.Add("Trancy.Zhai");
            Reviewers.Add("Iris.Wang");
            Reviewers.Add("Grace.Tang");
            Reviewers.Add("Cloud.Qi");
            Reviewers.Add("Carol.Gong");

            if (!isExcludeAccelaEngineer)
            {               
                Reviewers.Add("Jerry.Lu");
                Reviewers.Add("Anderson.Liu");
                Reviewers.Add("Prakash.Dhanore");
                Reviewers.Add("Shijie.Zhou");
            }            

            return Reviewers;
        }

        public static List<string> GetSupportDevList(bool isExcludeAccelaEngineer = false)
        {
            List<string> Reviewers = new List<string>();
            //Reviewers.Add("Jessy.Zhang");
            //Reviewers.Add("Adger.Chen");
            Reviewers.Add("Tim.Liu");

            //Reviewers.Add("Mia.Huang");
            //Reviewers.Add("Alvin.Li");
            //Reviewers.Add("Mina.Xiong");
            //Reviewers.Add("Rev.Vergara");
            //Reviewers.Add("Lisa.Kang");

            Reviewers.Add("Alex.Li");
            Reviewers.Add("Peter.Peng");
            Reviewers.Add("John.Huang");
            Reviewers.Add("Bass.Yang");
            Reviewers.Add("Star.Li");
            Reviewers.Add("Shaun.Qiu");
            Reviewers.Add("Lex.Wu");
            Reviewers.Add("Louis.He");
            Reviewers.Add("Likko.Zhang");
            Reviewers.Add("Sandy.Zheng");
            Reviewers.Add("Weber.Yan");
            //Reviewers.Add("Rick.Liu");
            //Reviewers.Add("Matt.Ao");
            //Reviewers.Add("Hyman.Zhang");
            //Reviewers.Add("Feng.Xuan");
            //Reviewers.Add("Cheng.Xu");
            Reviewers.Add("Felix.Chen");
            //Reviewers.Add("Frank.Deng");
            //Reviewers.Add("Howe.Deng");

            //Reviewers.Add("Mandy.Zhou");
            //Reviewers.Add("Linda.Xiao");
            //Reviewers.Add("Leo.Liu");
            //Reviewers.Add("Abel.Yu");
            //Reviewers.Add("Claire.Cao");
            //Reviewers.Add("Viola.Shi");
            //Reviewers.Add("Larry.Francisco");
            //Reviewers.Add("Yummy.Xie");
            //Reviewers.Add("Lola.He");
            //Reviewers.Add("Nicole.Guo");
            //Reviewers.Add("Mamie.Li");
            //Reviewers.Add("June.Liu");

            //Reviewers.Add("Joanna.Mae.Ramirez");

            //Reviewers.Add("Fay.Ding");

            //Reviewers.Add("Gordon.Chen");
            //Reviewers.Add("Tracy.Xiang");
            //Reviewers.Add("Evelyn.Zhang");

            //Reviewers.Add("Apia.Liu");
            //Reviewers.Add("Jessie.Zhang");
            //Reviewers.Add("William.Wang");
            //Reviewers.Add("Iron.Tang");


            //Reviewers.Add("Carly.Xu");
            //Reviewers.Add("Janice.Zhong");
            //Reviewers.Add("Jane.Hu");
            //Reviewers.Add("Amy.Bao");
            //Reviewers.Add("Iris.Wang");
            //Reviewers.Add("Grace.Tang");
            //Reviewers.Add("Cloud.Qi");
            //Reviewers.Add("Carol.Gong");

            if (isExcludeAccelaEngineer)
            {
                //Reviewers.Add("mkarvat@accela.com");
                //Reviewers.Add("sbalaji@accela.com");
                //Reviewers.Add("Jerry.Lu");
                //Reviewers.Add("Anderson.Liu");
                //Reviewers.Add("Prakash.Dhanore");
                //Reviewers.Add("Shijie.Zhou");
            }

            //Reviewers.Add("Robinson.Leung");
            //Reviewers.Add("Greg.Mietelski");

            return Reviewers;
        }

        public static List<string> GetSupportQAList(bool isExcludeAccelaEngineer = false)
        {
            List<string> Reviewers = new List<string>();
            Reviewers.Add("Jessy.Zhang");
            //Reviewers.Add("Adger.Chen");
            //Reviewers.Add("Tim.Liu");

            //Reviewers.Add("Mia.Huang");
            //Reviewers.Add("Alvin.Li");
            //Reviewers.Add("Mina.Xiong");
            //Reviewers.Add("Lisa.Kang");

            //Reviewers.Add("Alex.Li");
            //Reviewers.Add("Peter.Peng");
            //Reviewers.Add("John.Huang");
            //Reviewers.Add("Bass.Yang");
            //Reviewers.Add("Star.Li");
            //Reviewers.Add("Shaun.Qiu");
            //Reviewers.Add("Lex.Wu");
            //Reviewers.Add("Louis.He");
            //Reviewers.Add("Likko.Zhang");
            //Reviewers.Add("Sandy.Zheng");
            //Reviewers.Add("Weber.Yan");
            //Reviewers.Add("Rick.Liu");
            //Reviewers.Add("Matt.Ao");
            //Reviewers.Add("Hyman.Zhang");
            //Reviewers.Add("Feng.Xuan");
            //Reviewers.Add("Cheng.Xu");
            //Reviewers.Add("Felix.Chen");
            //Reviewers.Add("Frank.Deng");
            //Reviewers.Add("Howe.Deng");

            Reviewers.Add("Mandy.Zhou");
            Reviewers.Add("Linda.Xiao");
            Reviewers.Add("Leo.Liu");
            Reviewers.Add("Jane.Hu");
            Reviewers.Add("Abel.Yu");
            Reviewers.Add("Claire.Cao");
            Reviewers.Add("Viola.Shi");
            //Reviewers.Add("Larry.Francisco");
            //Reviewers.Add("Yummy.Xie");
            Reviewers.Add("Lola.He");
            Reviewers.Add("Nicole.Guo");
            Reviewers.Add("Mamie.Li");
            //Reviewers.Add("June.Liu");

            Reviewers.Add("Joanna.Mae.Ramirez");

            Reviewers.Add("Fay.Ding");

            Reviewers.Add("Gordon.Chen");
            //Reviewers.Add("Tracy.Xiang");
            //Reviewers.Add("Evelyn.Zhang");

            //Reviewers.Add("Apia.Liu");
            //Reviewers.Add("Jessie.Zhang");
            //Reviewers.Add("William.Wang");
            //Reviewers.Add("Iron.Tang");
            //Reviewers.Add("Rev.Vergara");
            //Reviewers.Add("Lisa.Kang");

            //Reviewers.Add("Carly.Xu");
            //Reviewers.Add("Janice.Zhong");
           
            //Reviewers.Add("Amy.Bao");
            //Reviewers.Add("Iris.Wang");
            //Reviewers.Add("Grace.Tang");
            //Reviewers.Add("Cloud.Qi");
            //Reviewers.Add("Carol.Gong");

            if (isExcludeAccelaEngineer)
            {
                //Reviewers.Add("Robinson.Leung");
                //Reviewers.Add("Greg.Mietelski");
            }

            return Reviewers;
        }

        public static List<string> GetSupportQAList1(bool isExcludeAccelaEngineer = false)
        {
            List<string> Reviewers = new List<string>();
           
            Reviewers.Add("Leo.Liu");
            Reviewers.Add("Jane.Hu");
            Reviewers.Add("Abel.Yu");

            if (!isExcludeAccelaEngineer)
            {
                Reviewers.Add("Robinson.Leung");
                Reviewers.Add("Greg.Mietelski");
            }

            return Reviewers;
        }

        public static List<string> GetQAReviewerNamesList()
        {
            List<string> Reviewers = new List<string>();

            /*
            Reviewers.Add("Jessy.Zhang");            

            Reviewers.Add("Mia.Huang");
            Reviewers.Add("Alvin.Li");
            Reviewers.Add("Mina.Xiong");           

            Reviewers.Add("Mandy.Zhou");
            Reviewers.Add("Linda.Xiao");
            Reviewers.Add("Leo.Liu");
            Reviewers.Add("Abel.Yu");
            Reviewers.Add("Claire.Cao");
            Reviewers.Add("Viola.Shi");
            Reviewers.Add("Larry.Francisco");
            Reviewers.Add("Yummy.Xie");
            Reviewers.Add("Lola.He");
            Reviewers.Add("Gordon.Chen");
            Reviewers.Add("Fay.Ding");

            Reviewers.Add("Apia.Liu");
            Reviewers.Add("Jessie.Zhang");
            Reviewers.Add("Rev.Vergara");
            Reviewers.Add("Lisa.Kang");

            Reviewers.Add("Carly.Xu");
            Reviewers.Add("Janice.Zhong");
            Reviewers.Add("Jane.Hu");
            Reviewers.Add("Amy.Bao");
            Reviewers.Add("Iris.Wang");
            Reviewers.Add("Grace.Tang");
            Reviewers.Add("Cloud.Qi");
            Reviewers.Add("Carol.Gong");
            * */

            Reviewers.Add("Jane.Hu");
            Reviewers.Add("Leo.Liu");
            Reviewers.Add("Robinson.Leung");
            Reviewers.Add("Greg.Mietelski");

            return Reviewers;
        }
    }
}
