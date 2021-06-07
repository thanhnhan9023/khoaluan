using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_anonymity.Model
{
  public static class ExportExcel
    {
        public static DataTable getData(string filename)
        {
            DataTable dt = new DataTable();

            dt = new System.Data.DataTable();
            if (filename != string.Empty)
            {
                using (XLWorkbook workbook = new XLWorkbook(filename))
                {
                    bool isFirstRow = true;
                    var rows = workbook.Worksheet(1).RowsUsed();
                    foreach (var row in rows)
                    {

                        if (isFirstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                                dt.Columns.Add(cell.Value.ToString());
                            isFirstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Rows[dt.Rows.Count - 1][i++] = cell.Value.ToString();
                            }
                        }
                    }
                }
            }
            return dt;
        }
       
    }
}
