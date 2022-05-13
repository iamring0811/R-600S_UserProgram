using DevExpress.Spreadsheet;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UrineAnalyzer
{
    public partial class Frm_Result : Form
    {


        //        static SerialConnect S_connect = new SerialConnect();
        //        Frm_User frmUser = Frm_Main.frmUser;
        //        Frm_Setting frmSetting = Frm_Main.frmSetting;
        //        Frm_listset frmlistset = Frm_Main.frmlistset;
        static Worksheet resultSheet;
        static Worksheet listSheet;
        //        static Worksheet spr_List;

        static DataTable ResultGridDataTable;
        static DataTable QCGridDataTable;

        static DataTable GraphItemGridDataTable;

        static DataTable ResultDataTable;
        static DataTable ViewResultDataTable;

        static DataTable QCResultDataTable;
        static DataTable ViewQCResultDataTable;

        static DataTable ViewListDataTable;

        static DataTable PatientDataTable;

        static DataTable GraphResultDataTable;
        static DataTable GraphItemDataTable;

        static DataRow[] ResultDataRow;
        static DataRow[] QCResultDataRow;

        static DataRow[] ListDataRow;
        // static DataRow[] SelectListDataRow;
        static Cell cell;

        public static ChartControl GraphChart;

        static int[,] item = new int[3, 14];
        static string[,] Array_prt = new string[20, 13];
        static int error;
        static bool QCMode = false;
        static bool SearchMode = false;
        static string UserID;
        //DataTable PadColor;
        public int[,,] PadColor = new int[13, 9, 3];
        static Panel panel = new Panel();
        //        static StringBuilder resultString = new StringBuilder();
        static string[] listitem;// = new string[15]; 
        static int[] listseq;// = new int[15]; 
        static int listitemcnt; //
        public string[] resultcol;
        public string[] listcol;
        public static string[] exceptionalItem = { "S.G", "pH", "ALB", "CRE", "A:C", "" };
        public static int[] exceptionalItemindex = { 5, 7, 12, 13, 14 };
        public string[] arraycolor = { Data.lNone, Data.lYellow, Data.lDKYellow, Data.lStraw, Data.lAmber, Data.lRed, Data.lOrange, Data.lGreen, Data.lOther };
        public string[] arrayturb = { Data.lNone, Data.mClear, Data.mSLCloudy, Data.mCloudy, Data.mTurbid, Data.lOther };
        static int seq_;

        static readonly int[,] alb_item = {	
        //	{0,3,3,3,0},	//0
	        {4,3,3,3,0},	//0  4 : Retest 3: High Abnormal
	        {1,2,2,3,0},	//1  1: Normal 2: Abnormal
	        {1,2,2,2,0},	//2
	        {1,1,2,2,0},	//3
	        {1,1,1,2,0}	//4
            };

        static readonly int[,] pro_item = {	
        //	{0,3,3,3,0},	//0
	        {1,1,1,1,1},	//0
	        {2,2,2,1,1},	//1
	        {2,2,2,2,1},	//2
	        {2,2,2,2,2},	//3
	        {2,2,2,2,2},	//4
	        {2,2,2,2,2} //5
            };

        static readonly string[] albumin_tb = { "", "Normal", "Abnormal", "High Abnormal", "Retest" };

        static readonly string[,] alb_tb_text = {
         {"mg/g", "Retest", "300", "800", "1500"},//0
		{"mg/g", "20", "60", "160", "300"},//1
		{"mg/g", "10", "30", "80", "150"},//2
		{"mg/g", "5", "15", "40", "75"},//3
		{"mg/g", "3.3", "10", "26.7", "50"}//4
        };

        static readonly string[,] alb_tb_text_si = {
         {"mg/mmol", "Retest", "33.3", "88.9", "166.7"},//0
		{"mg/mmol", "2.3", "6.8", "18.2", "34.1"},//1
		{"mg/mmol", "1.1", "3.4", "9.1", "17.0"},//2
		{"mg/mmol", "0.6", "1.7", "4.5", "8.5"},//3
		{"mg/mmol", "0.4", "1.1", "3.0", "5.7"}//4
        };

        public Frm_Result()
        {
            DoubleBuffered = true;
            InitializeComponent();

            this.DBGrid_test.RowHeadersVisible = false;
            listSheet = spr_List.Document.Worksheets[0];
            if (Data.Get_SerialType == Data.USB)
            {
                USBConnect.result_cmd += new USBConnect.DataHandler(ReadResult);
                USBConnect.Status_cmd += new USBConnect.StatusHandler(Status);
            }
            else
            {
                SerialConnect.result_cmd += new SerialConnect.DataHandler(ReadResult);
                SerialConnect.Status_cmd += new SerialConnect.StatusHandler(Status);
            }
            Frm_Main.frmlistset.Close_ += new Frm_listset.CloseHandler(ListUpdate);

        }
        private void Setcol()
        {
            resultcol = new string[12];
            resultcol[0] = Data.cItem;
            resultcol[1] = Data.cResult;
            resultcol[2] = Data.cUnit;
            for (int i = 3; i < 12; i++)
            {
                resultcol[i] = Data.cGrade + (i - 2);
            }

            listcol = new string[4];
            listcol[0] = Data.cSEQ;
            listcol[1] = Data.cTestDate;
            listcol[2] = Data.cStrip;
            listcol[3] = Data.cPatientID;
        }

        private void FrmSizeSet()
        {
            label4.Left = 223;
            label4.Top = 250;
            label4.Width = 116;
            label4.Height = 25;
            label3.Left = 223;
            label3.Top = 217;
            label3.Width = 116;
            label3.Height = 25;
            label2.Left = 223;
            label2.Top = 183;
            label2.Width = 116;
            label2.Height = 25;
            label1.Left = 223;
            label1.Top = 148;
            label1.Width = 116;
            label1.Height = 25;
            lbl_Id.Left = 367;
            lbl_Id.Top = 148;
            lbl_Id.Width = 116;
            lbl_Id.Height = 25;
            DBGrid_test.Left = 208;
            DBGrid_test.Top = 391;
            DBGrid_test.Width = 285;
            DBGrid_test.Height = 466;
            Btn_Graph.Left = 1;
            Btn_Graph.Top = 199;
            Btn_Graph.Width = 169;
            Btn_Graph.Height = 38;
            Btn_list.Left = 1;
            Btn_list.Top = 252;
            Btn_list.Width = 169;
            Btn_list.Height = 38;
            label5.Left = 575;
            label5.Top = 164;
            label5.Width = 84;
            label5.Height = 27;
            label6.Left = 846;
            label6.Top = 164;
            label6.Width = 84;
            label6.Height = 27;
            label7.Left = 846;
            label7.Top = 196;
            label7.Width = 84;
            label7.Height = 27;
            lbl_seq.Left = 676;
            lbl_seq.Top = 164;
            lbl_seq.Width = 130;
            lbl_seq.Height = 27;
            label8.Left = 586;
            label8.Top = 235;
            label8.Width = 84;
            label8.Height = 27;
            label9.Left = 586;
            label9.Top = 265;
            label9.Width = 84;
            label9.Height = 27;
            label10.Left = 850;
            label10.Top = 236;
            label10.Width = 84;
            label10.Height = 27;
            label11.Left = 850;
            label11.Top = 265;
            label11.Width = 84;
            label11.Height = 27;
            lbl_tdate.Left = 676;
            lbl_tdate.Top = 235;
            lbl_tdate.Width = 130;
            lbl_tdate.Height = 27;
            lbl_ttime.Left = 953;
            lbl_ttime.Top = 235;
            lbl_ttime.Width = 130;
            lbl_ttime.Height = 27;
            lbl_ttype.Left = 676;
            lbl_ttype.Top = 266;
            lbl_ttype.Width = 130;
            lbl_ttype.Height = 27;
            lbl_oper.Left = 953;
            lbl_oper.Top = 266;
            lbl_oper.Width = 130;
            lbl_oper.Height = 27;
            spr_result.Left = 531;
            spr_result.Top = 303;
            spr_result.Width = 597;
            spr_result.Height = 557;
            cb_color.Left = 953;
            cb_color.Top = 164;
            cb_color.Width = 130;
            cb_color.Height = 27;
            cb_trub.Left = 953;
            cb_trub.Top = 196;
            cb_trub.Width = 130;
            cb_trub.Height = 27;
            data_test.Left = 565;
            data_test.Top = 27;
            data_test.Width = 552;
            data_test.Height = 79;
            statusStrip1.Left = 0;
            statusStrip1.Top = 919;
            statusStrip1.Width = 1151;
            statusStrip1.Height = 22;
            StatusBar1.Width = 250;
            StatusBar1.Height = 17;
            StatusBar2.Width = 250;
            StatusBar2.Height = 17;
            Btn_result.Left = 1;
            Btn_result.Top = 146;
            Btn_result.Width = 169;
            Btn_result.Height = 38;
            panel_Graph.Left = 531;
            panel_Graph.Top = 303;
            panel_Graph.Width = 597;
            panel_Graph.Height = 557;
            Btn_View.Left = 484;
            Btn_View.Top = 4;
            Btn_View.Width = 65;
            Btn_View.Height = 27;
            CB_item.Left = 350;
            CB_item.Top = 9;
            CB_item.Width = 121;
            CB_item.Height = 23;
            RBtn_item.Left = 280;
            RBtn_item.Top = 6;
            RBtn_item.Width = 54;
            RBtn_item.Height = 23;
            RBtn_test.Left = 100;
            RBtn_test.Top = 6;
            RBtn_test.Width = 52;
            RBtn_test.Height = 23;
            chartControl.Left = 0;
            chartControl.Top = 35;
            chartControl.Width = 597;
            chartControl.Height = 519;
            txt_name.Left = 367;
            txt_name.Top = 183;
            txt_name.Width = 116;
            txt_name.Height = 27;
            DT_bth.Left = 367;
            DT_bth.Top = 217;
            DT_bth.Width = 116;
            DT_bth.Height = 27;
            cb_sex.Left = 367;
            cb_sex.Top = 250;
            cb_sex.Width = 116;
            cb_sex.Height = 27;
            lbl_lotno.Left = 953;
            lbl_lotno.Top = 164;
            lbl_lotno.Width = 130;
            lbl_lotno.Height = 27;
            lbl_sol.Left = 953;
            lbl_sol.Top = 196;
            lbl_sol.Width = 130;
            lbl_sol.Height = 27;
            panel_QC.Left = 697;
            panel_QC.Top = 112;
            panel_QC.Width = 148;
            panel_QC.Height = 36;
            panel_GE.Left = 534;
            panel_GE.Top = 112;
            panel_GE.Width = 148;
            panel_GE.Height = 36;
            spr_List.Left = 208;
            spr_List.Top = 143;
            spr_List.Width = 920;
            spr_List.Height = 717;
            Btn_Psave.Left = 221;
            Btn_Psave.Top = 289;
            Btn_Psave.Width = 118;
            Btn_Psave.Height = 43;
            Btn_Search.Left = 208;
            Btn_Search.Top = 866;
            Btn_Search.Width = 118;
            Btn_Search.Height = 43;
            Btn_reset.Left = 332;
            Btn_reset.Top = 866;
            Btn_reset.Width = 118;
            Btn_reset.Height = 43;
            Btn_set.Left = 1009;
            Btn_set.Top = 866;
            Btn_set.Width = 118;
            Btn_set.Height = 43;
            Btn_print.Left = 655;
            Btn_print.Top = 866;
            Btn_print.Width = 118;
            Btn_print.Height = 43;
            Btn_save.Left = 531;
            Btn_save.Top = 866;
            Btn_save.Width = 118;
            Btn_save.Height = 43;
            this.Width = 1167;
            this.Height = 980;

        }

        private void InitializeData()
        {
            ViewResultDataTable = ResultDataTableMake();
            ViewListDataTable = ViewListDataTableMake();
            PatientDataTable = Data.Patient;
            ResultDataTable = Data.Result;
            ResultGridDataTable = DBtableLoad();
            DBGridSet(ResultGridDataTable);
            QCResultDataTable = Data.QCResult;
            ViewQCResultDataTable = ResultDataTableMake();
            QCGridDataTable = QCDBtableLoad();
            GraphResultDataTable = Data.Result;
            //            GraphItemDataTable = Data.Result;
            GraphItemDataTable = GraphItemDataTableMake();
            GraphItemGridDataTable = ResultDataTable.DefaultView.ToTable(false, new string[] { "SEQ", "TestDate", "Strip" });
        }
        private DataTable GraphItemDataTableMake()
        {
            DataTable dt = new DataTable();

            DataColumn SEQ = new DataColumn("SEQ", typeof(Int32));
            DataColumn TestDate = new DataColumn("TestDate", typeof(string));
            DataColumn Value = new DataColumn("Value", typeof(string));
            DataColumn Result = new DataColumn("Result", typeof(string));
            dt.Columns.Add(SEQ);
            dt.Columns.Add(TestDate);
            dt.Columns.Add(Value);
            dt.Columns.Add(Result);
            return dt;
        }
        private void Frm_Result_Load(object sender, EventArgs e)
        {
            //220408 START
            FrmSizeSet();
            InitializeData();
            panel = new Panel();
            Top_set();
            //220408 END
            //Frm_Main.frmSetting.Unit = 1;
            GetPrt(Data.Get_Unit);
            PadColorSet();
            Setcol();
            cb_sex.Items.Add(Data.cMale);
            cb_sex.Items.Add(Data.cFemale);
            cb_color.Items.AddRange(arraycolor);
            cb_trub.Items.AddRange(arrayturb);
            InitDisplay();
            initSpread();
            InitResultDisplay();
            DBGridSet(ResultGridDataTable);
            this.Text = Data.aUrineAnalyzer;

            DataRow[] dr = Data.Table.Select();
            for (int i = 0; i < dr.Length; i++)
            {
                CB_item.Items.Add(dr[i][2]);
            }

        }

        public void Status()
        {
            StatusBar1.Text = Data.StatusData;
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke(new Action(delegate ()
                {
                    if (Data.StatusData == Data.iReceivingData) StatusBar1.BackColor = Data.PinkColor;
                    else StatusBar1.BackColor = SystemColors.Control;
                }));
            }

        }

        private void InitDisplay()
        {
            Btn_save.BackgroundImage = ImageLoad.btnSaveBack;
            Btn_print.BackgroundImage = ImageLoad.btnPrintBack;
            Btn_Psave.BackgroundImage = ImageLoad.btndisSaveBack;
            Btn_Search.BackgroundImage = ImageLoad.btnSearchBack;
            Btn_reset.BackgroundImage = ImageLoad.btnResetBack;
            Btn_set.BackgroundImage = ImageLoad.btnSettingBack;
            //220412 START
            panel_GE.Parent = panel;
            panel_GE.BackColor = Color.Transparent;

            panel_QC.Parent = panel;
            panel_QC.BackColor = Color.Transparent;

            //220412 END
            //            panel_Graph.Hide();
            //            spr_List.Hide();
            Btn_result.Text = Data.cResult;
            Btn_Graph.Text = Data.cGraph;
            Btn_list.Text = Data.cList;
            label1.Text = Data.cPatientID;
            label2.Text = Data.cName;
            label3.Text = Data.cBirthday;
            label4.Text = Data.cSex;
            label5.Text = Data.cSEQ;
            if (QCMode)
            {
                label6.Text = Data.cLotNo;
                label7.Text = Data.cSolution;
            }
            else
            {
                label6.Text = Data.cColor;
                label7.Text = Data.cturbidity;
            }
            label8.Text = Data.cTestDate;
            label9.Text = Data.cStrip;
            label10.Text = Data.cTestTime;
            label11.Text = Data.cOperator;
            RBtn_test.Text = Data.cTest;
            RBtn_item.Text = Data.cItem;
            Btn_View.Text = Data.cView;

            lbl_Id.Text = "";
            lbl_Id.BackColor = Color.White;
            txt_name.Text = "";
            txt_name.Enabled = false;
            cb_sex.SelectedIndex = 0;
            cb_sex.Enabled = false;
            DT_bth.Value = DateTime.Now;
            DT_bth.Enabled = false;
            Btn_Psave.Enabled = false;
            cb_color.SelectedIndex = 0;
            cb_trub.SelectedIndex = 0;
            lbl_seq.Text = "";
            lbl_tdate.Text = "";
            lbl_ttime.Text = "";
            lbl_ttype.Text = "";
            lbl_oper.Text = "";
            lbl_lotno.Text = "";
            lbl_sol.Text = "";
            if (Btn_list.BackColor == Data.SysColor) Btn_set.Visible = true;
            else Btn_set.Visible = false;


            StatusBar1.Text = Data.StatusData;
            //            Btn_result.BackColor = Color.FromArgb(154, 179, 198);
            //            Btn_result.Enabled = false;
            UserID = DataConn.LoginID;
            StatusBar2.Text = $"{Data.iUserID} : " + UserID;
        }

        public void ReadResult()
        {
            for (UInt16 j = 0; j < Data.datas.Count; j++)
            {
                try
                {
                    string cmd = Data.QueueData.Remove(0, 2);
                    //string cmd = SerialConnect.QueueData.Remove(0, 2);
                    int seq = Int32.Parse(cmd.Substring(0, 4));
                    seq_ = seq;
                    int itemCnt = Int32.Parse(cmd.Substring(58, 1), System.Globalization.NumberStyles.HexNumber);
                    DateTime datetime = new DateTime(Int32.Parse(cmd.Substring(4, 4)), Int16.Parse(cmd.Substring(8, 2)), Int16.Parse(cmd.Substring(10, 2)), Int16.Parse(cmd.Substring(12, 2)), Int16.Parse(cmd.Substring(14, 2)), Int16.Parse(cmd.Substring(16, 2)));
                    string operatorID = cmd.Substring(18, 10);
                    string lotno = cmd.Substring(28, 8).Replace(" ", "");
                    string patientID = cmd.Substring(28, 18).Replace(" ", "");
                    string testType = cmd.Substring(46, 2);
                    string strip = cmd.Substring(48, 10);
                    int color = Int32.Parse(cmd.Substring(256, 1));
                    int turbidity = Int32.Parse(cmd.Substring(257, 1));
                    int negPos = Int32.Parse(cmd.Substring(258, 1));
                    int[] listitem = new int[14];
                    int[] listvalue = new int[14];
                    int[] listintovalue = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                    int CreValue = -1, AlbValue = -1;
                    int ErrCode = Int32.Parse(cmd.Substring(255, 1));
                    string filterExpression;
                    for (int i = 0; i < 14; i++)
                    {
                        listitem[i] = Int32.Parse(cmd.Substring(59 + i, 1), System.Globalization.NumberStyles.HexNumber);
                        listvalue[i] = Int32.Parse(cmd.Substring(73 + i, 1), System.Globalization.NumberStyles.HexNumber);
                        if (listitem[i] == 12) AlbValue = listvalue[i];
                        else if (listitem[i] == 13) CreValue = listvalue[i];
                        if (listitem[i] > 0) listintovalue[listitem[i] - 1] = listvalue[i];
                    }
                    if (AlbValue >= 0 && CreValue >= 0) listintovalue[13] = alb_item[CreValue, AlbValue];

                    if (seq <= 5000)
                    {
                        //QCMode = false;
                        /*
                        panel.BackgroundImage = ImageLoad.resultBack;
                        DBGrid_test.Invoke(new Action(delegate ()
                        {
                            DBGridSet(ResultGridDataTable);
                        }));*/

                        filterExpression = $"seq = {seq} and TestDate = '{datetime}'";
                        DataRow[] row = Data.Result.Select(filterExpression);
                        //                                                DataRow[] row2 = Data.ListResult.Select(filterExpression);
                        //                        DataRow[] row = Data.Result.Select();

                        DataRow[] row2 = Data.ListResult.Select(filterExpression);
                        Console.WriteLine($"{row.Length} : {filterExpression}");
                        Console.WriteLine($"{row2.Length} : {filterExpression}");
                        //                        Data.ResultRow = Data.Result.NewRow();
                        DataRow dr = Data.Result.NewRow();
                        //                        Data.ListResultRow = Data.ListResult.NewRow();
                        DataRow dr2 = Data.ListResult.NewRow();
                        if (row.Length > 0)
                        {
                            dr["uid"] = UserID;
                            dr["OperID"] = operatorID;
                            dr["PatientID"] = patientID;
                            dr["TestType"] = testType;
                            dr["Strip"] = strip;
                            dr["ItemCnt"] = itemCnt.ToString();
                            for (int i = 0; i < 14; i++)
                            {
                                dr[$"Item{i + 1}"] = listitem[i];
                            }

                            for (int i = 0; i < 14; i++)
                            {
                                dr[$"Value{i + 1}"] = listvalue[i];
                            }

                            dr["ErrCode"] = ErrCode;
                            dr["Color"] = color;
                            dr["Turb"] = turbidity;
                            dr["NegPos"] = negPos;
                            dr["ReceiveTime"] = DateTime.Now.ToString();
                            dr["TestDate"] = datetime;
                            dr["SEQ"] = seq;
                            //220406 START
                            //Data.Result.Rows.Remove(row[0]);
                            //DataConn.DeleteData(Data.Result, row[0]);
                            DataConn.DeleteData(Data.Result, row[0]);
                            DataConn.InsertData(Data.Result, dr);
                            //DataConn.InsertData(Data.Result, Data.ResultRow);
                            //220406 END
                            //                            Data.Result.Rows.Add(Data.ResultRow);
                            //////////////////////////////////////////////////////////////          Update Result End
                            if (row2.Length > 0) //220408
                            {
                                dr2["uid"] = UserID;
                                dr2["PatientID"] = patientID;
                                dr2["Strip"] = strip;
                                for (int i = 0; i < 15; i++)
                                {
                                    dr2[$"Item{i + 1}"] = listintovalue[i];
                                }
                                dr2["TestDate"] = datetime;
                                dr2["SEQ"] = seq;
                                DataConn.DeleteData(Data.ListResult, row2[0]);
                                DataConn.InsertData(Data.ListResult, dr2);

                                //                                DataConn.AddDataTable(Data.ListResult, Data.ListResultRow);
                            }
                            //////////////////////////////////////////////////////////////         Update ListResult End
                        }
                        else
                        {
                            dr["uid"] = UserID;
                            dr["OperID"] = operatorID;
                            dr["PatientID"] = patientID;
                            dr["TestType"] = testType;
                            dr["Strip"] = strip;
                            dr["ItemCnt"] = itemCnt.ToString();

                            for (int i = 0; i < 14; i++)
                            {
                                dr[$"Item{i + 1}"] = listitem[i];
                            }

                            for (int i = 0; i < 14; i++)
                            {
                                dr[$"Value{i + 1}"] = listvalue[i];
                            }

                            dr["ErrCode"] = ErrCode;
                            dr["Color"] = color;
                            dr["Turb"] = turbidity;
                            dr["NegPos"] = negPos;
                            dr["ReceiveTime"] = DateTime.Now.ToString();
                            dr["TestDate"] = datetime;
                            dr["SEQ"] = seq;

                            DataConn.InsertData(Data.Result, dr);
                            //Data.Result.Rows.Add(dr);//220404
                            //Console.WriteLine($"INSERT RESULT SEQ : {seq} TESTDATE : {datetime}");
                            //////////////////////////////////////////////////////////////         Insert Result End
                            if (ErrCode == 0)
                            {
                                dr2["uid"] = UserID;
                                dr2["PatientID"] = patientID;
                                dr2["Strip"] = strip;
                                for (int i = 0; i < 15; i++)
                                {
                                    dr2[$"Item{i + 1}"] = listintovalue[i];
                                }
                                dr2["TestDate"] = datetime;
                                dr2["SEQ"] = seq;
                                //DataConn.DeleteData(Data.ListResult, row2[0]);
                                DataConn.InsertData(Data.ListResult, dr2);
                                //Data.ListResult.Rows.Add(dr2);
                                //Console.WriteLine($"INSERT LIST SEQ : {seq} TESTDATE : {datetime}");
                                //////////////////////////////////////////////////////////////         Insert List Result End
                            }
                        }
                    }
                    else
                    {
                        //QCMode = true;
                        /*
                        panel.BackgroundImage = ImageLoad.qcResultBack;
                        DBGrid_test.Invoke(new Action(delegate ()
                        {
                            DBGridSet(QCGridDataTable);
                        }));*/
                        filterExpression = $"seq = {seq} and TestDate = '{datetime}'";
                        //DataRow[] row = Data.QCResult.Select(filterExpression);
                        DataRow[] row = QCResultDataTable.Select(filterExpression);
                        DataRow dr = QCResultDataTable.NewRow();
                        if (row.Length > 0)
                        {
                            dr["uid"] = UserID;
                            dr["OperID"] = operatorID;
                            dr["LotNo"] = lotno;
                            dr["TestType"] = testType;
                            dr["Strip"] = strip;
                            dr["ItemCnt"] = itemCnt.ToString();
                            for (int i = 0; i < 14; i++)
                            {
                                dr[$"Item{i + 1}"] = listitem[i];
                            }

                            for (int i = 0; i < 14; i++)
                            {
                                dr[$"Value{i + 1}"] = listvalue[i];
                            }
                            dr["ErrCode"] = ErrCode;
                            dr["Color"] = color;
                            dr["Turb"] = turbidity;
                            dr["NegPos"] = negPos;
                            dr["ReceiveTime"] = DateTime.Now.ToString();
                            dr["TestDate"] = datetime;
                            dr["SEQ"] = seq;
                            //Data.QCResult.Rows.Remove(row[0]);
                            //QCResultDataTable.Rows.Remove(row[0]);
                            //DataConn.UpdateData(seq, datetime.ToString(), Data.QCResult, Data.QCResultRow);
                            QCResultDataTable.TableName = Data.QCResult.TableName;
                            DataConn.DeleteData(QCResultDataTable, row[0]);
                            DataConn.InsertData(QCResultDataTable, dr); //220408
                            //                            Data.QCResult.Rows.Add(Data.QCResultRow);
                        }
                        else
                        {
                            dr["uid"] = UserID;
                            dr["OperID"] = operatorID;
                            dr["LotNo"] = lotno;
                            dr["TestType"] = testType;
                            dr["Strip"] = strip;
                            dr["ItemCnt"] = itemCnt.ToString();
                            for (int i = 0; i < 14; i++)
                            {
                                dr[$"Item{i + 1}"] = listitem[i];
                            }

                            for (int i = 0; i < 14; i++)
                            {
                                dr[$"Value{i + 1}"] = listvalue[i];
                            }
                            dr["ErrCode"] = ErrCode;
                            dr["Color"] = color;
                            dr["Turb"] = turbidity;
                            dr["NegPos"] = negPos;
                            dr["ReceiveTime"] = DateTime.Now.ToString();
                            dr["TestDate"] = datetime;
                            dr["SEQ"] = seq;
                            QCResultDataTable.TableName = Data.QCResult.TableName;
                            DataConn.InsertData(QCResultDataTable, dr);
                            //Data.QCResult.Rows.Add(dr);//220404
                        }
                    }
                    //                    DataRow[] row3 = Data.Result.Select(filterExpression);
                    //                    Console.WriteLine($"{row3.Length} : {filterExpression}");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            if (Data.DelayCnt == 0 && SearchMode == false)
            //if (SerialConnect.DelayCnt == 0 && SearchMode == false)
            {
                if (QCMode == true)
                {
                    QCGridDataTable = QCDBtableLoad();
                    //Data.QCResult = DataConn.GetDataTable("DB_QCResult");
                    QCResultDataTable = DataConn.GetDataTable("DB_QCResult");
                    ViewResultDataTableMake(ViewQCResultDataTable);
                    //                    DisplayDataOnSpreadSheet(ViewQCResultDataTable);
                }
                else
                {
                    //220415 Start
                    if (seq_ <= 5000)
                    {
                        ResultGridDataTable = DBtableLoad();
                        ViewResultDataTableMake(ViewResultDataTable);
                    }
                    else
                    {
                        QCGridDataTable = QCtable();
                        //QCResultDataTable = DataConn.GetDataTable("DB_QCResult");
                    }
                    //220415 End
                    //                    DisplayDataOnSpreadSheet(ViewResultDataTable);
                }
            }
        }
        //220407 START
        private void btn_save_Click(object sender, EventArgs e)
        {
            string insert_query;
            int seq = Convert.ToInt32(lbl_seq.Text);
            string testdate = Convert.ToString(DBGrid_test.Rows[DBGrid_test.CurrentCell.RowIndex].Cells[2].Value);
            string sql = $" SELECT * FROM DB_Result WHERE seq = {seq} AND TestDate = '{testdate}'";


            // sql = @" SELECT * FROM DB_Result WHERE seq = " + seq + "AND StrComp(UID,'" + UserID + "',0)=0";
            if (DataConn.DataCheck(sql))
            {
                insert_query = "UPDATE DB_Result SET ";
                //insert_query += "Color = " + cb_color.SelectedIndex + ", Turb = " + cb_trub.SelectedIndex + " WHERE StrComp(UID,'" + UserID + "',0)=0 AND seq = " + seq;
                insert_query += $"Color = {cb_color.SelectedIndex}, Turb = {cb_trub.SelectedIndex} WHERE seq = {seq} AND TestDate = '{testdate}'";
                DataConn.Getdata(insert_query);
                Data.Result = DataConn.GetDataTable("DB_Result");
                //Console.WriteLine(insert_query);
                try
                {
                    DBtableLoad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (SearchMode)
                {
                    SearchMode = false;
                    Btn_Search.BackgroundImage = ImageLoad.btnSearchBack;
                }
            }
        }
        //220407 END
        public DataTable DBtableLoad()
        {
            string sql = "DB_Result";
            if (DataConn.LoginID == "Admin")
            {
                sql += $" WHERE ReceiveTime LIKE '{DateTime.Now.ToShortDateString()}%'";
            }
            else
            {
                sql += $" WHERE UID='{DataConn.LoginID}' and ReceiveTime LIKE '{DateTime.Now.ToShortDateString()}%'";
            }

            DataTable dt = DataConn.GetDataTable(sql);
            Console.WriteLine($"sql:{sql}");
            Console.WriteLine($"DBtableLoad Cnt:{dt.Rows.Count}");
            DataTable dt2 = dt.DefaultView.ToTable(false, new string[] { "PatientID", "SEQ", "TestDate" });

            DBGrid_test.Invoke(new Action(delegate ()
            {
                DBGridSet(dt2);
            }));
            return dt2;
        }
        public DataTable QCDBtableLoad()
        {
            string sql = "DB_QCResult";
            if (DataConn.LoginID == "Admin")
            {
                sql += $" WHERE ReceiveTime LIKE '{DateTime.Now.ToShortDateString()}%'";
            }
            else
            {
                sql += $" WHERE UID='{DataConn.LoginID}' and ReceiveTime LIKE '{DateTime.Now.ToShortDateString()}%'";
            }

            DataTable dt = DataConn.GetDataTable(sql);
            Console.WriteLine($"sql:{sql}");
            Console.WriteLine($"QCDBtableLoad Cnt:{dt.Rows.Count}");
            DataTable dt2 = dt.DefaultView.ToTable(false, new string[] { "LotNo", "SEQ", "TestDate" });

            DBGrid_test.Invoke(new Action(delegate ()
            {
                DBGridSet(dt2);
            }));
            return dt2;
        }

        public DataTable QCtable()
        {
            string sql = "DB_QCResult";
            if (DataConn.LoginID == "Admin")
            {
                sql += $" WHERE ReceiveTime LIKE '{DateTime.Now.ToShortDateString()}%'";
            }
            else
            {
                sql += $" WHERE UID='{DataConn.LoginID}' and ReceiveTime LIKE '{DateTime.Now.ToShortDateString()}%'";
            }

            DataTable dt = DataConn.GetDataTable(sql);
            Console.WriteLine($"sql:{sql}");
            Console.WriteLine($"QCDBtableLoad Cnt:{dt.Rows.Count}");
            DataTable dt2 = dt.DefaultView.ToTable(false, new string[] { "LotNo", "SEQ", "TestDate" });

            return dt2;
        }

        private void DBGridSet(DataTable dt)
        {
            DBGrid_test.DataSource = dt;
            DBGrid_test.MultiSelect = false;
            DBGrid_test.AutoSize = false;
            DBGrid_test.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DBGrid_test.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DBGrid_test.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //DBGrid_test.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            DataGridViewColumn colseq = DBGrid_test.Columns["SEQ"];
            DataGridViewColumn coldate = DBGrid_test.Columns["TestDate"];
            colseq.FillWeight = 50;
            coldate.FillWeight = 175;
            DBGrid_test.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DBGrid_test.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DBGrid_test.ReadOnly = true;
            DBGrid_test.AllowUserToAddRows = false;
            dt.DefaultView.Sort = "SEQ DESC";
            dt = dt.DefaultView.ToTable(true);

            if (QCMode)
            {
                DBGrid_test.Columns[0].HeaderText = Data.cLotNo;
                DBGrid_test.Columns[1].HeaderText = Data.cSEQ;
                DBGrid_test.Columns[2].HeaderText = Data.cTestDate;
            }
            else
            {
                DBGrid_test.Columns[0].HeaderText = Data.cPatientID;
                DBGrid_test.Columns[1].HeaderText = Data.cSEQ;
                DBGrid_test.Columns[2].HeaderText = Data.cTestDate;
            }

            DBGrid_test.Update();
            DBGrid_test.Refresh();
        }


        public void GetPrt(int unit)
        {
            string uunit = "";

            if (Data.PrintForm.Rows.Count == 0) Data.PrintForm = DataConn.GetDataTable("DB_PrintForm"); //220413

            switch (unit)
            {
                case 0:
                    uunit = "Arb";
                    break;
                case 1:
                    uunit = "Conv";
                    break;
                case 2:
                    uunit = "Si";
                    break;
            }

            string filterExpression = $"Unit = '{uunit}'";
            DataRow[] dr = Data.PrintForm.Select(filterExpression);
            for (int i = 0; i < 20; i++)
            {
                Array_prt[i, 0] = i.ToString();
                Array_prt[i, 1] = dr[i]["Item"].ToString();
                Array_prt[i, 2] = dr[i]["Units"].ToString();
                if (Array_prt[i, 2] != "        ") Array_prt[i, 2] = Array_prt[i, 2].Trim();
                string str = "";
                for (int j = 3; j < 12; j++)
                {
                    Array_prt[i, j] = dr[i][$"Grade{j - 2}"].ToString();
                    str += Array_prt[i, j];
                    if (Array_prt[i, j] != "        ") Array_prt[i, j].Trim();
                }
            }
        }
        public void initSpread()
        {
            spr_result.BeginUpdate();
            resultSheet = spr_result.Document.Worksheets[0];
            CellRange cellrange = resultSheet.Range.FromLTRB(0, 1, 11, 20);
            DevExpress.Spreadsheet.Formatting rangeFormatting = cellrange.BeginUpdateFormatting();
            cellrange.SetValue("");
            resultSheet.ClearFormats(cellrange);
            spr_result.Options.Behavior.ShowPopupMenu = DevExpress.XtraSpreadsheet.DocumentCapability.Hidden;
            resultSheet.ActiveView.ShowHeadings = false;
            resultSheet.ActiveView.Zoom = 90;
            cellrange.RowHeight = 100;
            cellrange.ColumnWidth = 200;
            cellrange.Font.Name = "Times New Roman";
            cellrange.SetValue("");
            //            resultSheet.GetUsedRange().AutoFitColumns();
            //            resultSheet.GetUsedRange().AutoFitRows();

            spr_result.WorksheetDisplayArea.SetSize(resultSheet.Index, cellrange.ColumnCount, cellrange.RowCount);
            for (int i = 0; i < ViewResultDataTable.Columns.Count - 1; i++)
            {
                cell = resultSheet.Rows[0][i];
                SetCellStyle(cell, true, 12, Color.LightGray);
                cell.SetValue(resultcol[i]);
                cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                cell.Font.Name = "Times New Roman";
            }
            cellrange.EndUpdateFormatting(rangeFormatting);
            spr_result.EndUpdate();
        }

        public void DisplayDataOnSpreadSheet(DataTable rdt)
        {
            if (spr_result.InvokeRequired)
            {
                spr_result.Invoke(new Action(delegate ()
                {
                    object sender = null;
                    DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(0, 0);
                    DBGrid_test_CellClick(sender, e);
                }));
            }
            else
            {
                initSpread();
                spr_result.BeginUpdate();
                resultSheet = this.spr_result.Document.Worksheets[0];
                CellRange cellrange = resultSheet.Range.FromLTRB(0, 1, 11, 15);
                resultSheet.ClearFormats(cellrange);
                resultSheet.Clear(cellrange);
                cellrange.UnMerge();
                cellrange.RowHeight = 100;
                cellrange.ColumnWidth = 200;
                cellrange.Font.Name = "Times New Roman";

                for (int i = 0; i < rdt.Rows.Count; i++)
                {
                    for (int j = 0; j < rdt.Columns.Count - 1; j++)
                    {
                        //Console.WriteLine($"Row:{i} Col:{j}");
                        cell = resultSheet.Rows[i + 1][j];
                        cell.SetValue(rdt.Rows[i][j]);
                        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;

                        if (!Array.Exists(exceptionalItem, x => x == rdt.Rows[i][0].ToString()))
                        {
                            if (item[2, i] == 0)
                            {

                                resultSheet.Rows[i + 1][0].FillColor = Data.Get_Neg_back;
                                resultSheet.Rows[i + 1][1].FillColor = Data.Get_Neg_back;
                                resultSheet.Rows[i + 1][0].Font.Color = Data.Get_Neg_fore;
                                resultSheet.Rows[i + 1][1].Font.Color = Data.Get_Neg_fore;
                            }
                            else
                            {
                                resultSheet.Rows[i + 1][0].FillColor = Data.Get_Pos_back;
                                resultSheet.Rows[i + 1][1].FillColor = Data.Get_Pos_back;
                                resultSheet.Rows[i + 1][0].Font.Color = Data.Get_Pos_fore;
                                resultSheet.Rows[i + 1][1].Font.Color = Data.Get_Pos_fore;
                            }
                        }
                        if ((j == 0 || j == 1) && rdt.Rows[i][0].ToString() != "")
                        {
                            cell.Borders.SetAllBorders(Color.Black, DevExpress.Spreadsheet.BorderLineStyle.Thin);
                        }

                        if (j == item[2, i] + 3 && rdt.Rows[i][0].ToString() != "A:C" && rdt.Rows[i][0].ToString() != "")
                        {
                            cell.Borders.SetAllBorders(Color.Black, DevExpress.Spreadsheet.BorderLineStyle.Medium);
                        }
                        if (rdt.Rows[i][j].ToString().Length > 8)
                        {
                            resultSheet.MergeCells(resultSheet.Range.FromLTRB(j, i + 1, j + 1, i + 1));
                            if (rdt.Rows[i][0].ToString() != "")
                            {
                                //resultSheet.Range.FromLTRB(j, i + 1, j + 1, i + 1).Borders.SetAllBorders(Color.Black, DevExpress.Spreadsheet.BorderLineStyle.Thin);
                                //resultSheet.Rows[i + 1][1].Borders.SetAllBorders(Color.Black, DevExpress.Spreadsheet.BorderLineStyle.Thin);
                                //resultSheet.Rows[i + 1][2].Borders.SetAllBorders(Color.Black, DevExpress.Spreadsheet.BorderLineStyle.Thin);

                            }
                        }

                        int itemno = item[1, i];
                        int itemV = item[2, i];

                        if (j > 2 && rdt.Rows[i][0].ToString() != "A:C" && rdt.Rows[i][0].ToString() != "")
                        {
                            if (PadColor[itemno, j - 3, 0] == 0 && PadColor[itemno, j - 3, 1] == 0 && PadColor[itemno, j - 3, 0] == 0) cell.ClearFormats();
                            else cell.FillColor = Color.FromArgb(PadColor[itemno, j - 3, 0], PadColor[itemno, j - 3, 1], PadColor[itemno, j - 3, 2]);
                            if (PadColor[itemno, j - 3, 0] < 125 && PadColor[itemno, j - 3, 1] < 125 && PadColor[itemno, j - 3, 0] < 125) cell.Font.Color = Color.White;

                        }
                        else if (j == 1 && rdt.Rows[i][0].ToString() == "")
                        {
                            string a = "";
                            a = rdt.Rows[i][j].ToString().Remove(0, 1);

                            if (a != "") cell.SetValue(a);
                        }
                    }
                }
                spr_result.EndUpdate();
            }
        }

        public void SetCellStyle(Cell cell, bool isBold, int fontSize, Color fillColor)
        {
            cell.Font.Bold = isBold;
            cell.Font.Size = fontSize;
            cell.FillColor = fillColor;
            //cell.Font.FontStyle = new Font("Times New Roman");
            cell.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
        }

        public DataTable ResultDataTableMake()
        {
            DataTable rdt = new DataTable();
            DataColumn ItemName = new DataColumn("Item", typeof(string));
            DataColumn Result = new DataColumn("Result", typeof(string));
            DataColumn Unit = new DataColumn("Unit", typeof(string));
            DataColumn Grade1 = new DataColumn("Grade1", typeof(string));
            DataColumn Grade2 = new DataColumn("Grade2", typeof(string));
            DataColumn Grade3 = new DataColumn("Grade3", typeof(string));
            DataColumn Grade4 = new DataColumn("Grade4", typeof(string));
            DataColumn Grade5 = new DataColumn("Grade5", typeof(string));
            DataColumn Grade6 = new DataColumn("Grade6", typeof(string));
            DataColumn Grade7 = new DataColumn("Grade7", typeof(string));
            DataColumn Grade8 = new DataColumn("Grade8", typeof(string));
            DataColumn Grade9 = new DataColumn("Grade9", typeof(string));
            DataColumn Arb = new DataColumn("Arb", typeof(string));

            rdt.Columns.Add(ItemName);
            rdt.Columns.Add(Result);
            rdt.Columns.Add(Unit);
            rdt.Columns.Add(Grade1);
            rdt.Columns.Add(Grade2);
            rdt.Columns.Add(Grade3);
            rdt.Columns.Add(Grade4);
            rdt.Columns.Add(Grade5);
            rdt.Columns.Add(Grade6);
            rdt.Columns.Add(Grade7);
            rdt.Columns.Add(Grade8);
            rdt.Columns.Add(Grade9);
            rdt.Columns.Add(Arb);
            return rdt;
        }
        public void ViewResultDataTableMake(DataTable dt)
        {
            dt.Rows.Clear();
            DataRow dr;
            int item_cnt = item[0, 0];
            string[] item_name = new string[14];
            string[] item_Grade = new string[14];
            int Ls_Pro = 0, Ls_Alb = 0, Ls_Cre = 0, Ls_AC = 0, Ls_PC = 0, Ls_CC = 0;

            //            Console.WriteLine("ItemCnt:"+item[0, 0]);
            for (int i = 0; i < item_cnt; i++)
            {
                dr = dt.NewRow();
                int item_no = item[1, i];
                item_name[i] = Array_prt[item_no, 1];
                int item_g = item[2, i];
                dr["Arb"] = item_g;
                item_Grade[i] = Array_prt[item_no, item_g + 3];
                dr["Item"] = item_name[i].Trim();
                dr["Result"] = item_Grade[i].Trim();
                dr["Unit"] = Array_prt[item_no, 2].Trim();
                for (int j = 1; j <= 9; j++)
                {
                    dr["grade" + j] = Array_prt[item_no, j + 2].Trim();
                }

                if (item_no == 7) Ls_Pro = item_g;
                else if (item_no == 11) Ls_Alb = item_g;
                else if (item_no == 12) Ls_Cre = item_g;

                if (item_no == 12 || item_no == 11) ++Ls_AC;
                if (item_no == 12 || item_no == 7) ++Ls_PC;
                if (item_no == 12 || item_no == 15) ++Ls_CC;
                /*                Console.WriteLine(dr["Arb"].ToString());
                                Console.WriteLine(dr["Item"].ToString());
                                Console.WriteLine(dr["Result"].ToString());
                                Console.WriteLine(dr["Unit"].ToString());
                                for (int j = 1; j < 9; j++)
                                {
                                    Console.WriteLine(dr["grade" + j].ToString());
                                }*/
                dt.Rows.Add(dr);
                //DataConn.AddDataTable(dt, dr);
                //                Console.WriteLine(dt.Rows.Count);
            }

            if (Ls_AC == 2 || Ls_PC == 2)
            {
                dr = dt.NewRow();
                if (Ls_AC == 2)
                {
                    dr["Item"] = "A:C";
                    int datAC = alb_item[Ls_Cre, Ls_Alb];
                    if (Data.Get_Unit == 2)
                    {
                        dr["Result"] = alb_tb_text_si[Ls_Cre, Ls_Alb + 1];
                        dr["Unit"] = alb_tb_text_si[Ls_Cre, 0];
                    }
                    else
                    {
                        dr["Result"] = alb_tb_text[Ls_Cre, Ls_Alb + 1];
                        dr["Unit"] = alb_tb_text[Ls_Cre, 0];
                    }
                    for (int j = 2; j < 9; j++)
                    {
                        dr["grade" + j] = null;
                    }
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["Item"] = null;
                    dr["Result"] = datAC + albumin_tb[datAC];
                    for (int j = 2; j < 9; j++)
                    {
                        dr["grade" + j] = null;
                    }
                    dt.Rows.Add(dr);
                }
                else if (Ls_PC == 2)
                {
                    dr["Item"] = "P:C";
                    int datPC = pro_item[Ls_Pro, Ls_Cre];
                    dr["Unit"] = albumin_tb[datPC];
                    for (int j = 2; j < 9; j++)
                    {
                        dr["grade" + j] = null;
                    }
                    dt.Rows.Add(dr);

                }

                Console.WriteLine(dt.Rows.Count);
            }
            //            Console.WriteLine($"Row : {dt.Rows.Count} Col : {dt.Columns.Count}");
            DisplayDataOnSpreadSheet(dt);
        }

        private void DBGrid_test_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string filterExpression;// sortOrder;
            //            if (!RBtn_item.Checked)//220406 Start
            if (Frm_Main.frmSearch.Resultmode != 1)//220406 End
            {
                if (DBGrid_test.Rows.Count > e.RowIndex && e.RowIndex >= 0)
                {
                    lbl_Id.BackColor = Color.White;
                    txt_name.Text = "";
                    txt_name.Enabled = false;
                    DT_bth.Value = DateTime.Now;
                    DT_bth.Enabled = false;
                    cb_sex.Enabled = false;
                    cb_sex.Text = "";

                    string seq = DBGrid_test.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    string PID = DBGrid_test.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    string testDate = DBGrid_test.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();//220404
                    if (!QCMode)
                    {
                        filterExpression = $"PatientID = '{PID}'";
                        DataRow[] patientdr = Data.Patient.Select(filterExpression);
                        if (patientdr.Length > 0)
                        {
                            txt_name.Text = Convert.ToString(patientdr[0][1]);
                            string date2 = Convert.ToString(patientdr[0][2]);
                            DT_bth.Value = Convert.ToDateTime(date2);
                            cb_sex.SelectedItem = Convert.ToString(patientdr[0][3]);
                            Btn_Psave.BackgroundImage = ImageLoad.btndisSaveBack;
                            Btn_Psave.Enabled = false;
                        }
                        else
                        {
                            lbl_Id.BackColor = Color.LightPink;
                            txt_name.Enabled = true;
                            DT_bth.Enabled = true;
                            cb_sex.Enabled = true;
                            Btn_Psave.BackgroundImage = ImageLoad.btnSaveBack;
                            Btn_Psave.Enabled = true;
                        }
                        filterExpression = $"PatientID = '{PID}' AND TestDate = '{testDate}'";//220404
                        ResultDataRow = Data.Result.Select(filterExpression);//220404
                        if (ResultDataRow.Length > 0)
                        {
                            lbl_Id.Text = PID;
                            lbl_seq.Text = Convert.ToString(ResultDataRow[0]["SEQ"]);
                            lbl_oper.Text = Convert.ToString(ResultDataRow[0][3]);
                            lbl_ttype.Text = Convert.ToString(ResultDataRow[0][6]);
                            lbl_ttype.ForeColor = Color.Black;
                            item[0, 0] = Convert.ToInt32(ResultDataRow[0][7]);
                            error = Convert.ToInt32(ResultDataRow[0][36]);
                            lbl_ttime.Text = "";
                            string[] date = Convert.ToString(ResultDataRow[0]["TestDate"]).Split(' ');
                            foreach (var datesplit in date.Select((value, index) => new { value, index }))
                            {
                                var value = datesplit.value;
                                var index = datesplit.index;

                                if (index == 0) lbl_tdate.Text = datesplit.value;
                                else lbl_ttime.Text += datesplit.value;
                            }

                            if (error == 0)
                            {
                                for (int i = 8, j = 0; i < 22; i++, j++)
                                {
                                    item[1, j] = Convert.ToInt32(ResultDataRow[0][i]) - 1;
                                    if (item[1, j] < 0) item[1, j] = 0;
                                }


                                for (int i = 22, j = 0; i < 36; i++, j++)
                                {
                                    item[2, j] = Convert.ToInt32(ResultDataRow[0][i]);
                                }
                            }
                            else
                            {
                                item[0, 0] = 0;
                                lbl_ttype.Text = Data.cNostrip;
                                lbl_ttype.ForeColor = Color.Red;
                            }

                            cb_color.SelectedIndex = Convert.ToInt32(ResultDataRow[0][37]);
                            cb_trub.SelectedIndex = Convert.ToInt32(ResultDataRow[0][38]);

                            ViewResultDataTableMake(ViewResultDataTable);
                        }
                    }
                    else
                    {
                        filterExpression = $"SEQ={seq} AND TestDate = '{testDate}'";//220404
                        QCResultDataRow = QCResultDataTable.Select(filterExpression);//220404
                        if (QCResultDataRow.Length > 0)
                        {
                            lbl_lotno.Text = PID;
                            if (Convert.ToInt32(QCResultDataRow[0]["NegPos"]) == 0) lbl_sol.Text = Data.cNegative;
                            else lbl_sol.Text = Data.cPositive;

                            lbl_seq.Text = Convert.ToString(QCResultDataRow[0]["SEQ"]);
                            lbl_oper.Text = Convert.ToString(QCResultDataRow[0][3]);
                            lbl_ttype.Text = Convert.ToString(QCResultDataRow[0][6]);
                            lbl_ttype.ForeColor = Color.Black;
                            item[0, 0] = Convert.ToInt32(QCResultDataRow[0][7]);
                            error = Convert.ToInt32(QCResultDataRow[0][36]);
                            lbl_ttime.Text = "";
                            string[] date = Convert.ToString(QCResultDataRow[0]["TestDate"]).Split(' ');
                            foreach (var datesplit in date.Select((value, index) => new { value, index }))
                            {
                                var value = datesplit.value;
                                var index = datesplit.index;

                                if (index == 0) lbl_tdate.Text = datesplit.value;
                                else lbl_ttime.Text += datesplit.value;
                            }

                            if (error == 0)
                            {
                                for (int i = 8, j = 0; i < 22; i++, j++)
                                {
                                    item[1, j] = Convert.ToInt32(QCResultDataRow[0][i]) - 1;
                                    if (item[1, j] < 0) item[1, j] = 0;
                                }


                                for (int i = 22, j = 0; i < 36; i++, j++)
                                {
                                    item[2, j] = Convert.ToInt32(QCResultDataRow[0][i]);
                                }
                            }
                            else
                            {
                                item[0, 0] = 0;
                                lbl_ttype.Text = Data.cNostrip;
                                lbl_ttype.ForeColor = Color.Red;
                            }

                            cb_color.SelectedIndex = Convert.ToInt32(QCResultDataRow[0][37]);
                            cb_trub.SelectedIndex = Convert.ToInt32(QCResultDataRow[0][38]);

                            ViewResultDataTableMake(ViewQCResultDataTable);
                        }
                    }
                }
            }

            //            DataTable rdt = new DataTable();
            //            rdt = DTCreat();
            if (!panel_Graph.Enabled)
            {
                if (!QCMode)
                {
                    DisplayDataOnSpreadSheet(ViewResultDataTable);
                }
                else
                {
                    DisplayDataOnSpreadSheet(ViewQCResultDataTable);
                }
            }
            else// if (!Btn_Graph.Enabled)
            {
                if (RBtn_test.Checked) Graph_Draw(ViewResultDataTable);
                else if (RBtn_item.Checked)
                {
                    Graph_Draw_Item(e.RowIndex);
                }
            }
        }

        private void DBGrid_test_KeyDown(object sender, KeyEventArgs e)
        {
            if (DBGrid_test.RowCount > 0)
            {
                int rowindex = DBGrid_test.CurrentCell.RowIndex;

                if (e.KeyCode == Keys.Down)
                {
                    if (rowindex != DBGrid_test.RowCount - 1) DBGrid_test_CellClick(sender, new DataGridViewCellEventArgs(0, rowindex + 1));
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (rowindex != 0) DBGrid_test_CellClick(sender, new DataGridViewCellEventArgs(0, rowindex - 1));
                }
            }
        }

        public void PadColorSet()
        {
            string filterexpression = "Dsp = 'CYBOW'";              //220414
            DataRow[] dr = Data.PadColor.Select(filterexpression);             //220414
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (dr[i * 8 + j][k + 2].ToString() != string.Empty) PadColor[i, j, k] = Convert.ToInt32(dr[i * 8 + j][k + 2]);
                    }
                }
            }
        }

        public void Graph_Draw(DataTable dt)
        {
            XYDiagram Diagram = chartControl.Diagram as XYDiagram;
            chartControl.Series.Clear();
            if (Diagram != null) Diagram.AxisX.CustomLabels.Clear();
            chartControl.Series.Add(new Series("BAR", ViewType.Bar));
            Diagram = (XYDiagram)chartControl.Diagram;
            chartControl.Series["BAR"].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            SideBySideBarSeriesView view = chartControl.Series["BAR"].View as SideBySideBarSeriesView;
            view.BarWidth = 0.4;
            Diagram.AxisX.NumericScaleOptions.GridSpacing = 1;
            Diagram.AxisX.Label.Font = new Font("Times New Roman", 10);
            Diagram.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            Diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
            Diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            //          Diagram.AxisX.Label.ResolveOverlappingOptions.MinIndent = 5;
            Diagram.AxisY.Label.Visible = false;
            Diagram.AxisY.VisualRange.MaxValue = 8;
            Diagram.AxisY.WholeRange.SetMinMaxValues(0, 9);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string item = "";
                int Value = 0;
                string Value2 = "";
                string ACR = "";

                if (dt.Rows[i]["Item"] != DBNull.Value)
                {
                    item = dt.Rows[i]["Item"].ToString();
                    if (item[1] != (char)0x3A)
                    {
                        if (dt.Rows[i]["Arb"] != DBNull.Value) Value = Convert.ToInt32(dt.Rows[i]["Arb"]) + 1;
                        if (dt.Rows[i]["Result"] != DBNull.Value) Value2 = dt.Rows[i]["Result"].ToString();
                    }
                    else
                    {
                        if (dt.Rows[i + 1]["Result"] != DBNull.Value) ACR = dt.Rows[i + 1]["Result"].ToString();
                        Value = Convert.ToInt32(ACR.Substring(0, 1));
                        if (dt.Rows[i]["Result"] != DBNull.Value) Value2 = dt.Rows[i]["Result"].ToString();
                        //if (Value == 4) Value = 1;
                    }
                    //Console.WriteLine($"item : {item} , value : {Value}, Value 2 : {Value2}");
                    chartControl.Series["BAR"].Points.Add(new SeriesPoint(item, Value) { Tag = new { test = Value2 } });

                    if (!Array.Exists(exceptionalItem, x => x == item))
                    {
                        if (Value == 1)
                        {
                            Diagram.AxisX.CustomLabels.Add(new CustomAxisLabel(name: item, value: item)
                            {
                                TextColor = Data.Get_Neg_fore
                            });
                            chartControl.Series[0].Points[i].Color = Data.Get_Neg_fore;
                        }
                        else
                        {
                            Diagram.AxisX.CustomLabels.Add(new CustomAxisLabel(name: item, value: item)
                            {
                                TextColor = Data.Get_Pos_fore
                            });
                            chartControl.Series[0].Points[i].Color = Data.Get_Pos_fore;
                        }
                    }
                    else
                    {
                        Diagram.AxisX.CustomLabels.Add(new CustomAxisLabel(name: item, value: item)); //220404
                        chartControl.Series[0].Points[i].Color = Data.Get_Neg_fore;
                    }
                    //                chartControl.Series["BAR"].ToolTipPointPattern = "{A}: {V} ({test})";
                    chartControl.Series["BAR"].Label.TextPattern = "{test}";
                    chartControl.Series["BAR"].CrosshairLabelPattern = "{A} : {test}";

                    //                ((RangeBarSeriesLabel)chartControl.Series["BAR"].Label).PointOptions.PointView = PointView.ArgumentAndValues;
                    //               if (dr["Result"] != DBNull.Value) ((RangeBarSeriesLabel)chartControl.Series["BAR"].Label).PointOptions.Pattern = dr["Result"].ToString();
                }
                else if (dt.Rows[i]["Item"].ToString() == "")
                {

                }
                //GraphChart = chartControl;
            }

            GraphChart = chartControl; //220404

        }

        public void Graph_Draw_Item(int cellindex)
        {
            XYDiagram Diagram = chartControl.Diagram as XYDiagram;
            chartControl.Series.Clear();
            if (Diagram != null) Diagram.AxisX.CustomLabels.Clear();
            chartControl.Series.Add(new Series("BAR", ViewType.Bar));
            Diagram = (XYDiagram)chartControl.Diagram;
            Diagram.AxisX.WholeRange.AutoSideMargins = false;
            chartControl.Series["BAR"].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            SideBySideBarSeriesView view = chartControl.Series["BAR"].View as SideBySideBarSeriesView;
            view.BarWidth = 0.4;
            if (cellindex != GraphItemDataTable.Rows.Count) cellindex = GraphItemDataTable.Rows.Count - cellindex;

            Diagram.AxisX.NumericScaleOptions.GridSpacing = 1;
            Diagram.AxisX.Label.Font = new Font("Times New Roman", 10);
            Diagram.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            Diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
            Diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            Diagram.AxisY.Label.Visible = false;
            Diagram.EnableAxisXScrolling = true;
            Diagram.DefaultPane.ScrollBarOptions.BarThickness = 10;
            Diagram.AxisY.WholeRange.SetMinMaxValues(0.5, 9);
            Diagram.AxisX.WholeRange.SideMarginsValue = 0.5;
            if (cellindex < 14) Diagram.AxisX.VisualRange.SetMinMaxValues(1, 14);
            else Diagram.AxisX.VisualRange.SetMinMaxValues(cellindex - 14, cellindex);

            int z = 0;
            int item = CB_item.SelectedIndex + 1;

            for (int i = 0; i < GraphItemDataTable.Rows.Count; i++)
            {
                DataRow dr = GraphItemDataTable.Rows[i];
                int seq_ = 0, value_ = 0;
                string TD = "", result_ = "";
                z++;

                if (dr["SEQ"] != DBNull.Value) seq_ = Convert.ToInt32(dr["SEQ"]);
                if (dr["TestDate"] != DBNull.Value) TD = dr["TestDate"].ToString();
                if (dr["Value"] != DBNull.Value) value_ = Convert.ToInt32(dr["Value"]) + 1;
                if (dr["Result"] != DBNull.Value) result_ = dr["Result"].ToString();

                chartControl.Series["BAR"].Points.Add(new SeriesPoint(z, value_) { Tag = new { result = result_, sseq = seq_ } });
                if (!Array.Exists(exceptionalItemindex, x => x == item))
                {
                    if (value_ == 1)
                    {
                        Diagram.AxisX.CustomLabels.Add(new CustomAxisLabel(name: seq_.ToString(), value: z)
                        {
                            TextColor = Data.Get_Neg_fore
                        });
                        chartControl.Series[0].Points[i].Color = Data.Get_Neg_fore;
                        //chartControl.Series["BAR"].Label.TextColor = Data.Get_Neg_fore;
                    }
                    else
                    {
                        Diagram.AxisX.CustomLabels.Add(new CustomAxisLabel(name: seq_.ToString(), value: z)
                        {
                            TextColor = Data.Get_Pos_fore
                        });
                        chartControl.Series[0].Points[i].Color = Data.Get_Pos_fore;
                        //chartControl.Series["BAR"].Label.TextColor = Data.Get_Pos_fore;
                    }
                }
                else
                {
                    Diagram.AxisX.CustomLabels.Add(new CustomAxisLabel(name: seq_.ToString(), value: z));
                    chartControl.Series[0].Points[i].Color = Data.Get_Neg_fore;
                }
                //                chartControl.Series["BAR"].ToolTipPointPattern = "{A}: {V} ({test})";
                chartControl.Series["BAR"].Label.TextPattern = "{result}";
                chartControl.Series["BAR"].CrosshairLabelPattern = "{sseq} : {result}";
            }
            //Diagram.AxisX.WholeRange.SetMinMaxValues(0, GraphItemDataTable.Rows.Count);

            GraphChart = chartControl;

        }


        public void Top_set()
        {

            int left = 30;
            int top = 10;
            int width = 73;
            int height = 73;
            Control[] Top_btn = new Control[5];


            for (int idx = 0; idx < 5; idx++)
            {
                Top_btn[idx] = new Button();
                Top_btn[idx].Name = "Top_btn [ " + idx.ToString() + " ] ";
                Top_btn[idx].Parent = this;
                // Top_btn[idx].Size = new Size(width, height);
                //Top_btn[idx].Margin = new Padding(20, 10, 0, 0);
                //Top_btn[idx].Location = new Point(left, top);
                Top_btn[idx].Left = left;
                Top_btn[idx].Top = top;
                Top_btn[idx].Width = width;
                Top_btn[idx].Height = height;
                Top_btn[idx].TabIndex = 19 + idx;
                Top_btn[idx].BackgroundImageLayout = ImageLayout.Stretch;

                left += 93;

                panel.Controls.Add(Top_btn[idx]);

            }
            Top_btn[0].BackgroundImage = ImageLoad.btnUserTopBack;
            Top_btn[1].BackgroundImage = ImageLoad.btnResultTopBack;
            Top_btn[2].BackgroundImage = ImageLoad.btnSetTopBack;
            Top_btn[3].BackgroundImage = ImageLoad.btnLogoutTopBack;
            Top_btn[4].BackgroundImage = ImageLoad.btnCloseTopBack;

            panel.BackgroundImage = ImageLoad.resultBack;

            this.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;

            tt_user.SetToolTip(Top_btn[0], Data.bPatient);
            tt_result.SetToolTip(Top_btn[1], Data.cResult);
            tt_Set.SetToolTip(Top_btn[2], Data.dSetting);
            tt_logout.SetToolTip(Top_btn[3], Data.jLogout);
            tt_close.SetToolTip(Top_btn[4], Data.kClose);

            Top_btn[0].Click += new System.EventHandler(Top_btn_0_Click);
            Top_btn[1].Enabled = true;
            Top_btn[2].Click += new System.EventHandler(Top_btn_2_Click);
            Top_btn[3].Click += new System.EventHandler(Top_btn_3_Click);
            Top_btn[4].Click += new System.EventHandler(Top_btn_4_Click);
            Top_btn[1].Focus();//220407
        }

        private void Top_btn_0_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Main.frmUser.Show();
        }

        private void Top_btn_2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\SettingProgram.exe");
            Application.Exit();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        //220408 START
        private void Top_btn_3_Click(object sender, EventArgs e)
        {
            Frm_Main.DisposeForm();
            Frm_Main frm_Main = new Frm_Main();
            frm_Main.Show();
            Frm_Main.LoadForm();
            //            Frm_Main.Form_Main_Load(sender, e);
            //            System.Diagnostics.Process.Start(Application.StartupPath + @"\frmrestart.exe");
        }
        //220408 END
        private void Top_btn_4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Form_Result_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Btn_Graph_Click(object sender, EventArgs e)
        {
            InitGraphDisplay();
        }

        private void Btn_list_Click(object sender, EventArgs e)
        {
            InitListDisplay();
        }

        public DateTime Delay(int MS)
        {
            DateTime thisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime Afterwards = thisMoment.Add(duration);
            while (Afterwards >= thisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                thisMoment = DateTime.Now;

            }
            return DateTime.Now;
        }

        private void Btn_result_Click(object sender, EventArgs e)
        {
            InitResultDisplay();
        }
        private void InitResultDisplay()
        {
            Frm_Main.frmSearch.Resultmode = 0;//220406_2
            Btn_result.BackColor = Data.SysColor;
            Btn_list.BackColor = SystemColors.Menu;
            Btn_Graph.BackColor = SystemColors.Menu;
            panel_GE.Visible = true;
            panel_GE.Enabled = true;
            panel_QC.Visible = true;
            panel_QC.Enabled = true;
            panel_Graph.Visible = false;
            panel_Graph.Enabled = false;
            spr_List.Enabled = false;
            spr_List.Visible = false;
            SearchMode = false;
            //220414 Start
            label6.Text = Data.cColor;
            label7.Text = Data.cturbidity;
            //           cb_color.Enabled = true;
            //           cb_trub.Enabled = true;
            lbl_lotno.Visible = false;
            lbl_sol.Visible = false;
            cb_color.Visible = true;
            cb_trub.Visible = true;
            cb_color.SelectedIndex = 0;
            cb_trub.SelectedIndex = 0;
            lbl_seq.Text = "";
            lbl_tdate.Text = "";
            lbl_ttime.Text = "";
            lbl_ttype.Text = "";
            lbl_oper.Text = "";
            lbl_lotno.Text = "";
            lbl_sol.Text = "";
            //220414End
            //            InitDisplay();
            //            initSpread();
            DBGridSet(ResultGridDataTable);
            initSpread();
            DBGrid_test.Columns[0].HeaderText = Data.cPatientID;
            DBGrid_test.Columns[1].HeaderText = Data.cSEQ;
            DBGrid_test.Columns[2].HeaderText = Data.cTestDate;
            Btn_set.Visible = false;    //220414
            cb_color.Enabled = true;    //220414
            cb_trub.Enabled = true;    //220414
            Btn_save.Visible = true;
            Btn_save.Enabled = true;
            Btn_Psave.Visible = true;
            panel.BackgroundImage = ImageLoad.resultBack;
            Btn_save.BackgroundImage = ImageLoad.btnSaveBack;
            Btn_Search.BackgroundImage = ImageLoad.btnSearchBack;
        }
        private void InitGraphDisplay()
        {
            panel.BackgroundImage = ImageLoad.resultBack;
            Btn_Search.BackgroundImage = ImageLoad.btnSearchBack;
            QCMode = false;
            panel_GE.Visible = true;
            panel_QC.Enabled = false;
            panel_Graph.Show();
            panel_Graph.Enabled = true;
            Btn_set.Visible = false;    //220414
            Btn_Graph.BackColor = Data.SysColor;
            Btn_result.BackColor = SystemColors.Menu;
            Btn_list.BackColor = SystemColors.Menu;
            RBtn_test.Checked = true;
            SearchMode = false;
            Btn_Search.Enabled = true;
            //220414 Start
            label6.Text = Data.cColor;
            label7.Text = Data.cturbidity;
            //            cb_color.Enabled = true;
            //           cb_trub.Enabled = true;
            cb_color.Visible = true;
            cb_trub.Visible = true;
            lbl_lotno.Visible = false;
            lbl_sol.Visible = false;
            cb_color.SelectedIndex = 0;
            cb_trub.SelectedIndex = 0;
            lbl_seq.Text = "";
            lbl_tdate.Text = "";
            lbl_ttime.Text = "";
            lbl_ttype.Text = "";
            lbl_oper.Text = "";
            lbl_lotno.Text = "";
            lbl_sol.Text = "";
            //220414End
            //220412 Start
            DBGridSet(ResultGridDataTable);
            DBGrid_test.Columns[0].HeaderText = Data.cPatientID;
            DBGrid_test.Columns[1].HeaderText = Data.cSEQ;
            DBGrid_test.Columns[2].HeaderText = Data.cTestDate;
            //220412 End
            spr_List.Hide();
            // CB_item.Enabled = false;
            //            panel_GE_Click(sender, e);
            chartControl.Series.Clear();
        }
        private void InitListDisplay()
        {
            //            panel_GE.Enabled = false;
            Frm_Main.frmSearch.Resultmode = 2;//220406_2
            panel_GE.Visible = false;
            //            panel_QC.Enabled = false;
            panel_QC.Visible = false;
            panel.BackgroundImage = ImageLoad.resultBack;
            Btn_Search.BackgroundImage = ImageLoad.btnSearchBack;

            Btn_list.BackColor = Data.SysColor;
            Btn_result.BackColor = SystemColors.Menu;
            Btn_Graph.BackColor = SystemColors.Menu;
            panel.BackgroundImage = ImageLoad.listBack;
            Btn_save.Visible = false;
            Btn_Psave.Visible = false;      //220414
            spr_List.Visible = true;
            spr_List.Enabled = true;
            Btn_Search.Enabled = true;
            Btn_set.Visible = true;
            SearchMode = false;

            string sql = @" SELECT * FROM DB_Listitem WHERE seq = 1";
            if (!DataConn.DataCheck(sql))
            {
                Frm_Main.frmlistset.Show();
            }
            ListUpdate();

        }
        private void RBtn_test_CheckedChanged(object sender, EventArgs e)
        {
            if (!RBtn_item.Checked)
            {
                Frm_Main.frmSearch.Resultmode = 0;//220406_3
                CB_item.Enabled = false;
                Btn_View.Visible = false;
                cb_color.Enabled = true;
                cb_trub.Enabled = true;
                Btn_save.Enabled = true;
                Btn_save.BackgroundImage = ImageLoad.btnSaveBack;
                Btn_Search.BackgroundImage = ImageLoad.btnSearchBack; //220412
                DBtableLoad();
            }
        }

        private void RBtn_item_CheckedChanged(object sender, EventArgs e)
        {
            if (RBtn_item.Checked)
            {
                Frm_Main.frmSearch.Resultmode = 1;//220406_3
                CB_item.Enabled = true;
                CB_item.SelectedIndex = 0;//220406_3
                Btn_View.Visible = true;
                //DBGrid_test.Enabled = false;
                cb_color.Enabled = false;
                cb_trub.Enabled = false;
                Btn_save.Enabled = false;
                Btn_save.BackgroundImage = ImageLoad.btndisSaveBack;
                InitDisplay();
            }
        }


        private void Btn_View_Click(object sender, EventArgs e)
        {
            Btn_Search.BackgroundImage = ImageLoad.btnSearchBack;
            SearchMode = false;
            GraphItemDataTable.Rows.Clear();
            if (GraphItemGridDataTable.Columns.Count > 0) GraphItemGridDataTable.Clear();
            int item = CB_item.SelectedIndex + 1;
            string filterExpression;

            if (UserID == "Admin")
            {
                filterExpression = $"(Item{item} > -1 )";
            }
            else
            {
                filterExpression = $"UID = '{ UserID }' and (Item{item} > -1 )";
            }

            //            DataColumn dcSEQ = Data.Result.Columns["SEQ"];
            //            DataColumn dcTestDate = Data.Result.Columns["TestDate"];
            //            DataColumn dcStrip = Data.Result.Columns["Strip"];
            DataTable dt = Data.ListResult;
            dt.Rows.Clear();
            Data.ListResult = DataConn.GetDataTable("DB_ListResult");
            DataRow[] dr = Data.ListResult.Select(filterExpression);
            //dt.Rows.Add(dr);
            for (int i = 0; i < dr.Length; i++) dt.ImportRow(dr[i]);


            /*
            DataColumn SEQ = new DataColumn("SEQ", typeof(Int32));
            DataColumn TestDate = new DataColumn("TestDate", typeof(string));
            DataColumn Value = new DataColumn("Value", typeof(string));
            DataColumn Result = new DataColumn("Result", typeof(string));


            string[] colNm = GraphItemDataTable.Columns.Cast<DataColumn>()
                .Select(x => x.ColumnName)
                .ToArray();

            if (!Array.Exists(colNm, x => x == "SEQ"))
            {
                GraphItemDataTable.Columns.Add(SEQ);
                GraphItemDataTable.Columns.Add(TestDate);
                GraphItemDataTable.Columns.Add(Value);
                GraphItemDataTable.Columns.Add(Result);
            }
            */
            dt.DefaultView.Sort = "SEQ ASC"; //220405
            dt = dt.DefaultView.ToTable(true);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                //                    if (dt.Rows[i][j] != DBNull.Value && Convert.ToInt32(dt.Rows[i][j]) == item)
                {
                    DataRow row = GraphItemDataTable.NewRow();
                    //row.BeginEdit();
                    //220404 Start
                    row["SEQ"] = Convert.ToInt32(dt.Rows[i]["SEQ"]);
                    row["TestDate"] = dt.Rows[i]["TestDate"].ToString();
                    row["Value"] = Convert.ToInt32(dt.Rows[i][$"Item{item}"]);
                    if (item < 14)
                    {
                        row["Result"] = Array_prt[item - 1, Convert.ToInt32(dt.Rows[i][$"Item{item}"]) + 3];
                    }
                    //220404 End
                    else if (item == 14)
                    {
                        int Ls_Cre = Convert.ToInt32(dt.Rows[i][$"Item13"]);
                        int Ls_Alb = Convert.ToInt32(dt.Rows[i][$"Item12"]);
                        if (Data.Get_Unit == 2)
                        {
                            row[3] = alb_tb_text_si[Ls_Cre, Ls_Alb + 1];
                        }
                        else
                        {
                            row[3] = alb_tb_text[Ls_Cre, Ls_Alb + 1];
                        }
                    }

                    //row.EndEdit(); 
                    //DataConn.AddDataTable(GraphItemDataTable, row);
                    GraphItemDataTable.Rows.Add(row);
                }
            }
            //            Console.WriteLine("Cnt:" + GraphItemDataTable.Rows.Count);


            GraphItemGridDataTable = dt.DefaultView.ToTable(false, new string[] { "SEQ", "TestDate", "Strip" });
            GraphItemGridDataTable.DefaultView.Sort = "SEQ DESC";        //220405
            GraphItemGridDataTable = GraphItemGridDataTable.DefaultView.ToTable(true);       //220405
            DBGrid_test.DataSource = GraphItemGridDataTable;             //220405

            DBGrid_test.Columns[0].HeaderText = Data.cSEQ;                      //220404
            DBGrid_test.Columns[1].HeaderText = Data.cTestDate;                      //220404
            DBGrid_test.Columns[2].HeaderText = Data.cStrip;                      //220404            
            Graph_Draw_Item(GraphItemDataTable.Rows.Count);
        }

        private DataTable ViewListDataTableMake()
        {
            DataRow dr = Data.ListItemRow;
            DataRow dr2 = Data.Table.NewRow();
            string filterExpression;
            listitem = new string[15];
            listseq = new int[15];

            for (int i = 0; i < listitemcnt; i++)
            {
                dr = Data.ListItem.Rows[i];
                listitem[i] = dr["Item"].ToString();
                filterExpression = $"Title = '{listitem[i]}'";
                //dr2 = Data.Table.Rows[i];
                dr2 = Data.Table.Select(filterExpression)[0];
                listseq[i] = int.Parse(dr2["Item"].ToString());
                if (listitem[i] == "S.G") listitem[i] = "SG";
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("SEQ");
            dt.Columns.Add("TestDate");
            dt.Columns.Add("Strip");
            dt.Columns.Add("PatientID");

            for (int i = 0; i < listitemcnt; i++)
            {
                DataColumn col = new DataColumn(listitem[i]);
                col.DataType = Type.GetType("System.String");
                dt.Columns.Add(col);
            }
            return dt;


            //            DataTable dt = dr.Table;
            //            return dt;
        }

        private void DisplayListDataOnDisplay() //220407
        {
            string filterExpression = "";
            string sortOrder;
            if (UserID != "Admin")
            {
                filterExpression = $"UID = '{ UserID }'";
            }
            sortOrder = " SEQ DESC";
            Data.ListResult = DataConn.GetDataTable("DB_ListResult");
            ListDataRow = Data.ListResult.Select(filterExpression, sortOrder);
            Console.WriteLine($"ListCnt : {ListDataRow.Length}");
            int dataCnt = ListDataRow.Length;
            DataRow dbrow;
            //listitemcnt = (listitemcnt > 14 ? 14 : listitemcnt);
            int Ls_Cre = 0, Ls_Alb = 0; //Ls_AC = 0;
            string tempValue = "";
            //220404 Start 
            for (int i = 0; i < dataCnt; i++)
            {
                DataRow dr = ViewListDataTable.NewRow();
                dbrow = ListDataRow[i];
                dr["SEQ"] = Convert.ToInt32(dbrow["SEQ"]);
                dr["TestDate"] = dbrow["TestDate"].ToString();
                dr["Strip"] = dbrow["Strip"].ToString();
                dr["PatientID"] = dbrow["PatientID"].ToString();
                //220407 Start
                for (int j = 0; j < listitemcnt; j++)
                {
                    int tempItemName = listseq[j];
                    int tempItem = Convert.ToInt32(dbrow[listseq[j] + 4]);
                    //string tempValue = Array_prt[listseq[j] - 1, tempItem + 3];
                    if (tempItem > -1)
                    {
                        if (tempItemName < 14)
                        {
                            tempValue = Array_prt[tempItemName - 1, tempItem + 3];
                        }
                        else if (tempItemName == 14)
                        {
                            Ls_Alb = Convert.ToInt32(dbrow[12 + 4]);
                            Ls_Cre = Convert.ToInt32(dbrow[13 + 4]);
                            if (Data.Get_Unit == 2)
                            {
                                tempValue = alb_tb_text_si[Ls_Cre, Ls_Alb + 1];
                            }
                            else
                            {
                                tempValue = alb_tb_text[Ls_Cre, Ls_Alb + 1];
                            }
                            Console.WriteLine($"ItmeName{tempItemName}, ,Cre:{Ls_Cre},Alb:{Ls_Alb},Value : {tempValue}, SEQ : {dr[0].ToString()}");
                        }
                    }
                    else
                    {
                        tempValue = "";
                    }

                    //                   Console.WriteLine(tempValue);
                    dr[j + 4] = tempValue;
                }
                //DataConn.AddDataTable(ViewListDataTable, dr);
                ViewListDataTable.Rows.Add(dr);
            }
            //220407 End
            //ViewListDataTable.DefaultView.Sort = "SEQ DESC";
            //ViewListDataTable = ViewListDataTable.DefaultView.ToTable(true);

            spr_List.BeginUpdate();
            spr_List.WorksheetDisplayArea.SetSize(listSheet.Index, listitemcnt + 4, dataCnt + 1);
            spr_List.Options.Behavior.ShowPopupMenu = DevExpress.XtraSpreadsheet.DocumentCapability.Hidden;
            listSheet.ActiveView.ShowHeadings = false;
            listSheet.Columns["B"].Width = 550;
            listSheet.Columns["C"].Width = 300;
            listSheet.Columns["D"].Width = 400;

            Cell cell;
            for (int i = 0; i < ViewListDataTable.Columns.Count; i++)
            {
                cell = listSheet.Rows[0][i];
                SetCellStyle(cell, true, 12, Color.LightGray);
                if (i < 4)
                {
                    cell.SetValue(listcol[i]);
                }
                else
                {
                    cell.SetValue(ViewListDataTable.Columns[i].ToString());
                }
                cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                cell.Font.Name = "Times New Roman";
            }
            for (int i = 0; i < ViewListDataTable.Rows.Count; i++)
            {
                for (int j = 0; j < ViewListDataTable.Columns.Count; j++)
                {
                    cell = listSheet.Rows[i + 1][j];
                    cell.SetValue(ViewListDataTable.Rows[i][j]);
                    cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                    cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                }
            }

            CellRange usedRange = listSheet.GetUsedRange();
            listSheet.GetUsedRange().AutoFitColumns();
            listSheet.GetUsedRange().AutoFitRows();

            spr_List.EndUpdate();
            DataConn.CloseDB();
        }

        private void Btn_Psave_Click(object sender, EventArgs e)
        {
            if (txt_name.Enabled)
            {
                string lblID = lbl_Id.Text;
                if (DataConn.IDCheck(lblID, Data.Patient))
                {
                    Data.Patient.Rows.Remove(Data.PatientRow);
                    DataRow dr = Data.Patient.NewRow();
                    dr["PatientID"] = lbl_Id.Text;
                    dr["PName"] = txt_name.Text;
                    dr["Birthday"] = DT_bth.Value.ToString("yyyy-MM-dd");
                    dr["Sex"] = cb_sex.SelectedItem;
                    //                    Data.Patient.Rows.Add(Data.PatientRow);
                    //DataConn.AddDataTable(Data.Patient, Data.PatientRow);
                    DataConn.InsertData(Data.Patient, dr); //220405
                    //Data.Patient.Rows.Add(dr);
                }
                else
                {
                    Data.Patient.NewRow();
                    DataRow dr = Data.Patient.NewRow();
                    dr["PatientID"] = lbl_Id.Text;
                    dr["PName"] = txt_name.Text;
                    dr["Birthday"] = DT_bth.Value.ToString("yyyy-MM-dd");
                    dr["Sex"] = cb_sex.SelectedItem;
                    //                    Data.Patient.Rows.Add(Data.PatientRow);
                    //DataConn.AddDataTable(Data.Patient, Data.PatientRow);
                    DataConn.InsertData(Data.Patient, dr); //220405
                    //Data.Patient.Rows.Add(dr);
                }
                DataConn.GetDataCommit();//220421_2
                Btn_Search.BackgroundImage = ImageLoad.btnSearchBack;
                lbl_Id.BackColor = Color.White;
                txt_name.Enabled = false;
                cb_sex.Enabled = false;
                DT_bth.Enabled = false;
            }
        }

        private void panel_GE_Click(object sender, EventArgs e)
        {
            QCMode = false;
            SearchMode = false;

            panel.BackgroundImage = ImageLoad.resultBack;
            Btn_Search.BackgroundImage = ImageLoad.btnSearchBack;
            Btn_Search.Enabled = true;
            cb_color.Visible = true;
            cb_trub.Visible = true;
            lbl_lotno.Visible = false;
            lbl_sol.Visible = false;
            Btn_reset.Enabled = true;
            Btn_save.Enabled = true;
            Btn_print.Enabled = true;
            Btn_save.BackgroundImage = ImageLoad.btnSaveBack;
            InitDisplay();
            if (Btn_Graph.Enabled) ResultGridDataTable = DBtableLoad();
            DBGridSet(ResultGridDataTable);
            initSpread();
        }

        private void panel_QC_Click(object sender, EventArgs e)
        {
            QCMode = true;
            SearchMode = false;

            panel.BackgroundImage = ImageLoad.qcResultBack;
            Btn_Search.BackgroundImage = ImageLoad.resultBack;
            Btn_Search.Enabled = false;
            Btn_save.Enabled = false;
            Btn_save.BackgroundImage = ImageLoad.btndisSaveBack;
            cb_color.Visible = false;
            cb_trub.Visible = false;
            lbl_lotno.Visible = true;
            lbl_sol.Visible = true;
            Btn_reset.Enabled = false;
            Btn_save.Enabled = false;
            Btn_print.Enabled = false;

            InitDisplay();
            DBGridSet(QCGridDataTable);
            initSpread();


        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (SearchMode)
            {
                Frm_Main.frmSearch.Btn_Confirm.Enabled = false;
                Frm_Main.frmSearch.Btn_Confirm.BackgroundImage = ImageLoad.btndisConfirmBack;
            }
            Frm_Main.frmSearch.QCmode = QCMode;
            if (RBtn_item.Checked)
            {
                //220406_2 Deleted
                Frm_Main.frmSearch.Item = CB_item.SelectedIndex + 1;
            }
            //220406_2 Start
            //            else if (Btn_list.BackColor == Data.SysColor) frmSearch.Resultmode = 2;
            //          else frmSearch.Resultmode = 0;
            //220406_2 End
            Console.WriteLine("Resultmode : " + Frm_Main.frmSearch.Resultmode);
            Frm_Main.frmSearch.search_cmd += new Frm_Search.DataHandler(SearchView);
            Frm_Main.frmSearch.Show();
        }

        public void SearchView()
        {
            DataTable dt2;
            SearchMode = true;

            InitDisplay();
            Frm_Main.frmSearch.QCmode = QCMode;

            //            Frm_Search frmSearch = new Frm_Search(QCMode);
            DataTable dt = Frm_Main.frmSearch.search;
            //if (!QCMode) 
            if (Frm_Main.frmSearch.Resultmode == 0)
            {
                dt2 = dt.DefaultView.ToTable(false, new string[] { "PatientID", "SEQ", "TestDate" });
                DBGridSet(dt2);
            }
            //else dt2 = dt.DefaultView.ToTable(false, new string[] { "LotNo", "SEQ", "TestDate" });
            else if (Frm_Main.frmSearch.Resultmode == 1)
            {
                dt.DefaultView.Sort = "SEQ ASC";        //220405
                dt = dt.DefaultView.ToTable(true);          //220405
                int item = CB_item.SelectedIndex + 1;
                GraphItemDataTable.Rows.Clear();
                if (GraphItemGridDataTable.Columns.Count > 0) GraphItemGridDataTable.Clear();


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    //                    if (dt.Rows[i][j] != DBNull.Value && Convert.ToInt32(dt.Rows[i][j]) == item)
                    {
                        DataRow row = GraphItemDataTable.NewRow();
                        //row.BeginEdit();
                        //220404 Start
                        row["SEQ"] = Convert.ToInt32(dt.Rows[i]["SEQ"]);
                        row["TestDate"] = dt.Rows[i]["TestDate"].ToString();
                        row["Value"] = Convert.ToInt32(dt.Rows[i][$"Item{item}"]);
                        if (item < 14)
                        {
                            row["Result"] = Array_prt[item - 1, Convert.ToInt32(dt.Rows[i][$"Item{item}"]) + 3];
                        }
                        //220404 End
                        else if (item == 14)
                        {
                            int Ls_Cre = Convert.ToInt32(dt.Rows[i][$"Item13"]);
                            int Ls_Alb = Convert.ToInt32(dt.Rows[i][$"Item12"]);
                            if (Data.Get_Unit == 2)
                            {
                                row["Result"] = alb_tb_text_si[Ls_Cre, Ls_Alb + 1];
                            }
                            else
                            {
                                row["Result"] = alb_tb_text[Ls_Cre, Ls_Alb + 1];
                            }
                        }

                        //row.EndEdit(); 
                        //DataConn.AddDataTable(GraphItemDataTable, row);
                        GraphItemDataTable.Rows.Add(row);
                    }
                }


                GraphItemGridDataTable = dt.DefaultView.ToTable(false, new string[] { "SEQ", "TestDate", "Strip" });
                GraphItemGridDataTable.DefaultView.Sort = "SEQ DESC";        //220405
                GraphItemGridDataTable = GraphItemGridDataTable.DefaultView.ToTable(true);       //220405
                DBGrid_test.DataSource = GraphItemGridDataTable;             //220405
                DBGrid_test.Columns[0].HeaderText = Data.cSEQ;                      //220404
                DBGrid_test.Columns[1].HeaderText = Data.cTestDate;              //220404
                DBGrid_test.Columns[2].HeaderText = Data.cStrip;                    //220404
                Graph_Draw_Item(GraphItemDataTable.Rows.Count);

            }
            else
            {
                ViewListDataTable.Rows.Clear();
                if (ViewListDataTable.Columns.Count > 0) ViewListDataTable.Clear();
                //ViewListDataTable = dt;
                ViewListDataTable = ViewListDataTableMake();
                int dataCnt = Frm_Main.frmSearch.search.Rows.Count;
                DataRow dbrow = Frm_Main.frmSearch.search.NewRow();
                //listitemcnt = (listitemcnt > 14 ? 14 : listitemcnt);
                int Ls_Cre = 0, Ls_Alb = 0; //Ls_AC = 0;
                string tempValue = "";
                //foreach(DataColumn dc in frmSearch.search.Rows.Columns)

                for (int i = 0; i < dataCnt; i++)
                {
                    DataRow dr = ViewListDataTable.NewRow();
                    //dbrow = ListDataRow[i];
                    dbrow = Frm_Main.frmSearch.search.Rows[i];
                    dr["SEQ"] = Convert.ToInt32(dbrow["SEQ"]);
                    dr["TestDate"] = dbrow["TestDate"].ToString();
                    dr["Strip"] = dbrow["Strip"].ToString();

                    //dr["PatientID"] = dbrow["T1.PatientID"].ToString();
                    //dr["PatientID"] = dbrow["PatientID"].ToString();
                    dr["PatientID"] = dbrow[4].ToString();

                    for (int j = 0; j < listitemcnt; j++)
                    {
                        int tempItemName = listseq[j];
                        int tempItem = Convert.ToInt32(dbrow[listseq[j] + 4]);
                        //string tempValue = Array_prt[listseq[j] - 1, tempItem + 3];
                        if (tempItem > -1)
                        {
                            if (tempItemName < 14)
                            {
                                tempValue = Array_prt[tempItemName - 1, tempItem + 3];
                            }
                            else if (tempItemName == 14)
                            {
                                Ls_Alb = Convert.ToInt32(dbrow[12 + 4]);
                                Ls_Cre = Convert.ToInt32(dbrow[13 + 4]);
                                if (Data.Get_Unit == 2)
                                {
                                    tempValue = alb_tb_text_si[Ls_Cre, Ls_Alb + 1];
                                }
                                else
                                {
                                    tempValue = alb_tb_text[Ls_Cre, Ls_Alb + 1];
                                }
                                Console.WriteLine($"ItmeName{tempItemName}, ,Cre:{Ls_Cre},Alb:{Ls_Alb},Value : {tempValue}, SEQ : {dr[0].ToString()}");
                            }
                        }
                        else
                        {
                            tempValue = "";
                        }

                        //                   Console.WriteLine(tempValue);
                        dr[j + 4] = tempValue;
                    }
                    //DataConn.AddDataTable(ViewListDataTable, dr);
                    ViewListDataTable.Rows.Add(dr);
                }
                ViewListDataTable.DefaultView.Sort = "TestDate DESC";
                ViewListDataTable = ViewListDataTable.DefaultView.ToTable(true);

                spr_List.BeginUpdate();
                spr_List.WorksheetDisplayArea.SetSize(listSheet.Index, listitemcnt + 4, dataCnt + 1);
                spr_List.Options.Behavior.ShowPopupMenu = DevExpress.XtraSpreadsheet.DocumentCapability.Hidden;
                listSheet.ActiveView.ShowHeadings = false;
                listSheet.Columns["B"].Width = 550;
                listSheet.Columns["C"].Width = 300;
                listSheet.Columns["D"].Width = 400;

                Cell cell;
                for (int i = 0; i < ViewListDataTable.Columns.Count; i++)
                {
                    cell = listSheet.Rows[0][i];
                    SetCellStyle(cell, true, 12, Color.LightGray);
                    if (i < 4)
                    {
                        cell.SetValue(listcol[i]);
                    }
                    else
                    {
                        cell.SetValue(ViewListDataTable.Columns[i].ToString());
                    }
                    cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                    cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    cell.Font.Name = "Times New Roman";
                }
                for (int i = 0; i < ViewListDataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < ViewListDataTable.Columns.Count; j++)
                    {
                        cell = listSheet.Rows[i + 1][j];
                        cell.SetValue(ViewListDataTable.Rows[i][j]);
                        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    }
                }

                CellRange usedRange = listSheet.GetUsedRange();
                //listSheet.GetUsedRange().AutoFitColumns();
                //listSheet.GetUsedRange().AutoFitRows();
                usedRange.AutoFitColumns();
                usedRange.AutoFitRows();

                spr_List.EndUpdate();
                DataConn.CloseDB();
            }
            Btn_Search.BackgroundImage = ImageLoad.btnSearchingBack;

            if (Frm_Search.patientSearchFlag)
            {
                lbl_Id.Text = Frm_Search.patientID;
                txt_name.Text = Frm_Search.name;
                DT_bth.Value = Convert.ToDateTime(Frm_Search.birthday);
                cb_sex.SelectedIndex = (Frm_Search.sex == Data.bMale ? 0 : 1);
            }
        }

        private void Btn_reset_Click(object sender, EventArgs e)
        {
            SearchMode = false;
            Frm_Search.patientSearchFlag = false;       //220421_2
            if (QCMode) QCGridDataTable = QCDBtableLoad();
            else ResultGridDataTable = DBtableLoad();
            if (Frm_Main.frmSearch.Resultmode == 2) ListUpdate();//220404
            else if (Frm_Main.frmSearch.Resultmode == 1)//220406_3 Start
            {
                InitDisplay();
                Btn_View_Click(sender, e);
            }//220406_3 End
            else InitDisplay();

        }

        private void Btn_set_Click(object sender, EventArgs e)
        {
            Frm_Main.frmlistset.Show();
        }

        private void ListUpdate()
        {
            Btn_Search.BackgroundImage = ImageLoad.btnSearchBack; //220405
            Data.ListItem = DataConn.GetDataTable("DB_ListItem");
            listitemcnt = Data.ListItem.Rows.Count;
            Console.WriteLine($"ListItem Count : {listitemcnt}");
            ViewListDataTable = ViewListDataTableMake();
            //            ViewListDataTable = ListDataTableMake();
            DisplayListDataOnDisplay();
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            if (Btn_result.BackColor != SystemColors.Menu)
            {
                PrintResult(ViewResultDataTable);
            }
            else if (Btn_Graph.BackColor != SystemColors.Menu)
            {
                if (RBtn_test.Checked) PrintGraph();
                else PrintGraphItem();
            }
            else if (Btn_list.BackColor != SystemColors.Menu)
            {
                PrintList();
            }
        }

        private void PrintResult(DataTable rdt)
        {
            //int itemCnt = 14;
            int itemCnt = rdt.Rows.Count;
            var filePath = Application.StartupPath + "\\PrintResult.repx";
            XtraReport rep = XtraReport.FromFile(filePath, true);

            rep.LoadLayout(filePath);
            var tbtitle = Data.cResult;
            var tbSampleID = lbl_Id.Text;
            var tbSEQ = lbl_seq.Text;
            var tbTestDate = lbl_tdate.Text;
            var tbTestTime = lbl_ttime.Text;
            var tbStrip = lbl_ttype.Text;
            var tbColor = cb_color.SelectedItem.ToString();
            var tbTurbidity = cb_trub.SelectedItem.ToString();
            var lblUserID = $"{Data.gUserID} : ";
            //rep.Bands["Header"].Visible = false;
            rep.Bands[0].BackColor = Color.White;
            rep.Bands["DetailTitle"].BackColor = Color.White;
            rep.Bands["DetailMid"].Controls[0].BackColor = Color.White;

            XRControl title = rep.Bands["DetailTitle"].FindControl("lblTitle", true);
            XRControl sampleID = rep.Bands["DetailMid"].FindControl("tbSampleIDInput", true);
            XRControl seq = rep.Bands["DetailMid"].FindControl("tbSEQInput", true);
            XRControl testDate = rep.Bands["DetailMid"].FindControl("tbTestDateInput", true);
            XRControl testTime = rep.Bands["DetailMid"].FindControl("tbTestTimeInput", true);
            XRControl strip = rep.Bands["DetailMid"].FindControl("tbTestTypeInput", true);
            XRControl color = rep.Bands["DetailMid"].FindControl("tbColorInput", true);
            XRControl turbidity = rep.Bands["DetailMid"].FindControl("tbTurbidityInput", true);
            XRControl lblsampleID = rep.Bands["DetailMid"].FindControl("tbSampleIDLabel", true);
            XRControl lblseq = rep.Bands["DetailMid"].FindControl("tbSEQLabel", true);
            XRControl lbltestDate = rep.Bands["DetailMid"].FindControl("tbTestDateLabel", true);
            XRControl lbltestTime = rep.Bands["DetailMid"].FindControl("tbTestTimeLabel", true);
            XRControl lblstrip = rep.Bands["DetailMid"].FindControl("tbTestTypeLabel", true);
            XRControl lblcolor = rep.Bands["DetailMid"].FindControl("tbColorLabel", true);
            XRControl lblturbidity = rep.Bands["DetailMid"].FindControl("tbTurbidityLabel", true);

            title.Text = tbtitle;
            sampleID.Text = tbSampleID;
            seq.Text = tbSEQ;
            testDate.Text = tbTestDate;
            testTime.Text = tbTestTime;
            strip.Text = tbStrip;
            color.Text = tbColor;
            turbidity.Text = tbTurbidity;
            lblsampleID.Text = Data.cPatientID;
            lblseq.Text = Data.cSEQ;
            lbltestDate.Text = Data.cTestDate;
            lbltestTime.Text = Data.cTestTime;
            lblstrip.Text = Data.cStrip;
            lblcolor.Text = Data.cColor;
            lblturbidity.Text = Data.cturbidity;

            XRControl lblItem = rep.Bands["DetailBottom"].FindControl("tbTitle1", true);
            XRControl lblResult = rep.Bands["DetailBottom"].FindControl("tbTitle2", true);
            XRControl lblUnit = rep.Bands["DetailBottom"].FindControl("tbTitle3", true);

            lblItem.Text = Data.cItem;
            lblResult.Text = Data.cResult;
            lblUnit.Text = Data.cUnit;

            List<XRControl> itemName = new List<XRControl>();
            List<XRControl> result = new List<XRControl>();
            List<XRControl> unit = new List<XRControl>();
            for (int i = 1; i <= itemCnt; i++)
            {
                XRControl ItemName = rep.Bands["DetailBottom"].FindControl("tbItemName" + i, true);
                XRControl Result = rep.Bands["DetailBottom"].FindControl("tbResult" + i, true);
                XRControl Unit = rep.Bands["DetailBottom"].FindControl("tbUnit" + i, true);
                itemName.Add(ItemName);
                result.Add(Result);
                unit.Add(Unit);
            }
            for (int i = 0; i < itemCnt; i++)
            {
                itemName[i].Text = rdt.Rows[i][0].ToString();
                if (itemName[i].Text != "") result[i].Text = rdt.Rows[i][1].ToString();
                else result[i].Text = rdt.Rows[i][1].ToString().Remove(0, 1);
                unit[i].Text = rdt.Rows[i][2].ToString();

                if (!Array.Exists(exceptionalItem, x => x == rdt.Rows[i][0].ToString()))
                {
                    if (item[2, i] == 0)
                    {
                        itemName[i].ForeColor = Data.Get_Neg_fore;
                        result[i].ForeColor = Data.Get_Neg_fore;
                    }
                    else
                    {
                        itemName[i].ForeColor = Data.Get_Pos_fore;
                        result[i].ForeColor = Data.Get_Pos_fore;
                    }
                }
            }



            //result[itemCnt].Text = rdt.Rows[itemCnt]

            XRControl userID = rep.Bands["BottomMargin"].FindControl("lblUserID", true);
            userID.Text = lblUserID + UserID;
            //XRControl PrintDate = rep.Bands["BottomMargin"].FindControl("lblPrintDate", true);
            //PrintDate.Text = DateTime.Now.ToString();
            ReportPrintTool tool = new ReportPrintTool(rep);
            _ = tool.PrintDialog();


            //            rep.SaveLayout(filePath);
            //            report.OpenDocument(filePath);
            //report.ReportExplorerOptions.Visibility = DevExpress.Xpf.Reports.UserDesigner.DockPanelVisibility.Closed;
            //report.ReportGalleryOptions.Visibility = DevExpress.Xpf.Reports.UserDesigner.DockPanelVisibility.Closed;
            //report.FieldListOptions.Visibility = DevExpress.Xpf.Reports.UserDesigner.DockPanelVisibility.Closed;
            //report.GroupAndSortPanelOptions.Visibility = DevExpress.Xpf.Reports.UserDesigner.DockPanelVisibility.Closed;
            //report.PropertyGridOptions.Visibility = DevExpress.Xpf.Reports.UserDesigner.DockPanelVisibility.Closed;
            //Close();
        }

        private void PrintGraph()
        {
            //int itemCnt = 14;
            var filePath = Application.StartupPath + "\\PrintGraph.repx";
            XtraReport rep = XtraReport.FromFile(filePath, true);

            rep.LoadLayout(filePath);

            var tbtitle = Data.cResult;
            var tbSampleID = lbl_Id.Text;
            var tbSEQ = lbl_seq.Text;
            var tbTestDate = lbl_tdate.Text;
            var tbTestTime = lbl_ttime.Text;
            var tbStrip = lbl_ttype.Text;
            var tbColor = cb_color.SelectedItem.ToString();
            var tbTurbidity = cb_trub.SelectedItem.ToString();
            var lblUserID = $"{Data.gUserID} : ";
            //rep.Bands["Header"].Visible = false;
            rep.Bands[0].BackColor = Color.White;
            rep.Bands["DetailTitle"].BackColor = Color.White;
            rep.Bands["DetailMid"].Controls[0].BackColor = Color.White;

            XRControl title = rep.Bands["DetailTitle"].FindControl("lblTitle", true);
            XRControl sampleID = rep.Bands["DetailMid"].FindControl("tbSampleIDInput", true);
            XRControl seq = rep.Bands["DetailMid"].FindControl("tbSEQInput", true);
            XRControl testDate = rep.Bands["DetailMid"].FindControl("tbTestDateInput", true);
            XRControl testTime = rep.Bands["DetailMid"].FindControl("tbTestTimeInput", true);
            XRControl strip = rep.Bands["DetailMid"].FindControl("tbTestTypeInput", true);
            XRControl color = rep.Bands["DetailMid"].FindControl("tbColorInput", true);
            XRControl turbidity = rep.Bands["DetailMid"].FindControl("tbTurbidityInput", true);
            XRControl lblsampleID = rep.Bands["DetailMid"].FindControl("tbSampleIDLabel", true);
            XRControl lblseq = rep.Bands["DetailMid"].FindControl("tbSEQLabel", true);
            XRControl lbltestDate = rep.Bands["DetailMid"].FindControl("tbTestDateLabel", true);
            XRControl lbltestTime = rep.Bands["DetailMid"].FindControl("tbTestTimeLabel", true);
            XRControl lblstrip = rep.Bands["DetailMid"].FindControl("tbTestTypeLabel", true);
            XRControl lblcolor = rep.Bands["DetailMid"].FindControl("tbColorLabel", true);
            XRControl lblturbidity = rep.Bands["DetailMid"].FindControl("tbTurbidityLabel", true);

            title.Text = tbtitle;
            sampleID.Text = tbSampleID;
            seq.Text = tbSEQ;
            testDate.Text = tbTestDate;
            testTime.Text = tbTestTime;
            strip.Text = tbStrip;
            color.Text = tbColor;
            turbidity.Text = tbTurbidity;
            lblsampleID.Text = Data.cPatientID;
            lblseq.Text = Data.cSEQ;
            lbltestDate.Text = Data.cTestDate;
            lbltestTime.Text = Data.cTestTime;
            lblstrip.Text = Data.cStrip;
            lblcolor.Text = Data.cColor;
            lblturbidity.Text = Data.cturbidity;

            XRChart Chart = (XRChart)rep.Bands["DetailBottom"].FindControl("chartResult", false);
            ((IChartContainer)Chart).Chart.Assign(((IChartContainer)GraphChart).Chart);

            XRControl userID = rep.Bands["BottomMargin"].FindControl("lblUserID", true);
            userID.Text = lblUserID + UserID;

            ReportPrintTool tool = new ReportPrintTool(rep);
            _ = tool.PrintDialog();
            //Close();
        }
        private void PrintGraphItem()
        {
            // int itemCnt = 14;
            var filePath = Application.StartupPath + "\\PrintGraphItem.repx";
            XtraReport rep = XtraReport.FromFile(filePath, true);

            rep.LoadLayout(filePath);
            var tbtitle = Data.cResult;
            var tbItem = CB_item.SelectedItem.ToString();
            var tbSampleID = lbl_Id.Text;
            var tbName = txt_name.Text;
            var tbBirthday = DT_bth.Value.ToString("d");  //220404
            var tbSex = cb_sex.SelectedItem.ToString();
            var tbStrip = lbl_ttype.Text;

            var lblUserID = $"{Data.gUserID} : ";
            //rep.Bands["Header"].Visible = false;
            rep.Bands[0].BackColor = Color.White;
            rep.Bands["DetailTitle"].BackColor = Color.White;
            rep.Bands["DetailMid"].Controls[0].BackColor = Color.White;

            XRControl title = rep.Bands["DetailTitle"].FindControl("lblTitle", true);
            XRControl Item = rep.Bands["DetailMid"].FindControl("tbItemInput", true);
            XRControl sampleID = rep.Bands["DetailMid"].FindControl("tbSampleIDInput", true);
            XRControl Name = rep.Bands["DetailMid"].FindControl("tbNameInput", true);
            XRControl Birthday = rep.Bands["DetailMid"].FindControl("tbBirthdayInput", true);
            XRControl Sex = rep.Bands["DetailMid"].FindControl("tbSexInput", true);
            XRControl lblItem = rep.Bands["DetailMid"].FindControl("tbItemLabel", true);
            XRControl lblsampleID = rep.Bands["DetailMid"].FindControl("tbSampleIDLabel", true);
            XRControl lblName = rep.Bands["DetailMid"].FindControl("tbNameLabel", true);
            XRControl lblBirthday = rep.Bands["DetailMid"].FindControl("tbBirthdayLabel", true);
            XRControl lblSex = rep.Bands["DetailMid"].FindControl("tbSexLabel", true);

            title.Text = tbtitle;
            Item.Text = tbItem;
            if (Frm_Search.patientSearchFlag)       //220421
            {
                sampleID.Text = tbSampleID;
                Name.Text = tbName;
                Birthday.Text = tbBirthday;
                Sex.Text = tbSex;
            }
            lblItem.Text = Data.cItem;
            lblsampleID.Text = Data.cPatientID;
            lblName.Text = Data.cName;
            lblBirthday.Text = Data.cBirthday;
            lblSex.Text = Data.cSex;


            XRChart Chart = (XRChart)rep.Bands["DetailBottom"].FindControl("chartResult", false);
            ((IChartContainer)Chart).Chart.Assign(((IChartContainer)GraphChart).Chart);

            XRControl userID = rep.Bands["BottomMargin"].FindControl("lblUserID", true);
            userID.Text = lblUserID + UserID;

            ReportPrintTool tool = new ReportPrintTool(rep);
            _ = tool.PrintDialog();
            //Close();
        }
        private void PrintList()
        {
            int itemCnt = Data.ListItem.Rows.Count;
            int dataCnt = ViewListDataTable.Rows.Count;
            int pageCnt = (dataCnt / 20) + 1;
            //int dataCnt = 20;
            var tbtitle = Data.cResult;
            var lblUserID = $"{Data.gUserID} : ";
            string Date = DateTime.Now.ToString();
            XtraReport xr = new XtraReport();
            var filePath = Application.StartupPath + "\\PrintList.repx";
            xr.PrintingSystem.ContinuousPageNumbering = true;
            for (int page = 0; page < pageCnt; page++)
            {
                XtraReport rep = XtraReport.FromFile(filePath, true);
                rep.BeginUpdate();
                rep.LoadLayout(filePath);
                int pageDataCnt = (page != pageCnt - 1 ? 20 : dataCnt - (page * 20));
                //              rep.Pages.Insert(page, rep.Pages[page]);
                //rep.Bands["Header"].Visible = false;
                XRControl lblSEQ = rep.Bands["Detail"].FindControl("lblSEQ", true);
                XRControl lblTestDate = rep.Bands["Detail"].FindControl("lblTestDate", true);
                XRControl lblStrip = rep.Bands["Detail"].FindControl("lblStrip", true);
                XRControl lblPatientID = rep.Bands["Detail"].FindControl("lblPatientID", true);
                XRControl lblUnit = rep.Bands["Detail"].FindControl("lblUnit", true);

                lblSEQ.Text = Data.cSEQ;
                lblTestDate.Text = Data.cTestDate;
                lblStrip.Text = Data.cStrip;
                lblPatientID.Text = Data.cPatientID;
                lblUnit.Text = Data.cUnit;

                List<XRControl> SEQ = new List<XRControl>();
                List<XRControl> result = new List<XRControl>();
                List<XRControl> unit = new List<XRControl>();
                List<XRControl> itemName = new List<XRControl>();
                List<XRControl> testDate = new List<XRControl>();
                List<XRControl> strip = new List<XRControl>();
                List<XRControl> pID = new List<XRControl>();
                for (int i = 1; i <= itemCnt; i++)
                {
                    XRControl ItemName = rep.Bands["Detail"].FindControl("item" + i, true);
                    ItemName.Text = "";
                    for (int j = 1; j <= pageDataCnt; j++)
                    {
                        XRControl Result = rep.Bands["Detail"].FindControl($"item{i}_{j}", true);
                        Result.Text = "";
                        if (Result == null) Console.WriteLine($"i:{i}, j:{j}");
                        result.Add(Result);
                    }
                    XRControl Unit = rep.Bands["Detail"].FindControl("unit" + i, true);
                    Unit.Text = "";
                    itemName.Add(ItemName);
                    unit.Add(Unit);
                }
                for (int i = 1; i <= pageDataCnt; i++)
                {
                    XRControl seq = rep.Bands["Detail"].FindControl("seq" + i, true);
                    XRControl TestDate = rep.Bands["Detail"].FindControl("date" + i, true);
                    XRControl Strip = rep.Bands["Detail"].FindControl("strip" + i, true);
                    XRControl PID = rep.Bands["Detail"].FindControl("pid" + i, true);
                    seq.Text = "";
                    TestDate.Text = "";
                    Strip.Text = "";
                    PID.Text = "";
                    SEQ.Add(seq);
                    testDate.Add(TestDate);
                    strip.Add(Strip);
                    pID.Add(PID);
                }
                for (int i = 0; i < itemCnt; i++)
                {
                    itemName[i].Text = ViewListDataTable.Columns[4 + i].ToString();
                    for (int j = 0; j < pageDataCnt; j++)
                    {
                        //220406_3 Start
                        //result[j + i * itemCnt].Text = ViewListDataTable.Rows[j+page*20][4 + i].ToString();
                        result[j + i * pageDataCnt].Text = ViewListDataTable.Rows[j + page * 20][4 + i].ToString();
                        //                       result[(j + i * pageDataCnt) * (page + 1)].Text = ViewListDataTable.Rows[j][4 + i].ToString();
                        //220406_3 End
                    }
                    unit[i].Text = Array_prt[listseq[i] - 1, 2];
                }
                for (int i = 0; i < pageDataCnt; i++)
                {
                    SEQ[i].Text = ViewListDataTable.Rows[page * 20 + i][0].ToString();
                    testDate[i].Text = ViewListDataTable.Rows[page * 20 + i][1].ToString();
                    strip[i].Text = ViewListDataTable.Rows[page * 20 + i][2].ToString();
                    pID[i].Text = ViewListDataTable.Rows[page * 20 + i][3].ToString();
                }
                XRControl title = rep.Bands["PageHeader"].FindControl("lblTitle", true);
                title.Text = tbtitle;
                XRControl userID = rep.Bands["BottomMargin"].FindControl("lblUserID", true);
                userID.Text = lblUserID + UserID;
                XRControl PrintDate = rep.Bands["BottomMargin"].FindControl("lblPrintDate", true);      //220404
                PrintDate.Text = Date;      //220404

                rep.CreateDocument();
                xr.ModifyDocument(x =>
                {
                    x.AddPages(rep.Pages);
                });
            }

            new ReportPrintTool(xr).ShowPreview();
            //ReportPrintTool tool = new ReportPrintTool(rep2);
            //_ = tool.PrintDialog();

            //Close();
        }


    }
}
