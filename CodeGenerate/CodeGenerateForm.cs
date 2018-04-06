using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyJobaid.CodeGenerate.Core;

namespace MyJobaid.CodeGenerate
{
    public partial class CodeGenerateForm : Form
    {

        private SQLDBInfo db = null;

        public CodeGenerateForm()
        {
            InitializeComponent();
        }

        public void CheckAuthenticationType()
        { 
            txtUserName.Enabled = !rdoWindows.Checked;
            txtUserPwd.Enabled = !rdoWindows.Checked;
        }
        private void OnAuthenticationTypeChecked(object sender, EventArgs e)
        {
            CheckAuthenticationType();
        }
        private void CodeGenerateForm_Load(object sender, EventArgs e)
        {
            CheckAuthenticationType();          
            lstViewDataDetail.Columns.Add("序号", 60, HorizontalAlignment.Center);
            lstViewDataDetail.Columns.Add("列名", 150, HorizontalAlignment.Center);
            lstViewDataDetail.Columns.Add("数据类型", 150, HorizontalAlignment.Center);
            lstViewDataDetail.Columns.Add("长度", 100, HorizontalAlignment.Center);
            lstViewDataDetail.Columns.Add("小数", 100, HorizontalAlignment.Center);            
        }

       

        private void btnConnection_Click(object sender, EventArgs e)
        {
            int iAnthenticationType = rdoSqlServer.Checked ? 1 : 0;
            string strServerName = txtServerName.Text.Trim();
            string strUserName = txtUserName.Text.Trim();
            string strUserPwd = txtUserPwd.Text.Trim();
            if (string.IsNullOrEmpty(strServerName))
            {
                MessageBox.Show("please enter your server name or server ip address", "System Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(iAnthenticationType == 1 && (string.IsNullOrEmpty(strUserName) || string.IsNullOrEmpty(strUserPwd)))
            {
                MessageBox.Show("you must be input the username and user password when you choose sql server anthentication type", "System Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db = new SQLDBInfo(iAnthenticationType, strServerName, strUserName, strUserPwd, "master");
            try
            {
                cmbDataBase.Items.Clear();
                foreach (string strDataBaseName in db.GetDatabaseList())
                {
                    cmbDataBase.Items.Add(strDataBaseName);
                }
                cmbDataBase.SelectedIndex = 0;
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message
                    , "System Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cmbDataBase.SelectedItem == null)
            {
                MessageBox.Show("currently you have no optional database.", "System Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            treeDataView.Nodes.Clear();
            string strDatabaseName = cmbDataBase.SelectedItem.ToString().Trim();
            TreeNode tn1 = new TreeNode(strDatabaseName);
            tn1.ImageIndex = 0;
            TreeNode tbls = tn1.Nodes.Add("Tables");
            tbls.ImageIndex = 2;
            TreeNode views = tn1.Nodes.Add("Views");
            views.ImageIndex = 3;
            foreach (string strTableName in db.GetDatabaseTables(strDatabaseName))
            {
                TreeNode tn = new TreeNode(strTableName);
                tn.ImageIndex = 4;
                tn.Tag = "Table";
                tbls.Nodes.Add(tn);
            }
            foreach (string strTableName in db.GetDatabaseViews(strDatabaseName))
            {
                TreeNode tn = new TreeNode(strTableName);
                tn.ImageIndex = 4;
                tn.Tag = "View";
                views.Nodes.Add(tn);
            }            
            treeDataView.Nodes.Add(tn1);
            tn1.ExpandAll();
        }

        private void treeDataView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeNode tn = e.Node;
                if (tn.Tag != null && (tn.Tag.ToString() == "Table" || tn.Tag.ToString() == "View"))
                {
                    FillDataDetail(tn.Text);
                    txtKeyword.Text = tn.Text;                    
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtKeyword.Text.Trim()))
            {
                MessageBox.Show("you must be input the generate keyword.", "System Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (TabPage page in tabCodeContent.TabPages)
            {
                if (page.Tag != null && page.Tag.ToString().Trim() == "Generate")
                {
                    tabCodeContent.TabPages.Remove(page);
                }
            }
            if (treeDataView.SelectedNode != null && treeDataView.SelectedNode.Tag != null 
                && (treeDataView.SelectedNode.Tag.ToString() == "Table" || treeDataView.SelectedNode.Tag.ToString() == "View"))
            {
                GenterateContext context = new GenterateContext();
                FillGenerateContext(context);
                if(context.Entity)
                {
                    AddTab(context, 1);
                }
                if(context.Abstract)
                {
                    AddTab(context, 2);
                }
                if (context.Provider)
                {
                    AddTab(context, 3);
                }
                if (context.Business)
                {
                    AddTab(context, 4);
                }
                if (context.Business)
                {
                    AddTab(context, 5);
                }
            }           
        }

        private void AddTab(GenterateContext context , int iType)
        {
            TabPage page = new TabPage();            
            page.Tag = "Generate";
            RichTextBox txtContent = new RichTextBox();            
            txtContent.Dock = DockStyle.Fill;
            page.Controls.Add(txtContent);
            tabCodeContent.TabPages.Add(page);
            switch (iType)
            {
                case 1:
                    page.Text = "Entity";
                    CodeBuilder.BuildEntityCode(db, context, txtContent);
                    break;
                case 2:
                     page.Text = "Abstract";
                     CodeBuilder.BuildAbstractCode(db, context, txtContent);
                    break;
                case 3:
                    page.Text = "Provider";
                    CodeBuilder.BuildProviderCode(db, context, txtContent);
                    break;
                case 4:
                    page.Text = "Business";
                    CodeBuilder.BuildBusinessCode(db, context, txtContent);
                    break;
                case 5:
                    page.Text = "Handler";
                    CodeBuilder.BuildHandlerCode(db, context, txtContent);
                    break;
                default:
                    break;
            }
        }

        private void FillGenerateContext(GenterateContext context)
        {
            context.DatabaseName = cmbDataBase.SelectedItem.ToString().Trim();
            context.TableName = treeDataView.SelectedNode.Text.Trim();
            context.Keyword = txtKeyword.Text.Trim();
            context.NameSpace = txtNameSpace.Text.Trim();

            context.Entity = chkEntity.Checked;
            context.Abstract = chkAbstract.Checked;
            context.Provider = chkProvider.Checked;
            context.Business = chkBusiness.Checked;
            context.Handler = chkHandler.Checked;

            context.Serializable = chkSerializable.Checked;
            context.Wcf = chkWcf.Checked;

            context.LoadAll = chkLoadAll.Checked;
            context.List = chkList.Checked;
            context.Count = chkCount.Checked;
            context.Create = chkCreate.Checked;
            context.Update = chkUpdate.Checked;
            context.Delete = chkDelete.Checked;
            context.Exists = chkExists.Checked;
            context.Get = chkGet.Checked;
            context.GetChild = chkGetChild.Checked;

            context.Parameter = rdoParameterModel.Checked;
        }

        public void FillDataDetail(string strTableName)
        {
            try
            {
                lstViewDataDetail.Items.Clear();
                string DatabaseName = cmbDataBase.SelectedItem.ToString().Trim();
                int number = 1;
                foreach (ColumnInfo column in db.GetTableColumns(DatabaseName, strTableName))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = Convert.ToString(number);
                    item.ImageIndex = 5;
                    item.SubItems.Add(column.ColumnName);
                    item.SubItems.Add(column.ColumnType);
                    item.SubItems.Add(column.Length);
                    item.SubItems.Add(column.Precision);
                    lstViewDataDetail.Items.Add(item);
                    number++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
