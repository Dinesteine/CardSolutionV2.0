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
    public partial class ACGroupEdit : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.ACGroupBLL bll = new BLL_Service.MenJin.ACGroupBLL();
        short GroupID { get; set; }
        internal Model_Service.MenJin.ACGroup modelData { get; set; }
        public ACGroupEdit(short GroupID)
        {
            this.GroupID = GroupID;
            InitializeComponent();
            object[] objs = new object[Model_Service.MenJin.ACGroup.MaxGroupID - 1];
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i] = (i + 1).ToString();
            }
            this.cbbGroupID.Items.AddRange(objs);
        }
        private void Init()
        {
            BLL_Service.MenJin.ACTimeZoneBLL bllACTimeZone = new BLL_Service.MenJin.ACTimeZoneBLL();
            var data = bllACTimeZone.GetData(string.Empty).Tables[0];
            foreach (DataRow item in data.Rows)
                item["TimeZoneID"] = (short)((short)item["TimeZoneID"] - 1);
            DataRow dr = data.NewRow();
            dr["TimeZoneID"] = 0;
            data.Rows.InsertAt(dr, 0);
            this.cbbTimeZone1.DataSource = data.Copy();
            this.cbbTimeZone1.DisplayMember = "TimeZoneID";
            this.cbbTimeZone1.ValueMember = "TimeZoneID";
            this.cbbTimeZone2.DataSource = data.Copy();
            this.cbbTimeZone2.DisplayMember = "TimeZoneID";
            this.cbbTimeZone2.ValueMember = "TimeZoneID";
            this.cbbTimeZone3.DataSource = data.Copy();
            this.cbbTimeZone3.DisplayMember = "TimeZoneID";
            this.cbbTimeZone3.ValueMember = "TimeZoneID";
            if (GroupID > 0)
            {
                this.cbbGroupID.Enabled = false;
                Model_Service.MenJin.ACGroup model = bll.GetModel(GroupID);
                this.textBox1.Text = model.Name;
                this.cbbGroupID.Text = (model.GroupID - 1).ToString();
                this.chkholidayvaild.Checked = model.Holidayvaild;
                this.cbbTimeZone1.SelectedValue = model.TimeZone1 - 1;
                this.cbbTimeZone2.SelectedValue = model.TimeZone2 - 1;
                this.cbbTimeZone3.SelectedValue = model.TimeZone3 - 1;
            }
            else
            {
                this.cbbTimeZone1.SelectedValue = 0;
                this.cbbTimeZone2.SelectedValue = 0;
                this.cbbTimeZone3.SelectedValue = 0;
            }
        }
        private void ACGroupEdit_Load(object sender, EventArgs e)
        {
            this.Init();
            if (this.cbbGroupID.SelectedIndex < 0)
                this.cbbGroupID.SelectedIndex = 0;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var model = new Model_Service.MenJin.ACGroup();
                bool isAdd = false;
                if (GroupID <= 0)
                {
                    this.GroupID = short.Parse((int.Parse(this.cbbGroupID.Text) + 1).ToString());
                    isAdd = true;
                }
                model.GroupID = this.GroupID;
                model.Verifystyle = 0;
                model.Holidayvaild = this.chkholidayvaild.Checked;
                model.Name = this.textBox1.Text;
                model.TimeZone1 = (short)(this.cbbTimeZone1.Text.TryShort() == null ? 1 : this.cbbTimeZone1.Text.TryShort().Value + 1);
                model.TimeZone2 = (short)(this.cbbTimeZone2.Text.TryShort() == null ? 1 : this.cbbTimeZone2.Text.TryShort().Value + 1);
                model.TimeZone3 = (short)(this.cbbTimeZone3.Text.TryShort() == null ? 1 : this.cbbTimeZone3.Text.TryShort().Value + 1);
                if (!isAdd)
                {
                    bll.Update(model);
                    {
                        MessageBox.Show("保存成功");
                        this.modelData = model;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    bll.Add(model);
                    {
                        MessageBox.Show("保存成功");
                        this.modelData = model;
                        this.DialogResult = DialogResult.OK;
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
