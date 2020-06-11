using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAAutoFramework.Extensions;

namespace EAEmployeeTest.Pages
{
    class Messenger : BasePage
    {

        [FindsBy (How = How.XPath, Using = "//*[@placeholder='Buscar en Messenger']")]
        public IWebElement txtsearch { get; set; }


        [FindsBy (How = How.XPath, Using = "//*[@class='_2s25 _606w']")]
        public IWebElement profile { get; set; }

        public Profile ClickProfile()
        {
            DriverContext.Driver.WaitForPageLoaded();
            profile.Click();
            return new Profile();
        }
    }
}
