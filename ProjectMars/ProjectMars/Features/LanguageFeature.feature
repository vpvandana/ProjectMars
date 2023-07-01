Feature: LanguageFeature

As a Mars user, 
I should be able to add, Update and Delete Language that I know, 
so that buyers can know the Languages I speak



Scenario: TC_002_01 Add new languages
	Given Launch Mars and login with valid credentials
	When I navigate language section in profile page
	And Add Languages I know
	Then Languages has been added successfully

Scenario Outline: TC_002_02 Update the existing language
Given Launch Mars and login with valid credentials
When I navigate language section in profile page
And I Update the existing language '<Language>' and '<Level>'
Then The record is updated'<Language>' and '<Level>'

Examples: 
| Language | Level          |
| Hindi    | Basic          |
| English  | Basic          |

Scenario:TC_002_03 Language and level field empty
Given Launch Mars and login with valid credentials
When I navigate language section in profile page 
And I left language and level field empty
Then Error message is displayed


