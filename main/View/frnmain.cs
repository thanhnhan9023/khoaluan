using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using main.DTO;
using main.Controller;
using main.Model;
using Rule = main.DTO.Rule;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Threading;
using System.IO;
using ExcelDataReader;
using System.Diagnostics;

namespace main.View
{
    public partial class frnmain : DevExpress.XtraEditors.XtraForm
    {
        string file_name = "";
        DataTable dt;
        //DataTable dt2;
        List<int> lstcombox = new List<int>();
        List<Rule> lstrule1 = new List<Rule>();
        List<Rule> lstrule2 = new List<Rule>();
        List<int> lstcount = new List<int>();
        List<int> lstcount2 = new List<int>();
        List<string> lstFielName = new List<string>();
        Stopwatch st;
        public frnmain()
        {
            InitializeComponent();
            skins();
           
           
        }
        public void skins()


        {
            DevExpress.LookAndFeel.DefaultLookAndFeel thems = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            thems.LookAndFeel.SkinName = "Valentine";

        }

        private void main_Load(object sender, EventArgs e)
        {

        }
        int openfile = 0;
        private void btnOpenFile_Click(object sender, EventArgs e)
        {

         
            dt = new DataTable();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                st = new Stopwatch();
                st.Reset();
                st.Restart();
                GridData.DataSource = null;
                gridView1.Columns.Clear();
             ExcelFileReader(dlg.FileName, "Sheet3");
            
                //GridData.DataSource = null;
                //gridView1.Columns.Clear();
                ////gridView1.OptionsView.ColumnAutoWidth = false;
                ////gridView1.OptionsView.BestFitMaxRowCount = -1;
                //gridView1.BestFitColumns();
                //file_name = dlg.FileName;
                //Thread obj1 = new Thread(load);
                //obj1.Start();
                //GridData.DataSource = dt;
                //gridView1.OptionsView.ColumnAutoWidth = false;
                //gridView1.OptionsView.BestFitMaxRowCount = -1;
                //gridView1.BestFitColumns();
                //dt = ExportExcel.getData(file_name);




                //GridData = new GridControl
                //{
                //    Top = 1,
                //    Left = 1,
                //    Width = panel1.ClientSize.Width,
                //    Height = panel1.ClientSize.Height
                //};

                //GridView gridView1 = new GridView();
                //gridView1.OptionsView.ColumnAutoWidth = false;
                //gridView1.OptionsView.BestFitMaxRowCount = -1;
                //gridView1.BestFitColumns();
                //if (GridData is GridView)
                //{
                //    // auto best fit...
                //    (view as GridView).BestFitMaxRowCount = 5000;   // just to avoid to many compares
                //    (view as GridView).BestFitColumns();
                //    foreach (GridColumn item in (view as GridView).Columns) // reduce the width of very wide columns
                //    {
                //        item.Width = (item.Width > 1000) ? 1000 : item.Width;
                //    }
                //}
                //panel1.Controls.Add(GridData);

                //GridData.DataSource = dt;
                //GridData.RefreshDataSource();
                //GridData.DataSource = dt;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.OptionsView.BestFitMaxRowCount = -1;
                gridView1.BestFitColumns();




                load_Field();
                openfile++;



            }
            st.Stop();
            float timeelapsed = (float)st.ElapsedMilliseconds / 1000;
            MessageBox.Show(timeelapsed.ToString());
        }
        public void load()
        {
            OpenFileDialog fl = new OpenFileDialog();
            fl.ShowDialog();
            string path = fl.FileName;
             
          
        }
        public void ExcelFileReader(string path,string sheetname)
        {
            //var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            //var excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            //var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            //{
            //    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
            //    {
            //        UseHeaderRow = true
            //    }
            //});
           
                       var fs = File.Open(path, FileMode.Open, FileAccess.Read);
           
            var reader = ExcelReaderFactory.CreateReader(fs);
            var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true 
                }
            });

            fs.Close();

            


            DataTable dt = dataSet.Tables[0];








            GridData.DataSource = dt;
        }
        public bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
        public List<string> addFiled_NameID()
        {
            List<string> lst = new List<string>();
         for(int i =0;i<gridView2.DataRowCount-1;i++)
            {
              string x= gridView2.GetRowCellValue(i, "Status").ToString();
            
                if(x=="True")
                {
                    string t = gridView2.GetRowCellValue(i, "Field_Name").ToString();
                    lst.Add(t);
                }
                
            }
            return lst;
                
        }
        public List<string> addField_Quasi()
        {
            List<string> lst = new List<string>();
            for (int i = 0; i < gridView3.DataRowCount - 1; i++)
            {
                string x = gridView3.GetRowCellValue(i, "Status").ToString();

                if (x == "True")
                {
                    string t = gridView3.GetRowCellValue(i, "Field_Name").ToString();
                    lst.Add(t);
                }

            }
            return lst;
        }
        public void load_data(DataTable dt)
        {
          
        }

        private void btn_SaveFile_Click(object sender, EventArgs e)
        {

        }
        //public float suport()
        //{

        //}

        private void btnRunQuaSi_Click(object sender, EventArgs e)
        {
           
            
            lstFielName = addField_Quasi();
            if (txtHeSoK.Text == string.Empty)
            {

                MessageBox.Show("Chua nhap he so k");
                return;
            }

           
            if (panelControl1.Controls.Count > 0)
            {
                foreach (Control contr in panelControl1.Controls)
                {
                    for (int i = 0; i < lstcount.Count; i++)
                    {
                      
                        //if (contr is TextEdit txtEdit)
                        //{
                        //    Rule rule1 = new Rule();
                        //    rule1.Field_name = txtEdit.Tag.ToString();
                        //    rule1.Values
                        //}
                        if (contr is TextEdit textEdit)
                        {
                            Fields fields = (Fields)textEdit.Tag;
                            if (contr.Name == "txt" + cboField_Name.SelectedValue.ToString() + lstcount[i].ToString())
                            {
                                Rule rule1 = new Rule();

                                rule1.Field_name = cboField_Name.SelectedValue.ToString();
                                rule1.Values = contr.Text;
                                lstrule1.Add(rule1);
                            }
                            if (contr.Name == "txt" + cboField_Name2.SelectedValue.ToString() + lstcount2[i].ToString())
                            {
                                Rule rule2 = new Rule();

                                rule2.Field_name = cboField_Name2.SelectedValue.ToString();
                                rule2.Values = contr.Text;
                                lstrule2.Add(rule2);
                            }
                        }
                    }
                }
            }

            DataTable data = new DataTable();
            data = K_anomymityCore.Update_FieldNameID(dt.Copy(), addFiled_NameID());


            // if (checkBox1.Checked)
            // {
            //     List<int> index = new List<int>();

            //     //    rule1.Values = 
            //     //Rule rule2 = new Rule();

            //     index=K_anomymityCore.ListIndexRule(data,lstrule1,lstrule2);
            //     GridData.DataSource = K_anomymityCore.Upadte_Fieldquasi1_fix1(data, int.Parse(txtHeSoK.Text), addField_Quasi(),index);

            // }
            //else
            //     GridData.DataSource = K_anomymityCore.Upadte_Fieldquasi1_fix(data,int.Parse(txtHeSoK.Text), addField_Quasi());


            if (rdRule.Checked)
            {
                if (txtNguong.Text == string.Empty)
                {

                    MessageBox.Show("Chua nhap nguong");
                    return;
                }
                //List<int> index = new List<int>();
                //index = K_anomymityCore.ListIndexRule(data.Copy(), lstrule1, lstrule2);
                GridData.DataSource = K_anomymityCore.Upadte_Fieldquasi1_Test2(data.Copy(), int.Parse(txtHeSoK.Text), lstFielName, lstrule1, lstrule2, float.Parse(txtNguong.Text));
                //GridData.DataSource = K_anomymityCore.update_quasi_k(data.Copy(), int.Parse(txtHeSoK.Text), lstFielName, lstrule1, lstrule2, float.Parse(txtNguong.Text));
                //GridData.DataSource = K_anomymityCore.Upadte_Fieldquasi1_Test(data.Copy(), int.Parse(txtHeSoK.Text), lstFielName,index);
            }
            else if(rdDefault.Checked)
            {
                GridData.DataSource = K_anomymityCore.Upadte_Fieldquasi1_fix(data.Copy(), int.Parse(txtHeSoK.Text), lstFielName);
            }
            else
            {
                List<int> index = new List<int>();
                index = K_anomymityCore.ListIndexRule(data.Copy(), lstrule1, lstrule2);
                GridData.DataSource = K_anomymityCore.Upadte_Fieldquasi1_fix1(data, int.Parse(txtHeSoK.Text), lstFielName,index);

            }
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
        }
      
      
      
        public void load_Field()
        {
           
         
     
            //cboField_Name.DataSource = dt2;
            //cboField_Name.DisplayMember = "Field_Name";
            //cboField_Name.ValueMember = "Field_Name";

            //foreach (DataColumn dataColumn in dt.Columns)
            //{
            //    dt2.Rows.Add(dataColumn);




            //}
            Grid_FieldID.DataSource = K_anomymityCore.ListFieldName(dt.Copy());
            GridField_Name.DataSource = K_anomymityCore.ListFieldName(dt.Copy());
            cboField_Name.DataSource= K_anomymityCore.ListFieldName(dt.Copy());
            cboField_Name.DisplayMember = "Field_Name";
            cboField_Name.ValueMember = "Field_Name";
            cboField_Name2.DataSource = K_anomymityCore.ListFieldName(dt.Copy());
            cboField_Name2.DisplayMember = "Field_Name";
            cboField_Name2.ValueMember = "Field_Name";






        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
     
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            panelControl1.Controls.Clear();
            lstrule1.Clear();
            lstrule2.Clear();
           top1 = 90;
             left1 = 20;
             top2 = 90;
             //left2 = 20;
             count = 0;
            count1 = 0;

        }
        private void btnSuport_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("");

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        int top1 = 90;
        int left1 = 20;
        int top2 = 90;
        int left2 = 20;
        int count = 0;
        int count1 = 0;
        int fieldscount = 0;
        private void cboField_Name_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fieldscount++;
            LabelControl lbl = new LabelControl();
            lbl.Name = "lbl" + cboField_Name.SelectedValue.ToString();
            lbl.Text = cboField_Name.SelectedValue.ToString();
            lbl.Top = top1;
            lbl.Left = left1;
            TextEdit txtEdit = new TextEdit();

            txtEdit.Name ="txt"+cboField_Name.SelectedValue.ToString()+count.ToString();
            txtEdit.Top = top1;
            txtEdit.Left = lbl.Right + 2;
            //txtEdit.Tag = cboField_Name.SelectedValue.ToString();
            Fields fields = new Fields
            {
                pos = fieldscount,
                Field = cboField_Name.SelectedValue.ToString()
            };
            txtEdit.Tag = fields;
            //txtEdit.Leave+=
            SimpleButton btn = new SimpleButton();
            btn.Name = "btn" + cboField_Name.SelectedValue.ToString();
            btn.Text = ">>";
            btn.Top = top1;
            btn.Size = new System.Drawing.Size(30, 24);
            btn.Left = txtEdit.Right + 10;
            int t =btn.Right;
            //Rule rl = new Rule();
            //rl.Field_name = cboField_Name.SelectedValue.ToString();
            //rl.Values = txtEdit.Text;
            //lstrule1.Add(rl);
            panelControl1.Controls.Add(lbl);
            panelControl1.Controls.Add(txtEdit);
            panelControl1.Controls.Add(btn);
            top1 += 30;
            lstcount.Add(count);
            count++;
            




        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
        }

        private void btn_Check_CheckStateChanged(object sender, EventArgs e)
        {
          
        }

        private void ckCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            // List<string> field_Name = new List<string>();
            // field_Name.Add("first_name");
            // field_Name.Add("last_name");
            // List<string> values = new List<string>();
            // values.Add("Fred");
            // values.Add("Clark");
            //float a= K_anomymityCore.tinhsuport(dt, field_Name, values);
            // XtraMessageBox.Show(a.ToString());
            //Rule t= new Rule();
            //t.Field_name1 = "first_name";
            //t.Field_name2 = "last_name";
            //t.Values_1 = "Fred";
            //t.Values_2 = "Clark";
            //Rule t1 = new Rule();
            //t1.Field_name1 = "first_name";
            //t1.Field_name2 = "last_name";
            //t1.Values_1 = "Bob";
            //t1.Values_2 = "Lopez";
            //List<Rule> lst = new List<Rule>();
            //lst.Add(t);
            //lst.Add(t1);
            //List<float> b = K_anomymityCore.ListsuportOneRule(dt, lst);
            //  List<string> lstFieldName = new List<string>();
            //  lstFieldName.Add("first_name");
            //  lstFieldName.Add("last_name");
            //List<ObjectCount>  t= K_anomymityCore.demsolanxuathien(dt, 9, 11, 1);
            //  MessageBox.Show(t[1].Values1 + "-" + t[1].Count1);


            // List<ObjectCount> list = K_anomymityCore.demsolanxuathien(dt, 0, 3, "Địa chỉ");
            //  foreach( var i in list) {
            // textBox1.Text += i.Values1 + "\t";
            // }
            //if (panelControl1.Controls.Count > 0)
            //{
            //    foreach (Control contr in panelControl1.Controls)
            //    {
            //        for (int i = 0; i < lstcount.Count; i++)
            //        {
            //            if (contr is TextEdit)
            //            {
            //                if (contr.Name == "txt" + cboField_Name.SelectedValue.ToString() + lstcount[i].ToString())
            //                {
            //                    Rule rule1 = new Rule();

            //                    rule1.Field_name = cboField_Name.SelectedValue.ToString();
            //                    rule1.Values = contr.Text;
            //                    lstrule1.Add(rule1);
            //                }
            //                if (contr.Name == "txt" + cboField_Name2.SelectedValue.ToString() + lstcount2[i].ToString())
            //                {
            //                    Rule rule2 = new Rule();

            //                    rule2.Field_name = cboField_Name2.SelectedValue.ToString();
            //                    rule2.Values = contr.Text;
            //                    lstrule2.Add(rule2);
            //                }
            //            }
            //        }
            //    }
            //}
            ////bool t=  K_anomymityCore.kiemtraruleInTable(dt, lstrule1, lstrule1, 0);
            ////MessageBox.Show(t.ToString());
            //bool t = K_anomymityCore.kiemtraruleInTable(dt, lstrule1, lstrule2, 0, 3);
            //MessageBox.Show(t.ToString());
           
          DataTable data=  K_anomymityCore.CopyTb(dt.Copy(),3,6);
            MessageBox.Show("");
           }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            LabelControl lbl2 = new LabelControl();
            lbl2.Name = "lbl" + cboField_Name2.SelectedValue.ToString();
            lbl2.Text = cboField_Name2.SelectedValue.ToString();
            lbl2.Top = top2;
            lbl2.Left = 281 + 10;
            TextEdit txtEdit2 = new TextEdit();
            txtEdit2.Name ="txt"+cboField_Name2.SelectedValue.ToString()+count1.ToString();
            txtEdit2.Top = top2;
            txtEdit2.Left = lbl2.Right + 2;
            Fields fields = new Fields
            {
                pos = fieldscount,
                Field = cboField_Name2.SelectedValue.ToString()
            };
            txtEdit2.Tag = fields;
            SimpleButton btn = new SimpleButton();
            btn.Name = "btn" +count1.ToString();
            btn.Top = top2;
            btn.Text = "Suport";
            btn.Left = txtEdit2.Right + 4;
            btn.Size = new System.Drawing.Size(50, 27);
            btn.Click += btnAddRule_Click;
                


            panelControl1.Controls.Add(lbl2);
            panelControl1.Controls.Add(txtEdit2);
            panelControl1.Controls.Add(btn);
            top2 += 30;
            lstcount2.Add(count1);
            count1++;
            //Rule rl = new Rule();
            //rl.Field_name = cboField_Name.SelectedValue.ToString();
            //rl.Values = txtEdit2.Text;
            //lstrule2.Add(rl);


        }

        private void rdDefault_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdRule_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GridData_Click(object sender, EventArgs e)
        {

        }

        private void GridData_Load(object sender, EventArgs e)
        {

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void txtRule1Leave(object sender, EventArgs e)
        {
        }

        private void frnmain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frnmain_Shown(object sender, EventArgs e)
        {

        }
    }
}