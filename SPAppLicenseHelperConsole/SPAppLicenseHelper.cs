using Microsoft.SharePoint.Client;
using System;
using System.Xml;

namespace BandR
{
    /// <summary>
    /// Helper enum to categorize a license in Free, Paid, Trial or Uknown
    /// </summary>
    public enum SPAppLicenseType { Free, Paid, Trial, Uknown }

    /// <summary>
    /// Helper class to manipulate app licenses
    /// </summary>
    public class SPAppLicenseHelper
    {


        /// <summary>
        /// Returns a license tokenXml from SharePoint. It is NOT recommended to read the tokenXml without verifying it first with the Store.
        /// Use GetAndVerifyLicense instead.
        /// </summary>
        /// <param name="productId">The ProductId of your app, get this from your AppManifest.xml</param>
        /// <param name="ctx"> An already wired up SP ClientContext object</param>
        public static string GetLicenseTokenFromSharePoint(Guid productId, ClientContext clientContext)
        {
            //Get the license from SP
            ClientResult<AppLicenseCollection> licenseCollection = Microsoft.SharePoint.Client.Utilities.Utility.GetAppLicenseInformation(clientContext, productId);
            clientContext.Load(clientContext.Web);
            clientContext.ExecuteQuery();

            string rawLicenseToken = null;

            foreach (AppLicense license in licenseCollection.Value)
            {
                //just get the first license; you could also traverse all licenses if required but usually the top one is enough because it the most 'relevant'
                rawLicenseToken = license.RawXMLLicenseToken;
                break;
            }
            return (rawLicenseToken);
        }


        /// <summary>
        /// Translates a string (e.g. "free") into the corresponding enum type.
        /// </summary>
        /// <param name="licenseTypeString"></param>
        /// <returns></returns>
        public static SPAppLicenseType GetLicenseTypeFromString(String licenseTypeString)
        {

            switch (licenseTypeString.ToLower())
            {
                case "free":
                    return SPAppLicenseType.Free;
                case "paid":
                    return SPAppLicenseType.Paid;
                case "trial":
                    return SPAppLicenseType.Trial;
                default:
                    return SPAppLicenseType.Uknown;
            }
        }

        
        /// <summary>
        /// Utility method to add XML attributes to an XML document
        /// </summary>
        /// <param name="inputXml">XML document in string form</param>
        /// <param name="attributeName">Name of the attribute to add</param>
        /// <param name="attributeValue">Valud of the attribute</param>
        private static string AddAttributesToToken(String inputXml, String attributeName, String attributeValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(inputXml);

            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName("t");

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                try
                {
                    if (xmlNode.Attributes.GetNamedItem(attributeName).Value == null) { }
                }
                catch (Exception)
                {
                    XmlAttribute CountryAttr = xmlDoc.CreateAttribute(attributeName);
                    CountryAttr.Value = attributeValue;
                    xmlNode.Attributes.Append(CountryAttr);
                }
            }

            return xmlDoc.OuterXml;
        }


        /// <summary>
        /// Generates a TEST tokenXml. Note that the tokenXml returned will always contain a hardcoded AssetId that points to the Cheezburguers App (WA103524926)
        /// </summary>
        /// <param name="licenseType">The type of license to generate</param>
        /// <param name="productId">The productId of the app</param>
        /// <param name="userLimit">Number of users for the license; 0 for unlimited</param>
        /// <param name="expirationDays">Number of days the license will be valid for. -1 for unlimited</param>
        /// <param name="purchaserId">Id of the purchaser; random GUID</param>
        public static string GenerateTestTokenXml(SPAppLicenseType licenseType, String productId, String userLimit, int expirationDays, String purchaserId)
        {
            //Note that the AssetId matches that of the Cheezburgers app on the marketplace.
            //This is just for TEST purposes so that the storefront URL takes you to a valid app page
            string hardCodedBaseToken = "<r v=\"0\"><t aid=\"WA103524926\"  did=\"{3F47392A-2308-4FC6-BF24-740626612B26}\"  ad=\"2012-06-19T21:48:56Z\"  te=\"2112-07-15T23:47:42Z\" sd=\"2012-02-01\" test=\"true\"/><d>449JFz+my0wNoCm0/h+Ci9DsF/W0Q8rqEBqjpe44KkY=</d></r>";

            string tokenXml = hardCodedBaseToken;
            tokenXml = AddAttributesToToken(tokenXml, "pid", productId);
            tokenXml = AddAttributesToToken(tokenXml, "et", UppercaseFirst(licenseType.ToString()));
            tokenXml = AddAttributesToToken(tokenXml, "cid", purchaserId);

            //Set user limit
            if (licenseType == SPAppLicenseType.Free)
            {
                tokenXml = AddAttributesToToken(tokenXml, "ts", "0");
            }
            else
            {
                tokenXml = AddAttributesToToken(tokenXml, "ts", userLimit);
            }

            //Set site license == unlimited users
            if (userLimit.Equals("0"))
            {
                tokenXml = AddAttributesToToken(tokenXml, "sl", "true");
            }
            else
            {
                tokenXml = AddAttributesToToken(tokenXml, "sl", "false");
            }

            //Set expiration (only supported for Trials)
            if (licenseType == SPAppLicenseType.Trial)
            {
                DateTime expirationDate;
                if (expirationDays==-1)
                {
                    //expired tokenXml
                    expirationDate = DateTime.UtcNow.Subtract(TimeSpan.FromDays(10));
                }
                else if (expirationDays == 9999)
                {
                    //Unlimited trial
                    expirationDate = DateTime.MaxValue;
                }
                else
                {
                    //today + the selected number of days
                    expirationDate = DateTime.UtcNow.AddDays(expirationDays);
                }
                tokenXml = AddAttributesToToken(tokenXml, "ed", expirationDate.ToString("o"));

            }

            return tokenXml;
        }

        /// <summary>
        /// Imports a license tokenXml into SharePoint
        /// </summary>
        /// <param name="ctx">Already wired up ClientContext object</param>
        /// <param name="licenseToken">String representation of an XML license tokenXml</param>
        /// <param name="iconUrl">URL of the dummy icon to use; this will be displayed on licensing UI</param>
        /// <param name="appTitle">Title of the App</param>
        /// <param name="providerName">Author of the app</param>
        public static void ImportLicense(ClientContext ctx, string licenseToken, string iconUrl, string appTitle, string providerName, AppSubType appSubType)
        {
            Microsoft.SharePoint.Client.Utilities.Utility.ImportAppLicense(ctx,
                 licenseToken,
                 "en-US",
                 "US",
                 appTitle,
                 iconUrl,
                 providerName,
                 (int)appSubType);

            ctx.ExecuteQuery();
        }


        /// <summary>
        /// </summary>
        public enum AppSubType
        {
            OfficeAppSingleTaskPane = 1,
            OfficeAppSingleContentPane = 2,
            OfficeAppSingleDictionaryTaskPane = 4,
            SharePointApp = 5
            /*
             * 1   An app for SharePoint used to package a single task pane app for Office.
             * 2   An app for SharePoint used to package a single content app for Office.
             * 4   An app for SharePoint used to package a single dictionary task pane app for Office.
             * 5   An app for SharePoint that is not being used exclusively to package an app for Office. This includes:
             * */
        }


        /// <summary>
        /// Utility method to uppercase first letter of a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }


    }
}