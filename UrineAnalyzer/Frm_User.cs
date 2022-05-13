using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace UrineAnalyzer
{

    public partial class Frm_User : Form
    {
        //        static SerialConnect S_connect = new SerialConnect();
        //        static Frm_Result frmResult = Frm_Main.frmResult;
        //        static Frm_Setting frmSetting = Frm_Main.frmSetting;
        static Panel panel;//220408
        public Frm_User()
        {
            DoubleBuffered = true;
            InitializeComponent();
            panel = new Panel();//220408
            Top_set();
            this.DBGrid_user.RowHeadersVisible = false;
        }
        //        public string targetpath = Application.StartupPath + @"\Data.accdb";
        public string UserID;

        private void Form_User_Load(object sender, EventArgs e)
        {
            FrmSizeSet();
            this.Text = Data.aUrineAnalyzer;
            btn_save.BackgroundImage = ImageLoad.btnSaveBack;
            StatusBar1.Text = Data.StatusData;
            StatusBar2.Text = $"{Data.iUserID} : " + DataConn.LoginID;
            UserID = DataConn.LoginID;
            lbl_Id.Text = Data.bPatientID;
            lbl_name.Text = Data.bName;
            lbl_bth.Text = Data.bBirthday;
            lbl_sex.Text = Data.bSex;
            cb_sex.Items.Add(Data.bMale);
            cb_sex.Items.Add(Data.bFemale);
            User_reset();
            DBtableLoad();

        }

        private void FrmSizeSet()
        {
            Txt_Id.Left = 334;
            Txt_Id.Top = 155;
            Txt_Id.Width = 130;
            Txt_Id.Height = 27;
            lbl_Id.Left = 202;
            lbl_Id.Top = 154;
            lbl_Id.Width = 116;
            lbl_Id.Height = 27;
            lbl_name.Left = 202;
            lbl_name.Top = 195;
            lbl_name.Width = 116;
            lbl_name.Height = 27;
            Txt_name.Left = 334;
            Txt_name.Top = 195;
            Txt_name.Width = 130;
            Txt_name.Height = 27;
            lbl_bth.Left = 202;
            lbl_bth.Top = 238;
            lbl_bth.Width = 116;
            lbl_bth.Height = 27;
            lbl_sex.Left = 202;
            lbl_sex.Top = 281;
            lbl_sex.Width = 116;
            lbl_sex.Height = 27;
            DBGrid_user.Left = 538;
            DBGrid_user.Top = 154;
            DBGrid_user.Width = 404;
            DBGrid_user.Height = 724;
            cb_sex.Left = 334;
            cb_sex.Top = 281;
            cb_sex.Width = 130;
            cb_sex.Height = 27;
            Udtpicker.Left = 334;
            Udtpicker.Top = 239;
            Udtpicker.Width = 130;
            Udtpicker.Height = 27;
            statusStrip1.Left = 0;
            statusStrip1.Top = 919;
            statusStrip1.Width = 1134;
            statusStrip1.Height = 22;
            StatusBar1.Width = 250;
            StatusBar1.Height = 17;
            StatusBar2.Width = 250;
            StatusBar2.Height = 17;
            btn_save.Left = 199;
            btn_save.Top = 321;
            btn_save.Width = 118;
            btn_save.Height = 43;
            this.Width = 1150;
            this.Height = 980;
        }
        public void Status()
        {
            StatusBar1.Text = Data.StatusData;
        }

        public void User_reset()
        {
            Txt_Id.Text = "";
            Txt_name.Text = "";
            Udtpicker.Value = DateTime.Now;
            cb_sex.SelectedIndex = 0;

        }

        public void DBtableLoad()
        {
            DataTable dt = Data.Patient.DefaultView.ToTable(false, new string[] { "PatientID", "PName", "Birthday", "Sex" });
            if (dt.Columns.Count > 0)
            {
                DBGrid_user.DataSource = dt;
                DBGrid_user.MultiSelect = false;
                DBGrid_user.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DBGrid_user.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                DBGrid_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                DBGrid_user.ReadOnly = true;
                DBGrid_user.AllowUserToAddRows = false;
                DBGrid_user.Columns[0].HeaderText = Data.bPatientID;
                DBGrid_user.Columns[1].HeaderText = Data.bName;
                DBGrid_user.Columns[2].HeaderText = Data.bBirthday;
                DBGrid_user.Columns[3].HeaderText = Data.bSex;
                DBGrid_user.Update();
                DBGrid_user.Refresh();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string patientID = Txt_Id.Text;
                string filterExpression = $"PatientID = '{patientID}'";
                DataRow[] row = Data.Patient.Select(filterExpression);
                Console.WriteLine("Cnt:" + row.Length);
                DataRow dr = Data.Patient.NewRow();
                if (row.Length > 0)
                {
                    //Data.Patient.Rows.Remove(dr[0]);
                    dr["PatientID"] = Txt_Id.Text;
                    dr["PName"] = Txt_name.Text;
                    dr["Birthday"] = Udtpicker.Text;
                    //Console.WriteLine(Data.PatientRow["Birthday"].GetType().ToString());
                    dr["Sex"] = cb_sex.Text;
                    //                    Data.Patient.Rows.Remove(Data.PatientRow);
                    DataConn.DeleteData(Data.Patient, row[0]);
                    DataConn.InsertData(Data.Patient, dr);
                    DataConn.GetDataCommit();

                    //Data.Patient.Rows.Add(Data.PatientRow);
                    //Data.Patient.AcceptChanges();
                    MessageBox.Show(Data.bWorning);
                }
                else
                {
                    dr["PatientID"] = Txt_Id.Text;
                    dr["PName"] = Txt_name.Text;
                    dr["Birthday"] = Udtpicker.Text;
                    dr["Sex"] = cb_sex.Text;
                    DataConn.InsertData(Data.Patient, dr);
                    DataConn.GetDataCommit();

                    //Data.Patient.Rows.Add(Data.PatientRow);
                }
                //                DBtableLoad();
                DBGrid_user.DataSource = Data.Patient;
                DBGrid_user.Columns[0].HeaderText = Data.bPatientID;
                DBGrid_user.Columns[1].HeaderText = Data.bName;
                DBGrid_user.Columns[2].HeaderText = Data.bBirthday;
                DBGrid_user.Columns[3].HeaderText = Data.bSex;
                DBGrid_user.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                // Top_btn[idx].BorderStyle = BorderStyle.FixedSingle;
                left += 93;

                panel.Controls.Add(Top_btn[idx]);

            }
            Top_btn[0].BackgroundImage = ImageLoad.btnUserTopBack;
            Top_btn[1].BackgroundImage = ImageLoad.btnResultTopBack;
            Top_btn[2].BackgroundImage = ImageLoad.btnSetTopBack;
            Top_btn[3].BackgroundImage = ImageLoad.btnLogoutTopBack;
            Top_btn[4].BackgroundImage = ImageLoad.btnCloseTopBack;

            panel.BackgroundImage = ImageLoad.patientBack;
            panel.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;

            tt_user.SetToolTip(Top_btn[0], Data.bPatient);
            tt_result.SetToolTip(Top_btn[1], Data.cResult);
            tt_Set.SetToolTip(Top_btn[2], Data.dSetting);
            tt_logout.SetToolTip(Top_btn[3], Data.jLogout);
            tt_close.SetToolTip(Top_btn[4], Data.kClose);

            Top_btn[0].Enabled = true;
            Top_btn[1].Click += new System.EventHandler(Top_btn_1_Click);
            Top_btn[2].Click += new System.EventHandler(Top_btn_2_Click);
            Top_btn[3].Click += new System.EventHandler(Top_btn_3_Click);
            Top_btn[4].Click += new System.EventHandler(Top_btn_4_Click);
            Top_btn[0].Focus();//220407
        }

        private void Top_btn_1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Main.frmResult.Show();
        }

        private void Top_btn_2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\SettingProgram.exe");
            Application.Exit();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Top_btn_3_Click(object sender, EventArgs e)
        {
            //220408 START
            Frm_Main.DisposeForm();
            Frm_Main frm_Main = new Frm_Main();
            frm_Main.Show();
            Frm_Main.LoadForm();
            //            Frm_Main.Form_Main_Load(sender, e);
            //            System.Diagnostics.Process.Start(Application.StartupPath + @"\frmrestart.exe");
            //220408 END
        }
        private void Top_btn_4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void DBGrid_user_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Txt_Id.Text = DBGrid_user.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                Txt_name.Text = DBGrid_user.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                string date = DBGrid_user.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                Udtpicker.Value = Convert.ToDateTime(date);
                cb_sex.SelectedItem = DBGrid_user.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            }
        }

        private void Form_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Txt_Id_TextChanged(object sender, EventArgs e)
        {
            string id = Txt_Id.Text;

            if (DataConn.IDCheck(id, Data.Patient))
            {
                for (int i = 0; i < DBGrid_user.Rows.Count; i++)
                {
                    if (id == DBGrid_user.Rows[i].Cells[0].FormattedValue.ToString())
                    {
                        Txt_name.Text = DBGrid_user.Rows[i].Cells[1].FormattedValue.ToString();
                        string date = DBGrid_user.Rows[i].Cells[2].FormattedValue.ToString();
                        Udtpicker.Value = Convert.ToDateTime(date);
                        cb_sex.SelectedItem = DBGrid_user.Rows[i].Cells[3].FormattedValue.ToString();
                        DBGrid_user.CurrentCell = DBGrid_user.Rows[i].Cells[0];
                    }
                }
            }
            else
            {
                Txt_name.Text = "";
                Udtpicker.Value = DateTime.Now;
                cb_sex.SelectedIndex = 0;
            }
        }

        private void Txt_Id_KeyUp(object sender, KeyEventArgs e)
        {
            Txt_Id.Text = Txt_Id.Text.Replace(" ", "");
            Txt_Id.SelectionStart = Txt_Id.Text.Length;
            Txt_Id.ScrollToCaret();
        }

       
    }


}











