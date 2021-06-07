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
using K_anonymity.Model;
using K_anonymity.Controller;
namespace K_anonymity.View
{
    public partial class main : DevExpress.XtraEditors.XtraForm
    {

        string file_name = "";
        public main()
        {
         
            InitializeComponent();
            skins();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                file_name = dlg.FileName;
                load_data();
                load_Listview();

            }

        }
        public void skins()


        {
            DevExpress.LookAndFeel.DefaultLookAndFeel thems = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            thems.LookAndFeel.SkinName = "Valentine";

        }
        public void load_data()
        {
            GridData.DataSource = ExportExcel.getData(file_name);
        }


        private void main_Load(object sender, EventArgs e)
        {
            skins();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
        public void load_Listview()
        {
            List<string> lst = new List<string>();
            foreach (DataColumn dataColumn in ExportExcel.getData(file_name).Columns)
            {
                lst.Add(dataColumn.ToString());
            }

            //lstViewFieldID.Columns.Add("Field_ID");

            foreach (string item1 in lst)
            {

                //lstViewFieldID.Items.Add(item1);
                //lstViewField_Name.Items.Add(item1);


            }

            //lstViewFieldID.View = View.Details;
            //lstViewField_Name.View = View.Details;



        }
    }
}