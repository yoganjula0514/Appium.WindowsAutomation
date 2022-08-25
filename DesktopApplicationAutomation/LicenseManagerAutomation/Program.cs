using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace LicenseManagerAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", Path.Combine(@"D:\WS_LM\SWF-LicenseManager\x64\Debug\Bin", @"Philips.Swf.LicenseManager.UI.exe"));
            appiumOptions.AddAdditionalCapability("appArguments", "enableautomation");

            WindowsDriver<WindowsElement> licenseManagerSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);

            Thread.Sleep(2000);
            var applyButton = licenseManagerSession.FindElementByName("Browse");
            var descriptionTextBox = licenseManagerSession.FindElementByAccessibilityId("ButtonBrowseLicenseFile");
            descriptionTextBox.Click();
            Thread.Sleep(2000);

            var treeViewForFolders = licenseManagerSession.FindElementByAccessibilityId("treeViewForFolders");
            var dLocalDrive = treeViewForFolders.FindElementByName(@"D:\");
            PerformAction(licenseManagerSession, dLocalDrive);
            Thread.Sleep(2000);

            var localFolder = treeViewForFolders.FindElementByName(@"Local");
            PerformAction(licenseManagerSession, localFolder);
            Thread.Sleep(2000);

            var swfFolder = treeViewForFolders.FindElementByName(@"SWF");
            PerformAction(licenseManagerSession, swfFolder);
            Thread.Sleep(2000);

            var remoteServicesFolder = treeViewForFolders.FindElementByName(@"RemoteServices");
            PerformAction(licenseManagerSession, remoteServicesFolder);
            Thread.Sleep(2000);

            var licenseFolder = treeViewForFolders.FindElementByName(@"License");
            PerformAction(licenseManagerSession, licenseFolder);
            Thread.Sleep(2000);

            var sentinelFolder = treeViewForFolders.FindElementByName(@"Sentinel");
            PerformAction(licenseManagerSession, sentinelFolder);
            Thread.Sleep(2000);

            var sentinalRadioButton = licenseManagerSession.FindElementByAccessibilityId("Sentinel");
            if(sentinalRadioButton.Selected)
            {
                var legacyRadioButton = licenseManagerSession.FindElementByAccessibilityId("Legacy");
                legacyRadioButton.Click();
            }
            sentinalRadioButton.Click();
            Thread.Sleep(2000);

            var buttonLoad = licenseManagerSession.FindElementByAccessibilityId("buttonLoad");
            buttonLoad.Click();

            var featuresGridView = licenseManagerSession.FindElementByClassName("DataGrid");

            var allHeadersByClassName = featuresGridView.FindElementsByClassName("DataGridColumnHeader");
            var allHeadersBytagName = featuresGridView.FindElementsByTagName("HeaderItem");
            Console.WriteLine("*** Start printing Headers ***");
            foreach (var headers in allHeadersByClassName)
            {
                Console.WriteLine($"--> {headers.Text} - {headers.Displayed} - {headers.Enabled}");
            }
            Console.WriteLine("*** Stop printing Headers ***");


            var allCellsByClassName = featuresGridView.FindElementsByClassName("DataGridCell");
            Console.WriteLine("\n\n*** Start printing Cells ***");
            foreach (var cell in allCellsByClassName)
            {
                Console.WriteLine($"--> cell name : {cell.GetAttribute("Name")} - Text : {cell.Text}");
            }
            Console.WriteLine("*** Stop printing Cells ***");

            var allRowsByClassName = featuresGridView.FindElementsByClassName("DataGridRow");
            Console.WriteLine("\n\n*** Start printing Cells by individula row ***");
            int count = 1;
            foreach (var row in allRowsByClassName)
            {
                var cellsFromCurrentRow = row.FindElementsByClassName("DataGridCell");
                Console.WriteLine($"\tstart Row#{count}");
                foreach (var cell in cellsFromCurrentRow)
                {
                    Console.WriteLine($"\t\t--> cell name : {cell.GetAttribute("Name")} - Text : {cell.Text}");
                }
                Console.WriteLine($"\tstart Row#{count}");
                count++;
            }
            Console.WriteLine("*** Stop printing Cells by individula row ***");

            licenseManagerSession.Close();
            licenseManagerSession.Quit();
        }

        private static void PerformAction(WindowsDriver<WindowsElement> licenseManagerSession, AppiumWebElement appiumWebElement)
        {
            Actions actsTree = new Actions(licenseManagerSession);
            actsTree.MoveToElement(appiumWebElement);
            actsTree.DoubleClick();
            actsTree.Perform();
        }
    }
}
