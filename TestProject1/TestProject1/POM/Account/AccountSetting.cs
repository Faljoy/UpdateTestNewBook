using OpenQA.Selenium;
using System.Threading;

namespace Selenium.POM
{
    class AccountSetting
    {
        private readonly IWebDriver _webDriver;

        private readonly By _goToAccount = By.CssSelector("[class='MainHeader__staticItemAvatar--3LwWp MainHeader__staticItem--2UY1x ']");

        private readonly By _changeGeneral = By.CssSelector("[class='ng-untouched ng-pristine ng-valid'] [class='edit-switcher__icon_type_edit']");
        private readonly By _changeGeneralWhenChange = By.CssSelector("[class='ng-valid ng-touched ng-pristine'] [class='edit-switcher__icon_type_edit']");

        private readonly By _changeEmail = By.CssSelector("nb-account-info-email-address [class='edit-switcher__icon_type_edit']");
        private readonly By _changePassword = By.CssSelector("nb-account-info-password [class='edit-switcher__icon_type_edit']");
        private readonly By _changePhone = By.CssSelector("nb-account-info-phone [class='edit-switcher__icon_type_edit']");

        private readonly By _changeFirstName = By.CssSelector("input[placeholder='Enter First Name']");
        private readonly By _changeLastName = By.CssSelector("input[placeholder='Enter Last Name']");
        private readonly By _changeLocation = By.CssSelector("input[placeholder='Enter Company Location']");
        private readonly By _changeIndustry = By.CssSelector("input[placeholder='Enter Industry']");
        private readonly By _saveGeneral = By.XPath("//common-input[@formcontrolname='first_name']/..//button");

        private readonly By _mainPage = By.CssSelector("[class='HeaderLine__logo--104lH ']");


        public AccountSetting(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AccountSetting GoToAccountSetting()
        {
            _webDriver.FindElement(_goToAccount).Click();
            return this;
        }

        public AccountSetting ChengeGeneral()
        {
            _webDriver.FindElement(_changeGeneral).Click();
            return this;
        }

        public AccountSetting ChangeFirstName(string firstName)
        {
            _webDriver.FindElement(_changeFirstName).Clear();
            _webDriver.FindElement(_changeFirstName).SendKeys(firstName);
            return this;       
        }

        public void GoToMainPage()
        {
            _webDriver.FindElement(_mainPage).Click();
        }

        public AccountSetting ChangeLastName(string lastName)
        {
            _webDriver.FindElement(_changeLastName).SendKeys(lastName);
            return this;
        }

        public AccountSetting ChangeIndustry(string industry)
        {
            _webDriver.FindElement(_changeIndustry).SendKeys(industry);
            return this;
        }

        public AccountSetting InputCompanyAddress(string address)
        {
            _webDriver.FindElement(_changeLocation).SendKeys(address);
            Thread.Sleep(1500);
            _webDriver.FindElement(_changeLocation).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            _webDriver.FindElement(_changeLocation).SendKeys(Keys.Enter);
            return this;
        }

        public AccountSetting ChangeEmail()
        {
            _webDriver.FindElement(_changeEmail).Click();
            return this;
        }

        public AccountSetting ChangePassword()
        {
            _webDriver.FindElement(_changePassword).Click();
            return this;
        }

        public AccountSetting ChangePhone()
        {
            _webDriver.FindElement(_changePassword).Click();
            return this;
        }

        public AccountSetting SaveChange()
        {
            _webDriver.FindElement(_saveGeneral).Click();
            return this;
        }
    }
}
