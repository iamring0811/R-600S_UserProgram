using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UrineAnalyzer
{
    public partial class Frm_listset : Form
    {
        public Frm_listset()
        {
            InitializeComponent();
            //            Console.WriteLine($"Frm_listset = m_bConn:{conn1.isConn.ToString()}");
        }

        static List<CheckBox> chkcontrol = new List<CheckBox>();
        static List<ComboBox> cboxcontrol = new List<ComboBox>();
        public delegate void CloseHandler();
        public event CloseHandler Close_;

        private void Frm_listset_Load(object sender, EventArgs e)
        {
            FrmSizeSet();
            this.Text = Data.fListSetting;
            btn_save.BackgroundImage = ImageLoad.btnSaveBack;
            btn_close.BackgroundImage = ImageLoad.btnCloseBack;
            DataRow[] dr = Data.Table.Select("", "Item");
            Dictionary<int, string> Name = new Dictionary<int, string>();

            for (int i = 0; i < dr.Length; i++)
            {
                Name.Add(Convert.ToInt32(dr[i][0]) - 1, dr[i][1].ToString());
            }

            foreach (ComboBox cbox in this.Controls.OfType<ComboBox>())
            {
                cboxcontrol.Add(cbox);
            }
            cboxcontrol = cboxcontrol.OrderBy(x => x.TabIndex).ToList();

            foreach (CheckBox chk in this.Controls.OfType<CheckBox>())
            {
                chkcontrol.Add(chk);
                chk.Checked = true;
            }
            chkcontrol = chkcontrol.OrderBy(x => x.TabIndex).ToList();

            for (int i = 0; i < cboxcontrol.Count; i++)
            {
                cboxcontrol[i].DataSource = new BindingSource(Name, null);
                cboxcontrol[i].DisplayMember = "Value";
                cboxcontrol[i].ValueMember = "Key";
                cboxcontrol[i].SelectedIndex = i;
                cboxcontrol[i].DropDownStyle = ComboBoxStyle.DropDownList;
                cboxcontrol[i].MaxDropDownItems = 15;
                cboxcontrol[i].Font = new Font("Times New Roman", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void FrmSizeSet()
        {
            checkBox1.Width = 15;
            checkBox1.Height = 14;
            checkBox2.Width = 15;
            checkBox2.Height = 14;
            checkBox3.Width = 15;
            checkBox3.Height = 14;
            checkBox4.Width = 15;
            checkBox4.Height = 14;
            checkBox5.Width = 15;
            checkBox5.Height = 14;
            checkBox6.Width = 15;
            checkBox6.Height = 14;
            checkBox7.Width = 15;
            checkBox7.Height = 14;
            checkBox8.Width = 15;
            checkBox8.Height = 14;
            checkBox9.Width = 15;
            checkBox9.Height = 14;
            checkBox10.Width = 15;
            checkBox10.Height = 14;
            checkBox11.Width = 15;
            checkBox11.Height = 14;
            checkBox12.Width = 15;
            checkBox12.Height = 14;
            checkBox13.Width = 15;
            checkBox13.Height = 14;
            checkBox14.Width = 15;
            checkBox14.Height = 14;
            checkBox15.Width = 15;
            checkBox15.Height = 14;
            checkBox1.Left = 30;
            checkBox1.Top = 33;
            checkBox2.Left = 30;
            checkBox2.Top = 67;
            checkBox3.Left = 30;
            checkBox3.Top = 101;
            checkBox4.Left = 30;
            checkBox4.Top = 135;
            checkBox5.Left = 30;
            checkBox5.Top = 169;
            checkBox6.Left = 30;
            checkBox6.Top = 203;
            checkBox7.Left = 30;
            checkBox7.Top = 237;
            checkBox8.Left = 30;
            checkBox8.Top = 271;
            checkBox9.Left = 173;
            checkBox9.Top = 33;
            checkBox10.Left = 173;
            checkBox10.Top = 67;
            checkBox11.Left = 173;
            checkBox11.Top = 101;
            checkBox12.Left = 173;
            checkBox12.Top = 135;
            checkBox13.Left = 173;
            checkBox13.Top = 169;
            checkBox14.Left = 173;
            checkBox14.Top = 203;
            checkBox15.Left = 173;
            checkBox15.Top = 237;

            comboBox1.Left = 61;
            comboBox1.Top = 33;
            comboBox1.Width = 70;
            comboBox1.Height = 20;
            comboBox2.Left = 61;
            comboBox2.Top = 67;
            comboBox2.Width = 70;
            comboBox2.Height = 20;
            comboBox3.Left = 61;
            comboBox3.Top = 101;
            comboBox3.Width = 70;
            comboBox3.Height = 20;
            comboBox4.Left = 61;
            comboBox4.Top = 135;
            comboBox4.Width = 70;
            comboBox4.Height = 20;
            comboBox5.Left = 61;
            comboBox5.Top = 169;
            comboBox5.Width = 70;
            comboBox5.Height = 20;
            comboBox6.Left = 61;
            comboBox6.Top = 203;
            comboBox6.Width = 70;
            comboBox6.Height = 20;
            comboBox7.Left = 61;
            comboBox7.Top = 237;
            comboBox7.Width = 70;
            comboBox7.Height = 20;
            comboBox8.Left = 61;
            comboBox8.Top = 271;
            comboBox8.Width = 70;
            comboBox8.Height = 20;
            comboBox9.Left = 204;
            comboBox9.Top = 33;
            comboBox9.Width = 70;
            comboBox9.Height = 20;
            comboBox10.Left = 204;
            comboBox10.Top = 67;
            comboBox10.Width = 70;
            comboBox10.Height = 20;
            comboBox11.Left = 204;
            comboBox11.Top = 101;
            comboBox11.Width = 70;
            comboBox11.Height = 20;
            comboBox12.Left = 204;
            comboBox12.Top = 135;
            comboBox12.Width = 70;
            comboBox12.Height = 20;
            comboBox13.Left = 204;
            comboBox13.Top = 169;
            comboBox13.Width = 70;
            comboBox13.Height = 20;
            comboBox14.Left = 204;
            comboBox14.Top = 203;
            comboBox14.Width = 70;
            comboBox14.Height = 20;
            comboBox15.Left = 204;
            comboBox15.Top = 237;
            comboBox15.Width = 70;
            comboBox15.Height = 20;
            btn_save.Left = 30;
            btn_save.Top = 336;
            btn_save.Width = 118;
            btn_save.Height = 43;
            btn_close.Left = 173;
            btn_close.Top = 336;
            btn_close.Width = 118;
            btn_close.Height = 43;
            this.Width = 337;
            this.Height = 445;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                Data.ListItem.Rows.Clear();//220401
                DataConn.DeleteData(Data.ListItem);
                DataConn.GetDataCommit();
                for (int i = 0; i < chkcontrol.Count(); i++)
                {
                    DataRow dr = Data.ListItem.NewRow();
                    if (chkcontrol[i].Checked)
                    {
                        dr[0] = i + 1;
                        dr[1] = cboxcontrol[i].Text;
                        DataConn.InsertData(Data.ListItem, dr);
                        DataConn.GetDataCommit();
                        //                        DataConn.AddDataTable(Data.ListItem, dr);
                    }
                    else
                    {

                    }
                }
                MessageBox.Show(Data.fComplete);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            CloseHandler handler = Close_;
            handler?.Invoke();
        }

       
    }


}
