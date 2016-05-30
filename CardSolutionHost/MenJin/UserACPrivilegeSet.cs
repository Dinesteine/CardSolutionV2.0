using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Extention.DataExtion;
using Extention.StringExtention;
namespace CardSolutionHost.MenJin
{
    public partial class UserACPrivilegeSet : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.ACTimeZoneBLL bllACTimeZones = new BLL_Service.MenJin.ACTimeZoneBLL();
        BLL_Service.MenJin.MachinesBLL bllMachines = new BLL_Service.MenJin.MachinesBLL();
        BLL_Service.MenJin.UserACPrivilegeBLL bllUserACPrivilege = new BLL_Service.MenJin.UserACPrivilegeBLL();
        BLL_Service.Hr.HREmployeeBLL bllEmployee = new BLL_Service.Hr.HREmployeeBLL();
        BLL_Service.Hr.DEPARTMENTSBLL bllDept = new BLL_Service.Hr.DEPARTMENTSBLL();
        int deptid = -1;
        public UserACPrivilegeSet()
        {
            InitializeComponent();
        }
        private void UserACPrivilegeSet_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append(" and TimeZoneID>1");
            var result = bllACTimeZones.GetData(sbWhere.ToString()).Tables[0];
            foreach (DataRow item in result.Rows)
            {
                item["TimeZoneID"] = (short)(Convert.ToInt32(item["TimeZoneID"]) - 1);
            }
            this.cbbTimeZone1.DataSource = result.Copy();
            this.cbbTimeZone1.DisplayMember = "TimeZoneID";
            this.cbbTimeZone1.ValueMember = "TimeZoneID";
            this.cbbTimeZone2.DataSource = result.Copy();
            this.cbbTimeZone2.DisplayMember = "TimeZoneID";
            this.cbbTimeZone2.ValueMember = "TimeZoneID";
            this.cbbTimeZone3.DataSource = result.Copy();
            this.cbbTimeZone3.DisplayMember = "TimeZoneID";
            this.cbbTimeZone3.ValueMember = "TimeZoneID";
            this.cbbTimeZone1.Text = string.Empty;
            this.cbbTimeZone2.Text = string.Empty;
            this.cbbTimeZone3.Text = string.Empty;
            this.dgvUserL.AutoGenerateColumns = false;
            this.dgvUserR.AutoGenerateColumns = false;
            DataTable dtUser = this.bllDept.GetData(" and supdeptid=1").Tables[0];
            this.dgvUserL.DataSource = dtUser;
            this.dgvUserR.DataSource = this.bllUserACPrivilege.GetDataWithUserInfoAndDeptInfo(" and 1=0").Tables[0];
            this.dgvDeviceL.AutoGenerateColumns = false;
            this.dgvDeviceR.AutoGenerateColumns = false;
            DataTable dtDevice = this.bllMachines.GetData(string.Empty).Tables[0];
            this.dgvDeviceL.DataSource = dtDevice;
            this.dgvDeviceR.DataSource = dtDevice.Clone();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.dgvUserL.Columns["Code"].DataPropertyName == "DeptCode")
                return;
            ACGroupSelect frm = new ACGroupSelect();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataTable dtUserL = (this.dgvUserL.DataSource as DataTable);
                DataRowView drv = (frm.dataGridView.SelectedRows[0].DataBoundItem as DataRowView);
                short resultGroupID = short.Parse((frm.dataGridView.SelectedRows[0].DataBoundItem as DataRowView).Row["GroupID"].ToString());
                foreach (DataGridViewRow item in this.dgvUserL.SelectedRows)
                {
                    DataRow dr = (item.DataBoundItem as DataRowView).Row;
                    dr["ACGroupID"] = drv["GroupID"];
                    dr["GName"] = drv["Name"];
                    dr["Gholidayvaild"] = drv["holidayvaild"];
                }
                dtUserL.AcceptChanges();
            }
        }

        #region MoveData
        private void btnLTROne_Click(object sender, EventArgs e)
        {
            DataTable dtL = this.dgvUserL.DataSource as DataTable;
            DataTable dtR = this.dgvUserR.DataSource as DataTable;
            for (int i = this.dgvUserL.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataRow drItem = (this.dgvUserL.SelectedRows[i].DataBoundItem as DataRowView).Row;
                dtR.Rows.Add(drItem.ItemArray);
                dtL.Rows.Remove(drItem);
            }
            dtL.AcceptChanges();
            dtR.AcceptChanges();
        }

        private void btnLTRALL_Click(object sender, EventArgs e)
        {
            DataTable dtL = this.dgvUserL.DataSource as DataTable;
            DataTable dtR = this.dgvUserR.DataSource as DataTable;
            for (int i = this.dgvUserL.Rows.Count - 1; i >= 0; i--)
            {
                DataRow drItem = (this.dgvUserL.Rows[i].DataBoundItem as DataRowView).Row;
                dtR.Rows.Add(drItem.ItemArray);
                dtL.Rows.Remove(drItem);
            }
            dtL.AcceptChanges();
            dtR.AcceptChanges();
        }

        private void btnRTLOne_Click(object sender, EventArgs e)
        {
            DataTable dtL = this.dgvUserL.DataSource as DataTable;
            DataTable dtR = this.dgvUserR.DataSource as DataTable;
            for (int i = this.dgvUserR.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataRow drItem = (this.dgvUserR.SelectedRows[i].DataBoundItem as DataRowView).Row;
                if (Convert.ToInt32(drItem["deptid"]) == this.deptid)
                    dtL.Rows.Add(drItem.ItemArray);
                dtR.Rows.Remove(drItem);
            }
            dtL.AcceptChanges();
            dtR.AcceptChanges();
        }

        private void btnRTLAll_Click(object sender, EventArgs e)
        {

            DataTable dtL = this.dgvUserL.DataSource as DataTable;
            DataTable dtR = this.dgvUserR.DataSource as DataTable;
            for (int i = this.dgvUserR.Rows.Count - 1; i >= 0; i--)
            {
                DataRow drItem = (this.dgvUserR.Rows[i].DataBoundItem as DataRowView).Row;
                if (Convert.ToInt32(drItem["deptid"]) == this.deptid)
                    dtL.Rows.Add(drItem.ItemArray);
                dtR.Rows.Remove(drItem);
            }
            dtL.AcceptChanges();
            dtR.AcceptChanges();
        }

        private void btnLTROne1_Click(object sender, EventArgs e)
        {
            DataTable dtL = this.dgvDeviceL.DataSource as DataTable;
            DataTable dtR = this.dgvDeviceR.DataSource as DataTable;
            for (int i = this.dgvDeviceL.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataRow drItem = (this.dgvDeviceL.Rows[i].DataBoundItem as DataRowView).Row;
                dtR.Rows.Add(drItem.ItemArray);
                dtL.Rows.Remove(drItem);
            }
            dtL.AcceptChanges();
            dtR.AcceptChanges();

        }

        private void btnLTRALL1_Click(object sender, EventArgs e)
        {

            DataTable dtL = this.dgvDeviceL.DataSource as DataTable;
            DataTable dtR = this.dgvDeviceR.DataSource as DataTable;
            for (int i = this.dgvDeviceL.Rows.Count - 1; i >= 0; i--)
            {
                DataRow drItem = (this.dgvDeviceL.Rows[i].DataBoundItem as DataRowView).Row;
                dtR.Rows.Add(drItem.ItemArray);
                dtL.Rows.Remove(drItem);
            }
            dtL.AcceptChanges();
            dtR.AcceptChanges();
        }

        private void btnRTLOne1_Click(object sender, EventArgs e)
        {
            DataTable dtL = this.dgvDeviceL.DataSource as DataTable;
            DataTable dtR = this.dgvDeviceR.DataSource as DataTable;
            for (int i = this.dgvDeviceR.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataRow drItem = (this.dgvDeviceR.Rows[i].DataBoundItem as DataRowView).Row;
                dtL.Rows.Add(drItem.ItemArray);
                dtR.Rows.Remove(drItem);
            }
            dtL.AcceptChanges();
            dtR.AcceptChanges();
        }

        private void btnRTLAll1_Click(object sender, EventArgs e)
        {
            DataTable dtL = this.dgvDeviceL.DataSource as DataTable;
            DataTable dtR = this.dgvDeviceR.DataSource as DataTable;
            for (int i = this.dgvDeviceR.Rows.Count - 1; i >= 0; i--)
            {
                DataRow drItem = (this.dgvDeviceR.Rows[i].DataBoundItem as DataRowView).Row;
                dtL.Rows.Add(drItem.ItemArray);
                dtR.Rows.Remove(drItem);
            }
            dtL.AcceptChanges();
            dtR.AcceptChanges();
        }
        #endregion

        private void btnYX_Click(object sender, EventArgs e)
        {
            try
            {
                int result = bllUserACPrivilege.AddUserACPrivilege(GetResult());
                MessageBox.Show("成功");
                //MessageBox.Show(string.Format("更改了{0}个权限", result));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJZ_Click(object sender, EventArgs e)
        {
            try
            {
                int result = bllUserACPrivilege.DelUserACPrivilege(GetResult());
                MessageBox.Show("成功");
                //MessageBox.Show(string.Format("删除了{0}个权限", result));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<Model_Service.MenJin.UserACPrivilege> GetResult()
        {

            List<Model_Service.MenJin.UserACPrivilege> list = new List<Model_Service.MenJin.UserACPrivilege>();
            var dataEmployee = this.dgvUserR.DataSource as DataTable;
            var listDevice = (this.dgvDeviceR.DataSource as DataTable).ToList<Model_Service.MenJin.Machine>();
            var listTimeZones = this.cbbTimeZone1.Items.Cast<DataRowView>().Select(t => Convert.ToInt32(t["TimeZoneID"]));
            bool isUseGroup = true;
            int? timeresult = this.cbbTimeZone1.Text.TryInt();
            if (timeresult != null && listTimeZones.Contains(timeresult.Value))
                isUseGroup = false;
            timeresult = this.cbbTimeZone2.Text.TryInt();
            if (timeresult != null && listTimeZones.Contains(timeresult.Value))
                isUseGroup = false;
            timeresult = this.cbbTimeZone3.Text.TryInt();
            if (timeresult != null && listTimeZones.Contains(timeresult.Value))
                isUseGroup = false;
            foreach (DataRow employee in dataEmployee.Rows)
            {
                foreach (var device in listDevice)
                {
                    var model = new Model_Service.MenJin.UserACPrivilege();
                    model.ACGroupID = model.ACGroupID1 = employee["ACGroupID"].ToString().TryInt() == null ? 1 : Convert.ToInt32(employee["ACGroupID"]);
                    model.Id = new Model_Service.MenJin.UserACPrivilegeId() { DeviceID = device.Id, UserID = Convert.ToInt32(employee["EmpId"]) };
                    model.Verifystyle = 0;
                    model.TimeZone1 = model.TimeZone11 = this.cbbTimeZone1.Text.TryInt() == null ? 1 : (listTimeZones.Contains(Convert.ToInt32(this.cbbTimeZone1.Text)) ? Convert.ToInt32(this.cbbTimeZone1.Text) + 1 : 1);
                    model.TimeZone2 = model.TimeZone21 = this.cbbTimeZone2.Text.TryInt() == null ? 1 : (listTimeZones.Contains(Convert.ToInt32(this.cbbTimeZone2.Text)) ? Convert.ToInt32(this.cbbTimeZone2.Text) + 1 : 1);
                    model.TimeZone3 = model.TimeZone31 = this.cbbTimeZone3.Text.TryInt() == null ? 1 : (listTimeZones.Contains(Convert.ToInt32(this.cbbTimeZone3.Text)) ? Convert.ToInt32(this.cbbTimeZone3.Text) + 1 : 1);
                    model.IsUseGroup = isUseGroup;
                    list.Add(model);
                }
            }
            list = this.bllUserACPrivilege.GetListByJRGZ(list);
            return list;
        }

        private void dgvUserL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvUserL.CurrentCell == null)
                    return;
                if (this.dgvUserL.Columns["Code"].DataPropertyName == "DeptCode")
                {
                    DataRowView drv = this.dgvUserL.Rows[this.dgvUserL.CurrentCell.RowIndex].DataBoundItem as DataRowView;
                    int deptidTemp = Convert.ToInt32(drv["deptid"]);
                    var result = this.bllDept.GetData(string.Format(" and supdeptid={0}", deptidTemp)).Tables[0];
                    if (result.Rows.Count > 0)
                    {
                        this.dgvUserL.DataSource = result;
                    }
                    else
                    {
                        this.dgvUserL.Columns["Code"].DataPropertyName = "EmpNo";
                        this.dgvUserL.Columns["NameL"].DataPropertyName = "EmpName";
                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.AppendFormat(" and DeptId = {0} ", drv["deptid"]);
                        sbWhere.Append("and EmpId not in (-1");
                        DataTable dtUR = this.dgvUserR.DataSource as DataTable;
                        if (dtUR != null)
                        {
                            foreach (DataRow row in dtUR.Rows)
                            {
                                sbWhere.AppendFormat(",{0}", row["EmpId"]);
                            }
                        }
                        sbWhere.Append(")");
                        this.dgvUserL.DataSource = this.bllUserACPrivilege.GetDataWithUserInfoAndDeptInfo(sbWhere.ToString()).Tables[0];
                    }
                    this.deptid = deptidTemp;
                }
                else
                    this.btnLTROne_Click(this.btnLTROne, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.dgvUserL.CurrentCell == null)
                //    return;
                if (this.dgvUserL.Columns["Code"].DataPropertyName == "EmpNo")
                {
                    var model = this.bllDept.GetModel(this.deptid);
                    var result = this.bllDept.GetData(string.Format(" and supdeptid={0}", model.SUPDEPTID)).Tables[0];
                    if (result.Rows.Count > 0)
                    {
                        this.dgvUserL.Columns["Code"].DataPropertyName = "DeptCode";
                        this.dgvUserL.Columns["NameL"].DataPropertyName = "DeptName";
                        this.dgvUserL.DataSource = result;
                        this.deptid = Convert.ToInt32(result.Rows[0]["supdeptid"]);
                        foreach (DataGridViewRow item in this.dgvUserL.Rows)
                        {
                            DataRowView drv1 = item.DataBoundItem as DataRowView;
                            if (drv1["DeptId"] != null && drv1["DeptId"].ToString() == model.DEPTID.ToString())
                                item.Selected = true;
                            else
                                item.Selected = false;
                        }
                    }
                }
                else
                {
                    var result = this.bllDept.GetData(string.Format(" and supdeptid=(select top 1 supdeptid from DEPARTMENTS where deptid = {0})", this.deptid)).Tables[0];
                    if (result.Rows.Count > 0)
                    {
                        this.dgvUserL.DataSource = result;
                        this.deptid = Convert.ToInt32(result.Rows[0]["supdeptid"]);
                        foreach (DataGridViewRow item in this.dgvUserL.Rows)
                        {
                            DataRowView drv1 = item.DataBoundItem as DataRowView;
                            if (drv1["DeptId"] != null && drv1["DeptId"].ToString() == this.deptid.ToString())
                                item.Selected = true;
                            else
                                item.Selected = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                    return;
                DataGridView dgv = sender as DataGridView;
                if (dgv.Columns.Contains("Code") && dgv.Columns["Code"].DataPropertyName != "EmpNo")
                    return;
                if (dgv.Columns.Contains("EmpNo") && dgv.Columns["EmpNo"].DataPropertyName != "EmpNo")
                    return;
                switch (dgv.Columns[e.ColumnIndex].Name)
                {
                    case "ACGroupIDR":
                    case "ACGroupIDL":
                        if (e.Value != null)
                        {
                            short result = 0;
                            if (short.TryParse(e.Value.ToString(), out result))
                                e.Value = result - 1;
                            else
                                e.Value = 0;
                        }
                        else
                            e.Value = 0;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUserL_RightMouseCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnReturn_Click(this.btnReturn, null);
        }

        private void dgvUserR_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.btnRTLOne_Click(this.btnRTLOne, null);
        }

        private void dgvDeviceL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnLTROne1_Click(this.btnLTROne1, null);
        }

        private void dgvDeviceR_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnRTLOne1_Click(this.btnRTLOne1, null);
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
            if (this.dgvUserL.Columns["Code"].DataPropertyName == "DeptCode")
                return;
            DataGridView dgv = sender as DataGridView;
            DataRowView drv = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            StringBuilder sbText = new StringBuilder();
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                default:
                    label1.Visible = false;
                    break;
                case "ACGroupIDL":
                case "ACGroupIDR":
                    int acGroupID;
                    if (int.TryParse(drv["ACGroupID"].ToString(), out acGroupID) && acGroupID > 1)
                    {
                        sbText.AppendLine();
                        sbText.AppendFormat("组：{0}\r\n", acGroupID - 1);
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
            }
        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.label1.Visible = false;
        }
    }
}
