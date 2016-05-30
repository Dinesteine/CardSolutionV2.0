using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using zkemkeeper;

namespace CardSolutionHost
{
    public partial class APIForm : Form
    {
        public APIForm()
        {
            InitializeComponent();
        }
        public void ReGetAPIAsync()
        {
        }
        private void APIForm_Load(object sender, EventArgs e)
        {
        }

        private void APIForm_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
