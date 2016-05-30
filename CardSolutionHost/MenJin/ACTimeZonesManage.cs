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
    public partial class ACTimeZonesManage : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.ACTimeZoneBLL bll = new BLL_Service.MenJin.ACTimeZoneBLL();
        public ACTimeZonesManage()
        {
            InitializeComponent();
        }

        private void ACTimeZonesManage_Load(object sender, EventArgs e)
        {
            DataTable dt = bll.GetData(string.Format(" and (TimeZoneID<>{0})", Model_Service.MenJin.ACTimeZone.MinTimeZoneID)).Tables[0];
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ACTimeZonesEdit frm = new ACTimeZonesEdit(0);
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

        private bool CheckHoliDay()
        {
            if (this.dataGridView.CurrentCell == null || this.dataGridView.CurrentCell.RowIndex < 0 || this.dataGridView.CurrentCell.ColumnIndex < 0)
                return false;
            DataRowView drv = (this.dataGridView.Rows[this.dataGridView.CurrentCell.RowIndex].DataBoundItem as DataRowView);
            if (Convert.ToInt32(drv["TimeZoneID"]) > 50)
                return true;
            return false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.CurrentCell == null)
                return;
            if (this.CheckHoliDay())
            {
                MessageBox.Show("不得大于50");
                return;
            }
            DataRow dr = (this.dataGridView.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row;
            ACTimeZonesEdit frm = new ACTimeZonesEdit(short.Parse(dr["TimeZoneID"].ToString()));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dr.RestData<Model_Service.MenJin.ACTimeZone>(frm.model);
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
                    default:
                        e.Value = Convert.ToDateTime(e.Value).ToString("HH:mm");
                        break;
                    case "NameDes":
                    case "Holidayvaild":
                        break;
                    case "TimeZoneID":
                        e.Value = (short)e.Value - 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.CurrentCell == null)
                return;
            if (this.CheckHoliDay())
            {
                MessageBox.Show("不得大于50");
                return;
            }
            if (MessageBox.Show("提示", "确实要删除吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow dr = (this.dataGridView.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row;
                bll.Delete(short.Parse(dr["TimeZoneID"].ToString()));
                MessageBox.Show("删除成功");
                (this.dataGridView.DataSource as DataTable).Rows.Remove(dr);
            }
        }
    }
}
