using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AmazonTest
{

[TestFixture]
public class BasePage
{
    protected static IWebDriver _driver = null!;

    protected void OpenBrowser()
    {
        string browser = Environment.GetEnvironmentVariable("BROWSER") ?? "FIREFOX";

        switch (browser.ToUpperInvariant())
        {
            case "CHROME":
                _driver = new ChromeDriver();
                break;
            case "FIREFOX":
                _driver = new FirefoxDriver();
                break;
            case "Edge":
                _driver = new EdgeDriver();
                break;
            default:
                throw new ArgumentException($"Browser not yet implemented: {browser}");
        }

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Manage().Window.Maximize();
    }

    protected void CloseBrowser()
    {
        _driver?.Dispose();
    }

    public void openURL()
    {
        _driver.Url = "https://www.amazon.co.uk/";
        List<ReadOnlyCollection<IWebElement>> elementList = new List<ReadOnlyCollection<IWebElement>>();
        elementList.AddRange(new[] { _driver.FindElements(By.Id("sp-cc-accept")) });
        
        if (elementList.Count > 0)
        {
            _driver.FindElement(By.Id("sp-cc-accept")).Click();
        }
    }

    public void waitforElement(By element)
    {
        WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        w.Until(ExpectedConditions.ElementExists(element));
    }
}
}