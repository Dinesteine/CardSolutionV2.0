using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Extention.StringExtention;
using Extention.DataExtion;
namespace CardSolutionHost.MenJin
{
    public partial class MenJinLog : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private string strEndString = "-------------------------------------";
        public delegate void AsynccallbackHandle();
        //CardSystem_Service.ZK.ZKService api = new CardSystem_Service.ZK.ZKService();
        zkemkeeper.CZKEMClass api = new zkemkeeper.CZKEMClass();
        IList<Model_Service.MenJin.ACTimeZone> listACTimeZones;
        IList<Model_Service.MenJin.ACGroup> listACGroup;
        IList<Model_Service.MenJin.ACUnlockComb> listACUnlockComb;
        IList<Model_Service.MenJin.UserACPrivilege> listUserACPrivilege;
        IList<Model_Service.Hr.HREmployee> listEmployee;
        private string strErrorMessage = string.Empty;
        BLL_Service.MenJin.UserACPrivilegeBLL bllUserACPrivilege = new BLL_Service.MenJin.UserACPrivilegeBLL();
        BLL_Service.MenJin.ACGroupBLL bllGroup = new BLL_Service.MenJin.ACGroupBLL();
        BLL_Service.MenJin.ACTimeZoneBLL bllACTimeZone = new BLL_Service.MenJin.ACTimeZoneBLL();
        BLL_Service.MenJin.AcholidayBLL bllAcholiday = new BLL_Service.MenJin.AcholidayBLL();
        public MenJinLog()
        {
            InitializeComponent();
        }

        private void MenJinLog_Load(object sender, EventArgs e)
        {
            this.dgvMachine.AutoGenerateColumns = false;
            var result = new BLL_Service.MenJin.MachinesBLL().GetData(string.Empty).Tables[0];
            result.Columns.Add("IsSelected", typeof(bool));
            foreach (DataRow item in result.Rows)
            {
                item["IsSelected"] = true;
                item.AcceptChanges();
            }
            this.dgvMachine.DataSource = result;
        }

