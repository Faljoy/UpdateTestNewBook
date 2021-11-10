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
        public void CheckValidChangeFirstName()
        {
            var accountSetting = new AccountSetting(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("d4cbf8f4a9@emailnax.com")
                .InputPasswordField("1234567890Qe_d")
                .ClickLogIn();
            accountSetting.GoToAccountSetting()
                .ChengeGeneral()
                .ChangeFirstName("rename")
                .SaveChange();
            string actualResult = accountSetting.CheckName();
            accountSetting.GoToMainPage();
            accountSetting.GoToAccountSetting()
                .ChengeGeneral()
                .ChangeFirstName("Di")
                .SaveChange();
            Assert.AreEqual(expected: "rename Di", actual: actualResult);
        }

        [Test]
        public void CheckValidChangeLastName()
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
                .ChangeLastName("rename")
                .SaveChange();
            string actualResult = accountSetting.CheckName();
            accountSetting.GoToMainPage();
            accountSetting.GoToAccountSetting()
               .ChengeGeneral()
               .ChangeLastName("Di")
               .SaveChange();
            Assert.AreEqual(expected: "Di rename", actual: actualResult);
        }

        [Test]
        public void CheckValidChangeAddress()
        {
            var accountSetting = new AccountSetting(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("d4cbf8f4a9@emailnax.com")
                .InputPasswordField("1234567890Qe_d")
                .ClickLogIn();
            accountSetting.GoToAccountSetting()
                .ChengeGeneral()
                .ChangeCompanyAddress("Ewell Hall, 221 Jamestown Rd, Williamsburg, VA 23185, США")
                .SaveChange();
            string actualResult = accountSetting.CheckLocation();
            accountSetting.GoToMainPage();
            accountSetting.GoToAccountSetting()
               .ChengeGeneral()
               .ChangeCompanyAddress("Queens, NY, USA")
               .SaveChange();
            Assert.AreEqual(expected: "Ewell Hall, 221 Jamestown Rd, Williamsburg, VA 23185, США", actual: actualResult);
        }

        [Test]
        public void CheckValidChangeIndustry()
        {
            var accountSetting = new AccountSetting(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("d4cbf8f4a9@emailnax.com")
                .InputPasswordField("1234567890Qe_d")
                .ClickLogIn();
            accountSetting.GoToAccountSetting()
                .ChengeGeneral()
                .ChangeIndustry("new Industry")
                .SaveChange();
            string actualResult = accountSetting.CheckIndustry();
            accountSetting.GoToMainPage();
            accountSetting.GoToAccountSetting()
               .ChengeGeneral()
               .ChangeIndustry("entertainment")
               .SaveChange();
            Assert.AreEqual(expected: "new Industry", actual: actualResult);
        }

        [Test]
        public void CheckValidChangePassword()
        {
            var accountSetting = new AccountSetting(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            var home = new HomePage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("d4cbf8f4a9@emailnax.com")
                .InputPasswordField("1234567890Qe_d")
                .ClickLogIn();
            accountSetting.GoToAccountSetting()
                .ChangePassword()
                .InputCurrentPaswd("1234567890Qe_d")
                .InputNewPaswd("1234567890Qe_q")
                .InputNewPaswdConfirm("1234567890Qe_q")
                .SaveChangePassword()
                .ButtonLogOut();
            signInPage.GoToSignInPage()
                .InputMailField("d4cbf8f4a9@emailnax.com")
                .InputPasswordField("1234567890Qe_q")
                .ClickLogIn();
            var actualResultMessage = home.CheckATryLogIn;
            accountSetting.GoToAccountSetting()
                .ChangePassword()
                .InputCurrentPaswd("1234567890Qe_q")
                .InputNewPaswd("1234567890Qe_d")
                .InputNewPaswdConfirm("1234567890Qe_d")
                .SaveChangePassword();
            Assert.AreEqual(expected: "Welcome back Di! How can we help?", actual: actualResultMessage);
        }

        [Test]
        public void CheckValidAddACard()
        {
            var accountSetting = new AccountSetting(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("d4cbf8f4a9@emailnax.com")
                .InputPasswordField("1234567890Qe_d")
                .ClickLogIn();
            accountSetting.GoToAccountSetting()
                .AddACardName()
                .GoToSettingCard()
                .AddACardNumber()
                .AddACardDate()
                .AddACardCVV()
                .GoToSettingAnother()
                .SaveChangeACard();
            string actualResult = accountSetting.CheckAddACard();
            Assert.AreEqual(expected: "Current card", actual: actualResult);
        }
    }
}