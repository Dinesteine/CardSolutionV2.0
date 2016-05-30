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
    public partial class ACTimeZonesEdit : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.ACTimeZoneBLL bll = new BLL_Service.MenJin.ACTimeZoneBLL();
        short TimeZoneID { get; set; }
        internal Model_Service.MenJin.ACTimeZone model { get; set; }
        public ACTimeZonesEdit(short TimeZoneID)
        {
            this.TimeZoneID = TimeZoneID;
            InitializeComponent();
            object[] objs = new object[Model_Service.MenJin.ACTimeZone.MaxTimeZoneID - 1];
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i] = (i + 1).ToString();
            }
            this.comboBox1.Items.AddRange(objs);
            this.Init();
        }

        private void Init()
        {
            if (TimeZoneID > 0)
            {
                this.comboBox1.Enabled = false;
                model = bll.GetModel(TimeZoneID);
                dtpSunStart.Value = model.SunStart;
                dtpSunEnd.Value = model.SunEnd;
                dtpMonStart.Value = model.MonStart;
                dtpMonEnd.Value = model.MonEnd;
                dtpTuesStart.Value = model.TuesStart;
                dtpTuesEnd.Value = model.TuesEnd;
                dtpWedStart.Value = model.WedStart;
                dtpWedEnd.Value = model.WedEnd;
                dtpThursStart.Value = model.ThursStart;
                dtpThursEnd.Value = model.ThursEnd;
                dtpFriStart.Value = model.FriStart;
                dtpFriEnd.Value = model.FriEnd;
                dtpSatStart.Value = model.SatStart;
                dtpSatEnd.Value = model.SatEnd;
                comboBox1.Text = (model.TimeZoneID - 1).ToString();
                textBox1.Text = model.Name;
                this.chkholidayvaild.Checked = model.Holidayvaild;
            }
        }

        private void ACTimeZonesEdit_Load(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex < 0)
                this.comboBox1.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (TimeZoneID <= 0)
                {
                    model = new Model_Service.MenJin.ACTimeZone();
                    model.TimeZoneID = short.Parse(this.comboBox1.Text);
                }
                model.SunStart = this.dtpSunStart.Value;
                model.SunEnd = this.dtpSunEnd.Value;
                model.MonStart = this.dtpMonStart.Value;
                model.MonEnd = this.dtpMonEnd.Value;
                model.TuesStart = this.dtpTuesStart.Value;
                model.TuesEnd = this.dtpTuesEnd.Value;
                model.WedStart = this.dtpWedStart.Value;
                model.WedEnd = this.dtpWedEnd.Value;
                model.ThursStart = this.dtpThursStart.Value;
                model.ThursEnd = this.dtpThursEnd.Value;
                model.FriStart = this.dtpFriStart.Value;
                model.FriEnd = this.dtpFriEnd.Value;
                model.SatStart = this.dtpSatStart.Value;
                model.SatEnd = this.dtpSatEnd.Value;
                model.Name = this.textBox1.Text;
                model.Holidayvaild = this.chkholidayvaild.Checked;
                if (model.TimeZoneID > 49)
                {
                    MessageBox.Show("不得大于49");
                    return;
                }
                if (TimeZoneID > 0)
                {
                    bll.Update(model);
                    {
                        MessageBox.Show("保存成功");
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    model.TimeZoneID = (short)(model.TimeZoneID + 1);
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
