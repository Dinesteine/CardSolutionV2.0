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
    public partial class ACUnlockCombEdit : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        BLL_Service.MenJin.ACUnlockCombBLL bll = new BLL_Service.MenJin.ACUnlockCombBLL();
        short UnlockCombID { get; set; }
        internal Model_Service.MenJin.ACUnlockComb model { get; set; }
        public ACUnlockCombEdit(short UnlockCombID)
        {
            this.UnlockCombID = UnlockCombID;
            InitializeComponent();
        }

        private void Init()
        {
            BLL_Service.MenJin.ACGroupBLL bllACGroup = new BLL_Service.MenJin.ACGroupBLL();
            var result = bllACGroup.GetData(string.Format("and (GroupID<> {0}) ", Model_Service.MenJin.ACGroup.MinGroupID)).Tables[0];
            for (int i = 0; i < result.Rows.Count; i++)
            {
                result.Rows[i]["GroupID"] = Convert.ToInt16(result.Rows[i]["GroupID"]) - 1;
            }
            result.AcceptChanges();
            var row = result.NewRow();
            row["GroupID"] = 0;
            result.Rows.InsertAt(row, 0);
            this.cbbGroup01.DataSource = result.Copy();
            this.cbbGroup01.DisplayMember = "GroupID";
            this.cbbGroup01.ValueMember = "GroupID";
            this.cbbGroup02.DataSource = result.Copy();
            this.cbbGroup02.DisplayMember = "GroupID";
            this.cbbGroup02.ValueMember = "GroupID";
            this.cbbGroup03.DataSource = result.Copy();
            this.cbbGroup03.DisplayMember = "GroupID";
            this.cbbGroup03.ValueMember = "GroupID";
            this.cbbGroup04.DataSource = result.Copy();
            this.cbbGroup04.DisplayMember = "GroupID";
            this.cbbGroup04.ValueMember = "GroupID";
            this.cbbGroup05.DataSource = result.Copy();
            this.cbbGroup05.DisplayMember = "GroupID";
            this.cbbGroup05.ValueMember = "GroupID";
            if (UnlockCombID > 0)
            {
                this.cbbUnlockCombID.Enabled = false;
                model = this.bll.GetModel(UnlockCombID);
                this.cbbUnlockCombID.Text = model.UnlockCombID.ToString();
                this.textBox1.Text = model.Name;
                this.cbbGroup01.SelectedValue = (model.Group01 - 1) < 0 ? 0 : (model.Group01 - 1);
                this.cbbGroup02.SelectedValue = (model.Group02 - 1) < 0 ? 0 : (model.Group02 - 1);
                this.cbbGroup03.SelectedValue = (model.Group03 - 1) < 0 ? 0 : (model.Group03 - 1);
                this.cbbGroup04.SelectedValue = (model.Group04 - 1) < 0 ? 0 : (model.Group04 - 1);
                this.cbbGroup05.SelectedValue = (model.Group05 - 1) < 0 ? 0 : (model.Group05 - 1);
            }
            else
            {
                this.cbbGroup01.SelectedValue = 0;
                this.cbbGroup02.SelectedValue = 0;
                this.cbbGroup03.SelectedValue = 0;
                this.cbbGroup04.SelectedValue = 0;
                this.cbbGroup05.SelectedValue = 0;
            }
        }
        private void ACUnlockCombEdit_Load(object sender, EventArgs e)
        {
            this.Init();
            if (this.cbbUnlockCombID.SelectedIndex < 0)
                this.cbbUnlockCombID.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (UnlockCombID <= 0)
                {
                    model = new Model_Service.MenJin.ACUnlockComb();
                    model.UnlockCombID = short.Parse(this.cbbUnlockCombID.Text);
                }
                model.Group01 = this.cbbGroup01.Text.TryShort() ?? 0;
                model.Group02 = this.cbbGroup02.Text.TryShort() ?? 0;
                model.Group03 = this.cbbGroup03.Text.TryShort() ?? 0;
                model.Group04 = this.cbbGroup04.Text.TryShort() ?? 0;
                model.Group05 = this.cbbGroup05.Text.TryShort() ?? 0;
                model.Group01 = model.Group01 == 0 ? Convert.ToInt16(0) : Convert.ToInt16(model.Group01 + 1);
                model.Group02 = model.Group02 == 0 ? Convert.ToInt16(0) : Convert.ToInt16(model.Group02 + 1);
                model.Group03 = model.Group03 == 0 ? Convert.ToInt16(0) : Convert.ToInt16(model.Group03 + 1);
                model.Group04 = model.Group04 == 0 ? Convert.ToInt16(0) : Convert.ToInt16(model.Group04 + 1);
                model.Group05 = model.Group05 == 0 ? Convert.ToInt16(0) : Convert.ToInt16(model.Group05 + 1);
                model.Name = this.textBox1.Text;
                if (UnlockCombID > 0)
                {
                    bll.Update(model);
                    {
                        MessageBox.Show("保存成功");
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
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
