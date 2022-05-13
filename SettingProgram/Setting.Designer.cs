
namespace SettingProgram
{
    partial class Frm_set
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_set));
            this.label1 = new System.Windows.Forms.Label();
            this.spr_Color = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.RB_Arb = new System.Windows.Forms.RadioButton();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.UnitBox = new System.Windows.Forms.GroupBox();
            this.RB_SI = new System.Windows.Forms.RadioButton();
            this.RB_Conv = new System.Windows.Forms.RadioButton();
            this.SerialBox = new System.Windows.Forms.GroupBox();
            this.btn_scan = new System.Windows.Forms.Button();
            this.cb_comport = new System.Windows.Forms.ComboBox();
            this.RB_Serial = new System.Windows.Forms.RadioButton();
            this.RB_usb = new System.Windows.Forms.RadioButton();
            this.BaudBox = new System.Windows.Forms.GroupBox();
            this.RB_115200 = new System.Windows.Forms.RadioButton();
            this.RB_38200 = new System.Windows.Forms.RadioButton();
            this.RB_9600 = new System.Windows.Forms.RadioButton();
            this.lblVersion = new System.Windows.Forms.Label();
            this.spr_lang = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Statusbar = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_lang = new System.Windows.Forms.Label();
            this.CB_lang = new System.Windows.Forms.ComboBox();
            this.Btn_langsave = new System.Windows.Forms.Button();
            this.Btn_lang = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.UnitBox.SuspendLayout();
            this.SerialBox.SuspendLayout();
            this.BaudBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(60, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Result Mark";
            // 
            // spr_Color
            // 
            this.spr_Color.Location = new System.Drawing.Point(60, 92);
            this.spr_Color.Name = "spr_Color";
            this.spr_Color.Size = new System.Drawing.Size(305, 129);
            this.spr_Color.TabIndex = 10;
            this.spr_Color.MouseLeave += new System.EventHandler(this.spr_Color_MouseLeave);
            this.spr_Color.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spr_Color_MouseMove);
            this.spr_Color.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spr_Color_MouseUp);
            // 
            // RB_Arb
            // 
            this.RB_Arb.AutoSize = true;
            this.RB_Arb.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.RB_Arb.ForeColor = System.Drawing.Color.Black;
            this.RB_Arb.Location = new System.Drawing.Point(24, 24);
            this.RB_Arb.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Arb.Name = "RB_Arb";
            this.RB_Arb.Size = new System.Drawing.Size(57, 24);
            this.RB_Arb.TabIndex = 2;
            this.RB_Arb.TabStop = true;
            this.RB_Arb.Text = "Arb";
            this.RB_Arb.UseVisualStyleBackColor = true;
            this.RB_Arb.CheckedChanged += new System.EventHandler(this.RB_Arb_CheckedChanged);
            // 
            // UnitBox
            // 
            this.UnitBox.BackColor = System.Drawing.Color.White;
            this.UnitBox.Controls.Add(this.RB_SI);
            this.UnitBox.Controls.Add(this.RB_Conv);
            this.UnitBox.Controls.Add(this.RB_Arb);
            this.UnitBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnitBox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnitBox.ForeColor = System.Drawing.Color.Black;
            this.UnitBox.Location = new System.Drawing.Point(60, 231);
            this.UnitBox.Name = "UnitBox";
            this.UnitBox.Size = new System.Drawing.Size(305, 99);
            this.UnitBox.TabIndex = 0;
            this.UnitBox.TabStop = false;
            this.UnitBox.Text = "Unit";
            // 
            // RB_SI
            // 
            this.RB_SI.AutoSize = true;
            this.RB_SI.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.RB_SI.ForeColor = System.Drawing.Color.Black;
            this.RB_SI.Location = new System.Drawing.Point(24, 72);
            this.RB_SI.Margin = new System.Windows.Forms.Padding(0);
            this.RB_SI.Name = "RB_SI";
            this.RB_SI.Size = new System.Drawing.Size(54, 24);
            this.RB_SI.TabIndex = 4;
            this.RB_SI.TabStop = true;
            this.RB_SI.Text = "S.I.";
            this.RB_SI.UseVisualStyleBackColor = true;
            this.RB_SI.CheckedChanged += new System.EventHandler(this.RB_SI_CheckedChanged);
            // 
            // RB_Conv
            // 
            this.RB_Conv.AutoSize = true;
            this.RB_Conv.BackColor = System.Drawing.Color.Transparent;
            this.RB_Conv.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.RB_Conv.ForeColor = System.Drawing.Color.Black;
            this.RB_Conv.Location = new System.Drawing.Point(24, 48);
            this.RB_Conv.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Conv.Name = "RB_Conv";
            this.RB_Conv.Size = new System.Drawing.Size(73, 24);
            this.RB_Conv.TabIndex = 3;
            this.RB_Conv.TabStop = true;
            this.RB_Conv.Text = "Conv.";
            this.RB_Conv.UseVisualStyleBackColor = false;
            this.RB_Conv.CheckedChanged += new System.EventHandler(this.RB_Conv_CheckedChanged);
            // 
            // SerialBox
            // 
            this.SerialBox.BackColor = System.Drawing.Color.White;
            this.SerialBox.Controls.Add(this.btn_scan);
            this.SerialBox.Controls.Add(this.cb_comport);
            this.SerialBox.Controls.Add(this.RB_Serial);
            this.SerialBox.Controls.Add(this.RB_usb);
            this.SerialBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SerialBox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialBox.ForeColor = System.Drawing.Color.Black;
            this.SerialBox.Location = new System.Drawing.Point(58, 340);
            this.SerialBox.Name = "SerialBox";
            this.SerialBox.Size = new System.Drawing.Size(305, 76);
            this.SerialBox.TabIndex = 1;
            this.SerialBox.TabStop = false;
            this.SerialBox.Text = "Interface";
            // 
            // btn_scan
            // 
            this.btn_scan.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_scan.Location = new System.Drawing.Point(225, 45);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(67, 30);
            this.btn_scan.TabIndex = 5;
            this.btn_scan.Text = "Scan";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // cb_comport
            // 
            this.cb_comport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_comport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_comport.FormattingEnabled = true;
            this.cb_comport.Location = new System.Drawing.Point(110, 45);
            this.cb_comport.Name = "cb_comport";
            this.cb_comport.Size = new System.Drawing.Size(103, 27);
            this.cb_comport.TabIndex = 4;
            // 
            // RB_Serial
            // 
            this.RB_Serial.AutoSize = true;
            this.RB_Serial.BackColor = System.Drawing.Color.Transparent;
            this.RB_Serial.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.RB_Serial.ForeColor = System.Drawing.Color.Black;
            this.RB_Serial.Location = new System.Drawing.Point(24, 48);
            this.RB_Serial.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Serial.Name = "RB_Serial";
            this.RB_Serial.Size = new System.Drawing.Size(83, 24);
            this.RB_Serial.TabIndex = 3;
            this.RB_Serial.TabStop = true;
            this.RB_Serial.Text = "RS-232";
            this.RB_Serial.UseVisualStyleBackColor = false;
            this.RB_Serial.CheckedChanged += new System.EventHandler(this.RB_Serial_CheckedChanged);
            // 
            // RB_usb
            // 
            this.RB_usb.AutoSize = true;
            this.RB_usb.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.RB_usb.ForeColor = System.Drawing.Color.Black;
            this.RB_usb.Location = new System.Drawing.Point(24, 24);
            this.RB_usb.Margin = new System.Windows.Forms.Padding(0);
            this.RB_usb.Name = "RB_usb";
            this.RB_usb.Size = new System.Drawing.Size(62, 24);
            this.RB_usb.TabIndex = 2;
            this.RB_usb.TabStop = true;
            this.RB_usb.Text = "USB";
            this.RB_usb.UseVisualStyleBackColor = true;
            this.RB_usb.CheckedChanged += new System.EventHandler(this.RB_usb_CheckedChanged);
            // 
            // BaudBox
            // 
            this.BaudBox.BackColor = System.Drawing.Color.White;
            this.BaudBox.Controls.Add(this.RB_115200);
            this.BaudBox.Controls.Add(this.RB_38200);
            this.BaudBox.Controls.Add(this.RB_9600);
            this.BaudBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaudBox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudBox.ForeColor = System.Drawing.Color.Black;
            this.BaudBox.Location = new System.Drawing.Point(58, 426);
            this.BaudBox.Name = "BaudBox";
            this.BaudBox.Size = new System.Drawing.Size(305, 99);
            this.BaudBox.TabIndex = 2;
            this.BaudBox.TabStop = false;
            this.BaudBox.Text = "Baud Rate";
            // 
            // RB_115200
            // 
            this.RB_115200.AutoSize = true;
            this.RB_115200.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.RB_115200.ForeColor = System.Drawing.Color.Black;
            this.RB_115200.Location = new System.Drawing.Point(24, 72);
            this.RB_115200.Margin = new System.Windows.Forms.Padding(0);
            this.RB_115200.Name = "RB_115200";
            this.RB_115200.Size = new System.Drawing.Size(80, 24);
            this.RB_115200.TabIndex = 4;
            this.RB_115200.TabStop = true;
            this.RB_115200.Text = "115200";
            this.RB_115200.UseVisualStyleBackColor = true;
            this.RB_115200.Visible = false;
            this.RB_115200.CheckedChanged += new System.EventHandler(this.RB_115200_CheckedChanged);
            // 
            // RB_38200
            // 
            this.RB_38200.AutoSize = true;
            this.RB_38200.BackColor = System.Drawing.Color.Transparent;
            this.RB_38200.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.RB_38200.ForeColor = System.Drawing.Color.Black;
            this.RB_38200.Location = new System.Drawing.Point(24, 48);
            this.RB_38200.Margin = new System.Windows.Forms.Padding(0);
            this.RB_38200.Name = "RB_38200";
            this.RB_38200.Size = new System.Drawing.Size(72, 24);
            this.RB_38200.TabIndex = 3;
            this.RB_38200.TabStop = true;
            this.RB_38200.Text = "38400";
            this.RB_38200.UseVisualStyleBackColor = false;
            this.RB_38200.CheckedChanged += new System.EventHandler(this.RB_38200_CheckedChanged);
            // 
            // RB_9600
            // 
            this.RB_9600.AutoSize = true;
            this.RB_9600.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.RB_9600.ForeColor = System.Drawing.Color.Black;
            this.RB_9600.Location = new System.Drawing.Point(24, 24);
            this.RB_9600.Margin = new System.Windows.Forms.Padding(0);
            this.RB_9600.Name = "RB_9600";
            this.RB_9600.Size = new System.Drawing.Size(63, 24);
            this.RB_9600.TabIndex = 2;
            this.RB_9600.TabStop = true;
            this.RB_9600.Text = "9600";
            this.RB_9600.UseVisualStyleBackColor = true;
            this.RB_9600.CheckedChanged += new System.EventHandler(this.RB_9600_CheckedChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.White;
            this.lblVersion.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(58, 639);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(305, 33);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "V1.00.EN.01-220408";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spr_lang
            // 
            this.spr_lang.Location = new System.Drawing.Point(424, 92);
            this.spr_lang.Name = "spr_lang";
            this.spr_lang.Size = new System.Drawing.Size(419, 531);
            this.spr_lang.TabIndex = 12;
            this.spr_lang.Text = "spreadsheetControl1";
            this.spr_lang.CellBeginEdit += new DevExpress.XtraSpreadsheet.CellBeginEditEventHandler(this.spr_lang_CellBeginEdit);
            this.spr_lang.CellEndEdit += new DevExpress.XtraSpreadsheet.CellEndEditEventHandler(this.spr_lang_CellEndEdit);
            this.spr_lang.ProtectionWarning += new System.ComponentModel.HandledEventHandler(this.spr_lang_ProtectionWarning);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Statusbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(901, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Statusbar
            // 
            this.Statusbar.AutoSize = false;
            this.Statusbar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Statusbar.Name = "Statusbar";
            this.Statusbar.Size = new System.Drawing.Size(300, 17);
            this.Statusbar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_lang
            // 
            this.lbl_lang.AutoSize = true;
            this.lbl_lang.BackColor = System.Drawing.Color.White;
            this.lbl_lang.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_lang.ForeColor = System.Drawing.Color.Black;
            this.lbl_lang.Location = new System.Drawing.Point(424, 64);
            this.lbl_lang.Name = "lbl_lang";
            this.lbl_lang.Size = new System.Drawing.Size(93, 23);
            this.lbl_lang.TabIndex = 14;
            this.lbl_lang.Text = "Language";
            // 
            // CB_lang
            // 
            this.CB_lang.DropDownHeight = 109;
            this.CB_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_lang.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_lang.FormattingEnabled = true;
            this.CB_lang.IntegralHeight = false;
            this.CB_lang.Location = new System.Drawing.Point(519, 64);
            this.CB_lang.Name = "CB_lang";
            this.CB_lang.Size = new System.Drawing.Size(120, 25);
            this.CB_lang.TabIndex = 15;
            this.CB_lang.SelectedIndexChanged += new System.EventHandler(this.CB_lang_SelectedIndexChanged);
            this.CB_lang.DropDownClosed += new System.EventHandler(this.CB_lang_DropDownClosed);
            // 
            // Btn_langsave
            // 
            this.Btn_langsave.Location = new System.Drawing.Point(424, 632);
            this.Btn_langsave.Name = "Btn_langsave";
            this.Btn_langsave.Size = new System.Drawing.Size(118, 40);
            this.Btn_langsave.TabIndex = 58;
            this.Btn_langsave.UseVisualStyleBackColor = true;
            this.Btn_langsave.Click += new System.EventHandler(this.Btn_langsave_Click);
            // 
            // Btn_lang
            // 
            this.Btn_lang.Location = new System.Drawing.Point(184, 542);
            this.Btn_lang.Name = "Btn_lang";
            this.Btn_lang.Size = new System.Drawing.Size(118, 42);
            this.Btn_lang.TabIndex = 57;
            this.Btn_lang.UseVisualStyleBackColor = true;
            this.Btn_lang.Click += new System.EventHandler(this.Btn_lang_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(58, 542);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(118, 42);
            this.Btn_Save.TabIndex = 56;
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Frm_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 698);
            this.Controls.Add(this.Btn_langsave);
            this.Controls.Add(this.Btn_lang);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.CB_lang);
            this.Controls.Add(this.lbl_lang);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.spr_lang);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.BaudBox);
            this.Controls.Add(this.SerialBox);
            this.Controls.Add(this.UnitBox);
            this.Controls.Add(this.spr_Color);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_set";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_set_FormClosing);
            this.Load += new System.EventHandler(this.Frm_set_Load);
            this.UnitBox.ResumeLayout(false);
            this.UnitBox.PerformLayout();
            this.SerialBox.ResumeLayout(false);
            this.SerialBox.PerformLayout();
            this.BaudBox.ResumeLayout(false);
            this.BaudBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spr_Color;
        private System.Windows.Forms.RadioButton RB_Arb;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.GroupBox UnitBox;
        private System.Windows.Forms.RadioButton RB_SI;
        private System.Windows.Forms.RadioButton RB_Conv;
        private System.Windows.Forms.GroupBox SerialBox;
        private System.Windows.Forms.RadioButton RB_Serial;
        private System.Windows.Forms.RadioButton RB_usb;
        private System.Windows.Forms.GroupBox BaudBox;
        private System.Windows.Forms.RadioButton RB_115200;
        private System.Windows.Forms.RadioButton RB_38200;
        private System.Windows.Forms.RadioButton RB_9600;
        private System.Windows.Forms.Label lblVersion;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spr_lang;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Statusbar;
        private System.Windows.Forms.Label lbl_lang;
        private System.Windows.Forms.ComboBox CB_lang;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.ComboBox cb_comport;
        private System.Windows.Forms.Button Btn_langsave;
        private System.Windows.Forms.Button Btn_lang;
        private System.Windows.Forms.Button Btn_Save;
    }
}

