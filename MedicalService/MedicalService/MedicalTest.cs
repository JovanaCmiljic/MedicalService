using MedicalService.Driver;
using MedicalService.Page;

namespace MedicalService
{
    public class Tests
    {
        LoginPage loginPage;
        MedicalPage medicalPage;


        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            medicalPage = new MedicalPage();
        }
        [TearDown]
        public void Close() 
        {
            WebDrivers.CleanUp();
        
        }

        [Test]
        public void TC01_MakeAppointmen_ShouldAppointmentBeCompleted()
        {
            loginPage.AppMed.Click();
            loginPage.Login( "John Doe", "ThisIsNotAPassword" );
            medicalPage.SelectOption("Hongkong CURA Healthcare Center");
            medicalPage.CheckBox.Click();
            medicalPage.MedicId.Click();
            medicalPage.Date.SendKeys("17/11/2022");
            medicalPage.Comment.SendKeys("Zakazano");
            medicalPage.ButtonApp.Submit();

            Assert.That("Appointment Confirmation",Is.EqualTo(medicalPage.Confirm.Text));
        }

    }
}