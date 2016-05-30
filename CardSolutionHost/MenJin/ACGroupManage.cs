using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Extention.DataExtion;
namespace CardSolutionHost.MenJin
{
    public partial class ACGroupManage : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.ACGroupBLL bll = new BLL_Service.MenJin.ACGroupBLL();
        public ACGroupManage()
        {
            InitializeComponent();
        }

        private void ACGroupManage_Load(object sender, EventArgs e)
        {
            DataTable dt = bll.GetData(string.Format("and (GroupID<> {0}) ", Model_Service.MenJin.ACGroup.MinGroupID)).Tables[0];
            this.dataGridView.DataSource = dt;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                    return;
                switch (this.dataGridView.Columns[e.ColumnIndex].Name)
                {
                    case "GroupID":
                    case "TimeZone1":
                    case "TimeZone2":
                    case "TimeZone3":
                        var result = Convert.ToInt16(e.Value) - 1;
                        if (result < 0)
                            result = 0;
                        e.Value = result;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ACGroupEdit frm = new ACGroupEdit(0);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    (this.dataGridView.DataSource as DataTable).AddRow(frm.modelData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.CurrentCell == null)
                return;
            DataRow dr = (this.dataGridView.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row;
            ACGroupEdit frm = new ACGroupEdit(short.Parse(dr["GroupID"].ToString()));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dr.RestData<Model_Service.MenJin.ACGroup>(frm.modelData);
            }
        }

        internal bool CheckHoliDay()
        {
            if (this.dataGridView.CurrentCell == null || this.dataGridView.CurrentCell.RowIndex < 0 || this.dataGridView.CurrentCell.ColumnIndex < 0)
                return false;
            DataRowView drv = (this.dataGridView.Rows[this.dataGridView.CurrentCell.RowIndex].DataBoundItem as DataRowView);
            if ((Model_Service.MenJin.ACGroup.MinGroupID < Convert.ToInt16(drv["GroupID"])) && (Convert.ToInt16(drv["GroupID"]) <= Model_Service.MenJin.ACGroup.MaxGroupID))
                return false;
            return true;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.CurrentCell == null)
                return;
            if (this.CheckHoliDay())
            {
                MessageBox.Show(string.Format("应在 {0}-{1} 范围内", Model_Service.MenJin.ACGroup.MinGroupID, Model_Service.MenJin.ACGroup.MaxGroupID));
                return;
            }
            if (MessageBox.Show("提示", "确实要删除吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow dr = (this.dataGridView.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row;
                bll.Delete(short.Parse(dr["GroupID"].ToString()));
                {
                    MessageBox.Show("删除成功");
                    (this.dataGridView.DataSource as DataTable).Rows.Remove(dr);
                }
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
