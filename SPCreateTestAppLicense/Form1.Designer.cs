namespace SPAppLicenseCreator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb1 = new System.Windows.Forms.TabControl();
            this.tp1 = new System.Windows.Forms.TabPage();
            this.lnkOpenLicenseManager = new System.Windows.Forms.LinkLabel();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.cbIsSPOnline = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDomain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbSiteUrl = new System.Windows.Forms.TextBox();
            this.tp2 = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbBillingMarket = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbContentMarket = new System.Windows.Forms.TextBox();
            this.ddlSubscriptionStatus = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbSetting_te = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbSetting_sd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSetting_ad = new System.Windows.Forms.TextBox();
            this.ddlAppSubType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSetting_aid = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbAppIconUrl = new System.Windows.Forms.TextBox();
            this.btnGenerateLicense = new System.Windows.Forms.Button();
            this.lnkGenerateCustomerId = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tbImportPurchaserId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbImportProviderName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbImportProductId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbImportAppTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlImportExpiration = new System.Windows.Forms.ComboBox();
            this.ddlImportUserLimit = new System.Windows.Forms.ComboBox();
            this.ddlImportLicenseType = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageBandR = new System.Windows.Forms.PictureBox();
            this.imageBandRwait = new System.Windows.Forms.PictureBox();
            this.tb1.SuspendLayout();
            this.tp1.SuspendLayout();
            this.tp2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBandR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBandRwait)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Controls.Add(this.tp1);
            this.tb1.Controls.Add(this.tp2);
            this.tb1.Location = new System.Drawing.Point(12, 27);
            this.tb1.Name = "tb1";
            this.tb1.SelectedIndex = 0;
            this.tb1.Size = new System.Drawing.Size(820, 369);
            this.tb1.TabIndex = 0;
            // 
            // tp1
            // 
            this.tp1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tp1.Controls.Add(this.lnkOpenLicenseManager);
            this.tp1.Controls.Add(this.btnTestConnection);
            this.tp1.Controls.Add(this.cbIsSPOnline);
            this.tp1.Controls.Add(this.label3);
            this.tp1.Controls.Add(this.tbDomain);
            this.tp1.Controls.Add(this.label2);
            this.tp1.Controls.Add(this.tbPassword);
            this.tp1.Controls.Add(this.label1);
            this.tp1.Controls.Add(this.tbUsername);
            this.tp1.Controls.Add(this.label16);
            this.tp1.Controls.Add(this.tbSiteUrl);
            this.tp1.Location = new System.Drawing.Point(4, 22);
            this.tp1.Name = "tp1";
            this.tp1.Size = new System.Drawing.Size(812, 343);
            this.tp1.TabIndex = 0;
            this.tp1.Text = "Connection Info";
            // 
            // lnkOpenLicenseManager
            // 
            this.lnkOpenLicenseManager.AutoSize = true;
            this.lnkOpenLicenseManager.Location = new System.Drawing.Point(467, 32);
            this.lnkOpenLicenseManager.Name = "lnkOpenLicenseManager";
            this.lnkOpenLicenseManager.Size = new System.Drawing.Size(135, 13);
            this.lnkOpenLicenseManager.TabIndex = 9;
            this.lnkOpenLicenseManager.TabStop = true;
            this.lnkOpenLicenseManager.Text = "Open SP License Manager";
            this.lnkOpenLicenseManager.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenLicenseManager_LinkClicked);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(690, 316);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(119, 23);
            this.btnTestConnection.TabIndex = 8;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // cbIsSPOnline
            // 
            this.cbIsSPOnline.AutoSize = true;
            this.cbIsSPOnline.Location = new System.Drawing.Point(6, 172);
            this.cbIsSPOnline.Name = "cbIsSPOnline";
            this.cbIsSPOnline.Size = new System.Drawing.Size(125, 17);
            this.cbIsSPOnline.TabIndex = 7;
            this.cbIsSPOnline.Text = "Connect to SPOnline";
            this.cbIsSPOnline.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Domain: (leave blank for SPOnline)";
            // 
            // tbDomain
            // 
            this.tbDomain.Location = new System.Drawing.Point(6, 146);
            this.tbDomain.Name = "tbDomain";
            this.tbDomain.Size = new System.Drawing.Size(218, 20);
            this.tbDomain.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(6, 107);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(218, 20);
            this.tbPassword.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(6, 68);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(218, 20);
            this.tbUsername.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Site URL:";
            // 
            // tbSiteUrl
            // 
            this.tbSiteUrl.Location = new System.Drawing.Point(6, 29);
            this.tbSiteUrl.Name = "tbSiteUrl";
            this.tbSiteUrl.Size = new System.Drawing.Size(455, 20);
            this.tbSiteUrl.TabIndex = 0;
            // 
            // tp2
            // 
            this.tp2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tp2.Controls.Add(this.label22);
            this.tp2.Controls.Add(this.groupBox1);
            this.tp2.Controls.Add(this.label11);
            this.tp2.Controls.Add(this.tbAppIconUrl);
            this.tp2.Controls.Add(this.btnGenerateLicense);
            this.tp2.Controls.Add(this.lnkGenerateCustomerId);
            this.tp2.Controls.Add(this.label10);
            this.tp2.Controls.Add(this.tbImportPurchaserId);
            this.tp2.Controls.Add(this.label9);
            this.tp2.Controls.Add(this.tbImportProviderName);
            this.tp2.Controls.Add(this.label8);
            this.tp2.Controls.Add(this.tbImportProductId);
            this.tp2.Controls.Add(this.label7);
            this.tp2.Controls.Add(this.tbImportAppTitle);
            this.tp2.Controls.Add(this.label6);
            this.tp2.Controls.Add(this.label5);
            this.tp2.Controls.Add(this.label4);
            this.tp2.Controls.Add(this.ddlImportExpiration);
            this.tp2.Controls.Add(this.ddlImportUserLimit);
            this.tp2.Controls.Add(this.ddlImportLicenseType);
            this.tp2.Controls.Add(this.label39);
            this.tp2.Controls.Add(this.label32);
            this.tp2.Location = new System.Drawing.Point(4, 22);
            this.tp2.Name = "tp2";
            this.tp2.Size = new System.Drawing.Size(812, 343);
            this.tp2.TabIndex = 6;
            this.tp2.Text = "Create License";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(720, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "Create a SharePoint or Office test license.  This program is intended for creatin" +
    "g SharePoint test licenses, and the defaults below are configured for that.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.tbBillingMarket);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.tbContentMarket);
            this.groupBox1.Controls.Add(this.ddlSubscriptionStatus);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.tbSetting_te);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.tbSetting_sd);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbSetting_ad);
            this.groupBox1.Controls.Add(this.ddlAppSubType);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbSetting_aid);
            this.groupBox1.Location = new System.Drawing.Point(374, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 238);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced Settings";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 210);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 13);
            this.label21.TabIndex = 40;
            this.label21.Text = "Billing Market:";
            // 
            // tbBillingMarket
            // 
            this.tbBillingMarket.Location = new System.Drawing.Point(149, 207);
            this.tbBillingMarket.Name = "tbBillingMarket";
            this.tbBillingMarket.Size = new System.Drawing.Size(274, 20);
            this.tbBillingMarket.TabIndex = 39;
            this.tbBillingMarket.Text = "US";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 184);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Content Market:";
            // 
            // tbContentMarket
            // 
            this.tbContentMarket.Location = new System.Drawing.Point(149, 181);
            this.tbContentMarket.Name = "tbContentMarket";
            this.tbContentMarket.Size = new System.Drawing.Size(274, 20);
            this.tbContentMarket.TabIndex = 37;
            this.tbContentMarket.Text = "en-US";
            // 
            // ddlSubscriptionStatus
            // 
            this.ddlSubscriptionStatus.FormattingEnabled = true;
            this.ddlSubscriptionStatus.Location = new System.Drawing.Point(149, 154);
            this.ddlSubscriptionStatus.Name = "ddlSubscriptionStatus";
            this.ddlSubscriptionStatus.Size = new System.Drawing.Size(194, 21);
            this.ddlSubscriptionStatus.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 157);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Subscription Status:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 131);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Lic Token Expiration Date:";
            // 
            // tbSetting_te
            // 
            this.tbSetting_te.Location = new System.Drawing.Point(149, 128);
            this.tbSetting_te.Name = "tbSetting_te";
            this.tbSetting_te.Size = new System.Drawing.Size(274, 20);
            this.tbSetting_te.TabIndex = 31;
            this.tbSetting_te.Text = "2112-07-15T23:47:42Z";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Initial Purchase Date:";
            // 
            // tbSetting_sd
            // 
            this.tbSetting_sd.Location = new System.Drawing.Point(149, 102);
            this.tbSetting_sd.Name = "tbSetting_sd";
            this.tbSetting_sd.Size = new System.Drawing.Size(274, 20);
            this.tbSetting_sd.TabIndex = 29;
            this.tbSetting_sd.Text = "2012-02-01";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Lic Acquisition Date:";
            // 
            // tbSetting_ad
            // 
            this.tbSetting_ad.Location = new System.Drawing.Point(149, 76);
            this.tbSetting_ad.Name = "tbSetting_ad";
            this.tbSetting_ad.Size = new System.Drawing.Size(274, 20);
            this.tbSetting_ad.TabIndex = 27;
            this.tbSetting_ad.Text = "2012-06-19T21:48:56Z";
            // 
            // ddlAppSubType
            // 
            this.ddlAppSubType.FormattingEnabled = true;
            this.ddlAppSubType.Location = new System.Drawing.Point(149, 23);
            this.ddlAppSubType.Name = "ddlAppSubType";
            this.ddlAppSubType.Size = new System.Drawing.Size(194, 21);
            this.ddlAppSubType.TabIndex = 23;
            this.ddlAppSubType.MouseEnter += new System.EventHandler(this.ddlAppSubType_MouseHover);
            this.ddlAppSubType.MouseLeave += new System.EventHandler(this.ddlAppSubType_MouseLeave);
            this.ddlAppSubType.MouseHover += new System.EventHandler(this.ddlAppSubType_MouseHover_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Asset ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "App Sub Type:";
            // 
            // tbSetting_aid
            // 
            this.tbSetting_aid.Location = new System.Drawing.Point(149, 50);
            this.tbSetting_aid.Name = "tbSetting_aid";
            this.tbSetting_aid.Size = new System.Drawing.Size(274, 20);
            this.tbSetting_aid.TabIndex = 25;
            this.tbSetting_aid.Text = "WA103524926";
            this.tbSetting_aid.MouseEnter += new System.EventHandler(this.tbAssetId_MouseEnter);
            this.tbSetting_aid.MouseLeave += new System.EventHandler(this.tbAssetId_MouseLeave);
            this.tbSetting_aid.MouseHover += new System.EventHandler(this.tbAssetId_MouseHover);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "App Icon Url:";
            // 
            // tbAppIconUrl
            // 
            this.tbAppIconUrl.Location = new System.Drawing.Point(87, 121);
            this.tbAppIconUrl.Name = "tbAppIconUrl";
            this.tbAppIconUrl.Size = new System.Drawing.Size(274, 20);
            this.tbAppIconUrl.TabIndex = 21;
            this.tbAppIconUrl.Text = "http://www.global-infonet.com/img/sharepoint_icon.png";
            this.tbAppIconUrl.MouseEnter += new System.EventHandler(this.tbAppIconUrl_MouseEnter);
            this.tbAppIconUrl.MouseLeave += new System.EventHandler(this.tbAppIconUrl_MouseLeave);
            this.tbAppIconUrl.MouseHover += new System.EventHandler(this.tbAppIconUrl_MouseHover);
            // 
            // btnGenerateLicense
            // 
            this.btnGenerateLicense.Location = new System.Drawing.Point(690, 316);
            this.btnGenerateLicense.Name = "btnGenerateLicense";
            this.btnGenerateLicense.Size = new System.Drawing.Size(119, 23);
            this.btnGenerateLicense.TabIndex = 20;
            this.btnGenerateLicense.Text = "Import License";
            this.btnGenerateLicense.UseVisualStyleBackColor = true;
            this.btnGenerateLicense.Click += new System.EventHandler(this.btnGenerateLicense_Click);
            // 
            // lnkGenerateCustomerId
            // 
            this.lnkGenerateCustomerId.AutoSize = true;
            this.lnkGenerateCustomerId.Location = new System.Drawing.Point(291, 150);
            this.lnkGenerateCustomerId.Name = "lnkGenerateCustomerId";
            this.lnkGenerateCustomerId.Size = new System.Drawing.Size(51, 13);
            this.lnkGenerateCustomerId.TabIndex = 19;
            this.lnkGenerateCustomerId.TabStop = true;
            this.lnkGenerateCustomerId.Text = "Generate";
            this.lnkGenerateCustomerId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGenerateCustomerId_LinkClicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Customer ID:";
            // 
            // tbImportPurchaserId
            // 
            this.tbImportPurchaserId.Location = new System.Drawing.Point(87, 147);
            this.tbImportPurchaserId.Name = "tbImportPurchaserId";
            this.tbImportPurchaserId.Size = new System.Drawing.Size(198, 20);
            this.tbImportPurchaserId.TabIndex = 17;
            this.tbImportPurchaserId.Text = "739835AE59FDE73E";
            this.tbImportPurchaserId.MouseEnter += new System.EventHandler(this.tbImportPurchaserId_MouseHover);
            this.tbImportPurchaserId.MouseLeave += new System.EventHandler(this.tbImportPurchaserId_MouseLeave);
            this.tbImportPurchaserId.MouseHover += new System.EventHandler(this.tbImportPurchaserId_MouseHover_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Provider Name:";
            // 
            // tbImportProviderName
            // 
            this.tbImportProviderName.Location = new System.Drawing.Point(87, 95);
            this.tbImportProviderName.Name = "tbImportProviderName";
            this.tbImportProviderName.Size = new System.Drawing.Size(274, 20);
            this.tbImportProviderName.TabIndex = 15;
            this.tbImportProviderName.Text = "SPAppLicenseCreator";
            this.tbImportProviderName.MouseEnter += new System.EventHandler(this.tbImportProviderName_MouseEnter);
            this.tbImportProviderName.MouseLeave += new System.EventHandler(this.tbImportProviderName_MouseLeave);
            this.tbImportProviderName.MouseHover += new System.EventHandler(this.tbImportProviderName_MouseHover);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Product ID:";
            // 
            // tbImportProductId
            // 
            this.tbImportProductId.Location = new System.Drawing.Point(87, 69);
            this.tbImportProductId.Name = "tbImportProductId";
            this.tbImportProductId.Size = new System.Drawing.Size(274, 20);
            this.tbImportProductId.TabIndex = 13;
            this.tbImportProductId.Text = "{7c617a53-6f45-4d23-ada0-28eabb744acb}";
            this.tbImportProductId.MouseEnter += new System.EventHandler(this.tbImportProductId_MouseHover);
            this.tbImportProductId.MouseLeave += new System.EventHandler(this.tbImportProductId_MouseLeave);
            this.tbImportProductId.MouseHover += new System.EventHandler(this.tbImportProductId_MouseHover_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "App Title:";
            // 
            // tbImportAppTitle
            // 
            this.tbImportAppTitle.Location = new System.Drawing.Point(87, 43);
            this.tbImportAppTitle.Name = "tbImportAppTitle";
            this.tbImportAppTitle.Size = new System.Drawing.Size(274, 20);
            this.tbImportAppTitle.TabIndex = 11;
            this.tbImportAppTitle.Text = "Cheezburgers";
            this.tbImportAppTitle.MouseEnter += new System.EventHandler(this.tbImportAppTitle_MouseEnter);
            this.tbImportAppTitle.MouseLeave += new System.EventHandler(this.tbImportAppTitle_MouseLeave);
            this.tbImportAppTitle.MouseHover += new System.EventHandler(this.tbImportAppTitle_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Expiration:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "User Limit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "License Type:";
            // 
            // ddlImportExpiration
            // 
            this.ddlImportExpiration.FormattingEnabled = true;
            this.ddlImportExpiration.Location = new System.Drawing.Point(87, 227);
            this.ddlImportExpiration.Name = "ddlImportExpiration";
            this.ddlImportExpiration.Size = new System.Drawing.Size(121, 21);
            this.ddlImportExpiration.TabIndex = 7;
            this.ddlImportExpiration.SelectedIndexChanged += new System.EventHandler(this.ddlImportExpiration_SelectedIndexChanged);
            // 
            // ddlImportUserLimit
            // 
            this.ddlImportUserLimit.FormattingEnabled = true;
            this.ddlImportUserLimit.Location = new System.Drawing.Point(87, 200);
            this.ddlImportUserLimit.Name = "ddlImportUserLimit";
            this.ddlImportUserLimit.Size = new System.Drawing.Size(121, 21);
            this.ddlImportUserLimit.TabIndex = 6;
            // 
            // ddlImportLicenseType
            // 
            this.ddlImportLicenseType.FormattingEnabled = true;
            this.ddlImportLicenseType.Location = new System.Drawing.Point(87, 173);
            this.ddlImportLicenseType.Name = "ddlImportLicenseType";
            this.ddlImportLicenseType.Size = new System.Drawing.Size(121, 21);
            this.ddlImportLicenseType.TabIndex = 5;
            this.ddlImportLicenseType.SelectedIndexChanged += new System.EventHandler(this.ddlImportLicenseType_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(3, 68);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(0, 13);
            this.label39.TabIndex = 4;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 13);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(0, 13);
            this.label32.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tbStatus
            // 
            this.tbStatus.BackColor = System.Drawing.SystemColors.Info;
            this.tbStatus.Location = new System.Drawing.Point(12, 402);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStatus.Size = new System.Drawing.Size(859, 153);
            this.tbStatus.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(875, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // imageBandR
            // 
            this.imageBandR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageBandR.Image = ((System.Drawing.Image)(resources.GetObject("imageBandR.Image")));
            this.imageBandR.Location = new System.Drawing.Point(838, 49);
            this.imageBandR.Name = "imageBandR";
            this.imageBandR.Size = new System.Drawing.Size(33, 45);
            this.imageBandR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageBandR.TabIndex = 10;
            this.imageBandR.TabStop = false;
            this.imageBandR.Click += new System.EventHandler(this.imageBandR_Click);
            // 
            // imageBandRwait
            // 
            this.imageBandRwait.Image = ((System.Drawing.Image)(resources.GetObject("imageBandRwait.Image")));
            this.imageBandRwait.Location = new System.Drawing.Point(838, 49);
            this.imageBandRwait.Name = "imageBandRwait";
            this.imageBandRwait.Size = new System.Drawing.Size(33, 45);
            this.imageBandRwait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageBandRwait.TabIndex = 11;
            this.imageBandRwait.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 583);
            this.Controls.Add(this.imageBandRwait);
            this.Controls.Add(this.imageBandR);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SPAppLicenseCreator v1.1";
            this.tb1.ResumeLayout(false);
            this.tp1.ResumeLayout(false);
            this.tp1.PerformLayout();
            this.tp2.ResumeLayout(false);
            this.tp2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBandR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBandRwait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tb1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.TabPage tp1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbSiteUrl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox imageBandR;
        private System.Windows.Forms.PictureBox imageBandRwait;
        private System.Windows.Forms.TabPage tp2;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDomain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.CheckBox cbIsSPOnline;
        private System.Windows.Forms.LinkLabel lnkOpenLicenseManager;
        private System.Windows.Forms.ComboBox ddlImportLicenseType;
        private System.Windows.Forms.ComboBox ddlImportUserLimit;
        private System.Windows.Forms.ComboBox ddlImportExpiration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbImportProviderName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbImportProductId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbImportAppTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbImportPurchaserId;
        private System.Windows.Forms.LinkLabel lnkGenerateCustomerId;
        private System.Windows.Forms.Button btnGenerateLicense;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbAppIconUrl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ddlAppSubType;
        private System.Windows.Forms.TextBox tbSetting_aid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbSetting_te;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbSetting_sd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbSetting_ad;
        private System.Windows.Forms.ComboBox ddlSubscriptionStatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbBillingMarket;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbContentMarket;
        private System.Windows.Forms.Label label22;
    }
}

