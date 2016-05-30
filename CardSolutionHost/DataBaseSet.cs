using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Configuration;

namespace CardSolutionHost
{
    public partial class DataBaseSet : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DataBaseSet()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //string strServer = CSTools.ConfigHelper.ReadAppSetting("server");
            //string strDataBase = CSTools.ConfigHelper.ReadAppSetting("database");
            //string strUId = CSTools.ConfigHelper.ReadAppSetting("uid");
            //string strPwd = CSTools.ConfigHelper.ReadAppSetting("pwd");
            //this.txtServer.Text = CSTools.CSharpEncrypt.Decrypt(strServer);
            //this.txtDataBase.Text = CSTools.CSharpEncrypt.Decrypt(strDataBase);
            //this.txtUId.Text = CSTools.CSharpEncrypt.Decrypt(strUId);
            //this.txtPwd.Text = CSTools.CSharpEncrypt.Decrypt(strPwd);
        }
        private void btnSaveConn_Click(object sender, EventArgs e)
        {
            //string strServer = CSTools.CSharpEncrypt.Encrypt(this.txtServer.Text.Trim());
            //string strDataBase = CSTools.CSharpEncrypt.Encrypt(this.txtDataBase.Text);
            //string strUId = CSTools.CSharpEncrypt.Encrypt(this.txtUId.Text);
            //string strPwd = CSTools.CSharpEncrypt.Encrypt(this.txtPwd.Text);
            //CSTools.ConfigHelper.SetSetting("server", strServer);
            //CSTools.ConfigHelper.SetSetting("database", strDataBase);
            //CSTools.ConfigHelper.SetSetting("uid", strUId);
            //CSTools.ConfigHelper.SetSetting("pwd", strPwd);
            //CSTools.ConfigHelper.Save();
            //MessageBox.Show("保存成功！");
        }
    }
}
