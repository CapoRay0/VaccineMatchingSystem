using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineMatchDBSource;

namespace DataFormatTransfer
{
    public class ExcelDataManager
    {
        /// <summary>
        /// Excel轉換為DataTable
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataTable GetDataTableFromExcelFile(string filePath)
        {
            FileStream fs = null;
            DataTable dt = new DataTable();
            try
            {
                IWorkbook wb = null;
                fs = File.Open(filePath, FileMode.Open, FileAccess.Read);
                switch (Path.GetExtension(filePath).ToUpper())
                {
                    case ".XLS":
                        {
                            wb = new HSSFWorkbook(fs);
                        }
                        break;
                    case ".XLSX":
                        {
                            wb = new XSSFWorkbook(fs);
                        }
                        break;
                }
                if (wb.NumberOfSheets > 0)
                {
                    ISheet sheet = wb.GetSheetAt(0);
                    IRow headerRow = sheet.GetRow(0);
                    //處理標題列
                    for (int i = headerRow.FirstCellNum; i < headerRow.LastCellNum; i++)
                    {
                        dt.Columns.Add(headerRow.GetCell(i).StringCellValue.Trim());
                    }
                    IRow row = null;
                    DataRow dr = null;
                    CellType ct = CellType.Blank;
                    //標題列之後的資料
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        dr = dt.NewRow();
                        row = sheet.GetRow(i);
                        if (row == null) continue;
                        for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                        {
                            ct = row.GetCell(j).CellType;
                            //如果此欄位格式為公式 則去取得CachedFormulaResultType
                            if (ct == CellType.Formula)
                            {
                                ct = row.GetCell(j).CachedFormulaResultType;
                            }
                            if (ct == CellType.Numeric)
                            {
                                dr[j] = row.GetCell(j).NumericCellValue;
                            }
                            else
                            {
                                dr[j] = row.GetCell(j).ToString().Replace("$", "");
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                }
                fs.Close();
            }
            finally
            {
                if (fs != null) fs.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// DataTable輸出為Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Outpath"></param>
        /// <returns></returns>
        public static bool DataTableToExcel(DataTable dt, string Outpath)
        {
            bool result = false;
            try
            {
                if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(Outpath))
                { throw new Exception("輸入的DataTable或路徑例外"); }
                int sheetIndex = 0;
                //根據輸出路徑的擴展名判斷workbook的實體型別
                IWorkbook workbook = null;
                string pathExtensionName = Outpath.Trim().Substring(Outpath.Length - 5);
                if (pathExtensionName.Contains(".xlsx"))
                {
                    workbook = new XSSFWorkbook();
                }
                else if (pathExtensionName.Contains(".xls"))
                {
                    workbook = new HSSFWorkbook();
                }
                else
                {
                    Outpath = Outpath.Trim() + ".xls";
                    workbook = new HSSFWorkbook();
                }
                //將DataTable匯出為Excel
                // foreach (DataTable dt in dataSet.Tables)

                sheetIndex++;
                if (dt != null && dt.Rows.Count > 0)
                {
                    ISheet sheet = workbook.CreateSheet(string.IsNullOrEmpty(dt.TableName) ? ("sheet" + sheetIndex) : dt.TableName);//創建一個名稱為Sheet0的表
                    int rowCount = dt.Rows.Count;//行數
                    int columnCount = dt.Columns.Count;//列數

                    //設定列頭
                    IRow row = sheet.CreateRow(0);//excel第一行設為列頭
                    for (int c = 0; c < columnCount; c++)
                    {
                        ICell cell = row.CreateCell(c);
                        cell.SetCellValue(dt.Columns[c].ColumnName);
                    }

                    //設定每行每列的單元格,
                    for (int i = 0; i < rowCount; i++)
                    {
                        row = sheet.CreateRow(i + 1);
                        for (int j = 0; j < columnCount; j++)
                        {
                            ICell cell = row.CreateCell(j);//excel第二行開始寫入資料
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                        }
                    }
                }


                //向outPath輸出資料
                using (FileStream fs = File.OpenWrite(Outpath))
                {
                    workbook.Write(fs);//向打開的這個xls檔案中寫入資料
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        public static DataTable GetUserFeedback()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT [FeedbackID]
                        , [FName]
                        , [Email]
                        , [Reason]
                        , [Opinion]
                        , [FeedbackGet]
                    FROM [Feedback]
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            try
            {
                return DBHelper.ReadDataTable(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }
    }
}
