using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automation.Classes
{
    public enum ExcelType
    {
        XLS, XLSX
    }
   public  class ExcelReader
    {
        String szConnectionString;
        public ExcelReader(String szFilePath, ExcelType excelType = ExcelType.XLSX)
        {
            // if the File extension is .XLSX using below connection string
            szConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + szFilePath + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";
            if (excelType == ExcelType.XLS)
                szConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = '" + szFilePath + "';Extended Properties=\"Excel 8.0;HDR=YES;\"";
        }

        public DataTable ReadExcel(String SheetName)
        {
            using (OleDbConnection conn = new OleDbConnection(szConnectionString))
            {
                conn.Open();
                OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter
                ("select * from ["+SheetName+"$]", conn);
                DataSet excelDataSet = new DataSet();
                objDA.Fill(excelDataSet);
                DataTable dataTable = excelDataSet.Tables[0];
                return dataTable;
            }
        }
        public DataTable ReadExcel()
        {
            using (OleDbConnection conn = new OleDbConnection(szConnectionString))
            {
                conn.Open();
                OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter
                ("select * from [Sheet1$]", conn);
                DataSet excelDataSet = new DataSet();
                objDA.Fill(excelDataSet);
                DataTable dataTable = excelDataSet.Tables[0];
                return dataTable;
            }
        }

        public void UpdateData(String query,ref byte errorByte, ref string errorMsg)
        {
            using (OleDbConnection conn = new OleDbConnection(szConnectionString))
            {
                errorByte = 0;
                errorMsg = "";
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //exception here
                    errorByte = 101;
                    errorMsg = ex.Message;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

        }

        public void Write(DataTable dataTable)
        {
            
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;
                // Start Excel and get Application object.  
            excel = new Microsoft.Office.Interop.Excel.Application();
            // for making Excel visible  
            excel.Visible = false;
            excel.DisplayAlerts = false;
            // Creation a new Workbook  
            excelworkBook = excel.Workbooks.Add(Type.Missing);
            // Workk sheet  
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "Test work sheet";
        }
    }
}
