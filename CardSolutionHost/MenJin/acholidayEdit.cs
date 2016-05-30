using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Extention.StringExtention;

namespace CardSolutionHost.MenJin
{
    public partial class acholidayEdit : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.AcholidayBLL bll = new BLL_Service.MenJin.AcholidayBLL();
        internal Model_Service.MenJin.Acholiday model { get; set; }
        int primaryid { get; set; }
        public acholidayEdit(int primaryid)
        {
            this.primaryid = primaryid;
            InitializeComponent();
        }

        private void acholidayEdit_Load(object sender, EventArgs e)
        {
            this.Init();
        }
        private void Init()
        {
            BLL_Service.MenJin.ACTimeZoneBLL bllACTimeZone = new BLL_Service.MenJin.ACTimeZoneBLL();
            var result = bllACTimeZone.GetList(string.Format(" and (TimeZoneID<>{0}) ", Model_Service.MenJin.ACTimeZone.MinTimeZoneID));// BLL_Service.ModelMethod.GetList<Model_Service.ACTimeZone>(null);
            this.cbbtimezone.DataSource = result;
            this.cbbtimezone.DisplayMember = "TimeZoneID";
            this.cbbtimezone.ValueMember = "TimeZoneID";
            if (primaryid > 0)
            {
                this.cbbholidayid.Enabled = false;
                model = bll.GetModel(primaryid);
                this.cbbtimezone.Text = model.Timezone.ToString();
                this.cbbholidayid.Text = model.Holidayid.ToString();
                this.dtpbegindate.Value = model.Begindate;
                this.dtpenddate.Value = model.Enddate;
            }
            else
            {
                this.cbbtimezone.Text = string.Empty;
            }
            this.cbbtimezone.Text = "1";
            this.cbbtimezone.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpbegindate.Value > this.dtpenddate.Value)
                {
                    MessageBox.Show("开始时间必须小于结束时间");
                    return;
                }
                if (Math.Abs((dtpbegindate.Value - dtpenddate.Value).TotalHours) < 1)
                {
                    MessageBox.Show("放假时间间隔不得小于1小时");
                    return;
                }
                if (primaryid <= 0)
                {
                    model = new Model_Service.MenJin.Acholiday();
                }
                model.Timezone = this.cbbtimezone.Text.TryInt() ?? 1;
                model.Holidayid = int.Parse(this.cbbholidayid.Text);
                model.Begindate = this.dtpbegindate.Value;
                model.Enddate = this.dtpenddate.Value;
                if (model.Begindate <= DateTime.Now && model.Enddate >= DateTime.Now)
                    model.Status = 0;
                if (primaryid > 0)
                {
                    //if (BLL_Service.ModelMethod.Update<Model_Service.MenJin.Acholiday>(model))
                    bll.Update(model);
                    {
                        MessageBox.Show("保存成功");
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    //if (BLL_Service.ModelMethod.Add<Model_Service.MenJin.Acholiday>(model))
                    bll.Add(model);
                    {
                        MessageBox.Show("保存成功");
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
