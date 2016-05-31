using CardSolutionHost.BLL;
using CardSolutionHost.Core;
using CardSolutionHost.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Net;
using System.ServiceModel;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CardSolutionHost
{
    public partial class MainForm : WeifenLuo.WinFormsUI.Docking.DockContent, IMenJinHost
    {
        public MainForm()
        {
            InitializeComponent();
        }
        bool loaded = false;
        UdpMsgService udpmsgservice;
        IReStartService irestartservice;
        ServiceHost hostZKService = null;
        ServiceHost menjincontrolerservice = null;
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (loaded) return;
                #region 启动门禁监控
                NavigationWorkForm navigationForm = null;
                foreach (DockContent frm in this.dockPanel.Contents)
                {
                    if (frm is NavigationWorkForm)
                    {
                        frm.Activate();     //激活子窗体
                        return;
                    }
                }
                navigationForm = ServiceLoader.LoadService<IMenJinControler>() as NavigationWorkForm;
                navigationForm.ShowHint = DockState.Document;
                navigationForm.Show(dockPanel);
                #endregion
                #region UdpMsgService
                udpmsgservice = new UdpMsgService();
                udpmsgservice.Start();
                #endregion;
                #region IReStartService
                irestartservice = ServiceLoader.LoadService<IReStartService>();
                irestartservice.Start();
                #endregion;
                #region hostZKService
                if (hostZKService == null)
                {
                    hostZKService = new ServiceHost(typeof(CardSystem_Service.ZKManage.ZKService));
                    System.ServiceModel.Channels.Binding binding = new NetTcpBinding(SecurityMode.None);
                    string strUrl = string.Format("net.tcp://{0}:{1}/ZK/ZKService", IPAddress.Any, SystemConfig.WcfServicePort);
                    hostZKService.AddServiceEndpoint(typeof(CardSystem_Service.ZKManage.IZKService), binding, strUrl);
                    if (hostZKService.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
                    {
                        System.ServiceModel.Channels.BindingElement elemnt = new System.ServiceModel.Channels.TcpTransportBindingElement();
                        System.ServiceModel.Channels.CustomBinding bind = new System.ServiceModel.Channels.CustomBinding(elemnt);
                        hostZKService.Description.Behaviors.Add(new System.ServiceModel.Description.ServiceMetadataBehavior());
                        hostZKService.AddServiceEndpoint(typeof(System.ServiceModel.Description.IMetadataExchange), bind, strUrl + "/Mex");
                    }
                }
                if (hostZKService.State != CommunicationState.Opened)
                    hostZKService.Open();
                #endregion;

                //#region menjincontrolerservice
                //if (menjincontrolerservice == null)
                //{
                //    menjincontrolerservice = new ServiceHost(typeof(MenJinControlerService));
                //    System.ServiceModel.Channels.Binding binding = new NetTcpBinding(SecurityMode.None);
                //    string strUrl = string.Format("net.tcp://{0}:{1}/MenJinControlerService", IPAddress.Any, SystemConfig.WcfServicePort);
                //    menjincontrolerservice.AddServiceEndpoint(typeof(IMenJinControlerService), binding, strUrl);
                //    if (menjincontrolerservice.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
                //    {
                //        System.ServiceModel.Channels.BindingElement elemnt = new System.ServiceModel.Channels.TcpTransportBindingElement();
                //        System.ServiceModel.Channels.CustomBinding bind = new System.ServiceModel.Channels.CustomBinding(elemnt);
                //        menjincontrolerservice.Description.Behaviors.Add(new System.ServiceModel.Description.ServiceMetadataBehavior());
                //        menjincontrolerservice.AddServiceEndpoint(typeof(System.ServiceModel.Description.IMetadataExchange), bind, strUrl + "/Mex");
                //    }
                //}
                //if (menjincontrolerservice.State != CommunicationState.Opened)
                //    menjincontrolerservice.Open();
                //#endregion;

                #region menjincontrolerservice
                if (menjincontrolerservice == null)
                {
                    menjincontrolerservice = new ServiceHost(typeof(MenJinControlerService));
                    System.ServiceModel.Channels.Binding binding = new NetTcpBinding(SecurityMode.None) { MaxReceivedMessageSize = 2147483647 };
                    //string strUrl = string.Format("net.tcp://{0}:{1}/MenJinControlerService", "192.168.0.170", SystemConfig.WcfServicePort);
                    string strUrl = string.Format("net.tcp://{0}:{1}/MenJinControlerService", IPAddress.Any, SystemConfig.WcfServicePort);
                    menjincontrolerservice.AddServiceEndpoint(typeof(IMenJinControlerService), binding, strUrl);

                    if (menjincontrolerservice.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
                    {
                        System.ServiceModel.Channels.BindingElement elemnt = new System.ServiceModel.Channels.TcpTransportBindingElement();
                        System.ServiceModel.Channels.CustomBinding bind = new System.ServiceModel.Channels.CustomBinding(elemnt);
                        menjincontrolerservice.Description.Behaviors.Add(new System.ServiceModel.Description.ServiceMetadataBehavior());
                        menjincontrolerservice.AddServiceEndpoint(typeof(System.ServiceModel.Description.IMetadataExchange), bind, strUrl + "/Mex");
                    }
                }
                if (menjincontrolerservice.State != CommunicationState.Opened)
                    menjincontrolerservice.Open();
                #endregion

                loaded = true;
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
                //MessageBox.Show("程序发生了不可预知的错误需要退出");
                //Environment.Exit(-1);
                Application.Restart();
            }
        }
        #region 菜单事件


        public void toolStripRefreshServer_Click(object sender, EventArgs e)
        {
            ServiceLoader.LoadService<IMenJinControler>().RunRefreshMachine();
        }

        public void toolStripStartServer_Click(object sender, EventArgs e)
        {
            ServiceLoader.LoadService<IMenJinControler>().RunReloadMachine();
        }
        /// <summary>
        /// 门禁显示设置
        /// </summary>
        private void toolStripMachineShowSet_Click(object sender, EventArgs e)
        {
            MenJin.MachineManage frmMachineManage = new MenJin.MachineManage();
            var dia = frmMachineManage.ShowDialog();
            try
            {
                if (dia == DialogResult.OK)
                {
                    ServiceLoader.LoadService<IMenJinControler>().RunReloadMachine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 门禁刷新重启设置
        /// </summary>
        private void toolStripStatusSet_Click(object sender, EventArgs e)
        {
            MenJinSet frmMenJinSet = new MenJinSet();
            var dia = frmMenJinSet.ShowDialog();
            try
            {
                if (dia == DialogResult.OK)
                {
                    ServiceLoader.LoadService<IMenJinControler>().RunReloadMachine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region 两个属性
        public bool CanReStart
        {
            get
            {
                return (bool)this.Invoke(new Func<bool>(() =>
                {
                    return toolStripReStartServer.Enabled;
                }));
            }

            set
            {
                this.Invoke(new Action(() =>
                {
                    if (toolStripReStartServer.Enabled == value)
                        return;
                    toolStripReStartServer.Enabled = value;
                }));
            }
        }

        public bool CanRefresh
        {
            get
            {
                return (bool)this.Invoke(new Func<bool>(() =>
                 {
                     return toolStripRefreshServer.Enabled;
                 }));
            }

            set
            {
                this.Invoke(new Action(() =>
                {
                    if (toolStripRefreshServer.Enabled == value)
                        return;
                    toolStripRefreshServer.Enabled = value;
                }));
            }
        }
        #endregion
        #region 暂时没用到的菜单事件
        private void 数据库连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseSet frmDataBaseSet = new DataBaseSet();
            frmDataBaseSet.StartPosition = FormStartPosition.CenterParent;
            var dia = frmDataBaseSet.ShowDialog();
            try
            {
                if (dia == DialogResult.OK)
                {
                    ServiceLoader.LoadService<IMenJinControler>().RunReloadMachine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toolStripUpLoad_Click(object sender, EventArgs e)
        {
            //CardSolutionHost.MenJin.MenJinLog frm = new CardSolutionHost.MenJin.MenJinLog();
            //frm.ShowDialog();
        }

        private void toolStripACTimeZones_Click(object sender, EventArgs e)
        {
            //MenJin.ACTimeZonesManage frm = new CardSolutionHost.MenJin.ACTimeZonesManage();
            //frm.ShowDialog();
        }

        private void toolStripACGroup_Click(object sender, EventArgs e)
        {
            //MenJin.ACGroupManage frm = new CardSolutionHost.MenJin.ACGroupManage();
            //frm.ShowDialog();
        }

        private void toolStripacholiday_Click(object sender, EventArgs e)
        {
            //MenJin.acholidayManage frm = new CardSolutionHost.MenJin.acholidayManage();
            //frm.ShowDialog();
        }

        private void toolStripACUnlockComb_Click(object sender, EventArgs e)
        {
            //MenJin.ACUnlockCombManage frm = new CardSolutionHost.MenJin.ACUnlockCombManage();
            //frm.ShowDialog();
        }

        private void toolStripUserACPrivilege_Click(object sender, EventArgs e)
        {
            //CardSolutionHost.MenJin.AttenPosition frm = new CardSolutionHost.MenJin.AttenPosition();
            //frm.ShowDialog();
        }
        #endregion

        #region 一般事件

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Application.Exit();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Application.Exit();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("是否确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.No)
            //    e.Cancel = true;
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                notifyIcon.Visible = true;
                //this.ShowInTaskbar = true;  //显示在系统任务栏
                this.Hide();
                return;
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.ShowInTaskbar = true;  //显示在系统任务栏
            this.WindowState = FormWindowState.Normal;  //还原窗体
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = false;  //不显示在系统任务栏
            notifyIcon.Visible = true;  //托盘图标可见
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = true;  //显示在系统任务栏
            this.WindowState = FormWindowState.Normal;  //还原窗体
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Application.Exit();
        }
        #endregion
    }
}
