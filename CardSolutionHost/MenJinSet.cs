using CardSolutionHost.Core;
using System;
using System.Windows.Forms;

namespace CardSolutionHost
{
    public partial class MenJinSet : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public MenJinSet()
        {
            InitializeComponent();
        }

        private void MenJinSet_Load(object sender, EventArgs e)
        {
            this.nCheckTimes.Value = SystemConfig.MenJinRefreshMinutes;
            int ReStartHour = Convert.ToInt32(SystemConfig.MenJinReStartTime.Substring(0, 2));
            int ReStartMin = Convert.ToInt32(SystemConfig.MenJinReStartTime.Substring(3, 2));
            this.nHour.Value = ReStartHour;
            this.nMin.Value = ReStartMin;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConfig.MenJinReStartTime =
               string.Format("{0}:{1}", Convert.ToInt32(nHour.Value).ToString().PadLeft(2, '0'), Convert.ToInt32(nMin.Value).ToString().PadLeft(2, '0'));
                SystemConfig.MenJinRefreshMinutes = Convert.ToInt32(nCheckTimes.Value);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
