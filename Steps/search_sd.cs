using AmazonTest.Pages;

namespace AmazonTest
{

[Binding]
public class SearchSd : BasePage
{
    private SearchPage _searchPage = new SearchPage(_driver);


    [Given(@"I enter the Amazon URL")]
    public void GivenIEnterTheAmazonUrl()
    {
        openURL();
    }

    [When(@"I search for ""(.*)""")]
    public void WhenISearchFor(string searchWord)
    {
        _searchPage.SearchwithText(searchWord);
        _searchPage.clickSearch();
    }

    [Then(@"I should see ""(.*)"" and ""(.*)"" Echo Dot speaker")]
    public void ThenIShouldSeeAndEchoDotSpeaker(string result1, string result2)
    {
        _searchPage.verifyResults(result1,result2);
    }

    [When(@"I add Third generation Echo Dot speaker to the  basket")]
    public void WhenIAddThirdGenerationEchoDotSpeakerToTheBasket()
    {
        _searchPage.addTotheBasket();
    }

    [Then(@"I should see ""(.*)"" message")]
    public void ThenIShouldSeeMessage(string p0)
    {
        _searchPage.verifyAddToCartMsg(p0);
    }
}
}