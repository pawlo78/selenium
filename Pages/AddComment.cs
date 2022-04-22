using OpenQA.Selenium;
using wswoimtempie.BaseClass;
using SeleniumExtras.PageObjects;
using AventStack.ExtentReports;

namespace wswoimtempie.Pages
{
    public class AddComment
    {
        [FindsBy(How = How.Id, Using = "comment")]
        public IWebElement TextArea { get; set; }

        [FindsBy(How = How.Id, Using = "author")]
        public IWebElement Author { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "url")]
        public IWebElement Url { get; set; }

        [FindsBy(How = How.Id, Using = "wp-comment-cookies-consent")]
        public IWebElement Cookie { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        public IWebElement Submit { get; set; }
        
        public AddComment(ExtentTest test)
        {
            PageFactory.InitElements(StaticDriver.driver, this);
        }

        public void PublicComment(ExtentTest test, string text, string author, string email, string url, bool cookie )
        {
            TextArea.SendKeys(text);
            WaitHelper.WaitUntilElementValueEquals(TextArea, text);
            test.Log(Status.Pass, "SendKeys Expression to TextArea" + text + "");
            Author.SendKeys(author);
            WaitHelper.WaitUntilElementValueEquals(Author, author);
            test.Log(Status.Pass, "SendKeys Expression to Author" + author + "");
            Email.SendKeys(email);
            WaitHelper.WaitUntilElementValueEquals(Email, email);
            test.Log(Status.Pass, "SendKeys Expression to Email" + email + "");
            Url.SendKeys(url);
            WaitHelper.WaitUntilElementValueEquals(Url, url);
            test.Log(Status.Pass, "SendKeys Expression to Url" + url + "");
            if (cookie == true)
            {
                Cookie.Click();
                test.Log(Status.Pass, "Login cookies click");
            }            
            Submit.Click();
            test.Log(Status.Pass, "Login button click");
        }
    }
}
