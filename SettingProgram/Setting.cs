using DevExpress.Spreadsheet;
using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using UrineAnalyzer;

namespace SettingProgram
{
    public partial class Frm_set : Form
    {

        static DataTable SetDataTable = Data.Set.Copy();
        static DataTable LangDataTable = Data.FullLang.Copy();
        static DataTable SelectLangDataTable = Data.Lang.Copy();
        static DataTable ChangeLangDataTable = Data.FullLang.Copy();
        static DataRow SetDataRow = SetDataTable.Rows[0];
        static string[] portName = SerialPort.GetPortNames();
        public static bool flag_langsave;//220407
        public Frm_set()
        {
            DoubleBuffered = true;
            InitializeComponent();
            //USBConnect.Status_cmd += new USBConnect.StatusHandler(status); //220413
            Console.WriteLine(LangDataTable.Rows.Count);
        }

        //        public string targetpath = Application.StartupPath + @"\Data.accdb";
        static int unit;
        static int serial;
        static int baud;
        static string lang;
        static Color neg_fore;
        static Color neg_back;
        static Color pos_fore;
        static Color pos_back;
        static bool flag_save = false;
        static string port;
        //Frm_Main frmMain = new Frm_Main();


        private void Frm_set_Load(object sender, EventArgs e)
        {
            try
            {
                FrmSizeSet();
                this.Text = Data.dSetting;
                cb_comport.Visible = false;
                btn_scan.Visible = false;
                ComboSet();
                InitSet();
                InitLang(CB_lang.SelectedItem.ToString());
                LangSet();
                Color_Load();
                this.BackgroundImage = ImageLoad.setBack;
                Btn_Save.BackgroundImage = ImageLoad.btnSaveBack;
                Btn_lang.BackgroundImage = ImageLoad.btnLangBack;
                Btn_langsave.BackgroundImage = ImageLoad.btnSaveBack;
                Btn_langsave.Visible = false;
                spr_lang.Visible = false;
                lbl_lang.Visible = false;
                CB_lang.Visible = false;
                //USBConnect.USBStart();  //220413
                ChangeLangDataTable.Rows.Clear();
                flag_langsave = false;
                flag_save = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        
        private void FrmSizeSet()
        {
            label1.Width = 116;
            label1.Height = 23;
            spr_Color.Width = 305;
            spr_Color.Height = 129;
            RB_Arb.Width = 57;
            RB_Arb.Height = 24;
            UnitBox.Width = 305;
            UnitBox.Height = 99;
            RB_SI.Width = 54;
            RB_SI.Height = 24;
            RB_Conv.Width = 73;
            RB_Conv.Height = 24;
            SerialBox.Width = 305;
            SerialBox.Height = 76;
            btn_scan.Width = 67;
            btn_scan.Height = 30;
            cb_comport.Width = 103;
            cb_comport.Height = 27;
            RB_Serial.Width = 83;
            RB_Serial.Height = 24;
            RB_usb.Width = 62;
            RB_usb.Height = 24;
            BaudBox.Width = 305;
            BaudBox.Height = 99;
            RB_115200.Width = 80;
            RB_115200.Height = 24;
            RB_38200.Width = 72;
            RB_38200.Height = 24;
            RB_9600.Width = 63;
            RB_9600.Height = 24;
            lblVersion.Width = 305;
            lblVersion.Height = 33;
            spr_lang.Width = 419;
           spr_lang.Height = 531;
            statusStrip1.Width = 901;
            statusStrip1.Height = 22;
            Statusbar.Width = 300;
            Statusbar.Height = 17;
            lbl_lang.Width = 93;
            lbl_lang.Height = 23;
            CB_lang.Width = 120;
            CB_lang.Height = 25;
            Btn_Save.Width =118 ;
            Btn_Save.Height = 42;
            Btn_lang.Width = 118;
            Btn_lang.Height = 42;
            Btn_langsave.Width =118 ;
            Btn_langsave.Height = 42;
            this.Width = 917;
           this .Height = 737;

            label1.Left = 60;
            label1.Top = 64;
            spr_Color.Left = 60;
            spr_Color.Top = 92;
            RB_Arb.Left = 24;
            RB_Arb.Top = 24;
            UnitBox.Left =60;
            UnitBox.Top = 231;
            RB_SI.Left = 24;
            RB_SI.Top = 72;
            RB_Conv.Left = 24;
            RB_Conv.Top = 48;
            SerialBox.Left = 58;
            SerialBox.Top = 340;
            btn_scan.Left = 225;
            btn_scan.Top = 45;
            cb_comport.Left = 110;
            cb_comport.Top = 45;
            RB_Serial.Left = 24;
            RB_Serial.Top = 48;
            RB_usb.Left = 24;
            RB_usb.Top = 24;
            BaudBox.Left = 58;
            BaudBox.Top = 426;
            RB_115200.Left =24;
            RB_115200.Top = 72;
            RB_38200.Left = 24;
            RB_38200.Top = 48;
            RB_9600.Left = 24;
            RB_9600.Top = 24;
            lblVersion.Left = 58;
            lblVersion.Top = 639;
            spr_lang.Left = 424;
            spr_lang.Top = 92;
            statusStrip1.Left = 0;
            statusStrip1.Top = 676;
            lbl_lang.Left = 424;
            lbl_lang.Top = 64;
            CB_lang.Left = 519;
            CB_lang.Top = 64;
            Btn_Save.Left = 58;
            Btn_Save.Top = 542;
            Btn_lang.Left = 184;
            Btn_lang.Top = 542;
            Btn_langsave.Left = 424;
            Btn_langsave.Top = 632;
           
        }



        private void LangSet()
        {
            this.Text = Data.dSetting;
            label1.Text = Data.dResultMark;
            lblVersion.Text = Data.Version;
            UnitBox.Text = Data.dUnit;
            RB_Arb.Text = Data.dArb;
            RB_Conv.Text = Data.dConv;
            RB_SI.Text = Data.dSI;
            SerialBox.Text = Data.dInterface;
            RB_usb.Text = Data.dUSB;
            RB_Serial.Text = Data.dRS232;
            BaudBox.Text = Data.dBaudrate;
            lbl_lang.Text = Data.dLanguage;
            btn_scan.Text = Data.dScan;
        }

        private void status()
        {
            Statusbar.Text = Data.StatusData;
        }

        private void ComboSet()
        {
            DataTable sortdt = DataConn.GetDataTable("DB_Lang", true, "Sort");
            for (int i = 0; i < sortdt.Rows.Count; i++)
            {
                CB_lang.Items.Add(sortdt.Rows[i][0].ToString());
            }
            CB_lang.SelectedIndex = 0;

        }


        private void InitSet() //220405
        {
            //220414 Start
            if (Data.Get_SetStart)
            {
                string sql = "UPDATE DB_Set SET BaudRate = 0 WHERE BaudRate = -1";
                DataConn.Getdata(sql);
                Data.Get_SetStart = false;
            }
            //220414 End

            cb_comport.Items.AddRange(portName);

            if (cb_comport.Items.Count == 0)
            {
                cb_comport.Items.Add("COM1");
                cb_comport.SelectedIndex = 0;
            }

            SetDataTable = DataConn.GetDataTable("DB_Set");
            SetDataRow = SetDataTable.Rows[0];          //220414
            if (SetDataTable.Rows.Count > 0)
            {
                neg_fore = Color.FromArgb(Convert.ToInt32(SetDataRow["Neg_Fore_R"]), Convert.ToInt32(SetDataRow["Neg_Fore_G"]), Convert.ToInt32(SetDataRow["Neg_Fore_B"]));
                neg_back = Color.FromArgb(Convert.ToInt32(SetDataRow["Neg_Back_R"]), Convert.ToInt32(SetDataRow["Neg_Back_G"]), Convert.ToInt32(SetDataRow["Neg_Back_B"]));
                pos_fore = Color.FromArgb(Convert.ToInt32(SetDataRow["Pos_Fore_R"]), Convert.ToInt32(SetDataRow["Pos_Fore_G"]), Convert.ToInt32(SetDataRow["Pos_Fore_B"]));
                pos_back = Color.FromArgb(Convert.ToInt32(SetDataRow["Pos_Back_R"]), Convert.ToInt32(SetDataRow["Pos_Back_G"]), Convert.ToInt32(SetDataRow["Pos_Back_B"]));
                unit = Convert.ToInt32(SetDataRow["Unit"]);
                serial = Convert.ToInt32(SetDataRow["Serial"]);
                baud = Convert.ToInt32(SetDataRow["BaudRate"]);
                lang = SetDataRow["Lang"].ToString();
                port = SetDataRow["PortName"].ToString();

                if (unit == 0)
                {
                    RB_Arb.Checked = true;
                    RB_Conv.Checked = false;
                    RB_SI.Checked = false;
                }
                else if (unit == 1)
                {
                    RB_Arb.Checked = false;
                    RB_Conv.Checked = true;
                    RB_SI.Checked = false;
                }
                else
                {
                    RB_Arb.Checked = false;
                    RB_Conv.Checked = false;
                    RB_SI.Checked = true;
                }

                if (serial == 0)
                {
                    RB_usb.Checked = true;
                    RB_Serial.Checked = false;
                }
                else
                {
                    RB_usb.Checked = false;
                    RB_Serial.Checked = true;
                    cb_comport.Visible = true;
                    btn_scan.Visible = true;
                }

                if (baud == 0)
                {
                    RB_9600.Checked = true;
                    RB_38200.Checked = false;
                    RB_115200.Checked = false;
                }
                else if (baud == 1)
                {
                    RB_9600.Checked = false;
                    RB_38200.Checked = true;
                    RB_115200.Checked = false;
                }
                else if (baud == 2)
                {
                    RB_9600.Checked = false;
                    RB_38200.Checked = false;
                    RB_115200.Checked = true;
                }

                CB_lang.SelectedItem = lang;
                int index = cb_comport.FindString(port);

                if (index > 0)
                {
                    cb_comport.SelectedIndex = index;
                }
                else
                {
                    cb_comport.SelectedIndex = 0;
                }
               
            }
            else
            {       //DB_Set에 처음부터 값 넣어서 셋팅
                neg_fore = Color.FromArgb(0, 0, 255);
                neg_back = Color.FromArgb(231, 232, 244);
                pos_fore = Color.FromArgb(255, 0, 0);
                pos_back = Color.FromArgb(249, 216, 197);

                unit = 0;
                RB_Arb.Checked = true;
                serial = 0;
                RB_usb.Checked = true;
                baud = 0;
                RB_9600.Checked = true;
                lang = "English";
                cb_comport.SelectedIndex = 0;
                Insert_Set();
                //string sql2 = $"INSERT INTO DB_Set VALUES( {neg_fore.R.ToString()},{neg_fore.G.ToString()},{neg_fore.B.ToString()},{neg_back.R.ToString()},{neg_back.G.ToString()},{neg_back.B.ToString()},{pos_fore.R.ToString()},{pos_fore.G.ToString()},{pos_fore.B.ToString()},{pos_back.R.ToString()},{pos_back.G.ToString()},{pos_back.B.ToString()}, {unit}, {serial}, {baud})";
                //DataConn.Getdata(sql2);
            }

            DataConn.CloseDB();
        }

        private void Insert_Set()
        {
            DataRow dr = SetDataTable.NewRow();
            dr["Neg_Fore_R"] = neg_fore.R;
            dr["Neg_Fore_G"] = neg_fore.G;
            dr["Neg_Fore_B"] = neg_fore.B;
            dr["Neg_Back_R"] = neg_back.R;
            dr["Neg_Back_G"] = neg_back.G;
            dr["Neg_Back_B"] = neg_back.B;
            dr["Pos_Fore_R"] = pos_fore.R;
            dr["Pos_Fore_G"] = pos_fore.G;
            dr["Pos_Fore_B"] = pos_fore.B;
            dr["Pos_Back_R"] = pos_back.R;
            dr["Pos_Back_G"] = pos_back.G;
            dr["Pos_Back_B"] = pos_back.B;
            dr["Unit"] = unit;
            dr["Serial"] = serial;
            dr["BaudRate"] = baud;
            dr["Lang"] = lang;
            dr["PortName"] = cb_comport.SelectedItem;
            DataConn.InsertData(SetDataTable, dr);
            DataConn.GetDataCommit();
        }

        private void Color_Load()
        {
            spr_Color.BeginUpdate();
            spr_Color.Options.Behavior.ShowPopupMenu = DevExpress.XtraSpreadsheet.DocumentCapability.Hidden;
            spr_Color.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            spr_Color.Cursor = System.Windows.Forms.Cursors.Default;
            spr_Color.Options.HorizontalScrollbar.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetScrollbarVisibility.Hidden;
            spr_Color.Options.TabSelector.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetElementVisibility.Hidden;
            spr_Color.Options.VerticalScrollbar.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetScrollbarVisibility.Hidden;
            spr_Color.Options.ZoomMode = DevExpress.Spreadsheet.WorksheetZoomMode.ActiveView;
            spr_Color.ReadOnly = true;
            Worksheet sheet = this.spr_Color.Document.Worksheets[0];
            sheet.ActiveView.ShowHeadings = false;
            sheet.MergeCells(sheet.Range.FromLTRB(0, 0, 0, 1));
            sheet.MergeCells(sheet.Range.FromLTRB(0, 2, 0, 3));
            sheet.MergeCells(sheet.Range.FromLTRB(2, 0, 2, 1));
            sheet.MergeCells(sheet.Range.FromLTRB(2, 2, 2, 3));
            sheet.Range.FromLTRB(0, 0, 0, 3).ColumnWidth = 165;
            sheet.Range.FromLTRB(1, 0, 1, 3).ColumnWidth = 315;
            sheet.Range.FromLTRB(2, 0, 2, 3).ColumnWidth = 465;
            sheet.Rows[0][0].SetValue(Data.dNeg);
            sheet.Rows[2][0].SetValue(Data.dPos);
            sheet.Rows[0][1].SetValue(Data.dForeColor);
            sheet.Rows[1][1].SetValue(Data.dBackColor);
            sheet.Rows[2][1].SetValue(Data.dForeColor);
            sheet.Rows[3][1].SetValue(Data.dBackColor);
            sheet.Rows[0][2].SetValue("ABCD1234");
            sheet.Rows[0][2].FillColor = neg_back;
            sheet.Rows[0][2].Font.Color = neg_fore;
            sheet.Rows[2][2].SetValue("ABCD1234");
            sheet.Rows[2][2].FillColor = pos_back;
            sheet.Rows[2][2].Font.Color = pos_fore;

            CellRange usedRange = sheet.GetUsedRange();
            usedRange.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            usedRange.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            usedRange.RowHeight = 100;
            usedRange.Font.Name = "Times New Roman";
            usedRange.Font.Size = 15;
            usedRange.Font.Bold = true;
            usedRange.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);

            spr_Color.WorksheetDisplayArea.SetSize(sheet.Index, usedRange.ColumnCount, usedRange.RowCount);
            sheet.Selection = sheet.Range.FromLTRB(0, 4, 0, 4); // 220404
            spr_Color.EndUpdate();
        }



        private void spr_Color_MouseUp(object sender, MouseEventArgs e)
        {
            CellRange cell = spr_Color.SelectedCell;
            Color Temp_Color;
            if (cell.LeftColumnIndex == 1)
            {
                switch (cell.TopRowIndex)
                {
                    case 0:
                        Temp_Color = SelColor(neg_fore);
                        if (Temp_Color != neg_fore)
                        {
                            neg_fore = Temp_Color;
                            flag_save = true;
                        }
                        break;
                    case 1:
                        Temp_Color = SelColor(neg_back);
                        if (Temp_Color != neg_back)
                        {
                            neg_back = Temp_Color;
                            flag_save = true;
                        }
                        break;
                    case 2:
                        Temp_Color = SelColor(pos_fore);
                        if (Temp_Color != pos_fore)
                        {
                            pos_fore = Temp_Color;
                            flag_save = true;
                        }
                        break;
                    case 3:
                        Temp_Color = SelColor(pos_back);
                        if (Temp_Color != pos_back)
                        {
                            pos_back = Temp_Color;
                            flag_save = true;
                        }
                        break;
                }
                Color_Load();

            }
            //Console.WriteLine($"{cell.LeftColumnIndex} : {cell.RightColumnIndex} : {cell.TopRowIndex} : {cell.BottomRowIndex}");
        }

        private Color SelColor(Color defaltColor)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {

                return cd.Color;
            }
            else
            {
                return defaltColor;
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            DataConn.DeleteData(SetDataTable);
            DataConn.GetDataCommit();
            /*string sql = $"UPDATE DB_Set SET Neg_Fore_R = {neg_fore.R.ToString()}, Neg_Fore_G = {neg_fore.R.ToString()}, Neg_Fore_B = {neg_fore.B.ToString()}, ";
            sql += $"Neg_Back_R = {neg_back.R.ToString()}, Neg_Back_G = {neg_back.G.ToString()}, Neg_Back_B = {neg_back.B.ToString()}, ";
            sql += $"Pos_Fore_R = {pos_fore.R.ToString()}, Pos_Fore_G = {pos_fore.G.ToString()}, Pos_Fore_B = {pos_fore.B.ToString()}, ";
            sql += $"Pos_Back_R = {pos_back.R.ToString()}, Pos_Back_G = {pos_back.G.ToString()}, Pos_Back_B = {pos_back.B.ToString()}, ";
            sql += $" Unit = {unit}, Serial = {serial}, BaudRate = {baud}";
            DataConn.Getdata(sql);*/

            Insert_Set();
            MessageBox.Show(Data.dComplete);
            flag_save = false;
        }

        private void RB_Arb_CheckedChanged(object sender, EventArgs e)
        {
            if (unit != 0) flag_save = true;
            unit = 0;
        }

        private void RB_Conv_CheckedChanged(object sender, EventArgs e)
        {
            if (unit != 1) flag_save = true;
            unit = 1;
        }

        private void RB_SI_CheckedChanged(object sender, EventArgs e)
        {
            if (unit != 2) flag_save = true;
            unit = 2;
        }

        private void RB_usb_CheckedChanged(object sender, EventArgs e)
        {
            if (serial != 0) flag_save = true;
            serial = 0;
            if (RB_usb.Checked)
            {
                cb_comport.Visible = false;
                btn_scan.Visible = false;
            }
        }

        private void RB_Serial_CheckedChanged(object sender, EventArgs e)
        {
            if (serial != 1) flag_save = true;
            serial = 1;
            if (RB_Serial.Checked)
            {
                cb_comport.Visible = true;
                btn_scan.Visible = true;
                RB_115200.Visible = true;
            }
            else
            {
                cb_comport.Visible = false;
                btn_scan.Visible = false;
                RB_115200.Visible = false;
                RB_9600.Checked = true;//220407
            }
        }

        private void RB_9600_CheckedChanged(object sender, EventArgs e)
        {
            if (baud != 0) flag_save = true;
            baud = 0;
        }

        private void RB_38200_CheckedChanged(object sender, EventArgs e)
        {
            if (baud != 1) flag_save = true;
            baud = 1;
        }

        private void RB_115200_CheckedChanged(object sender, EventArgs e)
        {
            if (baud != 2) flag_save = true;
            baud = 2;
        }

        private void Btn_lang_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = ImageLoad.langsetBack;
            Btn_lang.BackgroundImage = ImageLoad.btnDislangBack;
            Btn_langsave.Visible = true;
            spr_lang.Visible = true;
            lbl_lang.Visible = true;
            CB_lang.Visible = true;
        }
        private void InitLang(string Selectlang)
        {
            //string sql = $"SELECT * FROM DB_Lang";
            // string filterExpression = $"Sort = '{Selectlang}' AND ORDER BY SEQ";
            //DataRow[] dr = LangDataTable.Select(filterExpression);
            //for (int i = 0; i < dr.Length; i++) dt.ImportRow(dr[i]);
            //SelectLangDataTable = DataConn.GetDataTable($"DB_Lang WHERE Sort = '{Selectlang}' Order By English ASC");
            int cnt = SelectLangDataTable.Rows.Count;
            //SelectLangDataTable.DefaultView.Sort = "SEQ ASC";
            //SelectLangDataTable = SelectLangDataTable.DefaultView.ToTable(true);
            spr_lang.BeginUpdate();
            spr_lang.Options.Behavior.ShowPopupMenu = DevExpress.XtraSpreadsheet.DocumentCapability.Hidden;
            spr_lang.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            spr_lang.Cursor = System.Windows.Forms.Cursors.Default;
            spr_lang.Options.HorizontalScrollbar.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetScrollbarVisibility.Hidden;
            spr_lang.Options.TabSelector.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetElementVisibility.Hidden;
            //spr_lang.Options.VerticalScrollbar.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetScrollbarVisibility.Hidden;
            //spr_lang.Options.ZoomMode = DevExpress.Spreadsheet.WorksheetZoomMode.ActiveView;

            if (Selectlang != "Custom") spr_lang.ReadOnly = true;
            else spr_lang.ReadOnly = false;

            Worksheet sheet = this.spr_lang.Document.Worksheets[0];
            sheet.ActiveView.ShowHeadings = false;
            sheet["$A:$B"].Protection.Locked = false;
            sheet.Range.FromLTRB(0, 0, 0, cnt).Protection.Locked = true;
            sheet.Protect("123", WorksheetProtectionPermissions.Default);
            sheet.Range.FromLTRB(0, 0, 0, cnt).ColumnWidth = 550;
            //sheet.Range.FromLTRB(1, 0, 1, 69).ColumnWidth = 200;
            sheet.Range.FromLTRB(1, 0, 1, cnt).ColumnWidth = 650;

            Cell cell;

            cell = sheet.Rows[0][0];
            cell.SetValue(Data.dEnglish);
            cell = sheet.Rows[0][1];
            cell.SetValue(Data.dTranslation);
            cell.Protection.Locked = true;

            SetCellStyle(sheet["A1:B1"], true, 12, Color.LightGray);


            for (int i = 0; i < SelectLangDataTable.Rows.Count; i++)
            {
                string text;
                string subtext1 = "", subtext2 = "";

                cell = sheet.Rows[i + 1][0];
                text = SelectLangDataTable.Rows[i][1].ToString();
                if (text.Length > 20)
                {
                    foreach (string split in text.Split(' '))
                    {
                        Console.WriteLine(split);
                        if (subtext1.Length < 20)
                        {
                            subtext1 += split + ' ';
                        }
                        else
                        {
                            subtext2 += split + ' ';
                        }
                    }
                    text = subtext1;
                    if (subtext2 != "") text += "\r\n" + subtext2.Substring(0, subtext2.Length - 1);
                }
                cell.SetValueFromText(text);

                subtext1 = ""; subtext2 = "";
                cell = sheet.Rows[i + 1][1];
                text = SelectLangDataTable.Rows[i][2].ToString();

                if (text.Length > 20)
                {
                    foreach (string split in text.Split(' '))
                    {
                        Console.WriteLine(split);
                        if (subtext1.Length < 20)
                        {
                            subtext1 += split + ' ';
                        }
                        else
                        {
                            subtext2 += split + ' ';
                        }
                    }
                    text = subtext1;
                    if (subtext2 != "") text += "\r\n" + subtext2.Substring(0, subtext2.Length - 1);
                }
                cell.SetValueFromText(text);
            }
            SetCellStyle(sheet[$"A2:A{cnt + 1}"], true, 12, Color.Transparent);
            SetCellStyle(sheet[$"B2:B{cnt + 1}"], false, 12, Color.Transparent);
            CellRange usedRange = sheet.GetUsedRange();
            //          sheet.GetUsedRange().AutoFitColumns();
            //           sheet.GetUsedRange().AutoFitRows();

            spr_lang.WorksheetDisplayArea.SetSize(sheet.Index, usedRange.ColumnCount, usedRange.RowCount);
            spr_lang.EndUpdate();

            DataConn.CloseDB();
        }
        private void LangSet(string Selectlang)
        {
            /*for(int i =0; i<LangDataTable.Rows.Count; i++)
            {
                Console.WriteLine($"{LangDataTable.Rows[0][0]} || {LangDataTable.Rows[0][1]} || {LangDataTable.Rows[0][2]} || {LangDataTable.Rows[0][3]}");
            }
            SelectLangDataTable = LangDataTable.Select($"Sort = '{Selectlang}'").CopyToDataTable();
            SelectLangDataTable.DefaultView.Sort = "SEQ ASC";
            SelectLangDataTable = SelectLangDataTable.DefaultView.ToTable(true);*/
            SelectLangDataTable.Rows.Clear();
            string filterExpression = $"Sort = '{Selectlang}'";
            DataRow[] dr = LangDataTable.Select(filterExpression, "SEQ");
            for (int i = 0; i < dr.Length; i++) SelectLangDataTable.ImportRow(dr[i]);

            //SelectLangDataTable = DataConn.GetDataTable($"DB_Lang WHERE Sort = '{Selectlang}' Order By SEQ ASC");
            int cnt = SelectLangDataTable.Rows.Count;
            spr_lang.BeginUpdate();
            Worksheet sheet = this.spr_lang.Document.Worksheets[0];
            Cell cell;
            if (Selectlang != "Custom") spr_lang.ReadOnly = true;
            else spr_lang.ReadOnly = false;

            for (int i = 0; i < cnt; i++)
            {
                string text;
                string subtext1 = "", subtext2 = "";

                cell = sheet.Rows[i + 1][0];
                text = SelectLangDataTable.Rows[i][1].ToString();
                if (text.Length > 20)
                {
                    foreach (string split in text.Split(' '))
                    {
                        Console.WriteLine(split);
                        if (subtext1.Length < 20)
                        {
                            subtext1 += split + ' ';
                        }
                        else
                        {
                            subtext2 += split + ' ';
                        }
                    }
                    text = subtext1;
                    if (subtext2 != "") text += "\r\n" + subtext2.Substring(0, subtext2.Length - 1);
                }
                cell.SetValueFromText(text);

                subtext1 = ""; subtext2 = "";
                cell = sheet.Rows[i + 1][1];
                text = SelectLangDataTable.Rows[i][2].ToString();

                if (text.Length > 20)
                {
                    foreach (string split in text.Split(' '))
                    {
                        Console.WriteLine(split);
                        if (subtext1.Length < 20)
                        {
                            subtext1 += split + ' ';
                        }
                        else
                        {
                            subtext2 += split + ' ';
                        }
                    }
                    text = subtext1;
                    if (subtext2 != "") text += "\r\n" + subtext2.Substring(0, subtext2.Length - 1);
                }
                cell.SetValueFromText(text);
            }
            SetCellStyle(sheet[$"A2:A{cnt + 1}"], true, 12, Color.Transparent);
            SetCellStyle(sheet[$"B2:B{cnt + 1}"], false, 12, Color.Transparent);
            CellRange usedRange = sheet.GetUsedRange();
            //          sheet.GetUsedRange().AutoFitColumns();
            //           sheet.GetUsedRange().AutoFitRows();

            spr_lang.WorksheetDisplayArea.SetSize(sheet.Index, usedRange.ColumnCount, usedRange.RowCount);
            spr_lang.EndUpdate();
        }

