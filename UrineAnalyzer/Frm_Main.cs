using System;
using System.Drawing;
using System.Windows.Forms;


namespace UrineAnalyzer
{
    public partial class Frm_Main : Form
    {

        public bool chk_result = false;
        //220408 START
        public static Frm_User frmUser;
        public static Frm_listset frmlistset;
        public static Frm_Result frmResult;
        public static Frm_login frm_Login;
        public static Frm_manage frm_manage;
        public static Frm_Search frmSearch;
        //220408 END
        public static Color Neg_back;
        public static Color Neg_fore;
        public static Color Pos_back;
        public static Color Pos_fore;
        public static int Unit;
        public static int SerialType;
        public static int BaudRate;
        //220408 START
        public static void LoadForm()
        {
            frmUser = new Frm_User();
            frmlistset = new Frm_listset();
            frmResult = new Frm_Result();
            frm_Login = new Frm_login();
            frm_manage = new Frm_manage();
            frmSearch = new Frm_Search();
        }
        public static void DisposeForm()
        {

            frmUser.Dispose();
            frmlistset.Dispose();
            frmResult.Dispose();
            frm_Login.Dispose();
            frm_manage.Dispose();
            frmSearch.Dispose();
            GC.SuppressFinalize(frmUser);
            GC.SuppressFinalize(frmlistset);
            GC.SuppressFinalize(frmResult);
            GC.SuppressFinalize(frm_Login);
            GC.SuppressFinalize(frm_manage);
            GC.SuppressFinalize(frmSearch);
        }
        //220408 END
        public Frm_Main()
        {
            InitializeComponent();
            FrmSizeSet();
            DoubleBuffered = true;
            if (Data.Get_SerialType == Data.USB)
            {
                USBConnect.Status_cmd += new USBConnect.StatusHandler(Status);
                USBConnect.Pf_cmd += new USBConnect.PFHandler(Chk_pf); //220413
                USBConnect.connect_cmd += new USBConnect.ConnectHandler(ConncetLoad);
            }
            else
            {
                SerialConnect.Status_cmd += new SerialConnect.StatusHandler(Status);
                SerialConnect.Pf_cmd += new SerialConnect.PFHandler(Chk_pf); //220413
                SerialConnect.connect_cmd += new SerialConnect.ConnectHandler(ConncetLoad);
            }
            //220408 START
            Btn_Patient.BackgroundImage = ImageLoad.btnPatientBack;
            Btn_result.BackgroundImage = ImageLoad.btnResultBack;
            Btn_set.BackgroundImage = ImageLoad.btnSetBack;
            this.BackgroundImage = ImageLoad.mainBack;
            this.Text = Data.aUrineAnalyzer;
            //220408 END

            //220413 Start
            panel_conncet.Visible = false;
            if (!Data.chk_Pf)
            {
                Btn_Patient.Visible = false;
                Btn_result.Visible = false;
                Btn_set.Visible = false;
            }
            //220413 End
        }
        private void FrmSizeSet()
        {
            statusStrip1.Left = 0;
            statusStrip1.Top = 760;
            statusStrip1.Width = 955;
            statusStrip1.Height = 22;
            statusBar1.Width = 205;
            statusBar1.Height = 17;
            toolStripStatusLabel1.Width = 0;
            toolStripStatusLabel1.Height = 17;
            statusBar2.Width = 250;
            statusBar2.Height = 17;
            panel_conncet.Left = 226;
            panel_conncet.Top = 187;
            panel_conncet.Width = 422;
            panel_conncet.Height = 416;
            lbl_baud.Left = 174;
            lbl_baud.Top = 345;
            lbl_baud.Width = 60;
            lbl_baud.Height = 26;
            lbl_inter.Left = 174;
            lbl_inter.Top = 318;
            lbl_inter.Width = 86;
            lbl_inter.Height = 26;
            label2.Left = 33;
            label2.Top = 345;
            label2.Width = 140;
            label2.Height = 26;
            label1.Left = 33;
            label1.Top = 318;
            label1.Width = 140;
            label1.Height = 26;
            Btn_result.Left = 376;
            Btn_result.Top = 45;
            Btn_result.Width = 204;
            Btn_result.Height = 410;
            Btn_Patient.Left = 122;
            Btn_Patient.Top = 45;
            Btn_Patient.Width = 204;
            Btn_Patient.Height = 410;
            Btn_set.Left = 630;
            Btn_set.Top = 45;
            Btn_set.Width = 204;
            Btn_set.Height = 410;
            this.Width = 971;
            this.Height = 821;

        }

        public static void Form_Main_Load(object sender, EventArgs e)
        {
            if (Data.Get_SetStart) Btn_set_Click(sender, e); //220414
            else
            {
                
                LoadForm();//220408
                DialogResult result = frm_Login.ShowDialog();

                if (DataConn.LoginID != "")
                {
                    if (Data.Get_SerialType == Data.USB)
                    {
                        //SerialConnect.SerialStart();
                        USBConnect.USBStart();
                    }
                    else
                    {
                        SerialConnect.SerialStart();
                    }


                    // Get_SET();
                }
                statusBar2.Text = $"{Data.iUserID} : " + DataConn.LoginID;

            }


        }

