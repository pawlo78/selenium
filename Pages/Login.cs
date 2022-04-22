using OpenQA.Selenium;
using wswoimtempie.BaseClass;
using SeleniumExtras.PageObjects;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace wswoimtempie.Pages
{
    public class Login
    {
        public IWebDriver Driver { get; set; }
        
        public Login()
        {            
            PageFactory.InitElements(StaticDriver.driver, this);            
        }


        [FindsBy(How = How.Id, Using = "user_login")]
        public IWebElement InputUserLogin { get; set; }
        
        [FindsBy(How = How.Id, Using = "user_pass")]
        public IWebElement InputUserPass { get; set; }

        [FindsBy(How = How.Id, Using = "wp-submit")]
        public IWebElement ButtonLogin { get; set; }
        

        public void LoginWordpress(ExtentTest test, string username, string pass)
        {        

            InputUserLogin.SendKeys(username);
            WaitHelper.WaitUntilElementValueEquals(InputUserLogin, username);
            test.Log(Status.Pass, "SendKeys Expression to InputUserLogin");
            
            InputUserPass.SendKeys(pass);
            WaitHelper.WaitUntilElementValueEquals(InputUserPass, pass);
            test.Log(Status.Pass, "SendKeys Expression to InputUserPass");
            
            ButtonLogin.Click();
            test.Log(Status.Pass, "Login button click");
        }       
    }
}
