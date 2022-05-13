using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace UrineAnalyzer
{
    public partial class Frm_manage : Form
    {
        public bool registrationFlag = false;//220406_4
        public Frm_manage()
        {
            InitializeComponent();
        }

        private void Frm_manage_Load(object sender, EventArgs e)
        {
            FrmSizeSet();
            this.Text = Data.hManagement;
            Btn_regi.Text = Data.hRegistration;
            label1.Text = Data.hUserID;
            label2.Text = Data.hPassword;
            label3.Text = Data.hConfirmPassword;
            label4.Text = Data.hName;
            label5.Text = Data.hBirthday;
            Btn_save.Text = Data.hSave;
            Btn_cancel.Text = Data.hCancel;
            btn_delete.Text = Data.hDelete;

            labelbar2.Text = "";
            this.BackgroundImage = ImageLoad.mainBack;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            if (!DataConn.Admincheck())
            {
                txt_Rid.Text = "Admin";
                txt_Rid.ReadOnly = true;
                Btn_regi.BackColor = Data.SysColor;
                registrationFlag = true;
                btn_delete.Enabled = false;
            }
            else
            {
                Btn_regi_Click(sender, e);//220406_3
            }

            DBtableLoad();
        }
        private void FrmSizeSet()
        {
            Btn_regi.Left = 326;
            Btn_regi.Top = 29;
            Btn_regi.Width = 126;
            Btn_regi.Height = 40;
            User_data.Left = 44;
            User_data.Top = 51;
            User_data.Width = 249;
            User_data.Height = 341;
            labelbar2.Left = 322;
            labelbar2.Top = 300;
            labelbar2.Width = 57;
            labelbar2.Height = 19;
            DT_RBD.Left = 518;
            DT_RBD.Top = 251;
            DT_RBD.Width = 130;
            DT_RBD.Height = 26;
            dateTimePicker1.Left = 612;
            dateTimePicker1.Top = 371;
            dateTimePicker1.Width = 0;
            dateTimePicker1.Height = 21;
            label5.Left = 322;
            label5.Top = 251;
            label5.Width = 166;
            label5.Height = 27;
            txt_RPW.Left = 518;
            txt_RPW.Top = 130;
            txt_RPW.Width = 130;
            txt_RPW.Height = 27;
            label2.Left = 322;
            label2.Top = 130;
            label2.Width = 166;
            label2.Height = 27;
            label1.Left = 322;
            label1.Top = 91;
            label1.Width = 166;
            label1.Height = 27;
            txt_Rid.Left = 518;
            txt_Rid.Top = 91;
            txt_Rid.Width = 130;
            txt_Rid.Height = 27;
            Btn_cancel.Left = 453;
            Btn_cancel.Top = 341;
            Btn_cancel.Width = 80;
            Btn_cancel.Height = 42;
            Btn_save.Left = 336;
            Btn_save.Top = 341;
            Btn_save.Width = 80;
            Btn_save.Height = 42;
            txt_Rname.Left = 518;
            txt_Rname.Top = 209;
            txt_Rname.Width = 130;
            txt_Rname.Height = 27;
            label4.Left = 322;
            label4.Top = 209;
            label4.Width = 166;
            label4.Height = 27;
            label3.Left = 322;
            label3.Top = 169;
            label3.Width = 166;
            label3.Height = 27;
            txt_RPW2.Left = 518;
            txt_RPW2.Top = 169;
            txt_RPW2.Width = 130;
            txt_RPW2.Height = 27;
            btn_delete.Left = 568;
            btn_delete.Top = 341;
            btn_delete.Width = 80;
            btn_delete.Height = 42;
            this.Width = 735;
            this.Height = 468;

        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            string insert_query;

            string password = EncryptionHelper.EncryptionSHA256(txt_RPW.Text);

            if (txt_RPW.Text == txt_RPW2.Text)
            {
                if (registrationFlag) //220406_4
                {
                    if (txt_Rid.Text != "Admin")
                    {
                        insert_query = "INSERT INTO DB_User VALUES(" + User_data.RowCount + 1 + ",'" + txt_Rid.Text + "', '" + password + "','" + txt_Rname.Text + "','" + DT_RBD.Value.ToString("yyyy-MM-dd") + "', 0 )";
                    }
                    else
                    {
                        insert_query = "INSERT INTO DB_User VALUES(1,'" + txt_Rid.Text + "', '" + password + "','" + txt_Rname.Text + "','" + DT_RBD.Value.ToString("yyyy-MM-dd") + "', 1 )";
                    }
                }
                else
                {
                    insert_query = "UPDATE DB_User SET PW = '" + password + "', Uname = '" + txt_Rname.Text + "', Birthday = '" + DT_RBD.Value.ToString("yyyy-MM-dd") + "' WHERE ID = '" + txt_Rid.Text + "'";
                }

                try
                {
                    DataConn.Getdata(insert_query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                if (txt_Rid.ReadOnly) txt_Rid.ReadOnly = false;

                DBtableLoad();
                txt_reset();
                //Btn_regi.BackColor = SystemColors.Menu;

            }
            else
            {
                labelbar2.ForeColor = Color.Red;
                labelbar2.Text = Data.hWrongError1;
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            txt_reset();
            this.Close();
        }

        private void txt_reset()
        {
            txt_Rid.ReadOnly = false;
            txt_Rid.Text = "";
            txt_RPW.Text = "";
            txt_RPW2.Text = "";
            txt_Rname.Text = "";
            DT_RBD.Value = DateTime.Now;
            labelbar2.Text = "";
            //Btn_regi.BackColor = SystemColors.Menu;
        }


        public void DBtableLoad()
        {
            try
            {
                if (!DataConn.IsConn())
                {
                    string sql = "DB_User";
                    DataTable dt = DataConn.GetDataTable(sql);
                    DataTable dt2 = dt.DefaultView.ToTable(false, new string[] { "ID", "UName", "Birthday" });

                    User_data.DataSource = dt2;
                    User_data.MultiSelect = false;
                    User_data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    User_data.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                    User_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    User_data.RowHeadersVisible = false;
                    User_data.AllowUserToAddRows = false;
                    User_data.ReadOnly = true;
                    User_data.Columns[0].HeaderText = Data.hID;
                    User_data.Columns[1].HeaderText = Data.hName;
                    User_data.Columns[2].HeaderText = Data.hBirthday;
                    User_data.Update();
                    User_data.Refresh();
                }
                else
                {
                    DataConn.CloseDB();
                    DBtableLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_regi_Click(object sender, EventArgs e)
        {
            //220406_4 Start
            if (registrationFlag)
            {
                registrationFlag = false;
                txt_Rid.Enabled = false;
                txt_RPW.Enabled = true;
                txt_RPW2.Enabled = true;
                txt_Rname.Enabled = true;
                Btn_regi.BackColor = SystemColors.Menu;
                User_data.Enabled = true;
                btn_delete.Enabled = true;
            }
            else
            {
                registrationFlag = true;
                txt_Rid.Enabled = true;
                txt_RPW.Enabled = true;
                txt_RPW2.Enabled = true;
                txt_Rname.Enabled = true;
                Btn_regi.BackColor = Data.SysColor;
                User_data.Enabled = false;
                btn_delete.Enabled = false;
            }
            txt_reset();
            /*
                        if (Btn_regi.BackColor == SystemColors.Menu)
                        {
                            Btn_regi.BackColor = Data.SysColor;
                            txt_reset();
                        }
                        else
                        {
                            Btn_regi.BackColor = SystemColors.Menu;
                        }
            220406_4 End            */
        }

        private void User_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_Rid.Text = User_data.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txt_Rname.Text = User_data.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                DT_RBD.Value = Convert.ToDateTime(User_data.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
            }

            if (txt_Rid.Text == "Admin")
            {
                txt_Rid.ReadOnly = true;
            }
            else
            {
                txt_Rid.ReadOnly = false;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string query;

            if (MessageBox.Show($"{Data.hWrongError2} '{txt_Rid.Text}'?", Data.hDeleteWarning, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                query = "DELETE FROM DB_User WHERE ID = '" + txt_Rid.Text + "'";
                try
                {
                    DataConn.Getdata(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                DBtableLoad();
            }
        }

        private void txt_RPW2_Click(object sender, EventArgs e)
        {
            if (labelbar2.Text == Data.hWrongError1) labelbar2.Text = "";
        }

        private void txt_Rid_Leave(object sender, EventArgs e)
        {
            string id = txt_Rid.Text;

            if (registrationFlag)
            {
                for (int i = 0; i < User_data.Rows.Count; i++)
                {
                    if (id == User_data.Rows[i].Cells[0].FormattedValue.ToString())
                    {
                        Btn_regi_Click(sender, e);
                        txt_Rname.Text = User_data.Rows[i].Cells[1].FormattedValue.ToString();
                        DT_RBD.Value = Convert.ToDateTime(User_data.Rows[i].Cells[2].FormattedValue.ToString());
                    }
                }
            }

        }

        private void txt_Rid_KeyUp(object sender, KeyEventArgs e)
        {
            txt_Rid.Text = txt_Rid.Text.Replace(" ", "");
            txt_Rid.SelectionStart = txt_Rid.Text.Length;
            txt_Rid.ScrollToCaret();
        }
    }
}
