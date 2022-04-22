using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace wswoimtempie.BaseClass
{
    public class LoginDriver
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            StaticDriver.driver = new ChromeDriver();
            StaticDriver.driver.Manage().Window.Maximize();
            StaticDriver.driver.Navigate().GoToUrl("https://wswoimtempie.pl/postman/wp-admin/");
        }

        [TearDown]
        public void QuitDriver()
        {
            StaticDriver.driver.Quit();
        }
    }
}
