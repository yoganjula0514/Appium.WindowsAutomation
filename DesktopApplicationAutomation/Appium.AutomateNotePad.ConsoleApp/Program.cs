using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using OpenQA.Selenium;

namespace Appium.AutomateNotePad.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", Path.Combine(currentDirectory, @"WPFApp.exe"));
            
            WindowsDriver<WindowsElement> wpfAppSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);

            SetImplicitWaitTime(wpfAppSession, 5);

            Console.WriteLine($"Application title : {wpfAppSession.Title}");
            wpfAppSession.Manage().Window.Maximize();
            
            EnterDescriptionContent(wpfAppSession);
            //ClickApplyButton(wpfAppSession);

            Thread.Sleep(3000);

            ClickApplyButton(wpfAppSession);
            GetScreenShot(wpfAppSession);

            wpfAppSession.Quit();
        }

        private static void EnterDescriptionContent(WindowsDriver<WindowsElement> wpfAppSession)
        {
            var descriptionTextBox = wpfAppSession.FindElementByAccessibilityId("txtDescription");
            descriptionTextBox.SendKeys(Keys.Escape);
            descriptionTextBox.SendKeys("This is dummy Description TextBox");
        }

        private static void ClickApplyButton(WindowsDriver<WindowsElement> wpfAppSession)
        {
            var applyButton = wpfAppSession.FindElementByName("Apply");
            applyButton.Click();
        }

        private static void GetScreenShot(WindowsDriver<WindowsElement> wpfAppSession)
        {
            var screenShot = wpfAppSession.GetScreenshot();
            screenShot.SaveAsFile(Path.Combine(Environment.CurrentDirectory, $"Screenshot_{DateTime.Now:ddMMyyyyhhmmss}.png"), OpenQA.Selenium.ScreenshotImageFormat.Png);
        }

        private static void SetImplicitWaitTime(WindowsDriver<WindowsElement> wpfAppSession, double seconds)
        {
            wpfAppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
    }
}