        private void SetCellStyle(CellRange cell, bool isBold, int fontSize, Color fillColor)
        {
            cell.Font.Bold = isBold;
            cell.Font.Size = fontSize;
            cell.FillColor = fillColor;
            cell.Font.Name = "Times New Roman";
            cell.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
            cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
        }

        private void spr_lang_ProtectionWarning(object sender, System.ComponentModel.HandledEventArgs e)
        {
            e.Handled = true;
        }

        private void Btn_langsave_Click(object sender, EventArgs e)
        {
            string sql;
            string selectItem = CB_lang.SelectedItem.ToString();

            if (selectItem == "Custom")
            {
                if (ChangeLangDataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < ChangeLangDataTable.Rows.Count; i++)
                    {
                        DataConn.UpdateData(Data.Lang, ChangeLangDataTable.Rows[i], ChangeLangDataTable.Rows[i]["SEQ"].ToString(), "Custom");
                        //sql = $"UPDATE DB_Lang SET [Translation] = '{ChangeLangDataTable.Rows[i][1].ToString()}' WHERE English = '{ChangeLangDataTable.Rows[i][0].ToString()}' AND Sort = 'Custom'";
                        Console.WriteLine(ChangeLangDataTable.Rows.Count);
                        //DataConn.Getdata(sql);
                    }
                    Data.FullLang = DataConn.GetDataTable($"DB_Lang ORDER BY SEQ");
                    LangDataTable = Data.FullLang.Copy();
                }
                sql = $"UPDATE DB_Set SET [Lang] = '{selectItem}'";
                MessageBox.Show(Data.dComplete);
            }
            else
            {
                sql = $"UPDATE DB_Set SET [Lang] = '{selectItem}'";
                MessageBox.Show(Data.dComplete); //220424 
            }

