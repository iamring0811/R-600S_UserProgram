
namespace UrineAnalyzer
{
    partial class Frm_User
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_User));
            this.Txt_Id = new System.Windows.Forms.TextBox();
            this.lbl_Id = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.Txt_name = new System.Windows.Forms.TextBox();
            this.lbl_bth = new System.Windows.Forms.Label();
            this.lbl_sex = new System.Windows.Forms.Label();
            this.DBGrid_user = new System.Windows.Forms.DataGridView();
            this.tt_user = new System.Windows.Forms.ToolTip(this.components);
            this.tt_result = new System.Windows.Forms.ToolTip(this.components);
            this.tt_Set = new System.Windows.Forms.ToolTip(this.components);
            this.cb_sex = new System.Windows.Forms.ComboBox();
            this.Udtpicker = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBar1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tt_logout = new System.Windows.Forms.ToolTip(this.components);
            this.tt_close = new System.Windows.Forms.ToolTip(this.components);
            this.btn_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid_user)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_Id
            // 
            this.Txt_Id.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Id.HideSelection = false;
            this.Txt_Id.Location = new System.Drawing.Point(334, 155);
            this.Txt_Id.Name = "Txt_Id";
            this.Txt_Id.Size = new System.Drawing.Size(130, 27);
            this.Txt_Id.TabIndex = 0;
            this.Txt_Id.TextChanged += new System.EventHandler(this.Txt_Id_TextChanged);
            this.Txt_Id.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_Id_KeyUp);
            // 
            // lbl_Id
            // 
            this.lbl_Id.BackColor = System.Drawing.Color.White;
            this.lbl_Id.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Id.Location = new System.Drawing.Point(202, 154);
            this.lbl_Id.Name = "lbl_Id";
            this.lbl_Id.Size = new System.Drawing.Size(116, 27);
            this.lbl_Id.TabIndex = 1;
            this.lbl_Id.Text = "Patient ID";
            this.lbl_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name
            // 
            this.lbl_name.BackColor = System.Drawing.Color.White;
            this.lbl_name.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(202, 195);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(116, 27);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Name";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_name
            // 
            this.Txt_name.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Txt_name.Location = new System.Drawing.Point(334, 195);
            this.Txt_name.Name = "Txt_name";
            this.Txt_name.Size = new System.Drawing.Size(130, 27);
            this.Txt_name.TabIndex = 3;
            // 
            // lbl_bth
            // 
            this.lbl_bth.BackColor = System.Drawing.Color.White;
            this.lbl_bth.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bth.Location = new System.Drawing.Point(202, 238);
            this.lbl_bth.Name = "lbl_bth";
            this.lbl_bth.Size = new System.Drawing.Size(116, 27);
            this.lbl_bth.TabIndex = 4;
            this.lbl_bth.Text = "Birthday";
            this.lbl_bth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_sex
            // 
            this.lbl_sex.BackColor = System.Drawing.Color.White;
            this.lbl_sex.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sex.Location = new System.Drawing.Point(202, 281);
            this.lbl_sex.Name = "lbl_sex";
            this.lbl_sex.Size = new System.Drawing.Size(116, 27);
            this.lbl_sex.TabIndex = 6;
            this.lbl_sex.Text = "Sex";
            this.lbl_sex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DBGrid_user
            // 
            this.DBGrid_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DBGrid_user.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DBGrid_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DBGrid_user.DefaultCellStyle = dataGridViewCellStyle2;
            this.DBGrid_user.Location = new System.Drawing.Point(538, 154);
            this.DBGrid_user.Margin = new System.Windows.Forms.Padding(0);
            this.DBGrid_user.Name = "DBGrid_user";
            this.DBGrid_user.ReadOnly = true;
            this.DBGrid_user.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DBGrid_user.RowTemplate.Height = 23;
            this.DBGrid_user.RowTemplate.ReadOnly = true;
            this.DBGrid_user.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DBGrid_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DBGrid_user.Size = new System.Drawing.Size(404, 724);
            this.DBGrid_user.TabIndex = 18;
            this.DBGrid_user.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBGrid_user_CellClick);
            // 
            // cb_sex
            // 
            this.cb_sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sex.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.cb_sex.FormattingEnabled = true;
            this.cb_sex.Location = new System.Drawing.Point(334, 281);
            this.cb_sex.Name = "cb_sex";
            this.cb_sex.Size = new System.Drawing.Size(130, 27);
            this.cb_sex.TabIndex = 19;
            // 
            // Udtpicker
            // 
            this.Udtpicker.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Udtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Udtpicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Udtpicker.Location = new System.Drawing.Point(334, 239);
            this.Udtpicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.Udtpicker.Name = "Udtpicker";
            this.Udtpicker.Size = new System.Drawing.Size(130, 27);
            this.Udtpicker.TabIndex = 25;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar1,
            this.StatusBar2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 919);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1134, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBar1
            // 
            this.StatusBar1.AutoSize = false;
            this.StatusBar1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(250, 17);
            this.StatusBar1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBar2
            // 
            this.StatusBar2.AutoSize = false;
            this.StatusBar2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.StatusBar2.Name = "StatusBar2";
            this.StatusBar2.Size = new System.Drawing.Size(250, 17);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(199, 321);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(118, 43);
            this.btn_save.TabIndex = 71;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Frm_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1134, 941);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Udtpicker);
            this.Controls.Add(this.cb_sex);
            this.Controls.Add(this.DBGrid_user);
            this.Controls.Add(this.lbl_sex);
            this.Controls.Add(this.lbl_bth);
            this.Controls.Add(this.Txt_name);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_Id);
            this.Controls.Add(this.Txt_Id);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Urine Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_User_FormClosing);
            this.Load += new System.EventHandler(this.Form_User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid_user)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Id;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_bth;
        private System.Windows.Forms.Label lbl_sex;
        private System.Windows.Forms.DataGridView DBGrid_user;
        public System.Windows.Forms.Button btn_user_top;
        public System.Windows.Forms.Button btn_result_top;
        public System.Windows.Forms.Button btn_set_top;
        private System.Windows.Forms.ToolTip tt_user;
        private System.Windows.Forms.ToolTip tt_result;
        private System.Windows.Forms.ToolTip tt_Set;
        public System.Windows.Forms.TextBox Txt_Id;
        public System.Windows.Forms.TextBox Txt_name;
        public System.Windows.Forms.ComboBox cb_sex;
        public System.Windows.Forms.DateTimePicker Udtpicker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar2;
        private System.Windows.Forms.ToolTip tt_logout;
        private System.Windows.Forms.ToolTip tt_close;
        private System.Windows.Forms.Button btn_save;
    }
}