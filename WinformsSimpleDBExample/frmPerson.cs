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
    public partial class frmPerson : Form
    {
        private DataTable dtPersons = new DataTable("Persons");
        
        public frmPerson()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // add new person
            this.txtLastName.Text = string.Empty;
            this.txtFirstName.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtPhone.Text = string.Empty;
            this.chkMember.Checked = false;

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // save person
            dtPersons.Rows.Add(null,
                this.txtLastName.Text,
                this.txtFirstName.Text,
                this.txtEmail.Text,
                this.txtPhone.Text,
                this.chkMember.Checked
                );

            this.dgvPersons.DataSource = dtPersons;
            this.dgvPersons.Columns["Id"].Visible = false;

            this.tabControl1.SelectedIndex = 0;
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            var simpleDB = new SimpleDB();

            // optional, but makes it easier to update:
            simpleDB.CreateIdentityColumn(ref dtPersons); 

            // add additional columns:
            dtPersons.Columns.Add("LastName", typeof(string));
            dtPersons.Columns.Add("FirstName", typeof(string));
            dtPersons.Columns.Add("Email", typeof(string));
            dtPersons.Columns.Add("Phone", typeof(string));
            dtPersons.Columns.Add("Member", typeof(Boolean));

            simpleDB.LoadTable(ref dtPersons);

            this.dgvPersons.DataSource = dtPersons;

            this.dgvPersons.Columns["Id"].Visible = false;
        }

        private void frmPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            var simpleDB = new SimpleDB();
            simpleDB.SaveTable(dtPersons);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var fPerson1 = new frmPerson1();
            fPerson1.Show();
        }
    }
}
