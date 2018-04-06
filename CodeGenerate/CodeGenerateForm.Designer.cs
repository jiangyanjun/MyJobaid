namespace MyJobaid.CodeGenerate
{
    partial class CodeGenerateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeGenerateForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoSqlServer = new System.Windows.Forms.RadioButton();
            this.rdoWindows = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.plLeft = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeDataView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.plMain = new System.Windows.Forms.Panel();
            this.tabCodeContent = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lstViewDataDetail = new System.Windows.Forms.ListView();
            this.chkHandler = new System.Windows.Forms.CheckBox();
            this.chkBusiness = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdoParameterModel = new System.Windows.Forms.RadioButton();
            this.chkProvider = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkGetChild = new System.Windows.Forms.CheckBox();
            this.chkGet = new System.Windows.Forms.CheckBox();
            this.chkExists = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkCreate = new System.Windows.Forms.CheckBox();
            this.chkCount = new System.Windows.Forms.CheckBox();
            this.chkList = new System.Windows.Forms.CheckBox();
            this.chkLoadAll = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkWcf = new System.Windows.Forms.CheckBox();
            this.chkSerializable = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkAbstract = new System.Windows.Forms.CheckBox();
            this.chkEntity = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRunAndGenerate = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtCustomStatement = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.plLeft.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.plMain.SuspendLayout();
            this.tabCodeContent.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ServerName:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(403, 28);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(167, 21);
            this.txtServerName.TabIndex = 1;
            this.txtServerName.Text = ".\\wanglei";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "User:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(749, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(622, 28);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(108, 21);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Text = "sa";
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(814, 28);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(106, 21);
            this.txtUserPwd.TabIndex = 5;
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(939, 27);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(95, 23);
            this.btnConnection.TabIndex = 6;
            this.btnConnection.Text = "Connection";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.cmbDataBase);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rdoSqlServer);
            this.groupBox1.Controls.Add(this.rdoWindows);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUserPwd);
            this.groupBox1.Controls.Add(this.btnConnection);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtServerName);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1283, 94);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection DataBase";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(413, 62);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(97, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load Items";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(142, 64);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(255, 20);
            this.cmbDataBase.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "DataBase List:";
            // 
            // rdoSqlServer
            // 
            this.rdoSqlServer.AutoSize = true;
            this.rdoSqlServer.Location = new System.Drawing.Point(230, 31);
            this.rdoSqlServer.Name = "rdoSqlServer";
            this.rdoSqlServer.Size = new System.Drawing.Size(83, 16);
            this.rdoSqlServer.TabIndex = 8;
            this.rdoSqlServer.Text = "Sql Server";
            this.rdoSqlServer.UseVisualStyleBackColor = true;
            this.rdoSqlServer.CheckedChanged += new System.EventHandler(this.OnAuthenticationTypeChecked);
            // 
            // rdoWindows
            // 
            this.rdoWindows.AutoSize = true;
            this.rdoWindows.Checked = true;
            this.rdoWindows.Location = new System.Drawing.Point(149, 31);
            this.rdoWindows.Name = "rdoWindows";
            this.rdoWindows.Size = new System.Drawing.Size(65, 16);
            this.rdoWindows.TabIndex = 8;
            this.rdoWindows.TabStop = true;
            this.rdoWindows.Text = "Windows";
            this.rdoWindows.UseVisualStyleBackColor = true;
            this.rdoWindows.CheckedChanged += new System.EventHandler(this.OnAuthenticationTypeChecked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "AuthenticationType:";
            // 
            // plLeft
            // 
            this.plLeft.Controls.Add(this.groupBox2);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plLeft.Location = new System.Drawing.Point(0, 0);
            this.plLeft.Name = "plLeft";
            this.plLeft.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.plLeft.Size = new System.Drawing.Size(300, 692);
            this.plLeft.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeDataView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 682);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data View";
            // 
            // treeDataView
            // 
            this.treeDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDataView.ImageIndex = 0;
            this.treeDataView.ImageList = this.imageList1;
            this.treeDataView.Location = new System.Drawing.Point(3, 17);
            this.treeDataView.Margin = new System.Windows.Forms.Padding(10);
            this.treeDataView.Name = "treeDataView";
            this.treeDataView.SelectedImageIndex = 1;
            this.treeDataView.Size = new System.Drawing.Size(294, 662);
            this.treeDataView.TabIndex = 0;
            this.treeDataView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeDataView_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "database.ico");
            this.imageList1.Images.SetKeyName(1, "select.ico");
            this.imageList1.Images.SetKeyName(2, "table.ico");
            this.imageList1.Images.SetKeyName(3, "view.ico");
            this.imageList1.Images.SetKeyName(4, "item.ico");
            this.imageList1.Images.SetKeyName(5, "column.ico");
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.tabCodeContent);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Name = "plMain";
            this.plMain.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.plMain.Size = new System.Drawing.Size(979, 692);
            this.plMain.TabIndex = 9;
            // 
            // tabCodeContent
            // 
            this.tabCodeContent.Controls.Add(this.tabPage1);
            this.tabCodeContent.Controls.Add(this.tabPage2);
            this.tabCodeContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCodeContent.Location = new System.Drawing.Point(0, 10);
            this.tabCodeContent.Name = "tabCodeContent";
            this.tabCodeContent.SelectedIndex = 0;
            this.tabCodeContent.Size = new System.Drawing.Size(979, 682);
            this.tabCodeContent.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.chkHandler);
            this.tabPage1.Controls.Add(this.chkBusiness);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.chkProvider);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.btnGenerate);
            this.tabPage1.Controls.Add(this.txtKeyword);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtNameSpace);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.chkAbstract);
            this.tabPage1.Controls.Add(this.chkEntity);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(971, 656);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lstViewDataDetail);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(10, 10);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(951, 300);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Data Detail";
            // 
            // lstViewDataDetail
            // 
            this.lstViewDataDetail.BackColor = System.Drawing.SystemColors.Window;
            this.lstViewDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViewDataDetail.GridLines = true;
            this.lstViewDataDetail.Location = new System.Drawing.Point(3, 17);
            this.lstViewDataDetail.MaximumSize = new System.Drawing.Size(861, 433);
            this.lstViewDataDetail.Name = "lstViewDataDetail";
            this.lstViewDataDetail.Size = new System.Drawing.Size(861, 280);
            this.lstViewDataDetail.SmallImageList = this.imageList1;
            this.lstViewDataDetail.TabIndex = 2;
            this.lstViewDataDetail.UseCompatibleStateImageBehavior = false;
            this.lstViewDataDetail.View = System.Windows.Forms.View.Details;
            // 
            // chkHandler
            // 
            this.chkHandler.AutoSize = true;
            this.chkHandler.Checked = true;
            this.chkHandler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHandler.Location = new System.Drawing.Point(436, 383);
            this.chkHandler.Name = "chkHandler";
            this.chkHandler.Size = new System.Drawing.Size(66, 16);
            this.chkHandler.TabIndex = 13;
            this.chkHandler.Text = "Handler";
            this.chkHandler.UseVisualStyleBackColor = true;
            // 
            // chkBusiness
            // 
            this.chkBusiness.AutoSize = true;
            this.chkBusiness.Checked = true;
            this.chkBusiness.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBusiness.Location = new System.Drawing.Point(353, 383);
            this.chkBusiness.Name = "chkBusiness";
            this.chkBusiness.Size = new System.Drawing.Size(72, 16);
            this.chkBusiness.TabIndex = 12;
            this.chkBusiness.Text = "Business";
            this.chkBusiness.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoParameterModel);
            this.groupBox5.Location = new System.Drawing.Point(21, 570);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(798, 62);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Provider Atrribute";
            // 
            // rdoParameterModel
            // 
            this.rdoParameterModel.AutoSize = true;
            this.rdoParameterModel.Checked = true;
            this.rdoParameterModel.Location = new System.Drawing.Point(44, 30);
            this.rdoParameterModel.Name = "rdoParameterModel";
            this.rdoParameterModel.Size = new System.Drawing.Size(113, 16);
            this.rdoParameterModel.TabIndex = 3;
            this.rdoParameterModel.TabStop = true;
            this.rdoParameterModel.Text = "Parameter Model";
            this.rdoParameterModel.UseVisualStyleBackColor = true;
            // 
            // chkProvider
            // 
            this.chkProvider.AutoSize = true;
            this.chkProvider.Checked = true;
            this.chkProvider.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProvider.Location = new System.Drawing.Point(271, 382);
            this.chkProvider.Name = "chkProvider";
            this.chkProvider.Size = new System.Drawing.Size(72, 16);
            this.chkProvider.TabIndex = 10;
            this.chkProvider.Text = "Provider";
            this.chkProvider.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkGetChild);
            this.groupBox4.Controls.Add(this.chkGet);
            this.groupBox4.Controls.Add(this.chkExists);
            this.groupBox4.Controls.Add(this.chkDelete);
            this.groupBox4.Controls.Add(this.chkUpdate);
            this.groupBox4.Controls.Add(this.chkCreate);
            this.groupBox4.Controls.Add(this.chkCount);
            this.groupBox4.Controls.Add(this.chkList);
            this.groupBox4.Controls.Add(this.chkLoadAll);
            this.groupBox4.Location = new System.Drawing.Point(21, 491);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(798, 62);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Abstract Atrribute";
            // 
            // chkGetChild
            // 
            this.chkGetChild.AutoSize = true;
            this.chkGetChild.Location = new System.Drawing.Point(593, 29);
            this.chkGetChild.Name = "chkGetChild";
            this.chkGetChild.Size = new System.Drawing.Size(72, 16);
            this.chkGetChild.TabIndex = 3;
            this.chkGetChild.Text = "GetChild";
            this.chkGetChild.UseVisualStyleBackColor = true;
            // 
            // chkGet
            // 
            this.chkGet.AutoSize = true;
            this.chkGet.Checked = true;
            this.chkGet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGet.Location = new System.Drawing.Point(534, 29);
            this.chkGet.Name = "chkGet";
            this.chkGet.Size = new System.Drawing.Size(42, 16);
            this.chkGet.TabIndex = 17;
            this.chkGet.Text = "Get";
            this.chkGet.UseVisualStyleBackColor = true;
            // 
            // chkExists
            // 
            this.chkExists.AutoSize = true;
            this.chkExists.Checked = true;
            this.chkExists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExists.Location = new System.Drawing.Point(461, 29);
            this.chkExists.Name = "chkExists";
            this.chkExists.Size = new System.Drawing.Size(60, 16);
            this.chkExists.TabIndex = 16;
            this.chkExists.Text = "Exists";
            this.chkExists.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(388, 29);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(60, 16);
            this.chkDelete.TabIndex = 15;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(316, 29);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(60, 16);
            this.chkUpdate.TabIndex = 14;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkCreate
            // 
            this.chkCreate.AutoSize = true;
            this.chkCreate.Checked = true;
            this.chkCreate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreate.Location = new System.Drawing.Point(244, 29);
            this.chkCreate.Name = "chkCreate";
            this.chkCreate.Size = new System.Drawing.Size(60, 16);
            this.chkCreate.TabIndex = 13;
            this.chkCreate.Text = "Create";
            this.chkCreate.UseVisualStyleBackColor = true;
            // 
            // chkCount
            // 
            this.chkCount.AutoSize = true;
            this.chkCount.Checked = true;
            this.chkCount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCount.Location = new System.Drawing.Point(180, 29);
            this.chkCount.Name = "chkCount";
            this.chkCount.Size = new System.Drawing.Size(54, 16);
            this.chkCount.TabIndex = 12;
            this.chkCount.Text = "Count";
            this.chkCount.UseVisualStyleBackColor = true;
            // 
            // chkList
            // 
            this.chkList.AutoSize = true;
            this.chkList.Checked = true;
            this.chkList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkList.Location = new System.Drawing.Point(121, 29);
            this.chkList.Name = "chkList";
            this.chkList.Size = new System.Drawing.Size(48, 16);
            this.chkList.TabIndex = 1;
            this.chkList.Text = "List";
            this.chkList.UseVisualStyleBackColor = true;
            // 
            // chkLoadAll
            // 
            this.chkLoadAll.AutoSize = true;
            this.chkLoadAll.Checked = true;
            this.chkLoadAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoadAll.Location = new System.Drawing.Point(44, 29);
            this.chkLoadAll.Name = "chkLoadAll";
            this.chkLoadAll.Size = new System.Drawing.Size(66, 16);
            this.chkLoadAll.TabIndex = 0;
            this.chkLoadAll.Text = "LoadAll";
            this.chkLoadAll.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkWcf);
            this.groupBox3.Controls.Add(this.chkSerializable);
            this.groupBox3.Location = new System.Drawing.Point(21, 414);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(798, 62);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entity";
            // 
            // chkWcf
            // 
            this.chkWcf.AutoSize = true;
            this.chkWcf.Location = new System.Drawing.Point(155, 29);
            this.chkWcf.Name = "chkWcf";
            this.chkWcf.Size = new System.Drawing.Size(42, 16);
            this.chkWcf.TabIndex = 1;
            this.chkWcf.Text = "Wcf";
            this.chkWcf.UseVisualStyleBackColor = true;
            // 
            // chkSerializable
            // 
            this.chkSerializable.AutoSize = true;
            this.chkSerializable.Location = new System.Drawing.Point(44, 29);
            this.chkSerializable.Name = "chkSerializable";
            this.chkSerializable.Size = new System.Drawing.Size(96, 16);
            this.chkSerializable.TabIndex = 0;
            this.chkSerializable.Text = "Serializable";
            this.chkSerializable.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(736, 336);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(83, 23);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(451, 337);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(210, 21);
            this.txtKeyword.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(392, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "Keyword:";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(89, 337);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(278, 21);
            this.txtNameSpace.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "NameSpace:";
            // 
            // chkAbstract
            // 
            this.chkAbstract.AutoSize = true;
            this.chkAbstract.Checked = true;
            this.chkAbstract.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAbstract.Location = new System.Drawing.Point(193, 382);
            this.chkAbstract.Name = "chkAbstract";
            this.chkAbstract.Size = new System.Drawing.Size(72, 16);
            this.chkAbstract.TabIndex = 2;
            this.chkAbstract.Text = "Abstract";
            this.chkAbstract.UseVisualStyleBackColor = true;
            // 
            // chkEntity
            // 
            this.chkEntity.AutoSize = true;
            this.chkEntity.Checked = true;
            this.chkEntity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEntity.Location = new System.Drawing.Point(127, 382);
            this.chkEntity.Name = "chkEntity";
            this.chkEntity.Size = new System.Drawing.Size(60, 16);
            this.chkEntity.TabIndex = 1;
            this.chkEntity.Text = "Entity";
            this.chkEntity.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Generate Items:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRunAndGenerate);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.Size = new System.Drawing.Size(971, 656);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Custom Model";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRunAndGenerate
            // 
            this.btnRunAndGenerate.Location = new System.Drawing.Point(13, 326);
            this.btnRunAndGenerate.Name = "btnRunAndGenerate";
            this.btnRunAndGenerate.Size = new System.Drawing.Size(158, 23);
            this.btnRunAndGenerate.TabIndex = 8;
            this.btnRunAndGenerate.Text = "Run And Generate";
            this.btnRunAndGenerate.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtCustomStatement);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(10, 10);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(951, 301);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Custom Sql Statement";
            // 
            // txtCustomStatement
            // 
            this.txtCustomStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomStatement.Location = new System.Drawing.Point(3, 17);
            this.txtCustomStatement.Name = "txtCustomStatement";
            this.txtCustomStatement.Size = new System.Drawing.Size(945, 281);
            this.txtCustomStatement.TabIndex = 0;
            this.txtCustomStatement.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(10, 104);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.plLeft);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.plMain);
            this.splitContainer1.Size = new System.Drawing.Size(1283, 692);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 10;
            this.splitContainer1.TabStop = false;
            // 
            // CodeGenerateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 806);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CodeGenerateForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Code Generate";
            this.Load += new System.EventHandler(this.CodeGenerateForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.plLeft.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.tabCodeContent.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoSqlServer;
        private System.Windows.Forms.RadioButton rdoWindows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cmbDataBase;
        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeDataView;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.TabControl tabCodeContent;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkAbstract;
        private System.Windows.Forms.CheckBox chkEntity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkWcf;
        private System.Windows.Forms.CheckBox chkSerializable;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkProvider;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkList;
        private System.Windows.Forms.CheckBox chkLoadAll;
        private System.Windows.Forms.CheckBox chkGet;
        private System.Windows.Forms.CheckBox chkExists;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkCreate;
        private System.Windows.Forms.CheckBox chkCount;
        private System.Windows.Forms.CheckBox chkGetChild;
        private System.Windows.Forms.CheckBox chkBusiness;
        private System.Windows.Forms.CheckBox chkHandler;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox txtCustomStatement;
        private System.Windows.Forms.Button btnRunAndGenerate;
        private System.Windows.Forms.RadioButton rdoParameterModel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListView lstViewDataDetail;
    }
}