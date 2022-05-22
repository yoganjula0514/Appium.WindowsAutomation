using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumServiceBuilderTest.AutomationNotePad.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", @"C:\Windows\System32\notepad.exe");

            var localServiceBuilder = new AppiumServiceBuilder().UsingPort(5555).Build();
            localServiceBuilder.Start();

            WindowsDriver<WindowsElement> notePadSession = new WindowsDriver<WindowsElement>(localServiceBuilder, appiumOptions);
            notePadSession.Quit();
        }
    }
}
