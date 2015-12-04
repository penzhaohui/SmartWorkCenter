using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.smartwork.Proxy;

namespace com.smartwork
{
    public partial class DailyCaseImportorFromExcel : Form
    {
        public DailyCaseImportorFromExcel()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            this.btnLoad.Enabled = false;

            Stream fs = new FileStream("G:\\JIRA.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            IWorkbook workbook = new HSSFWorkbook(fs);
            ISheet sheet = workbook.GetSheet("All Case");

            if (sheet != null)
            {
                IRow firstRow = sheet.GetRow(0);
                int cellCount = firstRow.LastCellNum;   // 一行最后一个cell的编号 即总的列数
                int rowCount = sheet.LastRowNum;        // 最后一列的标号

                int startRow = 1;
                for (int i = startRow; i <= rowCount; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue; //没有数据的行默认是null　　　　　　　

                    string casenum = row.GetCell(1).ToString();

                    List<string> cases = new List<string>();
                    cases.Add(casenum);
                    var getCaselist = SalesforceProxy.GetCaseList(cases);
                    var caseList = await getCaselist;
                    foreach (var caseInfo in caseList)
                    {
                        if(caseInfo != null)
                        {
                            System.Console.WriteLine(casenum + "," + caseInfo.Origin);
                        }
                    }
                }
            }

            this.btnLoad.Enabled = true;
        }
    }
}
