using CardSolutionHost.Interfaces;
using System;
using System.Windows.Forms;

namespace CardSolutionHost.Control
{
    public partial class AppContainer : UserControl
    {
        public IMenJinRunner Runner { get; set; }
        public AppContainer()
        {
            InitializeComponent();
        }
        private void AppContainer_Load(object sender, EventArgs e)
        {
        }
    }
}
