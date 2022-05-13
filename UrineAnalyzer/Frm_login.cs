using System;
using System.Drawing;
using System.Windows.Forms;

namespace UrineAnalyzer
{
    public partial class Frm_login : Form
    {
        static string uid = "";
        public Frm_login()
        {
            InitializeComponent();

        }
        private void Frm_login_Load(object sender, EventArgs e)
        {
            FrmSizeSet();
            this.Text = Data.gLogin;
            label.Text = "";
            lbl_Id.Text = Data.gUserID;
            lbl_PW.Text = Data.gPassword;
            Btn_login.Text = Data.gLogin;
            Btn_Manage.Text = Data.gManagement;
            this.BackgroundImage = ImageLoad.loginBack;
            if (!DataConn.Admincheck())
            {

                // this.Hide();
                Frm_manage frm_Manage = Frm_Main.frm_manage;
                frm_Manage.Owner = this;
                frm_Manage.Show();
            }
        }

        private void FrmSizeSet()
        {
            Txt_Id.Left = 228;
            Txt_Id.Top = 35;
            Txt_Id.Width = 130;
            Txt_Id.Height = 27;
            lbl_Id.Left = 88;
            lbl_Id.Top = 34;
            lbl_Id.Width = 116;
            lbl_Id.Height = 27;
            lbl_PW.Left = 88;
            lbl_PW.Top = 75;
            lbl_PW.Width = 116;
            lbl_PW.Height = 27;
            Txt_PW.Left = 228;
            Txt_PW.Top = 75;
            Txt_PW.Width = 130;
            Txt_PW.Height = 27;
            Btn_login.Left = 88;
            Btn_login.Top = 155;
            Btn_login.Width = 105;
            Btn_login.Height = 35;
            label.Left = 88;
            label.Top = 108;
            label.Width = 37;
            label.Height = 19;
            Btn_Manage.Left = 253;
            Btn_Manage.Top = 154;
            Btn_Manage.Width = 105;
            Btn_Manage.Height = 35;
            this.Width = 441;
            this.Height = 254;

        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataConn.Logincheck(Txt_Id.Text, Txt_PW.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    uid = Txt_Id.Text;
                    DataConn.LoginID = uid;
                    this.Hide();
                }
                else
                {
                    label.ForeColor = Color.Red;
                    label.Text = $"{Data.gWrongError1} \n {Data.gWrongError2}";
                    label.BackColor = Color.White;
                    //this.DialogResult = DialogResult.Retry;  //220421_2
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void Txt_Id_TextChanged(object sender, EventArgs e)
        {
            label.Text = "";
        }

        private void Txt_PW_TextChanged(object sender, EventArgs e)
        {
            label.Text = "";
        }

        private void Txt_PW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_login_Click(sender, e);
                Btn_login.Select();
            }
        }

        private void Btn_Manage_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataConn.Logincheck("Admin", Txt_PW.Text))
                {
                    DataConn.LoginID = uid;
                    Frm_manage frm_Manage = new Frm_manage();
                    frm_Manage.Owner = this;
                    frm_Manage.ShowDialog();
                }
                else
                {
                    label.ForeColor = Color.Red;
                    label.Text = Data.gWrongError1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Frm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
                Environment.Exit(0);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            /*
            if (uid == "")
            {
                 Application.Exit();
                Environment.Exit(0);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            else
            {
                this.Hide();
            }*/
        }

        private void Txt_Id_KeyUp(object sender, KeyEventArgs e)
        {
            Txt_Id.Text = Txt_Id.Text.Replace(" ", "");
            Txt_Id.SelectionStart = Txt_Id.Text.Length;
            Txt_Id.ScrollToCaret();
        }
    }
}