        #region 上传权限
        void Upload()
        {
            try
            {
                this.strErrorMessage = string.Empty;
                for (int i = 0; i < this.dgvMachine.Rows.Count; i++)
                {
                    DataRowView drv = this.dgvMachine.Rows[i].DataBoundItem as DataRowView;
                    if (Convert.ToBoolean(drv["IsSelected"]))
                    {
                        if (api.Connect_Net(drv["IP"].ToString(), Convert.ToInt32(drv["Port"])))
                        {
                            this.ListAddString(string.Format("设备“{0}”连接成功", drv["MachineAlias"]));
                            this.ListAddString(string.Format("开始上传权限至“{0}”{1}", drv["MachineAlias"], strEndString));
                            var model = drv.Row.ToModel<Model_Service.MenJin.Machine>();
                            if (this.chkACTimeZone.Checked)
                                this.UploadACTimeZones(model);
                            if (this.chkGroup.Checked)
                                this.UpLoadGroup(model);
                            if (this.chkACUnlockComb.Checked)
                                this.UpLoadACUnlockComb(model);
                            if (this.chkUserACPrivilege.Checked)
                                this.UpLoadUserGroupOrTimeZone(model);
                            api.RefreshData(Convert.ToInt32(drv["MachineNumber"]));
                        }
                    }
                }
                var list = this.bllAcholiday.GetList(" and getdate() between Begindate and Enddate");
                foreach (var item in list)
                {
                    item.Status = 0;
                    this.bllAcholiday.Update(item);
                }
            }
            catch (Exception ex)
            {
                strErrorMessage = ex.Message;
            }
        }
        void UploadCallback(IAsyncResult ar)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                if (!this.strErrorMessage.IsNullOrEmpty())
                    MessageBox.Show(strErrorMessage);
                else
                    MessageBox.Show("上传完毕");
            }));
        }
        #endregion
        #region 上传时间段
        void UploadACTimeZones(Model_Service.MenJin.Machine machine)
        {
            this.ListAddString(string.Format("开始上传时间段至机器“{0}”{1}", machine.MachineAlias, strEndString));
            if (listACTimeZones == null)
                listACTimeZones = new BLL_Service.MenJin.ACTimeZoneBLL().GetList(string.Empty);
            foreach (var actimezone in listACTimeZones)
            {
                string stractimezone = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}"
                    , actimezone.SunStart.ToString("HHmm"), actimezone.SunEnd.ToString("HHmm")
                    , actimezone.MonStart.ToString("HHmm"), actimezone.MonEnd.ToString("HHmm")
                    , actimezone.TuesStart.ToString("HHmm"), actimezone.TuesEnd.ToString("HHmm")
                    , actimezone.WedStart.ToString("HHmm"), actimezone.WedEnd.ToString("HHmm")
                    , actimezone.ThursStart.ToString("HHmm"), actimezone.ThursEnd.ToString("HHmm")
                    , actimezone.FriStart.ToString("HHmm"), actimezone.FriEnd.ToString("HHmm")
                    , actimezone.SatStart.ToString("HHmm"), actimezone.SatEnd.ToString("HHmm")
                    );
                if (api.SetTZInfo(machine.MachineNumber, actimezone.TimeZoneID, stractimezone))
                    this.ListAddString(string.Format("上传时间段“{0}”至机器“{1}”成功", actimezone.TimeZoneID, machine.MachineAlias));
                else
                    this.ListAddString(string.Format("上传时间段“{0}”至机器“{1}”失败", actimezone.TimeZoneID, machine.MachineAlias));
            }
            this.ListAddString(string.Format("上传时间段至机器“{0}”完毕{1}", machine.MachineAlias, strEndString));
        }
        #endregion
        #region 上传组
        void UpLoadGroup(Model_Service.MenJin.Machine machine)
        {
            this.ListAddString(string.Format("开始上传组段至机器“{0}”{1}", machine.MachineAlias, strEndString));
            if (listACGroup == null)
                listACGroup = new BLL_Service.MenJin.ACGroupBLL().GetList(null);
            foreach (var group in listACGroup)
            {
                string sTZs = string.Format("{0}:{1}:{2}", group.TimeZone1, group.TimeZone2, group.TimeZone3);
                //if (api.SetGroupTZStr(machine.MachineNumber, (int)group.GroupID, sTZs) &&
                //      api.SetSysOption(machine.MachineNumber, "GVS" + group.GroupID.ToString(), "0"))
                if (api.SetGroupTZStr(machine.MachineNumber, (int)group.GroupID, sTZs))
                    this.ListAddString(string.Format("上传组“{0}”至机器“{1}”成功", group.GroupID, machine.MachineAlias));
                else
                    this.ListAddString(string.Format("上传组“{0}”至机器“{1}”失败", group.GroupID, machine.MachineAlias));
            }
            this.ListAddString(string.Format("上传组至机器“{0}”完毕{1}", machine.MachineAlias, strEndString));
        }
        #endregion
        #region 上传开锁组合
        void UpLoadACUnlockComb(Model_Service.MenJin.Machine machine)
        {
            this.ListAddString(string.Format("开始上传开锁组合段至机器“{0}”{1}", machine.MachineAlias, strEndString));
            if (listACUnlockComb == null)
                listACUnlockComb = new BLL_Service.MenJin.ACUnlockCombBLL().GetList(null);
            StringBuilder sbResult = new StringBuilder();
            for (int i = 1; i < 10; i++)
            {
                var result = listACUnlockComb.FirstOrDefault(t => t.UnlockCombID == i);
                if (result == null)
                {
                    sbResult.Append(string.Empty);
                }
                else
                {
                    sbResult.AppendFormat("{0}{1}{2}{3}{4}"
                        , result.Group01 > 0 ? result.Group01.ToString() : string.Empty
                        , result.Group02 > 0 ? result.Group02.ToString() : string.Empty
                        , result.Group03 > 0 ? result.Group03.ToString() : string.Empty
                        , result.Group04 > 0 ? result.Group04.ToString() : string.Empty
                        , result.Group05 > 0 ? result.Group05.ToString() : string.Empty);
                }
                if (i <= 8)
                {
                    sbResult.Append(":");
                }
            }
            if (api.SetUnlockGroups(machine.MachineNumber, sbResult.ToString()))
                this.ListAddString(string.Format("上传开锁组合至机器“{0}”成功", machine.MachineAlias));
            else
                this.ListAddString(string.Format("上传开锁组合至机器“{0}”失败", machine.MachineAlias));
        }
        #endregion
        #region 上传用户组及用户时间段
        void UpLoadUserGroupOrTimeZone(Model_Service.MenJin.Machine machine)
        {
            try
            {
                var groups = bllGroup.GetList(string.Empty);
                var times = bllACTimeZone.GetList(string.Empty);

                this.ListAddString(string.Format("开始上传用户组及用户时间段段至机器“{0}”{1}", machine.MachineAlias, strEndString));
                string strwhere = " and (DeviceID = " + machine.Id + ") ";
                if (!this.chkMJFK.Checked)
                    strwhere = " and ((ACGroupID!=ACGroupID1) or (TimeZone1!=TimeZone11) or (TimeZone2!=TimeZone21) or(TimeZone3!=TimeZone31))";
                listUserACPrivilege = bllUserACPrivilege.GetList(strwhere);
                if (listEmployee == null)
                    listEmployee = new BLL_Service.Hr.HREmployeeBLL().GetList(" and status <> '离职'");
                foreach (var useracprivilege in listUserACPrivilege)
                {
                    var user = listEmployee.FirstOrDefault(t => t.Id == useracprivilege.Id.UserID);
                    if (user == null)
                    {
                        this.bllUserACPrivilege.Delete(useracprivilege.Id.DeviceID, useracprivilege.Id.UserID);
                    }
                    else
                    {
                        if (useracprivilege.IsUseGroup)
                        {
                            api.SetUserTZStr(machine.MachineNumber, user.Id, "0:0:0");
                            if (api.SetUserGroup(machine.MachineNumber, user.Id, useracprivilege.ACGroupID))
                                this.ListAddString(string.Format("上传用户组“{0}--{1}”至机器“{2}”成功", user.EmpName, useracprivilege.ACGroupID, machine.MachineAlias));
                            else
                                this.ListAddString(string.Format("上传用户组“{0}--{1}”至机器“{2}”失败", user.EmpName, useracprivilege.ACGroupID, machine.MachineAlias));
                        }
                        else
                        {
                            string sTZs = string.Format("{0}:{1}:{2}", useracprivilege.TimeZone1, useracprivilege.TimeZone2, useracprivilege.TimeZone3);
                            if (api.SetUserTZStr(machine.MachineNumber, user.Id, sTZs))
                            {
                                string result = string.Empty;
                                api.GetUserTZStr(machine.MachineNumber, user.Id, ref result);
                                this.ListAddString(string.Format("上传用户时间段“{0}--{1}”至机器“{2}”成功", user.EmpName, sTZs, machine.MachineAlias));
                            }
                            else
                                this.ListAddString(string.Format("上传用户时间段“{0}--{1}”至机器“{2}”失败", user.EmpName, sTZs, machine.MachineAlias));
                        }
                        useracprivilege.ACGroupID1 = useracprivilege.ACGroupID;
                        useracprivilege.TimeZone11 = useracprivilege.TimeZone1;
                        useracprivilege.TimeZone21 = useracprivilege.TimeZone2;
                        useracprivilege.TimeZone31 = useracprivilege.TimeZone3;
                        this.bllUserACPrivilege.Update(useracprivilege);
                    }
                }
                this.ListAddString(string.Format("开始上传用户组及用户时间段段至机器“{0}”完毕{1}", machine.MachineAlias, strEndString));
            }
            catch (Exception ex)
            {
                strErrorMessage = ex.Message;
            }
        }
        #endregion
        private void ListAddString(string strMessage)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                this.listBox1.Items.Add(strMessage);
            }));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AsynccallbackHandle UpLoadHandle = new AsynccallbackHandle(Upload);
            IAsyncResult resultUpLoad = UpLoadHandle.BeginInvoke(new AsyncCallback(UploadCallback), UpLoadHandle);
        }

        private void dgvMachine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                DataRow dr = (this.dgvMachine.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                if (dr["IsSelected"].GetType().Name == "DBNull")
                    dr["IsSelected"] = true;
                else
                    dr["IsSelected"] = !Convert.ToBoolean(dr["IsSelected"]);
                dr.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMachine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                switch (this.dgvMachine.Columns[e.ColumnIndex].Name)
                {
                    case "IsSelected":
                        DataRow dr = (this.dgvMachine.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                        bool result;
                        if (bool.TryParse(dr["IsSelected"].ToString(), out result))
                            dr["IsSelected"] = !result;
                        else
                            dr["IsSelected"] = true;
                        dr.AcceptChanges();
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}