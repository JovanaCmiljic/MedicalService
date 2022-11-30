using MedicalService.Driver;
using MedicalService.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalService.Tests
{
     public class LoginTest
     {
        LoginPage loginPage;
        string message = "Login failed! Please ensure the username and password are valid.";

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            
        }
        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();

        }
        [Test]
        public void TC01_EnterInvalidUserName_ShouldNotBeLoginOnPage() 
        {
            loginPage.AppMed.Click();
            loginPage.Login("Jovana", "ThisIsNotAPassword");

            Assert.That(message,Is.EqualTo(loginPage.InvalidUserName.Text));
        }

        [Test]
        public void TC02_EnterInvalidPassword_ShouldNotBeLoginOnPage() 
        {
            loginPage.AppMed.Click();
            loginPage.Login("John Doe", "Jovana");

            Assert.That(message, Is.EqualTo(loginPage.InvalidUserName.Text));
        }
        [Test]
        public void TC03_EnterNoData_ShouldNotBeLoginOnPage()
        {
            loginPage.AppMed.Click();
            loginPage.Login("", "");

            Assert.That(message, Is.EqualTo(loginPage.InvalidUserName.Text));
        }
     }

}
    


