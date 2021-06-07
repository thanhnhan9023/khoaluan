using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using main.DTO;
using Rule = main.DTO.Rule;

namespace main.Controller
{
    public static class K_anomymityCore
    {
        public static DataTable Update_FieldNameID(DataTable dt, List<string> field_ID)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                for (int g = 0; g < field_ID.Count; g++)
                {
                    dt.Rows[i][field_ID[g]] = "*";
                }
            }
            return dt;
        }

        public static DataTable Upadte_Fieldquasi1_fix1(DataTable dt, int k, List<string> fields, List<int> index)  // giữ theo index rule
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


                        for (int g = 0; g < index.Count; g++)
                        {
                            if (index[g] == i)
                            {
                                i++;
                                break;
                            }
                        }


                        if (i == dt.Rows.Count)
                        {
                            break;
                        }
                        int[] maxIndex = new int[fields.Count];
                        maxIndex[fieldIndex] = Array.IndexOf(count[fieldIndex].ToArray(), count[fieldIndex].Max());
                        string vas = contents[fieldIndex][maxIndex[fieldIndex]];
                        result.Rows[i][fields[fieldIndex]] = vas;
                    }


                    #endregion
                    rowcount += k - 1;
                }


            }
            return result;
        }

        public static DataTable Upadte_Fieldquasi1_fix(DataTable dt, int k, List<string> fields) // k_anomymity bình thường
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
        public static DataTable CopyTb(DataTable dt, int start, int end)// chưa có columns
        {
            DataTable result = new DataTable();
            //result.Rows.Clear();
            //foreach (DataColumn data in dt.Columns)
            //{
            //    result.Columns.Add(data);
            //}
            //for(int i=start;i<end;i++)
            //{
            //    dt.Rows.Add();
            //         for(int j=0;j<dt.Columns.Count;j++)
            //        {
            //        dt.Rows[end - 1][j++] = dt.Rows[i][j].ToString();
            //          }
            //}



            List<DataRow> rows = new List<DataRow>();
            foreach (DataColumn item in dt.Columns)
            {
                result.Columns.Add(item.Caption);
            }
            for (int i = start; i < end; i++)
            {
                if (i >= dt.Rows.Count)
                {
                    break;
                }
                result.Rows.Add(dt.Rows[i].ItemArray);
            }
            //int k = start;
            //foreach (DataRow r in dt.Rows)
            //{
            //    if (k < end)
            //    {
            //        result.ImportRow(r);
            //        k++;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            /* for (int i = start; i < end; i++)
             {
                 // chỗ này sửa lại tí là hết
                 result.Rows.Add();
                 foreach (DataColumn j in dt.Columns)
                 {

                     foreach (DataRow row in dt.Rows)
                     {
                         dt.Rows[dt2.Rows.Count - 1][data] = row; // gán giá trị vào
                         // nhầm chỗ này debug tiếp chắc xem coi chạy dc không
                     }

                 }
             }*/
            return result;
        }
        public static void AddTb(ref DataTable k_ano, DataTable temp_)
        {
            foreach (DataRow r in temp_.Rows)
            {
                k_ano.Rows.Add(r.ItemArray);
            }
        }
        public static DataTable update_quasi_k(DataTable dt, int k, List<string> fields, List<Rule> rl1, List<Rule> rl2, float defaultvalues)
        {

  
            DataTable result = dt.Copy(); // lấy data từ bảng ra 
            DataTable final = dt.Copy(); // lấy data từ bảng ra
            final.Rows.Clear();
            for (int rowcount = 0; rowcount < result.Rows.Count; rowcount += k) // duyệt hết bảng, qua mỗi lần k dòng
            {
                bool isDone = false;
                DataTable temp = CopyTb(result, rowcount, rowcount + k);
                //duyệt từng fields

                for (int field = 0; field < fields.Count; field++)
                { //lặp 2 field chỗ này
                    List<ObjectCount> obj = demsolanxuathien(temp, 0, k, fields[field]); // lấy ra 1 list giá trị sẽ thay đổi và sắp từ cao xuống thấp

                    for (int iobj = 0; iobj < obj.Count; iobj++) // thử từng cách biến đổi từ cao xuống thấp
                    {
                        for (int t = 0; t < k; t++) //update k dòng //
                        {

                            temp.Rows[t][fields[field]] = obj[iobj].Values1;
                        }
                        //tính % sau khi thay đổi 
                    }

                }// cái break kia chỉ thoát vòng for field thôi nghĩ có lỗi k nhĩ
                bool isAccept = true;
                for (int ir = 0; ir < rl1.Count; ir++)
                {
                    if (tinhsuportOneRule(temp, rl1[ir], rl2[ir], 0, k) <= defaultvalues)
                    {
                        AddTb(ref final, temp);//thỏa thì lấy k dòng nà
                        isAccept = false;
                        break; //không thỏa thì break vòng rule này
                    }
                }
                if (isAccept) //% thỏa thì chấp nhận cách biến đổi này
                {
                    AddTb(ref final, temp);//thỏa thì lấy k dòng này
                    isDone = true;
                    break; //break, không biến đổi nữa => thoát vòng for (int iobj = 0; .... quên mà v còn vòng for trê
                }
                if (!isDone) //nếu thử các giá trị của k mà không đạt ngưỡng thì giữ như cũ
                {
                    AddTb(ref final, CopyTb(result, rowcount, rowcount + k)); // lặp lần đầu add 3 dòng, xong thêm lần nữa nó lại add thêm , mà đáng ra phải cập nhật lại chứ không phải add thêm, nên mai làm cái hàm update nữa =)))))) ok ông  v mai giúp tôi nha để mốt viết báo cáo ->>> nhưng mà không chắc là hoạt động ok nha, mới là triển khai ý tưởng ra code thôi  
                }

            }
            return final;

        }
        public static DataTable Upadte_Fieldquasi1_Test2(DataTable source, int k, List<string> fields, List<Rule> rl1, List<Rule> rl2, float defaultvalues)
        {
            DataTable ano = source.Copy(); // bảng ano
            DataTable k_ano = source.Copy(); // bảng k_ano

            k_ano.Rows.Clear();
           
            for (int rowcount = 0; rowcount < ano.Rows.Count; rowcount += k) // duyệt tất cả dòng theo hệ số k
            {
                float tile = 0;
                DataTable temp_ = CopyTb(ano, rowcount, rowcount + k); // di chuyển k dòng sang bảng temp_ (Dữ liệu tạm thời)
                int uutien = 0;
                for (int countRule = 0; countRule < rl1.Count; countRule++)
                {
                    if (k_ano.Rows.Count > 0)
                    {
                        tile = tinhsuportOneRule(k_ano, rl1[countRule], rl2[countRule], 0, k);
                    }
                    if (kiemtraruleInTable(temp_, rl1, rl2, countRule, k) && tile <= defaultvalues) //Nếu luật kết hợp có tồn tại trong bảng temp_ && tỉ lệ < ngưỡng thì
                    {
                        if (uutien % 2 == 0)
                        {
                            uutien++;
                            int dem = 0;
                            for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                            {

                                //List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                                if (dem > 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl2[countRule].Values, 0, k);
                                    dem++;
                                }
                                if (dem == 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl1[countRule].Values, 0, k);
                                    dem++;
                                }


                                //AddTb( ref k_ano, temp_);
                            }
                        }
                        else
                        {
                            countRule++;
                            int dem = 0;
                            for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                            {

                                //List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                                if (dem > 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl2[countRule].Values, 0, k);
                                    dem++;
                                }
                                if (dem == 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl1[countRule].Values, 0, k);
                                    dem++;
                                }


                                //AddTb( ref k_ano, temp_);
                            }

                        }
                    }
                    else if (kiemtraruleInTable(ano, rl1, rl2, countRule, k) && tile <= defaultvalues)//Nếu luật kết hợp có tồn tại trong bảng ano && tỉ lệ < ngưỡng
                    {
                        //for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                        //{
                        //    List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                        //    temp_ = update_quasi(temp_, fields[fieldcount], lst[0].Values1, 0, k);
                        //    //AddTb(ref k_ano, temp_);
                        //}
                        if (uutien % 2 == 0)
                        {
                            uutien++;
                            int dem = 0;
                            for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                            {

                                //List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                                if (dem > 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl2[countRule].Values, 0, k);
                                    dem++;
                                }
                                if (dem == 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl1[countRule].Values, 0, k);
                                    dem++;
                                }


                                //AddTb( ref k_ano, temp_);
                            }
                        }
                        else
                        {
                            countRule++;
                            int dem = 0;
                            for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                            {

                                //List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                                if (dem > 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl2[countRule].Values, 0, k);
                                    dem++;
                                }
                                if (dem == 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl1[countRule].Values, 0, k);
                                    dem++;
                                }


                                //AddTb( ref k_ano, temp_);
                            }

                        }
                    }
                    else if (kiemtraruleInTable(k_ano, rl1, rl2, countRule, k) && tile <= defaultvalues)//Nếu luật kết hợp có tồn tại trong bảng k_ano && tỉ lệ < ngưỡng
                    {
                        //for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                        //{
                        //    List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                        //    temp_ = update_quasi(temp_, fields[fieldcount], lst[0].Values1, 0, k);
                        //    AddTb(ref k_ano, temp_);
                        //}
                        if (uutien % 2 == 0)
                        {
                            uutien++;
                            int dem = 0;
                            for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                            {

                                //List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                                if (dem > 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl2[countRule].Values, 0, k);
                                    dem++;
                                }
                                if (dem == 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl1[countRule].Values, 0, k);
                                    dem++;
                                }


                                //AddTb( ref k_ano, temp_);
                            }
                        }
                        else
                        {
                            countRule++;
                            int dem = 0;
                            for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                            {

                                //List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                                if (dem > 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl2[countRule].Values, 0, k);
                                    dem++;
                                }
                                if (dem == 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl1[countRule].Values, 0, k);
                                    dem++;
                                }


                                //AddTb( ref k_ano, temp_);
                            }

                        }
                    }
                    else if (!kiemtraruleInTable(temp_, rl1, rl2, countRule, k) && !kiemtraruleInTable(k_ano, rl1, rl2, countRule, k) &&
                        !kiemtraruleInTable(ano, rl1, rl2, countRule, k)) //Nếu luật kết hợp Không có tồn tại trong bảng k_ano && ano && temp_
                    {
                        for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                        {
                            List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                            temp_ = update_quasi(temp_, fields[fieldcount], lst[0].Values1, 0, k);
                            //AddTb(ref k_ano, temp_);
                        }
                    }
                    else//Khác (đã vượt ngưỡng)
                    {
                        //for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                        //{
                        //    List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                        //    temp_ = update_quasi(temp_, fields[fieldcount], lst[0].Values1, 0, k);
                        //}
                        if (uutien % 2 == 0)
                        {
                            uutien++;
                            int dem = 0;
                            for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                            {

                                //List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                                if (dem > 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl2[countRule].Values, 0, k);
                                    dem++;
                                }
                                if (dem == 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl1[countRule].Values, 0, k);
                                    dem++;
                                }


                                //AddTb( ref k_ano, temp_);
                            }
                        }
                        else
                        {
                            countRule++;
                            int dem = 0;
                            for (int fieldcount = 0; fieldcount < fields.Count; fieldcount++)
                            {

                                //List<ObjectCount> lst = demsolanxuathien(temp_, 0, k, fields[fieldcount]);
                                if (dem > 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl2[countRule].Values, 0, k);
                                    dem++;
                                }
                                if (dem == 0)
                                {
                                    temp_ = update_quasi(temp_, fields[fieldcount], rl1[countRule].Values, 0, k);
                                    dem++;
                                }


                                //AddTb( ref k_ano, temp_);
                            }

                        }

                    }


                }
                AddTb(ref k_ano, temp_);
            }
            return k_ano;
        }

        //code cũ ở đây
        #region origin
        /*  for (int t = 0; t < k; t++) // vòng for này để lặp  lại theo số k  vì sẽ chọn từng dòng dữ liệu để thay đổi k dòng 
            {
                if (lap == 0)
                {
                    DataTable result = dt.Copy(); // lấy data từ bảng ra 
                   
                    for (int rowcount = 0; rowcount < result.Rows.Count; rowcount++) // row  của  bảng
                    {

                        for (int fieldIndex = 0; fieldIndex < fields.Count; fieldIndex++)// duyệt trong list Field để lấy  ra tên trường
                        {

                            if (rowcount + k >= result.Rows.Count)
                            {
                                break;
                            }
                            List<ObjectCount> obj = demsolanxuathien(result, rowcount, rowcount + k, fields[fieldIndex]);
                            for (int i = rowcount; i < rowcount + k; i++) //i là số dòng trong khoảng K
                            {

                                result.Rows[i][fields[fieldIndex]] = obj[t].Values1;
                            }
                        }
                        rowcount += k - 1;
                    }
                    int dem = 0;
                    List<float> lstsuport = ListsuportOneRule(result, rl1, rl2);
                    for (int x = 0; x < lstsuport.Count; x++)
                    {
                        if (lstsuport[x] >= defaultvalues)
                        {
                            dem++;
                        }

                    }
                    if(dem==lstsuport.Count)
                    {
                        return result;
                    }
                }
                else
                {
                    DataTable datanew = dt.Copy();
                    for (int rowcount = 0; rowcount < datanew.Rows.Count; rowcount++)
                    {

                        for (int fieldIndex = 0; fieldIndex < fields.Count; fieldIndex++)
                        {

                            if (rowcount + k >= datanew.Rows.Count)
                            {
                                break;
                            }
                            List<ObjectCount> obj = demsolanxuathien(datanew, rowcount, rowcount + k, fields[fieldIndex]);
                            for (int i = rowcount; i < rowcount + k; i++) //i là số dòng trong khoảng K
                            {

                                datanew.Rows[i][fields[fieldIndex]] = obj[t].Values1;
                            }
                        }
                        rowcount += k - 1;
                    }
                    int dem = 0;
                    List<float> lstsuport = ListsuportOneRule(datanew, rl1, rl2);
                    for (int x = 0; x < lstsuport.Count; x++)
                    {
                        if (lstsuport[x] >= defaultvalues)
                        {
                            dem++;
                        }

                    }
                    if (dem == lstsuport.Count)
                    {
                        return datanew;
                    }


                }
              
                lap++;

               }*/
        #endregion
        public static DataTable update_quasi(DataTable dt, string fieldname, string values, int start, int end)
        {

            for (int i = start; i < end; i++)
            {
                if (i >= dt.Rows.Count)
                {
                    break;
                }
                dt.Rows[i][fieldname] = values;
            }

            return dt; ;
        }
        public static bool kiemtraruleInTable(DataTable dt, List<Rule> rule1, List<Rule> rule2, int i, int k)
        {
            if (indexRuleToK(dt, rule1[i], rule2[i], 0, k).Count > 0)
            {
                return true;
            }
            else
                return false;


        }
        public static DataTable ListFieldName(DataTable dt)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Field_Name");
            dt2.Columns.Add("Status", typeof(bool));

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt2.Rows.Add(dt.Columns[i], false);
            }
            return dt2;
        }

        public static float tinhsuport(DataTable dt, List<string> Field_Name, List<string> values)
        {

            List<int> index = new List<int>();
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool isFind = true;
                for (int j = 0; j < Field_Name.Count; j++)
                {

                    if (dt.Rows[i][Field_Name[j]].ToString() != values[j])
                    {
                        isFind = false;
                        break;
                    }

                }
                if (isFind)
                {

                    count++;
                }
            }
            return (float)count / dt.Rows.Count;
        }
        public static float tinhsuportOneRule(DataTable dt, Rule rule, Rule rule2, int start, int end) //tính k dòng: end= start + k
        {

            //List<int> index = new List<int>();
            //List<int> lstcount = new List<int>();
            int count = 0;
            for (int i = start; i < end; i++)
            {
                bool isFind = true;


                if (dt.Rows[i][rule.Field_name].ToString() != rule.Values
                    || dt.Rows[i][rule2.Field_name].ToString() != rule2.Values
                    )
                {
                    isFind = false;
                }
                if (isFind)
                {

                    count++;
                }
            }
            return (float)count / dt.Rows.Count;
        }
        public static List<int> indexRuleToK(DataTable dt, Rule rule, Rule rule2, int start, int end)
        {
            int count = 0;
            List<int> index = new List<int>();
            for (int i = start; i < end; i++)
            {
                bool isFind = true;

                if (i >= dt.Rows.Count)
                {
                    break;
                }
                if (dt.Rows[i][rule.Field_name].ToString() != rule.Values
                    || dt.Rows[i][rule2.Field_name].ToString() != rule2.Values
                    )
                {
                    isFind = false;
                }
                if (isFind)
                {

                    count++;
                    index.Add(i);
                }
            }
            return index;
        }
        public static List<int> indexRule(DataTable dt, Rule rule, Rule rule2)
        {
            int count = 0;
            List<int> index = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool isFind = true;


                if (dt.Rows[i][rule.Field_name].ToString() != rule.Values
                    || dt.Rows[i][rule2.Field_name].ToString() != rule2.Values
                    )
                {
                    isFind = false;
                }
                if (isFind)
                {

                    count++;
                    index.Add(i);
                }
            }
            return index;
        }
        #region ListsuportOneRule
        //public static List<float> ListsuportOneRule(DataTable dt, List<Rule> rules1,List<Rule> rules2, int start, int end)

        //{
        //    List<float> lstsuport = new List<float>();
        //    for(int i=0;i<rules1.Count;i++)
        //    {
        //        lstsuport.Add(tinhsuportOneRule(dt, rules1[i], rules2[i], start, end));
        //    }
        //    return lstsuport;
        //}
        #endregion
        public static List<int> ListIndexRule(DataTable dt, List<Rule> lst, List<Rule> lst2)
        {
            List<int> index = new List<int>();
            for (int i = 0; i < lst.Count; i++)
            {

                int count = 0;

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    bool isFind = true;


                    if (dt.Rows[j][lst[i].Field_name].ToString() != lst[i].Values
                        || dt.Rows[j][lst2[i].Field_name].ToString() != lst2[i].Values
                        )
                    {
                        isFind = false;
                    }
                    if (isFind)
                    {

                        count++;
                        index.Add(j);
                    }
                }
            }
            return index;
        }

        //test lai hàm này đã
        public static List<ObjectCount> demsolanxuathien(DataTable dt, int start, int end, string fieldName)
        {

            List<ObjectCount> lstob = new List<ObjectCount>();

            for (int j = start; j < end; j++)
            {
                if (j >= dt.Rows.Count)
                {
                    break;
                }
                string fieldValue = dt.Rows[j][fieldName].ToString();
                if (lstob.Find(p => p.Values1 == fieldValue) == null)
                {
                    int count = 1;
                    for (int k = j + 1; k < end; k++)
                    {
                        if (k >= dt.Rows.Count)
                        {
                            break;
                        }
                        if (fieldValue == dt.Rows[k][fieldName].ToString())
                            count++;
                    }
                    lstob.Add(new ObjectCount(fieldValue, count));
                }
            };
            return lstob.OrderByDescending(c => Convert.ToInt32(c.Count1)).ToList();
        }
        public static DataTable Upadte_Fieldquasi1_Test(DataTable dt, int k, List<string> fields, List<int> index)
        {

            DataTable datanew = dt.Copy();
            for (int rowcount = 0; rowcount < datanew.Rows.Count; rowcount++)
            {


                for (int fieldIndex = 0; fieldIndex < fields.Count; fieldIndex++)
                {
                    if (rowcount + k >= datanew.Rows.Count)
                    {
                        break;
                    }
                    bool flag = false;
                    for (int g = 0; g < index.Count; g++)
                    {

                        if (index[g] == rowcount)
                        {
                            string values = datanew.Rows[rowcount][fields[fieldIndex]].ToString();
                            for (int i = rowcount; i < rowcount + k; i++) //i là số dòng trong khoảng K
                            {

                                datanew.Rows[i][fields[fieldIndex]] = values;
                            }
                        }
                    }
                    if (flag)
                        break;
                    if (!flag)
                    {

                        List<ObjectCount> obj = demsolanxuathien(datanew, rowcount, rowcount + k, fields[fieldIndex]);
                        for (int i = rowcount; i < rowcount + k; i++) //i là số dòng trong khoảng K
                        {

                            datanew.Rows[i][fields[fieldIndex]] = obj[0].Values1;
                        }
                    }
                }
                rowcount += k - 1;
            }
            return datanew;
        }


    }
}
