using System;
namespace CardSolutionHost.MenJin
{
    public partial class ACGroupSelect : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.ACGroupBLL bll = new BLL_Service.MenJin.ACGroupBLL();
        public ACGroupSelect()
        {
            InitializeComponent();
        }

        private void ACGroupSelect_Load(object sender, EventArgs e)
        {
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.DataSource = bll.GetData(string.Format("and (GroupID<> {0}) ", Model_Service.MenJin.ACGroup.MinGroupID)).Tables[0];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count <= 0)
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void dataGridView_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
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
                        e.Value = (short)e.Value - 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "系统错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
