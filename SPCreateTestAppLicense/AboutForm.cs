using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPAppLicenseCreator
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            tbAbout.Text = @" *** Welcome to SPAppLicenseCreator ***

v1.1

Created by Ben Steinhauser of B&R Business Solutions.

Product URL: https://spapplicensecreator.codeplex.com
Company URL: http://www.bandrsolutions.com

Description:
------------

Create test licenses for SharePoint and Office Apps. Compatible with SharePoint 2013 and Office 365 SharePoint Online.

SharePoint App Licensing in a nutshell consists of three main steps:
1. Import a test license
2. Add code to your app that retrieves and validates the license
3. Make decisions based on the outcome.

This project's goal is make step 1 ""Import a test license"" painless and easy. The other 2 steps have many code samples available on the web and best practices available from Office Dev Center and blogs.

Features:
---------

-WinForms desktop application using .NET 4.5.1
-Uses SharePoint Client Object Model
-Compatible with SharePoint 2013, Office365 SharePoint Online
-Works with Windows Auth sites and Claims Based sites
-Default settings are configured for creating SharePoint Test Licenses, but settings can be changed to try to create licenses for Office Apps and subscription based apps.
-Advanced settings to import Licenses with different App Sub Types, acquisition date, purchase date, token expiration date, subscription status, content and billing market languages.
-Remembers last login information using registry.

Definitions:
------------

For more information on definitions visit
https://msdn.microsoft.com/en-us/library/office/jj163880.aspx
https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.utilities.utility.importapplicense.aspx

APP TITLE: The name of the app.
PRODUCT ID: The GUID that represents the product ID of the app. The product ID of the app is specified in the app manifest.
PROVIDERNAME: Name of the provider of the app.
APICONURL: URL of the app icon, as it appears on Office Store. Can be left blank.
CUSTOMER ID: Represents the purchaser ID. This is an encrypted value of the Microsoft account used by the purchaser of the app.
LICENSE TYPE: Enumeration that represents the type of app license. Valid values include Free, Paid, and Trial.
USER LIMIT: Integer representing the total number of users licensed to access this app, by this purchaser, for apps that are site licensed, this value is 0, this attribute does not apply to apps for Office.
EXPIRATION: used to create the expiration date, UTC time-date stamp that represents the expiration date for the app license.
APPSUBTYPE: The subtype of the app. Use this parameter to specify whether this license is for an app for SharePoint used exclusively to package an app for Office, and if so, the type of app for Office. This enables corporate catalogs to filter and display apps for Office packaged in apps for SharePoint.
ASSETID: The asset ID assigned to this app by the Office Store.
LICENSE ACQUISITION DATE: UTC time-date stamp that represents the acquisition date for the app license.
INITIAL PURCHASE DATE: UTC time-date stamp that represents one of the following: the initial purchase of the license; the latest manual license recovery time, if the purchaser has performed such a recovery using their Microsoft account.
LICENSE TOKEN EXPIRATION DATE: UTC time-date stamp that represents the date the current app license token expires.
SUBSCRIPTION STATUS: Represents the subscription status of the app license. This attribute is optional for apps that are not being sold as subscriptions.
CONTENTMARKET: The content market in which you want to sell the app.
BILLINGMARKET: The billing market for the app.
IS TEST LICENSE: Indicates if creating/importing a test license.

";

            tbAbout.AppendText(" ");

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bandrsolutions.com/?utm_source=SPAppLicenseCreator&utm_medium=application&utm_campaign=SPAppLicenseCreator");
        }

    }
}
