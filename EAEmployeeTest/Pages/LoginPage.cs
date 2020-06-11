using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using EAAutoFramework.Extensions;
using System;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {

        //Objects for the login page
        [FindsBy(How = How.LinkText, Using = "Iniciar sesión")]
        IWebElement lnkLogin { get; set; }

        [FindsBy (How = How.XPath, Using = "(//*[@class='_5afe'])[3]")]
        IWebElement lnkMessenger { get; set; } 

        [FindsBy(How = How.Id, Using = "email")]
        IWebElement txtemail { get; set; }

        [FindsBy(How = How.Id, Using = "pass")]
        IWebElement txtpassword { get; set; }

        [FindsBy(How = How.Id, Using = "loginbutton")]
        IWebElement loginbutton { get; set; }

        public void Login (string email, string pass)
        {
            txtemail.SendKeys(email);
            txtpassword.SendKeys(pass);
            loginbutton.Submit();
        }

        //public void ClickLoginLink()
        //{
        //    lnkLogin.Click();
        //}

        public Messenger ClickMessenger()
        {
            DriverContext.Driver.WaitForPageLoaded();
            lnkMessenger.Click();
            return GetInstance<Messenger>();
        }

        internal void CheckInfMessengerExist()
        {
            txtemail.AssertElementPresent();
        }

    }
}
