using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.POM;
using System;
using System.Threading;

namespace LogOut.UITest
{
    public class TestsLogout
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Dispose();
        }

        [Test]
        public void CheckTryLogOut()
        {
            var signInPage = new SignInPage(_webDriver);
            var home = new HomePage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("596af73a33@emailnax.com")
                .InputPasswordField("1234567890Qe_d")
                .ClickLogIn();
            var accountSetting = new AccountSetting(_webDriver);
            accountSetting.GoToAccountSetting()
                .ButtonLogOut();
            var actualResultMessage = signInPage.SignInPageCheck();
            Assert.AreEqual(expected: "Client Sign In", actualResultMessage);
        }
    }
}
