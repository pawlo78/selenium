using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace wswoimtempie.BaseClass
{
    public static class WaitHelper
    {
        private static TimeSpan AmountOfTime { get; } = TimeSpan.FromSeconds(2);   


        public static void WaitUntilElementValueEquals(IWebElement element, string valueToCheck)
        {
            var wait = new WebDriverWait(StaticDriver.driver, AmountOfTime);
            wait.Until(x => element.GetAttribute("value") == valueToCheck);            
        }


        public static void WaitUntilElementToBeClicable(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(StaticDriver.driver, TimeSpan.FromMilliseconds(700));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();            
        }

        public static void WaitUntilElementIsVisible()
        {
            var wait = new WebDriverWait(StaticDriver.driver, AmountOfTime);
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("container")));
        }
        


    }
}
