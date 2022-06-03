using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AutomateMoviesAndTVWindowApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", "Microsoft.ZuneVideo_8wekyb3d8bbwe!Microsoft.ZuneVideo");

            WindowsDriver<WindowsElement> moviesAndTvSession =
                new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);


            Console.WriteLine($"Application title : {moviesAndTvSession.Title}");
            moviesAndTvSession.Manage().Window.Maximize();

            moviesAndTvSession.Quit();
        }
    }
}
