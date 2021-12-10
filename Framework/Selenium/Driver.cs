using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Selenium {
    public static class Driver {

        [ThreadStatic]
        private static IWebDriver _driver;
        
        public static void Init() {
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }    

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("Driver is Null!");
        
    }
}