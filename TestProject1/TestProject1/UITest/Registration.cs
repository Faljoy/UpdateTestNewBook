using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.POM;
using System;

namespace Registration.UITest
{
    class Registration
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
        public void RegistrationWitfValidData()
        {
            string name = "Di";
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(name)
                .InputLastName("Di")
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword("1234567890Qe_d")
                .InputConfirmPassword("1234567890Qe_d")
                .InputPhoneNumber("1234123123")
                .ClickNextButton();

            registrationPage.InputCompanyName("MyComp")
                .InputCompanyWebSite("MuComp.com")
                .InputCompanyAddress("3435 Wilshire Boulevard, Los Angeles, CA, USA")
                .InputCompanyIndustry(5)//1-6 a count of industry. 6 - other, added a new field
                .ClickOnFinishRegistration();

            Assert.AreEqual(expected: $"Welcome {name}! How can we help?", home.CheckATryLogIn);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Qe_d", "1234123123")]
        public void RegistrationWithInValidEmail(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail("name")
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutEmail();

            Assert.AreEqual(expected: "Invalid Email", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890qe_d", "1234567890qe_d", "1234123123")]
        public void RegistrationWithInValidPasswordUppercase(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutPassword() + " " + registrationPage.ErrorTextAboutPasswordUpperCase();

            Assert.AreEqual(expected: "Invalid password format At least one capital letter", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890QE_D", "1234567890QE_D", "1234123123")]
        public void RegistrationWithInValidPasswordLowercase(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutPassword() + " " + registrationPage.ErrorTextAboutPasswordLowerCase();

            Assert.AreEqual(expected: "Invalid password format At least one lowercase letter", actualResultat);
        }

        [TestCase("Di", "Di", "Qe_d", "Qe_d", "1234123123")]
        [TestCase("Di", "Di", "123456783242323232323232323232390Qe_d", "123456783242323232323232323232390Qe_d", "1234123123")]
        public void RegistrationWithInValidPasswordLenght(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutPassword() + " " + registrationPage.ErrorTextAboutPasswordLenght();

            Assert.AreEqual(expected: "Invalid password format From 8 to 25 characters", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qed", "1234567890Qed", "1234123123")]
        public void RegistrationWithInValidPasswordSymbol(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutPassword() + " " + registrationPage.ErrorTextAboutPasswordMarks();

            Assert.AreEqual(expected: "Invalid password format At least one special character such as an exclamation mark", actualResultat);
        }

        [TestCase("Di", "Di", "qwsdfeewQ_ed", "qwsdfeewQ_ed", "1234123123")]
        public void RegistrationWithInValidPasswordNumber(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutPassword() + " " + registrationPage.ErrorTextAboutPasswordNumbers();

            Assert.AreEqual(expected: "Invalid password format At least one number", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Q_d", "1234123123")]
        public void RegistrationWithInValidPasswordMath(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutPasswordMatch();

            Assert.AreEqual(expected: "Passwords match", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Qe_d", "143123")]
        public void RegistrationWithInValidPhone(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutPhone();

            Assert.AreEqual(expected: "Invalid phone format", actualResultat);
        }

        [TestCase("", "Di", "1234567890Qe_d", "1234567890Qe_d", "1231231234")]
        public void RegistrationWithEmptyFirstName(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutFirstName();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase("Di", "", "1234567890Qe_d", "1234567890Qe_d", "1231231234")]
        public void RegistrationWithEmptyLastName(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutLastName();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Qe_d", "1231231234")]
        public void RegistrationWithEmptyMail(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail("")
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutEmail();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase("Di", "Di", "", "1234567890Qe_d", "1231231234")]
        public void RegistrationWithEmptyPasword(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutPassword();

            Assert.AreEqual(expected: "Invalid password format", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "", "1231231234")]
        public void RegistrationWithEmptyConfirmPassword(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutConfitmPassword();

            Assert.AreEqual(expected: "Passwords must match", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Qe_d", "")]
        public void RegistrationWithEmptyPhone(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.ErrorTextAboutPhone();

            Assert.AreEqual(expected: "Invalid phone format", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Qe_d", "1231231234", "", "myComp.com",1)]
        public void RegistrationWitfInEmptyCompanyName(string firstName, string lastName, string password, string confirmPassword, string phone, 
                                                       string companyName, string companyWebSite, int count)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
                registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.AutoEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();

            registrationPage.InputCompanyName(companyName)
                .InputCompanyWebSite(companyWebSite)
                .InputCompanyAddress("3435 Wilshire Boulevard, Los Angeles, CA, USA")
                .InputCompanyIndustry(count)//1-6 a count of industry. 6 - other, added a new field
                .ClickOnFinishRegistration();
            var actualResultat = registrationPage.ErrorTextAboutCompanyName();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Qe_d", "1231231234", "muComp12", "", 2)]
        public void RegistrationWitfInEmptyCompanyWebSite(string firstName, string lastName, string password, string confirmPassword, string phone,
                                                          string companyName, string companyWebSite, int count)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
            .InputFirstName(firstName)
            .InputLastName(lastName)
            .InputEmail(Helper.AutoEmailUser())
            .InputPassword(password)
            .InputConfirmPassword(confirmPassword)
            .InputPhoneNumber(phone)
            .ClickNextButton();

            registrationPage.InputCompanyName(companyName)
                .InputCompanyWebSite(companyWebSite)
                .InputCompanyAddress("3435 Wilshire Boulevard, Los Angeles, CA, USA")
                .InputCompanyIndustry(count)//1-6 a count of industry. 6 - other, added a new field
                .ClickOnFinishRegistration();
            var actualResultat = registrationPage.ErrorTextAboutCompanyWebSite();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Qe_d", "1231231234", "muComp12", "myComp12.com", 2)]
        public void RegistrationWitfInEmptyAddress(string firstName, string lastName, string password, string confirmPassword, string phone,
                                                   string companyName, string companyWebSite, int count)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
            .InputFirstName(firstName)
            .InputLastName(lastName)
            .InputEmail(Helper.AutoEmailUser())
            .InputPassword(password)
            .InputConfirmPassword(confirmPassword)
            .InputPhoneNumber(phone)
            .ClickNextButton();

            registrationPage.InputCompanyName(companyName)
                .InputCompanyWebSite(companyWebSite)
                .InputCompanyAddress("")
                .InputCompanyIndustry(count)//0-6 a count of industry. 6 - other, added a new field
                .ClickOnFinishRegistration();
            var actualResultat = registrationPage.ErrorTextAboutAddress();

            Assert.AreEqual(expected: "Please choose a location from the suggested addresses. This field doesn’t accept custom addresses, or “#” symbols.", actualResultat);
        }


        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Qe_d", "1231231234", "muComp12", "myComp12.com", 2)]
        public void RegistrationWitfInValidAddress(string firstName, string lastName, string password, string confirmPassword, string phone,
                                                   string companyName, string companyWebSite, int count)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
            .InputFirstName(firstName)
            .InputLastName(lastName)
            .InputEmail(Helper.AutoEmailUser())
            .InputPassword(password)
            .InputConfirmPassword(confirmPassword)
            .InputPhoneNumber(phone)
            .ClickNextButton();

            registrationPage.InputCompanyName(companyName)
                .InputCompanyWebSite(companyWebSite)
                .InputCompanyAddress("zxscascvasqrqfxzavcszdfasfdsafafs")
                .InputCompanyIndustry(count)//0-6 a count of industry. 6 - other, added a new field
                .ClickOnFinishRegistration();
            var actualResultat = registrationPage.ErrorTextAboutAddress();

            Assert.AreEqual(expected: "Please choose a location from the suggested addresses. This field doesn’t accept custom addresses, or “#” symbols.", actualResultat);
        }

        [TestCase("Di", "Di", "1234567890Qe_d", "1234567890Qe_d", "1231231234", "muComp12", "myComp12.com", 6)]
        public void RegistrationWitfInEmptyIndustry(string firstName, string lastName, string password, string confirmPassword, string phone,
                                                    string companyName, string companyWebSite, int count)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
            .InputFirstName(firstName)
            .InputLastName(lastName)
            .InputEmail(Helper.AutoEmailUser())
            .InputPassword(password)
            .InputConfirmPassword(confirmPassword)
            .InputPhoneNumber(phone)
            .ClickNextButton();

            registrationPage.InputCompanyName(companyName)
                .InputCompanyWebSite(companyWebSite)
                .InputCompanyAddress("3435 Wilshire Boulevard, Los Angeles, CA, USA")
                .InputCompanyIndustry(count)
                .InputOtherIndustry("") //0-6 a count of industry. 6 - other, added a new field
                .ClickOnFinishRegistration();
            var actualResultat = registrationPage.ErrorTextAboutOtherIndustry();

            Assert.AreEqual(expected: "Required", actualResultat);
        }
    }
}
