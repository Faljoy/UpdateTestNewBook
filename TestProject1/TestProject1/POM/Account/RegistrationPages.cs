using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium.POM
{
    class RegistrationPages
    {
        private readonly IWebDriver _webDriver;

        private readonly By _buttonSignUp = By.CssSelector("[class='Navbar__signUp--12ZDV']");
        private readonly By _firstName = By.CssSelector("[name = 'first_name']");
        private readonly By _lastName = By.CssSelector("[name = 'last_name']");
        private readonly By _emailUser = By.CssSelector("[name='email']");
        private readonly By _paswordUser = By.CssSelector("[name='password']");
        private readonly By _confirmPaswordUser = By.CssSelector("[name='password_confirm']");
        private readonly By _phoneUser = By.CssSelector("[name='phone_number']");
        private readonly By _buttonNext = By.CssSelector("[type='submit']");
        private readonly By _companyName = By.CssSelector("[name='company_name']");
        private readonly By _companyWebSite = By.CssSelector("[name='company_website']");
        private readonly By _address = By.CssSelector("[name='location']");
        private readonly By _industry = By.CssSelector("[name='industry']");
        private readonly By _industryOther = By.CssSelector("[name='industry_other']");
        private readonly By _buttonFinish = By.CssSelector("[type='submit']");

        private readonly By _errorMessageByFirstName = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='first_name']/../div[@class = 'FormErrorText__error---nzyq']");
        private readonly By _errorMessageByLastName = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='last_name']/../div[@class = 'FormErrorText__error---nzyq']");
        private readonly By _errorMessageByEmail = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='email']/../div[@class = 'FormErrorText__error---nzyq']/div");
        private readonly By _errorMessageByPassword = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='password']/../div[@class = 'FormErrorText__error---nzyq']");
        private readonly By _errorMessageByConfirmPassword = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='password_confirm']/../div[@class = 'FormErrorText__error---nzyq']");
        private readonly By _errorMessageByPhone = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='phone_number']/../div[@class = 'FormErrorText__error---nzyq']");
        private readonly By _errorMessageByCompanyName = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='company_name']/../div[@class = 'FormErrorText__error---nzyq']");
        private readonly By _errorMessageByCompanyWebSite = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='company_website']/../div[@class = 'FormErrorText__error---nzyq']");
        private readonly By _errorMessageByAddress = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='location']/../div[@class = 'FormErrorText__error---nzyq']");
        private readonly By _errorMessageByIndustry = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='industry']/../../div[@class = 'FormErrorText__error---nzyq']");
        private readonly By _errorMessageByIndustryOther = By.XPath("//div[@class='SignupFormLayout__fieldRow--bGt25']//input[@name='industry_other']/../div[@class = 'FormErrorText__error---nzyq']");

        private readonly By _errorMessageByPasswordLenght = By.XPath(".//*[text()='From 8 to 25 characters']/..");
        private readonly By _errorMessageByPasswordNumbers = By.XPath(".//*[text()='At least one number']/..");
        private readonly By _errorMessageByPasswordUpperCaseLenght = By.XPath(".//*[text()='At least one capital letter']/..");
        private readonly By _errorMessageByPasswordLowCaseLetter = By.XPath(".//*[text()='At least one lowercase letter']/..");
        private readonly By _errorMessageByPasswordMarks = By.XPath(".//*[text()='At least one special character such as an exclamation mark']/..");
        private readonly By _errorMessageByPasswordPasswordMath = By.XPath(".//*[text()='Passwords match']/..");



        public RegistrationPages(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public RegistrationPages GoToRegistrationPages()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/");
            _webDriver.FindElement(_buttonSignUp).Click();
            return this;
        }

        public RegistrationPages InputFirstName(string firstName)
        {
            _webDriver.FindElement(_firstName).SendKeys(firstName);
            return this;
        }

        public RegistrationPages InputLastName(string lastName)
        {
            _webDriver.FindElement(_lastName).SendKeys(lastName);
            return this;
        }

        public RegistrationPages InputEmail(string mail)
        {
            _webDriver.FindElement(_emailUser).SendKeys(mail);
            return this;
        }

        public RegistrationPages InputPassword(string paswd)
        {
            _webDriver.FindElement(_paswordUser).SendKeys(paswd);
            return this;
        }

        public RegistrationPages InputConfirmPassword(string paswd)
        {
            _webDriver.FindElement(_confirmPaswordUser).SendKeys(paswd);
            return this;
        }

        public RegistrationPages InputPhoneNumber(string number)
        {
            _webDriver.FindElement(_phoneUser).SendKeys(number);
            return this;
        }

        public void ClickNextButton()
        {
            _webDriver.FindElement(_buttonNext).Click();
        }

        public RegistrationPages InputCompanyName(string number)
        {
            _webDriver.FindElement(_companyName).SendKeys(number);
            return this;
        }

        public RegistrationPages InputCompanyWebSite(string number)
        {
            _webDriver.FindElement(_companyWebSite).SendKeys(number);
            return this;
        }

        public RegistrationPages InputOtherIndustry(string number)
        {
            _webDriver.FindElement(_industryOther).SendKeys(number);
            return this;
        }

        public RegistrationPages InputCompanyAddress(string address)
        {
           _webDriver.FindElement(_address).SendKeys(address);
            Thread.Sleep(1500);
            _webDriver.FindElement(_address).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            _webDriver.FindElement(_address).SendKeys(Keys.Enter);
            return this;
        }

        public RegistrationPages InputCompanyIndustry(int i)
        {
            _webDriver.FindElement(_industry).Click();
                Thread.Sleep(1500);
            for (int counter = 0; counter < i; counter++)
            {
                _webDriver.FindElement(_industry).SendKeys(Keys.ArrowDown);
            }
            Thread.Sleep(500);
            _webDriver.FindElement(_industry).SendKeys(Keys.Enter);
            return this;
        }

        public void ClickOnFinishRegistration() => _webDriver.FindElement(_buttonFinish).Click();

        public string ErrorTextAboutFirstName() => _webDriver.FindElement(_errorMessageByFirstName).Text;

        public string ErrorTextAboutLastName() => _webDriver.FindElement(_errorMessageByLastName).Text;

        public string ErrorTextAboutEmail() => _webDriver.FindElement(_errorMessageByEmail).Text;

        public string ErrorTextAboutPassword() => _webDriver.FindElement(_errorMessageByPassword).Text;

        public string ErrorTextAboutPasswordLenght() => _webDriver.FindElement(_errorMessageByPasswordLenght).Text;

        public string ErrorTextAboutPasswordNumbers() => _webDriver.FindElement(_errorMessageByPasswordNumbers).Text;

        public string ErrorTextAboutPasswordUpperCase() => _webDriver.FindElement(_errorMessageByPasswordUpperCaseLenght).Text;

        public string ErrorTextAboutPasswordLowerCase() => _webDriver.FindElement(_errorMessageByPasswordLowCaseLetter).Text;

        public string ErrorTextAboutPasswordMatch() => _webDriver.FindElement(_errorMessageByPasswordPasswordMath).Text;

        public string ErrorTextAboutPasswordMarks() => _webDriver.FindElement(_errorMessageByPasswordMarks).Text;

        public string ErrorTextAboutConfitmPassword() => _webDriver.FindElement(_errorMessageByConfirmPassword).Text;

        public string ErrorTextAboutPhone() => _webDriver.FindElement(_errorMessageByPhone).Text;

        public string ErrorTextAboutCompanyName() => _webDriver.FindElement(_errorMessageByCompanyName).Text;

        public string ErrorTextAboutCompanyWebSite() => _webDriver.FindElement(_errorMessageByCompanyWebSite).Text;

        public string ErrorTextAboutAddress() => _webDriver.FindElement(_errorMessageByAddress).Text;

        public string ErrorTextAboutIndustry() => _webDriver.FindElement(_errorMessageByIndustry).Text;

        public string ErrorTextAboutOtherIndustry() => _webDriver.FindElement(_errorMessageByIndustryOther).Text;
    }
}
