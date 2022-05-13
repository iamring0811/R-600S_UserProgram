
namespace UrineAnalyzer
{
    partial class Frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_login));
            this.Txt_Id = new System.Windows.Forms.TextBox();
            this.lbl_Id = new System.Windows.Forms.Label();
            this.lbl_PW = new System.Windows.Forms.Label();
            this.Txt_PW = new System.Windows.Forms.TextBox();
            this.Btn_login = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.Btn_Manage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Txt_Id
            // 
            this.Txt_Id.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Id.HideSelection = false;
            this.Txt_Id.Location = new System.Drawing.Point(228, 35);
            this.Txt_Id.Name = "Txt_Id";
            this.Txt_Id.Size = new System.Drawing.Size(130, 27);
            this.Txt_Id.TabIndex = 11;
            this.Txt_Id.TextChanged += new System.EventHandler(this.Txt_Id_TextChanged);
            this.Txt_Id.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_Id_KeyUp);
            // 
            // lbl_Id
            // 
            this.lbl_Id.BackColor = System.Drawing.Color.White;
            this.lbl_Id.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Id.Location = new System.Drawing.Point(88, 34);
            this.lbl_Id.Name = "lbl_Id";
            this.lbl_Id.Size = new System.Drawing.Size(116, 27);
            this.lbl_Id.TabIndex = 12;
            this.lbl_Id.Text = "User ID";
            this.lbl_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PW
            // 
            this.lbl_PW.BackColor = System.Drawing.Color.White;
            this.lbl_PW.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PW.Location = new System.Drawing.Point(88, 75);
            this.lbl_PW.Name = "lbl_PW";
            this.lbl_PW.Size = new System.Drawing.Size(116, 27);
            this.lbl_PW.TabIndex = 13;
            this.lbl_PW.Text = "Password";
            this.lbl_PW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_PW
            // 
            this.Txt_PW.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Txt_PW.Location = new System.Drawing.Point(228, 75);
            this.Txt_PW.Name = "Txt_PW";
            this.Txt_PW.PasswordChar = '*';
            this.Txt_PW.Size = new System.Drawing.Size(130, 27);
            this.Txt_PW.TabIndex = 14;
            this.Txt_PW.TextChanged += new System.EventHandler(this.Txt_PW_TextChanged);
            this.Txt_PW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_PW_KeyDown);
            // 
            // Btn_login
            // 
            this.Btn_login.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_login.Location = new System.Drawing.Point(88, 155);
            this.Btn_login.Name = "Btn_login";
            this.Btn_login.Size = new System.Drawing.Size(105, 35);
            this.Btn_login.TabIndex = 16;
            this.Btn_login.Text = "Login";
            this.Btn_login.UseVisualStyleBackColor = true;
            this.Btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(88, 108);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(37, 19);
            this.label.TabIndex = 19;
            this.label.Text = "label";
            // 
            // Btn_Manage
            // 
            this.Btn_Manage.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Manage.Location = new System.Drawing.Point(253, 154);
            this.Btn_Manage.Name = "Btn_Manage";
            this.Btn_Manage.Size = new System.Drawing.Size(105, 35);
            this.Btn_Manage.TabIndex = 17;
            this.Btn_Manage.Text = "Management";
            this.Btn_Manage.UseVisualStyleBackColor = true;
            this.Btn_Manage.Click += new System.EventHandler(this.Btn_Manage_Click);
            // 
            // Frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(425, 215);
            this.Controls.Add(this.Btn_Manage);
            this.Controls.Add(this.Btn_login);
            this.Controls.Add(this.Txt_PW);
            this.Controls.Add(this.lbl_PW);
            this.Controls.Add(this.lbl_Id);
            this.Controls.Add(this.Txt_Id);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_login_FormClosing);
            this.Load += new System.EventHandler(this.Frm_login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Txt_Id;
        private System.Windows.Forms.Label lbl_Id;
        private System.Windows.Forms.Label lbl_PW;
        public System.Windows.Forms.TextBox Txt_PW;
        private System.Windows.Forms.Button Btn_login;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button Btn_Manage;
    }
}