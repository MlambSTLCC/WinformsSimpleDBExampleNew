using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsSimpleDBExample
{
    public partial class frmPerson1 : FormPlus
    {
        private enum TABPAGES
        {
            LIST = 0,
            DETAIL
        }
        
        public frmPerson1()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNewAction();
        }

        protected override void AddNewAction()
        {
            base.AddNewAction();

            this.tabControl1.SelectedIndex = (int)TABPAGES.DETAIL;
            ClearControls(this.tabControl1.TabPages[(int)TABPAGES.DETAIL]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }
    }
}
