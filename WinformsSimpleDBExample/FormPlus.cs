using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsSimpleDBExample
{
    public partial class FormPlus : Form
    {
        protected DataTable DT = null;
        protected Dictionary<string, object> DictControlValues = new Dictionary<string, object>();
        protected DataGridView DGV = null;
        protected Button SaveButton = null;
        protected Button AddButton = null;

        protected EventHandler saveButtonHandler = null;
        protected EventHandler addButtonHandler = null;

        public FormPlus()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadAction();
            this.FormClosing += (s, e) => CloseAction();
        }

        private void FormPlus_Load(object sender, EventArgs e)
        {
            //LoadDictionaryFromObject();
            //LoadControlsFromDictionary();
            LoadEventHandlers();
        }

        private void LoadEventHandlers() 
        {
            //formLoadHandler = (s, e) => LoadAction();
            //this.OnFormLoad += formLoadHandler;
            //formClosingHandler = (s, e) => CloseAction();
            //this.OnFormClosing += formClosingHandler;
        }

        protected virtual void AddNewAction()
        {
            //Default add new actions
        }

        private void SaveData(object s)
        {
            SaveAction();
        }

        protected void ClearControls(Control parent) 
        {
            ForAllControls(parent, "clearValue");
        }

        protected void SetDataGridView(Control parent) 
        {
            ForAllControls(this, "setDGV");
        }

        protected void SetSaveButton(Control parent) 
        {
            ForAllControls(this, "setSave");
        }
        
        protected void ControlValuesToTable() 
        {
            DictControlValues.Clear();

            ForAllControls(this, "getValue");

            DataRow row = this.DT.Rows.Add();
            foreach (DataColumn col in DT.Columns)
                if (col.ColumnName.ToLower() != "id")
                    row[col.ColumnName] = DictControlValues[col.ColumnName];
        }

        protected void CreateDataTableToMatchControls() 
        {
            DT = new DataTable(this.Name);  //name table after form
            var simpleDB = new SimpleDB();
            simpleDB.CreateIdentityColumn(ref DT); 

            ForAllControls(this, "createColumn");
        }

        private void ForAllControls(Control parent, string action = "")
        {
            foreach (Control ctl in parent.Controls)
            {
                CheckControls(ctl, action);
                ForAllControls(ctl, action);
            }
        }

        private void CheckControls(Control ctl, string action)
        {
            {
                switch (ctl.GetType().Name)
                {
                    case "TextBox":
                        if (action == "createColumn")
                            DT.Columns.Add(ctl.Name, typeof(string));
                        else if (action == "getValue")
                            DictControlValues.Add(ctl.Name, (ctl as TextBox).Text);
                        else if (action == "clearValue")
                            (ctl as TextBox).Text = string.Empty;
                        break;

                    case "CheckBox":
                        if (action == "createColumn")
                            DT.Columns.Add(ctl.Name, typeof(bool));
                        else if (action == "getValue")
                            DictControlValues.Add(ctl.Name, (ctl as CheckBox).Checked);
                        else if (action == "clearValue")
                           (ctl as CheckBox).Checked = false;
                        break;

                    case "ComboBox":
                        if (action == "createColumn")
                            DT.Columns.Add(ctl.Name, typeof(int));
                        else if (action == "getValue")
                            DictControlValues.Add(ctl.Name, (ctl as ComboBox).SelectedIndex);
                        else if (action == "clearValue")
                            (ctl as ComboBox).SelectedIndex = -1;
                        break;

                    case "DataGridView":
                        if (action == "setDGV")
                            this.DGV = (DataGridView)ctl;
                        break;

                    case "Button":
                        if (action == "setSave" && (ctl as Button).Text.ToLower().Contains("save")) 
                            this.SaveButton = (Button)ctl;
                        break;

                    default:
                        break;
                }
            }
        }

        protected void LoadAction() 
        { 
            //LoadDictionaryFromObject();
            //LoadControlsFromDictionary();
            SetDataGridView(this);

            SetSaveButton(this);
            if (this.SaveButton != null)
            {
                saveButtonHandler = (s, e) => SaveData(s);
                this.SaveButton.Click += saveButtonHandler;
            }

            CreateDataTableToMatchControls();               //generic

            var simpleDB = new SimpleDB();                  //generic
            simpleDB.LoadTable(ref this.DT);

            if (this.DGV != null)
                LoadGrid();
        }

        protected void CloseAction()
        {
            var simpleDB = new SimpleDB();                  //generic
            simpleDB.SaveTable(this.DT);                    //generic
        }

        protected virtual void SaveAction()
        {
            ControlValuesToTable();                         //generic

            if (this.DGV != null)
                LoadGrid();
        }

        private void LoadGrid()
        {
            this.DGV.DataSource = this.DT;
            this.DGV.Columns["Id"].Visible = false;
        }
    }
}


