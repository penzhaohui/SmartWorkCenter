using com.smartwork.Model;
using SimpleConsole;
using System.Collections.Generic;

namespace com.smartwork.Business
{
    public class CaseBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caseIDs"></param>
        /// <returns></returns>
        public List<CaseModel> BatchQuery(List<string> caseIDs)
        {
            List<CaseModel> caseModelList = new List<CaseModel>();

            return caseModelList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caseIDs"></param>
        /// <returns></returns>
        public bool ImportCasesFromSalesforce(List<string> caseIDs)
        {
            bool success = true;
            // 2.1 Retrive the login credential from database
            // 2.2 Export case list one by one
            // 2.3 Add case into database

            SFDCUnitTest sfdcUnitTest = new SFDCUnitTest();
            //SFDCUnitTest.RunUnitTest();

            return success;
        }
    }
}
