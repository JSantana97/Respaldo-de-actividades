using EAAutoFramework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAAutoFramework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace EAAutoFramework.Base
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserType Browser;

        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(Browser);

            LogHelpers.Write("Initialize framework");
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                //default:
                    //DriverContext.Driver = new ChromeDriver();
                    //DriverContext.Browser = new Browser(DriverContext.Driver);
                    //break;
            }
        }

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Opened the browser !!!");
        }
    }
}
