using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.POM;
using System;
using System.Threading;

namespace LogIn.UITest
{
    public class Tests
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

        [TestCase("WrongEmail@sdsdsemailnax.com", "wrongPasswd123")]
        [TestCase("596af73a33@emailnax.com", "wrongPasswd123")]
        [TestCase("WrongEmail@sdsdsemailnax.com", "1234567890Qe_d")]
        public void LoginWithInvalidLogginAndPass(string mail, string password)
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField(mail)
                .InputPasswordField(password)
                .ClickLogIn();
            var actualResultMessage = signInPage.GetErrorMessage();
            Assert.AreEqual(expected:"Please enter a correct email and password.", actualResultMessage);
        }

        [Test]
        public void LoginWithEmptyEmail()
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("")
                .InputPasswordField("1234567890Qe_d")
                .ClickLogIn();
            var actualResultMessage = signInPage.GetErrorMessageAboutMail();
            Assert.AreEqual(expected:"Required", actualResultMessage);
        }

        [TestCase("596af73a33@emailnax.com", "")]
        public void LoginWithEmptyPassword(string mail, string password)
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField(mail)
                .InputPasswordField(password)
                .ClickLogIn();
            var actualResultMessage = signInPage.GetErrorMessageAboutPassword();
            Assert.AreEqual(expected: "Required", actualResultMessage);
        }

        [TestCase("", "")]
        public void LoginWithEmptyPasswordAndEmail(string mail, string password)
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField(mail)
                .InputPasswordField(password)
                .ClickLogIn();
            var actualResultMessage = signInPage.GetErrorMessageAboutPassword() + signInPage.GetErrorMessageAboutMail();
            Assert.AreEqual(expected: "RequiredRequired", actualResultMessage);
        }

        [Test]
        public void LoginWithValidLogginAndPass()
        {
            var signInPage = new SignInPage(_webDriver);
            var home = new HomePage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("596af73a33@emailnax.com")
                .InputPasswordField("1234567890Qe_d")
                .ClickLogIn();
            var actualResultMessage = home.CheckATryLogIn;
            Assert.AreEqual(expected: "Welcome back Di66! How can we help?", actualResultMessage);
        }
    }
}