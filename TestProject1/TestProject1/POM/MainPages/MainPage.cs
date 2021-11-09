using OpenQA.Selenium;

namespace Selenium.POM
{
    class MainPage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _emailField = By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']");
        private readonly By _passwordField = By.CssSelector("input[type=\"password\"]");
        private readonly By _buttonLogIn = By.CssSelector("button[class^='SignInForm__submitButton--cUdOV']");
        private readonly By _welcomeInAccount = By.CssSelector("[class='WelcomePage__welcomeBackSection--1fVmu'] [class='Section__title--1wSQt']");

        public MainPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string CheckATryLogIn =>
            _webDriver.FindElement(_welcomeInAccount).Text;
    }
}
