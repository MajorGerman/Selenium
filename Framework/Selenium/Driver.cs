using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Selenium {
    public static class Driver {

        [ThreadStatic]
        private static IWebDriver _driver;
        
        public static void Init() {
            FW.Log.Info("Browser was opened: Google Chrome");
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }    

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("Driver is Null!");
        
        public static void GoTo(string url) {
            if (!url.StartsWith("http")) {
                url = $"http://{url}";
            }

            FW.Log.Info("Went to: " + url);
            Current.Navigate().GoToUrl(url);
        }

        public static void Quit() {
            FW.Log.Info("Browser was Closed");
            Current.Quit();
            Current.Dispose();
        }

        public static IWebElement FindElement(By by) {
            FW.Log.Step("Element was Found: " + by.Criteria);
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by) {
            return Current.FindElements(by);
        }
    }
}