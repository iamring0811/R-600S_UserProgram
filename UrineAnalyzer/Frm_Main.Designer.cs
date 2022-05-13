
namespace UrineAnalyzer
{
    partial class Frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBar1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            statusBar2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_conncet = new System.Windows.Forms.Panel();
            this.lbl_baud = new System.Windows.Forms.Label();
            this.lbl_inter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_set = new System.Windows.Forms.Button();
            this.Btn_result = new System.Windows.Forms.Button();
            this.Btn_Patient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel_conncet.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar1,
            this.toolStripStatusLabel1,
            statusBar2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 760);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(955, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "StatusBar1";
            // 
            // statusBar1
            // 
            this.statusBar1.AutoSize = false;
            this.statusBar1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(250, 17);
            this.statusBar1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // statusBar2
            // 
            statusBar2.AutoSize = false;
            statusBar2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusBar2.Name = "statusBar2";
            statusBar2.Size = new System.Drawing.Size(250, 17);
            statusBar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_conncet
            // 
            this.panel_conncet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_conncet.Controls.Add(this.lbl_baud);
            this.panel_conncet.Controls.Add(this.lbl_inter);
            this.panel_conncet.Controls.Add(this.label2);
            this.panel_conncet.Controls.Add(this.label1);
            this.panel_conncet.Location = new System.Drawing.Point(266, 187);
            this.panel_conncet.Name = "panel_conncet";
            this.panel_conncet.Size = new System.Drawing.Size(422, 416);
            this.panel_conncet.TabIndex = 5;
            // 
            // lbl_baud
            // 
            this.lbl_baud.AutoSize = true;
            this.lbl_baud.BackColor = System.Drawing.Color.Transparent;
            this.lbl_baud.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_baud.ForeColor = System.Drawing.Color.White;
            this.lbl_baud.Location = new System.Drawing.Point(174, 345);
            this.lbl_baud.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_baud.Name = "lbl_baud";
            this.lbl_baud.Size = new System.Drawing.Size(60, 26);
            this.lbl_baud.TabIndex = 3;
            this.lbl_baud.Text = "9600";
            this.lbl_baud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_inter
            // 
            this.lbl_inter.AutoSize = true;
            this.lbl_inter.BackColor = System.Drawing.Color.Transparent;
            this.lbl_inter.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_inter.ForeColor = System.Drawing.Color.White;
            this.lbl_inter.Location = new System.Drawing.Point(174, 318);
            this.lbl_inter.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_inter.Name = "lbl_inter";
            this.lbl_inter.Size = new System.Drawing.Size(86, 26);
            this.lbl_inter.TabIndex = 2;
            this.lbl_inter.Text = "RS-232";
            this.lbl_inter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 345);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 318);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interface :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_set
            // 
            this.Btn_set.Location = new System.Drawing.Point(630, 45);
            this.Btn_set.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_set.Name = "Btn_set";
            this.Btn_set.Size = new System.Drawing.Size(204, 410);
            this.Btn_set.TabIndex = 11;
            this.Btn_set.UseVisualStyleBackColor = true;
            this.Btn_set.Click += new System.EventHandler(Btn_set_Click);
            // 
            // Btn_result
            // 
            this.Btn_result.Location = new System.Drawing.Point(376, 45);
            this.Btn_result.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_result.Name = "Btn_result";
            this.Btn_result.Size = new System.Drawing.Size(204, 410);
            this.Btn_result.TabIndex = 10;
            this.Btn_result.UseVisualStyleBackColor = true;
            this.Btn_result.Click += new System.EventHandler(this.Btn_result_Click);
            // 
            // Btn_Patient
            // 
            this.Btn_Patient.Location = new System.Drawing.Point(122, 45);
            this.Btn_Patient.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Patient.Name = "Btn_Patient";
            this.Btn_Patient.Size = new System.Drawing.Size(204, 410);
            this.Btn_Patient.TabIndex = 9;
            this.Btn_Patient.UseVisualStyleBackColor = true;
            this.Btn_Patient.Click += new System.EventHandler(this.Btn_user_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(955, 782);
            this.Controls.Add(this.panel_conncet);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Btn_set);
            this.Controls.Add(this.Btn_result);
            this.Controls.Add(this.Btn_Patient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Urine Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel_conncet.ResumeLayout(false);
            this.panel_conncet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel_conncet;
        private System.Windows.Forms.Label lbl_baud;
        private System.Windows.Forms.Label lbl_inter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_set;
        private System.Windows.Forms.Button Btn_result;
        private System.Windows.Forms.Button Btn_Patient;
        private static System.Windows.Forms.ToolStripStatusLabel statusBar2;
    }
}