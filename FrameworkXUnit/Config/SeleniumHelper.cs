using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkXUnit1.Config
{
    public class SeleniumHelper : IDisposable
    {
        public IWebDriver WebDriver;
        public readonly ConfigurationHelper Configuration;
        public WebDriverWait Wait;

        public SeleniumHelper(Browser browser, ConfigurationHelper configuration, bool headless = true)
        {
            Configuration = configuration;
            WebDriver = WebDriverFactory.CreateWebDriver(browser, Configuration.WebDrivers, headless);
            WebDriver.Manage().Window.Maximize();
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
        }

        public string GetUrl()
        {
            return WebDriver.Url;
        }

        public void GoToUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public bool ValidateContentUrl(string content)
        {
            return Wait.Until(ExpectedConditions.UrlContains(content));
        }

        public void ClickLinkByText(string linkText)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText)));
            link.Click();
        }

        public void ClickButtonById(string buttonId)
        {
            var button = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(buttonId)));
            button.Click();
        }

        public void ClickByXPath(string xPath)
        {
            var element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            element.Click();
        }

        public IWebElement GetElementByClass(string classCss)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(classCss)));
        }

        public IWebElement GetElementByXPath(string xPath)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }

        public void FillTextBoxById(string idField, string value)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idField)));
            campo.SendKeys(value);
        }

        public void SelectDropDownById(string idField, string value)
        {
            var selected = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idField)));
            var selectElement = new SelectElement(selected);
            selectElement.SelectByValue(value);
        }

        public string GetTextElementByClass(string className)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className))).Text;
        }

        public string GetElementTextById(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;
        }

        public string GetValueTextBoxById(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)))
                .GetAttribute("value");
        }

        public IEnumerable<IWebElement> GetListByClass(string className)
        {
            return Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(className)));
        }

        public bool ValidateIfElementExistById(string id)
        {
            return ElementExist(By.Id(id));
        }

        public void BackNavigation(int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                WebDriver.Navigate().Back();
            }
        }

        public void GetScreenShot(string nome)
        {
            SaveScreenShot(WebDriver.TakeScreenshot(), string.Format("{0}_" + nome + ".png", DateTime.Now.ToFileTime()));
        }

        private void SaveScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile($"{Configuration.FolderPicture}{fileName}", ScreenshotImageFormat.Png);
        }

        private bool ElementExist(By by)
        {
            try
            {
                WebDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Dispose()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }
}
