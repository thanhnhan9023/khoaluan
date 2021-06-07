namespace K_anonymity
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_SaveFile = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.GridData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtHeSoK = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRunQuaSi = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.lstViewFieldID = new System.Windows.Forms.ListView();
            this.lstViewField_Name = new System.Windows.Forms.ListView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.listView3 = new System.Windows.Forms.ListView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(32, 21);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 29);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Open File";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btn_SaveFile
            // 
            this.btn_SaveFile.Location = new System.Drawing.Point(529, 21);
            this.btn_SaveFile.Name = "btn_SaveFile";
            this.btn_SaveFile.Size = new System.Drawing.Size(94, 29);
            this.btn_SaveFile.TabIndex = 0;
            this.btn_SaveFile.Text = "Save File";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(147, 25);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(340, 22);
            this.textEdit1.TabIndex = 1;
            // 
            // GridData
            // 
            this.GridData.Location = new System.Drawing.Point(489, 220);
            this.GridData.MainView = this.gridView1;
            this.GridData.Name = "GridData";
            this.GridData.Size = new System.Drawing.Size(1003, 478);
            this.GridData.TabIndex = 2;
            this.GridData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GridData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtHeSoK
            // 
            this.txtHeSoK.Location = new System.Drawing.Point(111, 85);
            this.txtHeSoK.Name = "txtHeSoK";
            this.txtHeSoK.Size = new System.Drawing.Size(129, 22);
            this.txtHeSoK.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 88);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 17);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Hệ Số K";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // btnRunQuaSi
            // 
            this.btnRunQuaSi.Location = new System.Drawing.Point(274, 81);
            this.btnRunQuaSi.Name = "btnRunQuaSi";
            this.btnRunQuaSi.Size = new System.Drawing.Size(94, 29);
            this.btnRunQuaSi.TabIndex = 0;
            this.btnRunQuaSi.Text = "Run Quasi";
            this.btnRunQuaSi.Click += new System.EventHandler(this.btnRunQuaSi_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(135, 16);
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(297, 166);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 134);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(457, 554);
            this.panelControl1.TabIndex = 6;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(20, 16);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(94, 29);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "Thêm Luật";
            // 
            // lstViewFieldID
            // 
            this.lstViewFieldID.HideSelection = false;
            this.lstViewFieldID.Location = new System.Drawing.Point(677, 44);
            this.lstViewFieldID.Name = "lstViewFieldID";
            this.lstViewFieldID.Size = new System.Drawing.Size(197, 135);
            this.lstViewFieldID.TabIndex = 7;
            this.lstViewFieldID.UseCompatibleStateImageBehavior = false;
            // 
            // lstViewField_Name
            // 
            this.lstViewField_Name.HideSelection = false;
            this.lstViewField_Name.Location = new System.Drawing.Point(950, 44);
            this.lstViewField_Name.Name = "lstViewField_Name";
            this.lstViewField_Name.Size = new System.Drawing.Size(197, 135);
            this.lstViewField_Name.TabIndex = 7;
            this.lstViewField_Name.UseCompatibleStateImageBehavior = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(716, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 16);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Field_ID";
            this.labelControl2.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(1634, -23);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(197, 135);
            this.listView3.TabIndex = 7;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(985, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Field_Quasi";
            this.labelControl3.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 700);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.lstViewField_Name);
            this.Controls.Add(this.lstViewFieldID);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtHeSoK);
            this.Controls.Add(this.GridData);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.btnRunQuaSi);
            this.Controls.Add(this.btn_SaveFile);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btn_SaveFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.GridControl GridData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtHeSoK;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRunQuaSi;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.ListView lstViewFieldID;
        private System.Windows.Forms.ListView lstViewField_Name;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ListView listView3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}

