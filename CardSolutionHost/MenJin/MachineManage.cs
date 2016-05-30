using CardSolutionHost.BLL;
using CardSolutionHost.Core;
using CardSolutionHost.Entitys;
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
    public partial class MachineManage : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        DataTable dt;
        public MachineManage()
        {
            InitializeComponent();
        }

        private void MachineManage_Load(object sender, EventArgs e)
        {
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.AutoGenerateColumns = false;
            this.BindDataGridView(string.Empty);
        }

        private void BindDataGridView(string strWhere)
        {
            this.dt = new MenJinService().GetMachinesEntityDt();
            DataView dv = dt.DefaultView;
            dv.Sort = "MachineNumber Asc";
            dt = dv.ToTable();
            this.dataGridView.DataSource = this.dt;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView.CurrentCell == null)
                    return;
                int index = this.dataGridView.CurrentCell.RowIndex;
                if (index <= 0)
                    return;
                DataRow dr = this.dt.NewRow();
                dr.ItemArray = this.dt.Rows[index].ItemArray;
                this.dt.Rows[index].ItemArray = this.dt.Rows[index - 1].ItemArray;
                this.dt.Rows[index - 1].ItemArray = dr.ItemArray;
                this.dataGridView.Rows[index - 1].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView.CurrentCell == null)
                    return;
                int index = this.dataGridView.CurrentCell.RowIndex;
                if (index >= this.dataGridView.Rows.Count - 1)
                    return;
                DataRow dr = this.dt.NewRow();
                dr.ItemArray = this.dt.Rows[index].ItemArray;
                this.dt.Rows[index].ItemArray = this.dt.Rows[index + 1].ItemArray;
                this.dt.Rows[index + 1].ItemArray = dr.ItemArray;
                this.dataGridView.Rows[index + 1].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Purpose"] = i;
                }
                dt.AcceptChanges();
                var results = ClassValueCopier.GetArrayFromDataTable<MachinesEntity>(dt);
                new MenJinService().SaveMachinesEntitys(results);
                MessageBox.Show("保存成功");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                    return;
                if (this.dataGridView.Columns[e.ColumnIndex].Name == "Enabled")
                {
                    DataRowView drv = this.dataGridView.Rows[e.RowIndex].DataBoundItem as DataRowView;
                    if (drv != null)
                    {
                        if (drv["Enabled"] == null)
                            drv.Row["Enabled"] = true;
                        drv.Row["Enabled"] = !bool.Parse(drv["Enabled"].ToString());
                        drv.Row.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
