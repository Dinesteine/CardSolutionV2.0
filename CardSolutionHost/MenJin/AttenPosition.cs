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
    public partial class AttenPosition : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.MachinesBLL machinesBLL = new BLL_Service.MenJin.MachinesBLL();
        BLL_Service.Hr.DEPARTMENTSBLL bllDept = new BLL_Service.Hr.DEPARTMENTSBLL();
        BLL_Service.Hr.HREmployeeBLL bllEmployee = new BLL_Service.Hr.HREmployeeBLL();
        List<int> listDeptIds = new List<int>();
        string[] strcolumns = { "UserId", "EmpNo", "EmpName", "DeptId", "status" };
        public AttenPosition()
        {
            InitializeComponent();
        }
        private void AttenPosition_Load(object sender, EventArgs e)
        {
            this.dgvUserR.AutoGenerateColumns = false;
            var resultDepts = bllDept.GetList(string.Empty);
            BindTreeView(resultDepts);
            this.treeGroup.ImageList = this.imageList1;
            this.treeGroup.ImageIndex = 0;
            this.dgvUserR.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvUserR.MultiSelect = true;
            this.MaximizeBox = true;
        }

        public void BindTreeView(IList<Model_Service.Hr.DEPARTMENTS> depts)
        {
            try
            {
                foreach (var item in depts)
                {
                    if (item.SUPDEPTID <= 0)
                    {
                        TreeNode treeNode = new TreeNode();
                        treeNode.Text = item.DEPTNAME;
                        treeNode.Tag = item.DEPTID;
                        treeNode.ImageIndex = 0;
                        LoadSubNaviMenu(treeNode, depts);
                        this.treeGroup.Nodes.Add(treeNode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadSubNaviMenu(TreeNode fatherNode, IEnumerable<Model_Service.Hr.DEPARTMENTS> depts)
        {
            var fatherId = fatherNode.Tag.TryInt();
            if (fatherId == null)
                return;
            var resutls = depts.Where(t => t.SUPDEPTID == fatherId.Value);
            foreach (var item in resutls)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = item.DEPTNAME;
                treeNode.Tag = item.DEPTID;
                treeNode.ImageIndex = 0;
                LoadSubNaviMenu(treeNode, depts);
                fatherNode.Nodes.Add(treeNode);
            }
        }


        void GetAllDeptIds(int faterDeptId)
        {
            if (!listDeptIds.Contains(faterDeptId))
                listDeptIds.Add(faterDeptId);
            var result = bllDept.GetList(string.Format(" and SUPDEPTID = {0}", faterDeptId));
            foreach (var item in result)
            {
                listDeptIds.Add(item.DEPTID);
                this.GetAllDeptIds(item.DEPTID);
            }
        }
        private void treeGroup_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                return;
            int deptid = 0;
            if (int.TryParse(e.Node.Tag.ToString(), out deptid))
            {
                ShowResult(deptid);
            }
        }

        private void ShowResult(int deptId)
        {
            this.listDeptIds.Clear();
            this.GetAllDeptIds(deptId);
            string sql = " and 1=1 ";
            sql = sql + " and status = '在职' ";
            if (listDeptIds.Count > 0)
            {
                sql = sql + " and DeptId in (";
                sql = sql + string.Join(",", listDeptIds.Select(t => t.ToString()).ToArray());
                sql = sql + ")";
            }
            var result = this.machinesBLL.GetUserPosition(sql).Tables[0];
            for (int i = this.dgvUserR.Columns.Count - 1; i >= 0; i--)
            {
                string columnName = this.dgvUserR.Columns[i].Name;
                if (columnName != "EmpName" && columnName != "EmpNo")
                {
                    this.dgvUserR.Columns.Remove(columnName);
                }
            }
            for (int i = 0; i < result.Columns.Count; i++)
            {
                if (strcolumns.Contains(result.Columns[i].ColumnName))
                    continue;
                this.dgvUserR.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = result.Columns[i].ColumnName,
                    HeaderText = result.Columns[i].ColumnName,
                    DataPropertyName = result.Columns[i].ColumnName
                });
            }
            this.dgvUserR.AutoGenerateColumns = false;
            this.dgvUserR.DataSource = result;
        }

        private void dgvUserR_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                    return;
                string strColumnName = this.dgvUserR.Columns[e.ColumnIndex].Name;
                if (strcolumns.Contains(strColumnName))
                    return;
                DataRowView drv = this.dgvUserR.Rows[e.RowIndex].DataBoundItem as DataRowView;
                int _userId = drv["UserId"].TryInt().Value;
                var result = this.dgvUserR.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.TryInt();
                var machineModel = this.machinesBLL.GetModelByName(strColumnName);
                if (result == null)
                {
                    var model = new Model_Service.MenJin.Kq_Position();
                    model.Id = new Model_Service.MenJin.Kq_PositionId();
                    model.Id.MachineId = machineModel.Id;
                    model.Id.UserId = _userId;
                    model.status = 0;
                    if (this.machinesBLL.SaveKq_Position(model))
                        this.dgvUserR.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
                else
                {
                    if (result.Value == 0)
                    {
                        var model = new Model_Service.MenJin.Kq_Position();
                        model.Id = new Model_Service.MenJin.Kq_PositionId();
                        model.Id.MachineId = machineModel.Id;
                        model.Id.UserId = _userId;
                        model.status = 0;
                        if (this.machinesBLL.SaveKq_Position(model))
                            this.dgvUserR.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                    }
                    else
                    {
                        if (this.machinesBLL.DelKq_Position(_userId, machineModel.Id))
                            this.dgvUserR.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "系统错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void dgvUserR_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                    return;
                string columnName = this.dgvUserR.Columns[e.ColumnIndex].Name;
                if (columnName != "EmpName" && columnName != "EmpNo")
                {
                    var result = e.Value.TryInt();
                    if (result == null)
                        e.Value = "无权限";
                    else
                    {
                        if (result.Value == 0)
                            e.Value = "考勤";
                        else
                            e.Value = "允许";
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "系统错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnYX_Click(object sender, EventArgs e)
        {
            try
            {
                SaveKqPosition(1);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "系统错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            try
            {
                SaveKqPosition(0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "系统错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnJZ_Click(object sender, EventArgs e)
        {
            try
            {
                SaveKqPosition(null);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "系统错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void SaveKqPosition(int? status)
        {
            List<Model_Service.MenJin.Kq_Position> resutls = new List<Model_Service.MenJin.Kq_Position>();
            for (int i = 0; i < this.dgvUserR.Rows.Count; i++)
            {
                DataRowView drv = this.dgvUserR.Rows[i].DataBoundItem as DataRowView;
                for (int j = 0; j < this.dgvUserR.Columns.Count; j++)
                {
                    string strColumnName = this.dgvUserR.Columns[j].Name;
                    if (strcolumns.Contains(strColumnName))
                        continue;
                    if (this.dgvUserR.Rows[i].Cells[j].Selected)
                    {
                        var model = new Model_Service.MenJin.Kq_Position();
                        model.Id = new Model_Service.MenJin.Kq_PositionId();
                        var machineModel = this.machinesBLL.GetModelByName(strColumnName);
                        model.Id.MachineId = machineModel.Id;
                        model.Id.UserId = drv["UserId"].TryInt().Value;
                        model.status = status ?? -1;
                        resutls.Add(model);
                    }
                }
            }
            if (resutls.Count <= 0)
            {
                MessageBox.Show("您尚未选择任何单元格");
                return;
            }
            if (this.machinesBLL.SaveKq_PositionList(resutls))
            {
                MessageBox.Show("保存成功");
                for (int i = 0; i < this.dgvUserR.Rows.Count; i++)
                {
                    DataRow dr = (this.dgvUserR.Rows[i].DataBoundItem as DataRowView).Row;
                    for (int j = 0; j < this.dgvUserR.Columns.Count; j++)
                    {
                        string strColumnName = this.dgvUserR.Columns[j].Name;
                        if (strcolumns.Contains(strColumnName))
                            continue;
                        if (this.dgvUserR.Rows[i].Cells[j].Selected)
                        {
                            if (status == null)
                                dr[strColumnName] = DBNull.Value;
                            else
                                dr[strColumnName] = status;
                        }
                    }
                    dr.AcceptChanges();
                }
            }
        }
    }
}
