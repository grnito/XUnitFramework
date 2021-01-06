using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace FrameworkXUnit1.Config
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string chromedriverpath, bool headless)
        {
        IWebDriver webdriver = null;

            switch (browser)
            {
                case Browser.Firefox:
                    var optionsFirefox = new FirefoxOptions();
                    if (headless)
                        optionsFirefox.AddArgument("--headless");

                    webdriver = new FirefoxDriver(chromedriverpath, optionsFirefox);
                    break;

                case Browser.Chrome:
                    var options = new ChromeOptions();
                    if (headless)
                        options.AddArgument("--headless");

                    webdriver = new ChromeDriver(chromedriverpath, options);

                    break;
            }
            return webdriver;
        }
    }
}
