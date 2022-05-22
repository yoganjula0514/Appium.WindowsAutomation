using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace Appium.AutomateNotePad.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", @"C:\Windows\System32\notepad.exe");
            WindowsDriver<WindowsElement> notePadSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);

            if(notePadSession == null)
            {
                Console.WriteLine("Application Notepad not started.... Try Again!");
            }

            notePadSession.Quit();
        }
    }
}
