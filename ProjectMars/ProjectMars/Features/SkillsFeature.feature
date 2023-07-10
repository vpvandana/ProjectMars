Feature: SkillsFeature

As a Mars user, 
I should be able to add, Update and Delete Skills that I have, 
so that buyers can know the Skill set I have


Scenario Outline: TC_003_01 Add new skills
	Given Launch Mars with valid credentials
	When I add skills '<Skill>'  and '<Level>' I have
	Then New skills '<Skill>' and '<Level>' are added to the list

	Examples: 
	| Skill  | Level    |
	| Coding  | Beginner |
	| Testing | Beginner |


Scenario Outline: TC_003_02 Update the existing skill and level
Given Launch Mars and login with valid credentials
When I Update the existing skill and skill level '<skill>' and '<slevel>'
Then The skill record is updated'<skill>' and '<slevel>'

Examples: 
| skill   | slevel |
| Chess | Beginner |


Scenario: TC_003_08 Delete skill by clicking cancel icon
Given Launch Mars and login with valid credentials
When I click on cancel icon of added skill
Then Skill deleted successfully from list

Scenario: TC_003_03 Level and skill field empty
Given Launch Mars and login with valid credentials
When I left skill and level field empty
Then Error message to enter is displayed

Scenario Outline:TC_003_04 Add existing skill and level
Given Launch Mars and login with valid credentials
When I add skill and level '<skill>' and '<level>' already in the list
Then Error message Skill already exists is displayed 

Examples: 
| skill  | level    |
| Coding | Beginner |

Scenario Outline:TC_003_05 Duplicate skill with different level
Given Launch Mars and login with valid credentials
When I add same skill with different level '<skill>' and '<level>'
Then Error message Duplicated data is displayed

Examples:
| skill  | level  |
| Coding | Expert |

Scenario: TC_002_09 add skill using keyboard keys
Given Launch Mars and login with valid credentials
When Add Skills I have using keyboard keys 
Then Skill is added to the list successfully 