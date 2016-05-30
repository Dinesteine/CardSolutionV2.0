using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardSolutionHost.MenJin
{
    public partial class UserACPrivilegeEdit : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.UserACPrivilegeBLL bll = new BLL_Service.MenJin.UserACPrivilegeBLL();
        public UserACPrivilegeEdit()
        {
            InitializeComponent();
        }
        private void UserACPrivilegeEdit_Load(object sender, EventArgs e)
        {
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.DataSource = this.bll.GetDataWithUserInfoAndMachineInfo(string.Empty).Tables[0];
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                    return;
                switch (this.dataGridView.Columns[e.ColumnIndex].Name)
                {
                    case "ACGroupID":
                    case "ACGroupID1":
                    case "TimeZone1":
                    case "TimeZone2":
                    case "TimeZone3":
                        if (e.Value != null)
                        {
                            short result = 0;
                            if (short.TryParse(e.Value.ToString(), out result))
                                e.Value = result - 1;
                            else
                                e.Value = 1;
                        }
                        else
                            e.Value = 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                UserACPrivilegeSet frm = new UserACPrivilegeSet();
                frm.ShowDialog();
                this.dataGridView.DataSource = this.bll.GetDataWithUserInfoAndMachineInfo(string.Empty).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void dataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Location = new Point(e.X + 20, e.Y + 100);
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                label1.Visible = false;
                return;
            }
            DataRowView drv = this.dataGridView.Rows[e.RowIndex].DataBoundItem as DataRowView;
            StringBuilder sbText = new StringBuilder();
            switch (this.dataGridView.Columns[e.ColumnIndex].Name)
            {
                default:
                    label1.Visible = false;
                    break;
                case "ACGroupID":
                    int acGroupID;
                    if (int.TryParse(drv["ACGroupID"].ToString(), out acGroupID) && acGroupID > 1)
                    {
                        sbText.AppendLine();
                        sbText.AppendFormat("组：{0}\r\n", Convert.ToInt32(drv["ACGroupID"]) - 1);
                        sbText.AppendLine();
                        sbText.AppendFormat("名称：{0}\r\n", drv["GName"]);
                        sbText.AppendLine();
                        sbText.AppendFormat("节假日有效：{0}", Convert.ToBoolean(drv["Gholidayvaild"]) ? "是" : "否");
                        label1.Text = sbText.ToString();
                        label1.Visible = true;
                    }
                    else
                        label1.Visible = false;
                    break;
                case "TimeZone1":
                case "TimeZone2":
                case "TimeZone3":
                    string EndString = this.dataGridView.Columns[e.ColumnIndex].Name.Substring(this.dataGridView.Columns[e.ColumnIndex].Name.Length - 1);
                    int timezone;
                    if (int.TryParse(drv["TimeZone" + EndString].ToString(), out timezone) && timezone > 1)
                    {
                        sbText.AppendLine();
                        sbText.AppendFormat("时间段：{0}\r\n", Convert.ToInt32(drv["TimeZone" + EndString]) - 1);
                        sbText.AppendLine();
                        sbText.AppendFormat("名称：{0}\r\n", drv["AcName" + EndString]);
                        sbText.AppendLine();
                        sbText.AppendFormat("节假日有效：{0}", Convert.ToBoolean(drv["Acholidayvaild" + EndString]) ? "是" : "否");
                        label1.Text = sbText.ToString();
                        label1.Visible = true;
                    }
                    else
                        label1.Visible = false;
                    break;
            }
        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.label1.Visible = false;
        }
    }
}
