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

Scenario:TC_002_04 Duplicate language and duplicate level
Given Launch Mars and login with valid credentials
When I navigate language section in profile page
And I add language and level already added
Then Error message Language and level already exists is displayed

Scenario:TC_002_05 Duplicate language with different level
Given Launch Mars and login with valid credentials
When I navigate language section in profile page
And I add language already added with different level
Then Duplicated data message is displayed

Scenario:TC_002_07 Same language with different case
Given Launch Mars and login with valid credentials
When I navigate language section in profile page
And I add already added language with differnt case
Then Language already exixts error message is displayed

Scenario:TC_002_08 I Click on Cancel icon
Given Launch Mars and login with valid credentials
When I navigate language section in profile page
And I click on cancel icon of added language
Then Language record is deleted

Scenario: TC_002_09 add language using keyboard keys
Given Launch Mars and login with valid credentials
When I navigate language section in profile page
And Add Languages I know using keyboard keys
Then language is added successfully 

Scenario: TC_002_12 User clicks on update button without making changes
Given Launch Mars and login with valid credentials
When I navigate language section in profile page
And I Click on edit icon and update button without making changes
Then Error message Language and level already added is displayed

