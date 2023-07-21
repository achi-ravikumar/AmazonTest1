Feature: Amazon Search

    @search
    Scenario: Search Amazon
        Given I enter the Amazon URL
        When I search for "echo dot"
        Then I should see "3rd gen" and "4th gen" Echo Dot speaker
        When I add Third generation Echo Dot speaker to the  basket