        /*   private void Get_SET()
           {
               Data.Set = DataConn.GetDataTable("DB_Set");
               DataRow row = Data.Set.Rows[0];
               Neg_fore = Color.FromArgb(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToInt32(row[2]));
               Neg_back = Color.FromArgb(Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), Convert.ToInt32(row[5]));
               Pos_fore = Color.FromArgb(Convert.ToInt32(row[6]), Convert.ToInt32(row[7]), Convert.ToInt32(row[8]));
               Pos_back = Color.FromArgb(Convert.ToInt32(row[9]), Convert.ToInt32(row[10]), Convert.ToInt32(row[11]));
               Unit = Convert.ToInt32(row[12]);
               SerialType = Convert.ToInt32(row[13]);
               BaudRate = Convert.ToInt32(row[14]);
           }*/

        //220413 Start

        private void ConncetLoad()
        {
            //  if (Data.Get_SerialType == Data.USB)
            {
                if (Btn_Patient.InvokeRequired)
                {
                    Btn_Patient.Invoke(new Action(delegate ()
                    {
                        Btn_Patient.Visible = true;
                    }));
                }
                if (Btn_result.InvokeRequired)
                {
                    Btn_result.Invoke(new Action(delegate ()
                    {
                        Btn_result.Visible = true;
                    }));
                }
                if (Btn_set.InvokeRequired)
                {
                    Btn_set.Invoke(new Action(delegate ()
                    {
                        Btn_set.Visible = true;
                    }));
                }
                this.BackgroundImage = ImageLoad.mainBack;
                if (panel_conncet.InvokeRequired)
                {
                    panel_conncet.Invoke(new Action(delegate ()
                    {
                        panel_conncet.Visible = false;
                    }));
                }
            }
            /*else
            {
                Btn_Patient.Visible = true;
                Btn_result.Visible = true;
                Btn_set.Visible = true;
                this.BackgroundImage = ImageLoad.mainBack;
                panel_conncet.Visible = false;
            }*/


        }

        public void Chk_pf()
        {
            if (Data.Get_SerialType == Data.USB)
            {
                if (Btn_Patient.InvokeRequired)
                {
                    Btn_Patient.Invoke(new Action(delegate ()
                    {
                        Btn_Patient.Visible = false;
                    }));
                }
                if (Btn_result.InvokeRequired)
                {
                    Btn_result.Invoke(new Action(delegate ()
                    {
                        Btn_result.Visible = false;
                    }));
                }
                if (Btn_set.InvokeRequired)
                {
                    Btn_set.Invoke(new Action(delegate ()
                    {
                        Btn_set.Visible = false;
                    }));
                }
                this.BackgroundImage = ImageLoad.DisMainBack;
                if (panel_conncet.InvokeRequired)
                {
                    panel_conncet.Invoke(new Action(delegate ()
                    {
                        panel_conncet.Visible = true;
                        panel_conncet.BackgroundImage = ImageLoad.connectBack;
                        label1.Text = $"{Data.dInterface} :";
                        label2.Text = $"{Data.dBaudrate} :";
                        if (Data.Get_SerialType == Data.USB) lbl_inter.Text = Data.dUSB;
                        else lbl_inter.Text = $"{Data.dRS232} ({Data.portName})";

                        switch (Data.Get_BaudRate)
                        {
                            case 0:
                                lbl_baud.Text = "9600";
                                break;
                            case 1:
                                lbl_baud.Text = "38400";
                                break;
                            case 2:
                                lbl_baud.Text = "115200";
                                break;
                        }
                    }));
                }
            }
            else
            {
                Btn_Patient.Visible = false;
                Btn_result.Visible = false;
                Btn_set.Visible = false;
                this.BackgroundImage = ImageLoad.DisMainBack;
                panel_conncet.Visible = true;
                panel_conncet.BackgroundImage = ImageLoad.connectBack;
                label1.Text = $"{Data.dInterface} :";
                label2.Text = $"{Data.dBaudrate} :";
                if (Data.Get_SerialType == Data.USB) lbl_inter.Text = Data.dUSB;
                else lbl_inter.Text = $"{Data.dRS232} ({Data.portName})";

                switch (Data.Get_BaudRate)
                {
                    case 0:
                        lbl_baud.Text = "9600";
                        break;
                    case 1:
                        lbl_baud.Text = "38400";
                        break;
                    case 2:
                        lbl_baud.Text = "115200";
                        break;
                }
            }


        }

        //220413 End
        public void Status()
        {
            statusBar1.Text = Data.StatusData;
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke(new Action(delegate ()
                {
                    if (Data.StatusData == Data.iReceivingData) statusBar1.BackColor = Data.PinkColor;
                    else statusBar1.BackColor = SystemColors.Control;
                }));
            }
        }
        public void Btn_user_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUser.Show();
        }

        public void Btn_result_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmResult.Show();
        }

        public static void Btn_set_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\SettingProgram.exe");
            Application.Exit();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Data.UpdateDB();
            Application.Exit();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        
    }
}





