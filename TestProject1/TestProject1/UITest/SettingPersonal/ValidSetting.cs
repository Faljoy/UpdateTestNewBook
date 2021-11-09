using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.POM;
using System;

namespace ValidSetting.UITest
{
    class ValidSetting
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
        public void CheckValidChangeName()
        {
            var accountSetting = new AccountSetting(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            var home = new HomePage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("d4cbf8f4a9@emailnax.com")
                .InputPasswordField("1234567890Qe_d")
                .ClickLogIn();
            accountSetting.GoToAccountSetting()
                .ChengeGeneral()
                .ChangeFirstName("rename")
                .SaveChange()
                .GoToMainPage();
            var homePage = new HomePage(_webDriver);
            string actualResult = homePage.CheckATryLogIn;
            Assert.AreEqual(expected: "Welcome back rename! How can we help?", actual: actualResult);
        }

    }
}
