using System;
using EAAutoFramework.Base;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using EAAutoFramework.Config;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            string fileName = @"C:\Users\Titanium\Documents\UdemyCJ\EATestProject\EAEmployeeTest\Data\Login.xlsx";

            ExcelHelpers.PopulateInCollection(fileName);           

            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "email"), ExcelHelpers.ReadData(1, "pass"));
            CurrentPage = CurrentPage.As<LoginPage>().ClickMessenger();
            CurrentPage.As<LoginPage>().CheckInfMessengerExist();
            CurrentPage.As<Messenger>().ClickProfile();

        }
    }
}
