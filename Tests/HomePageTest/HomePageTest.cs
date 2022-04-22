using wswoimtempie.BaseClass;
using NUnit.Framework;
using wswoimtempie.Pages;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;


namespace wswoimtempie.Tests
{
    public class HomePageTest : BaseTestDriver
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


        [Test, Order(0), Category("TestHomePageMenu")]               
        public void TestPageName()
        {
            //sprawdzenie ignorowania testu
            ChangeIgnoreTest(Parameters.TestPageName, Parameters.TestHomePageMenu, Parameters.HomePageTest);
            var homePage = new HomePage();

            try
            {
                //uruchomienie raportowania
                testReport = extentRep.CreateTest("TestPageName").Info("Test started");                
                //przejście na podstronę informacje i powrót poprzez link nazwy strony
                homePage.ClickLinkInformacje(testReport);
                var text = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/article/header/h1")).Text;
                Assert.AreEqual("Informacje", text);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/sample-page/");
                homePage.ClickPageName(testReport);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/");
                //zamknięcie raportowania testu
                testReport.Log(Status.Pass, "TestPageName Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testPageName.jpg", ScreenshotImageFormat.Jpeg);
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

        
        [Test, Order(1), Category("TestHomePageMenu")]              
        public void TestLinkStronaGlowna()
        {
            ChangeIgnoreTest(Parameters.TestLinkStronaGlowna, Parameters.TestHomePageMenu, Parameters.HomePageTest);
            var homePage = new HomePage();

            try
            {
                testReport = extentRep.CreateTest("TestLinkStronaGlowna").Info("Test started");
                homePage.ClickLinkInformacje(testReport);
                var text = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/article/header/h1")).Text;
                Assert.AreEqual("Informacje", text);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/sample-page/");
                homePage.ClickLinkStronaGlowna(testReport);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/");
                testReport.Log(Status.Pass, "TestLinkStronaGlowna Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testLinkStronaGlowna.Png", ScreenshotImageFormat.Png);
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


        [Test, Order(2), Category("TestHomePageMenu")]
        public void TestLinkInformacje()
        {
            ChangeIgnoreTest(Parameters.TestLinkInformacje, Parameters.TestHomePageMenu, Parameters.HomePageTest);
            var homePage = new HomePage();

            try
            {
                testReport = extentRep.CreateTest("TestLinkInformacje").Info("Test started");
                homePage.ClickLinkInformacje(testReport);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/sample-page/");
                var text = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/article/header/h1")).Text;
                Assert.AreEqual("Informacje", text);
                testReport.Log(Status.Pass, "TestLinkInformacje Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testLinkInformacje.jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (StaticDriver.driver != null)
                {
                    StaticDriver.driver.Quit();
                }
            }            
        }


        [Test, Order(3), Category("TestHomePageMenu")]
        public void TestLinkKontakt()
        {
            ChangeIgnoreTest(Parameters.TestLinkKontakt, Parameters.TestHomePageMenu, Parameters.HomePageTest);
            var homePage = new HomePage();

            try
            {
                testReport = extentRep.CreateTest("TestLinkKontakt").Info("Test started");
                homePage.ClickLinkKontakt(testReport);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/kontakt/");
                var text = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/article/header/h1")).Text;
                Assert.AreEqual("Kontakt", text);
                testReport.Log(Status.Pass, "TestLinkKontakt Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testLinkKontakt.jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (homePage.Driver != null)
                {
                    homePage.Driver.Quit();
                }
            }            
        }


        [Test, Order(4), Category("TestHomePageMenu")]
        public void TestLinkPrivacyPolicy()
        {
            ChangeIgnoreTest(Parameters.TestLinkPrivacyPolicy, Parameters.TestHomePageMenu, Parameters.HomePageTest);
            var homePage = new HomePage();

            try
            {
                testReport = extentRep.CreateTest("TestLinkPrivacyPolicy").Info("Test started");
                homePage.ClickLinkPrivacyPolicy(testReport);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/privacy-policy/");
                var text = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/article/header/h1")).Text;
                Assert.AreEqual("Privacy Policy", text);
                testReport.Log(Status.Pass, "TestLinkPrivacyPolicy Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testLinkPrivacyPolicy.jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (StaticDriver.driver != null)
                {
                    StaticDriver.driver.Quit();
                }
            }                       
        }

        [Test, Order(5), Category("TestHomePageSearch")]
        [TestCase("")]        
        public void TestSearchWithoutExpression(string expression)
        {
            ChangeIgnoreTest(Parameters.TestSearchWithoutExpression, Parameters.TestHomePageSearch, Parameters.HomePageTest);
            var homePage = new HomePage();

            try
            {
                testReport = extentRep.CreateTest("TestSearchWithoutExpression").Info("Test started");
                homePage.SearchExpression(testReport, expression);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/");                
                testReport.Log(Status.Pass, "TestSearchWithoutExpression Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testSearchWithoutExpression.jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (StaticDriver.driver != null)
                {
                    StaticDriver.driver.Quit();
                }
            }
        }

        [Test, Order(6), Category("TestHomePageSearch")]
        [TestCase("Theory", 1)]
        [TestCase("Words", 2)]
        [TestCase("Many", 3)]
        [TestCase("Bonorum et Malorum", 4)]
        [TestCase("chunks as necessary", 5)]
        public void TestSearchExpressionTrue(string expression, int noTest)
        {
            ChangeIgnoreTest(Parameters.TestSearchExpressionTrue, Parameters.TestHomePageSearch, Parameters.HomePageTest);
            var homePage = new HomePage();
            //tworzenie adresu na podstawie wyszukiwanego wyrażenia
            //dla assercji adresu
            string expressionToLink = CreateAssertLink(expression);

            try
            {
                testReport = extentRep.CreateTest("TestSearchExpressionTrue").Info("Test started");
                homePage.SearchExpression(testReport, expression);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/?s="+ expressionToLink +"");
                var textx = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/section/div/header/h1")).Text;
                string texty = "Wyniki wyszukiwania: " + expression + "";
                Assert.AreEqual(texty.ToUpper(), textx);
                testReport.Log(Status.Pass, "TestSearchExpressionTrue Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testSearchExpressionTrue"+ noTest +".jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (StaticDriver.driver != null)
                {
                    StaticDriver.driver.Quit();
                }
            }
        }

        [Test, Order(7), Category("TestHomePageSearch")]
        [TestCase("1234", 1)]
        [TestCase("abcde", 2)]
        [TestCase("* *", 3)]
        [TestCase("   ", 4)]
        public void TestSearchExpressionFalse(string expression, int noTest)
        {
            ChangeIgnoreTest(Parameters.TestSearchExpressionFalse, Parameters.TestHomePageSearch, Parameters.HomePageTest);
            var homePage = new HomePage();
            //tworzenie adresu na podstawie wyszukiwanego wyrażenia
            //dla assercji adresu
            string expressionToLink = CreateAssertLink(expression);

            try
            {                
                testReport = extentRep.CreateTest("TestSearchExpressionFalse").Info("Test started");
                homePage.SearchExpression(testReport, expression);
                Assert.AreEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/?s=" + expressionToLink + "");
                var textx = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/section/div/article/header/h1")).Text;
                string texty = "Niczego nie znaleziono";
                Assert.AreEqual(texty, textx);
                testReport.Log(Status.Pass, "TestSearchExpressionFalse Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testSearchExpressionFalse" + noTest + ".jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (StaticDriver.driver != null)
                {
                    StaticDriver.driver.Quit();
                }
            }
        }


        [Test, Order(8), Category("TestHomePageSearch")]
        [TestCase("105 OR 1=1", 1)]
        [TestCase("' or '' = '", 2)]
        [TestCase("105; DROP TABLE Suppliers", 3)]        
        public void TestSearchExpressionSqlInjection(string expression, int noTest)
        {
            ChangeIgnoreTest(Parameters.TestSearchExpressionSqlInjection, Parameters.TestHomePageSearch, Parameters.HomePageTest);
            var homePage = new HomePage();
            //tworzenie adresu na podstawie wyszukiwanego wyrażenia
            //dla assercji adresu
            string expressionToLink = CreateAssertLink(expression);

            try
            {
                testReport = extentRep.CreateTest("TestSearchExpressionSqlInjection").Info("Test started");
                homePage.SearchExpression(testReport, expression);
                Assert.AreNotEqual(StaticDriver.driver.Url, "https://www.wswoimtempie.pl/postman/?s=" + expressionToLink + "");
                testReport.Log(Status.Pass, "TestSearchExpressionSqlInjection Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testSearchExpressionSqlInjection" + noTest + ".jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (StaticDriver.driver != null)
                {
                    StaticDriver.driver.Quit();
                }
            }
        }


        [Test, Order(9), Category("TestHomePagePosts")]
        public void TestLinkToDisplayCommentsPost()
        {
            ChangeIgnoreTest(Parameters.TestLinkToDisplayCommentsPost, Parameters.TestHomePagePosts, Parameters.HomePageTest);
            var homePage = new HomePage();            

            try
            {
                testReport = extentRep.CreateTest("TestLinkToDisplayCommentsPost").Info("Test started");
                homePage.ClickLinkToDisplayCommentsPost(testReport);
                var urlAddress = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/article[1]/header/div/a")).GetAttribute("href");
                Assert.AreEqual(StaticDriver.driver.Url, urlAddress);
                testReport.Log(Status.Pass, "TestLinkToDisplayCommentsPost Passed");
            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\HomePageTest\ScreenShots\testLinkToDisplayCommentsPost.jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (StaticDriver.driver != null)
                {
                    StaticDriver.driver.Quit();
                }
            }
        }


        [Test, Order(10), Category("TestHomePagePosts")]
        public void TestDisplayedPost()
        {
            ChangeIgnoreTest(Parameters.TestDisplayedPost, Parameters.TestHomePagePosts, Parameters.HomePageTest);
            var homePage = new HomePage();

            try
            {
                testReport = extentRep.CreateTest("TestDisplayedPost").Info("Test started");
                Pages.AddComment dispPost = homePage.ClickLinkToDisplayPost(testReport);
                var titleComments = StaticDriver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/form/p[2]/label")).Text;
                Assert.AreEqual("Komentarz", titleComments);
                var titleButton = StaticDriver.driver.FindElement(By.XPath("//*[@id='submit']")).GetAttribute("value");
                Assert.AreEqual("Opublikuj komentarz", titleButton);
                testReport.Log(Status.Pass, "TestDisplayedPost Passed");

            }
            catch (Exception ex)
            {
                testReport.Log(Status.Fail, ex.ToString());
                var scsh = ((ITakesScreenshot)StaticDriver.driver).GetScreenshot();
                scsh.SaveAsFile(@"C:\sciezka\Tests\DisplayedPostTest\ScreenShots\testDisplayedPost.jpg", ScreenshotImageFormat.Jpeg);
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


        //sprawdzenie ignorowania testu
        public static void ChangeIgnoreTest(bool paramTest, bool paramCategory, bool paramFile)
        {
            if (paramTest)
                Assert.Ignore();
            if (paramCategory)
                Assert.Ignore();
            if (paramFile)
                Assert.Ignore();
        }

        //tworzenie linka na podstawie wyszukiwanego wyrażenia
        public static string CreateAssertLink(string exp)
        {
            char spacja = ' ';
            string expressionToLink = "";
            foreach (char item in exp)
            {
                if (item == spacja)
                {
                    expressionToLink += "+";
                }
                else
                {
                    expressionToLink += item;
                }
            }
            return expressionToLink;
        }

    }
}