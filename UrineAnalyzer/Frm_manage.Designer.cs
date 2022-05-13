
namespace UrineAnalyzer
{
    partial class Frm_manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_manage));
            this.Btn_regi = new System.Windows.Forms.Button();
            this.User_data = new System.Windows.Forms.DataGridView();
            this.labelbar2 = new System.Windows.Forms.Label();
            this.DT_RBD = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_RPW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Rid = new System.Windows.Forms.TextBox();
            this.Btn_cancel = new System.Windows.Forms.Button();
            this.Btn_save = new System.Windows.Forms.Button();
            this.txt_Rname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_RPW2 = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.User_data)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_regi
            // 
            this.Btn_regi.BackColor = System.Drawing.SystemColors.Menu;
            this.Btn_regi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btn_regi.FlatAppearance.BorderSize = 0;
            this.Btn_regi.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.Btn_regi.Location = new System.Drawing.Point(326, 29);
            this.Btn_regi.Name = "Btn_regi";
            this.Btn_regi.Size = new System.Drawing.Size(126, 40);
            this.Btn_regi.TabIndex = 45;
            this.Btn_regi.Text = " Registration";
            this.Btn_regi.UseVisualStyleBackColor = false;
            this.Btn_regi.Click += new System.EventHandler(this.Btn_regi_Click);
            // 
            // User_data
            // 
            this.User_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.User_data.Location = new System.Drawing.Point(44, 51);
            this.User_data.Name = "User_data";
            this.User_data.RowTemplate.Height = 23;
            this.User_data.Size = new System.Drawing.Size(249, 341);
            this.User_data.TabIndex = 32;
            this.User_data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.User_data_CellClick);
            // 
            // labelbar2
            // 
            this.labelbar2.AutoSize = true;
            this.labelbar2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbar2.Location = new System.Drawing.Point(322, 300);
            this.labelbar2.Name = "labelbar2";
            this.labelbar2.Size = new System.Drawing.Size(57, 19);
            this.labelbar2.TabIndex = 31;
            this.labelbar2.Text = "labelbar";
            // 
            // DT_RBD
            // 
            this.DT_RBD.CalendarFont = new System.Drawing.Font("Times New Roman", 12.75F);
            this.DT_RBD.CustomFormat = "yyyy-MM-dd";
            this.DT_RBD.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.DT_RBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_RBD.Location = new System.Drawing.Point(518, 251);
            this.DT_RBD.Name = "DT_RBD";
            this.DT_RBD.Size = new System.Drawing.Size(130, 26);
            this.DT_RBD.TabIndex = 21;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(612, 371);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(0, 21);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(322, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 27);
            this.label5.TabIndex = 27;
            this.label5.Text = "Birthday";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_RPW
            // 
            this.txt_RPW.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.txt_RPW.Location = new System.Drawing.Point(518, 130);
            this.txt_RPW.Name = "txt_RPW";
            this.txt_RPW.PasswordChar = '*';
            this.txt_RPW.Size = new System.Drawing.Size(130, 27);
            this.txt_RPW.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(322, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 27);
            this.label2.TabIndex = 25;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 27);
            this.label1.TabIndex = 24;
            this.label1.Text = "User ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Rid
            // 
            this.txt_Rid.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Rid.HideSelection = false;
            this.txt_Rid.Location = new System.Drawing.Point(518, 91);
            this.txt_Rid.Name = "txt_Rid";
            this.txt_Rid.Size = new System.Drawing.Size(130, 27);
            this.txt_Rid.TabIndex = 17;
            this.txt_Rid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Rid_KeyUp);
            this.txt_Rid.Leave += new System.EventHandler(this.txt_Rid_Leave);
            // 
            // Btn_cancel
            // 
            this.Btn_cancel.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Btn_cancel.Location = new System.Drawing.Point(453, 341);
            this.Btn_cancel.Name = "Btn_cancel";
            this.Btn_cancel.Size = new System.Drawing.Size(80, 42);
            this.Btn_cancel.TabIndex = 22;
            this.Btn_cancel.Text = "Cancel";
            this.Btn_cancel.UseVisualStyleBackColor = true;
            this.Btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // Btn_save
            // 
            this.Btn_save.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Btn_save.Location = new System.Drawing.Point(336, 341);
            this.Btn_save.Name = "Btn_save";
            this.Btn_save.Size = new System.Drawing.Size(80, 42);
            this.Btn_save.TabIndex = 21;
            this.Btn_save.Text = "Save";
            this.Btn_save.UseVisualStyleBackColor = true;
            this.Btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // txt_Rname
            // 
            this.txt_Rname.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.txt_Rname.Location = new System.Drawing.Point(518, 209);
            this.txt_Rname.Name = "txt_Rname";
            this.txt_Rname.Size = new System.Drawing.Size(130, 27);
            this.txt_Rname.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(322, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 27);
            this.label4.TabIndex = 19;
            this.label4.Text = "Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(322, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 27);
            this.label3.TabIndex = 18;
            this.label3.Text = "Confirm Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_RPW2
            // 
            this.txt_RPW2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RPW2.HideSelection = false;
            this.txt_RPW2.Location = new System.Drawing.Point(518, 169);
            this.txt_RPW2.Name = "txt_RPW2";
            this.txt_RPW2.PasswordChar = '*';
            this.txt_RPW2.Size = new System.Drawing.Size(130, 27);
            this.txt_RPW2.TabIndex = 19;
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.btn_delete.Location = new System.Drawing.Point(568, 341);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(80, 42);
            this.btn_delete.TabIndex = 46;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // Frm_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(719, 429);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.Btn_regi);
            this.Controls.Add(this.User_data);
            this.Controls.Add(this.labelbar2);
            this.Controls.Add(this.txt_RPW2);
            this.Controls.Add(this.DT_RBD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Rname);
            this.Controls.Add(this.txt_RPW);
            this.Controls.Add(this.Btn_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Rid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Management";
            this.Load += new System.EventHandler(this.Frm_manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.User_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_regi;
        private System.Windows.Forms.DataGridView User_data;
        private System.Windows.Forms.Label labelbar2;
        private System.Windows.Forms.DateTimePicker DT_RBD;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txt_RPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_Rid;
        private System.Windows.Forms.Button Btn_cancel;
        private System.Windows.Forms.Button Btn_save;
        public System.Windows.Forms.TextBox txt_Rname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_RPW2;
        private System.Windows.Forms.Button btn_delete;
    }
}