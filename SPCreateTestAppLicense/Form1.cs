using BandR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using SP = Microsoft.SharePoint.Client;

using System.Security;

namespace SPAppLicenseCreator
{
    public partial class Form1 : Form
    {

        private AboutForm aboutForm = null;
        private BackgroundWorker bgw = null;





        public Hashtable htImportLicenseType = null;
        public Hashtable htImportUserLimit = null;
        public Hashtable htImportExpiration = null;
        public Hashtable htAppSubType = null;

        public Hashtable htSubscriptionStatus = null;
        



        public Form1()
        {
            InitializeComponent();

            toolStripStatusLabel1.Text = "";

            this.FormClosed += Form1_FormClosed;

            LoadSettingsFromRegistry();

            imageBandR.Visible = true;
            imageBandRwait.Visible = false;

            // load license types
            htImportLicenseType = new Hashtable();
            htImportLicenseType["Free"] = "Free";
            htImportLicenseType["Paid"] = "Paid";
            htImportLicenseType["Trial"] = "Trial";

            ddlImportLicenseType.Items.Add("Free");
            ddlImportLicenseType.Items.Add("Paid");
            ddlImportLicenseType.Items.Add("Trial");

            // load user limits
            htImportUserLimit = new Hashtable();
            htImportUserLimit["Unlimited"] = "0";
            htImportUserLimit["10"] = "10";
            htImportUserLimit["20"] = "20";

            ddlImportUserLimit.Items.Add("Unlimited");
            ddlImportUserLimit.Items.Add("10");
            ddlImportUserLimit.Items.Add("20");

            // load expiration
            htImportExpiration = new Hashtable();
            htImportExpiration["N/A"] = "0";
            htImportExpiration["30 days"] = "30";
            htImportExpiration["-1 (expired)"] = "-1";
            htImportExpiration["Unlimited"] = "9999";

            ddlImportExpiration.Items.Add("N/A");
            ddlImportExpiration.Items.Add("30 days");
            ddlImportExpiration.Items.Add("-1 (expired)");
            ddlImportExpiration.Items.Add("Unlimited");

            // load app sub types
            htAppSubType = new Hashtable();
            htAppSubType["OfficeAppSingleTaskPane"] = "1";
            htAppSubType["OfficeAppSingleContentPane"] = "2";
            htAppSubType["OfficeAppSingleDictionaryTaskPane"] = "4";
            htAppSubType["SharePointApp"] = "5";

            ddlAppSubType.Items.Add("OfficeAppSingleTaskPane");
            ddlAppSubType.Items.Add("OfficeAppSingleContentPane");
            ddlAppSubType.Items.Add("OfficeAppSingleDictionaryTaskPane");
            ddlAppSubType.Items.Add("SharePointApp");
            ddlAppSubType.SelectedIndex = 3;

            // load subscription status
            htSubscriptionStatus = new Hashtable();
            htSubscriptionStatus["N/A"] = "-1";
            htSubscriptionStatus["NotApplicable"] = "0";
            htSubscriptionStatus["Active"] = "1";
            htSubscriptionStatus["FailedPayment"] = "2";
            htSubscriptionStatus["Canceled"] = "3";
            htSubscriptionStatus["DelayedCancel"] = "4";

            ddlSubscriptionStatus.Items.Add("N/A");
            ddlSubscriptionStatus.Items.Add("NotApplicable");
            ddlSubscriptionStatus.Items.Add("Active");
            ddlSubscriptionStatus.Items.Add("FailedPayment");
            ddlSubscriptionStatus.Items.Add("Canceled");
            ddlSubscriptionStatus.Items.Add("DelayedCancel");
            ddlSubscriptionStatus.SelectedIndex = 0;
        }




        private void LoadSettingsFromRegistry()
        {
            var msg = "";
            var json = "";

            if (RegistryHelper.GetRegStuff(out json, out msg) && !json.IsNull())
            {
                var obj = JsonExtensionMethod.FromJson<CustomRegistrySettings>(json);

                tbSiteUrl.Text = obj.siteurl;
                tbUsername.Text = obj.username;
                tbPassword.Text = obj.password;
                tbDomain.Text = obj.domain;
                cbIsSPOnline.Checked = obj.issponline;
            }
        }

