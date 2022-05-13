
namespace UrineAnalyzer
{
    partial class Frm_Search
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
            Btn_close_Click(null, null);
            /*            if (disposing && (components != null))
                        {
                            components.Dispose();
                        }
                        base.Dispose(disposing);
            */
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Search));
            this.DT_Sdate = new System.Windows.Forms.DateTimePicker();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DBGrid_user = new System.Windows.Forms.DataGridView();
            this.txt_PID = new System.Windows.Forms.TextBox();
            this.DT_Edate = new System.Windows.Forms.DateTimePicker();
            this.user_chk_1 = new System.Windows.Forms.CheckBox();
            this.user_chk_0 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusbar1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusbar2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_reset = new System.Windows.Forms.Button();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Btn_close = new System.Windows.Forms.Button();
            this.Btn_Confirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid_user)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DT_Sdate
            // 
            this.DT_Sdate.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_Sdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DT_Sdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DT_Sdate.Location = new System.Drawing.Point(186, 138);
            this.DT_Sdate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DT_Sdate.Name = "DT_Sdate";
            this.DT_Sdate.Size = new System.Drawing.Size(116, 27);
            this.DT_Sdate.TabIndex = 53;
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.txt_name.Location = new System.Drawing.Point(186, 104);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(116, 27);
            this.txt_name.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 51;
            this.label3.Text = "Start Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 50;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 49;
            this.label1.Text = "Patient ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.DBGrid_user.Location = new System.Drawing.Point(368, 8);
            this.DBGrid_user.Margin = new System.Windows.Forms.Padding(0);
            this.DBGrid_user.Name = "DBGrid_user";
            this.DBGrid_user.ReadOnly = true;
            this.DBGrid_user.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DBGrid_user.RowTemplate.Height = 23;
            this.DBGrid_user.RowTemplate.ReadOnly = true;
            this.DBGrid_user.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DBGrid_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DBGrid_user.Size = new System.Drawing.Size(404, 375);
            this.DBGrid_user.TabIndex = 56;
            this.DBGrid_user.CurrentCellChanged += new System.EventHandler(this.DBGrid_user_CurrentCellChanged);
            // 
            // txt_PID
            // 
            this.txt_PID.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.txt_PID.Location = new System.Drawing.Point(186, 68);
            this.txt_PID.Name = "txt_PID";
            this.txt_PID.Size = new System.Drawing.Size(116, 27);
            this.txt_PID.TabIndex = 57;
            this.txt_PID.TextChanged += new System.EventHandler(this.txt_PID_TextChanged);
            this.txt_PID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_PID_KeyUp);
            // 
            // DT_Edate
            // 
            this.DT_Edate.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_Edate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DT_Edate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DT_Edate.Location = new System.Drawing.Point(186, 171);
            this.DT_Edate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DT_Edate.Name = "DT_Edate";
            this.DT_Edate.Size = new System.Drawing.Size(116, 27);
            this.DT_Edate.TabIndex = 58;
            // 
            // user_chk_1
            // 
            this.user_chk_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(179)))), ((int)(((byte)(198)))));
            this.user_chk_1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.user_chk_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.user_chk_1.Location = new System.Drawing.Point(19, 159);
            this.user_chk_1.Margin = new System.Windows.Forms.Padding(0);
            this.user_chk_1.Name = "user_chk_1";
            this.user_chk_1.Size = new System.Drawing.Size(15, 15);
            this.user_chk_1.TabIndex = 61;
            this.user_chk_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.user_chk_1.UseVisualStyleBackColor = false;
            this.user_chk_1.CheckedChanged += new System.EventHandler(this.user_chk_1_CheckedChanged);
            // 
            // user_chk_0
            // 
            this.user_chk_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(179)))), ((int)(((byte)(198)))));
            this.user_chk_0.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.user_chk_0.Cursor = System.Windows.Forms.Cursors.Default;
            this.user_chk_0.Location = new System.Drawing.Point(19, 93);
            this.user_chk_0.Margin = new System.Windows.Forms.Padding(0);
            this.user_chk_0.Name = "user_chk_0";
            this.user_chk_0.Size = new System.Drawing.Size(15, 15);
            this.user_chk_0.TabIndex = 59;
            this.user_chk_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.user_chk_0.UseVisualStyleBackColor = false;
            this.user_chk_0.CheckedChanged += new System.EventHandler(this.user_chk_0_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 62;
            this.label4.Text = "End Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusbar1,
            this.statusbar2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(781, 22);
            this.statusStrip1.TabIndex = 65;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusbar1
            // 
            this.statusbar1.AutoSize = false;
            this.statusbar1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusbar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusbar1.Name = "statusbar1";
            this.statusbar1.Size = new System.Drawing.Size(200, 17);
            this.statusbar1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusbar2
            // 
            this.statusbar2.AutoSize = false;
            this.statusbar2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusbar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusbar2.Name = "statusbar2";
            this.statusbar2.Size = new System.Drawing.Size(150, 17);
            this.statusbar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Location = new System.Drawing.Point(184, 212);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(0);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(118, 43);
            this.btn_reset.TabIndex = 74;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // Btn_Search
            // 
            this.Btn_Search.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Search.Location = new System.Drawing.Point(36, 212);
            this.Btn_Search.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(118, 43);
            this.Btn_Search.TabIndex = 73;
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // Btn_close
            // 
            this.Btn_close.Location = new System.Drawing.Point(184, 327);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(118, 43);
            this.Btn_close.TabIndex = 72;
            this.Btn_close.UseVisualStyleBackColor = true;
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // Btn_Confirm
            // 
            this.Btn_Confirm.Location = new System.Drawing.Point(36, 327);
            this.Btn_Confirm.Name = "Btn_Confirm";
            this.Btn_Confirm.Size = new System.Drawing.Size(118, 43);
            this.Btn_Confirm.TabIndex = 71;
            this.Btn_Confirm.UseVisualStyleBackColor = true;
            this.Btn_Confirm.Click += new System.EventHandler(this.Btn_Confirm_Click);
            // 
            // Frm_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(781, 414);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.Btn_close);
            this.Controls.Add(this.Btn_Confirm);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.user_chk_1);
            this.Controls.Add(this.user_chk_0);
            this.Controls.Add(this.DT_Edate);
            this.Controls.Add(this.txt_PID);
            this.Controls.Add(this.DBGrid_user);
            this.Controls.Add(this.DT_Sdate);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Activated += new System.EventHandler(this.Frm_Search_Activated);
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid_user)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DateTimePicker DT_Sdate;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DBGrid_user;
        private System.Windows.Forms.TextBox txt_PID;
        public System.Windows.Forms.DateTimePicker DT_Edate;
        private System.Windows.Forms.CheckBox user_chk_1;
        private System.Windows.Forms.CheckBox user_chk_0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusbar2;
        private System.Windows.Forms.ToolStripStatusLabel statusbar1;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.Button Btn_close;
        public System.Windows.Forms.Button Btn_Confirm;
    }
}