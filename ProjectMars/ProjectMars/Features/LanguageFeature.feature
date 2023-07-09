Feature: LanguageFeature

As a Mars user, 
I should be able to add, Update and Delete Language that I know, 
so that buyers can know the Languages I speak



Scenario: TC_002_01 Add new languages
	Given Launch Mars and login with valid credentials
    When Add Languages and level '<language>' and '<level>' I know
	Then Languages has been added successfully'<language>'and '<level>'

	Examples: 
	| language | level  |
	| English  | Fluent |
	| Hindi    | Basic  |
	| German   | Basic  |
	| French   | Basic |

Scenario Outline: TC_002_02 Update the existing language
Given Launch Mars and login with valid credentials
When I Update the existing language '<Language>' and '<Level>'
Then The record is updated'<Language>' and '<Level>'

Examples: 
| Language | Level |
| Spanish | Basic|
| Dutch | Basic |


Scenario:TC_002_09 Click on Cancel icon
Given Launch Mars and login with valid credentials
When I click on cancel icon of added 
Then Language record is deleted 

Scenario:TC_002_03 Language and level field empty
Given Launch Mars and login with valid credentials
When I left language and level field empty
Then Error message language and level empty is displayed

Scenario:TC_002_04 Duplicate language and same level
Given Launch Mars and login with valid credentials
When I add language and level already added '<language>' and '<level>'
Then Error message Language and level already exists is displayed

Examples: 
| language | level  |
| English  | Fluent |

Scenario:TC_002_05 Duplicate language with different level
Given Launch Mars and login with valid credentials
When I add language already added with different level '<language>','<level>'
Then Duplicated data message is displayed

Examples: 
| language | level          |
| English  | Conversational |

Scenario: TC_002_10 add language using keyboard keys
Given Launch Mars and login with valid credentials
When Add Languages I know using keyboard keys 
Then language is added successfully 

Scenario: TC_002_13 User clicks on update button without making changes
Given Launch Mars and login with valid credentials
When Click on edit icon and update button without making changes
Then Error message Language and level already added is displayed




