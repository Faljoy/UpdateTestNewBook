using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.POM
{
    class SignInPage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _emailField = By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']");
        private readonly By _passwordField = By.CssSelector("input[type=\"password\"]");
        private readonly By _buttonLogIn = By.CssSelector("button[class^='SignInForm__submitButton--cUdOV']");
        private readonly By _errorMessage = By.CssSelector("[class ='PageFormLayout__errors--3dFcq']>[class]");
        private readonly By _errorMessageByEmail = By.XPath("//input[@name = 'email']/../div[@class='FormErrorText__error---nzyq']");
        private readonly By _errorMessageByPass = By.XPath("//input[@name = 'password']/../div[@class='FormErrorText__error---nzyq']/div");

        public SignInPage(IWebDriver webDriver) 
        {
            _webDriver = webDriver;
        }

        public SignInPage GoToSignInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SignInPage InputMailField(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignInPage InputPasswordField(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public void ClickLogIn() =>
             _webDriver.FindElement(_buttonLogIn).Click();

        public string GetErrorMessage() =>
             _webDriver.FindElement(_errorMessage).Text;

        public string GetErrorMessageAboutMail() =>
     _webDriver.FindElement(_errorMessageByEmail).Text;

        public string GetErrorMessageAboutPassword() =>
     _webDriver.FindElement(_errorMessageByPass).Text;
    }
}
