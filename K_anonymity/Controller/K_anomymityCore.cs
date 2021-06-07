using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_anonymity.Controller
{
   public static class K_anomymityCore
    {
        public static DataTable Upadte_Fieldquasi1_fix(DataTable dt, int k, List<string> fields)
        {
            DataTable result = dt;

            for (int rowcount = 0; rowcount < dt.Rows.Count; rowcount++)
            {
                List<string>[] contents = new List<string>[fields.Count];//Danh sách các giá trị của field khác nhau
                List<int>[] count = new List<int>[fields.Count];//danh sách biến đếm
                //Lấy list danh sách và tính số lần xuất hiện
                #region Lấy list danh sách và tính số lần xuất hiện                
                for (int i = rowcount; i < rowcount + k; i++) //i là số dòng trong khoảng K
                {
                    if (i == dt.Rows.Count) //trường hợp quá số dòng thì dừng
                    {
                        break;
                    }
                    for (int fieldIndex = 0; fieldIndex < fields.Count; fieldIndex++)
                    {
                        string fieldValue = dt.Rows[i][fields[fieldIndex]].ToString();
                        if (contents[fieldIndex] == null) //trường hợp chưa có giá trị field nào (mới khởi tạo)
                        {
                            contents[fieldIndex] = new List<string>();
                            contents[fieldIndex].Add(fieldValue);
                            count[fieldIndex] = new List<int>();
                            count[fieldIndex].Add(1);
                        }
                        else
                        {
                            int valueIndex = Array.IndexOf(contents[fieldIndex].ToArray(), fieldValue);
                            if (valueIndex < 0)
                            {
                                contents[fieldIndex].Add(fieldValue);
                                count[fieldIndex].Add(1);
                            }
                            else
                            {
                                count[fieldIndex][valueIndex]++;
                            }
                        }
                    }
                }
                #endregion
                //Set lại giá trị cho table
                #region Set lại giá trị cho table
                for (int fieldIndex = 0; fieldIndex < fields.Count; fieldIndex++)
                {
                    for (int i = rowcount; i < rowcount + k; i++) //i là số dòng trong khoảng K
                    {
                        if (i == dt.Rows.Count)
                        {
                            break;
                        }

                        int[] maxIndex = new int[fields.Count];
                        maxIndex[fieldIndex] = Array.IndexOf(count[fieldIndex].ToArray(), count[fieldIndex].Max());
                        string vas = contents[fieldIndex][maxIndex[fieldIndex]];
                        result.Rows[i][fields[fieldIndex]] = vas;
                    }
                }
                #endregion
                rowcount += k - 1;
            }
            return result;
        }
        public static DataTable Update_Fieldquasi(DataTable dt, int k, List<string> lst)
        {
            if (dt.Rows.Count <= 0) // data null
            {
                return null;
            }
            if (lst.Count <= 0)
                return null;
            //int dem = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List<List<int>> Dem = new List<List<int>>();
                List<List<string>> GtriField = new List<List<string>>();
                //int ValueCount = 0;
                for (int j = i; j < k + i; j++)
                {
                    //Lay toan bo gia tri khac nhau cua field dang xet
                    List<string> RowValue = new List<string>();
                    List<int> temp = new List<int>();
                    if (i == j)
                    {
                        for (int g = 0; g < lst.Count; g++)
                        {
                            RowValue.Add(dt.Rows[j][lst[g]].ToString());
                            temp.Add(1);
                        }
                        GtriField.Add(RowValue);
                        Dem.Add(temp);
                    }
                    else
                    {
                        for (int g = 0; g < lst.Count; g++)
                        {
                            foreach (string item in GtriField[g])
                            {
                                string fieldVal = dt.Rows[j][lst[g]].ToString();
                                if (fieldVal != item)
                                {
                                    GtriField[j].Add(fieldVal);
                                    Dem[j].Add(1);
                                }
                                else
                                {
                                    Dem[j][g]++;
                                }
                            }
                        }
                    }

                    for (int g = 0; g < lst.Count; g++)
                    {
                        string fieldVal = dt.Rows[j][lst[g]].ToString();
                        for (int n = 0; n < GtriField[g].Count; n++)
                        {
                            if (fieldVal == GtriField[n][g])
                            {
                                Dem[n][g]++;
                            }
                        }
                    }
                }
                List<string> MaxValue = new List<string>();
                for (int y = 0; y < lst.Count; y++)
                {
                    int MaxIndex = Dem[y].IndexOf(Dem[y].Max(x => x));
                    MaxValue.Add(GtriField[y][MaxIndex]);
                }
                for (int j = i; j < k + i; j++)
                {
                    for (int t = 0; t < lst.Count; t++)
                    {
                        dt.Rows[j][t] = MaxValue[t];
                    }
                }
                i += k - 1;
            }

            return dt;
        }
     
    }
}
