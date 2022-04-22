using wswoimtempie.BaseClass;
using NUnit.Framework;
using wswoimtempie.Pages;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Threading;
using System.Collections.Generic;

namespace wswoimtempie.Tests
{
    public class AddComment : BaseTestDriver
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


        [Test, Order(0), Category("TestAddComment")]
        [TestCase("Adama12345", "Adam", "adam@adam.pl", "adam.pl", false)]
        [TestCase("Jolaa12345", "Jola", "jola@jola.pl", "", true)]
        [TestCase("Zosiaa12345", "Zosia", "zosia@jola.pl", "zosia.pl", true)]
        public void TestAddCommentCorrect(string text, string author, string email, string url, bool cookie)
        {
            //sprawdzenie ignorowania testu
            ChangeIgnoreTest(Parameters.TestAddCommentCorrect, Parameters.TestAddComment, Parameters.AddCommentTest);
            var homePage = new HomePage();
            List<IWebElement> el = new List<IWebElement>();

            try
            {
                //przerwy między wysyłaniem komentarzy
                //problem ze zbyt szybkim wstawianiu komentarzy
                Thread.Sleep(12000);

                testReport = extentRep.CreateTest("TestAddCommentCorrect").Info("Test started");
                Pages.AddComment addCom = homePage.ClickLinkToDisplayPost(testReport);
                               
                //sprawdzenie czy są jakieś komentarze                
                el.AddRange(StaticDriver.driver.FindElements(By.XPath("/html/body/div/div/div[1]/div/div/h2")));

                if ( el.Count > 0) {
                    //pobranie liczby komentarzy
                    var currentNoComments = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/h2")).Text;
                    string[] currentComment = currentNoComments.Split(" ");
                    //działanie                
                    addCom.PublicComment(testReport, text, author, email, url, cookie);
                    //pobranie nowej liczby komentarzy
                    var newNoComments = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/h2")).Text;
                    string[] newComment = newNoComments.Split(" ");
                    //assercja
                    Assert.AreEqual(Int32.Parse(newComment[0]), Int32.Parse(currentComment[0]) + 1);

                    //porównanie wpisów
                    var textFromPage = StaticDriver.driver.FindElement(By.XPath("html/body/div/div/div[1]/div/div/ol/li[" + Int32.Parse(newComment[0]) + "]/article/section/p")).Text;
                    Assert.AreEqual(text, textFromPage);
                    testReport.Log(Status.Pass, "TestAddCommentCorrect Passed");
                } else
                {
                    addCom.PublicComment(testReport, text, author, email, url, cookie);
                  
                    //porównanie wpisów
                    var textFromPage = StaticDriver.driver.FindElement(By.XPath("html/body/div/div/div[1]/div/div/ol/li[1]/article/section/p")).Text;
                    Assert.AreEqual(text, textFromPage);
                    testReport.Log(Status.Pass, "TestAddCommentCorrect (1) Passed");
                }
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\Users\pwantola\Desktop\NUnit\wswoimtempie\Tests\AddCommentTest\ScreenShots\testDisplayedPost" + author + ".jpg", ScreenshotImageFormat.Jpeg);
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


        [Test, Order(0), Category("TestAddComment")]
        [TestCase("", "Tomek", "tomek@tomek.pl", "tomek.pl", true)]
        [TestCase("Tomek1", "", "tomek@tomek.pl", "tomek.pl", false)]
        [TestCase("Tomek12", "Tomek", "", "", true)]
        [TestCase("Tomek123", "Tomek", "tomektomek.pl", "", true)]
        [TestCase("Tomek1234", "Tomek", "tomek@tomek", "tomek.pl", true)]
        public void TestAddCommentInCorrect(string text, string author, string email, string url, bool cookie)
        {
            ChangeIgnoreTest(Parameters.TestAddCommentInCorrect, Parameters.TestAddComment, Parameters.AddCommentTest);
            var homePage = new HomePage();

            try
            {
                //przerwy między wysyłaniem komentarzy
                Thread.Sleep(2000);

                testReport = extentRep.CreateTest("TestAddCommentInCorrect").Info("Test started");
                Pages.AddComment addCom = homePage.ClickLinkToDisplayPost(testReport);

                
                //pobranie liczby komentarzy
                var currentNoComments = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/h2")).Text;
                string[] currentComment = currentNoComments.Split(" ");
                //działanie                
                addCom.PublicComment(testReport, text, author, email, url, cookie);
                Thread.Sleep(1000);

                if (text == "" || author == "" || email == "")
                {
                    //pobranie nowej liczby komentarzy
                    var newNoComments = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/h2")).Text;
                    string[] newComment = newNoComments.Split(" ");
                    //assercja
                    Assert.AreEqual(Int32.Parse(newComment[0]), Int32.Parse(currentComment[0]));
                } else
                {
                    Assert.AreEqual("https://www.wswoimtempie.pl/postman/wp-comments-post.php", StaticDriver.driver.Url);
                }
                testReport.Log(Status.Pass, "TestAddCommentCorrect Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\Users\pwantola\Desktop\NUnit\wswoimtempie\Tests\AddCommentTest\ScreenShots\testDisplayedPost" + author + ".jpg", ScreenshotImageFormat.Jpeg);
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
