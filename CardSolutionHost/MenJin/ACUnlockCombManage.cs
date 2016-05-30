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
    public partial class ACUnlockCombManage : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.ACUnlockCombBLL bll = new BLL_Service.MenJin.ACUnlockCombBLL();
        public ACUnlockCombManage()
        {
            InitializeComponent();
        }

        private void ACUnlockCombManage_Load(object sender, EventArgs e)
        {
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.DataSource = bll.GetData(string.Empty).Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ACUnlockCombEdit frm = new ACUnlockCombEdit(0);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    (this.dataGridView.DataSource as DataTable).AddRow(frm.model);
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
            ACUnlockCombEdit frm = new ACUnlockCombEdit(short.Parse(dr["UnlockCombID"].ToString()));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dr.RestData<Model_Service.MenJin.ACUnlockComb>(frm.model);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.CurrentCell == null)
                return;
            if (MessageBox.Show("提示", "确实要删除吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow dr = (this.dataGridView.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row;
                bll.Delete(short.Parse(dr["UnlockCombID"].ToString()));
                {
                    MessageBox.Show("删除成功");
                    (this.dataGridView.DataSource as DataTable).Rows.Remove(dr);
                }
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                    return;
                switch (this.dataGridView.Columns[e.ColumnIndex].Name)
                {
                    case "Group01":
                    case "Group02":
                    case "Group03":
                    case "Group04":
                    case "Group05":
                        var result = Convert.ToInt16((short)e.Value - 1);
                        if (result <= 0)
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
    }
}
