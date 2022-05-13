
using DevExpress.XtraSpreadsheet;

namespace UrineAnalyzer
{
    partial class Frm_Result
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Result));
            this.tt_user = new System.Windows.Forms.ToolTip(this.components);
            this.tt_result = new System.Windows.Forms.ToolTip(this.components);
            this.tt_Set = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Id = new System.Windows.Forms.Label();
            this.DBGrid_test = new System.Windows.Forms.DataGridView();
            this.Btn_Graph = new System.Windows.Forms.Button();
            this.Btn_list = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_seq = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_tdate = new System.Windows.Forms.Label();
            this.lbl_ttime = new System.Windows.Forms.Label();
            this.lbl_ttype = new System.Windows.Forms.Label();
            this.lbl_oper = new System.Windows.Forms.Label();
            this.spr_result = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.cb_color = new System.Windows.Forms.ComboBox();
            this.cb_trub = new System.Windows.Forms.ComboBox();
            this.data_test = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBar1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Btn_result = new System.Windows.Forms.Button();
            this.panel_Graph = new System.Windows.Forms.Panel();
            this.Btn_View = new System.Windows.Forms.Button();
            this.CB_item = new System.Windows.Forms.ComboBox();
            this.RBtn_item = new System.Windows.Forms.RadioButton();
            this.RBtn_test = new System.Windows.Forms.RadioButton();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.DT_bth = new System.Windows.Forms.DateTimePicker();
            this.cb_sex = new System.Windows.Forms.ComboBox();
            this.lbl_lotno = new System.Windows.Forms.Label();
            this.lbl_sol = new System.Windows.Forms.Label();
            this.panel_QC = new System.Windows.Forms.Panel();
            this.panel_GE = new System.Windows.Forms.Panel();
            this.spr_List = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.tt_logout = new System.Windows.Forms.ToolTip(this.components);
            this.tt_close = new System.Windows.Forms.ToolTip(this.components);
            this.Btn_set = new System.Windows.Forms.Button();
            this.Btn_reset = new System.Windows.Forms.Button();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Btn_Psave = new System.Windows.Forms.Button();
            this.Btn_print = new System.Windows.Forms.Button();
            this.Btn_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid_test)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_test)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel_Graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(223, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sex";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(223, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Birthday";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Patient ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Id
            // 
            this.lbl_Id.BackColor = System.Drawing.Color.White;
            this.lbl_Id.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Id.Location = new System.Drawing.Point(367, 148);
            this.lbl_Id.Name = "lbl_Id";
            this.lbl_Id.Size = new System.Drawing.Size(116, 25);
            this.lbl_Id.TabIndex = 11;
            this.lbl_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DBGrid_test
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DBGrid_test.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DBGrid_test.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DBGrid_test.DefaultCellStyle = dataGridViewCellStyle2;
            this.DBGrid_test.Location = new System.Drawing.Point(208, 391);
            this.DBGrid_test.Name = "DBGrid_test";
            this.DBGrid_test.RowTemplate.Height = 23;
            this.DBGrid_test.RowTemplate.ReadOnly = true;
            this.DBGrid_test.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DBGrid_test.Size = new System.Drawing.Size(285, 466);
            this.DBGrid_test.TabIndex = 15;
            this.DBGrid_test.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBGrid_test_CellClick);
            this.DBGrid_test.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DBGrid_test_KeyDown);
            // 
            // Btn_Graph
            // 
            this.Btn_Graph.BackColor = System.Drawing.SystemColors.Menu;
            this.Btn_Graph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btn_Graph.FlatAppearance.BorderSize = 0;
            this.Btn_Graph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Graph.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Graph.Location = new System.Drawing.Point(1, 199);
            this.Btn_Graph.Name = "Btn_Graph";
            this.Btn_Graph.Size = new System.Drawing.Size(169, 38);
            this.Btn_Graph.TabIndex = 16;
            this.Btn_Graph.Text = " GRAPH";
            this.Btn_Graph.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Graph.UseVisualStyleBackColor = false;
            this.Btn_Graph.Click += new System.EventHandler(this.Btn_Graph_Click);
            // 
            // Btn_list
            // 
            this.Btn_list.BackColor = System.Drawing.SystemColors.Menu;
            this.Btn_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btn_list.FlatAppearance.BorderSize = 0;
            this.Btn_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_list.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_list.Location = new System.Drawing.Point(1, 252);
            this.Btn_list.Name = "Btn_list";
            this.Btn_list.Size = new System.Drawing.Size(169, 38);
            this.Btn_list.TabIndex = 17;
            this.Btn_list.Text = " LIST";
            this.Btn_list.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_list.UseVisualStyleBackColor = false;
            this.Btn_list.Click += new System.EventHandler(this.Btn_list_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(575, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 27);
            this.label5.TabIndex = 18;
            this.label5.Text = "SEQ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(846, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 27);
            this.label6.TabIndex = 19;
            this.label6.Text = "Color";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(846, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 27);
            this.label7.TabIndex = 20;
            this.label7.Text = "Turbidity";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_seq
            // 
            this.lbl_seq.BackColor = System.Drawing.Color.White;
            this.lbl_seq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_seq.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_seq.Location = new System.Drawing.Point(676, 164);
            this.lbl_seq.Name = "lbl_seq";
            this.lbl_seq.Size = new System.Drawing.Size(130, 27);
            this.lbl_seq.TabIndex = 21;
            this.lbl_seq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(179)))), ((int)(((byte)(198)))));
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(586, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 27);
            this.label8.TabIndex = 24;
            this.label8.Text = "Test Date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(179)))), ((int)(((byte)(198)))));
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(586, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 27);
            this.label9.TabIndex = 25;
            this.label9.Text = "Strip";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(179)))), ((int)(((byte)(198)))));
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(850, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 27);
            this.label10.TabIndex = 26;
            this.label10.Text = "Test Time";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(179)))), ((int)(((byte)(198)))));
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(850, 265);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 27);
            this.label11.TabIndex = 27;
            this.label11.Text = "Operator";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_tdate
            // 
            this.lbl_tdate.BackColor = System.Drawing.Color.White;
            this.lbl_tdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_tdate.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tdate.Location = new System.Drawing.Point(676, 235);
            this.lbl_tdate.Name = "lbl_tdate";
            this.lbl_tdate.Size = new System.Drawing.Size(130, 27);
            this.lbl_tdate.TabIndex = 28;
            this.lbl_tdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ttime
            // 
            this.lbl_ttime.BackColor = System.Drawing.Color.White;
            this.lbl_ttime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ttime.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ttime.Location = new System.Drawing.Point(953, 235);
            this.lbl_ttime.Name = "lbl_ttime";
            this.lbl_ttime.Size = new System.Drawing.Size(130, 27);
            this.lbl_ttime.TabIndex = 29;
            this.lbl_ttime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ttype
            // 
            this.lbl_ttype.BackColor = System.Drawing.Color.White;
            this.lbl_ttype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ttype.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ttype.Location = new System.Drawing.Point(676, 266);
            this.lbl_ttype.Name = "lbl_ttype";
            this.lbl_ttype.Size = new System.Drawing.Size(130, 27);
            this.lbl_ttype.TabIndex = 30;
            this.lbl_ttype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_oper
            // 
            this.lbl_oper.BackColor = System.Drawing.Color.White;
            this.lbl_oper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_oper.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_oper.Location = new System.Drawing.Point(953, 266);
            this.lbl_oper.Name = "lbl_oper";
            this.lbl_oper.Size = new System.Drawing.Size(130, 27);
            this.lbl_oper.TabIndex = 31;
            this.lbl_oper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spr_result
            // 
            this.spr_result.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spr_result.Cursor = System.Windows.Forms.Cursors.Default;
            this.spr_result.Location = new System.Drawing.Point(531, 303);
            this.spr_result.Name = "spr_result";
            this.spr_result.Options.HorizontalScrollbar.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetScrollbarVisibility.Hidden;
            this.spr_result.Options.TabSelector.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetElementVisibility.Hidden;
            this.spr_result.Options.VerticalScrollbar.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetScrollbarVisibility.Hidden;
            this.spr_result.Options.ZoomMode = DevExpress.Spreadsheet.WorksheetZoomMode.ActiveView;
            this.spr_result.ReadOnly = true;
            this.spr_result.Size = new System.Drawing.Size(597, 557);
            this.spr_result.TabIndex = 35;
            this.spr_result.Text = "spreadsheetControl1";
            // 
            // cb_color
            // 
            this.cb_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_color.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.cb_color.FormattingEnabled = true;
            this.cb_color.Location = new System.Drawing.Point(953, 164);
            this.cb_color.Name = "cb_color";
            this.cb_color.Size = new System.Drawing.Size(130, 27);
            this.cb_color.TabIndex = 38;
            // 
            // cb_trub
            // 
            this.cb_trub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_trub.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.cb_trub.FormattingEnabled = true;
            this.cb_trub.Location = new System.Drawing.Point(953, 196);
            this.cb_trub.Name = "cb_trub";
            this.cb_trub.Size = new System.Drawing.Size(130, 27);
            this.cb_trub.TabIndex = 39;
            // 
            // data_test
            // 
            this.data_test.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_test.Location = new System.Drawing.Point(565, 27);
            this.data_test.Name = "data_test";
            this.data_test.RowTemplate.Height = 23;
            this.data_test.Size = new System.Drawing.Size(552, 79);
            this.data_test.TabIndex = 40;
            this.data_test.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar1,
            this.StatusBar2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 919);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1151, 22);
            this.statusStrip1.TabIndex = 41;
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
            this.StatusBar2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar2.Name = "StatusBar2";
            this.StatusBar2.Size = new System.Drawing.Size(250, 17);
            // 
            // Btn_result
            // 
            this.Btn_result.BackColor = System.Drawing.SystemColors.Menu;
            this.Btn_result.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_result.FlatAppearance.BorderSize = 0;
            this.Btn_result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_result.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_result.Location = new System.Drawing.Point(1, 146);
            this.Btn_result.Name = "Btn_result";
            this.Btn_result.Size = new System.Drawing.Size(169, 38);
            this.Btn_result.TabIndex = 43;
            this.Btn_result.Text = " RESULT";
            this.Btn_result.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_result.UseVisualStyleBackColor = false;
            this.Btn_result.Click += new System.EventHandler(this.Btn_result_Click);
            // 
            // panel_Graph
            // 
            this.panel_Graph.Controls.Add(this.Btn_View);
            this.panel_Graph.Controls.Add(this.CB_item);
            this.panel_Graph.Controls.Add(this.RBtn_item);
            this.panel_Graph.Controls.Add(this.RBtn_test);
            this.panel_Graph.Controls.Add(this.chartControl);
            this.panel_Graph.Location = new System.Drawing.Point(531, 303);
            this.panel_Graph.Name = "panel_Graph";
            this.panel_Graph.Size = new System.Drawing.Size(597, 557);
            this.panel_Graph.TabIndex = 42;
            // 
            // Btn_View
            // 
            this.Btn_View.AutoSize = true;
            this.Btn_View.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.Btn_View.Location = new System.Drawing.Point(484, 4);
            this.Btn_View.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_View.Name = "Btn_View";
            this.Btn_View.Size = new System.Drawing.Size(65, 27);
            this.Btn_View.TabIndex = 4;
            this.Btn_View.Text = "View";
            this.Btn_View.UseVisualStyleBackColor = true;
            this.Btn_View.Click += new System.EventHandler(this.Btn_View_Click);
            // 
            // CB_item
            // 
            this.CB_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_item.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_item.FormattingEnabled = true;
            this.CB_item.Location = new System.Drawing.Point(350, 9);
            this.CB_item.Name = "CB_item";
            this.CB_item.Size = new System.Drawing.Size(121, 23);
            this.CB_item.TabIndex = 3;
            // 
            // RBtn_item
            // 
            this.RBtn_item.AutoSize = true;
            this.RBtn_item.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtn_item.Location = new System.Drawing.Point(280, 6);
            this.RBtn_item.Name = "RBtn_item";
            this.RBtn_item.Size = new System.Drawing.Size(54, 23);
            this.RBtn_item.TabIndex = 2;
            this.RBtn_item.TabStop = true;
            this.RBtn_item.Text = "Item";
            this.RBtn_item.UseVisualStyleBackColor = true;
            this.RBtn_item.CheckedChanged += new System.EventHandler(this.RBtn_item_CheckedChanged);
            // 
            // RBtn_test
            // 
            this.RBtn_test.AutoSize = true;
            this.RBtn_test.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtn_test.Location = new System.Drawing.Point(100, 6);
            this.RBtn_test.Name = "RBtn_test";
            this.RBtn_test.Size = new System.Drawing.Size(52, 23);
            this.RBtn_test.TabIndex = 1;
            this.RBtn_test.TabStop = true;
            this.RBtn_test.Text = "Test";
            this.RBtn_test.UseVisualStyleBackColor = true;
            this.RBtn_test.CheckedChanged += new System.EventHandler(this.RBtn_test_CheckedChanged);
            // 
            // chartControl
            // 
            this.chartControl.AppearanceNameSerializable = "Gray";
            xyDiagram1.AxisX.AutoScaleBreaks.MaxCount = 1;
            xyDiagram1.AxisX.LabelVisibilityMode = DevExpress.XtraCharts.AxisLabelVisibilityMode.AutoGeneratedAndCustom;
            xyDiagram1.AxisX.NumericScaleOptions.AutoGrid = false;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.PaneDistance = 13;
            this.chartControl.Diagram = xyDiagram1;
            this.chartControl.Legend.Name = "Default Legend";
            this.chartControl.Legend.TextVisible = false;
            this.chartControl.Location = new System.Drawing.Point(0, 35);
            this.chartControl.Margin = new System.Windows.Forms.Padding(0);
            this.chartControl.Name = "chartControl";
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.LegendName = "Default Legend";
            series1.Name = "Series 1";
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl.Size = new System.Drawing.Size(597, 519);
            this.chartControl.TabIndex = 0;
            this.chartControl.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.txt_name.Location = new System.Drawing.Point(367, 183);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(116, 27);
            this.txt_name.TabIndex = 47;
            // 
            // DT_bth
            // 
            this.DT_bth.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_bth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DT_bth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DT_bth.Location = new System.Drawing.Point(367, 217);
            this.DT_bth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DT_bth.Name = "DT_bth";
            this.DT_bth.Size = new System.Drawing.Size(116, 27);
            this.DT_bth.TabIndex = 48;
            // 
            // cb_sex
            // 
            this.cb_sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sex.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.cb_sex.FormattingEnabled = true;
            this.cb_sex.Location = new System.Drawing.Point(367, 250);
            this.cb_sex.Name = "cb_sex";
            this.cb_sex.Size = new System.Drawing.Size(116, 27);
            this.cb_sex.TabIndex = 49;
            // 
            // lbl_lotno
            // 
            this.lbl_lotno.BackColor = System.Drawing.Color.White;
            this.lbl_lotno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_lotno.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lotno.Location = new System.Drawing.Point(953, 164);
            this.lbl_lotno.Name = "lbl_lotno";
            this.lbl_lotno.Size = new System.Drawing.Size(130, 27);
            this.lbl_lotno.TabIndex = 54;
            this.lbl_lotno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_lotno.Visible = false;
            // 
            // lbl_sol
            // 
            this.lbl_sol.BackColor = System.Drawing.Color.White;
            this.lbl_sol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_sol.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sol.Location = new System.Drawing.Point(953, 196);
            this.lbl_sol.Name = "lbl_sol";
            this.lbl_sol.Size = new System.Drawing.Size(130, 27);
            this.lbl_sol.TabIndex = 55;
            this.lbl_sol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_sol.Visible = false;
            // 
            // panel_QC
            // 
            this.panel_QC.Location = new System.Drawing.Point(697, 112);
            this.panel_QC.Name = "panel_QC";
            this.panel_QC.Size = new System.Drawing.Size(148, 36);
            this.panel_QC.TabIndex = 53;
            this.panel_QC.Click += new System.EventHandler(this.panel_QC_Click);
            // 
            // panel_GE
            // 
            this.panel_GE.Location = new System.Drawing.Point(534, 112);
            this.panel_GE.Name = "panel_GE";
            this.panel_GE.Size = new System.Drawing.Size(148, 36);
            this.panel_GE.TabIndex = 52;
            this.panel_GE.Click += new System.EventHandler(this.panel_GE_Click);
            // 
            // spr_List
            // 
            this.spr_List.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spr_List.Cursor = System.Windows.Forms.Cursors.Default;
            this.spr_List.Location = new System.Drawing.Point(208, 143);
            this.spr_List.Name = "spr_List";
            this.spr_List.Options.Culture = new System.Globalization.CultureInfo("");
            this.spr_List.Options.TabSelector.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetElementVisibility.Hidden;
            this.spr_List.Options.ZoomMode = DevExpress.Spreadsheet.WorksheetZoomMode.ActiveView;
            this.spr_List.ReadOnly = true;
            this.spr_List.Size = new System.Drawing.Size(920, 717);
            this.spr_List.TabIndex = 58;
            // 
            // Btn_set
            // 
            this.Btn_set.Location = new System.Drawing.Point(1009, 866);
            this.Btn_set.Name = "Btn_set";
            this.Btn_set.Size = new System.Drawing.Size(118, 43);
            this.Btn_set.TabIndex = 71;
            this.Btn_set.UseVisualStyleBackColor = true;
            this.Btn_set.Visible = false;
            this.Btn_set.Click += new System.EventHandler(this.Btn_set_Click);
            // 
            // Btn_reset
            // 
            this.Btn_reset.Location = new System.Drawing.Point(332, 866);
            this.Btn_reset.Name = "Btn_reset";
            this.Btn_reset.Size = new System.Drawing.Size(118, 43);
            this.Btn_reset.TabIndex = 69;
            this.Btn_reset.UseVisualStyleBackColor = true;
            this.Btn_reset.Click += new System.EventHandler(this.Btn_reset_Click);
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(208, 866);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(118, 43);
            this.Btn_Search.TabIndex = 68;
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // Btn_Psave
            // 
            this.Btn_Psave.Location = new System.Drawing.Point(221, 289);
            this.Btn_Psave.Name = "Btn_Psave";
            this.Btn_Psave.Size = new System.Drawing.Size(118, 43);
            this.Btn_Psave.TabIndex = 70;
            this.Btn_Psave.UseVisualStyleBackColor = true;
            this.Btn_Psave.Click += new System.EventHandler(this.Btn_Psave_Click);
            // 
            // Btn_print
            // 
            this.Btn_print.Location = new System.Drawing.Point(655, 866);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(118, 43);
            this.Btn_print.TabIndex = 67;
            this.Btn_print.UseVisualStyleBackColor = true;
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // Btn_save
            // 
            this.Btn_save.Location = new System.Drawing.Point(531, 866);
            this.Btn_save.Name = "Btn_save";
            this.Btn_save.Size = new System.Drawing.Size(118, 43);
            this.Btn_save.TabIndex = 66;
            this.Btn_save.UseVisualStyleBackColor = true;
            this.Btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Frm_Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1151, 941);
            this.Controls.Add(this.spr_List);
            this.Controls.Add(this.Btn_set);
            this.Controls.Add(this.Btn_reset);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.Btn_Psave);
            this.Controls.Add(this.Btn_print);
            this.Controls.Add(this.Btn_save);
            this.Controls.Add(this.lbl_sol);
            this.Controls.Add(this.lbl_lotno);
            this.Controls.Add(this.panel_QC);
            this.Controls.Add(this.panel_GE);
            this.Controls.Add(this.cb_sex);
            this.Controls.Add(this.DT_bth);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.Btn_result);
            this.Controls.Add(this.panel_Graph);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.data_test);
            this.Controls.Add(this.cb_trub);
            this.Controls.Add(this.cb_color);
            this.Controls.Add(this.spr_result);
            this.Controls.Add(this.lbl_oper);
            this.Controls.Add(this.lbl_ttype);
            this.Controls.Add(this.lbl_ttime);
            this.Controls.Add(this.lbl_tdate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_seq);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Btn_list);
            this.Controls.Add(this.Btn_Graph);
            this.Controls.Add(this.DBGrid_test);
            this.Controls.Add(this.lbl_Id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Result";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Urine Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Result_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Result_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid_test)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_test)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel_Graph.ResumeLayout(false);
            this.panel_Graph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tt_user;
        private System.Windows.Forms.ToolTip tt_result;
        private System.Windows.Forms.ToolTip tt_Set;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DBGrid_test;
        private System.Windows.Forms.Button Btn_Graph;
        private System.Windows.Forms.Button Btn_list;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_seq;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_tdate;
        private System.Windows.Forms.Label lbl_ttime;
        private System.Windows.Forms.Label lbl_ttype;
        private System.Windows.Forms.Label lbl_oper;
        public System.Windows.Forms.Label lbl_Id;
        private SpreadsheetControl spr_result;
        public System.Windows.Forms.ComboBox cb_color;
        public System.Windows.Forms.ComboBox cb_trub;
        private System.Windows.Forms.DataGridView data_test;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar2;
        private System.Windows.Forms.Panel panel_Graph;
        private System.Windows.Forms.Button Btn_result;
        private DevExpress.XtraCharts.ChartControl chartControl;
        private System.Windows.Forms.ComboBox CB_item;
        private System.Windows.Forms.RadioButton RBtn_item;
        private System.Windows.Forms.RadioButton RBtn_test;
        private System.Windows.Forms.Button Btn_View;
        private System.Windows.Forms.TextBox txt_name;
        public System.Windows.Forms.DateTimePicker DT_bth;
        public System.Windows.Forms.ComboBox cb_sex;
        private System.Windows.Forms.Label lbl_lotno;
        private System.Windows.Forms.Label lbl_sol;
        private SpreadsheetControl spr_List;
        private System.Windows.Forms.ToolTip tt_logout;
        private System.Windows.Forms.ToolTip tt_close;
        private System.Windows.Forms.Panel panel_QC;
        private System.Windows.Forms.Panel panel_GE;
        private System.Windows.Forms.Button Btn_set;
        private System.Windows.Forms.Button Btn_reset;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.Button Btn_Psave;
        private System.Windows.Forms.Button Btn_print;
        private System.Windows.Forms.Button Btn_save;
        //        private DevExpress.XtraSpreadsheet.SpreadsheetControl spr_List;
    }
}