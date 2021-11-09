using OpenQA.Selenium;

namespace Selenium.POM
{
    class HomePage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _welconeInAccount = By.CssSelector("[class='WelcomePage__welcomeBackSection--1fVmu'] [class='Section__title--1wSQt']");

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string CheckATryLogIn =>
            _webDriver.FindElement(_welconeInAccount).Text;

    }
}
