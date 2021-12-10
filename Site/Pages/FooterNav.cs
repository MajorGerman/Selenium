using OpenQA.Selenium;

namespace Site.Pages {

    public class FooterNav {

        public readonly FooterNavMap Map; 

        public FooterNav(IWebDriver driver) {
            Map = new FooterNavMap(driver);
        }
        public void VisitInsta() {
            Map.instaLink.Click();
        }

    }

    public class FooterNavMap {

        IWebDriver _driver;

        public FooterNavMap(IWebDriver driver) {
            _driver = driver;
        }
        public IWebElement instaLink => _driver.FindElement(By.CssSelector("img[src='./src/img/insta_logo.svg']")).FindElement(By.XPath("./.."));


    }
}