            DataConn.Getdata(sql);
            //else MessageBox.Show("You cannot edit this language.");
            flag_langsave = false;//220407
        }

        private void spr_Color_MouseMove(object sender, MouseEventArgs e)
        {
            Worksheet sheet = this.spr_Color.Document.Worksheets[0];
            for (int i = 0; i < 4; i++)
            {
                Rectangle rec = spr_Color.GetCellBounds(i, 1);
                Cell c = sheet.Rows[i][1];
                if (rec.Contains(e.Location))
                {
                    // spr_Color.Cursor = Cursors.Hand;
                    SetCellStyle(c, true, 15, Color.LightGray);
                    c.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thick);
                }
                else SetCellStyle(c, true, 15, Color.Transparent);
            }
        }

        private void spr_Color_MouseLeave(object sender, EventArgs e)
        {
            Worksheet sheet = this.spr_Color.Document.Worksheets[0];
            for (int i = 0; i < 4; i++)
            {
                Cell c = sheet.Rows[i][1];
                SetCellStyle(c, true, 15, Color.Transparent);
            }
        }


        /*  private void spr_lang_MouseUp(object sender, MouseEventArgs e)
          {
              /*Worksheet sheet = this.spr_lang.Document.Worksheets[0];
              for (int i = 0; i < sldt.Rows.Count; i++)
              {
                  Cell c = sheet.Rows[i + 1][1];
                  if (c.Value.IsEmpty) c.SetValue(sldt.Rows[i][1]);
              }

              CellRange cell = spr_lang.SelectedCell;
              if ((cell.LeftColumnIndex == 1) && (cell.TopRowIndex != 0))
              {
                  cell.Value = CellValue.Empty;
              }
          }*/

        //220407 START
        private void Frm_set_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag_save || flag_langsave)
            {
                if (MessageBox.Show($"{Data.dWarningError1}\n{Data.dWarningError2}", Data.dWarning, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + @"\UrineAnalyzer.exe");
                    //Application.Exit();
                    Environment.Exit(0);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();

                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {

                System.Diagnostics.Process.Start(Application.StartupPath + @"\UrineAnalyzer.exe");
                //Application.Exit();
                Environment.Exit(0);
                System.Diagnostics.Process.GetCurrentProcess().Kill();

            }
        }
        //220407 End

        private void CB_lang_DropDownClosed(object sender, EventArgs e)
        {
            LangSet(CB_lang.SelectedItem.ToString());

        }

        private void spr_lang_CellBeginEdit(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellCancelEventArgs e)
        {
            Worksheet sheet = this.spr_lang.Document.Worksheets[0];
            CellRange cell = sheet.Rows[e.RowIndex][e.ColumnIndex];
            if ((cell.LeftColumnIndex == 1) && (cell.TopRowIndex != 0))
            {
                cell.Value = CellValue.Empty;
            }
        }

        private void spr_lang_CellEndEdit(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellValidatingEventArgs e)
        {
            Worksheet sheet = this.spr_lang.Document.Worksheets[0];
            int index = e.RowIndex;
            //Cell c = sheet.Rows[index][1];
            string SEQ = SelectLangDataTable.Rows[index - 1]["SEQ"].ToString();//220406

            if (e.EditorText == "")
            {
                e.EditorText = SelectLangDataTable.Rows[index - 1]["Translation"].ToString();//220406
                Console.WriteLine($"text : '{e.EditorText}' /index : {index} / value : '{SelectLangDataTable.Rows[index - 1][1]}'");
            }
            else
            {
                DataRow row = ChangeLangDataTable.NewRow();
                row.BeginEdit();
                string filterExpression = $"Sort = 'Custom' AND SEQ = '{SEQ}'";
                Console.WriteLine(filterExpression + LangDataTable.Rows.Count);
                DataRow[] dr = LangDataTable.Select(filterExpression);
                //Console.WriteLine($"Insert{dr[0].ToString()} || {dr[1].ToString()} || {dr[2].ToString()} ||{dr[3].ToString()} ");
                row["SEQ"] = dr[0]["SEQ"].ToString();
                row["English"] = dr[0]["English"].ToString();
                row["Translation"] = e.EditorText.ToString();
                row["Sort"] = "Custom";
                row.EndEdit();
                ChangeLangDataTable.Rows.Add(row);
                flag_langsave = true;//220407
                                     //int indexdr = LangDataTable.Rows.IndexOf(dr[0]);
                                     // LangDataTable.Rows[indexdr]["Translation"] = row["Translation"].ToString();
                                     // Console.WriteLine($"Insert{row[0].ToString()} || {row[1].ToString()} || {row[2].ToString()} || {row[3].ToString()} ");
            }

            //Console.WriteLine($"before index : {index} / '{sheet.Rows[index][0].Value.ToString()}', '{sheet.Rows[index][1].Value.ToString()}'");


        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            cb_comport.Items.Clear();
            portName = SerialPort.GetPortNames();
            cb_comport.Items.AddRange(portName);
            cb_comport.SelectedIndex = 0;
        }

        private void spr_lang_CellValueChanged(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellEventArgs e)
        {
            /*Worksheet sheet = this.spr_lang.Document.Worksheets[0];
            int index = e.RowIndex;

            if (e.Value.IsEmpty)
            {
                Cell c = sheet.Rows[index][1];
                c.Value = SelectLangDataTable.Rows[index - 1][1].ToString();
                // Console.WriteLine($"text : '{e.EditorText}' /index : {index} / value : '{sldt.Rows[index - 1][1]}'");
            }
            else
            {
                DataRow row = ChangeLangDataTable.NewRow();
                row.BeginEdit();
                row[0] = sheet.Rows[index][0].Value.ToString();
                row[1] = sheet.Rows[index][1].Value.ToString();
                row.EndEdit();
                ChangeLangDataTable.Rows.Add(row);
                string filterExpression = $"Sort = 'Custom' AND English = '{row[0]}'";
                Console.WriteLine(filterExpression + LangDataTable.Rows.Count);
                DataRow[] dr = LangDataTable.Select(filterExpression);
                int indexdr = LangDataTable.Rows.IndexOf(dr[0]);
                LangDataTable.Rows[indexdr]["Translation"] = row["Translation"].ToString();
                Console.WriteLine($"Insert{row[0]} || {row[1]} || Cnt : {index}");
            }*/
        }

        private void CB_lang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = $"DB_Lang WHERE Sort = '{CB_lang.SelectedItem.ToString()}' ORDER BY SEQ";
            Console.WriteLine(sql);
            SelectLangDataTable = DataConn.GetDataTable(sql);
            flag_langsave = true;
        }

       
    }
}
