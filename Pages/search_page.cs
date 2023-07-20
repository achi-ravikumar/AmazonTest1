using NUnit.Framework;
using OpenQA.Selenium;

namespace AmazonTest.Pages;

public class SearchPage : BasePage
{
    public SearchPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebDriver driver;
    private IWebElement SearchBox => _driver.FindElement(By.Id("twotabsearchtextbox"));
    private IWebElement SubmitButton => _driver.FindElement(By.Id("nav-search-submit-button"));

    private IWebElement addToCart => _driver.FindElement(By.Name("submit.add-to-cart"));

    private IWebElement addedToBasketMsg => _driver.FindElement(By.Id("NATC_SMART_WAGON_CONF_MSG_SUCCESS"));

    public IWebElement requiredElement;

    private List<IWebElement> searchResults =>
        new List<IWebElement>(_driver.FindElements(
            By.CssSelector("div[data-component-type = 's-search-result'] h2 a.a-link-normal.a-text-normal")));


    public void SearchwithText(String searchText)
    {
        waitforElement(By.Id("twotabsearchtextbox"));
        // _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); WE CAN USE THIS ALSO
        SearchBox.SendKeys(searchText);
    }

    public void clickSearch()
    {
        SubmitButton.Click();
    }

    public void verifyResults(String result1, String result2)
    {
        Boolean isResult1 = false;
        Boolean isResult2 = false;
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        foreach (var result in searchResults)
        {
            if (isResult1 == false)
            {
                if (result.Text.ToLower().Contains(result1))
                {
                    isResult1 = true;
                    requiredElement = result;
                }
            }

            if (isResult2 == false)
            {
                if (result.Text.ToLower().Contains(result2))
                {
                    isResult2 = true;
                }
            }
        }

        Assert.IsTrue(isResult1);
        Assert.IsTrue(isResult2);
        // We can click 3rd Gen item from here also. but added extra step in feature file   
    }

    public void addTotheBasket()
    {
        requiredElement.Click();
        // waitforElement(By.Name("submit.add-to-cart"));
        addToCart.Click();
    }

    public void verifyAddToCartMsg(String expectedMsg)
    {
        // waitforElement(By.Id("NATC_SMART_WAGON_CONF_MSG_SUCCESS"));
        // Assert.AreEqual(expectedMsg, addedToBasketMsg.Text);
    }
}