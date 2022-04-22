using OpenQA.Selenium;
using wswoimtempie.BaseClass;
using SeleniumExtras.PageObjects;
using AventStack.ExtentReports;

namespace wswoimtempie.Pages
{
    public class HomePage
    {
        public IWebDriver Driver { get; set; }
        
        public HomePage()
        {            
            PageFactory.InitElements(StaticDriver.driver, this);            
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div/header/hgroup/h1/a")]
        public IWebElement PageName { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/header/nav/div/ul/li[1]/a")]
        public IWebElement LinkStronaGlowna { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "page-item-2")]
        public IWebElement LinkInformacje { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "page-item-198")]
        public IWebElement LinkKontakt { get; set; }

        [FindsBy(How = How.ClassName, Using = "page-item-3")]
        public IWebElement LinkPrivacyPolicy { get; set; }

        [FindsBy(How = How.Id, Using = "wp-block-search__input-1")]
        public IWebElement InputSearch { get; set; }

        [FindsBy(How = How.ClassName, Using = "wp-block-search__button")]
        public IWebElement ButtonSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div/article[1]/header/h1/a")]
        public IWebElement LinkToDisplayPost { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div/article[1]/header/div/a")]
        public IWebElement LinkToDisplayCommentsPost { get; set; }



        public AddComment ClickLinkToDisplayPost(ExtentTest test)
        {
            LinkToDisplayPost.Click();
            test.Log(Status.Pass, "Login DisplayPost Click");
            return new AddComment(test); 
        }

        public void ClickLinkToDisplayCommentsPost(ExtentTest test)
        {
            LinkToDisplayCommentsPost.Click();
            test.Log(Status.Pass, "Login DisplayCommentsPost Click");
        }

        public void SearchExpression(ExtentTest test, string expression)
        {
            InputSearch.SendKeys(expression);
            WaitHelper.WaitUntilElementValueEquals(InputSearch, expression);
            test.Log(Status.Pass, "SendKeys Expression to Input");
            ButtonSearch.Click();
            test.Log(Status.Pass, "Login button click");
        }
                
        
        public void ClickPageName(ExtentTest test)
        {                        
            PageName.Click();
            test.Log(Status.Pass, "Login PageName Click");
        }
        
        public void ClickLinkStronaGlowna(ExtentTest test)
        {           
            LinkStronaGlowna.Click();
            test.Log(Status.Pass, "Login LinkStronaGlowna Click");
        }

        public void ClickLinkInformacje(ExtentTest test)
        {
            LinkInformacje.Click();
            test.Log(Status.Pass, "Login LinkInformacje Click");
        }

        public void ClickLinkKontakt(ExtentTest test)
        {
            LinkKontakt.Click();
            test.Log(Status.Pass, "Login LinkKontakt Click");
        }

        public void ClickLinkPrivacyPolicy(ExtentTest test)
        {
            LinkPrivacyPolicy.Click();
            test.Log(Status.Pass, "Login LinkPrivacyPolicy Click");
        }

    }
}
