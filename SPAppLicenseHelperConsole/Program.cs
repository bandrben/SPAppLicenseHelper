using BandR;
using Microsoft.SharePoint.Client;
using System;
using System.IO;
using System.Security;

namespace SPAppLicenseHelperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CreateLogOutputFile();

                cout("Started...");
                cout();

                cout("OOB Url to Manage Licenses: " + "https://bandr.sharepoint.com/sites/BSteinhauser/_layouts/15/AllAppLicensesManagement.aspx");
                cout();

                //TestSPOnlineAuth();
                CreateTestLicense();
                //GetProductLicenses();

            }
            catch (Exception exc)
            {
                cout("ERROR", exc.ToString());
            }

            cout();
            cout("Done. Press any key.");
            Console.ReadLine();

            if (_file != null)
            {
                _file.Dispose();
            }
        }

        /// <summary>
        /// </summary>
        private static void GetProductLicenses()
        {
            var targetSite = new Uri("https://bandr.sharepoint.com/sites/BSteinhauser");
            var login = "bsteinhauser@bandrsolutions.com";
            var password = "garden123#";

            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);

            // set productid
            var importProductId = "{2db683a9-1731-449e-8f20-6bf479660acc}";

            using (ClientContext ctx = new ClientContext(targetSite))
            {
                ctx.Credentials = onlineCredentials;

                cout("token from SP", SPAppLicenseHelper.GetLicenseTokenFromSharePoint(new Guid(importProductId), ctx));
            }

            /*
             * NOTES:
             * this did not work for me, access denied errors
             * */
        }

        /// <summary>
        /// </summary>
        private static void CreateTestLicense()
        {
            /*
             * NOTES:
             * SUCCESS! it worked, can create license
             * still need to test the license in client code
             * */

            var targetSite = new Uri("https://bandr.sharepoint.com/sites/BSteinhauser");
            var login = "bsteinhauser@bandrsolutions.com";
            var password = "garden123#";

            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);

            // set license type
            var importLicenseType = "Paid";
            /*
             * valid values: Free, Paid, Trial
             * */
            SPAppLicenseType licenseType = SPAppLicenseHelper.GetLicenseTypeFromString(importLicenseType);

            // set productid
            var importProductId = "{2db683a9-1731-449e-8f20-6bf479660acc}";

            // set userlimit
            var importUserLimit = "0";
            /*
             * valid values:
             *  <asp:ListItem Value="0">Unlimited</asp:ListItem>
             *  <asp:ListItem>10</asp:ListItem>
             *  <asp:ListItem>20</asp:ListItem>
             * */

            // set expiration
            var importExpiration = "0";
            /*
             * valid values:
             * 	<asp:ListItem Value="0">NA</asp:ListItem>
             * 	<asp:ListItem Value="30">30 days</asp:ListItem>
             * 	<asp:ListItem Value="-1">-1 (expired)</asp:ListItem>
             * 	<asp:ListItem Value="9999">Unlimited</asp:ListItem>
             * */

            // create importPurchaserId
            //Random random = new Random();
            //var importPurchaserId = String.Format("{0}59FDE73E", random.Next().ToString("X"));
            // Simulates the identity of a purchaser; generate a new one if you want to import multiple license types for the same app (at the same time); otherwise the license will be overwritten.
            var importPurchaserId = "739835AE59FDE73E"; // works!

            string tokenXml = SPAppLicenseHelper.GenerateTestTokenXml(licenseType, importProductId, importUserLimit, int.Parse(importExpiration), importPurchaserId);

            cout("token", tokenXml);

            var importAppTitle = "BanderaApps Goal Thermometer";
            var appIconUrl = "http://www.global-infonet.com/img/sharepoint_icon.png"; // generic sharepoint icon
            //var importProviderName = "Microsoft SDK Demo";
            var importProviderName = "BanderaApps License Demo"; // works!

            using (ClientContext ctx = new ClientContext(targetSite))
            {
                ctx.Credentials = onlineCredentials;

                SPAppLicenseHelper.ImportLicense(ctx, tokenXml, appIconUrl, importAppTitle, importProviderName, SPAppLicenseHelper.AppSubType.SharePointApp);
            }

            cout("License Imported Succesfully!", DateTime.Now.ToString());
        }

        /// <summary>
        /// </summary>
        private static void TestSPOnlineAuth()
        {
            var targetSite = new Uri("https://bandr.sharepoint.com/sites/BSteinhauser");
            var login = "bsteinhauser@bandrsolutions.com";
            var password = "garden123#";

            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);

            using (ClientContext ctx = new ClientContext(targetSite))
            {
                ctx.Credentials = onlineCredentials;

                Web web = ctx.Web;

                ctx.Load(web, webSite => webSite.Title);

                ctx.ExecuteQuery();

                cout(web.Title);
            }
        }

        #region "Ouput"

        /// <summary>
        /// </summary>
        static void cout(params object[] objs)
        {
            string output = "";

            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] == null) objs[i] = "";

                string delim = " : ";

                if (i == objs.Length - 1) delim = "";

                output += string.Format("{0}{1}", objs[i], delim);
            }
            output += Environment.NewLine;

            Console.Write(output);

            coutFile(objs);
        }

        /// <summary>
        /// </summary>
        static void coutFile(params object[] objs)
        {
            string output = "";

            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] == null) objs[i] = "";

                string delim = "";

                if (!outToCsv)
                {
                    delim = " : ";
                }
                else
                {
                    objs[i] = NormalizeForCsv(objs[i].ToString());
                    delim = ",";
                }

                if (i == objs.Length - 1) delim = "";

                output += string.Format("{0}{1}", objs[i], delim);
            }
            output += Environment.NewLine;

            _file.Write(output);
        }

        /// <summary>
        /// </summary>
        static string NormalizeForCsv(string s)
        {
            s = System.Text.RegularExpressions.Regex.Replace(s, @"\r\n|\n\r|\n|\r", "\r\n");

            if (s.Contains(",") || s.Contains("\r\n"))
            {
                s = string.Concat("\"", s, "\"");
            }

            return s;
        }

        /// <summary>
        /// </summary>
        private static void CreateLogOutputFile()
        {
            _file = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory.TrimEnd(new char[] { '\\' }) + "\\output.txt");
        }

        private static StreamWriter _file;
        private static DateTime _curDateTime = DateTime.Now;
        private const bool outToCsv = false;

        #endregion

    }
}
