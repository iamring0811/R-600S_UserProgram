using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace UrineAnalyzer
{
    public partial class Frm_Search : Form
    {

        public bool QCmode;
        public int Resultmode;
        public int Item;

        public Frm_Search()
        {
            InitializeComponent();
        }

        //public string targetpath = Application.StartupPath + @"\Data.accdb";
        public delegate void DataHandler();
        public event DataHandler search_cmd;
        string UID = "";
        static DataTable DTsearch;
        static DataTable DTpatient;
        public static string patientID = "";
        public static string name = "";
        public static string birthday = "";
        public static string sex = "";
        public static bool patientSearchFlag = false;
        //        DataSet ds;
        //        static int cnt = 0;

        public DataTable search
        {
            get
            {
                return DTsearch;
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {
            FrmSizeSet();
            UID = DataConn.LoginID;
            statusbar1.Text = $"{Data.iUserID} : " + UID;
            this.Text = Data.eSearch;
            txt_PID.Enabled = false;
            txt_name.Enabled = false;
            DT_Sdate.Enabled = false;
            DT_Edate.Enabled = false;
            txt_PID.Text = "";
            txt_name.Text = "";
            DT_Sdate.Value = DateTime.Now.AddDays(-7);
            DT_Edate.Value = DateTime.Now;
            Btn_Confirm.Enabled = false;
            statusbar2.Text = "";
            statusbar2.BackColor = SystemColors.Menu;
            label1.Text = Data.ePatientID;
            label2.Text = Data.eName;
            label3.Text = Data.eStartDate;
            label4.Text = Data.eEndDate;
            if (QCmode) user_chk_0.Enabled = false;
            Btn_Search.Enabled = false;
            Btn_Search.BackgroundImage = ImageLoad.btnSearchBack;
            Btn_Confirm.BackgroundImage = ImageLoad.btndisConfirmBack;
            Btn_close.BackgroundImage = ImageLoad.btnCloseBack;
            btn_reset.BackgroundImage = ImageLoad.btnResetBack;
            this.BackgroundImage = ImageLoad.loginBack;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            DBtableLoad("DB_Patient");
        }

        private void FrmSizeSet()
        {
            DT_Sdate.Left = 186;
            DT_Sdate.Top = 138;
            DT_Sdate.Width = 116;
            DT_Sdate.Height = 27;
            txt_name.Left = 186;
            txt_name.Top = 104;
            txt_name.Width = 116;
            txt_name.Height = 27;
            label3.Left = 52;
            label3.Top = 137;
            label3.Width = 116;
            label3.Height = 25;
            label2.Left = 52;
            label2.Top = 103;
            label2.Width = 116;
            label2.Height = 25;
            label1.Left = 52;
            label1.Top = 68;
            label1.Width = 116;
            label1.Height = 25;
            DBGrid_user.Left = 368;
            DBGrid_user.Top = 8;
            DBGrid_user.Width = 404;
            DBGrid_user.Height = 375;
            txt_PID.Left = 186;
            txt_PID.Top = 68;
            txt_PID.Width = 116;
            txt_PID.Height = 27;
            DT_Edate.Left = 186;
            DT_Edate.Top = 171;
            DT_Edate.Width = 116;
            DT_Edate.Height = 27;
            user_chk_1.Left = 19;
            user_chk_1.Top = 159;
            user_chk_1.Width = 15;
            user_chk_1.Height = 15;
            user_chk_0.Left = 19;
            user_chk_0.Top = 93;
            user_chk_0.Width = 15;
            user_chk_0.Height = 15;
            label4.Left = 52;
            label4.Top = 172;
            label4.Width = 116;
            label4.Height = 25;
            statusStrip1.Left = 0;
            statusStrip1.Top = 392;
            statusStrip1.Width = 781;
            statusStrip1.Height = 22;
            statusbar1.Width = 200;
            statusbar1.Height = 17;
            statusbar2.Width = 150;
            statusbar2.Height = 17;
            Btn_Search.Left = 36;
            Btn_Search.Top = 212;
            Btn_Search.Width = 118;
            Btn_Search.Height = 43;
            btn_reset.Left = 184;
            btn_reset.Top = 212;
            btn_reset.Width = 118;
            btn_reset.Height = 43;
            Btn_Confirm.Left = 36;
            Btn_Confirm.Top = 327;
            Btn_Confirm.Width = 118;
            Btn_Confirm.Height = 43;
            Btn_close.Left = 184;
            Btn_close.Top = 327;
            Btn_close.Width = 118;
            Btn_close.Height = 43;
            this.Width = 797;
            this.Height = 453;

        }

        public void DBtableLoad(string tableName)
        {

            try
            {
                if (!DataConn.IsConn())
                {
                    DataTable dt;
                    //                    string DB_path = targetpath;
                    dt = DataConn.GetDataTable(tableName);

                    DBGrid_user.DataSource = dt;
                    DBGrid_user.MultiSelect = false;
                    DBGrid_user.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DBGrid_user.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                    DBGrid_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    DBGrid_user.ReadOnly = true;
                    DBGrid_user.RowHeadersVisible = false;
                    DBGrid_user.AllowUserToAddRows = false;
                    DBGrid_user.Columns[0].HeaderText = Data.ePatientID;
                    DBGrid_user.Columns[1].HeaderText = Data.eName;
                    DBGrid_user.Columns[2].HeaderText = Data.eBirthday;
                    DBGrid_user.Columns[3].HeaderText = Data.eSex;
                    DBGrid_user.Update();
                    DBGrid_user.Refresh();
                }
                else
                {
                    DataConn.CloseDB();
                    DBtableLoad(tableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void user_chk_0_CheckedChanged(object sender, EventArgs e)
        {
            if (user_chk_0.Checked)
            {
                txt_PID.Enabled = true;
                txt_name.Enabled = true;
                Btn_Search.Enabled = true;
            }
            else
            {
                txt_PID.Enabled = false;
                txt_name.Enabled = false;
                statusbar2.Text = "";
                statusbar2.BackColor = SystemColors.Menu;
                DBtableLoad("DB_Patient");
                if (!user_chk_1.Checked) Btn_Search.Enabled = false;
            }
        }


        private void user_chk_1_CheckedChanged(object sender, EventArgs e)
        {
            if (user_chk_1.Checked)
            {
                DT_Sdate.Enabled = true;
                DT_Edate.Enabled = true;
                Btn_Search.Enabled = true;
            }
            else
            {
                DT_Sdate.Enabled = false;
                DT_Edate.Enabled = false;
                DT_Sdate.Value = DateTime.Now.AddDays(-7);
                DT_Edate.Value = DateTime.Now;
                statusbar2.Text = "";
                statusbar2.BackColor = SystemColors.Menu;
                if (!user_chk_0.Checked) Btn_Search.Enabled = false;
            }
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            string sql;

            if (Resultmode == 0)
            {
                if (user_chk_0.Checked)
                {
                    if (!user_chk_1.Checked)
                    {
                        //if (UID == "Admin") sql = $" SELECT * FROM DB_Result WHERE PatientID = '" + txt_PID.Text + "'";
                        //                    else sql = $" SELECT * FROM DB_Result WHERE StrComp(UID,'" + UID + "',0)=0 AND PatientID = '" + txt_PID.Text + "'";
                        if (UID == "Admin") sql = $"DB_Result WHERE PatientID = '" + txt_PID.Text + "'";
                        else sql = $"DB_Result WHERE StrComp(UID,'" + UID + "',0)=0 AND PatientID = '" + txt_PID.Text + "'";
                    }
                    else
                    {
                        if (UID == "Admin") sql = $"DB_Result WHERE (TestDate BETWEEN '{DT_Sdate.Value.ToString("yyyy-MM-dd")}%' AND '{DT_Edate.Value.ToString("yyyy-MM-dd")}%') AND PatientID = '" + txt_PID.Text + "'";
                        else sql = $"DB_Result WHERE (TestDate BETWEEN '{DT_Sdate.Value.ToString("yyyy-MM-dd")}%' AND '{DT_Edate.Value.ToString("yyyy-MM-dd")}%') AND StrComp(UID,'" + UID + "',0)=0 AND PatientID = '" + txt_PID.Text + "'";
                    }
                    DTsearch = DataConn.GetDataTable(sql);
                    Console.WriteLine(sql);
                    DataHandler handler = search_cmd;
                    handler?.Invoke();
                    this.Hide();
                }
                else
                {

                    if (user_chk_1.Checked)
                    {
                        DataHandler handler = search_cmd;
                        handler?.Invoke();
                        this.Hide();
                    }
                    else
                    {
                        statusbar2.Text = "DB Error";
                        statusbar2.BackColor = Data.PinkColor;
                    }
                }
            }
            else
            {   //220407 Start
                //220412 Start
                //220407 Start
                //220412 Start
                //220407 Start
                string filterExpression;
                DataTable dt = DTsearch.Copy();
                dt.Rows.Clear();
                DataRow[] dr;
                if (user_chk_0.Checked)
                {
                    filterExpression = $"T1.PatientID = '{txt_PID.Text}'";
                    dr = DTsearch.Select(filterExpression);
                }
                else
                {
                    //                    filterExpression = $"PatientID = '{txt_PID.Text}'";
                    dr = DTsearch.Select();
                }
                //220412 End
                for (int i = 0; i < dr.Length; i++)
                {
                    dt.ImportRow(dr[i]);
                }
                DTsearch = dt;
                //220407 End
                DataHandler handler = search_cmd;
                handler?.Invoke();
                this.Hide();
            }

        }



        private void Btn_search_Click(object sender, EventArgs e)
        {
            string sql = "";
            string name = txt_name.Text;
            string patientID = txt_PID.Text;
            string startDate = DT_Sdate.Value.AddDays(-1).ToString("yyyy-MM-dd");
            string endDate = DT_Edate.Value.ToString("yyyy-MM-dd");
            //if (!QCmode && Resultmode == 0)
            if (Resultmode == 0)
            {
                if (user_chk_0.Checked)
                {
                    if (!user_chk_1.Checked)
                    {
                        if (UID == "Admin") sql = $"DB_Result As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%'";//220404
                        else sql = $"DB_Result As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND StrComp(T1.UID,'" + UID + "',0)=0";
                        //sql =" SELECT * FROM DB_Result As T1 INNER JOIN DB_Patient As T2 ON(T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%A%' AND T2.PName LIKE '%%' AND(T1.TestDate BETWEEN '2022-02-08' AND '2022-02-15') AND StrComp(T1.UID, 'Lee', 0) = 0";

                    }
                    else
                    {
                        if (startDate == endDate)
                        {
                            if (UID == "Admin") sql = $"DB_Result As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND T1.TestDate LIKE '{startDate}%'";//220404
                            else sql = $"DB_Result As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND T1.TestDate LIKE '{startDate}%' AND StrComp(T1.UID,'" + UID + "',0)=0";
                        }
                        else
                        {
                            if (UID == "Admin") sql = $"DB_Result As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND (T1.TestDate BETWEEN '{startDate}%' AND '{endDate}%')";//220404
                            else sql = $"DB_Result As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND (T1.TestDate BETWEEN '{startDate}%' AND '{endDate}%') AND StrComp(T1.UID,'" + UID + "',0)=0";
                        }

                        //sql =" SELECT * FROM DB_Result As T1 INNER JOIN DB_Patient As T2 ON(T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%A%' AND T2.PName LIKE '%%' AND(T1.TestDate BETWEEN '2022-02-08' AND '2022-02-15') AND StrComp(T1.UID, 'Lee', 0) = 0";
                        /*DTsearch = DataConn.GetDataTable(sql);
                        DTpatient = DTsearch.DefaultView.ToTable(false, new string[] { "T1.PatientID", "PName", "Birthday", "Sex" });
                        DBGrid_user.DataSource = DTpatient;
                        DBGrid_user.Columns[0].HeaderText = "PatientID";
                        DBGrid_user.Columns[1].HeaderText = "Name";
                        DBGrid_user.Refresh();*/
                    }
                    //DBGrid_user.DataSource = ds.Tables[0];
                    DTsearch = DataConn.GetDataTable(sql);
                    //DTpatient = DataConn.GetDataTable(sql, true, "T1.PatientID").DefaultView.ToTable(false, new string[] { "T1.PatientID", "PName", "Birthday", "Sex" });
                    //DTpatient = DTsearch.DefaultView.ToTable(false, new string[] { "T1.PatientID", "PName", "Birthday", "Sex" });
                    DTpatient = DTsearch.DefaultView.ToTable(true, new string[] { "T1.PatientID", "PName", "Birthday", "Sex" });

                    DBGrid_user.DataSource = DTpatient;
                    DBGrid_user.Columns[0].HeaderText = Data.ePatientID;
                    DBGrid_user.Columns[1].HeaderText = Data.eName;
                    DBGrid_user.Columns[2].HeaderText = Data.eBirthday;
                    DBGrid_user.Columns[3].HeaderText = Data.eSex;
                    DBGrid_user.Refresh();

                }
                else
                {
                    if (user_chk_1.Checked)
                    {
                        if (startDate == endDate)
                        {
                            if (UID == "Admin") sql = $"DB_Result WHERE TestDate LIKE '{startDate}%'";
                            else sql = $"DB_Result WHERE TestDate  LIKE '{startDate}%' AND StrComp(UID,'" + UID + "',0)=0";
                        }
                        else
                        {
                            if (UID == "Admin") sql = $"DB_Result WHERE TestDate BETWEEN '{startDate}%' AND '{endDate}%'";
                            else sql = $"DB_Result WHERE TestDate BETWEEN '{startDate}%' AND '{endDate}%' AND StrComp(UID,'" + UID + "',0)=0";
                        }
                        //sql += $"* FROM DB_Result WHERE Convert(VARCHAR(10),TestDate,23) BETWEEN '{DT_Sdate.Value.ToString("yyyy-MM-dd")}' AND '{DT_Edate.Value.ToString("yyyy-MM-dd")}'";

                        DTsearch = DataConn.GetDataTable(sql);
                    }
                }
            }
            else         //220404 Start
            {
                if (user_chk_0.Checked)
                {
                    if (!user_chk_1.Checked)
                    {
                        if (Resultmode == 1)
                        {
                            if (UID == "Admin") sql = $"DB_ListResult As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND  T1.Item{Item} > -1";
                            else sql = $"DB_ListResult As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND T1.Item{Item} > -1 AND StrComp(T1.UID,'" + UID + "',0)=0 ";
                            //sql =" SELECT * FROM DB_Result As T1 INNER JOIN DB_Patient As T2 ON(T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%A%' AND T2.PName LIKE '%%' AND(T1.TestDate BETWEEN '2022-02-08' AND '2022-02-15') AND StrComp(T1.UID, 'Lee', 0) = 0";
                        }
                        else
                        {
                            if (UID == "Admin") sql = $"DB_ListResult As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%'";
                            else sql = $"DB_ListResult As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND StrComp(T1.UID,'" + UID + "',0)=0 ";
                        }

                    }
                    else
                    {
                        if (Resultmode == 1)
                        {
                            if (UID == "Admin") sql = $"DB_ListResult As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND (T1.TestDate BETWEEN '{startDate}%' AND '{endDate}%') AND T1.Item{Item} > -1";
                            else sql = $"DB_ListResult As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND (T1.TestDate BETWEEN '{startDate}%' AND '{endDate}%') AND T1.Item{Item} > -1 AND StrComp(T1.UID,'" + UID + "',0)=0";
                        }
                        else
                        {
                            if (UID == "Admin") sql = $"DB_ListResult As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND (T1.TestDate BETWEEN '{startDate}%' AND '{endDate}%')";
                            else sql = $"DB_ListResult As T1 RIGHT OUTER JOIN DB_Patient As T2 ON (T1.PatientID = T2.PatientID) WHERE T1.PatientID LIKE '%{patientID}%' AND T2.PName LIKE '%{name}%' AND (T1.TestDate BETWEEN '{startDate}%' AND '{endDate}%') AND StrComp(T1.UID,'" + UID + "',0)=0";
                        }

                    }
                    DTsearch = DataConn.GetDataTable(sql);
                    //DTpatient = DataConn.GetDataTable(sql, true, "T1.PatientID").DefaultView.ToTable(false, new string[] { "T1.PatientID", "PName", "Birthday", "Sex" });
                    DTpatient = DTsearch.DefaultView.ToTable(true, new string[] { "T1.PatientID", "PName", "Birthday", "Sex" });
                    DBGrid_user.DataSource = DTpatient;
                    DBGrid_user.Columns[0].HeaderText = Data.ePatientID;
                    DBGrid_user.Columns[1].HeaderText = Data.eName;
                    DBGrid_user.Columns[2].HeaderText = Data.eBirthday;
                    DBGrid_user.Columns[3].HeaderText = Data.eSex;
                    DBGrid_user.Refresh();

                }
                else          //220404 End
                {
                    if (user_chk_1.Checked)
                    {
                        string filterExpression;
                        //220405 Start
                        if (Resultmode == 1)
                        {
                            if (UID == "Admin")
                            {
                                if (startDate == endDate)
                                {
                                    filterExpression = $"(Item{Item} > -1 ) AND TestDate LIKE '{startDate}%'";
                                }
                                else
                                {
                                    filterExpression = $"(Item{Item} > -1 ) AND TestDate >= '{startDate}%' AND TestDate <= '{endDate}%'";
                                }
                            }
                            else
                            {
                                if (startDate == endDate)
                                {
                                    filterExpression = $"UID = '{ UID }' AND (Item{Item} > -1 ) AND TestDate LIKE '{startDate}%'";
                                }
                                else
                                {
                                    filterExpression = $"UID = '{ UID }' AND (Item{Item} > -1 ) AND TestDate >= '{startDate}%' AND TestDate <= '{endDate}%'";
                                }
                            }
                            Console.WriteLine($"Resultmode : {Resultmode}, filter{filterExpression}");
                        }
                        else
                        {
                            if (UID == "Admin")
                            {
                                if (startDate == endDate)
                                {
                                    filterExpression = $"TestDate LIKE '{startDate}%'";
                                }
                                else
                                {
                                    filterExpression = $"TestDate >= '{startDate}%' AND TestDate <= '{endDate}%'";
                                }
                            }
                            else
                            {
                                if (startDate == endDate)
                                {
                                    filterExpression = $"UID = '{ UID }' AND TestDate LIKE '{startDate}%'";
                                }
                                else
                                {
                                    filterExpression = $"UID = '{ UID }' AND TestDate >= '{startDate}%' AND TestDate <= '{endDate}%'";
                                }
                            }
                            Console.WriteLine($"Resultmode : {Resultmode}, filter{filterExpression}");
                        }
                        // 220405 End
                        //220407 Start
                        /*
                        DataTable dt = Data.ListResult;
                        dt.Rows.Clear();
                        Data.ListResult = DataConn.GetDataTable("DB_ListResult");
                        DataRow[] dr = Data.ListResult.Select(filterExpression);
                        Console.WriteLine(dr.Length);
                        //dt.Rows.Add(dr);
                        for (int i = 0; i < dr.Length; i++) dt.ImportRow(dr[i]);
                        */
                        DataRow[] dr = DataConn.GetDataTable("DB_ListResult").Select(filterExpression);
                        DTsearch = dr.CopyToDataTable();
                        // dt.DefaultView.Sort = "SEQ ASC";
                        // dt = dt.DefaultView.ToTable(true);

                        //DTsearch = dt;
                        //220407 End
                    }
                }
                Btn_Confirm.Enabled = true;
                //                Btn_Confirm.BackgroundImage = Image.FromFile(Application.StartupPath + "\\IMG\\Btn_confirm_BACK.png");
                Btn_Confirm.BackgroundImage = ImageLoad.btnConfirmBack;
            }
            if (DTsearch != null)
            {
                if (user_chk_0.Checked)
                {
                    statusbar2.Text = $"{Data.iData} : {DTpatient.Rows.Count}";
                }
                else
                {
                    statusbar2.Text = $"{Data.iData} : {DTsearch.Rows.Count}";
                }
                statusbar2.BackColor = Data.PinkColor;
            }
            else
            {
                statusbar2.Text = Data.iDBError;
                statusbar2.BackColor = Data.PinkColor;
            }
            if (DTsearch.Rows.Count > 0)
            {
                Btn_Confirm.Enabled = true;
                Btn_Confirm.BackgroundImage = ImageLoad.btnConfirmBack;
            }
            if (user_chk_0.Checked) patientSearchFlag = true;
            else patientSearchFlag = false;
        }

        private void DBGrid_user_CurrentCellChanged(object sender, EventArgs e)
        {
            if (DBGrid_user.CurrentCell != null)
            {
                if (user_chk_0.Checked)
                {
                    patientID = Convert.ToString(DBGrid_user.Rows[DBGrid_user.CurrentCell.RowIndex].Cells[0].Value);
                    name = Convert.ToString(DBGrid_user.Rows[DBGrid_user.CurrentCell.RowIndex].Cells[1].Value);
                    birthday = Convert.ToString(DBGrid_user.Rows[DBGrid_user.CurrentCell.RowIndex].Cells[2].Value);
                    sex = Convert.ToString(DBGrid_user.Rows[DBGrid_user.CurrentCell.RowIndex].Cells[3].Value);
                    txt_PID.Text = patientID;
                    txt_name.Text = name;
                }
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txt_PID_TextChanged(object sender, EventArgs e)
        {
            string id = txt_PID.Text;
            try
            {
                if (DataConn.IDCheck(id, Data.Patient))
                {
                    for (int i = 0; i < DBGrid_user.Rows.Count; i++)
                    {
                        if (id == DBGrid_user.Rows[i].Cells[0].FormattedValue.ToString())
                        {
                            txt_name.Text = DBGrid_user.Rows[i].Cells[1].FormattedValue.ToString();
                            DBGrid_user.CurrentCell = DBGrid_user.Rows[i].Cells[0];
                        }
                    }
                }
                else
                {
                    txt_name.Text = "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_PID.Text = "";
            txt_name.Text = "";
            user_chk_0.Checked = false;
            user_chk_1.Checked = false;
        }

        private void Frm_Search_Activated(object sender, EventArgs e)
        {
            txt_PID.Text = "";
            txt_name.Text = "";
            user_chk_0.Checked = false;
            user_chk_1.Checked = false;
            DBtableLoad("DB_Patient");
        }

        private void txt_PID_KeyUp(object sender, KeyEventArgs e)
        {
            txt_PID.Text = txt_PID.Text.Replace(" ", "");
            txt_PID.SelectionStart = txt_PID.Text.Length;
            txt_PID.ScrollToCaret();
        }

       
    }
}
