using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardSolutionHost.Control
{
    public class MyDataGridView : DataGridView
    {
        #region 实现datagridview右键双击
        private const int GWL_WNDPROC = -4;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_LBUTTONDBLCLK = 0x0203;//双击消息
        private const int WM_RBUTTONDBLCLK = 0x0206;//双击消息
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, MyWndProc wndProc);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public delegate IntPtr MyWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private IntPtr ldWndProc = IntPtr.Zero;
        private MyWndProc Wpr = null;
        #endregion

        //定义delegate
        public delegate void RightMouseCellDoubleClickHandler(object sender, DataGridViewCellEventArgs e);
        public event RightMouseCellDoubleClickHandler RightMouseCellDoubleClick;
        public MyDataGridView()
        {
            this.Wpr = new MyWndProc(this.MyControlWndProc);
            this.ldWndProc = SetWindowLong(this.Handle, GWL_WNDPROC, Wpr);
        }
        /// <summary>
        /// 实现datagridview右键双击
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private IntPtr MyControlWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WM_RBUTTONDBLCLK:
                    var row = this.CurrentCell;
                    if (row == null)
                        this.OnRightMouseCellDoubleClick(null);
                    else
                        this.OnRightMouseCellDoubleClick(new DataGridViewCellEventArgs(row.ColumnIndex, row.RowIndex));
                    return (IntPtr)0;
                default:
                    return CallWindowProc(ldWndProc, hWnd, msg, wParam, lParam);
            }
        }
        //事件触发方法
        protected virtual void OnRightMouseCellDoubleClick(DataGridViewCellEventArgs e)
        {
            if (RightMouseCellDoubleClick != null)
                RightMouseCellDoubleClick(this, e);
        }
    }
}