        private void SaveSettingsToRegistry()
        {
            var msg = "";

            var obj = new CustomRegistrySettings
            {
                siteurl = tbSiteUrl.Text.Trim(),
                username = tbUsername.Text.Trim(),
                password = tbPassword.Text.Trim(),
                domain = tbDomain.Text.Trim(),
                issponline = cbIsSPOnline.Checked
            };
            var json = JsonExtensionMethod.ToJson(obj);

            RegistryHelper.SaveRegStuff(json, out msg);
        }




        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (aboutForm != null)
            {
                aboutForm.Dispose();
            }

            SaveSettingsToRegistry();
        }




        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm = new AboutForm();
            aboutForm.Show();
            aboutForm.Focus();
        }




        private void DisableFormControls()
        {
            toolStripStatusLabel1.Text = "Running...";

            imageBandR.Visible = false;
            imageBandRwait.Visible = true;

            btnTestConnection.Enabled = false;
            btnGenerateLicense.Enabled = false;
            lnkGenerateCustomerId.Enabled = false;
            lnkOpenLicenseManager.Enabled = false;
        }

        private void EnableFormControls()
        {
            toolStripStatusLabel1.Text = "";

            imageBandR.Visible = true;
            imageBandRwait.Visible = false;

            btnTestConnection.Enabled = true;
            btnGenerateLicense.Enabled = true;
            lnkGenerateCustomerId.Enabled = true;
            lnkOpenLicenseManager.Enabled = true;
        }





        bool ValidateLoginCreds(string siteurl, string username, string password, string domain, bool isSPOnline)
        {
            if (siteurl.IsNull() || username.IsNull() || password.IsNull())
            {
                MessageBox.Show("Site URL, Username, and Password are required.", "Warning");
                return false;
            }
            else if (!isSPOnline && domain.IsNull())
            {
                MessageBox.Show("When not connecting to SPOnline, Domain is required.", "Warning");
                return false;
            }

            return true;
        }





        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            DisableFormControls();
            InitCoutBuffer();
            tbStatus.Text = "";

            var siteurl = tbSiteUrl.Text.Trim();
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();
            var domain = tbDomain.Text.Trim();
            var isSPOnline = cbIsSPOnline.Checked;

            if (!ValidateLoginCreds(siteurl, username, password, domain, isSPOnline))
            {
                return;
            }

            bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bgw_btnTestConnection);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_btnTestConnection_End);
            bgw.ProgressChanged += new ProgressChangedEventHandler(BgwReportProgress);
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();
        }

        private void bgw_btnTestConnection(object sender, EventArgs e)
        {
            var siteurl = tbSiteUrl.Text.Trim();
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();
            var domain = tbDomain.Text.Trim();
            var isSPOnline = cbIsSPOnline.Checked;

            try
            {

                using (var ctx = SPAppLicenseHelper.ClientContextFactory(siteurl, username, password, domain, isSPOnline))
                {
                    var web = ctx.Web;

                    ctx.Load(web, webSite => webSite.Title);

                    ctx.ExecuteQuery();

                    tcout(string.Format("'{0}' Site Loaded OK", web.Title));
                }

            }
            catch (Exception ex)
            {
                tcout("ERROR: " + ex.ToString());
            }
        }

        private void bgw_btnTestConnection_End(object sender, RunWorkerCompletedEventArgs e)
        {
            FlushCoutBuffer();
            EnableFormControls();
        }





        private void btnGenerateLicense_Click(object sender, EventArgs e)
        {
            tbStatus.Text = "";

            // validate input
            var siteurl = tbSiteUrl.Text.Trim();
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();
            var domain = tbDomain.Text.Trim();
            var isSPOnline = cbIsSPOnline.Checked;

            if (!ValidateLoginCreds(siteurl, username, password, domain, isSPOnline))
            {
                return;
            }

            if (ddlImportLicenseType.SelectedIndex < 0)
            {
                MessageBox.Show("Choose a license type.", "Warning");
                return;
            }
            if (ddlImportUserLimit.SelectedIndex < 0)
            {
                MessageBox.Show("Choose a user limit.", "Warning");
                return;
            }
            if (ddlImportExpiration.SelectedIndex < 0)
            {
                MessageBox.Show("Choose an expiration.", "Warning");
                return;
            }
            if (ddlAppSubType.SelectedIndex < 0)
            {
                MessageBox.Show("Choose an app sub type.", "Warning");
                return;
            }
            if (ddlSubscriptionStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Choose a subscription status.", "Warning");
                return;
            }
            if (tbImportAppTitle.Text.IsNull())
            {
                MessageBox.Show("App Title is required.", "Warning");
                return;
            }
            if (tbAppIconUrl.Text.IsNull())
            {
                MessageBox.Show("App Icon Url is required.", "Warning");
                return;
            }
            if (tbImportProductId.Text.IsNull())
            {
                MessageBox.Show("Product ID is required.", "Warning");
                return;
            }
            if (tbImportProviderName.Text.IsNull())
            {
                MessageBox.Show("Provider Name is required.", "Warning");
                return;
            }
            if (tbImportPurchaserId.Text.IsNull())
            {
                MessageBox.Show("Customer ID is required.", "Warning");
                return;
            }
            if (tbSetting_aid.Text.IsNull())
            {
                MessageBox.Show("Asset ID is required.", "Warning");
                return;
            }
            if (tbSetting_ad.Text.IsNull())
            {
                MessageBox.Show("Lic Acquisition Date is required.", "Warning");
                return;
            }
            if (tbSetting_sd.Text.IsNull())
            {
                MessageBox.Show("Initial Purchase Date is required.", "Warning");
                return;
            }
            if (tbSetting_te.Text.IsNull())
            {
                MessageBox.Show("Lic Token Expiration Date is required.", "Warning");
                return;
            }
            if (tbContentMarket.Text.IsNull())
            {
                MessageBox.Show("Content Market is required.", "Warning");
                return;
            }
            if (tbBillingMarket.Text.IsNull())
            {
                MessageBox.Show("Billing Market is required.", "Warning");
                return;
            }

            DisableFormControls();
            InitCoutBuffer();

            // save control data to args for thread
            var args = new List<object>();
            args.Add(ComboGetSelValue(ddlImportLicenseType, htImportLicenseType));
            args.Add(ComboGetSelValue(ddlImportUserLimit, htImportUserLimit));
            args.Add(ComboGetSelValue(ddlImportExpiration, htImportExpiration));
            args.Add(ComboGetSelValue(ddlAppSubType, htAppSubType));
            args.Add(ComboGetSelValue(ddlSubscriptionStatus, htSubscriptionStatus));

            bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bgw_btnGenerateLicense);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_btnGenerateLicense_End);
            bgw.ProgressChanged += new ProgressChangedEventHandler(BgwReportProgress);
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync(args);
        }

        private void bgw_btnGenerateLicense(object sender, DoWorkEventArgs e)
        {
            var args = e.Argument as List<object>;

            // get vals from UI
            var siteurl = tbSiteUrl.Text.Trim();
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();
            var domain = tbDomain.Text.Trim();
            var isSPOnline = cbIsSPOnline.Checked;

            var appTitle = tbImportAppTitle.Text.Trim();
            var productId = tbImportProductId.Text.Trim();
            var providerId = tbImportProviderName.Text.Trim();
            var appIconUrl = tbAppIconUrl.Text.Trim();
            var purchaserId = tbImportPurchaserId.Text.Trim();

            var licType = args[0].ToString();
            var userLimit = args[1].ToString();
            var expiration = Convert.ToInt32(args[2].ToString());

            var appSubType = Convert.ToInt32(args[3].ToString());
            var assetId = tbSetting_aid.Text.Trim();
            var licAcqDate = tbSetting_ad.Text.Trim();
            var initPurchaseDate = tbSetting_sd.Text.Trim();
            var tokenExpDate = tbSetting_te.Text.Trim();
            var subStatus = args[4].ToString();

            var contentMarket = tbContentMarket.Text.Trim();
            var billingMarket = tbBillingMarket.Text.Trim();

            try
            {
                SPAppLicenseType licenseType = SPAppLicenseHelper.GetLicenseTypeFromString(licType);

                string tokenXml = SPAppLicenseHelper.GenerateTestTokenXml(
                    licenseType,
                    productId,
                    userLimit,
                    expiration,
                    purchaserId,
                    assetId,
                    licAcqDate,
                    initPurchaseDate,
                    tokenExpDate,
                    subStatus);

                tcout("License Xml Generated", tokenXml);

                using (var ctx = SPAppLicenseHelper.ClientContextFactory(siteurl, username, password, domain, isSPOnline))
                {
                    SP.Utilities.Utility.ImportAppLicense(ctx,
                        tokenXml,
                        contentMarket,
                        billingMarket,
                        appTitle,
                        appIconUrl,
                        providerId,
                        appSubType);

                    ctx.ExecuteQuery();

                    tcout("Test License Created!");
                }

            }
            catch (Exception ex)
            {
                tcout("ERROR", ex.ToString());
            }
        }

        private void bgw_btnGenerateLicense_End(object sender, RunWorkerCompletedEventArgs e)
        {
            FlushCoutBuffer();
            EnableFormControls();
        }






        /// <summary>
        /// Combine function params as strings with separator, no line breaks.
        /// </summary>
        public string CombineFnParmsToString(params object[] objs)
        {
            string output = "";
            string delim = ": ";

            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] == null) objs[i] = "";
                if (i == objs.Length - 1) delim = "";
                output += string.Concat(objs[i], delim);
            }

            return output;
        }

        /// <summary>
        /// Build message for status window, prepend datetime, append message (already combined with separator), append newline chars.
        /// </summary>
        public string BuildCoutMessage(string msg)
        {
            return string.Format("{0}: {1}\r\n", DateTime.Now.ToLongTimeString(), msg);
        }

        /// <summary>
        /// Standard status dumping function, immediately dumps to status window.
        /// </summary>
        public void cout(params object[] objs)
        {
            tbStatus.AppendText(BuildCoutMessage(CombineFnParmsToString(objs)));
        }

        string tcout_buffer;
        int tcout_counter;

        /// <summary>
        /// Threaded status dumping function, uses buffer to only dump to status window peridocially, batch size configured in app.config.
        /// </summary>
        public void tcout(params object[] objs)
        {
            tcout_counter++;
            tcout_buffer += BuildCoutMessage(CombineFnParmsToString(objs));

            var batchSize = 1;

            if (tcout_counter % batchSize == 0)
            {
                bgw.ReportProgress(0, tcout_buffer);
                InitCoutBuffer();
            }
        }

        /// <summary>
        /// Reset status buffer.
        /// </summary>
        private void InitCoutBuffer()
        {
            tcout_counter = 0;
            tcout_buffer = "";
        }

        /// <summary>
        /// Flush status buffer to status window (since using mod operator).
        /// </summary>
        private void FlushCoutBuffer()
        {
            if (!tcout_buffer.IsNull())
            {
                tbStatus.AppendText(tcout_buffer);
                InitCoutBuffer();
            }
        }

        /// <summary>
        /// Threaded callback function, dump input to status window, already formatted with datetime, combined params, and linebreaks.
        /// </summary>
        private void BgwReportProgress(object sender, ProgressChangedEventArgs e)
        {
            tbStatus.AppendText(e.UserState.ToString());
        }





        private void lnkOpenLicenseManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = tbSiteUrl.Text.Trim().TrimEnd("/".ToCharArray()) + "/_layouts/15/AllAppLicensesManagement.aspx";
            cout("Opening ur: " + url);
            System.Diagnostics.Process.Start(url);
        }





        private void tbImportProductId_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Must match the ProductID contained in your AppManifest.xml.";
        }

        private void tbImportProductId_MouseHover_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Must match the ProductID contained in your AppManifest.xml.";
        }

        private void tbImportProductId_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }




        private void tbImportPurchaserId_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Simulates the identity of a purchaser; generate a new one if you want to import multiple license types for the same app (at the same time); otherwise the license will be overwritten.";
        }

        private void tbImportPurchaserId_MouseHover_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Simulates the identity of a purchaser; generate a new one if you want to import multiple license types for the same app (at the same time); otherwise the license will be overwritten.";
        }

        private void tbImportPurchaserId_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }






        private void ddlAppSubType_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "You probably want to use 'SharePointApp', but other options are available too.";
        }

        private void ddlAppSubType_MouseHover_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "You probably want to use 'SharePointApp', but other options are available too.";
        }

        private void ddlAppSubType_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }





        private void tbAssetId_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Asset ID for your app, default is Cheezburguers App already in App Store.";
        }

        private void tbAssetId_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Asset ID for your app, default is Cheezburguers App already in App Store.";
        }

        private void tbAssetId_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }







        private void tbImportAppTitle_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "The name of the app.";
        }

        private void tbImportAppTitle_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "The name of the app.";
        }

        private void tbImportAppTitle_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }






        private void tbImportProviderName_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Name of the provider of the App.";
        }

        private void tbImportProviderName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Name of the provider of the App.";
        }

        private void tbImportProviderName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }





        private void tbAppIconUrl_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "URL of the app icon, as it appears on Office Store. Can be any URL, is required even though MSDN says its optional.";
        }

        private void tbAppIconUrl_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "URL of the app icon, as it appears on Office Store. Can be any URL, is required even though MSDN says its optional.";
        }

        private void tbAppIconUrl_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }





        private void lnkGenerateCustomerId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random random = new Random();
            tbImportPurchaserId.Text = String.Format("{0}59FDE73E", random.Next().ToString("X"));
        }




        private void ddlImportLicenseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboGetSelValue(ddlImportLicenseType, htImportLicenseType).Equals("Free"))
            {
                ddlImportUserLimit.SelectedIndex = 0;
                ddlImportExpiration.SelectedIndex = 0;
                ddlImportExpiration.Enabled = false;
                ddlImportUserLimit.Enabled = false;
            }
            else if (ComboGetSelValue(ddlImportLicenseType, htImportLicenseType).Equals("Paid"))
            {
                ddlImportUserLimit.SelectedIndex = 0;
                ddlImportExpiration.SelectedIndex = 0;
                ddlImportExpiration.Enabled = false;
                ddlImportUserLimit.Enabled = true;
            }
            else if (ComboGetSelValue(ddlImportLicenseType, htImportLicenseType).Equals("Trial"))
            {
                ddlImportUserLimit.SelectedIndex = 0;
                ddlImportExpiration.SelectedIndex = 1;
                ddlImportExpiration.Enabled = true;
                ddlImportUserLimit.Enabled = true;
            }
        }

        private void ddlImportExpiration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboGetSelValue(ddlImportLicenseType, htImportLicenseType).Equals("Trial") 
                && ComboGetSelValue(ddlImportExpiration, htImportExpiration).Equals("0"))
            {
                // Non expiring trials aren't supported hence resetting this to 30
                ddlImportExpiration.SelectedIndex = 1;
            }
        }





        private string ComboGetSelValue(ComboBox cb, Hashtable ht)
        {
            if (cb.SelectedIndex < 0) return "";
            return ht[cb.Items[cb.SelectedIndex]].ToString();
        }




        private void imageBandR_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bandrsolutions.com/?utm_source=SPAppLicenseCreator&utm_medium=application&utm_campaign=SPAppLicenseCreator");
        }



    }
}
