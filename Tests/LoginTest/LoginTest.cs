using wswoimtempie.BaseClass;
using NUnit.Framework;
using wswoimtempie.Pages;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;


namespace wswoimtempie.Tests
{
    public class LoginTest : LoginDriver
    {

        //obsługa raportu z testów
        ExtentReports extentRep;
        ExtentTest testReport;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extentRep = new ExtentReports();
            //ścieżka do katalogu do zapisu raportu
            var htmlReporter = new ExtentHtmlReporter(@"C:\sciezka\Tests\LoginTest\Reports\");
            extentRep.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extentRep.Flush();
        }


        
        [TestCase("", "")] 
        [TestCase("", "xxxxxxxxx")] 
        [TestCase("pawel", "")]
        [TestCase("pawel", "xxxxxxxx")]
        [TestCase("' or '' = '", "' or '' = '")]
        [TestCase("105 OR 1=1", "pass")]
        [TestCase("105; DROP TABLE Suppliers", "pass")]
        [Test, Order(0), Category("TestLogin")]               
        public void TestLoginInCorrect(string username, string pass)
        {
            //sprawdzenie ignorowania testu
            ChangeIgnoreTest(Parameters.TestLoginInCorrect, Parameters.TestLogin, Parameters.FileLoginTest);
            var login = new Login();

            try
            {
                //uruchomienie raportowania
                testReport = extentRep.CreateTest("TestPageName").Info("Test started");                
                login.LoginWordpress(testReport, username, pass);
                var errorLogin = StaticDriver.driver.FindElement(By.Id("login_error"));
                Assert.AreEqual(true,  errorLogin.Displayed);
                Assert.AreEqual("https://www.wswoimtempie.pl/postman/wp-login.php", StaticDriver.driver.Url);
                //zamknięcie raportowania testu
                testReport.Log(Status.Pass, "TestLoginInCorrect Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                //tworzenie screenshot
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                //ścieżka do katalogu z screenshot
                scsh.SaveAsFile(@"C:\sciezka\Tests\LoginTest\ScreenShots\loginTestInCorrect.jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
            finally
            {
                if (StaticDriver.driver != null)
                {
                    StaticDriver.driver.Quit();
                }
            }
        }


        
        [TestCase("user", "pass")]
        [Test, Order(1), Category("TestLogin")]
        public void TestLoginCorrect(string username, string pass)
        {
            ChangeIgnoreTest(Parameters.TestLoginCorrect, Parameters.TestLogin, Parameters.FileLoginTest);
            var login = new Login();

            try
            {
                testReport = extentRep.CreateTest("TestPageName").Info("Test started");
                login.LoginWordpress(testReport, username, pass);
                Assert.AreEqual("https://www.wswoimtempie.pl/postman/wp-login.php", StaticDriver.driver.Url);
                testReport.Log(Status.Pass, "TestLoginCorrect Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());                
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();                
                scsh.SaveAsFile(@"C:\sciezka\Tests\LoginTest\ScreenShots\loginTestCorrect.jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
            finally
            {
                if (StaticDriver.driver != null)
                {
                    StaticDriver.driver.Quit();
                }
            }
        }


        public static void ChangeIgnoreTest(bool paramTest, bool paramCategory, bool paramFile)
        {
            if (paramTest)
                Assert.Ignore();
            if (paramCategory)
                Assert.Ignore();
            if (paramFile)
                Assert.Ignore();
        }        

    }
}