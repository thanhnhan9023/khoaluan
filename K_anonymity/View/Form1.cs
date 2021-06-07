using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K_anonymity.Model;
using K_anonymity.Controller;
namespace K_anonymity
{
    public partial class Form1 : Form
    {
        string file_name = "";
     
        public Form1()
        {
            InitializeComponent();
          
        }
        public void skins()


        {
            DevExpress.LookAndFeel.DefaultLookAndFeel thems = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            thems.LookAndFeel.SkinName = "Valentine";

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter="Excel Files|*.xls;*.xlsx;*.xlsm";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                file_name = dlg.FileName;
                load_data();
                load_Listview();

            }
        }
        public void load_data()
        {
            GridData.DataSource = ExportExcel.getData(file_name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skins();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnRunQuaSi_Click(object sender, EventArgs e)
        {
            if(txtHeSoK.Text==string.Empty)
            {

                MessageBox.Show("Chua nhap he so k");
                return;
            }
            List<string> item = new List<string>();
            item.Add("first_name");
            item.Add("last_name");
            GridData.DataSource = K_anomymityCore.Upadte_Fieldquasi1_fix(ExportExcel.getData(file_name), int.Parse(txtHeSoK.Text),item);
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void load_Listview()
        {
            List<string> lst = new List<string>();
            foreach(DataColumn dataColumn in ExportExcel.getData(file_name).Columns)
            {
                lst.Add(dataColumn.ToString());
            }

            lstViewFieldID.Columns.Add("Field_ID");
           
            foreach (string item1 in lst)
            {
            
                lstViewFieldID.Items.Add(item1);
                lstViewField_Name.Items.Add(item1);
               

            }

            //lstViewFieldID.View = View.Details;
            //lstViewField_Name.View = View.Details;



        }
    }
}
