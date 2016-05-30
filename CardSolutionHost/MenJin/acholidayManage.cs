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
    public partial class acholidayManage : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.AcholidayBLL bll = new BLL_Service.MenJin.AcholidayBLL();
        public acholidayManage()
        {
            InitializeComponent();
        }

        private void acholidayManage_Load(object sender, EventArgs e)
        {
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.DataSource = bll.GetData(string.Empty).Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                acholidayEdit frm = new acholidayEdit(0);
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
            acholidayEdit frm = new acholidayEdit(short.Parse(dr["primaryid"].ToString()));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dr.RestData<Model_Service.MenJin.Acholiday>(frm.model);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.CurrentCell == null)
                return;
            if (MessageBox.Show("提示", "确实要删除吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow dr = (this.dataGridView.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row;
                bll.Delete(int.Parse(dr["primaryid"].ToString()));
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
