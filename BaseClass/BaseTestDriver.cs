using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace wswoimtempie.BaseClass
{
    public class BaseTestDriver
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            StaticDriver.driver = new ChromeDriver();
            StaticDriver.driver.Manage().Window.Maximize();
            StaticDriver.driver.Navigate().GoToUrl("https://wswoimtempie.pl/postman");
        }

        [TearDown]
        public void QuitDriver()
        {
            StaticDriver.driver.Quit();
        }
    }
}
